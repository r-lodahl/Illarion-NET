using System;
using Illarion.Common.Character;
using Illarion.Common.Chat;
using Illarion.Common.System;
using Illarion.Network.Core.Interfaces;

namespace Illarion.Network.Core
{
    internal sealed class InternalReceiver : IReceiver
    {
        internal UnityConnection Connection { get; set; }

        private readonly IReceiver _publicReciever;

        internal InternalReceiver(IReceiver receiver)
        {
            if (receiver == null)
                throw new ArgumentNullException("receiver");

            _publicReciever = receiver;
        }

        public void LoginSuccessful()
        {
            if (Connection != null) Connection.LoginDone();
            _publicReciever.LoginSuccessful();
        }

        public void Action(CharacterId characterId, MessageType messageType, string message)
        {
            _publicReciever.Action(characterId, messageType, message);
        }

        public void SkillChanged(CharacterId characterId, byte skillId, short value, short minor)
        {
            _publicReciever.SkillChanged(characterId, skillId, value, minor);
        }

        public void AttributeChanged(CharacterId characterId, CharacterAttribute attribute, short value)
        {
            _publicReciever.AttributeChanged(characterId, attribute, value);
        }

        public void LogoutPlayer(CharacterId characterId)
        {
            _publicReciever.LogoutPlayer(characterId);
        }

        public void NewPlayer(CharacterId characterId, string name, Coordinate coordinate)
        {
            _publicReciever.NewPlayer(characterId, name, coordinate);
        }

        public void PlayerMoved(CharacterId characterId, Coordinate coordinate)
        {
            _publicReciever.PlayerMoved(characterId, coordinate);
        }

        public void Message(string message, MessageType messageType)
        {
            _publicReciever.Message(message, messageType);
        }

        public void Talk(CharacterId characterId, TalkType talkType, string message)
        {
            _publicReciever.Talk(characterId, talkType, message);
        }

        public void Logout(LogoutReason reason)
        {
            if (Connection != null) Connection.LogoutDone();
            _publicReciever.Logout(reason);
        }
    }
}