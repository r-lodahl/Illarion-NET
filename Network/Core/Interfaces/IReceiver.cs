using Illarion.Common.Character;
using Illarion.Common.Chat;
using Illarion.Common.System;

namespace Illarion.Network.Core.Interfaces
{
    public interface IReceiver
    {
        void LoginSuccessful();
        void Action(CharacterId characterId, MessageType messageType, string message);
        void SkillChanged(CharacterId characterId, byte skillId, short value, short minor);
        void AttributeChanged(CharacterId characterId, CharacterAttribute attribute, short value);
        void LogoutPlayer(CharacterId characterId);
        void NewPlayer(CharacterId characterId, string name, Coordinate coordinate);
        void PlayerMoved(CharacterId characterId, Coordinate coordinate);
        void Message(string message, MessageType messageType);
        void Talk(CharacterId characterId, TalkType talkType, string message);
        void Logout(LogoutReason reason);
    }
}