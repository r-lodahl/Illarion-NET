using System.Collections.Generic;

namespace Illarion.Common.Item
{
    public class CraftingItem : Item
    {
        private readonly byte _itemIndex, _itemGroup, _craftingStackSize;
        private readonly ushort _craftingTime;
        private Dictionary<ushort, byte> _craftingIngredients;

        public CraftingItem(byte itemIndex, byte itemGroup, ushort itemId, string name, ushort craftingTime,
            byte craftingStackSize, Dictionary<ushort, byte> ingredients) : base(itemId, name)
        {
            _itemIndex = itemIndex;
            _itemGroup = itemGroup;
            
            _craftingTime = craftingTime;
            _craftingStackSize = craftingStackSize;
            _craftingIngredients = ingredients;
        }
    }
}
