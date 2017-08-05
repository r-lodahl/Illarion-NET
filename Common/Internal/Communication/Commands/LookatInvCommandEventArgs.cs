using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookatInvCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The inventory slot we are looking at.
         */
        private readonly byte _slot;

        /**
         * Default constructor for the look at inventory command.
         *
         * @param slot the inventory slot to look at
         */
        public LookatInvCommandEventArgs(int slot) : base(Command.CmdLookatInv)
        {
            _slot = (byte) slot;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_slot);
        }

        /**
         * Get the data of this look at inventory command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[LookatInvCommand Slot: " + _slot + "]";
        }
    }
}
