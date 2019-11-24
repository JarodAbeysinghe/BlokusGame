using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class BlockSet
	{
		private List<Block> _blocks;

		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.BlockSet"/> class.
		/// </summary>
		public BlockSet ()
		{
			_blocks = new List<Block> ();
		}
		/// <summary>
		/// Adds the block to the Blockset
		/// </summary>
		/// <param name="block">Block.</param>
		public void AddBlock (Block block)
		{
			_blocks.Add (block);
		}
		/// <summary>
		/// Removes the block from the Blockset.
		/// </summary>
		/// <param name="block">Block.</param>
		public void RemoveBlock (Block block)
		{
			_blocks.Remove (block);
		}
		/// <summary>
		/// Gets the blocks.
		/// </summary>
		/// <value>The blocks.</value>
		public List<Block> Blocks
		{
			get { return _blocks;}
		}
		/// <summary>
		/// Selects the block at the point
		/// </summary>
		/// <param name="pt">Point.</param>
		public void SelectBlockAt (Point2D pt)
		{
			foreach(Block b in _blocks)
			{
				if (b.isAt (pt) == true)
					b.Used = false;
				else
					b.Used = true;
			}
		}
		/// <summary>
		/// Draw the blocks in the blockset
		/// </summary>
		public void Draw()
		{
			foreach (Block b in _blocks)
				b.Draw ();
		}
		/// <summary>
		/// Draws the blocks in the blockset gray
		/// </summary>
		public void DrawChosen()
		{
			foreach (Block b in _blocks)
			{
				foreach (Square s in b.Squares)
					s.DrawDark ();
			}
		}
		/// <summary>
		/// Gets the block identifier.
		/// </summary>
		/// <returns>The block identifier.</returns>
		/// <param name="b">The blue component.</param>
		public int GetBlockId(Block b)
		{	
			foreach (Block block in _blocks)
			{
				if (b.Number == block.Number)
					return _blocks.IndexOf (b);
			}
			return 22;
		}
		/// <summary>
		/// Returns the location of the block.
		/// </summary>
		/// <returns>The number.</returns>
		/// <param name="number">Number.</param>
		public Point2D ReturnNum(int number)
		{
			Point2D ret = new Point2D ();
			foreach (Block b in _blocks)
			{
				if (_blocks.IndexOf(b) == number)
				{
					ret.X = b.X;
					ret.Y = b.Y;
					return ret;
				}
			}
			ret.X = 0;
			ret.Y = 0;
			return ret;
		}
	}
}

