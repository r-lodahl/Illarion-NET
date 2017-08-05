using System;
using System.IO;
using Illarion.Common.Map;

namespace Illarion.Common.Internal.Communication.Messages
{
    public class MapStripeMessageEventArgs : EventArgs
    {


        /**
         * The list of tiles that are inside the update and all containing information.
         */

        private readonly TileUpdate[] _tileUpdates;


        public MapStripeMessageEventArgs(BinaryReader reader)
        {
            var location = new Coordinate(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());


            var dir = reader.ReadByte();
            var count = reader.ReadByte();

            _tileUpdates = new TileUpdate[count];

            for (var i = 0; i < count; i++)
            {
                var tileId = reader.ReadInt16();
                var movementCost = reader.ReadByte();
                var tileMusic = reader.ReadUInt16();

                var itemNumber = reader.ReadByte();
                var itemIds = new ushort[itemNumber];
                var itemCounts = new ushort[itemNumber];

                for (var j = 0; j < itemNumber; j++)
                {
                    itemIds[j] = reader.ReadUInt16();
                    itemCounts[j] = reader.ReadUInt16();
                }

                _tileUpdates[i] = new TileUpdate(
                    location,
                    tileId,
                    movementCost,
                    tileMusic,
                    itemNumber,
                    itemIds,
                    itemCounts
                );

                if (dir == 1)
                {
                    // DIR_DOWN
                    location.IncrementY();
                    location.DecrementX();
                }
                else
                {
                    // DIR_RIGHT
                    location.IncrementX();
                    location.IncrementY();
                }
            }
        }
        // public ServerReplyResult Execute() {
        //   if (_tileUpdates == null) {
        //     throw new NotDecodedException();
        //}

        //  MapUpdater.updateTiles(_tileUpdates);

        // return ServerReplyResult.Success;
        //}

        public override string ToString()
        {
            return "[MapStripeMessage]";
        }
    }
}
