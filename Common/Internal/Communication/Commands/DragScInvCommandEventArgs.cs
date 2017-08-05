using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragScInvCommandEventArgs : AbstractDragCommandEventArgs
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
         * The target inventory slot of the dragging event.
         */
        private readonly byte _targetSlot;

        /**
         * The default constructor of this DragScInvCmd.
         *
         * @param sourceContainer the container that is the source
         * @param sourceSlot the slot in the container that is the source
         * @param destination the inventory slot that is the destination of the drag
         * @param count the amount of items to move
         */
        public DragScInvCommandEventArgs(int sourceContainer, int sourceSlot, int destination, int count) : base(
            Command.CmdDragScInv, count)
        {
            _sourceContainer = (byte) sourceContainer;
            _sourceContainerItem = (byte) sourceSlot;
            _targetSlot = (byte) destination;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_sourceContainer);
            //writer.Write(_sourceContainerItem);
            //writer.Write(_targetSlot);
            //writer.Write(GetCount());
        }

        public override string ToString()
        {
            return "[DragScInvCommand Source: " + _sourceContainer + '/' + _sourceContainerItem + " Destination: " +
                   _targetSlot + ' ' + GetCount() + "]";
        }
    }
}