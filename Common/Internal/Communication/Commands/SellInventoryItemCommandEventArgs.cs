using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class SellInventoryItemCommandEventArgs : AbstractTradeItemCommandEventArgs
    {
        /**
         * The sub command ID for this command.
         */
        private const int SubCmdId = 1;

        /**
     * The inventory slot to sell the item from.
     */
        private readonly ushort _slot;

        /**
         * The amount of items to sell.
         */
        private readonly ushort _amount;

        /**
         * Default constructor for the trade item command.
         *
         * @param dialogId the ID of the trading dialog to sell to
         * @param inventorySlot the inventory slot to tell the item from
         * @param count the amount of items to be sold
         */
        public SellInventoryItemCommandEventArgs(int dialogId, int inventorySlot, int count) : base(dialogId, SubCmdId)
        {
            _slot = (ushort) inventorySlot;
            _amount = (ushort) count;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            base.Encode(encoder, stream);
            //writer.Write((byte) 0);
            //writer.Write(_slot);
            //writer.Write(_amount);
        }

        public override string ToString()
        {
            return "[SellInventoryItemCommand " + base.ToString() + " Slot: " + _slot + ' ' + _amount + "]";
        }
    }
}