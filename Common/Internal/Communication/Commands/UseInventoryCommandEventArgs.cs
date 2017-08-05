using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class UseInventoryCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The inventory slot that is used.
         */
        private readonly byte _slot;

        /**
         * Default constructor for the use command.
         *
         * @param inventorySlot the inventory slot that is used
         */
        public UseInventoryCommandEventArgs(int inventorySlot) : base(Command.CmdUse)
        {
            _slot = (byte) inventorySlot;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write((byte) 3); // INVENTORY REFERENCE
            //writer.Write(_slot);
        }

        public override string ToString()
        {
            return "[UseInventoryCommand Slot: " + _slot + "]";
        }
    }
}
