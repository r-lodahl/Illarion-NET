using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class PickUpItemCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The location on the map where the item is fetched from.
         */
        private readonly Coordinate _location;

        /**
     * Default constructor for the pickup command.
     *
     * @param location the location the item is taken from
     */
        public PickUpItemCommandEventArgs(Coordinate location) : base(Command.CmdPickUp)
        {
            _location = location;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_location.X);
            //writer.Write(_location.Y);
            //writer.Write(_location.Z);
        }

        public override string ToString()
        {
            return "Location (" + _location + ")";
        }
    }
}
