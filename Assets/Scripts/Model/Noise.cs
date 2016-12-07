using UnityEngine;
using System.Collections;

namespace QuadTreeLOD
{
    public static class Noise
    {
		public static float[,] GeneratePerlin( int _mapSize, float _scale, int _seed, int _octaves, float _persistance, float _lacunarity, Vector2 _offset )
		{
			float[,] noiseMap = new float[ _mapSize, _mapSize ];

			System.Random seedRNG = new System.Random( _seed );
			Vector2[] octaveOffsets = new Vector2[ _octaves ];
			for( int i = 0; i < _octaves; i++ ) {
				float offsetX = seedRNG.Next( -100000, 100000 ) + _offset.x;
				float offsetY = seedRNG.Next( -100000, 100000 ) + _offset.y;
				octaveOffsets [i] = new Vector2( offsetX, offsetY );
			}

			_scale = ( _scale <= 0 ) ? 0.001f : _scale;

			float maxNoiseHeight = float.MinValue;
			float minNoiseHeight = float.MaxValue;

			float halfSize = _mapSize / 2f;
			
			for (int x = 0; x < _mapSize; x++) 
			{
				for (int y = 0; y < _mapSize; y++) 
				{
					float amplitude = 1;
					float frequency = 1;
					float noiseHeight = 0;

					for( int i = 0; i < _octaves; i++ ) 
					{
						float sampleX = (x - halfSize) / _scale * frequency + octaveOffsets[i].x;
						float sampleY = (y - halfSize) / _scale * frequency + octaveOffsets[i].y;

						float perlinValue = Mathf.PerlinNoise( sampleX, sampleY ) * 2 - 1;
						noiseHeight += perlinValue * amplitude;

						amplitude *= _persistance;
						frequency *= _lacunarity;
					}

					if( noiseHeight > maxNoiseHeight )
						maxNoiseHeight = noiseHeight;
					else if( noiseHeight < minNoiseHeight )
						minNoiseHeight = noiseHeight;

					noiseMap[ x, y ] = noiseHeight;
				}
			}

			
			for( int x = 0; x < _mapSize; x++ ) {
				for( int y = 0; y < _mapSize; y++ ) {
					noiseMap[ x, y ] = Mathf.InverseLerp( minNoiseHeight, maxNoiseHeight, noiseMap[ x, y ] );
				}
			}

			return noiseMap;
		}
    }
}