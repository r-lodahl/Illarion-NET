using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogCraftingUpdateMessageEventArgs : EventArgs
    {
        /**
         * The update type.
         */
        private readonly byte _type;

        /**
         * The time in 1s/10 required to complete the task.
         */
        private readonly ushort _requiredTime;

        /**
         * The ID of this dialog
         */
        private readonly int _requestId;

        /**
         * The amount of remaining items that still need to be produced.
         */
        private readonly byte _remaining;


        public DialogCraftingUpdateMessageEventArgs(BinaryReader reader)
        {
            _type = reader.ReadByte();
            if (_type == 0)
            {
                _remaining = reader.ReadByte();
                _requiredTime = reader.ReadUInt16();
            }
            _requestId = reader.Read();
        }

        // public ServerReplyResult Execute() {
//        if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //  }

        // We currently only know three types of update messages
        //      if (_type > 2) {
        // return ServerReplyResult.Failed;
        //    }

        //GuiUpdater.updateCraftingGui(_type, _remaining, _requiredTime);

        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[DialogCraftingUpdateMessage ID: " + _requestId + " TYPE: " + _type +
                   " Required Time (if any): " + _requiredTime / 10f + "s Remaining (if any): " + _remaining + "]";
        }
    }
}
