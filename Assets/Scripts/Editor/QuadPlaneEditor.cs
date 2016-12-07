using UnityEditor;
using UnityEngine;

namespace QuadTreeLOD
{
	[ CustomEditor( typeof(QuadPlane) ) ]
    public class QuadPlaneEditor : Editor
    {
    	public override void OnInspectorGUI()
        {
            QuadPlane plane = (QuadPlane)target;

            if( DrawDefaultInspector() || GUILayout.Button( "Render" ) )
            {
            	plane.RenderPreview();
            }

            if( GUILayout.Button( "Clear" ) )
            {
                plane.Clear();
            }
        }
    }
}