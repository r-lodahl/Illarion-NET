using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class PickUpAllItemsCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Default constructor for the pickup all command.
         */
        public PickUpAllItemsCommandEventArgs() : base(Command.CmdPickUpAll)
        {

        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
        }

        public override string ToString()
        {
            return "[PickUpAllItemsCommand]";
        }
    }
}
