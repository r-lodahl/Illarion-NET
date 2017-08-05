using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class BuyTradingItemEventArgs : AbstractTradeItemCommandEventArgs {
        /**
     * The index of the item that is supposed to be bought.
     */
        private readonly byte _index;

        /**
     * The amount of items to buy.
     */
        private readonly ushort _amount;

        /**
     * The sub command ID for this command.
     */
        private const int SubCmdId = 2;

        /**
     * Default constructor for the trade item command.
     *
     * @param dialogId the ID of the dialog to buy the item from
     * @param index the index of the item to buy
     * @param count the amount of items to buy
     */
        public BuyTradingItemEventArgs(int dialogId, int index, int count) : base(dialogId, SubCmdId)
        {
            _index = (byte) index;
            _amount = (ushort) count;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            base.Encode(encoder, stream);
            //writer.Write(_index);
            //writer.Write(_amount);
        }

        public override string ToString() {
            return "[" + base.ToString() + " Index: " + _index + ' ' + _amount + "]";
        }
    }
}
