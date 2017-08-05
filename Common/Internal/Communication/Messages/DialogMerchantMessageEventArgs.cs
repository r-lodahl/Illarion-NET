using System;
using System.Collections.Generic;
using System.IO;
using Illarion.Common.Item;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DialogMerchantMessageEventArgs : EventArgs
    {
        /**
         * The title of the dialog window.
         */
        private readonly string _title;

        /**
         * The ID of the dialog that needs to be returned in order to inform the server that the window was closed.
         */
        private readonly int _dialogId;

        /**
         * The items that were received from the server.
         */
        private readonly List<MerchantItem> _items;


        public DialogMerchantMessageEventArgs(BinaryReader reader)
        {
            _title = reader.ReadString();
            _items = new List<MerchantItem>();

            int entriesSell = reader.ReadByte();
            for (var i = 0; i < entriesSell; i++)
            {
                var itemId = reader.ReadUInt16();
                var name = reader.ReadString();
                var itemValue = reader.ReadUInt32();
                var bundleSize = reader.ReadByte();

                _items.Add(new MerchantItem(i, MerchantTradeType.Selling, itemId, name, itemValue, bundleSize));
            }

            int entriesBuyPrimary = reader.ReadByte();
            for (var i = 0; i < entriesBuyPrimary; i++)
            {
                var itemId = reader.ReadUInt16();
                var name = reader.ReadString();
                var itemValue = reader.ReadUInt32();

                _items.Add(new MerchantItem(i, MerchantTradeType.BuyingPrimary, itemId, name, itemValue));
            }

            int entriesBuySecondary = reader.ReadByte();
            for (var i = 0; i < entriesBuySecondary; i++)
            {
                var itemId = reader.ReadUInt16();
                var name = reader.ReadString();
                var itemValue = reader.ReadUInt32();

                _items.Add(new MerchantItem(i, MerchantTradeType.BuyingSecondary, itemId, name, itemValue));
            }

            _dialogId = reader.Read();
        }

        // public ServerReplyResult Execute() {
        //        if ((_title == null) || (_items == null)) {
        //          throw new NotDecodedException();
        //    }
        // TODO: No GuiUpdater.isGuiReady() required here?
        //  GuiUpdater.showMerchantDialog(_dialogId, _title, _items);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[DialogMerchantMessage ID: " + _dialogId + " TITLE: " + _title +
            " Items: " + (_items == null ? "0" : _items.Count.ToString()) + "]";
        }
    }
}