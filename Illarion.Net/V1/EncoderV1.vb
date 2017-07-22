Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports Illarion.Core.Types
Imports Illarion.Net

Friend NotInheritable Class EncoderV1
  Implements IEncoder

  Private ReadOnly _stream As NetworkStream
  Private ReadOnly _encoding As Encoding

  Public Shared ReadOnly Property MaxStringLength As Integer
    Get
      Return UShort.MaxValue
    End Get
  End Property

  Friend Sub New(stream As NetworkStream)
    _stream = stream
    _encoding = Encoding.GetEncoding("ISO-8859-1")
  End Sub

  Public Sub Encode(value As String, stream As Stream) Implements IEncoder.Encode
    Dim byteString = _encoding.GetBytes(value)
    Dim length = Math.Min(MaxStringLength, byteString.Length)
    Encode(CUShort(length), stream)
    stream.Write(byteString, 0, byteString.Length)
  End Sub

  Public Sub Encode(value As Byte, stream As Stream) Implements IEncoder.Encode
    stream.WriteByte(value)
  End Sub

  Public Sub Encode(value As UShort, stream As Stream) Implements IEncoder.Encode
    Dim caster As New Caster With {.UShortValue1 = value}
    Dim buffer(0 To 2) As Byte
    buffer(0) = caster.ByteValue2
    buffer(1) = caster.ByteValue1
    stream.Write(buffer, 0, 2)
  End Sub

  Public Sub Encode(value As Short, stream As Stream) Implements IEncoder.Encode
    Dim caster As New Caster With {.ShortValue1 = value}
    Dim buffer(0 To 2) As Byte
    buffer(0) = caster.ByteValue2
    buffer(1) = caster.ByteValue1
    stream.Write(buffer, 0, 2)
  End Sub

  Public Sub Encode(value As UInteger, stream As Stream) Implements IEncoder.Encode
    Dim caster As New Caster With {.UIntegerValue = value}
    Dim buffer(0 To 3) As Byte
    buffer(0) = caster.ByteValue4
    buffer(1) = caster.ByteValue3
    buffer(2) = caster.ByteValue2
    buffer(3) = caster.ByteValue1
    stream.Write(buffer, 0, 4)
  End Sub

  Public Sub Encode(value As Integer, stream As Stream) Implements IEncoder.Encode
    Dim caster As New Caster With {.IntegerValue = value}
    Dim buffer(0 To 3) As Byte
    buffer(0) = caster.ByteValue4
    buffer(1) = caster.ByteValue3
    buffer(2) = caster.ByteValue2
    buffer(3) = caster.ByteValue1
    stream.Write(buffer, 0, 4)
  End Sub

  Public Sub Encode(value As CharacterId, stream As Stream) Implements IEncoder.Encode
    Encode(CType(value, UInteger), stream)
  End Sub

  Public Sub Encode(value As Location, stream As Stream) Implements IEncoder.Encode
    Encode(CUShort(value.X), stream)
    Encode(CUShort(value.Y), stream)
    Encode(CUShort(value.Z), stream)
  End Sub

  Public Function SendCommandAsync(commandId As Byte, payload As MemoryStream) As Task Implements IEncoder.SendCommandAsync
    Dim payloadArray = payload.ToArray
    Return SendCommandAsync(commandId, payloadArray, 0, payloadArray.Length)
  End Function

  Public Async Function SendCommandAsync(commandId As Byte, payload() As Byte, offset As Integer, length As Integer) As Task Implements IEncoder.SendCommandAsync
    Dim buffer(0 To length + 5) As Byte
    buffer(0) = commandId
    buffer(1) = commandId Xor Byte.MaxValue
    EncodeToBuffer(CUShort(length), buffer, 2)
    EncodeToBuffer(CalculateCrc(payload, offset, length), buffer, 4)
    Array.Copy(payload, offset, buffer, 6, length)
    Await _stream.WriteAsync(buffer, 0, buffer.Length)
    Await _stream.FlushAsync()
  End Function

  Private Shared Sub EncodeToBuffer(value As Short, buffer() As Byte, offset As Integer)
    Dim caster As New Caster With {.ShortValue1 = value}
    buffer(offset) = caster.ByteValue2
    buffer(offset + 1) = caster.ByteValue1
  End Sub

  Private Shared Sub EncodeToBuffer(value As UShort, buffer() As Byte, offset As Integer)
    Dim caster As New Caster With {.UShortValue1 = value}
    buffer(offset) = caster.ByteValue2
    buffer(offset + 1) = caster.ByteValue1
  End Sub

  Public Sub EncodePassword(value As String, stream As Stream) Implements IEncoder.EncodePassword
    If value Is Nothing Then Throw New ArgumentNullException(NameOf(value))
    If stream Is Nothing Then Throw New ArgumentNullException(NameOf(stream))

    Encode(EncryptPassword(value, "illarion", "$1$"), stream)
  End Sub

  Public Function SendCommandAsync(commandId As Byte) As Task Implements IEncoder.SendCommandAsync
    Return SendCommandAsync(commandId, New Byte() {}, 0, 0)
  End Function
End Class
