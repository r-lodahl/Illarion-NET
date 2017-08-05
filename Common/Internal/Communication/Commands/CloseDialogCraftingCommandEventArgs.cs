using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CloseDialogCraftingCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID of the dialog to close. This ID is send by the server once the dialog is opened.
     */
        private readonly int _dialogId;

        /**
     * Default constructor for the close crafting dialog command.
     *
     * @param dialogId the ID of the dialog to close
     */
        public CloseDialogCraftingCommandEventArgs(int dialogId) : base(Command.CmdCraftItem) {
            _dialogId = dialogId;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_dialogId);
            //writer.Write((byte)0);
        }

        public override string ToString() {
            return "[CloseDialogCraftingCommand Dialog ID: " + _dialogId + "]";
        }
    }
}
