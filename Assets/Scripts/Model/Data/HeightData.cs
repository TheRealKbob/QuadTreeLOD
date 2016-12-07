using UnityEngine;

namespace QuadTreeLOD
{
	[ CreateAssetMenu() ]
    public class HeightData : ScriptableObject
    {
		public float multiplier;
		public AnimationCurve curve;

		public AnimationCurve Curve
		{
			get{
				return new AnimationCurve( curve.keys );
			}
		}
    }
}