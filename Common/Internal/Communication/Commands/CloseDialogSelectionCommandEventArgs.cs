using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CloseDialogSelectionCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID that was send by the server to initiate text input.
     */
        private readonly int _dialogId;

        /**
     * The index that was selected.
     */
        private readonly byte _selectedIndex;

        /**
     * The flag that stores if the input was confirmed or canceled.
     */
        private readonly byte _success;

        /**
     * Default constructor for the text response command.
     *
     * @param dialogID the ID of the dialog
     * @param selectedIndex the index that was selected
     * @param success {@code true} in case the dialog got confirmed
     */
        public CloseDialogSelectionCommandEventArgs(int dialogId, int selectedIndex, bool success) : base(Command.CmdCloseDialogSelection) {
            _dialogId = dialogId;
            _selectedIndex = (byte) selectedIndex;
            _success = (byte) (success ? 0xFF : 0x00);
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_dialogId);
            //writer.Write(_success );
            //writer.Write(_selectedIndex);
        }

        public override string ToString() {
            return "[CloseDialogSelectionCommand Dialog ID: " + _dialogId + " - Index: " + _selectedIndex + " successful: " + _success+"]";
        }
    }
}
