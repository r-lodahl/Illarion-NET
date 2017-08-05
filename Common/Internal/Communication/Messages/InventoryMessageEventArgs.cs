using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class InventoryMessageEventArgs : EventArgs
    {
        /**
         * New count of the item on the position.
         */
        private readonly ushort _count;

        /**
         * New ID of the item.
         */
        private readonly ushort _itemId;

        /**
         * Position in the inventory.
         */
        private readonly byte _location;


        public InventoryMessageEventArgs(BinaryReader reader)
        {
            _location = reader.ReadByte();
            _itemId = reader.ReadUInt16();
            _count = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        //LocalPlayerUpdater.setItem(_location, _itemId, _count);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[InventoryMessage Slot: " + _location + " ItemId: " +  _itemId + " Count: " +  _count + "]";
        }
    }
}
