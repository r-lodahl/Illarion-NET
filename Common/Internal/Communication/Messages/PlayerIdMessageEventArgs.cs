using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class PlayerIdMessageEventArgs : EventArgs
    {
        /**
         * The ID if the character, played with this client.
         */
        private readonly int _playerId;


        public PlayerIdMessageEventArgs(BinaryReader reader)
        {
            _playerId = reader.Read();
        }

        // public ServerReplyResult Execute() {
//        LocalPlayerUpdater.setPlayerId(_playerId);
        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[PlayerIdMessage Id: " + _playerId + "]";
        }
    }
}
