using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LocationMessageEventArgs : EventArgs
    {
        /**
         * The location of the player.
         */
        private readonly Coordinate _location;


        public LocationMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        }

        // public ServerReplyResult Execute() {
        // System.out.println("IM AT: " + this.toString());
        //LocalPlayerUpdater.moveToServerLocation(_locationX, _locationY, _locationZ);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[LocationMessage Location: (" + _location + ")]";
        }
    }
}
