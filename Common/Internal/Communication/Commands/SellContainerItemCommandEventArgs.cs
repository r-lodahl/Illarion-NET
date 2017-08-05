using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class SellContainerItemCommandEventArgs : AbstractTradeItemCommandEventArgs
    {
        /**
         * The sub command ID for this command.
         */
        private const int SubCmdId = 1;

        /**
     * The ID of the container to sell the item from.
     */
        private readonly byte _container;

        /**
         * The slot in the inventory to sell the item from.
         */
        private readonly ushort _slot;

        /**
         * The amount of items to be sold.
         */
        private readonly ushort _amount;

        /**
         * Default constructor for the trade item command.
         *
         * @param dialogId the ID of the trading dialog to sell the item to
         * @param container the ID of the container to sell the item from
         * @param slot the slot in the container to sell the item from
         * @param count the amount of items to be sold
         */
        public SellContainerItemCommandEventArgs(int dialogId, int container, int slot, int count) : base(dialogId, SubCmdId)
        {
            _container = (byte) (container + 1);
            _slot = (ushort) slot;
            _amount = (ushort) count;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            base.Encode(encoder, stream);
            //writer.Write(_container);
            //writer.Write(_slot);
            //writer.Write(_amount);
        }

        public override string ToString()
        {
            return "[SellContainerItemCommand "  + base.ToString() + " Item: " + _container + '/' + _slot + ' ' + _amount + "]";
        }
    }
}