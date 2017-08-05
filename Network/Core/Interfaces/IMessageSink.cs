using System.IO;

namespace Illarion.Network.Core.Interfaces
{
    public interface IMessageSink
    {
        void ProcessMessage(IDecoder decoder, byte id, Stream payload);
    }
}