using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CloseDialogMessageCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID of the dialog to close. This ID is send by the server once the dialog is opened.
     */
        private readonly int _dialogId;

        /**
     * Default constructor for the close message dialog command.
     *
     * @param dialogId the ID of the dialog to close
     */
        public CloseDialogMessageCommandEventArgs(int dialogId) : base(Command.CmdCloseDialogMessage) {
           _dialogId = dialogId;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_dialogId);
        }

        public override string ToString() {
            return "[CloseDialogMessageCommand Dialog ID: " + _dialogId+"]";
        }
    }
}
