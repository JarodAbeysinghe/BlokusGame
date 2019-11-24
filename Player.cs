using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Player
	{
		private string _name;
		private Color _color;
		private BlockSet _playerSet;
		private int _move;

		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Player"/> class. Adds all 21 blocks to the players blockset
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="color">Color.</param>
		public Player (string name,Color color)
		{
			_name = name;
			_color = color;
			_playerSet = new BlockSet ();
			_move = 1;

			Block b1 = new Block_L (_color, 25, 425, 20, 3,1);
			Block b2 = new Block_L (_color,95,425, 20, 4,2);
			Block b3 = new Block_L (_color, 165, 425, 20, 5,3);
			Block b4 = new Block_T (_color,235,425, 20, 4,4);
			Block b5 = new Block_T (_color, 305, 425, 20, 5,5);
			Block b6 = new Block_TSymmetric (_color, 375, 425, 20, 5,6);
			Block b7 = new Block_Line (_color, 445, 425, 20, 1,7);
			Block b8 = new Block_Line (_color,515,425, 20, 2,8);
			Block b9 = new Block_Line (_color, 585, 425, 20, 3,9);
			Block b10 = new Block_Line (_color, 655, 425, 20, 4,10);
			Block b11 = new Block_Line (_color, 725, 425, 20, 5,11);
			Block b12 = new Block_NoRotation (_color, 25, 515, 20, 4, 12);
			Block b13 = new Block_NoRotation (_color, 95, 515, 20, 5, 13);
			Block b14 = new Block_Z (_color,165,515, 20, 4,14);
			Block b15 = new Block_Z (_color, 235, 515, 20, 5,15);
			Block b16 = new Block_C (_color, 305, 515, 20, 5,16);
			Block b17 = new Block_LSymmetric (_color, 375, 515, 20, 5,17);
			Block b18 = new Block_M(_color, 445, 515, 20, 5,18);
			Block b19 = new Block_ZSymmetric(_color, 515, 515, 20, 5,19);
			Block b20 = new Block_N1(_color, 585, 515, 20, 5,20);
			Block b21 = new Block_N2(_color, 655, 515, 20, 5,21);
			_playerSet.AddBlock (b1);
			_playerSet.AddBlock (b2);
			_playerSet.AddBlock (b3);
			_playerSet.AddBlock (b4);
			_playerSet.AddBlock (b5);
			_playerSet.AddBlock (b6);
			_playerSet.AddBlock (b7);
			_playerSet.AddBlock (b8);
			_playerSet.AddBlock (b9);
			_playerSet.AddBlock (b10);
			_playerSet.AddBlock (b11);
			_playerSet.AddBlock (b12);
			_playerSet.AddBlock (b13);
			_playerSet.AddBlock (b14);
			_playerSet.AddBlock (b15);
			_playerSet.AddBlock (b16);
			_playerSet.AddBlock (b17);
			_playerSet.AddBlock (b18);
			_playerSet.AddBlock (b19);
			_playerSet.AddBlock (b20);
			_playerSet.AddBlock (b21);

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Player"/> class.
		/// </summary>
		public Player (): this ("Default",Color.Black)
		{

		}
		/// <summary>
		/// Gets or sets the name of the player.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get{return _name; }
			set{ _name = value;}
		}
		/// <summary>
		/// Gets or sets the color of the player.
		/// </summary>
		/// <value>The color.</value>
		public Color Color
		{
			get{ return _color;}
			set{ _color = value;}
		}
		/// <summary>
		/// Gets or sets the player's blockset set.
		/// </summary>
		/// <value>The player set.</value>
		public BlockSet PlayerSet
		{
			get{return _playerSet; }
			set{ _playerSet = value;}
		}
		/// <summary>
		/// Increments the players move.
		/// </summary>
		public void PlayMove()
		{
			_move++;
		}
		/// <summary>
		/// Gets the players move.
		/// </summary>
		/// <value>The move.</value>
		public int Move
		{
			get {return _move;}
		}
	}
}

 