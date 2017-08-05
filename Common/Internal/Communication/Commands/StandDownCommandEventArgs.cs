using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class StandDownCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The default constructor of the stand down command.
         */
        public StandDownCommandEventArgs() : base(Command.CmdStandDown)
        {
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
        }

        public override string ToString()
        {
            return "[StandDownCommand]";
        }
    }
}
