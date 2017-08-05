using System.IO;
using System.Threading.Tasks;

namespace Illarion.Network.Core.Interfaces
{
    public interface IAsyncTransmitter
    {
        Task SendCommandAsync(byte commandId);
        Task SendCommandAsync(byte commandId, MemoryStream payload);
        Task SendCommandAsync(byte commandId, byte[] payload, int offset, int length);
    }
}
