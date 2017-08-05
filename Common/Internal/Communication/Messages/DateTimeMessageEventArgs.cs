using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class DateTimeMessageEventArgs : EventArgs
    {
        /**
         * Day of the current IG time.
         */
        private readonly byte _day;

        /**
         * Hour of the current IG time.
         */
        private readonly byte _hour;

        /**
         * Minute of the current IG time.
         */
        private readonly byte _minute;

        /**
         * Month of the current IG time.
         */
        private readonly byte _month;

        /**
         * Year of the current IG time.
         */
        private readonly ushort _year;


        public DateTimeMessageEventArgs(BinaryReader reader)
        {
            _hour = reader.ReadByte();
            _minute = reader.ReadByte();
            _day = reader.ReadByte();
            _month = reader.ReadByte();
            _year = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        // GameUpdater.setDateTime(_year, _month, _day, _hour, _minute);
        // return ServerReplyResult.Success;
//    }

        public override string ToString()
        {
            return "[DateTimeMessage " + string.Format("Date: {0:D}/{1:D}/{2:D} - Time: {3:D}/{4:D}/{5:D}", _month, _day, _year, _hour, _minute) + "]";
        }
    }
}
