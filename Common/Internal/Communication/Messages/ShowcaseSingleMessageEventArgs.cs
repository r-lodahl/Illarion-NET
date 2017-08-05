using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class ShowcaseSingleMessageEventArgs : EventArgs
    {
        /**
         * The ID of the container.
         */
        private readonly byte _containerId;

        /**
         * The slot in the container that is updated.
         */
        private readonly ushort _containerSlot;

        /**
         * The id of the new item in the slot.
         */
        private readonly ushort _slotItem;

        /**
         * The new amount of items in the slot.
         */
        private readonly ushort _slotItemCount;


        public ShowcaseSingleMessageEventArgs(BinaryReader reader)
        {
            _containerId = reader.ReadByte();
            _containerSlot = reader.ReadUInt16();
            _slotItem = reader.ReadUInt16();
            _slotItemCount = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
//        if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //      }

        //    if (LocalPlayerUpdater.updateSingleSlotInContainer(_containerId, _slotItem, _slotItemCount)) {
        //      GuiUpdater.showContainer(_containerId);
        // return ServerReplyResult.Success;
        // }

        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[ShowcaseSingleMessage ContainerId: " + _containerId + " Slot: " + _containerSlot + "]";
        }
    }
}
