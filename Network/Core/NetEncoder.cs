using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Illarion.Common.Character;
using Illarion.Common.Internal.Serialization;
using Illarion.Network.Core.Interfaces;
using Illarion.Network.Core.Utility;

namespace Illarion.Network.Core
{
    /// <summary>
    /// Encodes in BigEndian
    /// </summary>
    internal sealed class NetEncoder : IEncoder, IAsyncTransmitter
    {

        private readonly NetworkStream _stream;

        private readonly Encoding _encoding;

        public static int MaxStringLength
        {
            get { return ushort.MaxValue; }
        }

        internal NetEncoder(NetworkStream stream)
        {
            _stream = stream;
            _encoding = Encoding.GetEncoding("ISO-8859-1");
        }

        public void Encode(string value, Stream stream)
        {
            var byteString = _encoding.GetBytes(value);
            var length = Math.Min(MaxStringLength, byteString.Length);
            Encode(Convert.ToUInt16(length), stream);
            stream.Write(byteString, 0, byteString.Length);
        }

        public void Encode(byte value, Stream stream)
        {
            stream.WriteByte(value);
        }

        public void Encode(ushort value, Stream stream)
        {
            var caster = new Caster {UShortValue1 = value};
            var buffer = new byte[3];
            buffer[0] = caster.ByteValue2;
            buffer[1] = caster.ByteValue1;
            stream.Write(buffer, 0, 2);
        }

        public void Encode(short value, Stream stream)
        {
            var caster = new Caster {ShortValue1 = value};
            var buffer = new byte[3];
            buffer[0] = caster.ByteValue2;
            buffer[1] = caster.ByteValue1;
            stream.Write(buffer, 0, 2);
        }

        public void Encode(uint value, Stream stream)
        {
            var caster = new Caster {UIntegerValue = value};
            var buffer = new byte[4];
            buffer[0] = caster.ByteValue4;
            buffer[1] = caster.ByteValue3;
            buffer[2] = caster.ByteValue2;
            buffer[3] = caster.ByteValue1;
            stream.Write(buffer, 0, 4);
        }

        public void Encode(int value, Stream stream)
        {
            var caster = new Caster {IntegerValue = value};
            var buffer = new byte[4];
            buffer[0] = caster.ByteValue4;
            buffer[1] = caster.ByteValue3;
            buffer[2] = caster.ByteValue2;
            buffer[3] = caster.ByteValue1;
            stream.Write(buffer, 0, 4);
        }

        public void Encode(CharacterId value, Stream stream)
        {
            Encode(Convert.ToUInt32(value), stream);
        }

        public void Encode(Coordinate value, Stream stream)
        {
            Encode(Convert.ToUInt16(value.X), stream);
            Encode(Convert.ToUInt16(value.Y), stream);
            Encode(Convert.ToUInt16(value.Z), stream);
        }

        public Task SendCommandAsync(byte commandId, MemoryStream payload)
        {
            var payloadArray = payload.ToArray();
            return SendCommandAsync(commandId, payloadArray, 0, payloadArray.Length);
        }

        public async Task SendCommandAsync(byte commandId, byte[] payload, int offset, int length)
        {
            var buffer = new byte[length + 6];
            buffer[0] = commandId;
            buffer[1] = (byte) (commandId ^ byte.MaxValue);
            EncodeToBuffer(Convert.ToUInt16(length), buffer, 2);
            EncodeToBuffer(Tools.CalculateCrc(payload, offset, length), buffer, 4);
            Array.Copy(payload, offset, buffer, 6, length);
            await _stream.WriteAsync(buffer, 0, buffer.Length);
            await _stream.FlushAsync();
        }

        private static void EncodeToBuffer(short value, byte[] buffer, int offset)
        {
            var caster = new Caster {ShortValue1 = value};
            buffer[offset] = caster.ByteValue2;
            buffer[offset + 1] = caster.ByteValue1;
        }

        private static void EncodeToBuffer(ushort value, byte[] buffer, int offset)
        {
            var caster = new Caster {UShortValue1 = value};
            buffer[offset] = caster.ByteValue2;
            buffer[offset + 1] = caster.ByteValue1;
        }

        public void EncodePassword(string value, Stream stream)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (stream == null)
                throw new ArgumentNullException("stream");

            Encode(Tools.EncryptPassword(value, "illarion", "$1$"), stream);
        }

        public Task SendCommandAsync(byte commandId)
        {
            return SendCommandAsync(commandId, new byte[0], 0, 0);
        }
    }
}