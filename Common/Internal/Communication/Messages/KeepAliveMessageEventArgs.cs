using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class KeepAliveMessageEventArgs : EventArgs
    {

        public KeepAliveMessageEventArgs(BinaryReader reader)
        {
            //ConnectionPerformanceClock.notifyNetCommDecode();
        }

        // public ServerReplyResult Execute() {
        //ConnectionPerformanceClock.notifyPublishToClient();
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[KeepAliveMessage]";
        }
    }
}
