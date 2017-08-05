using System.ComponentModel;
using System.IO;
using Illarion.Common.Internal.Serialization;
using JetBrains.Annotations;

namespace Illarion.Common.Internal.Communication.Commands
{
    [ImmutableObject(true)]
    public class LoginCommandEventArgs : AbstractCommandEventArgs
    {
        /**
         * The name of the character that shall log in.
         */
        [NotNull] private readonly string _charName;

        /**
         * The account password that is used. This contains the plain text password.
         */
        [NotNull] private readonly string _password;
        
        /**
         * Default constructor for the login command.
         *
         * @param charName the name of the character to login with
         * @param password the password used to login
         * @param version the version of the client to report to the server
         */
        public LoginCommandEventArgs([NotNull] string charName, [NotNull] string password) : base(Command
            .CmdLogin)
        {
            _charName = charName;
            _password = password;
        }

        public void Encode(IEncoder encoder, Stream stream, byte version)
        {
            encoder.Encode(version, stream);
            encoder.Encode(_charName, stream);
            encoder.EncodePassword(_password, stream);
        }

        /// <summary>
        /// Use Encode(IEncoder, Stream, byte) instead.
        /// </summary>
        /// <param name="encoder"></param>
        /// <param name="stream"></param>
        public override void Encode(IEncoder encoder, Stream stream)
        {
            encoder.Encode((byte)0, stream);
            encoder.Encode(_charName, stream);
            encoder.EncodePassword(_password, stream);
        }

        public override string ToString()
        {
            return "[LoginCommand Char: " + _charName + "]";
        }
    }
}