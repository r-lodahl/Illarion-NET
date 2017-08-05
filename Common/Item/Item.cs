namespace Illarion.Common.Item
{
    public class Item
    {
        private ushort _itemId;
        private string _itemName;

        public Item(ushort id, string name)
        {
            _itemId = id;
            _itemName = name;
        }

    }
}
