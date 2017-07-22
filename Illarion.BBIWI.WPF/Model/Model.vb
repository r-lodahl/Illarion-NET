Imports Illarion.BBIWI.WPF.ViewModel
Imports Illarion.Net.BBIWI

Friend Class Model
  Friend Shared ReadOnly Property Instance As New Model

  Private _connection As BBIWIConnection
  Private _mainWindowViewModel As MainWindowViewModel

  Private Sub New()
    _mainWindowViewModel = New MainWindowViewModel
  End Sub

  Friend Async Function Login(hostName As String, port As Integer, characterName As String, password As String) As Task
    Dim connection As New BBIWIConnection(hostName, port, _mainWindowViewModel)
    _connection = connection
    Await connection.ConnectAsync()
    Await connection.Login(characterName, password)

    Dim window As New View.MainWindow With {
        .DataContext = _mainWindowViewModel
    }
    window.Show()
  End Function
End Class
