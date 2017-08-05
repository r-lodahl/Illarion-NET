using System.IO;

namespace Illarion.Common.Map
{
    public struct Tile
    {
        private readonly ushort _tileId;
        private readonly byte _musicId;

        public ushort TileId { get { return _tileId; } }
        public byte MusicId { get { return _musicId; } }

        public Tile(BinaryReader reader)
        {
            _tileId = reader.ReadUInt16();
            _musicId = reader.ReadByte();
        }

        public Tile(ushort tileId, byte musicId)
        {
            _tileId = tileId;
            _musicId = musicId;
        }
    }
}
