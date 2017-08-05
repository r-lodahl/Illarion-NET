using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LookAtTileMessageEventArgs : EventArgs
    {

        /**
         * The location of the tile on the server map.
         */
        private readonly Coordinate _location;

        /**
     * The look at text for the tile.
     */
        private readonly string _text;


        public LookAtTileMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _text = reader.ReadString();
        }
        // public ServerReplyResult Execute() {
        //Log.warn(
        //      _text,
        //        "Location: (" + _locationX + "," + _locationY + "," + _locationZ + ")"
        //      );
        // return ServerReplyResult.Success;
//    }

        public override string ToString()
        {
            return "[LookAtTileMessage Location: (" + _location + ") Text: " + _text + "]";
        }
    }
}
