using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Single Line Blocks.
	/// </summary>
	public class Block_Line : Block
	{
		public Block_Line (Color clr,int x,int y, int length,int size, int number):base(clr,x,y,length,size,number)
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
			if (Rotate == true)
			{
				if (Y >= 20 + (20 * (20 - (Size))) && Y < 420)
				{
					Rotate = false;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 0; i < Size; i++)
						_squares.Add (new Square (Color, X, Y + 20 * i));
				}
			}
			else
			{
				if (X >= 20 + (20 * (20 - (Size - 1))) && X < 420)
				{
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
					Rotate = true;
				}
				else
				{
					for (int i = 0; i < Size; i++)
						_squares.Add (new Square (Color, X + 20 * i, Y));
				}
			}
		}
			
		public override void MoveRight(int a)
		{
			if (Rotate == false)
			{
				X += 20;
				if (X > 400 - a)
				{
					X = 400 - a;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else
			{
				X += 20;
				if (X > 400)
				{
					X = 400;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
		}
		public override void MoveDown(int a)
		{
			if (Rotate == false)
			{
				Y += 20;
				if (Y > 390)
				{
					Y = 390;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else
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
		public override void AssignEdges()
		{
			_topLeftEdges.Clear ();
			_topRightEdges.Clear ();
			_bottomLeftEdges.Clear ();
			_bottomRightEdges.Clear ();
			Point2D TL = Locations.EdgeLocations (X, Y, 1, 1);
			Point2D TR = new Point2D ();
			Point2D BR = new Point2D ();
			Point2D BL = new Point2D ();
			if(Rotate == false)
			{
				TR = Locations.EdgeLocations (X, Y, Size+1, 1);
				BR = Locations.EdgeLocations (X, Y, Size+1, 2);
				BL = Locations.EdgeLocations (X, Y, 1, 2);
			}
			else
			{
				TR = Locations.EdgeLocations (X, Y, 2, 1);
				BR = Locations.EdgeLocations (X, Y, 2, Size + 1);
				BL = Locations.EdgeLocations (X, Y, 1, Size+1);
			}
			_topRightEdges.Add (TR);
			_bottomRightEdges.Add (BR);
			_bottomLeftEdges.Add (BL);
			_topLeftEdges.Add (TL);
		}
	}
}

