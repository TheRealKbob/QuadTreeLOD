using UnityEngine;
using System;
using System.Collections;

namespace QuadTreeLOD
{

    public class QuadPlane : MonoBehaviour
    {
    	public enum Direction
		{
			TOP,
			BOTTOM,
			LEFT,
			RIGHT,
			FRONT,
			BACK
		}

		public Direction direction;

		public NoiseData noiseData;
		public HeightData heightData;
		public TextureData textureData;

		[ Range( 8, 32 ) ]
		public int gridSize = 16;
		public float radius = 6;

		public MapData mapData{ get; private set; }

		private QuadTree quadTree;

		public void RenderPreview()
		{
			Clear();
			mapData = MapGenerator.Generate( noiseData );
			quadTree = new QuadTree( this, null, 0, Vector2.zero );
			quadTree.Render();
		}

		public void Clear()
		{
			foreach( Transform child in transform ) {
			    DestroyImmediate(child.gameObject);
			}
		}

		void OnValidate()
		{
			gridSize = MathUtilities.RoundToFactor( gridSize, 8 );
		}
    }
}