using System.IO;
using Illarion.Common.Map;
using UnityEngine;

public struct Coordinate
{
    private short _x;
    private short _y;
    private readonly short _z;

    public short X { get { return _x; } }
    public short Y { get { return _y; } }
    public short Z { get { return _z; } }

    public Coordinate(short x, short y, short z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public Coordinate(BinaryReader reader)
    {
        _x = reader.ReadInt16();
        _y = reader.ReadInt16();
        _z = reader.ReadInt16();
    }

    public void Encode(BinaryWriter writer)
    {
        //writer.Write(_x);
        //writer.Write(_y);
        //writer.Write(_z);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Coordinate)) return false;
        var coordinate = (Coordinate) obj;
        return coordinate.X == X && coordinate.Y == Y && coordinate.Z == Z;
    }

    public override int GetHashCode()
    {
        var hash = 31;
        hash = hash * 23 + X;
        hash = hash * 23 + Y;
        return hash * 23 + Z;
    }

    /// <summary>
    /// Increments X value of the Location by 1.
    /// This changes the hash-value of the class, so dont use it in hashed environments
    /// </summary>
    public void IncrementX()
    {
        _x++;
    }

    /// <summary>
    /// Increments Y value of the Location by 1.
    /// This changes the hash-value of the class, so dont use it in hashed environments
    /// </summary>
    public void IncrementY()
    {
        _y++;
    }

    /// <summary>
    /// Decrements X value of the Location by 1.
    /// This changes the hash-value of the class, so dont use it in hashed environments
    /// </summary>
    public void DecrementX()
    {
        _x--;
    }

    /// <summary>
    /// Decrements Y value of the Location by 1.
    /// This changes the hash-value of the class, so dont use it in hashed environments
    /// </summary>
    public void DecrementY()
    {
        _y--;
    }

    public Direction GetDirection(Coordinate target)
    {
        return GetDirection(this, target);
    }

    public static Direction GetDirection(Coordinate origin, Coordinate target)
    {
        var dX = origin.X - target.X;
        var dY = origin.Y - target.Y;

        if (dX == 0 && dY == 0) return null;

        var theta = Mathf.Atan2(dY, dX) + Mathf.PI;
        const float part = Mathf.PI / 8;

        if (theta < part)
        {
            return Direction.East;
        }
        if (theta < 3 * part)
        {
            return Direction.SouthEast;
        }
        if (theta < 5 * part) {
            return Direction.South;
        }
        if (theta < 7 * part)
        {
            return Direction.SouthWest;
        }
        if (theta < 9 * part)
        {
            return Direction.West;
        }
        if (theta < 11 * part)
        {
            return Direction.NorthWest;
        }
        if (theta < 13 * part)
        {
            return Direction.North;
        }
        return theta < 15 * part ? Direction.NorthEast : Direction.East;
    }

    public override string ToString()
    {
        return string.Format("[Coordinate {0}, {1}, {2}]", X, Y, Z);
    }
}