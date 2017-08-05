using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Illarion.Common.Internal.Serialization;

namespace Illarion.Network.Core.Interfaces
{
    public abstract class Connection
    {
        private IDecoder _decoder;
        public byte ProtocolVersion { get; private set; }
        public string HostName { get; private set; }
        public int Port { get; private set; }


        public bool IsConnected
        {
            get { return TcpClient.Connected; }
        }

        protected TcpClient TcpClient { get; private set; }
        protected IEncoder Encoder { get; private set; }
        protected IAsyncTransmitter Transmitter { get; private set; }


        private readonly IMessageSink _messageSink;

        protected Connection(string hostName, int port, byte protocolVersion, IMessageSink messageSink)
        {
            if (hostName == null)
                throw new ArgumentNullException("hostName");
            if (string.IsNullOrWhiteSpace(hostName))
                throw new ArgumentException("Host cannot be white-space only.");
            if (port < IPEndPoint.MinPort)
                throw new ArgumentOutOfRangeException("port", port,
                    string.Format("Port cannot be less then {0}", IPEndPoint.MinPort));
            if (port > IPEndPoint.MaxPort)
                throw new ArgumentOutOfRangeException("port", port,
                    string.Format("Port cannot be greater then {0}", IPEndPoint.MaxPort));

            HostName = hostName;
            Port = port;
            ProtocolVersion = protocolVersion;
            _messageSink = messageSink;

            TcpClient = new TcpClient();
        }

        public virtual async Task ConnectAsync()
        {
            if (TcpClient.Connected)
                throw new InvalidOperationException("Connect was already called.");

            await TcpClient.ConnectAsync(HostName, Port);

            switch (ProtocolVersion)
            {
                case 200:
                    var stream = TcpClient.GetStream();
                    var encoder = new NetEncoder(stream);
                    Encoder = encoder;
                    Transmitter = encoder;
                    _decoder = new Decoder(stream, _messageSink);
                    break;
            }
        }
    }
}