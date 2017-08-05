using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class TargetLostMessageEventArgs : EventArgs
    {

        public TargetLostMessageEventArgs(BinaryReader reader)
        {
            // nothing to decode
        }

        // public ServerReplyResult Execute() {
//        LocalPlayerUpdater.informTargetLost();
        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[TargetLostMessage]";
        }
    }
}
