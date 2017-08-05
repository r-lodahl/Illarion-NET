using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DisconnectMessageEventArgs : EventArgs
    {
        /**
         * The ID of the logout reason.
         */
        private readonly byte _reason;


        public DisconnectMessageEventArgs(BinaryReader reader)
        {
            _reason = reader.ReadByte();
        }
        // public ServerReplyResult Execute() {
        // GameUpdater.handleDisconnect(_reason);
        // return ServerReplyResult.Success;
        // }

        public override string ToString()
        {
            return "[DisconnectMessage Reason:" + _reason + "]";
        }
    }
}
