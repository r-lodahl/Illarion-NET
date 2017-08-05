using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class RemoveItemMessageEventArgs : EventArgs
    {
        /**
         * The location the top item shall be removed from.
         */
        private readonly Coordinate _location;

        /**
     * The new move points of the tile after the update.
     */
        private readonly byte _newTileMovePoints;


        public RemoveItemMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _newTileMovePoints = reader.ReadByte();
        }

        // public ServerReplyResult Execute() {
        //   if (MapUpdater.removeTopItemFromTile(_locationX, _locationY, _locationZ, _newTileMovePoints)) {
        // return ServerReplyResult.Success;
        //   }
        // return ServerReplyResult.Failed;
        // }

        public override string ToString()
        {
            return "[RemoveItemMessage Location: (" + _location + ")]";
        }
    }
}
