using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Illarion.Common.Item;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogCraftingMessageEventArgs : EventArgs
    {
        /**
         * The title that is supposed to be displayed in the dialog.
         */
        private readonly string _title;

        /**
         * The group names
         */

        private readonly string[] _groups;

        /**
         * The crafting item.
         */

        private readonly CraftingItem[] _craftItems;

        /**
         * The ID of this request.
         */
        private readonly int _requestId;


        public DialogCraftingMessageEventArgs(BinaryReader reader)
        {
            _title = reader.ReadString();

            _groups = new string[reader.ReadByte()];
            var groupCount = _groups.Length;
            for (var i = 0; i < groupCount; i++)
            {
                Debug.Assert(_groups != null);
                _groups[i] = reader.ReadString();
            }

            _craftItems = new CraftingItem[reader.ReadByte()];
            var itemsCount = _craftItems.Length;
            for (var i = 0; i < itemsCount; i++)
            {
                var itemIndex = reader.ReadByte();
                var group = reader.ReadByte();
                var itemId = reader.ReadUInt16();
                var name = reader.ReadString();
                var buildTime = reader.ReadUInt16();
                var craftStackSize = reader.ReadByte();

                var numberOfIngredients = reader.ReadByte();

                var ingredients = new Dictionary<ushort, byte>();
                for (var j = 0; j < numberOfIngredients; j++)
                {
                    var ingredientId = reader.ReadUInt16();
                    var ingredientCount = reader.ReadByte();

                    ingredients.Add(ingredientId, ingredientCount);
                }

                Debug.Assert(_craftItems != null);
                _craftItems[i] = new CraftingItem(itemIndex, group, itemId, name, buildTime, craftStackSize,
                    ingredients);
            }

            _requestId = reader.Read();
        }

        // public ServerReplyResult Execute() {
        //if ((_groups == null) || (_craftItems == null) || (_title == null)) {
        //    throw new NotDecodedException();
        //}

//        if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //      }

        //    GuiUpdater.showCraftingDialog(_requestId, _title, _groups, _craftItems);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[DialogCraftingMessage ID: " + _requestId + " title: " + _title + "]";
        }
    }
}
