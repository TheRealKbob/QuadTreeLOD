using UnityEngine;
using System.Collections;

namespace QuadTreeLOD
{
    public static class MapGenerator
    {
		public static MapData Generate( NoiseData _noiseData )
		{
			float[,] noiseMap = Noise.GeneratePerlin( 	_noiseData.mapSize,
														_noiseData.noiseScale,
														_noiseData.seed,
														_noiseData.octaves,
														_noiseData.persistance,
														_noiseData.lacunarity,
														_noiseData.offset );
			MapData mapData = new MapData( noiseMap );
			return mapData;
		}
    }

    public class MapData
    {

    	public float[,] heightMap{ get; private set; }

    	public MapData( float[,] _heightMap )
    	{
    		heightMap = _heightMap;
    	}
    }
}