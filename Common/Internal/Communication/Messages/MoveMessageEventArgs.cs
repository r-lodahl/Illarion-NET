using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class MoveMessageEventArgs : EventArgs
    {

        /**
         * The ID of the moving character.
         */
        private readonly int _charId;

        /**
         * The new location of the character.
         */
        private readonly Coordinate _location;

        /**
     * The moving mode of the character. Valid values are {@link #MODE_NO_MOVE}, {@link #MODE_MOVE}, {@link
     * #MODE_PUSH}.
     */
        private readonly byte _mode;

        /**
         * The moving duration of the character (in milliseconds)
         */
        private readonly ushort _duration;


        public MoveMessageEventArgs(BinaryReader reader)
        {
            _charId = reader.Read();
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _mode = reader.ReadByte();
            _duration = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
//        if (!EntityUpdater.isAllowedMoveType(_mode)) {
        //          Log.warn("Move char message called in unknown mode {}", _mode);
        // return ServerReplyResult.Failed;
        //    }

        //  if (EntityUpdater.moveEntity(_charId, _mode, _locationX, _locationY, _locationZ, _duration)) {
        // return ServerReplyResult.Success;
        //}

        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[MoveMessage charId: " + _charId +
                   " Location: (" + _location + ")" +
                   " Duration: " + _duration + "ms]";
        }
    }
}
