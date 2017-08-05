using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class NamePlayerCommandEventArgs : AbstractCommandEventArgs
    {
        private readonly int _playerId;

        private readonly string _customName;

        public NamePlayerCommandEventArgs(int playerId, string customName) : base(Command.CmdNamePlayer)
        {
            _playerId = playerId;
            _customName = customName;
        }

        /**
         * Encode the data of this command and put the values into the buffer.
         *
         * @param writer the interface that allows writing data to the network
         * communication system
         */
        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_playerId);
            //writer.Write(_customName);
        }

        public override string ToString()
        {
            return "[NamePlayerCommand playerId + " + _playerId + " is named: " + _customName + "]";
        }
    }
}
