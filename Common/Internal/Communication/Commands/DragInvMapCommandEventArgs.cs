using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragInvMapCommandEventArgs : AbstractDragCommandEventArgs {
        /**
     * The location on the map that is the target of the move operation.
     */
        private readonly short _destinationX;

        private readonly short _destinationY;

        private readonly short _destinationZ;

        /**
     * Inventory position the drag starts at.
     */
        private readonly byte _srcPos;

        /**
     * Default constructor for the dragging from inventory to map command.
     */
        public DragInvMapCommandEventArgs(int source, short destinationX, short destinationY, short destinationZ, int count) : base(Command.CmdDragInvMap, count) {
            _srcPos = (byte) source;
            _destinationX = destinationX;
            _destinationY = destinationY;
            _destinationZ = destinationZ;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_srcPos);
            //writer.Write(_destinationX);
            //writer.Write(_destinationY);
            //writer.Write(_destinationZ);
            //writer.Write((ushort) GetCount());
        }

        public override string ToString() {
            return "[DragInvMapCommand Source: " + _srcPos + " Destination: (" + _destinationX +
                            "," + _destinationY + "," + _destinationZ + ")" + ' ' + GetCount() + "]";
        }
    }
}
