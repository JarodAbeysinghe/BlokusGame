using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class GameBoard
	{ 
		private const int BLOCK_SIZE = 20;
		private const int XINIT = 20;
		private const int YINIT = 10;

		private Square [,] _myboard = new Square[22,22] ;

		public GameBoard ()
		{
		}

		/// <summary>
		/// Assigns the board to its initial colour.
		/// </summary>
		public void AssignBoard()
		{
			int x =XINIT-20, y = YINIT-20;
			for (int i = 0; i < BLOCK_SIZE+2; i++)
			{	
				for (int j = 0; j < BLOCK_SIZE+2; j++)
				{
					_myboard [i, j] = new Square (Color.AntiqueWhite, x, y);
					x += BLOCK_SIZE;
				}
				x = XINIT-20;
				y += BLOCK_SIZE;
			}
		}
		/// <summary>
		/// Draws the Gameboard.
		/// </summary>
		public void DrawBoard()
		{
			int x =XINIT, y = YINIT;
			for (int i = 1; i < BLOCK_SIZE+1; i++)
			{	
				for (int j = 1; j < BLOCK_SIZE+1; j++)
					_myboard[i,j].Draw ();
			}
				
			for (int i = 0; i < BLOCK_SIZE+1; i++)
			{	
				SwinGame.DrawLine (Color.Black, x, y, x + (BLOCK_SIZE*BLOCK_SIZE), y);
				y += BLOCK_SIZE;
			}
				
			y = YINIT;
			for (int i = 0; i < BLOCK_SIZE + 1; i++)
			{	
				SwinGame.DrawLine (Color.Black, x, y, x, y + (BLOCK_SIZE * BLOCK_SIZE));
				x += BLOCK_SIZE;
			}
			SwinGame.DrawText ("Press M to Play Music", Color.Brown,20,605);
		}

		/// <summary>
		/// Draws the display shape box.
		/// </summary>
		public void DrawShapeBox()
		{
			SwinGame.FillRectangle (Color.Black, 20, 420, 770, 180);
			SwinGame.FillRectangle (Color.WhiteSmoke, 20+1, 420+1, 768, 178);

			SwinGame.DrawLine (Color.Black, 20,420+90,20 +700, 420+ 90);
			int x = 70;
			for (int a = 0; a < 10; a++)
			{
				SwinGame.DrawLine (Color.Black, 20+x, 420, 20+x, 420 + 180);
				x += 70;
			}
		}

		/// <summary>
		/// Checks the board to see if there is a block placed in the same location. If there is no block the block will be placed.
		/// </summary>
		/// <returns><c>true</c>, if board was checked, <c>false</c> otherwise.</returns>
		/// <param name="b">The blue component.</param>
		public bool CheckBoard(Block b)
		{
			int x = 0;
			foreach (Square s in _myboard)
			{
				foreach(Square blocksquare in b.Squares)
				{
					if ((blocksquare.X == s.X) && (blocksquare.Y == s.Y) && (s.Color == Color.AntiqueWhite))
						x++;
				}
			}
			if (b.Size == x)
			{
				foreach (Square s in _myboard)
				{
					foreach(Square blocksquare in b.Squares)
					{
						if (blocksquare.X == s.X && blocksquare.Y == s.Y && s.Color == Color.AntiqueWhite)
							s.Color = b.Color;
					}
				}
				return true;
			}
			return false;
		}
		/// <summary>
		/// Checks Edges to see if the Block can be placed
		/// </summary>
		/// <returns><c>true</c>, if checking was edged, <c>false</c> otherwise.</returns>
		/// <param name="b">The blue component.</param>
		public bool EdgeChecking(Block b)
		{
			int x = 0, y = 0;
			int z = 0 , w= 0;
			b.AssignEdges ();
			bool edge = false;

			foreach (Square s in _myboard)
			{
				foreach (Point2D lte in b.TopLeftEdges)
				{
					if ((s.X == (lte.X - b.Length)) && (s.Y == (lte.Y - b.Length)) && (s.Color == b.Color))
						x++;
				}
				foreach (Point2D rte in b.TopRightEdges)
				{
					if ((s.X == rte.X) && (s.Y == (rte.Y - b.Length)) && (s.Color == b.Color))
						y++;
				}
				foreach (Point2D bre in b.BottomRightEdges)
				{
					if ((bre.X == s.X) && (bre.Y == s.Y) && (s.Color == b.Color))
						z++;
				}
				foreach (Point2D ble in b.BottomLeftEdges)
				{
					if ((s.X == (ble.X - b.Length)) && (s.Y == (ble.Y)) && (s.Color == b.Color))
						w++;
				}
			}
			if (x>=1)
			{
					
				foreach (Square s in _myboard)
				{
					foreach (Point2D lte in b.TopLeftEdges)
					{
						if (((lte.X - b.Length) == s.X) && (lte.Y == (s.Y)) && (s.Color != b.Color))
							x++;
						if (((lte.X) == s.X) && ((lte.Y - b.Length) == s.Y) && (s.Color != b.Color))
							x++;
					}
				}
			}
			if (y>=1)
			{
				foreach (Square s in _myboard)
				{
					foreach (Point2D lte in b.TopRightEdges)
					{
						if ((lte.X == s.X) && (lte.Y == (s.Y)) && (s.Color != b.Color))
							y++;
						if (((lte.X - b.Length) == s.X) && ((lte.Y - b.Length) == s.Y) && (s.Color != b.Color))
							y++;
					}
				}
			}
			if (z>=1)
			{
				foreach (Square s in _myboard)
				{
					foreach (Point2D bre in b.BottomRightEdges)
					{
						if ((bre.X == s.X) && ((bre.Y-b.Length) == (s.Y)) && (s.Color != b.Color))
							z++;
						if (((bre.X - b.Length) == s.X) && (bre.Y == s.Y) && (s.Color != b.Color))
							z++;
					}
				}
			}
			if (w>=1)
			{
				foreach (Square s in _myboard)
				{
					foreach (Point2D lte in b.BottomLeftEdges)
					{
						if (((lte.X - b.Length) == s.X) && ((lte.Y-b.Length) == (s.Y)) && (s.Color != b.Color))
							w++;
						if (((lte.X) == s.X) && ((lte.Y) == s.Y) && (s.Color != b.Color))
							w++;
					}
				}
			}
			foreach (Square s in _myboard)
			{
				foreach (Point2D lte in b.TopLeftEdges)
				{
					if (((lte.X - b.Length) == s.X) && (lte.Y == (s.Y)) && (s.Color == b.Color))
						edge = true;
					if (((lte.X) == s.X) && ((lte.Y - b.Length) == s.Y) && (s.Color == b.Color))
						edge = true;
				}
				foreach (Point2D lte in b.BottomLeftEdges)
				{
					if (((lte.X - b.Length) == s.X) && ((lte.Y-b.Length) == (s.Y)) && (s.Color == b.Color))
						edge = true;
					if (((lte.X) == s.X) && ((lte.Y) == s.Y) && (s.Color == b.Color))
						edge = true;
				}
				foreach (Point2D bre in b.BottomRightEdges)
				{
					if ((bre.X == s.X) && ((bre.Y-b.Length) == (s.Y)) && (s.Color == b.Color))
						edge = true;
					if (((bre.X - b.Length) == s.X) && (bre.Y == s.Y) && (s.Color == b.Color))
						edge = true;
				}
				foreach (Point2D lte in b.TopRightEdges)
				{
					if ((lte.X == s.X) && (lte.Y == (s.Y)) && (s.Color == b.Color))
						edge = true;
					if (((lte.X - b.Length) == s.X) && ((lte.Y - b.Length) == s.Y) && (s.Color == b.Color))
						edge = true;
				}
			}
			if (((x >= 1 + 2*b.TopLeftEdges.Count)|| (y >=1 + 2*b.TopRightEdges.Count) || (z >=1+ 2*b.BottomRightEdges.Count) || (w >=1+ 2*b.BottomLeftEdges.Count)) && edge == false)
				return true;
			return false;
		}

		/// <summary>
		/// Draws the player details.
		/// </summary>
		public void DrawPlayerDetails()
		{
			int p1score = 0, p2score = 0, p3score = 0, p4score = 0;

			SwinGame.DrawText ("Player 1: ",Color.Blue,450,150);
			SwinGame.DrawText ("Player 2: ",Color.Red,450,170);
			SwinGame.DrawText ("Player 3: ",Color.Green,450,190);
			SwinGame.DrawText ("Player 4: ",Color.Gold,450,210);
			for(int i =0; i< 22; i++)
			{
				for(int j=0; j < 22 ; j++)
				{
					if (_myboard [i, j].Color == Color.Blue)
						p1score++;
					else if (_myboard [i, j].Color == Color.Red)
						p2score++;
					else if (_myboard [i, j].Color == Color.Green)
						p3score++;
					else if (_myboard [i, j].Color == Color.Gold)
						p4score++;
				}
			}
			SwinGame.DrawText (p1score.ToString(),Color.Blue,530,150);
			SwinGame.DrawText (p2score.ToString(),Color.Red,530,170);
			SwinGame.DrawText (p3score.ToString(),Color.Green,530,190);
			SwinGame.DrawText (p4score.ToString(),Color.Gold,530,210);
			SwinGame.LoadBitmapNamed ("Blokus","Blokus.jpg");
			SwinGame.DrawBitmap ("Blokus",431,11);
		}
		/// <summary>
		/// Displays the winner.
		/// </summary>
		public void DisplayWinner()
		{
			int p1score = 0, p2score = 0, p3score = 0, p4score = 0;
			for(int i =0; i< 22; i++)
			{
				for(int j=0; j < 22 ; j++)
				{
					if (_myboard [i, j].Color == Color.Blue)
						p1score++;
					else if (_myboard [i, j].Color == Color.Red)
						p2score++;
					else if (_myboard [i, j].Color == Color.Green)
						p3score++;
					else if (_myboard [i, j].Color == Color.Gold)
						p4score++;
				}
			}
			//SwinGame.ClearScreen (Color.White);
			if(p1score > p2score && p1score > p3score && p1score > p4score)
				SwinGame.DrawText ("Player 1 Wins",Color.Blue,450,300);
			else if(p2score > p1score && p2score > p3score && p2score > p4score)
				SwinGame.DrawText ("Player 2 Wins",Color.Red,450,300);
			else if(p3score > p1score && p3score > p2score && p3score > p4score)
				SwinGame.DrawText ("Player 3 Wins",Color.Green,450,300);
			else if(p4score > p1score && p4score > p2score && p4score > p3score)
				SwinGame.DrawText ("Player 4 Wins",Color.Gold,450,300);
			else
				SwinGame.DrawText ("No Winner",Color.Black,450,300);

			SwinGame.DrawText ("Press Q to Exit",Color.Black,450,320);
			SwinGame.DrawText ("Press R to go to the MainMenu",Color.Black,450,340);
		}
		/// <summary>
		/// Draws the Background box.
		/// </summary>
		public void BackgroundBox()
		{
			SwinGame.FillRectangle (Color.Black, 430, 10, 360, 400);
			SwinGame.FillRectangle (Color.White, 430+1, 10+1, 358, 398);
		}
		/// <summary>
		/// Draw the Single Block box which sdisplays the selected block.
		/// </summary>
		public void SingleBlockBox()
		{
			SwinGame.FillRectangle (Color.Black, 440, 230, 140, 140);
			SwinGame.FillRectangle (Color.WhiteSmoke, 440+1, 230+1, 138, 138);
		}
		/// <summary>
		/// Checks if the user places the first move in the respective corner
		/// </summary>
		/// <returns><c>true</c>, if board first move was checked, <c>false</c> otherwise.</returns>
		/// <param name="b">The blue component.</param>
		/// <param name="p">P.</param>
		public bool CheckBoardFirstMove(Block b,Player p)
		{
			bool check = false;
			int x = 0, y = 0;
			if (p.Color == Color.Blue)
			{
				x = 20;
				y = 10;
			}
			else if (p.Color == Color.Red)
			{
				x = 400;
				y = 10;
			}
			else if (p.Color == Color.Green)
			{
				x = 20;
				y = 390;
			}
			else if (p.Color == Color.Gold)
			{
				x = 400;
				y = 390;
			}
	
			foreach (Square s in _myboard)
			{
				foreach(Square blocksquare in b.Squares)
				{
					if ((blocksquare.X == x) && (blocksquare.Y == y))
					{
						check = true;
						p.PlayMove ();
					}
				}
			}
			if (check)
			{
				foreach (Square s in _myboard)
				{
					foreach(Square blocksquare in b.Squares)
					{
						if (blocksquare.X == s.X && blocksquare.Y == s.Y && s.Color == Color.AntiqueWhite)
						{
							s.Color = b.Color;
						}
					}
				}
				return true;

			}
			return false;
		}
		/// <summary>
		/// Displays the instrcutions during gameplay
		/// </summary>
		/// <param name="i">The index.</param>
		public void GameInstructionDisplay(int i)
		{
			SwinGame.DrawText("Click Block to select",Color.Black,590,240);
			SwinGame.DrawText("Place 1st Block at Corner",Color.Black,590,255);
			SwinGame.DrawText("S to Skip Turn",Color.Black,590,300);
			SwinGame.DrawText("R to Rotate/Flip Block",Color.Black,590,315);
			SwinGame.DrawText("P to Place Block",Color.Black,590,330);
			SwinGame.DrawText("Use Arrow keys to Move",Color.Black,590,345);
			SwinGame.DrawText("E to end game",Color.Black,590,360);
			if (i == 1)
			{
				SwinGame.DrawText ("Blocks assigned Randomly", Color.Brown, 590, 270);
				SwinGame.DrawText ("After First Move", Color.Brown, 590, 285);
			}
		}

	}
}
	