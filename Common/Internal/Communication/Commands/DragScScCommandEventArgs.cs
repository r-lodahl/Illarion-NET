using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragScScCommandEventArgs : AbstractDragCommandEventArgs
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
         * The target container of the dragging event.
         */
        private readonly byte _targetContainer;

        /**
         * The target container item of the dragging event.
         */
        private readonly byte _targetContainerItem;

        /**
         * The default constructor of this DragScScCmd.
         *
         * @param sourceContainer the container that is the source
         * @param sourceSlot the slot in the container that is the source
         * @param destinationContainer the container that is the destination
         * @param destinationSlot the slot in the container that is the destination
         * @param count the amount of items to move
         */
        public DragScScCommandEventArgs(int sourceContainer, int sourceSlot, int destinationContainer,
            int destinationSlot, int count) : base(Command.CmdDragScSc, count)
        {
            _sourceContainer = (byte) sourceContainer;
            _sourceContainerItem = (byte) sourceSlot;
            _targetContainer = (byte) destinationContainer;
            _targetContainerItem = (byte) destinationSlot;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_sourceContainer);
            //writer.Write(_sourceContainerItem);
            //writer.Write(_targetContainer);
            //writer.Write(_targetContainerItem);
            //writer.Write(GetCount());
        }

        public override string ToString()
        {
            return "[DragScScCommand Source: " + _sourceContainer + '/' + _sourceContainerItem + " Destination: " +
                   _targetContainer + '/' + _targetContainerItem + ' ' + GetCount() + "]";
        }
    }
}
