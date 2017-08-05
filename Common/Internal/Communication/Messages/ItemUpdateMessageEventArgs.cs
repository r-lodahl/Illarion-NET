using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class ItemUpdateMessageEventArgs : EventArgs
    {
        /**
         * Count values for each item on this map tile.
         */

        private readonly ushort[] _itemCounts;

        /**
         * List of the item IDs on this map tile.
         */

        private readonly ushort[] _itemIds;

        /**
         * Amount of item stacks on the map tile.
         */
        private readonly byte _itemNumber;

        /**
         * Position of the server map that is updated.
         */
        private readonly Coordinate _location;

        /**
     * The new movement points of the tile.
     */
        private readonly byte _newTileMovePoints;


        public ItemUpdateMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

            _itemNumber = reader.ReadByte();
            _itemIds = new ushort[_itemNumber];
            _itemCounts = new ushort[_itemNumber];
            for (var i = 0; i < _itemNumber; ++i)
            {
                _itemIds[i] = reader.ReadUInt16();
                _itemCounts[i] = reader.ReadUInt16();
            }
            _newTileMovePoints = reader.ReadByte();
        }

        // public ServerReplyResult Execute() {
        //if (_itemIds == null || _itemCounts == null) {
        //   throw new NotDecodedException();
        //}

        //  MapUpdater.updateTileItems(_itemNumber, _itemIds, _itemCounts, _newTileMovePoints);

        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[ItemUpdateMessage Location: (" + _location + ")]";
        }
    }
}
