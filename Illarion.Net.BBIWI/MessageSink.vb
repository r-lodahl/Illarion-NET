Imports System.IO

Friend NotInheritable Class MessageSink
  Implements IMessageSink

  Private Const IdLoginSuccessful As Integer = &H0
  Private Const IdMonitorLogout As Integer = &HCC
  Private Const IdMessage As Integer = &H1
  Private Const IdNewPlayer As Integer = &H2
  Private Const IdTalk As Integer = &H3
  Private Const IdLogout As Integer = &H4
  Private Const IdPlayerMove As Integer = &H5
  Private Const IdSendAttrib As Integer = &H6
  Private Const IdSendSkill As Integer = &H7
  Private Const IdAction As Integer = &H8

  Private ReadOnly _receiver As IBBIWIReceiver

  Friend Sub New(receiver As IBBIWIReceiver)
    If receiver Is Nothing Then Throw New ArgumentNullException(NameOf(receiver))

    _receiver = receiver
  End Sub

  Public Sub ProcessMessage(decoder As IDecoder, id As Byte, payload As Stream) Implements IMessageSink.ProcessMessage
    Select Case id
      Case IdLoginSuccessful
        Debug.Assert(payload.Length = 0, "payload.Length = 0")
        _receiver.LoginSuccessful()
      Case IdMessage
        ProcessMessageReceived(decoder, payload)
      Case IdNewPlayer
        ProcessNewPlayer(decoder, payload)
      Case IdTalk
        ProcessTalk(decoder, payload)
      Case IdLogout
        ProcessLogout(decoder, payload)
      Case IdPlayerMove
        ProcessPlayerMove(decoder, payload)
      Case IdSendAttrib
        ProcessSendAttribute(decoder, payload)
      Case IdSendSkill
        ProcessSendSkill(decoder, payload)
      Case IdMonitorLogout
        ProcessMonitorLogout(decoder, payload)
    End Select
  End Sub

  Private Sub ProcessMessageReceived(decoder As IDecoder, payload As Stream)
    Dim message = decoder.ReadString(payload)
    Dim messageType = decoder.ReadByte(payload)

    _receiver.Message(message, getMessageType(messageType))
  End Sub

  Private Sub ProcessNewPlayer(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim name = decoder.ReadString(payload)
    Dim location = decoder.ReadLocation(payload)

    _receiver.NewPlayer(charId, name, location)
  End Sub

  Private Sub ProcessTalk(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim talkType = decoder.ReadByte(payload)
    Dim message = decoder.ReadString(payload)

    _receiver.Talk(charId, getTalkType(talkType), message)
  End Sub

  Private Sub ProcessLogout(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)

    _receiver.LogoutPlayer(charId)
  End Sub

  Private Sub ProcessPlayerMove(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim location = decoder.ReadLocation(payload)

    _receiver.PlayerMoved(charId, location)
  End Sub

  Private Sub ProcessSendAttribute(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim attribute = decoder.ReadString(payload)
    Dim value = decoder.ReadShort(payload)

    _receiver.AttributeChanged(charId, getAttribute(attribute), value)
  End Sub

  Private Sub ProcessSendSkill(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim skill = decoder.ReadByte(payload)
    Dim value = decoder.ReadShort(payload)
    Dim minor = decoder.ReadShort(payload)

    _receiver.SkillChanged(charId, skill, value, minor)
  End Sub

  Private Sub ProcessAction(decoder As IDecoder, payload As Stream)
    Dim charId = decoder.ReadCharacterId(payload)
    Dim messageType = decoder.ReadByte(payload)
    Dim message = decoder.ReadString(payload)

    _receiver.Action(charId, getMessageType(messageType), message)
  End Sub

  Private Sub ProcessMonitorLogout(decoder As IDecoder, payload As Stream)
    Dim reasonByte = decoder.ReadByte(payload)

    Dim reason As LogoutReason
    Select Case reasonByte
      Case 0 : reason = LogoutReason.NormalLogout
      Case &H1 : reason = LogoutReason.OldClient
      Case &H2 : reason = LogoutReason.AlreadyOnline
      Case &H3 : reason = LogoutReason.WrongPassword
      Case &H4 : reason = LogoutReason.ServerShutdown
      Case &H5 : reason = LogoutReason.ByGamemaster
      Case &H6 : reason = LogoutReason.ForCreate
      Case &H7 : reason = LogoutReason.NoPlace
      Case &H8 : reason = LogoutReason.NoCharacterFound
      Case &H9 : reason = LogoutReason.PlayerCreated
      Case &HA : reason = LogoutReason.UnstableConnection
      Case &HB : reason = LogoutReason.NoAccount
      Case &HC : reason = LogoutReason.NoSkills
      Case &HD : reason = LogoutReason.CorruptData
      Case Else : reason = LogoutReason.Unknown
    End Select

    _receiver.Logout(reason)
  End Sub

  Private Shared Function getMessageType(id As Byte) As MessageType
    Select Case id
      Case 1
        Return MessageType.Chat
      Case 2
        Return MessageType.GMPage
      Case 3
        Return MessageType.Combat
      Case Else
        Return MessageType.Unknown
    End Select
  End Function

  Private Shared Function getTalkType(id As Byte) As TalkType
    Select Case id
      Case 1
        Return TalkType.Speak
      Case 2
        Return TalkType.Whisper
      Case 3
        Return TalkType.Shout
      Case Else
        Return TalkType.Unknown
    End Select
  End Function

  Private Shared Function getAttribute(attribute As String) As CharacterAttrib
    Select Case attribute
      Case "agility"
        Return CharacterAttrib.Agility
      Case "constitution"
        Return CharacterAttrib.Constitution
      Case "dexterity"
        Return CharacterAttrib.Dexterity
      Case "essence"
        Return CharacterAttrib.Essence
      Case "intelligence"
        Return CharacterAttrib.Intelligence
      Case "perception"
        Return CharacterAttrib.Perception
      Case "strength"
        Return CharacterAttrib.Strength
      Case "willpower"
        Return CharacterAttrib.Willpower
      Case Else
        Return CharacterAttrib.Unknown
    End Select
  End Function
End Class
