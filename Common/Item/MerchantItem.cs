namespace Illarion.Common.Item
{
    public class MerchantItem : Item
    {
        private int _entryId;
        private MerchantTradeType _merchantTradeType;
        private uint _itemValue;
        private byte _stackSize;

        public MerchantItem(int entryId, MerchantTradeType tradeType, ushort itemId, string itemName, uint itemValue,
            byte stackSize = 0) : base(itemId, itemName)
        {
            _entryId = entryId;
            _merchantTradeType = tradeType;
            _itemValue = itemValue;
            _stackSize = stackSize;
        }
    }
}
