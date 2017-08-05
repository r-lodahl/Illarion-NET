using System.ComponentModel;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class CloseDialogTradingCommandEventArgs : AbstractTradeItemCommandEventArgs {
        /**
     * The sub command ID for this command.
     */
        private const int SubCmdId = 0;

        /**
     * Default constructor for the close crafting dialog command.
     *
     * @param dialogId the ID of the dialog to close
     */
        public CloseDialogTradingCommandEventArgs(int dialogId) : base(dialogId, SubCmdId) {
        }
    }
}
