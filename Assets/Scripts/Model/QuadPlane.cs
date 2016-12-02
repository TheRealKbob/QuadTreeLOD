using UnityEngine;

namespace QuadTreeLOD
{
    public class QuadPlane : MonoBehaviour
    {

    	public int size;
    	public float radius;

		QuadTree tree;

		void Start()
		{
			tree = new QuadTree( this, null, 0, Vector2.zero );
		}

		void Update()
		{
			tree.Update( Camera.main.transform.position );
		}
    }
}