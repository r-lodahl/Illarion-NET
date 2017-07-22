Imports System.Collections.ObjectModel
Imports Illarion.Core.Types
Imports Illarion.Net.BBIWI

Namespace ViewModel
  Public Class MainWindowViewModel
    Implements IBBIWIReceiver

    Public ReadOnly Property Characters As New ObservableCollection(Of String)

    Public Sub LoginSuccessful() Implements IBBIWIReceiver.LoginSuccessful
      Console.WriteLine("Login OK!")
    End Sub

    Public Sub Action(characterId As CharacterId, messageType As MessageType, message As String) Implements IBBIWIReceiver.Action
      'Throw New NotImplementedException()
    End Sub

    Public Sub SkillChanged(characterId As CharacterId, skillId As Byte, value As Short, minor As Short) Implements IBBIWIReceiver.SkillChanged
      ' Throw New NotImplementedException()
    End Sub

    Public Sub AttributeChanged(characterId As CharacterId, attribute As CharacterAttrib, value As Short) Implements IBBIWIReceiver.AttributeChanged
      'Throw New NotImplementedException()
    End Sub

    Public Sub Logout(characterId As CharacterId) Implements IBBIWIReceiver.LogoutPlayer
      ' Throw New NotImplementedException()
    End Sub

    Public Sub Logout(reason As LogoutReason) Implements IBBIWIReceiver.Logout
      Console.WriteLine("Logout :/ " & [Enum].GetName(GetType(LogoutReason), reason))
    End Sub

    Public Sub NewPlayer(characterId As CharacterId, name As String, location As Location) Implements IBBIWIReceiver.NewPlayer
      Characters.Add(name)
    End Sub

    Public Sub PlayerMoved(characterId As CharacterId, location As Location) Implements IBBIWIReceiver.PlayerMoved
      '  Throw New NotImplementedException()
    End Sub

    Public Sub Message(message As String, messageType As MessageType) Implements IBBIWIReceiver.Message
      'Throw New NotImplementedException()
    End Sub

    Public Sub Talk(characterId As CharacterId, talkType As TalkType, message As String) Implements IBBIWIReceiver.Talk
      ' Throw New NotImplementedException()
    End Sub
  End Class
End Namespace
