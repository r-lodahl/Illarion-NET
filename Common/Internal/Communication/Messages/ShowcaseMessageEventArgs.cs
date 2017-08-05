using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class ShowcaseMessageEventArgs : EventArgs
    {
        /**
         * The ID of the container.
         */
        private readonly byte _containerId;

        /**
         * The title of the container.
         */

        private readonly string _title;

        /**
         * The description of the container.
         */

        private readonly string _description;

        /**
         * The amount of slots in the container.
         */
        private readonly ushort _slotCount;

        /**
         * The positions of the filled slots.
         */

        private readonly ushort[] _slots;

        /**
         * The item IDs in the filled slots.
         */

        private readonly ushort[] _itemIds;

        /**
         * The amount of items in the filled slots.
         */

        private readonly ushort[] _itemCounts;


        public ShowcaseMessageEventArgs(BinaryReader reader)
        {
            _containerId = reader.ReadByte();
            _title = reader.ReadString();
            _description = reader.ReadString();
            _slotCount = reader.ReadUInt16();

            int itemAmount = reader.ReadUInt16();

            _slots = new ushort[itemAmount];
            _itemIds = new ushort[itemAmount];
            _itemCounts = new ushort[itemAmount];

            for (var i = 0; i < itemAmount; i++)
            {
                _slots[i] = reader.ReadUInt16();
                _itemIds[i] = reader.ReadUInt16();
                _itemCounts[i] = reader.ReadUInt16();
            }
        }

        // public ServerReplyResult Execute() {
//        if (_title == null || _description == null || _slots == null || _itemIds == null || _itemCounts == null) {
        //          throw new NotDecodedException();
        //    }

        //  if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        // LocalPlayerUpdater.updateSlotsInContainer(_containerId, _title, _description, _slotCount, _slots, _itemIds, _itemCounts);

        // GuiUpdater.showContainer(_containerId);

        // return ServerReplyResult.Success;
//    }

        public override string ToString()
        {
            return "[ShowcaseMessage ContainerId: " + _containerId + " Title: " + _title + " Slots: " + _slotCount + "]";
        }
    }
}
