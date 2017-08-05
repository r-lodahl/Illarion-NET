using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragInvScCommandEventArgs : AbstractDragCommandEventArgs
    {
        /**
         * The source inventory slot of the dragging event.
         */
        private readonly byte _sourceSlot;

        /**
         * The target container of the dragging event.
         */
        private readonly byte _targetContainer;

        /**
         * The target slot of the container.
         */
        private readonly byte _targetContainerSlot;

        /**
         * The default constructor of this DragInvScCmd.
         */
        public DragInvScCommandEventArgs(int source, int targetContainer, int targetSlot, int count) : base(Command.CmdDragInvSc,
            count)
        {
            _sourceSlot = (byte) source;
            _targetContainer = (byte) targetContainer;
            _targetContainerSlot = (byte) targetSlot;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_sourceSlot);
            //writer.Write(_targetContainer);
            //writer.Write(_targetContainerSlot);
            //writer.Write((ushort)GetCount());
        }

        public override string ToString()
        {
            return "[DragInvScCommand Source: " + _sourceSlot + " Destination: " + _targetContainer + '/' +
                            _targetContainerSlot +
                            ' ' + GetCount()+"]";
        }
    }
}
