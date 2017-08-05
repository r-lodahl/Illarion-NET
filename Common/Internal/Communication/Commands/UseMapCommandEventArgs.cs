using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class UseMapCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The map location that is used.
         */

        private readonly Coordinate _location;

        /**
     * Default constructor for the use command.
     *
     * @param location the location that is used
     */
        public UseMapCommandEventArgs(Coordinate location) : base(Command.CmdUse)
        {
            _location = location;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write((byte) 1); // MAP REFERENCE
            //writer.Write(_location.X);
            //writer.Write(_location.Y);
            //writer.Write(_location.Z);
        }

        public override string ToString()
        {
            return "[UseMapCommand Location (" + _location + ")]";
        }
    }
}
