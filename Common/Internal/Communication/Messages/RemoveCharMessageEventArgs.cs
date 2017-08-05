using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class RemoveCharMessageEventArgs : EventArgs
    {
        /**
         * The ID of the character that shall be removed.
         */
        private readonly int _charId;


        public RemoveCharMessageEventArgs(BinaryReader reader)
        {
            _charId = reader.Read();
        }

        // public ServerReplyResult Execute() {
//        EntityUpdater.removeEntity(_charId);
        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[RemoveCharMessage CharId: " + _charId + "]";
        }
    }
}
