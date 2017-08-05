using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class CloseDialogMessageEventArgs : EventArgs
    {
        /**
         * The ID of the dialog that is supposed to be closed.
         */
        private readonly int _dialogId;


        public CloseDialogMessageEventArgs(BinaryReader reader)
        {
            _dialogId = reader.Read();
        }


        // public ServerReplyResult Execute() {
        //   GuiUpdater.closeAnyDialog(_dialogId);
        // return ServerReplyResult.Success;
        // }


        public override string ToString()
        {
            return "[CloseDialogMessage dialogId: " + _dialogId +"]";
        }
    }
}
