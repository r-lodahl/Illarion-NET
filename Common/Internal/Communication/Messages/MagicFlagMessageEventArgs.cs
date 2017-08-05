using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class MagicFlagMessageEventArgs : EventArgs
    {
        /**
         * Flags of the magic that are available. So the runes a character is allowed to use.
         */
        private readonly uint _flags;

        /**
         * Type of magic that is used. Such a magician, druid, bard, priest.
         */
        private readonly byte _type;


        public MagicFlagMessageEventArgs(BinaryReader reader)
        {
            _type = reader.ReadByte();
            _flags = reader.ReadUInt32();
        }

        // public ServerReplyResult Execute() {
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[MagicFlagMessage Type: " + _type + " Flags: " + _flags + "]";
        }
    }
}
