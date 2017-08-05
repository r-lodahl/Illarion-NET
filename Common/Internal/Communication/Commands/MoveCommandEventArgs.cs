using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;
using Illarion.Common.Map;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class MoveCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Byte flag for a simple move.
         */
        // TODO: Diese Variablen auslagern in den späteren MovementModeHandler
        public const byte ModeMove = 0x0B;

        /**
         * Byte flag for a pushing.
         */
        public const byte ModePush = 0x0C;

        /**
         * Byte flag for a running move.
         */
        public const byte ModeRun = 0x0D;

        /**
         * The character ID of the char that shall move.
         */
        private readonly int _charId;

        /**
         * The direction the character moves to.
         */
        private readonly Direction _direction;

        /**
         * Set the movement type. Possible values are {@link #MODE_MOVE} and
         * {@link #MODE_PUSH}.
         */
        private readonly sbyte _mode;

        /**
         * Default constructor for the move command.
         */
        public MoveCommandEventArgs(int charId, int movementMode, Direction direction) : base(Command.CmdMove)
        {
            _charId = charId;
            _direction = direction;
            _mode = (sbyte) movementMode;

            //We assume that we save movementMode also on clientside as byte
            // TODO: Check this!

            /*switch (movementMode) {
                case Walk:
                    this.mode = MODE_MOVE;
                    break;
                case Run:
                    this.mode = MODE_RUN;
                    break;
                case Push:
                    this.mode = MODE_PUSH;
                    break;
                default:
                    throw new IllegalArgumentException("Invalid move mode!");
            }*/
        }

        /**
         * Encode the data of this move command and put the values into the buffer.
         *
         * @param writer the interface that allows writing data to the network
         * communication system
         */
        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_charId);
            //_direction.Encode(writer);
            //writer.Write(_mode);
        }

        /**
         * Get the data of this move command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[MoveCommand + " + _charId + " Direction: " + _direction + " Mode: " + _mode + "]";
        }
    }
}