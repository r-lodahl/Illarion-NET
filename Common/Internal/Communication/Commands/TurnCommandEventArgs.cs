using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;
using Illarion.Common.Map;
using JetBrains.Annotations;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class TurnCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The direction the character is supposed to turn to.
         */
        [NotNull] private readonly Direction _direction;

        /**
         * Default constructor for the turn message.
         *
         * @param direction the direction to turn to
         */
        public TurnCommandEventArgs([NotNull] Direction direction) : base(Command.CmdTurn)
        {
            _direction = direction;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
           // _direction.Encode(writer);
        }

        public override string ToString()
        {
            return "[TurnCommand Direction: " + _direction + "]";
        }
    }
}
