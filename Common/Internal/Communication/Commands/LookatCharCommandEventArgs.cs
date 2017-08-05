using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LookatCharCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * Mode for looking in a polite way at a character. That leads to the point
         * that the character you are looking at gets no message but you get only
         * limited information.
         */
        //public static int LOOKAT_POLITE = 0;
        //TODO: Is LOOKAT_POLITE, LOOKAT_STARE needed?
        /**
         * Staring at a character, leads to a message for the character you are
         * staring at. But this way you get far more information then by looking in
         * a polite way.
         */
        //public static int LOOKAT_STARE = 1;

        /**
         * The ID of the character we are looking at.
         */
        private int _charId;

        /**
         * The mode that is used to look at the character. So looking in a normal
         * way at the character or staring at it. Possible values are
         * {@link #LOOKAT_POLITE} and {@link #LOOKAT_STARE}.
         */
        private sbyte _mode;

        /**
         * Default constructor for the look at character command.
         */
        public LookatCharCommandEventArgs() : base(Command.CmdLookatChar)
        {
            
        }

        /**
         * Encode the data of this look at character command and put the values into
         * the buffer.
         *
         * @param writer the interface that allows writing data to the network
         * communication system
         */
        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_charId);
            //writer.Write(_mode);
        }

        /**
         * Set the target of the look at and the way the look at is done.
         *
         * @param lookAtCharId the ID of the char we want to look at
         * @param lookAtMode the mode of the look at so the method used to look at
         * the target character
         */
        public void Examine(int lookAtCharId, int lookAtMode)
        {
            _charId = lookAtCharId;
            _mode = (sbyte) lookAtMode;
        }

        /**
         * Get the data of this look at character command as string.
         *
         * @return the data of this command as string
         */
        public override string ToString()
        {
            return "[LookatCharCommand + " + _charId + " mode: " + _mode + "]";
        }
    }
}
