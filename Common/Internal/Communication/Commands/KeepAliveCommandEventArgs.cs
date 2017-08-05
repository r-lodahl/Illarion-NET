using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class KeepAliveCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Default constructor for the keep alive command.
         */
        public KeepAliveCommandEventArgs() : base(Command.CmdKeepalive)
        {
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
            //ConnectionPerformanceClock.notifyNetCommEncode();
        }

        public override string ToString()
        {
            return "[KeepAliveCommand]";
        }
    }
}
