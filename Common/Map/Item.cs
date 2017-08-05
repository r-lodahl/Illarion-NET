using System.Collections.Generic;
using System.IO;

namespace Illarion.Common.Map
{
    public struct Item
    {
        private readonly ushort _itemId;
        private readonly ushort _quality;

        public ushort ItemId { get { return _itemId; } }
        public ushort Quality { get { return _quality; } }

        private Dictionary<string, string> _textData;

        public Item(BinaryReader reader)
        {
            _itemId = reader.ReadUInt16();
            _quality = reader.ReadByte();
            _textData = null;
        }

        public Item(ushort tileId, byte musicId)
        {
            _itemId = tileId;
            _quality = musicId;
            _textData = null;
        }

        public void AddTextData(string key, string data)
        {
            if (_textData == null) _textData = new Dictionary<string, string>();
            _textData.Add(key, data);
        }

    }
}
