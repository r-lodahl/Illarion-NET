Imports Illarion.BBIWI.WPF.ViewModel

Namespace Commands
  Public NotInheritable Class LoginCommand
    Implements ICommand

    Public ReadOnly _vm As LoginDialogViewModel

    Friend Sub New(vm As LoginDialogViewModel)
      _vm = vm
    End Sub

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
      Return True
    End Function

    Public Async Sub Execute(parameter As Object) Implements ICommand.Execute
      Dim passwordBox = TryCast(parameter, PasswordBox)
      If passwordBox IsNot Nothing Then
        Dim server = _vm.Server
        Dim character = _vm.CharacterName
        Dim password = passwordBox.Password

        _vm.LoginPending = True
        Try
          Await Model.Instance.Login(server.HostName, server.Port, character, password)
        Finally
          _vm.LoginPending = False
        End Try
      End If
    End Sub
  End Class
End Namespace
