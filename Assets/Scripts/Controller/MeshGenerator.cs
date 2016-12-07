using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QuadTreeLOD
{
    public static class MeshGenerator
    {
		public static MeshData GenerateQuadPlane( int vertexPerLine, MapData _mapData, HeightData _heightData )
		{
			int size = vertexPerLine + 1;
			Vector2 topLeft = new Vector2( vertexPerLine / -2f, vertexPerLine / -2f );

			MeshData meshData = new MeshData( size );
			int vertexIndex = 0;

			for( int x = 0; x < size; x++ )
			{
				for( int y = 0; y < size; y++ )
				{
					float q = topLeft.x + x;
					float r = 0;
					float s = topLeft.y + y;
					Vector2 uv = new Vector2 ( x / (float)size, y / (float)size );
					meshData.AddVertex( new Vector3( q, r, s ), uv, vertexIndex );
					if( x < vertexPerLine && y < vertexPerLine )
					{
						meshData.AddTriangle( vertexIndex, vertexIndex + size + 1, vertexIndex + size );
						meshData.AddTriangle( vertexIndex + size + 1, vertexIndex, vertexIndex + 1 );
					}
					vertexIndex++;
				}
			}
			return meshData;
		}
    }

    public class MeshData
    {

    	public Vector3[] vertices{ get; private set; }
    	public int[] triangles{ get; private set; }
    	public Vector2[] uvs{ get; private set; }

    	private int triangleIndex = 0;

    	public MeshData( int _size )
    	{
    		vertices = new Vector3[ _size * _size ];
    		triangles = new int[ ( _size - 1 ) * ( _size - 1 ) * 6 ];
    		uvs = new Vector2[ vertices.Length ];
    	}

    	public void AddVertex( Vector3 vert, Vector2 uv, int vertIndex )
    	{
    		vertices[ vertIndex ] = vert;
    		uvs[ vertIndex ] = uv;
    	}

    	public void AddTriangle( int a, int b, int c )
    	{
    		triangles[ triangleIndex ] = a;
    		triangles[ triangleIndex + 1 ] = b;
    		triangles[ triangleIndex + 2 ] = c;
    		triangleIndex += 3;
    	}

    	public Mesh CreateMesh()
    	{
    		Mesh mesh = new Mesh();
    		mesh.vertices = vertices;
    		mesh.triangles = triangles;
    		mesh.uv = uvs;
    		mesh.RecalculateNormals();
    		return mesh;
    	}

    }
}