using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class CloseShowcaseMessageEventArgs : EventArgs
    {
        /**
         * The container that shall be closed.
         */
        private readonly byte _containerId;


        public CloseShowcaseMessageEventArgs(BinaryReader reader)
        {
            _containerId = reader.ReadByte();
        }

        // public ServerReplyResult Execute() {
        //  LocalPlayerUpdater.removeContainer(_containerId);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[CloseShowcaseMessage containerId: " + _containerId + "]";
        }
    }
}