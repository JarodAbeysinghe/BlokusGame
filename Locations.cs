using System;
using SwinGameSDK;

namespace MyGame
{
	public static class Locations
	{
		static Locations ()
		{
		}
		/// <summary>
		/// Returns the location of the edge
		/// </summary>
		/// <returns>The locations.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="xnum">Xnum.</param>
		/// <param name="ynum">Ynum.</param>
		public static Point2D EdgeLocations(int x,int y, int xnum,int ynum)
		{
			Point2D mypoint = new Point2D();
			int length =20;

			mypoint.Y = y + (length*(ynum-1));
			mypoint.X = x + (length* (xnum-1));
			
			return mypoint;
		}
	}
}

