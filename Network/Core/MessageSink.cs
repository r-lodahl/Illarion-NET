using System;
using System.Diagnostics;
using System.IO;
using Illarion.Common.Character;
using Illarion.Common.Chat;
using Illarion.Common.System;
using Illarion.Network.Core.Interfaces;

namespace Illarion.Network.Core
{
    internal sealed class MessageSink : IMessageSink
    {
        //TODO: These Codes are no longer used
        private const int IdLoginSuccessful = 0xCA;

        private const int IdMonitorLogout = 0xcc;
        private const int IdMessage = 0x1;
        private const int IdNewPlayer = 0x2;
        private const int IdTalk = 0x3;
        private const int IdLogout = 0x4;
        private const int IdPlayerMove = 0x5;
        private const int IdSendAttrib = 0x6;
        private const int IdSendSkill = 0x7;

        private const int IdAction = 0x8;

        private readonly IReceiver _receiver;

        internal MessageSink(IReceiver receiver)
        {
            if (receiver == null)
                throw new ArgumentNullException("receiver");

            _receiver = receiver;
        }

        public void ProcessMessage(IDecoder decoder, byte id, Stream payload)
        {
            switch (id)
            {
                case IdLoginSuccessful:
                    Debug.Assert(payload.Length == 0, "payload.Length = 0");
                    _receiver.LoginSuccessful();
                    break;
                case IdMessage:
                    ProcessMessageReceived(decoder, payload);
                    break;
                case IdNewPlayer:
                    ProcessNewPlayer(decoder, payload);
                    break;
                case IdTalk:
                    ProcessTalk(decoder, payload);
                    break;
                case IdLogout:
                    ProcessLogout(decoder, payload);
                    break;
                case IdPlayerMove:
                    ProcessPlayerMove(decoder, payload);
                    break;
                case IdSendAttrib:
                    ProcessSendAttribute(decoder, payload);
                    break;
                case IdSendSkill:
                    ProcessSendSkill(decoder, payload);
                    break;
                case IdMonitorLogout:
                    ProcessMonitorLogout(decoder, payload);
                    break;
            }
        }

        private void ProcessMessageReceived(IDecoder decoder, Stream payload)
        {
            var message = decoder.ReadString(payload);
            var messageType = decoder.ReadByte(payload);

            _receiver.Message(message, GetMessageType(messageType));
        }

        private void ProcessNewPlayer(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var name = decoder.ReadString(payload);
            var location = decoder.ReadLocation(payload);

            _receiver.NewPlayer(charId, name, location);
        }

        private void ProcessTalk(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var talkType = decoder.ReadByte(payload);
            var message = decoder.ReadString(payload);

            _receiver.Talk(charId, GetTalkType(talkType), message);
        }

        private void ProcessLogout(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);

            _receiver.LogoutPlayer(charId);
        }

        private void ProcessPlayerMove(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var location = decoder.ReadLocation(payload);

            _receiver.PlayerMoved(charId, location);
        }

        private void ProcessSendAttribute(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var attribute = decoder.ReadString(payload);
            var value = decoder.ReadInt16(payload);

            _receiver.AttributeChanged(charId, GetAttribute(attribute), value);
        }

        private void ProcessSendSkill(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var skill = decoder.ReadByte(payload);
            var value = decoder.ReadInt16(payload);
            var minor = decoder.ReadInt16(payload);

            _receiver.SkillChanged(charId, skill, value, minor);
        }

        private void ProcessAction(IDecoder decoder, Stream payload)
        {
            var charId = decoder.ReadCharacterId(payload);
            var messageType = decoder.ReadByte(payload);
            var message = decoder.ReadString(payload);

            _receiver.Action(charId, GetMessageType(messageType), message);
        }

        private void ProcessMonitorLogout(IDecoder decoder, Stream payload)
        {
            var reasonByte = decoder.ReadByte(payload);

            LogoutReason reason;
            switch (reasonByte)
            {
                case 0:
                    reason = LogoutReason.NormalLogout;
                    break;
                case 0x1:
                    reason = LogoutReason.OldClient;
                    break;
                case 0x2:
                    reason = LogoutReason.AlreadyOnline;
                    break;
                case 0x3:
                    reason = LogoutReason.WrongPassword;
                    break;
                case 0x4:
                    reason = LogoutReason.ServerShutdown;
                    break;
                case 0x5:
                    reason = LogoutReason.ByGamemaster;
                    break;
                case 0x6:
                    reason = LogoutReason.ForCreate;
                    break;
                case 0x7:
                    reason = LogoutReason.NoPlace;
                    break;
                case 0x8:
                    reason = LogoutReason.NoCharacterFound;
                    break;
                case 0x9:
                    reason = LogoutReason.PlayerCreated;
                    break;
                case 0xa:
                    reason = LogoutReason.UnstableConnection;
                    break;
                case 0xb:
                    reason = LogoutReason.NoAccount;
                    break;
                case 0xc:
                    reason = LogoutReason.NoSkills;
                    break;
                case 0xd:
                    reason = LogoutReason.CorruptData;
                    break;
                default:
                    reason = LogoutReason.Unknown;
                    break;
            }

            _receiver.Logout(reason);
        }

        private static MessageType GetMessageType(byte id)
        {
            switch (id)
            {
                case 1:
                    return MessageType.Chat;
                case 2:
                    return MessageType.GmPage;
                case 3:
                    return MessageType.Combat;
                default:
                    return MessageType.Unknown;
            }
        }

        private static TalkType GetTalkType(byte id)
        {
            switch (id)
            {
                case 1:
                    return TalkType.Speak;
                case 2:
                    return TalkType.Whisper;
                case 3:
                    return TalkType.Shout;
                default:
                    return TalkType.Unknown;
            }
        }

        private static CharacterAttribute GetAttribute(string attribute)
        {
            switch (attribute)
            {
                case "agility":
                    return CharacterAttribute.Agility;
                case "constitution":
                    return CharacterAttribute.Constitution;
                case "dexterity":
                    return CharacterAttribute.Dexterity;
                case "essence":
                    return CharacterAttribute.Essence;
                case "intelligence":
                    return CharacterAttribute.Intelligence;
                case "perception":
                    return CharacterAttribute.Perception;
                case "strength":
                    return CharacterAttribute.Strength;
                case "willpower":
                    return CharacterAttribute.Willpower;
                default:
                    return CharacterAttribute.Unknown;
            }
        }
    }
    
}