using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class IntroduceCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Default constructor for the introduce message.
         */
        public IntroduceCommandEventArgs() : base(Command.CmdIntroduce)
        {
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
        }

        public override string ToString()
        {
            return "[IntroduceCommand]";
        }
    }
}
