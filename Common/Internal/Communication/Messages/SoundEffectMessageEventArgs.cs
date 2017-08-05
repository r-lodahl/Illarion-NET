using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class SoundEffectMessageEventArgs : EventArgs
    {
        /**
         * ID of the effect that shall be shown.
         */
        private readonly ushort _effectId;

        /**
         * The location the effect occurs on.
         */
        private readonly Coordinate _location;


        public SoundEffectMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _effectId = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        // GameUpdater.playSoundEffect(_locationX, _locationY, _locationZ, _effectId);
        // return ServerReplyResult.Success;
        //    }

        public override string ToString()
        {
            return "[SoundEffectMessage Location: (" + _location + ") Sound: " + _effectId + "]";
        }
    }
}
