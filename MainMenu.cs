using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Main menu of the Game.
	/// </summary>
	public class MainMenu
	{
		/// <summary>
		/// Draws the Main menu and buttons.
		/// </summary>
		public void DrawMenu()
		{
			SwinGame.LoadBitmapNamed ("Background","BlokusBackground.jpg");
			SwinGame.DrawBitmap ("Background",0,0);
			SwinGame.FillRectangle (Color.Black,50,500,200,75);
			SwinGame.FillRectangle (Color.GhostWhite,52,502,196,71);
			SwinGame.FillRectangle (Color.Black,300,500,200,75);
			SwinGame.FillRectangle (Color.GhostWhite,302,502,196,71);
			SwinGame.FillRectangle (Color.Black,550,500,200,75);
			SwinGame.FillRectangle (Color.GhostWhite,552,502,196,71);
			SwinGame.DrawText ("Play Blokus Classic", Color.Black,65,535);
			SwinGame.DrawText ("Play Blokus Advanced", Color.Black,315,535);
			SwinGame.DrawText ("Exit", Color.Black,625,535);
		}
		/// <summary>
		/// Handles the user input if a button is clicked in the main menu
		/// </summary>
		/// <returns>The handler.</returns>
		public string InputHandler()
		{
			if(SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				if (SwinGame.PointInRect (SwinGame.MousePosition(), 50, 500, 200, 75))
					return "Classic";
				else if (SwinGame.PointInRect (SwinGame.MousePosition(), 300,500,200,75))
					return "Random";
				else if (SwinGame.PointInRect (SwinGame.MousePosition(),550,500,200,75))
					return "Quit";
			}
			return "";
		}
	}
}

