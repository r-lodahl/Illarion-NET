using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CloseShowcaseCommandEventArgs : AbstractCommandEventArgs {
        /**
     * The ID of the container.
     */
        private readonly byte _showcaseId;

        /**
     * Default constructor for the open bag command.
     *
     * @param showcaseId the ID of the showcase to close
     */
        public CloseShowcaseCommandEventArgs(int showcaseId) : base(Command.CmdCloseShowcase) {
            _showcaseId = (byte) showcaseId;
        }

        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_showcaseId);
        }

        public override string ToString() {
            return "[CloseShowcaseCommand Showcase: " + _showcaseId+"]";
        }
    }
}
