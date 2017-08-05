using System;
using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookAtMapItemCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The position on the map we are going to look at.
         */
        private Coordinate _location;

        /**
         * The position of the item inside the stack.
         */
        private readonly byte _stackPosition;

        /**
         * Default constructor for the look at tile command.
         *
         * @param tileLocation the location of the tile to look at
         * @param position the position of the item inside the stack
         */
        public LookAtMapItemCommandEventArgs(Coordinate tileLocation, int position) : base(Command.CmdLookAtMapItem)
        {
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException("Position has to be 0 or more. Got: " + position);
            }
            _location = tileLocation;
            _stackPosition = (byte) position;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_location.X);
            //writer.Write(_location.Y);
            //writer.Write(_location.Z);
            //writer.Write(_stackPosition);
        }

        public override string ToString()
        {
            return "[LookAtMapItemCommand Location (" + _location + ") Stack position: " + _stackPosition + "]";
        }
    }
}