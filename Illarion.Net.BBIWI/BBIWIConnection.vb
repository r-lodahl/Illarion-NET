Imports System.IO
Imports System.Threading
Imports Illarion.Core.Types

Public Class BBIWIConnection
  Inherits Connection
  Implements IBBIWISender

  Private Const BBIWIProtocolVersion As Byte = 200

  Private Const IdKeepAlive As Byte = &H1
  Private Const IdBroadCast As Byte = &H2
  Private Const IdDisconnect As Byte = &H3
  Private Const IdBan As Byte = &H4
  Private Const IdTalkTo As Byte = &H5
  Private Const IdChangeAttrib As Byte = &H6
  Private Const IdChangeSkill As Byte = &H7
  Private Const IdServerCommand As Byte = &H8
  Private Const IdWarpPlayer As Byte = &H9
  Private Const IdSpeakAs As Byte = &HA
  Private Const IdLogin As Byte = &HD

  Private _receiveBuffer(1000) As Byte

  Private _keepAliveTimer As Timer

  Public Sub New(hostName As String, port As Integer, receiver As IBBIWIReceiver)
    Me.New(hostName, port, New InternalReceiver(receiver))
    If receiver Is Nothing Then Throw New ArgumentNullException(NameOf(receiver))
  End Sub

  Private Sub New(hostName As String, port As Integer, receiver As InternalReceiver)
    MyBase.New(hostName, port, BBIWIProtocolVersion, New MessageSink(receiver))

    receiver.Connection = Me
  End Sub

  Friend Sub LoginDone()
    _keepAliveTimer = New Timer(Sub() KeepAlive(), Nothing, TimeSpan.Zero, TimeSpan.FromMinutes(1))
  End Sub

  Friend Sub LogoutDone()
    _keepAliveTimer?.Dispose()
    _keepAliveTimer = Nothing
  End Sub

  Public Function Broadcast(message As String) As Task Implements IBBIWISender.Broadcast
    Dim stream As New MemoryStream

    Encoder.Encode(message, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdBroadCast, stream)
  End Function

  Public Function SpeakAs(characterId As CharacterId, message As String) As Task Implements IBBIWISender.SpeakAs
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Encoder.Encode(message, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdSpeakAs, stream)
  End Function

  Public Function Warp(characterId As CharacterId, location As Location) As Task Implements IBBIWISender.Warp
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Encoder.Encode(location, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdWarpPlayer, stream)
  End Function

  Public Function ServerCommand(command As ServerCommand) As Task Implements IBBIWISender.ServerCommand
    Dim stream As New MemoryStream

    Select Case command
      Case BBIWI.ServerCommand.KickAll
        Encoder.Encode("kickall", stream)
      Case BBIWI.ServerCommand.Nuke
        Encoder.Encode("nuke", stream)
      Case BBIWI.ServerCommand.Reload
        Encoder.Encode("reload", stream)
      Case BBIWI.ServerCommand.SetLoginTrue
        Encoder.Encode("setlogintrue", stream)
      Case BBIWI.ServerCommand.SetLoginFalse
        Encoder.Encode("setloginfalse", stream)
    End Select

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdServerCommand, stream)
  End Function

  Public Function ChangeAttribute(characterId As CharacterId, attribute As CharacterAttrib, value As Short) As Task Implements IBBIWISender.ChangeAttribute
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Select Case attribute
      Case CharacterAttrib.Agility
        Encoder.Encode("agility", stream)
      Case CharacterAttrib.Constitution
        Encoder.Encode("constitution", stream)
      Case CharacterAttrib.Dexterity
        Encoder.Encode("dexterity", stream)
      Case CharacterAttrib.Essence
        Encoder.Encode("essence", stream)
      Case CharacterAttrib.Intelligence
        Encoder.Encode("intelligence", stream)
      Case CharacterAttrib.Perception
        Encoder.Encode("perception", stream)
      Case CharacterAttrib.Strength
        Encoder.Encode("strength", stream)
      Case CharacterAttrib.Willpower
        Encoder.Encode("willpower", stream)
    End Select
    Encoder.Encode(value, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdChangeAttrib, stream)
  End Function

  Public Function ChangeSkill(characterId As CharacterId, skillId As Byte, value As Short) As Task Implements IBBIWISender.ChangeSkill
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Encoder.Encode(skillId, stream)
    Encoder.Encode(value, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdChangeSkill, stream)
  End Function

  Public Function TalkTo(characterId As CharacterId, message As String) As Task Implements IBBIWISender.TalkTo
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Encoder.Encode(message, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdTalkTo, stream)
  End Function

  Public Function Disconnect() As Task Implements IBBIWISender.Disconnect
    Return Encoder.SendCommandAsync(IdDisconnect)
  End Function

  Public Function KeepAlive() As Task Implements IBBIWISender.KeepAlive
    Return Encoder.SendCommandAsync(IdKeepAlive)
  End Function

  Public Function Ban(characterId As CharacterId, time As TimeSpan) As Task Implements IBBIWISender.Ban
    Dim stream As New MemoryStream

    Encoder.Encode(characterId, stream)
    Encoder.Encode(CInt(time.TotalMinutes), stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdBan, stream)
  End Function

  Public Function Login(characterName As String, password As String) As Task Implements IBBIWISender.Login
    Dim stream As New MemoryStream

    Encoder.Encode(ProtocolVersion, stream)
    Encoder.Encode(characterName, stream)
    Encoder.EncodePassword(password, stream)

    stream.Position = 0
    Return Encoder.SendCommandAsync(IdLogin, stream)
  End Function
End Class
