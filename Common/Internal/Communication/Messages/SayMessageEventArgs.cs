using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class SayMessageEventArgs : EventArgs
    {
        /**
         * The location the text was spoken at.
         */
        private readonly Coordinate _location;

        /**
     * The text that was actually spoken.
     */

        private readonly string _text;


        public SayMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _text = reader.ReadString();
        }

        // public ServerReplyResult Execute() {
        // if (_text == null) {
        //   throw new NotDecodedException();
        //}

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.handleMessage(_text, GuiUpdater.SpeechMode.NORMAL, _locationX, _locationY, _locationZ);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[SayMessage Location: (" + _location + ") Text: " + _text + "]";
        }
    }
}
