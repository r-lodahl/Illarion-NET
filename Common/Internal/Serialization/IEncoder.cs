using System.IO;
using Illarion.Common.Character;

namespace Illarion.Common.Internal.Serialization
{
    public interface IEncoder
    {
        void Encode(string value, Stream stream);
        void Encode(byte value, Stream stream);
        void Encode(ushort value, Stream stream);
        void Encode(short value, Stream stream);
        void Encode(uint value, Stream stream);
        void Encode(int value, Stream stream);
        void Encode(CharacterId value, Stream stream);
        void Encode(Coordinate value, Stream stream);
        void EncodePassword(string value, Stream stream);
    }
}