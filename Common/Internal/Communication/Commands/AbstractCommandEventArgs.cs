using System;
using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Common.Internal.Communication.Commands
{

    /// <summary>
    /// Base class for all other Network-Based EventArgs.
    /// We could remove this class and turn _commandId into an static field.
    /// However this would not save any space, and we would still need an interface for methods like Encode
    /// </summary>
    [ImmutableObject(true)]
    public abstract class AbstractCommandEventArgs : EventArgs {
       
        public Command Command { get; private set; }

        protected AbstractCommandEventArgs(Command command) {
            Command = command;
        }
        
        public abstract override string ToString();

        public abstract void Encode(IEncoder encoder, Stream stream);
    }
}
