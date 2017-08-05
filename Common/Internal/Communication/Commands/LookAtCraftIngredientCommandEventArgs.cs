using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookAtCraftIngredientCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The ID of the crafting dialog.
         */
        private readonly int _dialogId;

        /**
         * The index of the item that is supposed to be crafted
         */
        private readonly byte _itemIndex;

        /**
         * The index of the ingredient to look at.
         */
        private readonly byte _ingredientIndex;

        /**
         * Default constructor for the looking at a crafting item.
         *
         * @param dialogId the ID of the dialog to close
         * @param itemIndex the index of the item that is crafted
         * @param ingredientIndex the index of the ingredient to look at
         */
        public LookAtCraftIngredientCommandEventArgs(int dialogId, int itemIndex, int ingredientIndex) : base(Command
            .CmdCraftItem)
        {
            _dialogId = dialogId;
            _itemIndex = (byte) itemIndex;
            _ingredientIndex = (byte) ingredientIndex;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_dialogId);
            //writer.Write((sbyte) 3);
            //writer.Write(_itemIndex);
            //writer.Write(_ingredientIndex);
        }

        public override string ToString()
        {
            return "[LookAtCraftIngredientCommand Dialog ID: " + _dialogId + " Look at index: " + _itemIndex +
                   " Ingredient index:" +
                   _ingredientIndex + "]";
        }
    }
}
