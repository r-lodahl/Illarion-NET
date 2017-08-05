using System;
using System.IO;
using Illarion.Common.UiHelper;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class LookAtMapItemMessageEventArgs : EventArgs
    {
        /**
         * The location of the tile on the server map.
         */
        private readonly Coordinate _location;

        /**
     * The position of the referenced item.
     */
        private readonly byte _stackPosition;

        /**
         * The tooltip that is displayed for the item on the specified location.
         */

        private readonly Tooltip _tooltip;


        public LookAtMapItemMessageEventArgs(BinaryReader reader)
        {
            _location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            _stackPosition = reader.ReadByte();

            // The sequence of the decoding is important!
            _tooltip = new Tooltip(
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadByte() == 1,
                reader.ReadUInt16(),
                reader.ReadUInt32(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()
            );
        }
        // public ServerReplyResult Execute() {
        //   if (_tooltip == null) {
        //     throw new NotDecodedException();
        //}

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.showItemToolTip(_locationX, _locationY, _locationZ, _stackPosition, _tooltip);
        // return ServerReplyResult.Success;
        // }

        public override string ToString()
        {
            return "[LookAtMapItemMessage Location: (" + _location + ") Tooltip: " + _tooltip + "]";
        }
    }
}
