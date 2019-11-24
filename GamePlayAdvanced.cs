using System;
using SwinGameSDK;

namespace MyGame
{
	public class GamePlayAdvanced : GamePlay
	{
		
		private bool chosenblock = false;
		private int randomselection = 0;

		private Random choose = new Random();
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.GamePlayClassic"/> class.
		/// </summary>
		public GamePlayAdvanced ()
		{
			_BlokusBoard.AssignBoard ();
			_BlokusBoard.BackgroundBox ();
			_BlokusBoard.DrawPlayerDetails ();
			_p = _players[0];
		}
		/// <summary>
		/// Dictates the gameplay.
		/// </summary>
		public override void Play()
		{
			
			if(_end==false)//Player is selecting Block
				SelectBlock(_p);
			if (_play && _end== false)//Player is Moving and Placing Block
			{
				MoveBlock ();
				if (SwinGame.KeyTyped (KeyCode.vk_s))
				{
					SwitchPlayer ();
					chosenblock = false;
				}
			}
			else if(_end)//Ends the game
			{
				_BlokusBoard.BackgroundBox ();
				_BlokusBoard.DrawPlayerDetails ();
				_BlokusBoard.DisplayWinner ();
				if (SwinGame.KeyTyped (KeyCode.vk_r))
					GameMain.Main ();
			}

		}
		/// <summary>
		/// Player Selects the Block
		/// </summary>
		/// <param name="player">Player.</param>
		public override void SelectBlock(Player player)
		{
			_BlokusBoard.BackgroundBox ();
			_BlokusBoard.DrawPlayerDetails ();
			_BlokusBoard.DrawShapeBox ();
			_BlokusBoard.SingleBlockBox ();
			_BlokusBoard.DrawBoard ();
			player.PlayerSet.Draw ();
			_BlokusBoard.GameInstructionDisplay (1);
			turnDisplay ();
			Point2D rand = new Point2D();
			if (SwinGame.KeyTyped(KeyCode.vk_e))
			{
				_end = true;
				Play ();
			}
			if(_p.Move != 1 && chosenblock == false)
			{
				if (player.PlayerSet.Blocks.Count == 0)
				{
					_end = true;
					Play ();
				}
				else
				{
					randomselection = choose.Next (player.PlayerSet.Blocks.Count);
					rand = player.PlayerSet.ReturnNum (_p.PlayerSet.GetBlockId (player.PlayerSet.Blocks [randomselection]));
					if ((player.PlayerSet.Blocks [randomselection] is Block_NoRotation && player.PlayerSet.Blocks [randomselection].Size == 5) || (player.PlayerSet.Blocks [randomselection] is Block_M))
					{
						rand.X += 20;
					}
					player.PlayerSet.SelectBlockAt (rand);
					chosenblock = true;
					player.PlayerSet.DrawChosen ();
				}
			}
			else
				player.PlayerSet.DrawChosen ();

			if (_p.Move > 1)
			{
				foreach (Block b in player.PlayerSet.Blocks)
				{
					if (player.PlayerSet.Blocks.IndexOf(b) == randomselection)
						b.Draw ();
				}
			}
			if (SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				if (_p.Move == 1 && chosenblock== false)
				{
					player.PlayerSet.SelectBlockAt (SwinGame.MousePosition ());
				}
				foreach (Block b in player.PlayerSet.Blocks)
				{
					if (b.Used == false)
					{
						if (b is Block_Line)
						{
							_temp = new Block_Line (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_Line (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_Z)
						{
							_temp = new Block_Z (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_Z (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_NoRotation)
						{
							_temp = new Block_NoRotation (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_NoRotation (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_L)
						{
							_temp = new Block_L (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_L (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_LSymmetric)
						{
							_temp = new Block_LSymmetric (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_LSymmetric (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_M)
						{
							_temp = new Block_M (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_M (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_T)
						{
							_temp = new Block_T (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_T (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_C)
						{
							_temp = new Block_C (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_C (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_TSymmetric)
						{
							_temp = new Block_TSymmetric (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_TSymmetric (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_ZSymmetric)
						{
							_temp = new Block_ZSymmetric (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_ZSymmetric (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_N1)
						{
							_temp = new Block_N1 (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_N1 (Color.Black, 0, 0, 0, 0, 0);
						}
						else if (b is Block_N2)
						{
							_temp = new Block_N2 (Color.Black, 0, 0, 0, 0, 0);
							_display = new Block_N2 (Color.Black, 0, 0, 0, 0, 0);
						}
						_temp.X = 200;
						_temp.Y = 190;
						_temp.Length = b.Length;
						_temp.Size = b.Size;
						_temp.Color = b.Color;
						_temp.Number = b.Number;
						_display.Length = b.Length;
						_display.Size = b.Size;
						_display.Color = b.Color;
						_play = true;
					}
				}
			}
		}
		/// <summary>
		/// Allows the Player to Move,Rotate, Flip and Place the Block
		/// </summary>
		public override void MoveBlock()
		{
			_display.X = 450;
			_display.Y = 240;
			_display.Assign ();
			_temp.Assign ();
			_display.Color = _p.Color;
			_temp.Color = _p.Color;
			_temp.Draw ();
			_display.Rotation = _temp.Rotation;
			_display.Rotate = _temp.Rotate;
			_display.Draw ();
			_temp.Move ();
			_temp.AssignEdges ();

			if (SwinGame.KeyTyped (KeyCode.vk_e))
			{
				_end = true;
				Play ();
			}
			if (SwinGame.KeyTyped (KeyCode.vk_r))
			{
				if (_temp.Rotate == false)
				{
					_temp.Rotate = true;
					_display.Rotate = true;
					SwinGame.LoadSoundEffectNamed ("Rotate", "rot.wav");
					SwinGame.PlaySoundEffect ("Rotate");
				}
				else
				{
					_temp.Rotate = false;
					_display.Rotate = false;
					SwinGame.LoadSoundEffectNamed ("Rotate", "rot.wav");
					SwinGame.PlaySoundEffect ("Rotate");
				}
			}
			if (SwinGame.KeyTyped (KeyCode.vk_p))
			{
				if (_p.Move == 1)
				{
					if (_BlokusBoard.CheckBoardFirstMove (_temp, _p))
					{
						foreach (Block b in _p.PlayerSet.Blocks)
						{
							if (_temp.Number == b.Number)
								_id = _p.PlayerSet.GetBlockId (b);
						}
						_p.PlayerSet.RemoveBlock (_p.PlayerSet.Blocks [_id]);
						SwitchPlayer ();

					}
				}
				else
				{
					if (_BlokusBoard.EdgeChecking (_temp))
					{
						if (_BlokusBoard.CheckBoard (_temp))
						{
							foreach (Block b in _p.PlayerSet.Blocks)
							{
								if (_temp.Number == b.Number)
									_id = _p.PlayerSet.GetBlockId (b);
							}
							_p.PlayerSet.RemoveBlock (_p.PlayerSet.Blocks [_id]);
							SwitchPlayer ();
							chosenblock = false;
						}
					}
				}
			}
			turnDisplay ();
		}
	}
}


