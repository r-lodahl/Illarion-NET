using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class BookMessageEventArgs : EventArgs
    {
        /**
         * The book id that was sent.
         */
        private readonly ushort _bookId;


        public BookMessageEventArgs(BinaryReader reader)
        {
            _bookId = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        //if (GuiUpdater.isGuiReady()) {
        //  GuiUpdater.showBook(_bookId);
        // return ServerReplyResult.Success;
        //}
        // return ServerReplyResult.Reschedule;
        //}

        public override string ToString()
        {
            return "[BookMessage BookId:" + _bookId + "]";
        }
    }
}
