using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Block_NoRotation : Block
	{
		public Block_NoRotation (Color clr,int x,int y, int length,int size, int number) :base(clr,x,y,length,size,number)
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
			Assign ();
		}
		public override void Assign()
		{
			_squares.Clear ();
			if (Size == 4)
			{
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 2; j++)
						_squares.Add (new Square (Color, X + 20 * i, Y + 20 * j));
				}
			}
			else if (Size == 5)
			{
				for (int i = 0; i < 3; i++)
				{					
					for (int j = 0; j < 3; j++)
					{
						if ((i==0 && j == 1) || (i == 1) || (i==2 && j ==1))
							_squares.Add (new Square (Color, X + 20 * i, Y + 20 * j));
					}
				}
			}
		}
		public override int moveParameter ()
		{
			if (Size == 4)
				return 20;
			else if (Size == 5)
				return 40;
			return 0;
		}
		public override void AssignEdges()
		{
			_topLeftEdges.Clear ();
			_topRightEdges.Clear ();
			_bottomLeftEdges.Clear ();
			_bottomRightEdges.Clear ();

			if (Size == 4)
			{	
				Point2D TR = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
				Point2D BR = Locations.EdgeLocations (X, Y, 3, 3);
				Point2D BL = Locations.EdgeLocations (X, Y, 1, 3);
				_topRightEdges.Add (TR);
				_topLeftEdges.Add (TL);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL);
			}
			else if (Size == 5)
			{
				Point2D TR1 = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TR2 = Locations.EdgeLocations (X, Y, 4, 2);
				Point2D TL1 = Locations.EdgeLocations (X, Y, 2, 1);
				Point2D TL2 = Locations.EdgeLocations (X, Y, 1, 2);
				Point2D BR1 = Locations.EdgeLocations (X, Y, 3, 4);
				Point2D BR2 = Locations.EdgeLocations (X, Y, 4, 3);
				Point2D BL1 = Locations.EdgeLocations (X, Y, 2, 4);
				Point2D BL2 = Locations.EdgeLocations (X, Y, 1, 3);
				_topRightEdges.Add (TR1);
				_topLeftEdges.Add (TL1);
				_bottomRightEdges.Add (BR1);
				_bottomLeftEdges.Add (BL1);
				_topRightEdges.Add (TR2);
				_topLeftEdges.Add (TL2);
				_bottomRightEdges.Add (BR2);
				_bottomLeftEdges.Add (BL2);
			}
		}
		public override void MoveRight(int a)
		{
			X += 20;
			if (X > 400 - a)
			{
				X = 400 - a;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}
		public override void MoveDown(int a)
		{
			Y += 20;
			if (Y > 390 - a)
			{
				Y = 390 - a;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}
	}
}

