using System;

namespace QuadTreeLOD
{
    public static class MathUtilities
    {
		public static int RoundToFactor( int val, int factor )
		{
			return ( ( int )System.Math.Round( ( val / (double)factor ), System.MidpointRounding.AwayFromZero ) * factor );
		}
    }
}