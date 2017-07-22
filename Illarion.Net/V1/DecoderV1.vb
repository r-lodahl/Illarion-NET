Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Illarion.Core.Types

Friend NotInheritable Class DecoderV1
  Implements IDecoder

  Private ReadOnly _shutdownToken As CancellationTokenSource
  Private ReadOnly _stream As NetworkStream
  Private ReadOnly _sink As IMessageSink
  Private ReadOnly _encoding As Encoding

  Private _receiveBuffer() As Byte

  Friend Sub New(stream As NetworkStream, sink As IMessageSink)
    If stream Is Nothing Then Throw New ArgumentNullException(NameOf(stream))
    If sink Is Nothing Then Throw New ArgumentNullException(NameOf(sink))

    _stream = stream
    _sink = sink
    _encoding = Encoding.GetEncoding("ISO-8859-1")
    _shutdownToken = New CancellationTokenSource()

    ReDim _receiveBuffer(999)

    ReceiveLoop()
  End Sub

  Private Async Sub ReceiveLoop()
    Dim token = _shutdownToken.Token

    Dim bufferCursor = 0
    While True
      bufferCursor = Await PopulateBuffer(bufferCursor, 6, token)

      Dim commandId = _receiveBuffer(0)
      Dim negCommandId = _receiveBuffer(1)

      If commandId = (negCommandId Xor Byte.MaxValue) Then
        'Command ID is properly matching
        Dim length = ReadShort(_receiveBuffer, 2)
        Dim crc = ReadShort(_receiveBuffer, 4)

        EnsureBufferSize(6 + length)
        bufferCursor = Await PopulateBuffer(bufferCursor, 6 + length, token)

        Dim resultCrc = CalculateCrc(_receiveBuffer, 6, length)
        If crc = resultCrc Then
          'Befehl ist gültig. Das geht an den Dekoder.
          Dim payload(0 To length - 1) As Byte
          Array.Copy(_receiveBuffer, 6, payload, 0, length)
          Dim payloadStream As New MemoryStream(payload) With {
              .Position = 0
          }
          PublishMessage(commandId, payloadStream)
          bufferCursor = 0
        End If
      End If

      If bufferCursor > 0 Then
        Array.ConstrainedCopy(_receiveBuffer, 1, _receiveBuffer, 0, bufferCursor - 1)
      End If
    End While
  End Sub

  Private Shared Function ReadShort(buffer() As Byte, offset As Integer) As Short
    Dim caster As New Caster With {
      .ByteValue2 = buffer(offset),
      .ByteValue1 = buffer(offset + 1)
    }
    Return caster.ShortValue1
  End Function

  Private Async Function PopulateBuffer(cursor As Integer, expected As Integer, token As CancellationToken) As Task(Of Integer)
    While cursor < expected
      cursor += Await _stream.ReadAsync(_receiveBuffer, cursor, expected - cursor, token)
    End While
    Return cursor
  End Function

  Private Sub EnsureBufferSize(size As Integer)
    If _receiveBuffer.Length < size Then
      ReDim Preserve _receiveBuffer(0 To size - 1)
    End If
  End Sub

  Private Async Sub PublishMessage(id As Byte, payload As Stream)
    Try
      Await Task.Run(Sub() _sink.ProcessMessage(Me, id, payload))
    Catch ex As Exception
      Debug.Fail("Unhandled exception received from message sink: " & ex.Message)
    End Try
  End Sub

  Public Sub Shutdown() Implements IDecoder.Shutdown
    _shutdownToken.Cancel()
  End Sub

  Public Function ReadString(stream As Stream) As String Implements IDecoder.ReadString
    Dim length = CInt(ReadShort(stream))
    Dim buffer(0 To length - 1) As Byte
    While length > 0
      length -= stream.Read(buffer, 0, length)
    End While
    Return _encoding.GetString(buffer)
  End Function

  Public Function ReadByte(stream As Stream) As Byte Implements IDecoder.ReadByte
    Return CByte(stream.ReadByte())
  End Function

  Public Function ReadShort(stream As Stream) As Short Implements IDecoder.ReadShort
    Dim caster As New Caster With {
        .ByteValue2 = CByte(stream.ReadByte()),
        .ByteValue1 = CByte(stream.ReadByte())
    }
    Return caster.ShortValue1
  End Function

  Public Function ReadCharacterId(stream As Stream) As CharacterId Implements IDecoder.ReadCharacterId
    Dim caster As New Caster With {
        .ByteValue4 = CByte(stream.ReadByte()),
        .ByteValue3 = CByte(stream.ReadByte()),
        .ByteValue2 = CByte(stream.ReadByte()),
        .ByteValue1 = CByte(stream.ReadByte())
    }
    Return caster.UIntegerValue
  End Function

  Public Function ReadLocation(stream As Stream) As Location Implements IDecoder.ReadLocation
    Dim x = ReadShort(stream)
    Dim y = ReadShort(stream)
    Dim z = ReadShort(stream)
    Return New Location(x, y, z)
  End Function
End Class
