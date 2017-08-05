using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;
using Illarion.Common.Map;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class OpenOnMapCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The direction relative to the player character the bag is located at.
         */
        private readonly Direction _direction;

        /**
         * Default constructor for the open container on the map command.
         *
         * @param mapLocation the location on the map where the container is supposed to be opened
         */
        public OpenOnMapCommandEventArgs(Coordinate mapLocation) : base(Command.CmdOpenMap)
        {
            _direction = Direction.East;
            //TODO: This should be done by the receiving class not by the network!
            //_direction = mapLocation.getLocation(PlayerLocation);
        }

        /**
         * Encode the data of this open container on map command and put the values into the buffer.
         *
         * @param writer the interface that allows writing data to the network communication system
         */

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //_direction.Encode(writer);
        }

        /**
         * Get the data of this open container on map command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[OpenOnMapCommand From direction: " + _direction + "]";
        }
    }
}
