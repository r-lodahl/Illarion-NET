using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class IntroduceMessageEventArgs : EventArgs
    {
        /**
         * The ID of the character who is introduced.
         */
        private readonly int _charId;

        /**
         * The name of the character.
         */

        private readonly string _name;


        public IntroduceMessageEventArgs(BinaryReader reader)
        {
            _charId = reader.Read();
            _name = reader.ReadString();
        }

        // public ServerReplyResult Execute() {
        //   if (_name == null) {
        //     throw new NotDecodedException();
        //}

        //if (EntityUpdater.checkExistence(_charId)) {
        //  EntityUpdater.updateName(_charId, _name);
        // return ServerReplyResult.Success;
        //}

        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[IntroduceMessage charId: " + _charId + " Name:" + _name + "]";
        }
    }
}
