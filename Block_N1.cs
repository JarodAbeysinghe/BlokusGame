using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Block_N1 : Block
	{
		public Block_N1 (Color clr,int x,int y, int length,int size, int number):base(clr,x,y,length,size,number)
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
				if (Rotation == 8)
					Rotation = 0;
			}
			if (Rotation == 0 || Rotation ==2 || Rotation == 4 || Rotation == 6)
			{
				for (int i = 0; i < 3; i++)
					_squares.Add (new Square (Color, X+20, Y + 20 * i));

				if (Rotation == 0 || Rotation == 6)
				{
					_squares.Add (new Square (Color, X + 40, Y + 20));
					if(Rotation == 0)
						_squares.Add (new Square (Color, X, Y));
					else if(Rotation == 6)
						_squares.Add (new Square (Color, X, Y+40));
				}
				else if (Rotation == 2 || Rotation == 4)
				{
					_squares.Add (new Square (Color, X, Y + 20));
					if(Rotation == 2)
						_squares.Add (new Square (Color, X+40, Y));
					if(Rotation == 4)
						_squares.Add (new Square (Color, X+40, Y+40));
				}
			}
			if (Rotation == 1 || Rotation ==3 || Rotation == 5 || Rotation == 7)
			{
				for (int i = 0; i < 3; i++)
					_squares.Add (new Square (Color, X+20* i, Y + 20 ));

				if (Rotation == 1 || Rotation == 7)
				{
					_squares.Add (new Square (Color, X + 20, Y));
					if(Rotation == 1)
						_squares.Add (new Square (Color, X, Y+40));
					else if(Rotation == 7)
						_squares.Add (new Square (Color, X+40, Y+40));
				}
				else if (Rotation == 3 || Rotation == 5)
				{
					_squares.Add (new Square (Color, X+20, Y + 40));
					if(Rotation == 5)
						_squares.Add (new Square (Color, X, Y));
					if(Rotation == 3)
						_squares.Add (new Square (Color, X+40, Y));
				}
			}
		}
		public override void AssignEdges()
		{
			_topLeftEdges.Clear ();
			_topRightEdges.Clear ();
			_bottomLeftEdges.Clear ();
			_bottomRightEdges.Clear ();
			if (Rotation == 0 || Rotation == 6)
			{	
				Point2D TR1 = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 2);
				Point2D BR1 = Locations.EdgeLocations (X,Y,4,3);
				Point2D BR2 = Locations.EdgeLocations (X,Y,3,4);
				if (Rotation == 0)
				{
					Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
					Point2D BL1 = Locations.EdgeLocations (X, Y, 2, 4);
					Point2D BL2 = Locations.EdgeLocations (X, Y, 1, 2);
					_topLeftEdges.Add (TL);
					_bottomLeftEdges.Add (BL1);
					_bottomLeftEdges.Add (BL2);
				}
				else if (Rotation == 6)
				{
					Point2D TL1 = Locations.EdgeLocations (X, Y, 1, 3);
					Point2D TL2 = Locations.EdgeLocations (X, Y, 2, 1);
					Point2D BL = Locations.EdgeLocations (X,Y,1,4);
					_topLeftEdges.Add (TL1);
					_topLeftEdges.Add (TL2);
					_bottomLeftEdges.Add (BL);
				}
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
			}
			else if (Rotation == 1 || Rotation == 7)
			{	
				Point2D TL1 = Locations.EdgeLocations (X, Y, 2, 1);
				Point2D TL2 = Locations.EdgeLocations (X, Y, 1, 2);
				Point2D TR1 = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 2);
				if (Rotation == 1)
				{
					Point2D BR1 = Locations.EdgeLocations (X, Y, 3, 4);
					Point2D BR2 = Locations.EdgeLocations (X, Y, 4, 2);
					Point2D BL = Locations.EdgeLocations (X, Y, 1, 4);
					_bottomRightEdges.Add (BR1);
					_bottomRightEdges.Add (BR2);
					_bottomLeftEdges.Add (BL);
				}
				else if (Rotation == 7)
				{
					Point2D BR = Locations.EdgeLocations (X, Y, 4, 4);
					Point2D BL1 = Locations.EdgeLocations (X, Y, 3, 4);
					Point2D BL2 = Locations.EdgeLocations (X, Y, 1, 3);
					_bottomRightEdges.Add (BR);
					_bottomLeftEdges.Add (BL1);
					_bottomLeftEdges.Add (BL2);
				}
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
			}
			else if (Rotation == 2 || Rotation == 4)
			{	
				Point2D TL1 = Locations.EdgeLocations (X, Y, 2, 1);
				Point2D TL2 = Locations.EdgeLocations (X, Y, 1, 2);
				Point2D BL1 = Locations.EdgeLocations (X,Y,1,3);
				Point2D BL2 = Locations.EdgeLocations (X,Y,2,4);

				if (Rotation == 2)
				{
					Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
					Point2D BR1 = Locations.EdgeLocations (X, Y, 4, 2);
					Point2D BR2 = Locations.EdgeLocations (X, Y, 3, 4);
					_topRightEdges.Add (TR);
					_bottomRightEdges.Add (BR1);
					_bottomRightEdges.Add (BR2);
				}
				if (Rotation == 4)
				{
					Point2D TR1 = Locations.EdgeLocations (X, Y, 3, 1);
					Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 3);
					Point2D BR = Locations.EdgeLocations (X, Y, 4, 4);
					_topRightEdges.Add (TR1);
					_topRightEdges.Add (TR2);
					_bottomRightEdges.Add (BR);
				}
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
			else if (Rotation == 3 || Rotation == 5)
			{	
				Point2D BR1 = Locations.EdgeLocations (X, Y, 4, 3);
				Point2D BR2 = Locations.EdgeLocations (X, Y, 3, 4);
				Point2D BL1 = Locations.EdgeLocations (X,Y,1,3);
				Point2D BL2 = Locations.EdgeLocations (X,Y,2,4);

				if (Rotation == 3)
				{
					Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
					Point2D TL1 = Locations.EdgeLocations (X, Y, 3, 1);
					Point2D TL2 = Locations.EdgeLocations (X, Y, 1, 2);
					_topRightEdges.Add (TR);
					_topLeftEdges.Add (TL1);
					_topLeftEdges.Add (TL2);

				}
				if (Rotation == 5)
				{
					Point2D TR1 = Locations.EdgeLocations (X, Y, 2, 1);
					Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 2);
					Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
					_topRightEdges.Add (TR1);
					_topRightEdges.Add (TR2);
					_topLeftEdges.Add (TL);
				}
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
		}
	}
}

