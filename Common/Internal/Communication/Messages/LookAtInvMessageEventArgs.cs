using System;
using System.IO;
using Illarion.Common.UiHelper;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LookAtInvMessageEventArgs : EventArgs
    {
        /**
         * Inventory slot that message is related to.
         */
        private readonly byte _slot;

        /**
         * The tooltip that is supposed to be displayed at the inventory slot.
         */

        private readonly Tooltip _tooltip;


        public LookAtInvMessageEventArgs(BinaryReader reader)
        {
            _slot = reader.ReadByte();

            // The sequence of the decoding is important!
            _tooltip = new Tooltip(
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadByte() == 1,
                reader.ReadUInt16(),
                reader.ReadUInt32(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()
            );
        }
        // public ServerReplyResult Execute() {
        //   if (_tooltip == null) {
        //     throw new NotDecodedException();
        //}
        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.showInventoryTooltip(_slot, _tooltip);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[LookAtInvMessage Slot: " + _slot + " Tooltip: " +  _tooltip + "]";
        }
    }
}
