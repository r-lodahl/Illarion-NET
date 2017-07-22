Imports System.ComponentModel
Imports Illarion.BBIWI.WPF.Commands

Namespace ViewModel
  Public Class LoginDialogViewModel
    Implements INotifyPropertyChanged

    Private _loginPending As Boolean

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public ReadOnly Property Servers As IReadOnlyCollection(Of Server)
      Get
        Return {
            New Server("Game Server", "illarion.org", 3008),
            New Server("Test Server", "illarion.org", 3011),
            New Server("Development Server", "illarion.org", 3012)
        }
      End Get
    End Property

    Public Property Server As Server
    Public Property CharacterName As String

    Public ReadOnly Property LoginCommand As ICommand
      Get
        Return New LoginCommand(Me)
      End Get
    End Property

    Public Property LoginPending As Boolean
      Get
        Return _loginPending
      End Get
      Set(value As Boolean)
        If value <> _loginPending Then
          _loginPending = value
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(LoginPending)))
        End If
      End Set
    End Property

    Public Sub New()
      _loginPending = False
    End Sub
  End Class
End Namespace
