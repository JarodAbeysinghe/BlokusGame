using System;
using SwinGameSDK; 
namespace MyGame
{
	public abstract class GamePlay
	{
		protected GameBoard _BlokusBoard = new GameBoard ();
		protected BlockSet _mySet = new BlockSet ();
		protected int _switch =0;
		protected string instruction = "Start Game";
		protected Player _p = new Player();
		protected Player[] _players = {new Player ("Player 1",Color.Blue),new Player ("Player 2", Color.Red),new Player ("Player 3",Color.Green),new Player ("Player 4",Color.Gold)};
		protected int _id =0;
		protected bool _play = false;
		protected bool _end = false;
		protected Block _temp;
		protected Block _display;

		public GamePlay ()
		{
		}
		public abstract void Play ();
		public abstract void SelectBlock (Player player);
		public abstract void MoveBlock();
		/// <summary>
		/// Switches the player after a turn has been completed.
		/// </summary>
		public void SwitchPlayer()
		{
			_play = false;
			_switch++;
			if (_switch == 4)
				_switch = 0;
			if (_switch ==0)
				_p = _players[0];
			else if (_switch ==1)
				_p = _players[1];
			else if (_switch ==2)
				_p = _players[2];
			else if (_switch ==3)
				_p = _players[3];
		}
		/// <summary>
		/// Displays which players turn it is
		/// </summary>
		public void turnDisplay()
		{
			for (int i = 0; i < 4; i++)
			{
				if (_p == _players [i])
					instruction = (_p.Name +" " +" it is Your Turn");
			}
			SwinGame.DrawText(instruction,_p.Color,490,390);
		}
	}
}

