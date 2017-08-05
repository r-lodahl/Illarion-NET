using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookAtMerchantItemCommandEventArgs : AbstractTradeItemCommandEventArgs
    {
        /**
         * The constant ID for the list of items sold.
         */
        // TODO: Check if this can be removed
        public static byte ListIdSell = 0;

        /**
         * The constant ID for the list of primary bought items.
         */
        public static byte ListIdBuyPrimary = 1;

        /**
         * The constant ID for the list of secondary bought items.
         */
        public static byte ListIdBuySecondary = 2;

        /**
         * The sub command ID for this command.
         */
        private const int SubCmdId = 3;

        /**
     * The ID of the list.
     */
        private readonly byte _listId;

        /**
         * The ID of the slot.
         */
        private readonly byte _slotId;

        /**
         * The constructor for the look at a merchant item command.
         *
         * @param dialogId the merchant dialog
         * @param listId the index of the list, looked at. Can be {@link #LIST_ID_SELL}, {@link #LIST_ID_BUY_PRIMARY},
         * or {@link #LIST_ID_BUY_SECONDARY}
         * @param slotId the ID of the item slot
         */
        public LookAtMerchantItemCommandEventArgs(int dialogId, int listId, int slotId) : base(dialogId, SubCmdId)
        {
            _listId = (byte) listId;
            _slotId = (byte) slotId;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            base.Encode(encoder, stream);
            //writer.Write(_listId);
            //writer.Write(_slotId);
        }

        public override string ToString()
        {
            return "[LookAtMerchantItemCommand " + base.ToString() + " Look at list: " + _listId + ", Look at index: " +
                   _slotId + "]";
        }
    }
}
