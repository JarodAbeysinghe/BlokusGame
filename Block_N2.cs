using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Block_N2: Block
	{
		public Block_N2 (Color clr,int x,int y, int length,int size, int number):base(clr,x,y,length,size,number)
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
		public override void MoveRight (int a)
		{
			X += 20;
			if (Rotation == 2 || Rotation == 3 || Rotation == 6 || Rotation == 7)
			{
				if (X > 360)
				{
					X = 360;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else
			{
				if (X > 380)
				{
					X = 380;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
		}
		public override void MoveDown (int a)
		{
			Y += 20;
			if (Rotation == 0 || Rotation == 1 || Rotation == 4 || Rotation == 5)
			{
				if (Y > 350)
				{
					Y = 350;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else
			{
				if (Y > 370)
				{
					Y = 370;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
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
			if (Rotation == 0 || Rotation ==1)
			{
				if ((Y >= 360) && (X <= 440) && Rotation == 0)
				{
					Rotation = 7;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 0; i < 2; i++)
					{
						for (int j = 1; j < 3; j++)
							_squares.Add (new Square (Color, X + 20 * i, Y + 20 * j));
					}
					if (Rotation == 0)
						_squares.Add (new Square (Color, X, Y));
					else if (Rotation == 1)
						_squares.Add (new Square (Color, X + 20, Y));
				}
			}
			else if (Rotation >= 2 && Rotation <=5)
			{
				if ((X >= 370) && (X <= 400) && Rotation == 2)
				{
					Rotation = 1;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				if ((Y >= 360) && (X <= 440) && Rotation == 4)
				{
					Rotation = 3;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 0; i < 2; i++)
					{
						for (int j = 0; j < 2; j++)
							_squares.Add (new Square (Color, X + 20 * i, Y + 20 * j));
					}
					if (Rotation == 2)
						_squares.Add (new Square (Color, X + 40, Y));
					else if (Rotation == 3)
						_squares.Add (new Square (Color, X + 40, Y + 20));
					else if (Rotation == 4)
						_squares.Add (new Square (Color, X + 20, Y + 40));
					else if (Rotation == 5)
						_squares.Add (new Square (Color, X, Y + 40));
				}
			}
			else if (Rotation == 6 || Rotation ==7)
			{
				if ((X >= 370) && (X <= 400) && Rotation == 6)
				{
					Rotation = 5;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 1; i < 3; i++)
					{
						for (int j = 0; j < 2; j++)
							_squares.Add (new Square (Color, X + 20 * i, Y + 20 * j));
					}
					if (Rotation == 7)
						_squares.Add (new Square (Color, X, Y));
					else if (Rotation == 6)
						_squares.Add (new Square (Color, X, Y + 20));
				}
			}

		}
		public override void AssignEdges()
		{
			_topLeftEdges.Clear ();
			_topRightEdges.Clear ();
			_bottomLeftEdges.Clear ();
			_bottomRightEdges.Clear ();
			if (Rotation == 0 || Rotation == 1)
			{	
				Point2D BR = Locations.EdgeLocations (X, Y, 3, 4);
				Point2D BL = Locations.EdgeLocations (X, Y, 1, 4);
				if (Rotation == 0)
				{
					Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
					Point2D TR1 = Locations.EdgeLocations (X, Y, 2, 1);
					Point2D TR2 = Locations.EdgeLocations (X, Y, 3, 2);
					_topLeftEdges.Add (TL);
					_topRightEdges.Add (TR1);
					_topRightEdges.Add (TR2);
				}
				else if (Rotation == 1)
				{
					Point2D TL1 = Locations.EdgeLocations (X, Y, 1, 2);
					Point2D TL2 = Locations.EdgeLocations (X, Y, 2, 1);
					Point2D TR = Locations.EdgeLocations (X, Y, 1, 3);
					_topLeftEdges.Add (TL1);
					_topLeftEdges.Add (TL2);
					_topRightEdges.Add (TR);
				}
				_bottomLeftEdges.Add (BL);
				_bottomRightEdges.Add (BR);
			}
			else if (Rotation == 2 || Rotation == 3)
			{	
				Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
				Point2D BL = Locations.EdgeLocations (X, Y, 1, 3);
				if (Rotation == 2)
				{
					Point2D BR1 = Locations.EdgeLocations (X, Y, 4, 2);
					Point2D BR2 = Locations.EdgeLocations (X, Y, 3, 3);
					Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
					_bottomRightEdges.Add (BR1);
					_bottomRightEdges.Add (BR2);
					_topRightEdges.Add (TR);
				}
				else if (Rotation == 3)
				{
					Point2D BR = Locations.EdgeLocations (X, Y, 4, 3);
					Point2D TR1 = Locations.EdgeLocations (X, Y, 4, 2);
					Point2D TR2 = Locations.EdgeLocations (X, Y, 3, 1);
					_bottomRightEdges.Add (BR);
					_topRightEdges.Add (TR1);
					_topRightEdges.Add (TR2);
				}
				_topLeftEdges.Add (TL);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 4 || Rotation == 5)
			{	
				Point2D TR = Locations.EdgeLocations (X, Y, 3, 1);
				Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
				if (Rotation == 4)
				{
					Point2D BR = Locations.EdgeLocations (X, Y, 3, 4);
					Point2D BL1 = Locations.EdgeLocations (X, Y, 2, 4);
					Point2D BL2 = Locations.EdgeLocations (X, Y, 1, 3);
					_bottomRightEdges.Add (BR);
					_bottomLeftEdges.Add (BL1);
					_bottomLeftEdges.Add (BL2);
				}
				else if (Rotation == 5)
				{
					Point2D BR1 = Locations.EdgeLocations (X, Y, 3, 3);
					Point2D BR2 = Locations.EdgeLocations (X, Y, 2, 4);
					Point2D BL = Locations.EdgeLocations (X, Y, 1, 4);
					_bottomRightEdges.Add (BR1);
					_bottomRightEdges.Add (BR2);
					_bottomLeftEdges.Add (BL);
				}
				_topRightEdges.Add (TR);
				_topLeftEdges.Add (TL);
			}
			else if (Rotation == 6 || Rotation == 7)
			{	
				Point2D TR = Locations.EdgeLocations (X, Y, 4, 1);
				Point2D BR = Locations.EdgeLocations (X, Y, 4, 3);
				if (Rotation == 6)
				{
					Point2D TL1 = Locations.EdgeLocations (X, Y, 1, 2);
					Point2D TL2 = Locations.EdgeLocations (X, Y, 2, 1);
					Point2D BL = Locations.EdgeLocations (X, Y, 1, 3);
					_topLeftEdges.Add (TL1);
					_topLeftEdges.Add (TL2);
					_bottomLeftEdges.Add (BL);
				}
				else if (Rotation == 7)
				{
					Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
					Point2D BL1 = Locations.EdgeLocations (X, Y, 1, 2);
					Point2D BL2 = Locations.EdgeLocations (X, Y, 2, 3);
					_topLeftEdges.Add (TL);
					_bottomLeftEdges.Add (BL1);
					_bottomLeftEdges.Add (BL2);
				}
				_bottomRightEdges.Add (BR);
				_topRightEdges.Add (TR);
			}
		}
	}
}

