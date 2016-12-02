using UnityEngine;
using System.Collections;

namespace QuadTreeLOD
{
    public class QuadTree
    {

    	private const int MAX_LEVEL = 5;

    	private QuadPlane owner;
    	private QuadTree parent;
    	private QuadTree[] children;
    	private int level;
    	public Vector2 offset{ get; private set; }

    	public int splitDistance = 3;

    	private float scale = 1;

    	private MeshData meshData;

    	private GameObject gObj;

		public QuadTree( QuadPlane _owner, QuadTree _parent, int _level, Vector2 _offset )
		{
			owner = _owner;
			parent = _parent;
			level = _level;
			offset = _offset;

			scale = 1 / Mathf.Pow( 2, level );

			meshData = MeshGenerator.GeneratePlane( owner.size, owner.radius, scale, offset );
		}

		public void Update( Vector3 cameraPosition )
		{
			float d = Vector3.Distance( cameraPosition, owner.transform.TransformPoint( meshData.centerVertex ) );
			bool doSplit = ( d / ( owner.size * scale ) < splitDistance && level <= MAX_LEVEL );

			if( doSplit )
			{
				if( children == null )
				{
					split();
				}

				for( int i = 0; i < children.Length; i++ )
				{
					children[i].Update( cameraPosition );
				}
			}
			else if( !doSplit )
			{
				Clear();
				Render();
			}
		}

		public void Render()
		{
			if( gObj == null )
			{
				gObj = new GameObject();
				gObj.AddComponent<MeshFilter>();
				gObj.AddComponent<MeshRenderer>();
			}

			gObj.GetComponent<MeshFilter>().mesh = meshData.CreateMesh();
			gObj.SetActive( true );
		}

		public void Clear()
		{
			if( children != null )
			{
				for( int i = 0; i < children.Length; i++ )
				{
					children[i].Clear();
				}
			}
			if( gObj != null ) gObj.SetActive( false );
		}

		private void split()
		{
			if( children == null )
			{
				float halfSize = ( (owner.size / 4) * scale );
				children = new QuadTree[4]{
					new QuadTree( owner, this, level + 1, offset + new Vector2( -halfSize, halfSize ) ),
					new QuadTree( owner, this, level + 1, offset + new Vector2( halfSize, halfSize ) ),
					new QuadTree( owner, this, level + 1, offset + new Vector2( halfSize, -halfSize ) ),
					new QuadTree( owner, this, level + 1, offset + new Vector2( -halfSize, -halfSize ) )
				};
			}
			else
			{
				for( int i = 0; i < children.Length; i++ )
				{
					children[i].Render();
				}
			}
		}
    }
}