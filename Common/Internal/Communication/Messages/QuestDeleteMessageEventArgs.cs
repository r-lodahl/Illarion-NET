using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class QuestDeleteMessageEventArgs : EventArgs
    {
        /**
         * The ID of the quest.
         */
        private readonly ushort _questId;


        public QuestDeleteMessageEventArgs(BinaryReader reader)
        {
            _questId = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
//        if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //      }

        //    GuiUpdater.removeQuest(_questId);
        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[QuestDeleteMessage Quest-Id: " + _questId + "]";
        }
    }
}
