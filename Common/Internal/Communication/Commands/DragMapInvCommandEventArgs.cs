using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragMapInvCommandEventArgs : AbstractDragCommandEventArgs {
        /**
     * The location the item that is moved by this command is located at.
     */
        private readonly short _srcLocX;

        private readonly short _srcLocY;

        private readonly short _srcLocZ;

        /**
     * The inventory slot that is the target of this drag operation.
     */
        private readonly byte _dstPos;

        /**
     * Default constructor for the dragging from map to inventory command.
     *
     * @param srcLocX, srcLocY, srcLocZ the location from where the item is taken
     * @param destination the destination slot in the inventory
     * @param count the amount of items to move
     */
        public DragMapInvCommandEventArgs(short srcLocX, short srcLoxY, short srcLocZ, int destination, int count) : base(Command.CmdDragMapInv, count) {
            _srcLocX = srcLocX;
            _srcLocY = srcLoxY;
            _srcLocZ = srcLocZ;
            _dstPos = (byte) destination;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_srcLocX);
            //writer.Write(_srcLocY);
            //writer.Write(_srcLocZ);
            //writer.Write(_dstPos);
            //writer.Write(GetCount());
        }

        public override string ToString() {
            return "[DragMapInvCommand Source: (" + _srcLocX +
                            "," + _srcLocY + "," + _srcLocZ +
                            ") Destination: " + _dstPos +
                            ' ' + GetCount()+"]";
        }
    }
}
