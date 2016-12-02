using UnityEditor;
using UnityEngine;

namespace QuadTreeLOD
{
	[ CustomEditor( typeof( QuadPlane ) ) ]
    public class QuadPlaneEditor : Editor
    {
    	public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
         	QuadPlane plane = (QuadPlane)target;
        }
    }
}