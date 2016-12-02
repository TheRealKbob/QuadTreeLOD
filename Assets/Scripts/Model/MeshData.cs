using UnityEngine;

namespace QuadTreeLOD
{
    public class MeshData
    {
		public Vector3[] vertices;
		public Vector3 centerVertex;
		public int[] triangles;
		public Vector2[] uvs;

		public int triangleIndex = 0;

		public MeshData( int _width, int _height )
		{
			vertices = new Vector3[ _width * _height ];
			triangles = new int[ ( _width - 1 ) * ( _height - 1 ) * 6 ];
			uvs = new Vector2[ vertices.Length ];
		}

		public void AddVertex( Vector3 position, Vector2 uv, int index, bool center )
		{
			vertices[ index ] = position;
			uvs[ index ] = uv;
			if( center ) centerVertex = vertices[ index ];
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