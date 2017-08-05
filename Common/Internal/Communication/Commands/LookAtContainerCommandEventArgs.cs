using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookAtContainerCommandEventArgs : AbstractCommandEventArgs
    {

        /**
         * The container we are going to look at.
         */
        private readonly byte _containerId;

        /**
         * The slot within the container we are going to look at.
         */
        private readonly byte _slot;

        /**
         * Default constructor for the look at container command.
         *
         * @param containerId the ID of the container
         * @param slot the ID of the slot in the container
         */
        public LookAtContainerCommandEventArgs(int containerId, int slot) : base(Command.CmdLookatContainer)
        {
            _containerId = (byte) containerId;
            _slot = (byte) slot;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_containerId);
            //writer.Write(_slot);
        }

        /**
         * Get the data of this look at showcase command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[LookAtContainerCommand Container: " + _containerId + " Slot: " + _slot + "]";
        }
    }
}