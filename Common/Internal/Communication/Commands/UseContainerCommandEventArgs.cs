using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class UseContainerCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The ID of the container that contains the used slot.
         */
        private readonly byte _containerId;

        /**
         * The slot that is used.
         */
        private readonly byte _slot;

        /**
         * Default constructor for the use command.
         *
         * @param container the ID of the container that is used
         * @param slot the ID of the container slot that is used
         */
        public UseContainerCommandEventArgs(int container, int slot) : base(Command.CmdUse)
        {
            _containerId = (byte) container;
            _slot = (byte) slot;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write((byte) 2); // CONTAINER REFERENCE
            //writer.Write(_containerId);
            //writer.Write(_slot);
        }

        public override string ToString()
        {
            return "[UseContainerCommand Container: " + _containerId + " Slot: " + _slot + "]";
        }
    }
}
