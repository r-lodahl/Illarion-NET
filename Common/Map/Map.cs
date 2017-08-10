public class Map {
	
	private MapChunk[,,] _subMaps;
	private const byte ChunkSizeX = 128, ChunkSizeY = 128, ChunkSizeZ = 3;
	private const short originX = 2048, originY = 2048, originZ = 2048;  //Origin: Abs() of maximal negative map value used! Equals _subMaps[0]
	private const short maxX = 4096, maxY = 4096, maxZ = 4096;
	
	public Map 
	{
		_subMaps = new MapChunk[(2*(originX)) / ChunkSizeX, (2*(originY)) / ChunkSizeY, (2*(originZ)) / ChunkSizeZ]
	}
	
	public void TryLoadMapChunk(Coordinate fromPosition)
	{
		var chunkCoordinate = GetChunkCoordinates(fromPosition.X, fromPosition.Y, fromPosition.Z);
		
		//PSEUDO:
		var fileName = "chunk" + x + "-" + y + "_" + z +  ".dat";
		TryLoadMapChunk(fileName, chunkCoordinate, true);
	}
	
	public void TryLoadMapChunk(string mapFileName) 
	{
		var xPos = mapFileName.IndexOf('k') + 1;
		var yPos = mapFileName.IndexOf('-') + 1;
		var zPos = mapFileName.IndexOf('_') + 1;
		var endPos = mapFileName.IndexOf('.');
	
		var chunkCoordinate = new Coordinate(
			short.TryParse(Substring(mapFileName, xPos, yPos - xPos - 1)),
			short.TryParse(Substring(mapFileName, yPos, zPos - yPos - 1)),
			short.TryParse(Substring(mapFileName, zPos, endPos - zPos))
		);
		
		TryLoadMapChunk(mapFileName, chunkCoordinate, false);
	}	

	private void TryLoadMapChunk(string fileName, short x, short y, short z, bool loadVisibleMapChunks)
	{
		if (!File.Exists(mapFileName)) return;
		
		MapChunk chunk = LoadFromFile(mapFileName)
		_subMaps[x, y, z] = chunk;
		
		if (!loadVisibleMapChunks) return;
		
		foreach (var visibleChunk in chunk.VisibleZChunks)
		{
			TryLoadMapChunk(fileName);
		}
	}
	
	private Coordinate GetChunkCoordinates(Coordinate mapCoordinates)
	{
		var x = mapCoordinates.X + originX;
		var y = mapCoordinates.Y + originY;
		var z = mapCoordinates.Z + originZ;
		
		if (x < 0 || x > maxX || y < 0 || y > maxY || z < 0 || z > maxZ)
		{
		    UnityEngine.Debug.LogError(string.Format("Tried to load MapChunk out of Bounds! {0}|{1}|{2}", x, y, z));
			throw new ArgumentOfOfBoundsException();
		}
		
		return new Coordinate(
			x / ChunkSizeX,
			y / ChunkSizeY,
			z / ChunkSizeZ
		);
	}
	
	public void UnloadMapChunk(short x, short y, short z)
	{
		var chunkCoordinate = GetChunkCoordinates(x, y, z);
		
		_subMaps[chunkCoordinate.X, chunkCoordinate.Y, chunkCoordinat.Z] = null;
	}
	
}
