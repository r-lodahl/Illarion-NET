using System;
using System.IO;
using Illarion.Common.UiHelper;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LookAtDialogItemMessageEventArgs : EventArgs
    {
        /**
         * The ID of the dialog.
         */
        private readonly int _dialogId;

        /**
         * The look at type.
         */
        private readonly DialogSlot _type;

        /**
         * The ID of the slot.
         */
        private readonly byte _slotId;

        /**
         * The ID of the secondary slot.
         */
        private readonly byte _secondarySlotId;

        /**
         * The tool tip.
         */

        private readonly Tooltip _tooltip;

        public LookAtDialogItemMessageEventArgs(BinaryReader reader)
        {
            _dialogId = reader.Read();
            _type = (DialogSlot) reader.ReadByte();

            switch (_type)
            {
                case DialogSlot.Primary:
                    _slotId = reader.ReadByte();
                    break;
                case DialogSlot.Secondary:
                    _slotId = reader.ReadByte();
                    _secondarySlotId = reader.ReadByte();
                    break;
                default:
                    UnityEngine.Debug.LogError(string.Format("Illegal type ID: {0}", _type));
                    return;
            }

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
//        if (_tooltip == null) {
        //          throw new NotDecodedException();
        //    }

        //  if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        // }

        // GuiUpdater.handleItemTooltip(_dialogId, _slotId, _secondarySlotId, _tooltip);

        // return ServerReplyResult.Success;
        // }

        //[NotNull]


        public override string ToString()
        {
            return "[LookAtDialogItemMessage DialogID: " + _dialogId + " ToolTip: " + _tooltip + "]";
        }
    }
}

