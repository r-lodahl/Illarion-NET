using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogSelectionMessageEventArgs : EventArgs
    {
        /**
         * The title of the dialog window.
         */

        private readonly string _title;

        /**
         * The message that is displayed inside this selection dialog.
         */

        private readonly string _message;

        /**
         * The ID of the dialog that needs to be returned in order to inform the server that the window was closed.
         */
        private readonly int _dialogId;

        private readonly ushort[] _selectionIds;
        private readonly string[] _selectionNames;


        public DialogSelectionMessageEventArgs(BinaryReader reader)
        {
            _title = reader.ReadString();
            _message = reader.ReadString();
            var itemCount = reader.ReadSByte();

            _selectionIds = new ushort[itemCount];
            _selectionNames = new string[itemCount];

            for (var i = 0; i < itemCount; i++)
            {
                _selectionIds[i] = reader.ReadUInt16();
                _selectionNames[i] = reader.ReadString();
            }

            _dialogId = reader.Read();
        }

        // public ServerReplyResult Execute() {
        // if ((_title == null) || (_message == null)) {
        //     throw new NotDecodedException();
        //}

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.showSelectionDialog(_dialogId, _title, _message, _selectionIds, _selectionNames);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[DialogSelectionMessage ID: " + _dialogId + " TITLE: " + _title + "]";
        }
    }
}
