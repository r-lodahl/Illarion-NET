using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class ChangeItemMessageEventArgs : EventArgs
    {

        /**
         * The new count value of the item.
         */

        private readonly byte _count;

        /**
         * The location on the map this update is performed on.
         */

        private readonly Coordinate _location;

        /**
     * The ID of the item after the change.
     */

        private readonly ushort _newItem;

        /** 
         * The ID of the item before the change.
         */

        private readonly ushort _oldItem;

        /**
         * The new move points of the tile the item is located on.
         */
        private readonly byte _newTileMovePoints;


        public ChangeItemMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(
                reader.ReadInt16(),
                reader.ReadInt16(),
                reader.ReadInt16()
            );

            _oldItem = reader.ReadUInt16();
            _newItem = reader.ReadUInt16();
            _count = reader.ReadByte();
            _newTileMovePoints = reader.ReadByte();
        }

        /*// public ServerReplyResult Execute() {
            MapUpdater.changeTopItem(_locationX, _locationY, _locationZ, _oldItem, _newItem, _count, _newTileMovePoints);
            // return ServerReplyResult.Success;
        }*/

        public override string ToString()
        {
            return "[ChangeItemMessage Old " + _oldItem + " New " + _newItem + " Location (" + _location + ")]";
        }
    }
}
