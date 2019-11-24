using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Block_Z : Block
	{
		public Block_Z (Color clr,int x,int y, int length,int size, int number):base(clr,x,y,length,size,number)
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
				if(Size == 5)
					Rotation++;
				else if(Size == 4)
					Rotation +=2;
				Rotate = false;
				if (Rotation == 8)
					Rotation = 0;
			}
			if (Rotation == 0)
			{
				if (Y >= 10 + (20 * (20 - (Size - 2))) && Y < 390)
				{
					if(Size == 5)
						Rotation = 7;
					if (Size == 4)
						Rotation = 6;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 0; i < 2; i++)
						_squares.Add (new Square (Color, X, Y + 20 * i));
					for (int j = 0; j < Size - 2; j++)
						_squares.Add (new Square (Color, X + 20, Y + 20 + 20 * j));
				}
			}
			else if (Rotation == 1)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X, Y +40+ 20 * i));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X+20, Y + 20 * j));
			}
			else if (Rotation == 2)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X+20, Y + 20 * i));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X , Y + 20 + 20 * j));
			}
			else if (Rotation == 3)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X+20, Y +40+ 20 * i));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X, Y + 20 * j));
			}
			else if (Rotation == 4)
			{
				if ((X >= (20 * (20 - (Size - 3)))) && (X <= 440))
				{
					if(Size == 5)
						Rotation = 3;
					if (Size == 4)
						Rotation = 2;
					SwinGame.LoadSoundEffectNamed ("Error2","Error2.wav");
					SwinGame.PlaySoundEffect ("Error2");
				}
				else
				{
					for (int i = 0; i < 2; i++)
						_squares.Add (new Square (Color, X + 20 * i, Y));
					for (int j = 0; j < Size - 2; j++)
						_squares.Add (new Square (Color, X + 20 + 20 * j, Y + 20));
				}
			}
			else if (Rotation == 5)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X+ 40 + 20 * i, Y ));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X + 20 * j, Y + 20 ));
			}
			else if (Rotation == 6)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X+ 20 * i, Y +20));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X + 20+ 20 * j, Y ));
			}
			else if (Rotation == 7)
			{
				for (int i = 0; i < 2; i++)
					_squares.Add (new Square (Color, X+40+ 20 * i, Y +20));
				for (int j = 0; j < Size-2; j++)
					_squares.Add (new Square (Color, X +  20 * j, Y ));
			}
		}
		public override void MoveRight (int a)
		{
			X += 20;
			if (Rotation >= 0 && Rotation <= 3)
			{
				if (X > 380)
				{
					X = 380;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else if(Rotation >= 4)
			{
				if (X > 400 - 20 * (Size - 2))
				{
					X = 400 - 20 * (Size - 2);
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
		}
		public override void MoveDown (int a)
		{
			Y += 20;
			if (Rotation >= 4 && Rotation <= 7)
			{
				if (Y > 370)
				{
					Y = 370;
					SwinGame.LoadSoundEffectNamed ("Error","error.wav");
					SwinGame.PlaySoundEffect ("Error");
				}
			}
			else
			{
				if (Y > 390 - 20 * (Size - 2))
				{
					Y = 390 - 20 * (Size - 2);
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

			if (Rotation == 0)
			{
				Point2D TL = Locations.EdgeLocations (X,Y,1,1);
				Point2D TR1 = Locations.EdgeLocations (X,Y,2, 1);
				Point2D TR2 = Locations.EdgeLocations (X,Y,3, 2);
				Point2D BR = Locations.EdgeLocations (X,Y,3, Size);
				Point2D BL1 = Locations.EdgeLocations (X,Y,2, Size);
				Point2D BL2 = Locations.EdgeLocations (X,Y,1, 3);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
			else if (Rotation == 1)
			{
				Point2D TL1 = Locations.EdgeLocations (X,Y,1,3);
				Point2D TL2 = Locations.EdgeLocations (X,Y,2,1);
				Point2D TR = Locations.EdgeLocations (X,Y,3, 1);
				Point2D BR1 = Locations.EdgeLocations (X,Y,3, 4);
				Point2D BR2 = Locations.EdgeLocations (X,Y,2, 5);
				Point2D BL = Locations.EdgeLocations (X,Y,1, 5);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 2)
			{
				Point2D TL1 = Locations.EdgeLocations (X,Y,1,2);
				Point2D TL2 = Locations.EdgeLocations (X,Y,2,1);
				Point2D TR = Locations.EdgeLocations (X,Y,3, 1);
				Point2D BR1 = Locations.EdgeLocations (X,Y,3, 3);
				Point2D BR2 = Locations.EdgeLocations (X,Y,2, Size);
				Point2D BL = Locations.EdgeLocations (X,Y,1, Size);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR2);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 3)
			{
				Point2D TL = Locations.EdgeLocations (X,Y,1,1);
				Point2D TR1 = Locations.EdgeLocations (X,Y,2, 1);
				Point2D TR2 = Locations.EdgeLocations (X,Y,3, 3);
				Point2D BR = Locations.EdgeLocations (X,Y,3, Size);
				Point2D BL1 = Locations.EdgeLocations (X,Y,2, Size);
				Point2D BL2 = Locations.EdgeLocations (X,Y,1, 4);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
			else if (Rotation == 4)
			{
				Point2D TL =  Locations.EdgeLocations (X,Y,1,1);
				Point2D TR1 = Locations.EdgeLocations (X,Y,3, 1);
				Point2D TR2 = Locations.EdgeLocations (X,Y,Size, 2);
				Point2D BR = Locations.EdgeLocations (X,Y,Size, 3);
				Point2D BL1 = Locations.EdgeLocations (X,Y,2,3);
				Point2D BL2 = Locations.EdgeLocations (X,Y,1, 2);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
			else if (Rotation == 5)
			{
				Point2D TL1 = Locations.EdgeLocations (X,Y,1,2);
				Point2D TL2 = Locations.EdgeLocations (X,Y,3,1);
				Point2D TR = Locations.EdgeLocations (X,Y,Size, 1);
				Point2D BR1 = Locations.EdgeLocations (X,Y,Size, 2);
				Point2D BR2 = Locations.EdgeLocations (X,Y,4, 2);
				Point2D BL = Locations.EdgeLocations (X,Y,1, 3);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR1);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 6)
			{
				Point2D TL1 = Locations.EdgeLocations (X,Y,1,2);
				Point2D TL2 = Locations.EdgeLocations (X,Y,2,1);
				Point2D TR = Locations.EdgeLocations (X,Y,Size, 1);
				Point2D BR1 = Locations.EdgeLocations (X,Y,Size, 2);
				Point2D BR2 = Locations.EdgeLocations (X,Y,3, 2);
				Point2D BL = Locations.EdgeLocations (X,Y,1, 3);
				_topLeftEdges.Add (TL1);
				_topLeftEdges.Add (TL2);
				_topRightEdges.Add (TR);
				_bottomRightEdges.Add (BR1);
				_bottomRightEdges.Add (BR1);
				_bottomLeftEdges.Add (BL);
			}
			else if (Rotation == 7)
			{
				Point2D TL = Locations.EdgeLocations (X,Y,1,1);
				Point2D TR1 = Locations.EdgeLocations (X,Y,4, 1);
				Point2D TR2 = Locations.EdgeLocations (X,Y,Size, 2);
				Point2D BR = Locations.EdgeLocations (X,Y,Size, 3);
				Point2D BL1 = Locations.EdgeLocations (X,Y,3,3);
				Point2D BL2 = Locations.EdgeLocations (X,Y,1, 2);
				_topLeftEdges.Add (TL);
				_topRightEdges.Add (TR1);
				_topRightEdges.Add (TR2);
				_bottomRightEdges.Add (BR);
				_bottomLeftEdges.Add (BL1);
				_bottomLeftEdges.Add (BL2);
			}
		}
	}
}

