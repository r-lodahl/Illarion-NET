using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class OpenBagCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Default constructor for the open bag command.
         */
        public OpenBagCommandEventArgs() : base(Command.CmdOpenBag)
        {

        }

        /**
         * Encode the data of this open bag command and put the values into the buffer.
         *
         * @param writer the interface that allows writing data to the network communication system
         */

        public override void Encode(IEncoder encoder, Stream stream)
        {
            // nothing
        }

        /**
         * Get the data of this open bag command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[OpenBagCommand]";
        }
    }
}
