using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LookAtCharMessageEventArgs : EventArgs
    {

        /**
         * The ID of the character the look at text is related to.
         */
        private readonly uint _charId;

        /**
         * The text that is the look at result.
         */

        private readonly string _text;


        public LookAtCharMessageEventArgs(BinaryReader reader)
        {
            _charId = reader.ReadUInt32();
            _text = reader.ReadString();
        }
// public ServerReplyResult Execute() {
//        Log.warn("Received a look at char message for some reason for {} with the text {}", _charId, _text);
        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[LookAtCharMessage charId: " + _charId + " Text:" + _text + "]";
        }
    }
}
