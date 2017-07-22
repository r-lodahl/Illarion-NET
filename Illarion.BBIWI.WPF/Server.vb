Public NotInheritable Class Server
  Public ReadOnly Property Name As String
  Public ReadOnly Property HostName As String
  Public ReadOnly Property Port As Integer

  Public Sub New(name As String, hostName As String, port As Integer)
    Me.Name = name
    Me.HostName = hostName
    Me.Port = port
  End Sub
End Class
