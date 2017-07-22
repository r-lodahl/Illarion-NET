Imports System.Net
Imports System.Net.Sockets

Public MustInherit Class Connection
  Private _encoder As IEncoder
  Private _decoder As IDecoder

  Public ReadOnly Property ProtocolVersion As Byte
  Public ReadOnly Property HostName As String
  Public ReadOnly Property Port As Integer


  Public ReadOnly Property IsConnected As Boolean
    Get
      Return TcpClient.Connected
    End Get
  End Property

  Protected ReadOnly Property TcpClient As TcpClient

  Protected ReadOnly Property Encoder As IEncoder
    Get
      Return _encoder
    End Get
  End Property

  Private ReadOnly _messageSink As IMessageSink

  Protected Sub New(hostName As String, port As Integer, protocolVersion As Byte, messageSink As IMessageSink)
    If hostName Is Nothing Then Throw New ArgumentNullException(hostName)
    If String.IsNullOrWhiteSpace(hostName) Then Throw New ArgumentException("Host cannot be white-space only.")
    If port < IPEndPoint.MinPort Then Throw New ArgumentOutOfRangeException(NameOf(port), port, String.Format("Port cannot be less then {0}", IPEndPoint.MinPort))
    If port > IPEndPoint.MaxPort Then Throw New ArgumentOutOfRangeException(NameOf(port), port, String.Format("Port cannot be greater then {0}", IPEndPoint.MaxPort))
    If protocolVersion < 0 Then Throw New ArgumentOutOfRangeException(NameOf(protocolVersion), protocolVersion, "Protocol version cannot be less then 0")

    Me.HostName = hostName
    Me.Port = port
    Me.ProtocolVersion = protocolVersion
    _messageSink = messageSink

    TcpClient = New TcpClient()
  End Sub

  Public Overridable Async Function ConnectAsync() As Task
    If TcpClient.Connected Then Throw New InvalidOperationException("Connect was already called.")

    Await TcpClient.ConnectAsync(HostName, Port)

    Select Case ProtocolVersion
      Case 200
        Dim stream = TcpClient.GetStream()
        _encoder = New EncoderV1(stream)
        _decoder = New DecoderV1(stream, _messageSink)
    End Select
  End Function
End Class
