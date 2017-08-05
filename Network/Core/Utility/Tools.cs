using System;
using System.Security.Cryptography;
using System.Text;

namespace Illarion.Network.Core.Utility
{
    internal static class Tools
    {

        private static readonly string IllaBase64 = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        internal static short CalculateCrc(byte[] payload, int offset, int length)
        {
            var caster = new Caster {IntegerValue = 0};
            for (var i = offset; i <= offset + length - 1; i++)
            {
                caster.IntegerValue = Convert.ToInt32(caster.ShortValue1) + payload[i];
            }
            return caster.ShortValue1;
        }

        internal static string EncryptPassword(string password, string salt, string magic)
        {
            if (password == null)
                throw new ArgumentNullException("password"); //C# 4 does not support "nameof()"
            if (salt == null)
                throw new ArgumentNullException("salt");
            if (magic == null)
                throw new ArgumentNullException("magic");

            var cleanSalt = GetCleanedSalt(salt, magic);

            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var passwordBytes = encoding.GetBytes(password);
            var saltBytes = encoding.GetBytes(cleanSalt);
            var magicBytes = encoding.GetBytes(magic);

            var encPasswordBytes = EncryptPassword(passwordBytes, saltBytes, magicBytes);

            return magic + salt + '$' + ToBase64String(encPasswordBytes);
        }

        private static string ToBase64String(byte[] bytes)
        {
            var base64 = new StringBuilder();
            for (var i = 0; i <= 3; i++)
            {
                AppendTo64(base64,
                    (Convert.ToInt32(bytes[i]) << 16) | (Convert.ToInt32(bytes[i + 6]) << 8) | bytes[i + 12], 4);
            }
            AppendTo64(base64, (Convert.ToInt32(bytes[4]) << 16) | (Convert.ToInt32(bytes[10]) << 8) | bytes[5], 4);
            AppendTo64(base64, bytes[11], 2);
            return base64.ToString();
        }

        private static void AppendTo64(StringBuilder builder, int value, int size)
        {
            var currentValue = value;
            for (var i = 0; i <= size - 1; i++)
            {
                builder.Append(IllaBase64[currentValue & 0x3f]);
                currentValue >>= 6;
            }
        }

        private static byte[] EncryptPassword(byte[] password, byte[] salt, byte[] magic)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (salt == null)
                throw new ArgumentNullException("salt");
            if (magic == null)
                throw new ArgumentNullException("magic");

            var hashProvider = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
            hashProvider.AppendData(password);
            hashProvider.AppendData(salt);
            hashProvider.AppendData(password);
            var currentHash = hashProvider.GetHashAndReset();

            hashProvider.AppendData(password);
            hashProvider.AppendData(magic);
            hashProvider.AppendData(salt);

            for (var length = password.Length; length >= 1; length += -16)
            {
                hashProvider.AppendData(currentHash, 0, Math.Min(length, 16));
            }

            Array.Clear(currentHash, 0, currentHash.Length);

            var i = password.Length;
            while (i != 0)
            {
                hashProvider.AppendData((i & 1) == 0 ? password : currentHash, 0, 1);
                i >>= 1;
            }

            var currentEncPassword = hashProvider.GetHashAndReset();

            for (i = 0; i <= 999; i++)
            {
                if ((i & 1) == 0)
                {
                    hashProvider.AppendData(currentEncPassword, 0, 16);
                }
                else
                {
                    hashProvider.AppendData(password);
                }

                if ((i % 3) != 0)
                {
                    hashProvider.AppendData(salt);
                }

                if ((i % 7) != 0)
                {
                    hashProvider.AppendData(password);
                }

                if ((i & 1) == 0)
                {
                    hashProvider.AppendData(password);
                }
                else
                {
                    hashProvider.AppendData(currentEncPassword, 0, 16);
                }

                currentEncPassword = hashProvider.GetHashAndReset();
            }

            return currentEncPassword;
        }

        private static string GetCleanedSalt(string salt, string magic)
        {
            if (salt == null)
                throw new ArgumentNullException("salt");
            if (magic == null)
                throw new ArgumentNullException("magic");

            var cleanedSalt = salt.StartsWith(magic) ? salt.Substring(magic.Length) : salt;

            var saltTerminatorIndex = cleanedSalt.IndexOf('$');
            if (saltTerminatorIndex != -1)
            {
                cleanedSalt = cleanedSalt.Substring(0, saltTerminatorIndex);
            }
            if (cleanedSalt.Length > 8)
            {
                cleanedSalt = cleanedSalt.Substring(0, 8);
            }
            return cleanedSalt;
        }
    }
}