using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class OpenInContainerCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The showcase the container is located in and also the showcase that will show up the opened container.
         */
        private readonly byte _containerId;

        /**
         * The slot within the showcase that contains the container.
         */
        private readonly byte _slot;

        /**
         * Default constructor for the open container in container command.
         *
         * @param containerId the ID of the container
         * @param slot the slot in the container where the item that is supposed to be opened is located
         */
        public OpenInContainerCommandEventArgs(int containerId, int slot) : base(Command.CmdOpenShowcase)
        {
            _containerId = (byte) containerId;
            _slot = (byte) slot;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_containerId);
            //writer.Write(_slot);
        }

        public override string ToString()
        {
            return "[OpenInContainerCommand Container:" + _containerId + " Slot: " + _slot + "]";
        }
    }
}
