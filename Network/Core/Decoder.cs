using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Illarion.Common.Character;
using Illarion.Network.Core.Interfaces;
using Illarion.Network.Core.Utility;

namespace Illarion.Network.Core
{
    internal sealed class Decoder : IDecoder
    {

        private readonly CancellationTokenSource _shutdownToken;
        private readonly NetworkStream _stream;
        private readonly IMessageSink _sink;
        private readonly Encoding _encoding;

        private byte[] _receiveBuffer;

        internal Decoder(NetworkStream stream, IMessageSink sink)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (sink == null)
                throw new ArgumentNullException("sink");

            _stream = stream;
            _sink = sink;
            _encoding = Encoding.GetEncoding("ISO-8859-1");
            _shutdownToken = new CancellationTokenSource();

            _receiveBuffer = new byte[1000];

            ReceiveLoop();
        }

        private async void ReceiveLoop()
        {
            var token = _shutdownToken.Token;

            var bufferCursor = 0;
            while (true)
            {
                bufferCursor = await PopulateBuffer(bufferCursor, 6, token);

                var commandId = _receiveBuffer[0];
                var negCommandId = _receiveBuffer[1];

                if (commandId == (negCommandId ^ byte.MaxValue))
                {
                    //Command ID is properly matching
                    var length = ReadInt16(_receiveBuffer, 2);
                    var crc = ReadInt16(_receiveBuffer, 4);

                    EnsureBufferSize(6 + length);
                    bufferCursor = await PopulateBuffer(bufferCursor, 6 + length, token);

                    var resultCrc = Tools.CalculateCrc(_receiveBuffer, 6, length);
                    if (crc == resultCrc)
                    {
                        //Befehl ist gültig. Das geht an den Dekoder.
                        byte[] payload = new byte[length];
                        Array.Copy(_receiveBuffer, 6, payload, 0, length);
                        MemoryStream payloadStream = new MemoryStream(payload) {Position = 0};
                        PublishMessage(commandId, payloadStream);
                        bufferCursor = 0;
                    }
                }

                if (bufferCursor > 0)
                {
                    Array.ConstrainedCopy(_receiveBuffer, 1, _receiveBuffer, 0, bufferCursor - 1);
                }
            }
        }

        private static short ReadInt16(byte[] buffer, int offset)
        {
            var caster = new Caster
            {
                ByteValue2 = buffer[offset],
                ByteValue1 = buffer[offset + 1]
            };
            return caster.ShortValue1;
        }

        private async Task<int> PopulateBuffer(int cursor, int expected, CancellationToken token)
        {
            while (cursor < expected)
            {
                cursor += await _stream.ReadAsync(_receiveBuffer, cursor, expected - cursor, token);
            }

            return cursor;
        }

        private void EnsureBufferSize(int size)
        {
            if (_receiveBuffer.Length < size)
            {
                Array.Resize(ref _receiveBuffer, size);
            }
        }

        private async void PublishMessage(byte id, Stream payload)
        {
            try
            {
                await Task.Run(() => _sink.ProcessMessage(this, id, payload));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception received from message sink: " + ex.Message);
            }
        }

        public void Shutdown()
        {
            _shutdownToken.Cancel();
        }

        public string ReadString(Stream stream)
        {
            var length = Convert.ToInt32(ReadInt16(stream));
            var buffer = new byte[length];
            while (length > 0)
            {
                length -= stream.Read(buffer, 0, length);
            }
            return _encoding.GetString(buffer);
        }

        public byte ReadByte(Stream stream)
        {
            return Convert.ToByte(stream.ReadByte());
        }

        public short ReadInt16(Stream stream)
        {
            var caster = new Caster
            {
                ByteValue2 = Convert.ToByte(stream.ReadByte()),
                ByteValue1 = Convert.ToByte(stream.ReadByte())
            };
            return caster.ShortValue1;
        }

        public CharacterId ReadCharacterId(Stream stream)
        {
            var caster = new Caster
            {
                ByteValue4 = Convert.ToByte(stream.ReadByte()),
                ByteValue3 = Convert.ToByte(stream.ReadByte()),
                ByteValue2 = Convert.ToByte(stream.ReadByte()),
                ByteValue1 = Convert.ToByte(stream.ReadByte())
            };
            return caster.UIntegerValue;
        }

        public Coordinate ReadLocation(Stream stream)
        {
            var x = ReadInt16(stream);
            var y = ReadInt16(stream);
            var z = ReadInt16(stream);
            return new Coordinate(x, y, z);
        }
    }
}