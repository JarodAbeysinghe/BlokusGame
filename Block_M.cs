using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Block_M : Block
	{
		public Block_M (Color clr,int x,int y, int length,int size, int number):base(clr,x,y,length,size,number)
		{
			Color = clr;
			X = x;
			Y = y;
			Length = length;
			_squares = new List<Square> ();
			_topRightEdges = new List<Point2D> ();
			_topLeftEdges = new List<Point2D> ();
			_bottomRightEdges = new List<Point2D> ();
			_bottomLeftEdges = new List<Point2D> ();
			Rotate = false;
			Rotation = 0;
			Assign ();
		}

		public override void Assign()
		{
			_squares.Clear ();
			if (Rotate)
			{
				Rotation++;
				Rotate = false;
				if (Rotation == 4)
					Rotation = 0;
			}
			if (Rotation == 0)
			{
				for (int i = 1; i < 3; i++)
					_squares.Add (new Square (Color, X, Y + 20 * i));
				for (int j = 1; j < 3; j++)
					_squares.Add (new Square (Color, X + 20 * j, Y));
			}
			else if (Rotation == 1)
			{
				for (int i = 1; i < 3; i++)
					_squares.Add (new Square (Color, X + 40, Y + 20 * i));
				for (int j = 0; j < 2; j++)
					_squares.Add (new Square (Color, X + 20 * j, Y));
			}
			else if (Rotation == 2)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X + 40, Y + 20 * i));
				for (int j = 0; j < 2; j++)
					_squares.Add (new Square (Color, X + 20 * j, Y + 40));
			}
			else if (Rotation == 3)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X, Y + 20 * i));
				for (int j = 1; j < 3; j++)
					_squares.Add (new Square (Color, X + 20 * j, Y + 40));
			}
			_squares.Add (new Square (Color, X + 20, Y + 20));
		}

		public override void AssignEdges()
		{
			_topLeftEdges.Clear ();
			_topRightEdges.Clear ();
			_bottomLeftEdges.Clear ();
			_bottomRightEdges.Clear ();
			if (Rotation == 0)
			{	
				Point2D TL1 = Locations.EdgeLocations (X, Y, 2, 1);
				Point2D TL2 = Locations.EdgeLocations (X, Y, 1, 2);
				Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
				Point2D BR1 = Locations.EdgeLocations (X, Y, 4, 2);
				Point2D BR2 = Locations.EdgeLocations (X, Y, 3, 3);
				Point2D BR3 = Locations.EdgeLocations (X, Y, 2, 4);
				Point2D BL = Locations.EdgeLocations (X, Y, 1, 4);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
				_bottomRightEdges.Add (BR3);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 1)
			{
				Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
				Point2D TR1 = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 2);
				Point2D BR = Locations.EdgeLocations (X, Y, 4, 4);
				Point2D BL1 = Locations.EdgeLocations (X, Y, 1, 2);
				Point2D BL2 = Locations.EdgeLocations (X, Y, 2, 3);
				Point2D BL3 = Locations.EdgeLocations (X, Y, 3, 4);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
				_bottomLeftEdges.Add (BL3);
			}
			else if (Rotation == 2)
			{
				Point2D TL1 = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TL2 = Locations.EdgeLocations (X, Y, 2, 2);
				Point2D TL3 = Locations.EdgeLocations (X, Y, 1, 3);
				Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
				Point2D BR1 = Locations.EdgeLocations (X, Y, 4, 3);
				Point2D BR2 = Locations.EdgeLocations (X, Y, 3, 4);
				Point2D BL = Locations.EdgeLocations (X, Y, 1, 4);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topLeftEdges.Add (TL3);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 3)
			{
				Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
				Point2D TR1 = Locations.EdgeLocations (X, Y, 2, 1);
				Point2D TR2 = Locations.EdgeLocations (X, Y, 3, 2);
				Point2D TR3 = Locations.EdgeLocations (X, Y, 4, 3);
				Point2D BR = Locations.EdgeLocations (X, Y, 4, 4);
				Point2D BL1 = Locations.EdgeLocations (X, Y, 1, 3);
				Point2D BL2 = Locations.EdgeLocations (X, Y, 2, 4);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_topRightEdges.Add (TR3);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
		}
	}
}



