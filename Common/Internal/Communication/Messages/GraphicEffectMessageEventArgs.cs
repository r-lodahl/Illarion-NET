using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class GraphicEffectMessageEventArgs : EventArgs
    {
        /**
         * ID of the effect that shall be shown.
         */
        private readonly ushort _effectId;

        /**
         * The location the effect occurs on.
         */
        private readonly Coordinate _location;


        public GraphicEffectMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(
                reader.ReadInt16(),
                reader.ReadInt16(),
                reader.ReadInt16()
            );

            _effectId = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        //  if (MapUpdater.isEmpty()) {
        // return ServerReplyResult.Reschedule;
        //}

        //  if (MapUpdater.showEffect(_locationX, _locationY, _locationZ, _effectId)) {
        // return ServerReplyResult.Success;
        // }

        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[GraphicEffectMessage " + "Location: (" + _location + ") + ID: " + _effectId + "]";
        }
    }
}
