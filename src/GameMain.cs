using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 620);
            //SwinGame.ShowSwinGameSplashScreen();
			GamePlayClassic Classic = new GamePlayClassic ();
			GamePlayAdvanced Random = new GamePlayAdvanced ();
			MainMenu menu = new MainMenu ();
			//Display the main menu
			menu.DrawMenu();
			string s = "";
			bool nextoption = false;
			Audio.LoadMusicNamed ("song","Background.mp3");
			Audio.PlayMusic ("song");
			SwinGame.DrawText ("Press M to Play Music", Color.Crimson,65,605);
			while(false == SwinGame.WindowCloseRequested())
            {
				
				if (SwinGame.KeyTyped (KeyCode.vk_m))
				{
					Audio.StopMusic ();
					Audio.LoadMusicNamed ("song1","Creed.mp3");
					Audio.PlayMusic ("song1");
				}
				if (s == "")
				{
					//Get Input From Main Menu
					s = menu.InputHandler ();
					if (s == "Classic" || s == "Random")
						nextoption = true;
				}
				if (nextoption)
				{
					if (s == "Classic")
						SwinGame.ClearScreen (Color.White);
					if (s == "Random")
						SwinGame.ClearScreen (Color.Beige);
					nextoption = false;
				}

                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				if (s == "Classic")
					Classic.Play ();
				else if (s == "Random")
					Random.Play ();
				else if (s == "Quit")
					break;
				if (SwinGame.KeyTyped (KeyCode.vk_q))
					break;
				
                SwinGame.RefreshScreen(60);
            }
        }
    }
}