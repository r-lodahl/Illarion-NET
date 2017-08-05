using System;
using System.Collections.Generic;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class QuestAvailabilityMessageEventArgs : EventArgs
    {

        /**
         * This array contains the available quests in range of the character.
         */

        private readonly List<Coordinate> _availableQuests;

        /**
         * This array contains the quests that become available to the player soon.
         */

        private readonly List<Coordinate> _availableSoonQuests;


        public QuestAvailabilityMessageEventArgs(BinaryReader reader)
        {
            Func<int, List<Coordinate>> decodeHelper = questCount =>
            {
                List<Coordinate> questList;
                if (questCount > 0)
                {
                    questList = new List<Coordinate>(questCount);
                    for (var i = 0; i < questCount; i++)
                    {
                        questList.Add(new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16()));
                    }
                }
                else
                {
                    questList = new List<Coordinate>();
                }
                return questList;
            };

            _availableQuests = decodeHelper(reader.ReadUInt16());
            _availableSoonQuests = decodeHelper(reader.ReadUInt16());
        }

        // public ServerReplyResult Execute() {
        //  if ((_availableQuests == null) || (_availableSoonQuests == null)) {
        //    throw new NotDecodedException();
        //}

        //if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
//        }

        /* It's possible that both lists contain the same entries or multiple times equal entries. */
        //      Collection<Coordinate> availableSoonQuestsSet = new HashSet<>(_availableSoonQuests);
        //    Collection<Coordinate> availableQuestsSet = new HashSet<>(_availableQuests);
        //  availableSoonQuestsSet.removeAll(availableQuestsSet);

        //MapUpdater.setQuestStartLocations(availableQuestsSet, availableSoonQuestsSet);

        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[QuestAvailabilityMessage Quests: " + _availableQuests + " SoonQuest: " + _availableSoonQuests +
                   "]";
        }
    }
}
