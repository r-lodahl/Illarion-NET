using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class AttackMessageEventArgs : EventArgs
    {

        public AttackMessageEventArgs(BinaryReader reader)
        {
            // nothing to decode
        }
        // public ServerReplyResult Execute() {
        //   LocalPlayerUpdater.confirmAttack();
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[AttackMessage]";
        }
    }
}
