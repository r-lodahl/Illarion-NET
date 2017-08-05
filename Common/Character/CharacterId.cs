using System;
using System.Diagnostics;

namespace Illarion.Common.Character
{
    [DebuggerDisplay("{ToString()}", Name = "Character ID")]
    public struct CharacterId : IComparable, IComparable<CharacterId>
    {
        private readonly uint _id;

        public CharacterId(uint id)
        {
            _id = id;
        }

        #region "IComparable/IComparable(of )"

        public int CompareTo(object obj)
        {
            if (obj is CharacterId)
            {
                return CompareTo((CharacterId) obj);
            }
            return 1;
        }

        public int CompareTo(CharacterId other)
        {
            return _id.CompareTo(other._id);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is CharacterId)) return false;

            var charId = (CharacterId) obj;
            return charId._id == _id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        //TODO: WHY?

        #region "Operators"

        public static implicit operator uint(CharacterId id)
        {
            return id._id;
        }

        public static implicit operator CharacterId(uint id)
        {
            return new CharacterId(id);
        }

        public static bool operator ==(CharacterId first, CharacterId second)
        {
            return first._id == second._id;
        }

        public static bool operator !=(CharacterId first, CharacterId second)
        {
            return first._id != second._id;
        }

        public static bool operator <(CharacterId first, CharacterId second)
        {
            return first._id < second._id;
        }

        public static bool operator >(CharacterId first, CharacterId second)
        {
            return first._id > second._id;
        }

        public static bool operator <=(CharacterId first, CharacterId second)
        {
            return first._id <= second._id;
        }

        public static bool operator >=(CharacterId first, CharacterId second)
        {
            return first._id >= second._id;
        }

        #endregion
    }
}