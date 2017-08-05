using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class DragMapScCommandEventArgs : AbstractDragCommandEventArgs {
    /**
     * The location where the item that is moved is located at.
     */
    private Coordinate _source;

    /**
     * The target container of the dragging event.
     */
    private readonly byte _targetContainer;

    /**
     * The target slot of the container.
     */
    private readonly byte _targetContainerSlot;

    /**
     * The default constructor of this DragMapScCmd.
     *
     * @param source the location from where the item is taken
     * @param destinationContainer the container that is the destination
     * @param destinationSlot the slot in the container that is the destination
     * @param count the amount of items to move
     */
    public DragMapScCommandEventArgs(Coordinate source, int destinationContainer, int destinationSlot, int count) : base(Command.CmdDragMapSc, count)
    {
        _source = source;
        _targetContainer = (byte) destinationContainer;
        _targetContainerSlot = (byte) destinationSlot;
    }

    public override void Encode(IEncoder encoder, Stream stream)
    {
        //writer.Write(_source.X);
        //writer.Write(_source.Y);
        //writer.Write(_source.Z);
        //writer.Write(_targetContainer);
        //writer.Write(_targetContainerSlot);
        //writer.Write(GetCount());
    }

    public override string ToString()
    {
        return "[DragMapScCommand Source: (" + _source + ") Destination: " + _targetContainer +
                        '/' + _targetContainerSlot + ' ' + GetCount() + "]";
    }
    }
}
