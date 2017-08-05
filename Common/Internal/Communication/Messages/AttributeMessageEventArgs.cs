using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class AttributeMessageEventArgs : EventArgs
    {

        /**
         * The ID of the character this attribute update is related to.
         */
        private readonly int _targetCharacter;

        /**
         * The name of the received attribute.
         */
        private readonly string _attribute;

        /**
         * The value of the received attribute.
         */
        private readonly ushort _value;


        public AttributeMessageEventArgs(BinaryReader reader)
        {
            _targetCharacter = reader.Read();
            _attribute = reader.ReadString();
            _value = reader.ReadUInt16();
        }

        // public ServerReplyResult Execute() {
        //noinspection ConstantConditions

//        if (EntityUpdater.checkExistence(_targetCharacter)) {
        //          if (EntityUpdater.updateAttribute(_targetCharacter, _attribute, _value)) {
        // return ServerReplyResult.Success;
        //        } else {
        //          Log.error("Failed to match {} to any existing attribute.", _attribute);
        // return ServerReplyResult.Failed;
        //    }
        //} else { // Check if local player has his id loaded, in case it was a player update
        //  if (!LocalPlayerUpdater.isIdKnown()) {
        // return ServerReplyResult.Reschedule;
        // }

        // Log.error("Received a attribute update for character {}, but this character is not around.", _targetCharacter);
        // return ServerReplyResult.Failed;
        //}
//    }

        public override string ToString()
        {
            return "[AttributeMessage chardId: " + _targetCharacter + " attribute: " + _attribute + " New value: " +
                   _value + "]";
        }
    }
}
