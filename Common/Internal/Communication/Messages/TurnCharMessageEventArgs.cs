using System;
using System.IO;
using Illarion.Common.Map;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class TurnCharMessageEventArgs : EventArgs
    {

        /**
         * The ID of the character that is turned.
         */
        private readonly int _charId;

        /**
         * The new direction of the character.
         */
        private readonly Direction _direction;

        public TurnCharMessageEventArgs(BinaryReader reader)
        {
            _direction = Direction.FromServerId(reader.ReadByte());
            _charId = reader.Read();
        }

        // public ServerReplyResult Execute() {
        //    if (_direction == null) {
        //      Log.error("Decoding of the direction from the server failed.");
        // return ServerReplyResult.Failed;
        //}

//        EntityUpdater.turnEntity(_charId, _dir);

        // return ServerReplyResult.Success;
        //  }

        public override string ToString()
        {
            return "[TurnCharMessage charId: " + _charId + " To: " + _direction + "]";
        }
    }
}
