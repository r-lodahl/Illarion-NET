using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class AttackCommandEventArgs : AbstractCommandEventArgs {
        private readonly int _charId;

        public AttackCommandEventArgs(int targetCharId) : base(Command.CmdAttack) {
            _charId = targetCharId;
        }
        
        public override void Encode(IEncoder encoder, Stream stream) {
            //writer.Write(_charId);
        }

        public override string ToString()
        {
            return string.Format("[Attack-Command, Target {0}]", _charId);
        }
    }
}
