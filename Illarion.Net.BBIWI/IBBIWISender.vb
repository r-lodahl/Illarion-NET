Imports Illarion.Core.Types

Public Interface IBBIWISender
  Function Broadcast(message As String) As Task
  Function SpeakAs(characterId As CharacterId, message As String) As Task
  Function Warp(characterId As CharacterId, location As Location) As Task
  Function ServerCommand(command As ServerCommand) As Task
  Function ChangeAttribute(characterId As CharacterId, attribute As CharacterAttrib, value As Short) As Task
  Function ChangeSkill(characterId As CharacterId, skillId As Byte, value As Short) As Task
  Function TalkTo(characterId As CharacterId, message As String) As Task
  Function Disconnect() As Task
  Function KeepAlive() As Task
  Function Ban(characterId As CharacterId, time As TimeSpan) As Task
  Function Login(characterName As String, password As String) As Task
End Interface
