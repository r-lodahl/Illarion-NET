
using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public sealed class DragMapMapCommandEventArgs : AbstractDragCommandEventArgs
    {
        /**
         * The source location of the move operation.
         */
        private Coordinate _source;

        /**
         * The location on the map that is the target of the move operation.
         */
        private Coordinate _destination;

        /**
         * Default constructor for the dragging from map to map command.
         *
         * @param source the location from where the item is taken
         * @param destination the destination location on the map
         * @param count the amount of items to move
         */
        public DragMapMapCommandEventArgs(Coordinate source, Coordinate destination, int itemCount) : base(Command.CmdDragMapMap, itemCount)
        {
            _source = source;
            _destination = destination;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_source.X);
            //writer.Write(_source.Y);
            //writer.Write(_source.Z);
            //writer.Write(_destination.X);
            //writer.Write(_destination.Y);
            //writer.Write(_destination.Z);
            //writer.Write((ushort)GetCount());
        }

        public override string ToString()
        {
            return "[DragMapMapCommand Source: (" + _source + ") Destination: (" + _destination + ") " + GetCount()+ "]";
        }
    }
}
