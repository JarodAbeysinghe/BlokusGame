using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public abstract class Block
	{
		private Color _color;
		private int _x, _y;
		private int _length,_number;
		private bool _used;
		private int _size;
		private bool _rot;
		private int _rotation;

		protected List<Square> _squares;
		protected List<Point2D> _topRightEdges;
		protected List<Point2D> _topLeftEdges;
		protected List<Point2D> _bottomRightEdges;
		protected List<Point2D> _bottomLeftEdges;

		public Block(Color clr,int x,int y, int length,int size,int number)
		{
			Color = clr;
			X = x;
			Y = y;
			Length = length;
			_used = false;
			_size = size;
			_rot = true;
			_number = number;
		}
		public int Size
		{
			get{ return _size; }
			set{ _size = value;}
		}
		public int Number
		{
			get{ return _number; }
			set{ _number = value;}
		}
		public Color Color
		{
			get { return _color;}
			set {_color = value;}
		}
		public int X
		{
			get { return _x;}
			set { _x = value;}
		}
		public int Y
		{
			get { return _y;}
			set {_y = value;}
		}

		public bool Used
		{
			get {return _used; }
			set {_used = value; }
		}
		public int Length
		{
			get { return _length;}
			set {_length = value;}
		}
		public bool Rotate
		{
			get{return _rot; }
			set{ _rot = value;}
		}
		public List<Point2D> TopRightEdges
		{
			get{return _topRightEdges; }
			set{ _topRightEdges = value;}
		}
		public List<Point2D> TopLeftEdges
		{
			get{return _topLeftEdges; }
			set{ _topLeftEdges = value;}
		}
		public List<Point2D> BottomLeftEdges
		{
			get{return _bottomLeftEdges; }
			set{ _bottomLeftEdges = value;}
		}
		public List<Point2D> BottomRightEdges
		{
			get{return _bottomRightEdges; }
			set{ _bottomRightEdges = value;}
		}
		public List<Square> Squares
		{
			get{return _squares; }
			set{ _squares = value;}
		}
		public int Rotation
		{
			get{ return _rotation;}
			set{ _rotation = value;}
		}
		public void Draw()
		{
			foreach (Square s in _squares)
				s.Draw ();
		}

		public bool isAt (Point2D pt)
		{
			foreach (Square s in _squares)
			{
				if (s.isAt (pt))
					return true;
			}
			return false;
		}
		/// <summary>
		/// Parameter used to control movement (Right and Down) in some occasions
		/// </summary>
		/// <returns>The parameter.</returns>
		public virtual int moveParameter()
		{
			int a = 0;
			for (int count = 0; count < Size-1; count++)
				a += 20;
			return a;
		}
		/// <summary>
		/// Controls the movement of the block
		/// </summary>
		public virtual void Move ()
		{
			int a = moveParameter ();

			if(SwinGame.KeyTyped(KeyCode.vk_RIGHT))
			{
				MoveRight (a);
				SwinGame.LoadSoundEffectNamed ("Move","tick.wav");
				SwinGame.PlaySoundEffect ("Move");
			}
			else if(SwinGame.KeyTyped(KeyCode.vk_LEFT))
			{
				MoveLeft ();
				SwinGame.LoadSoundEffectNamed ("Move","intro.mp3");
				SwinGame.PlaySoundEffect ("Move");
			}
			else if(SwinGame.KeyTyped(KeyCode.vk_UP))
			{
				MoveUp ();
				SwinGame.LoadSoundEffectNamed ("Move","tick.wav");
				SwinGame.PlaySoundEffect ("Move");
			}
			else if(SwinGame.KeyTyped(KeyCode.vk_DOWN))
			{
				MoveDown (a);
				SwinGame.LoadSoundEffectNamed ("Move","tick.wav");
				SwinGame.PlaySoundEffect ("Move");
			}
		}

		/// <summary>
		/// Controls the movement of the block to the left
		/// </summary>
		/// <param name="a">The alpha component.</param>
		public virtual void MoveLeft ()
		{
			X -= 20;
			if (X < 20)
			{
				X = 20;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}

		/// <summary>
		/// Controls the upward movement of the block
		/// </summary>
		/// <param name="a">The alpha component.</param>
		public virtual void MoveUp ()
		{
			Y -= 20;
			if (Y < 10)
			{
				Y = 10;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}

		/// <summary>
		/// Controls the movement of the block to the right
		/// </summary>
		/// <param name="a">The alpha component.</param>
		public virtual void MoveRight (int a)
		{
			X += 20;
			if (X > 400 - 40)
			{
				X = 400 - 40;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}

		/// <summary>
		/// Controls the downward movement of the block
		/// </summary>
		/// <param name="a">The alpha component.</param>
		public virtual void MoveDown (int a)
		{
			Y += 20;
			if (Y > 390 - 40)
			{
				Y = 390 - 40;
				SwinGame.LoadSoundEffectNamed ("Error","error.wav");
				SwinGame.PlaySoundEffect ("Error");
			}
		}

		/// <summary>
		/// Assign this squares to the block.
		/// </summary>
		public abstract void Assign();

		/// <summary>
		/// Assigns the edges of the blocks.
		/// </summary>
		public abstract void AssignEdges();
	}
}

