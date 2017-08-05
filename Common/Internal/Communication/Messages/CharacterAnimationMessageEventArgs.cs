using System;
using System.IO;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class CharacterAnimationMessageEventArgs : EventArgs
    {

        /**
         * The ID of the animation that is shown.
         */
        private readonly byte _animationId;

        /**
         * The ID of the character that is animated.
         */

        private readonly int _charId;


        public CharacterAnimationMessageEventArgs(BinaryReader reader)
        {
            _charId = reader.Read();
            _animationId = reader.ReadByte();
        }


        // public ServerReplyResult Execute()
        //{
            // GameUpdater.playCharacterAnimation(_charId, _animationId);
            // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[CharacterAnimationMessage charId: " + _charId + " Animation ID: " + _animationId + "]";
        }
    }
}
