using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogInputMessageEventArgs : EventArgs
    {
        /**
         * The title that is supposed to be displayed in the dialog.
         */
        private readonly string _title;

        /**
         * The description text that is displayed in this dialog.
         */
        private readonly string _description;

        /**
         * The flag if the text input is supposed to be multi-lined or not.
         */
        private readonly bool _multiLine;

        /**
         * The maximal amount of characters that are valid to be input.
         */
        private readonly ushort _maxCharacters;

        /**
         * The ID of this request.
         */
        private readonly int _requestId;


        public DialogInputMessageEventArgs(BinaryReader reader)
        {
            _title = reader.ReadString();
            _description = reader.ReadString();
            _multiLine = reader.ReadSByte() != 0;
            _maxCharacters = reader.ReadUInt16();
            _requestId = reader.Read();
        }

        // public ServerReplyResult Execute() {
        //   if ((_title == null) || (_description == null)) {
        //       throw new IllegalStateException("Message is not decoded yet.");
        //  }

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //        GuiUpdater.showInputDialog(_requestId, _title, _description, _maxCharacters, _multiLine);
        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[DialogInputMessage ID: " + _requestId + " TITLE: " + _title + " DESC: " + _description + "]";
        }
    }
}
