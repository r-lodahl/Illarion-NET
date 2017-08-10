using System.Collections.Generic;

namespace Illarion.Common.Map
{
    public class MapChunk
    {
        private Coordinate _baseCoordinate;  //world-coordinate of the lower left corner
        private Coordinate _maximalExtent;   //width, height, depth of the map TODO: Make the extent for xyz fixed. I propose: x=128, y=128, z=3;

        private Tile[,,] _relativeMap;      //map is extremly dense -> array is most efficient, space-wise, also we always need to loop
        private Item[,,] _relativeItemMap;  //items are nearly as dense as the tile-map because of everything but tiles and players being items

        private Dictionary<Coordinate, Coordinate> _warpLocations;  // very sparse -> dictionary is the best solution
    
		private List<string> _visibleZChunks = new List<string>; // File-list of other chunks visible through tile-movement on the z-axis
		public List<string> VisibleZChunks { get { return _visibleZChunks; } }
	}
	
	
}
