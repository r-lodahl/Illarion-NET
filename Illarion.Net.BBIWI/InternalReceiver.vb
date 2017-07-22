Imports Illarion.Core.Types

Friend NotInheritable Class InternalReceiver
  Implements IBBIWIReceiver

  Friend Property Connection As BBIWIConnection

  Private ReadOnly _publicReciever As IBBIWIReceiver

  Friend Sub New(receiver As IBBIWIReceiver)
    If receiver Is Nothing Then Throw New ArgumentNullException(NameOf(receiver))

    _publicReciever = receiver
  End Sub

  Public Sub LoginSuccessful() Implements IBBIWIReceiver.LoginSuccessful
    Connection?.LoginDone()
    _publicReciever.LoginSuccessful()
  End Sub

  Public Sub Action(characterId As CharacterId, messageType As MessageType, message As String) Implements IBBIWIReceiver.Action
    _publicReciever.Action(characterId, messageType, message)
  End Sub

  Public Sub SkillChanged(characterId As CharacterId, skillId As Byte, value As Short, minor As Short) Implements IBBIWIReceiver.SkillChanged
    _publicReciever.SkillChanged(characterId, skillId, value, minor)
  End Sub

  Public Sub AttributeChanged(characterId As CharacterId, attribute As CharacterAttrib, value As Short) Implements IBBIWIReceiver.AttributeChanged
    _publicReciever.AttributeChanged(characterId, attribute, value)
  End Sub

  Public Sub LogoutPlayer(characterId As CharacterId) Implements IBBIWIReceiver.LogoutPlayer
    _publicReciever.LogoutPlayer(characterId)
  End Sub

  Public Sub NewPlayer(characterId As CharacterId, name As String, location As Location) Implements IBBIWIReceiver.NewPlayer
    _publicReciever.NewPlayer(characterId, name, location)
  End Sub

  Public Sub PlayerMoved(characterId As CharacterId, location As Location) Implements IBBIWIReceiver.PlayerMoved
    _publicReciever.PlayerMoved(characterId, location)
  End Sub

  Public Sub Message(message As String, messageType As MessageType) Implements IBBIWIReceiver.Message
    _publicReciever.Message(message, messageType)
  End Sub

  Public Sub Talk(characterId As CharacterId, talkType As TalkType, message As String) Implements IBBIWIReceiver.Talk
    _publicReciever.Talk(characterId, talkType, message)
  End Sub

  Public Sub Logout(reason As LogoutReason) Implements IBBIWIReceiver.Logout
    Connection?.LogoutDone()
    _publicReciever.Logout(reason)
  End Sub
End Class
