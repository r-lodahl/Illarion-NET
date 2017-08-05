using System;

namespace Illarion.Common.Internal.Communication.Messages
{
    [Serializable]
    public class NotDecodedException : Exception
    {
        public NotDecodedException()
        {
        }

        public NotDecodedException(string message) : base(message)
        {
        }

        public NotDecodedException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
