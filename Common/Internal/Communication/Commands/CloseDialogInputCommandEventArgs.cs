using System.IO;
using Illarion.Common.Internal.Serialization;
using JetBrains.Annotations;

namespace Illarion.Common.Internal.Communication.Commands
{
    public class CloseDialogInputCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID that was send by the server to initiate text input.
     */
        private readonly int _dialogId;

        /**
     * The text that is send to the server.
     */
    
        [NotNull]
        private readonly string _text;

        /**
     * The flag that stores if the input was confirmed or canceled.
     */
        private readonly byte _success;

        /**
     * Default constructor for the text response command.
     *
     * @param dialogID the ID of the dialog to close
     * @param text the text that contains the response
     * @param success {@code true} in case the dialog was confirmed
     */
        public CloseDialogInputCommandEventArgs(int dialogId, string text, bool success) : base(Command.CmdCloseDialogInput) {
            _dialogId = dialogId;
            _text = text;
            _success = (byte) (success ? 0xFF : 0x00);
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_dialogId);
            //writer.Write(_success);
            //writer.Write(_text);
        }

        public override string ToString() {
            return "[CloseDialogInputCommand Dialog ID: " + _dialogId + " - Response: " + _text + " successful: " + _success + "]";
        }
    }
}
