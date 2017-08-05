using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class InformMessageEventArgs : EventArgs
    {

        /**
         * The type of the inform.
         */
        private readonly byte _informType;

        /**
         * The text of the inform.
         */

        private readonly string _informText;


        public InformMessageEventArgs(BinaryReader reader)
        {
            _informType = reader.ReadByte();
            _informText = reader.ReadString();
        }

        // public ServerReplyResult Execute() {
        //       if (_informText == null) {
        //         throw new NotDecodedException();
        //   }

        // if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.displayInform(_informType, _informText);

        // return ServerReplyResult.Success;
        //}

        //[NotNull]


        public override string ToString()
        {
            return "[InformMessage Message: " + _informText + "]";
        }
    }
}
