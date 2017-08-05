using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CraftItemCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The ID of the dialog to interact with.
         */
        private readonly int _dialogId;

        /**
         * The index of the item in the crafting list that is referred to.
         */
        private readonly byte _craftingIndex;

        /**
         * The amount of items to be crafted.
         */
        private readonly byte _amount;

        /**
         * Default constructor for the trade item command.
         *
         * @param dialogId the dialog ID of the dialog to craft a item from
         * @param craftingIndex the index of the item to craft
         * @param amount the amount of items to create as a batch
         */
        public CraftItemCommandEventArgs(int dialogId, int craftingIndex, int amount) : base(Command.CmdCraftItem)
        {
            _dialogId = dialogId;
            _craftingIndex = (byte) craftingIndex;
            _amount = (byte) amount;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_dialogId);
            //writer.Write((byte)1);
            //writer.Write(_craftingIndex);
            //writer.Write(_amount);
        }

        public override string ToString()
        {
            return "[CraftItemCommand dialog ID: " + _dialogId+"]";
        }
    }
}
