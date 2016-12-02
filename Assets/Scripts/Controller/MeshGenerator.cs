using UnityEngine;

namespace QuadTreeLOD
{
    public static class MeshGenerator
    {
		public static MeshData GeneratePlane( int _size, float _radius, float _scale, Vector2 _offset )
		{
			int vertSize = _size + 1;
			Vector2 topLeft = new Vector2( _size / -2, _size / -2 );
			MeshData meshData = new MeshData( vertSize, vertSize );
			int vertexIndex = 0;
			for( int x = 0; x < vertSize; x++ )
			{
				for( int y = 0; y < vertSize; y++ )
				{	

					float q = (_offset.x + ( topLeft.x + x ) * _scale) * _radius;
					float r = 0;
					float s = (_offset.y + ( topLeft.y + y ) * _scale) * _radius;

					Vector3 vert = new Vector3( q, r, s );
					Vector2 uv = new Vector2( x / (float)vertSize, y / (float)vertSize );
					bool centerVert = ( vertexIndex == ( _size / 2 ) + 1 );
					meshData.AddVertex( vert, uv, vertexIndex, centerVert );
					if( x < _size && y < _size )
					{
						meshData.AddTriangle (vertexIndex, vertexIndex + vertSize + 1, vertexIndex + vertSize);
						meshData.AddTriangle (vertexIndex + vertSize + 1, vertexIndex, vertexIndex + 1);
					}
					vertexIndex++;
				}
			}
			return meshData;
		}
    }
}