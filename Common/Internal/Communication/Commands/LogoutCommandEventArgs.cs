using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LogoutCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The default constructor of the logout command.
         */
        public LogoutCommandEventArgs() : base(Command.CmdLogoff)
        {
        }

        public override void Encode(IEncoder encoder, Stream stream)
        {
        }

        public override string ToString()
        {
            return "[LogoutCommand]";
        }
    }
}
