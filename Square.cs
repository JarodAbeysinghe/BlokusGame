using System;
using SwinGameSDK;

namespace MyGame
{
	public class Square
	{
		private Color _color;
		private int _x, _y;
		private const int SIZE = 20;

		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Square"/> class.
		/// </summary>
		/// <param name="color">Color.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Square (Color color, int x, int y)
		{
			_color = color;
			_x = x;
			_y = y;
		}
		public Square(): this(Color.WhiteSmoke,0,0)
		{
		}

		/// <summary>
		/// Draw the square.
		/// </summary>
		public void Draw()
		{
			SwinGame.FillRectangle (_color, _x, _y, SIZE, SIZE);
		}
		/// <summary>
		/// Draws the square in Gray Colour.
		/// </summary>
		public void DrawDark()
		{
			SwinGame.FillRectangle (Color.Gray, _x, _y, SIZE, SIZE);
		}
		/// <summary>
		/// Checks if Square is at Point
		/// </summary>
		/// <returns>The <see cref="System.Boolean"/>.</returns>
		/// <param name="pt">Point.</param>
		public bool isAt(Point2D pt)
		{
			if (SwinGame.PointInRect (pt, X, Y, SIZE, SIZE))
				return true;
			else
				return false;
		}
		/// <summary>
		/// Gets or sets the color of the square
		/// </summary>
		/// <value>The color.</value>
		public Color Color
		{
			get{ return _color;}
			set{ _color = value;}
		}
		/// <summary>
		/// Gets the x coordinate of the square.
		/// </summary>
		/// <value>The x.</value>
		public int X
		{
			get{ return _x;}
		}
		/// <summary>
		/// Gets the y coorinate of the square.
		/// </summary>
		/// <value>The y.</value>
		public int Y
		{
			get{ return _y;}
		}
	}
}

