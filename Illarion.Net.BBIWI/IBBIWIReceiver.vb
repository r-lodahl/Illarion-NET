Imports Illarion.Core.Types

Public Interface IBBIWIReceiver
  Sub LoginSuccessful()
  Sub Action(characterId As CharacterId, messageType As MessageType, message As String)
  Sub SkillChanged(characterId As CharacterId, skillId As Byte, value As Short, minor As Short)
  Sub AttributeChanged(characterId As CharacterId, attribute As CharacterAttrib, value As Short)
  Sub LogoutPlayer(characterId As CharacterId)
  Sub NewPlayer(characterId As CharacterId, name As String, location As Location)
  Sub PlayerMoved(characterId As CharacterId, location As Location)
  Sub Message(message As String, messageType As MessageType)
  Sub Talk(characterId As CharacterId, talkType As TalkType, message As String)
  Sub Logout(reason As LogoutReason)
End Interface
