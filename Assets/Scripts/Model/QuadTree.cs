using UnityEngine;

namespace QuadTreeLOD
{
    public class QuadTree
    {

    	private QuadPlane owner;
    	private QuadTree parent;
    	private QuadTree[] children;
    	private int level;
    	public Vector2 offset{ get; private set; }

    	private GameObject terrainObject;

    	MeshData meshData;

		public QuadTree( QuadPlane _owner, QuadTree _parent, int _level, Vector2 _offset )
		{
			owner = _owner;
			parent = _parent;
			level = _level;
			offset = _offset;
		}

		public void Render()
		{
			if( terrainObject == null )
			{
				terrainObject = new GameObject();
				terrainObject.AddComponent<MeshFilter>();
				terrainObject.AddComponent<MeshRenderer>();
				terrainObject.transform.parent = owner.transform;
			}

			meshData = MeshGenerator.GenerateQuadPlane( owner.gridSize, owner.radius, owner.mapData, owner.heightData );

			terrainObject.GetComponent<MeshFilter>().mesh = meshData.CreateMesh();
			terrainObject.SetActive( true );
		}

		public void Clear()
		{
			GameObject.DestroyImmediate( terrainObject );
			terrainObject = null;
		}

    }
}