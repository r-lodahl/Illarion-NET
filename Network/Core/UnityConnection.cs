using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Illarion.Common.Character;
using Illarion.Common.Internal.Communication;
using Illarion.Common.Internal.Communication.Commands;
using Illarion.Network.Commands.GameMaster;
using Illarion.Network.Core.Interfaces;

namespace Illarion.Network.Core
{
    public class UnityConnection : Connection, ISender, ISubscriber
    {
        private const byte UnityProtocolVersion = 200;
        private const byte IdKeepAlive = 0x1;
        private const byte IdBroadCast = 0x2;
        private const byte IdDisconnect = 0x3;
        private const byte IdBan = 0x4;
        private const byte IdTalkTo = 0x5;
        private const byte IdChangeAttrib = 0x6;
        private const byte IdChangeSkill = 0x7;
        private const byte IdServerCommand = 0x8;
        private const byte IdWarpPlayer = 0x9;
        private const byte IdSpeakAs = 0xa;

        private const byte IdLogin = 0xd;

        private byte[] _receiveBuffer = new byte[1001];

        private Timer _keepAliveTimer;

        public UnityConnection(string hostName, int port, IReceiver receiver) : this(hostName, port,
            new InternalReceiver(receiver))
        {
            if (receiver == null) throw new ArgumentNullException("receiver");
        }

        private UnityConnection(string hostName, int port, InternalReceiver receiver) : base(hostName, port,
            UnityProtocolVersion, new MessageSink(receiver))
        {
            #region Command-Subscriptions
            EventManager.Subscribe(Command.CmdLogin, this);
            #endregion

            receiver.Connection = this;
        }

        public async void ActionInvoked(object sender, EventArgs args)
        {
            if (!(args is AbstractCommandEventArgs))
            {
                UnityEngine.Debug.LogError("Sender received non-Command Event. Check subscriptions!");
                return;
            }

            var command = (AbstractCommandEventArgs) args;

            switch (command.Command)
            {
                case Command.CmdLogin:
                    await Login((LoginCommandEventArgs)command);
                    break;
                default:
                    UnityEngine.Debug.Log("Send-Command NIY");
                    break;
            }


        }

        internal void LoginDone()
        {
            _keepAliveTimer = new Timer(x => KeepAlive(), null, 0, 60000);
        }

        internal void LogoutDone()
        {
            if (_keepAliveTimer != null) _keepAliveTimer.Dispose();
            _keepAliveTimer = null;
        }

        public Task Broadcast(string message)
        {
            var stream = new MemoryStream();

            Encoder.Encode(message, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdBroadCast, stream);
        }

        public Task SpeakAs(CharacterId characterId, string message)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            Encoder.Encode(message, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdSpeakAs, stream);
        }

        public Task Warp(CharacterId characterId, Coordinate coordinate)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            Encoder.Encode(coordinate, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdWarpPlayer, stream);
        }

        public Task SendServerCommand(GmCommand command)
        {
            var stream = new MemoryStream();

            switch (command)
            {
                case GmCommand.KickAll:
                    Encoder.Encode("kickall", stream);
                    break;
                case GmCommand.Nuke:
                    Encoder.Encode("nuke", stream);
                    break;
                case GmCommand.Reload:
                    Encoder.Encode("reload", stream);
                    break;
                case GmCommand.SetLoginTrue:
                    Encoder.Encode("setlogintrue", stream);
                    break;
                case GmCommand.SetLoginFalse:
                    Encoder.Encode("setloginfalse", stream);
                    break;
            }

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdServerCommand, stream);
        }

        public Task ChangeAttribute(CharacterId characterId, CharacterAttribute attribute, short value)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            switch (attribute)
            {
                case CharacterAttribute.Agility:
                    Encoder.Encode("agility", stream);
                    break;
                case CharacterAttribute.Constitution:
                    Encoder.Encode("constitution", stream);
                    break;
                case CharacterAttribute.Dexterity:
                    Encoder.Encode("dexterity", stream);
                    break;
                case CharacterAttribute.Essence:
                    Encoder.Encode("essence", stream);
                    break;
                case CharacterAttribute.Intelligence:
                    Encoder.Encode("intelligence", stream);
                    break;
                case CharacterAttribute.Perception:
                    Encoder.Encode("perception", stream);
                    break;
                case CharacterAttribute.Strength:
                    Encoder.Encode("strength", stream);
                    break;
                case CharacterAttribute.Willpower:
                    Encoder.Encode("willpower", stream);
                    break;
            }
            Encoder.Encode(value, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdChangeAttrib, stream);
        }

        public Task ChangeSkill(CharacterId characterId, byte skillId, short value)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            Encoder.Encode(skillId, stream);
            Encoder.Encode(value, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdChangeSkill, stream);
        }

        public Task TalkTo(CharacterId characterId, string message)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            Encoder.Encode(message, stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdTalkTo, stream);
        }

        public Task Disconnect()
        {
            return Transmitter.SendCommandAsync(IdDisconnect);
        }

        public Task KeepAlive()
        {
            return Transmitter.SendCommandAsync(IdKeepAlive);
        }

        public Task Ban(CharacterId characterId, TimeSpan time)
        {
            var stream = new MemoryStream();

            Encoder.Encode(characterId, stream);
            Encoder.Encode(Convert.ToInt32(time.TotalMinutes), stream);

            stream.Position = 0;
            return Transmitter.SendCommandAsync(IdBan, stream);
        }

        public Task Login(LoginCommandEventArgs loginData)
        {
            var stream = new MemoryStream();

            loginData.Encode(Encoder, stream, ProtocolVersion);

            stream.Position = 0;
            return Transmitter.SendCommandAsync((byte) Command.CmdLogin, stream);
        }


    }
}