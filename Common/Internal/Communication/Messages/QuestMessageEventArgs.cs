using System;
using System.Collections.Generic;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class QuestMessageEventArgs : EventArgs
    {
        /**
         * The ID of the quest.
         */
        private readonly ushort _questId;

        /**
         * The title of the quest.
         */

        private readonly string _title;

        /**
         * The description text of the quests current state.
         */

        private readonly string _description;

        /**
         * The flag if this quest is already finished.
         */
        private readonly bool _finished;

        /**
         * The target locations where the next steps of the quest will happen.
         */

        private readonly List<Coordinate> _targetLocations;


        public QuestMessageEventArgs(BinaryReader reader)
        {
            _questId = reader.ReadUInt16();
            _title = reader.ReadString();
            _description = reader.ReadString();
            _finished = reader.ReadSByte() == 1;

            int count = reader.ReadByte();

            _targetLocations = new List<Coordinate>(count);
            for (var i = 0; i < count; i++)
            {
                _targetLocations.Add(new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16()));
            }
        }

        // public ServerReplyResult Execute() {
        //if ((_title == null) || (_description == null) || (_targetLocations == null)) {
        //  throw new NotDecodedException();
        //}

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //}

        //GuiUpdater.addQuest(_questId, _title, _description, _finished, _targetLocations);
        // return ServerReplyResult.Success;
        //}
        
        public override string ToString()
        {
            return "[QuestMessage Quest-Id: " + _questId + " Title: " + _title + "]";
        }
    }
}
