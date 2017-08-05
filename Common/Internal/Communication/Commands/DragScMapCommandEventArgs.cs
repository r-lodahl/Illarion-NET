using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragScMapCommandEventArgs : AbstractDragCommandEventArgs
    {
        /**
         * The source container of the dragging event.
         */
        private readonly byte _sourceContainer;

        /**
         * The source container item of the dragging event.
         */
        private readonly byte _sourceContainerItem;

        /**
         * The target location of the dragging event.
         */
        private Coordinate _destination;

        /**
         * The default constructor of this DragScMapCmd.
         *
         * @param sourceContainer the container that is the source
         * @param sourceSlot the slot in the container that is the source
         * @param destination the location on the map that is the destination of the drag
         * @param count the amount of items to move
         */
        public DragScMapCommandEventArgs(int sourceContainer, int sourceSlot, Coordinate destination, int count) : base(
            Command.CmdDragScMap, count)
        {

            _sourceContainer = (byte) sourceContainer;
            _sourceContainerItem = (byte) sourceSlot;
            _destination = destination;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_sourceContainer);
            //writer.Write(_sourceContainerItem);
            //writer.Write(_destination.X);
            //writer.Write(_destination.Y);
            //writer.Write(_destination.Z);
            //writer.Write(GetCount());
        }

        public override string ToString()
        {
            return "[DragScMapCommand Source: " + _sourceContainer + '/' + _sourceContainerItem + " Destination: (" +
                   _destination + ") " + GetCount() + "]";
        }
    }
}
