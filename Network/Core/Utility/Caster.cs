using System.Runtime.InteropServices;

namespace Illarion.Network.Core.Utility
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct Caster
    {
        [FieldOffset(0)] public int IntegerValue;
        [FieldOffset(0)] public uint UIntegerValue;
        [FieldOffset(0)] public short ShortValue1;
        [FieldOffset(2)] public short ShortValue2;
        [FieldOffset(0)] public ushort UShortValue1;
        [FieldOffset(2)] public ushort UShortValue2;
        [FieldOffset(0)] public byte ByteValue1;
        [FieldOffset(1)] public byte ByteValue2;
        [FieldOffset(2)] public byte ByteValue3;
        [FieldOffset(3)] public byte ByteValue4;
    }
}