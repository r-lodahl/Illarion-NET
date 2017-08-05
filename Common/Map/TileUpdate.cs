namespace Illarion.Common.Map
{
    public class TileUpdate
    {
        private Coordinate _location;
        private byte _movementCost;
        private ushort _music;
        private byte _itemNumber;
        private ushort[] _itemIds, _itemCounts;

        private int _shapeId, _overlayId, _baseId;

        public TileUpdate(Coordinate location, short tileId, byte movementCost, ushort tileMusic, byte itemNumber,
            ushort[] itemIds, ushort[] itemCounts)
        {
            _location = location;
            _movementCost = movementCost;
            _music = tileMusic;
            _itemNumber = itemNumber;
            _itemCounts = itemCounts;
            _itemIds = itemIds;

            _shapeId = ((tileId & TileMask.ShapeMask) >> 10) - 1;
            _overlayId = _shapeId != -1 ? (tileId & TileMask.OverlayMask) >> 5 : 0;
            _baseId = _shapeId != -1 ? tileId & TileMask.BaseMask : tileId;
        }
    }
}
