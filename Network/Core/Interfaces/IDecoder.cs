using System.IO;
using Illarion.Common.Character;

namespace Illarion.Network.Core.Interfaces
{
    public interface IDecoder
    {
        void Shutdown();
        string ReadString(Stream stream);
        byte ReadByte(Stream stream);
        short ReadInt16(Stream stream);
        CharacterId ReadCharacterId(Stream stream);
        Coordinate ReadLocation(Stream stream);
    }
}