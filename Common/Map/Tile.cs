using System.IO;

namespace Illarion.Common.Map
{
    public struct Tile
    {
        private ushort _tileId;
        private byte _musicId;
		private byte _movementCost;
		private ushort _overlayId;

		private Dictionary<int, List<Item>> _items;
		
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
			_items = new Dictionary<int, Item>();
        }
		
		public ApplyDifference(TileUpdate update)
		{
			// Checking for difference would ALWAYS be more expensive than this...
			_tileId = update.TileId;
			_musicId = update.MusicId;
			_movementCost = update.MovementCost;
			_overlayId = update.ShapeId + update.OverlayId // TODO: Recombine these two in the TileUpdate. Change file name of Overlays to Shape+Overlay 
			
			// Check if we have to add or remove items
			foreach (var i = 0; i < update.ItemNumber; i++)
			{
				var itemId = update.ItemIds[i];
				var itemCount = update.ItemCount[i];
				
				if (_items.ContainsKey(itemId))
				{
					var itemList = _items[itemId];
					if (itemList.Count > itemCount)
					{
						for (var j = 0; j < itemList.Count - itemCount; j++)
						{
							itemList.Add(new Item());
						}
					}
					else if (itemList.Count < itemCount)
					{
						for (var j = 0; j < itemCount - itemList.Count; j++)
						{
							itemList.Remove(itemList.Length-1);
						}
					}
				}
				else
				{

					var itemList = new List<Item>(itemCount);
					
					for (var j = 0; j < itemCount; j++) {
						itemList.Add(new Item());
					}
					
					_items.Add(itemId, itemList);
				}
			}
			
		}
		
    }
}
