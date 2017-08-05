using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class MapCompleteMessageEventArgs : EventArgs
    {

        public MapCompleteMessageEventArgs(BinaryReader reader)
        {
            // nothing to decode
        }

        // public ServerReplyResult Execute() {
        //MapUpdater.mapCompletelyLoaded();
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[MapCompleteMessage]";
        }
    }
}
