using System;
using System.Threading.Tasks;
using Illarion.Common.Character;
using Illarion.Common.Internal.Communication.Commands;
using Illarion.Network.Commands.GameMaster;

namespace Illarion.Network.Core.Interfaces
{
    public interface ISender
    {
        Task Broadcast(string message);
        Task SpeakAs(CharacterId characterId, string message);
        Task Warp(CharacterId characterId, Coordinate coordinate);
        Task SendServerCommand(GmCommand command);
        Task ChangeAttribute(CharacterId characterId, CharacterAttribute attribute, short value);
        Task ChangeSkill(CharacterId characterId, byte skillId, short value);
        Task TalkTo(CharacterId characterId, string message);
        Task Disconnect();
        Task KeepAlive();
        Task Ban(CharacterId characterId, TimeSpan time);
        Task Login(LoginCommandEventArgs loginData);
    }
}