using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class MusicMessageEventArgs : EventArgs
    {
        /**
         * The ID of the song that shall be played.
         */
        private readonly ushort _song;


        public MusicMessageEventArgs(BinaryReader reader)
        {
            _song = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        // GameUpdater.playMusic(_song);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[MusicMessage Song: " + _song + "]";
        }
    }
}
