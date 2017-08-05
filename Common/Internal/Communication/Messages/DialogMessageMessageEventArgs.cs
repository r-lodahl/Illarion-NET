using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogMessageMessageEventArgs : EventArgs
    {
        /**
         * The title of the dialog window.
         */

        private readonly string _title;

        /**
         * The content of the dialog.
         */

        private readonly string _content;

        /**
         * The ID of the dialog that needs to be returned in order to inform the server that the window was closed.
         */

        private readonly int _dialogId;


        public DialogMessageMessageEventArgs(BinaryReader reader)
        {
            _title = reader.ReadString();
            _content = reader.ReadString();
            _dialogId = reader.Read();
        }

        // public ServerReplyResult Execute() {
//        if ((_title == null) || (_content == null)) {
        //          throw new NotDecodedException();
        //    }

        //  if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.showMessageDialog(_dialogId, _title, _content);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[DialogMessageMessage ID: " + _dialogId + " TITLE: " + _title + "]";
        }
    }
}
