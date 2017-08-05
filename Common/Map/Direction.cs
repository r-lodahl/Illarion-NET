using System.IO;

namespace Illarion.Common.Map
{
    public class Direction
    {
        public sbyte XVector { get; private set; }
        public sbyte YVector { get; private set; }

        public static Direction North = new Direction(0, -1);
        public static Direction NorthEast = new Direction(1, -1);
        public static Direction East = new Direction(1, 0);
        public static Direction SouthEast = new Direction(1, 1);
        public static Direction South = new Direction(0, 1);
        public static Direction SouthWest = new Direction(-1, 1);
        public static Direction West = new Direction(-1, 0);
        public static Direction NorthWest = new Direction(-1, -1);

        private static readonly Direction[] ServerIdDirections;

        static Direction()
        {
            ServerIdDirections = new Direction[8];
            ServerIdDirections[0] = North;
            ServerIdDirections[1] = NorthEast;
            ServerIdDirections[2] = East;
            ServerIdDirections[3] = SouthEast;
            ServerIdDirections[4] = South;
            ServerIdDirections[5] = SouthWest;
            ServerIdDirections[6] = West;
            ServerIdDirections[7] = NorthWest;
        }

        public void Encode(BinaryWriter writer)
        {
            //writer.Write((byte) Array.IndexOf(ServerIdDirections, this));
        }

        public static Direction FromServerId(short serverId)
        {
            return ServerIdDirections[serverId];
        }
        
        private Direction(sbyte xVector, sbyte yVector)
        {
            XVector = xVector;
            YVector = yVector;
        }
    }
}
