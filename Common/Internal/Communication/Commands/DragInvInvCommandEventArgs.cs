using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragInvInvCommandEventArgs : AbstractDragCommandEventArgs {
        /**
     * The inventory position the drag ends at.
     */
        private readonly byte _dstPos;

        /**
     * The inventory position the drag starts at.
     */
        private readonly byte _srcPos;

        /**
     * Default constructor for the dragging from inventory to inventory command.
     *
     * @param source the inventory position where the drag starts
     * @param destination the inventory position where the drag ends
     * @param count the amount of items to drag
     */
        public DragInvInvCommandEventArgs(int source, int destination, int count) : base(Command.CmdDragInvInv, count) {
            _srcPos = (byte) source;
            _dstPos = (byte) destination;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_srcPos);
            //writer.Write(_dstPos);
            //writer.Write((ushort)GetCount());
        }

        public override string ToString() {
            return "[DragInvInvCommand Source: " + _srcPos + " Destination: " + _dstPos + ' ' + GetCount()+"]";
        }
    }
}
