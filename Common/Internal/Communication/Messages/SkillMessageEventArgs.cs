using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class SkillMessageEventArgs : EventArgs
    {
        /**
         * The current minor skill points of that skill.
         */
        private readonly ushort _minor;

        /**
         * The ID of the skill that is used
         */
        private readonly byte _skill;

        /**
         * The new value of the skill.
         */
        private readonly ushort _value;


        public SkillMessageEventArgs(BinaryReader reader)
        {
            _skill = reader.ReadByte();
            _value = reader.ReadUInt16();
            _minor = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
//        if (!GuiUpdater.isGuiReady()) {
        // return ServerReplyResult.Reschedule;
        //      }

        //    if (LocalPlayerUpdater.updateSkillValue(_skill, _value, _minor)) {
        // return ServerReplyResult.Success;
        //  }

        //Log.warn("Unknown skill received! ID: {}", _skill);
        // return ServerReplyResult.Failed;
        //}

        public override string ToString()
        {
            return "[SkillMessage Skill: " + _skill + " Value: " + _value + " Minor: " + _minor + "]";
        }
    }
}
