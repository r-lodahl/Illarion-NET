using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class PutItemMessageEventArgs : EventArgs
    {
        /**
         * The ID of the item that is placed on the ground.
         */
        private readonly ushort _itemId;

        /**
         * The location the item is placed at.
         */
        private readonly Coordinate _location;

        /**
     * The count value of the item that is placed on the ground.
     */
        private readonly ushort _itemCount;

        /**
         * The new move points of the tile the item is located on.
         */
        private readonly byte _newTileMovePoints;


        public PutItemMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _itemId = reader.ReadUInt16();
            _itemCount = reader.ReadUInt16();
            _newTileMovePoints = reader.ReadByte();
        }

        // public ServerReplyResult Execute() {
        // if (MapUpdater.addItemToTile(_locationX, _locationY, _locationZ, _itemId, _itemCount, _newTileMovePoints)) {
        // return ServerReplyResult.Success;
        //}

        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[PutItemMessage itemId: " + _itemId + "Location: (" + _location + ")]";
        }
    }
}
