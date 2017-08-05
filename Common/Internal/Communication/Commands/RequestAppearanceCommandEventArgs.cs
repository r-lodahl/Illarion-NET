using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class RequestAppearanceCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The ID of the characters who's appearance is needed.
         */
        private readonly int _charId;

        /**
         * Default constructor for the request appearance command.
         *
         * @param characterId the ID of the character to request the appearance from
         */
        public RequestAppearanceCommandEventArgs(int characterId) : base(Command.CmdRequestAppearance)
        {
            _charId = characterId;
        }


        public override void Encode(IEncoder encoder, Stream stream)
        {
            //writer.Write(_charId);
        }

        public override string ToString()
        {
            return "[RequestAppearanceCommand CharId: " + _charId + "]";
        }
    }
}
