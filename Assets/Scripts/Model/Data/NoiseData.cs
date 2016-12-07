using UnityEngine;

namespace QuadTreeLOD
{
	[ CreateAssetMenu() ]
    public class NoiseData : ScriptableObject
    {
		[ Range(16, 1024) ]
		public int mapSize;
		public float noiseScale;
		[ Range(2, 16) ]
		public int octaves;
		[ Range( 0, 1 ) ]
		public float persistance;
		public float lacunarity;
		public int seed;
		public Vector2 offset;

		void OnValidate()
		{
			mapSize = MathUtilities.RoundToFactor( mapSize, 16 );
			octaves = MathUtilities.RoundToFactor( octaves, 2);
		}
    }
}