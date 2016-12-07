using UnityEngine;

namespace QuadTreeLOD
{
    public class HeightData : ScriptableObject
    {
    	public float radius;
		public float multiplier;
		public AnimationCurve curve;

		public AnimationCurve GetCurve()
		{
			return new AnimationCurve( curve.keys );
		}
    }
}