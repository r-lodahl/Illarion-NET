using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookAtCraftItemCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The ID of the crafting dialog.
         */
        private readonly int _dialogId;

        /**
         * The index of the item to look at.
         */
        private readonly byte _itemIndex;

        /**
         * Default constructor for the looking at a crafting item.
         *
         * @param dialogId the ID of the dialog to close
         * @param itemIndex the index of the item to look at
         */
        public LookAtCraftItemCommandEventArgs(int dialogId, int itemIndex) : base(Command.CmdCraftItem)
        {
            _dialogId = dialogId;
            _itemIndex = (byte) itemIndex;
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_dialogId);
            //writer.Write((sbyte) 2);
            //writer.Write(_itemIndex);
        }

        public override string ToString()
        {
            return "[LookAtCraftItemCommand Dialog ID: " + _dialogId + " Look at index: " + _itemIndex + "]";
        }
    }
}
