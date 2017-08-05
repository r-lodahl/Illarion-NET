using System;
using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;
using JetBrains.Annotations;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class SayCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The text that is send to the server.
         */
        [NotNull] private readonly string _text;

        /**
         * Default constructor for the say text command.
         */
        public SayCommandEventArgs(int mode, [NotNull] string text) : base(GetCommandId(mode))
        {
            _text = text;
        }

        /**
         * Get the fitting command ID according to the speech mode.
         *
         * @param mode the speech mode
         * @return the command id
         * @throws IllegalArgumentException in case {@code mode} is not {@link SpeechMode#Normal} or
         * {@link SpeechMode#Shout} or {@link SpeechMode#Whisper}
         */
        private static Command GetCommandId(int mode)
        {
            switch (mode)
            {
                case 0:
                    return Command.CmdSay;
                case 1:
                    return Command.CmdShout;
                case 2:
                    return Command.CmdWhisper;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_text);
        }

        public override string ToString()
        {
            return "[SayCommand Text: " + _text + "]";
        }
    }
}
