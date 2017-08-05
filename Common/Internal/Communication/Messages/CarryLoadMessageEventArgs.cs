using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class CarryLoadMessageEventArgs : EventArgs
    {
        /**
         * The load the character currently carries.
         */
        private readonly ushort _currentLoad;

        /**
         * The load the character is maximal able to carry.
         */
        private readonly ushort _maximumLoad;


        public CarryLoadMessageEventArgs(BinaryReader reader)
        {
            _currentLoad = reader.ReadUInt16();
            _maximumLoad = reader.ReadUInt16();
        }

        //// public ServerReplyResult Execute() {
        //     EntityUpdater.updatePlayerLoad(_currentLoad, _maximumLoad);
        //     // return ServerReplyResult.Success;
        //}
        public override string ToString()
        {
            return "[CarryLoadMessage Current: " + _currentLoad + " Max:" + _maximumLoad + "]";
        }
    }
}