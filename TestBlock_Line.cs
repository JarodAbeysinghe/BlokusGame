using System;
using SwinGameSDK;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class TestBlock_Line
	{
		[Test()]
		public void TestInitialisation()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			Assert.AreEqual (20,TestBlock.X);
			Assert.AreEqual (10,TestBlock.Y);
			Assert.AreEqual (20,TestBlock.Length);
			Assert.AreEqual (4,TestBlock.Size);
			Assert.AreEqual (false,TestBlock.Used);

			TestBlock.Used = true;
			Assert.AreEqual (true, TestBlock.Used);
		}
		[Test()]
		public void TestAssign()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();
			for (int i = 0; i < TestBlock.Squares.Count; i++)
			{
				Assert.AreEqual (20+ i*TestBlock.Length,TestBlock.Squares[i].X);
				Assert.AreEqual (10,TestBlock.Squares[i].Y);
			}

			TestBlock.Rotate = true;
			TestBlock.Assign ();
			for (int i = 0; i < TestBlock.Squares.Count; i++)
			{
				Assert.AreEqual (10+ i*TestBlock.Length,TestBlock.Squares[i].Y);			
				Assert.AreEqual (20,TestBlock.Squares[i].X);
			}
		}
		[Test()]
		public void TestMoveRight()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();

			Assert.AreEqual (20, TestBlock.X);
			int x = 20* (TestBlock.Size-1);

			TestBlock.MoveRight (x);
			TestBlock.MoveRight (x);

			Assert.AreEqual (60, TestBlock.X);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveRight (x);
			
			Assert.AreEqual (400-x, TestBlock.X);

			//Testing After Block is Rotated
			TestBlock.Rotate = true;
			TestBlock.Assign ();

			Assert.AreEqual (400-x, TestBlock.X);

			TestBlock.MoveRight (x);
			TestBlock.MoveRight (x);

			Assert.AreEqual (400-x +40, TestBlock.X);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveRight (x);

			Assert.AreEqual (400, TestBlock.X);
		}
		[Test()]
		public void TestMoveLeft()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();

			Assert.AreEqual (20, TestBlock.X);
			int x = 20* (TestBlock.Size-1);

			TestBlock.MoveLeft ();
			TestBlock.MoveLeft ();

			Assert.AreEqual (20, TestBlock.X);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveLeft ();

			Assert.AreEqual (20, TestBlock.X);

			//Testing After Block is Rotated
			TestBlock.Rotate = true;
			TestBlock.Assign ();

			Assert.AreEqual (20, TestBlock.X);

			TestBlock.MoveLeft ();
			TestBlock.MoveLeft ();

			Assert.AreEqual (20, TestBlock.X);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveLeft ();

			Assert.AreEqual (20, TestBlock.X);
		}
		[Test()]
		public void TestMoveUp()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();

			Assert.AreEqual (10, TestBlock.Y);
			int x = 20* (TestBlock.Size-1);

			TestBlock.MoveUp ();
			TestBlock.MoveUp ();

			Assert.AreEqual (10, TestBlock.Y);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveUp ();

			Assert.AreEqual (10, TestBlock.Y);

			//Testing After Block is Rotated
			TestBlock.Rotate = true;
			TestBlock.Assign ();

			Assert.AreEqual (10, TestBlock.Y);

			TestBlock.MoveUp ();
			TestBlock.MoveUp ();

			Assert.AreEqual (10, TestBlock.Y);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveUp ();

			Assert.AreEqual (10, TestBlock.Y);
		}
		[Test()]
		public void TestMoveDown()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();

			Assert.AreEqual (10, TestBlock.Y);
			int x = 20* (TestBlock.Size-1);

			TestBlock.MoveDown (x);
			TestBlock.MoveDown (x);

			Assert.AreEqual (50, TestBlock.Y);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveDown (x);

			Assert.AreEqual (390, TestBlock.Y);

			//Testing After Block is Rotated
			TestBlock.Rotate = true;
			TestBlock.Assign ();

			Assert.AreEqual (390, TestBlock.Y);

			TestBlock.MoveDown (x);
			TestBlock.MoveDown (x);

			Assert.AreEqual (390, TestBlock.Y);

			for(int i =0; i<30 ; i++)
				TestBlock.MoveDown (x);

			Assert.AreEqual (390, TestBlock.Y);
		}
		[Test()]
		public void TestMovement()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();

			Assert.AreEqual (20, TestBlock.X);
			Assert.AreEqual (10, TestBlock.Y);
			int x = 20* (TestBlock.Size-1);

			for(int i =0; i< 2; i++)
				TestBlock.MoveDown (x);

			for(int i =0; i< 4; i++)
				TestBlock.MoveRight (x);
					
			Assert.AreEqual (20 + 20*4, TestBlock.X);
			Assert.AreEqual (10 + 20*2, TestBlock.Y);

			for(int i =0; i< 3; i++)
				TestBlock.MoveLeft ();

			Assert.AreEqual (20 + 20*4 - 20*3, TestBlock.X);
			Assert.AreEqual (50, TestBlock.Y);

			for(int i =0; i< 5; i++)
				TestBlock.MoveUp ();

			Assert.AreEqual (20 + 20*4 - 20*3, TestBlock.X);
			Assert.AreEqual (10, TestBlock.Y);

			//Tesing After Rotaion
			TestBlock.Rotate = true;
			TestBlock.Assign ();

			for(int i =0; i< 30; i++)
				TestBlock.MoveDown (x);
			
			Assert.AreEqual (20 + 20*4 - 20*3, TestBlock.X);
			Assert.AreEqual (390 - x, TestBlock.Y);

			for(int i =0; i< 30; i++)
				TestBlock.MoveRight (x);

			Assert.AreEqual (400, TestBlock.X);
			Assert.AreEqual (390 - x, TestBlock.Y);


		}
		[Test()]
		public void TestTopEdgeAssign()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();
			TestBlock.AssignEdges ();
			foreach (Point2D rte in TestBlock.TopRightEdges)
			{
				Assert.AreEqual (20+ 20*TestBlock.Size,rte.X);
				Assert.AreEqual (10,rte.Y);
			}
			foreach (Point2D lte in TestBlock.TopLeftEdges)
			{
				Assert.AreEqual (20 ,lte.X);
				Assert.AreEqual (10,lte.Y);
			}

			//test after Rotation
			TestBlock.Rotate = true;
			TestBlock.AssignEdges ();
			foreach (Point2D rte in TestBlock.TopRightEdges)
			{
				Assert.AreEqual (20 + TestBlock.Length,rte.X);
				Assert.AreEqual (10,rte.Y);
			}
			foreach (Point2D lte in TestBlock.TopLeftEdges)
			{
				Assert.AreEqual (20 ,lte.X);
				Assert.AreEqual (10,lte.Y);
			}
		}

		[Test()]
		public void TestBottomEdgeAssign()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();
			TestBlock.AssignEdges ();
			foreach (Point2D rbe in TestBlock.BottomRightEdges)
			{
				Assert.AreEqual (20+ 20*TestBlock.Size ,rbe.X);
				Assert.AreEqual (10 + TestBlock.Length,rbe.Y);
			}
			foreach (Point2D lbe in TestBlock.BottomLeftEdges)
			{
				Assert.AreEqual (20 ,lbe.X);
				Assert.AreEqual (10+ TestBlock.Length,lbe.Y);
			}

			//test after Rotation
			TestBlock.Rotate = true;
			TestBlock.AssignEdges ();
			foreach (Point2D rbe in TestBlock.BottomRightEdges)
			{
				Assert.AreEqual (20 + TestBlock.Length,rbe.X);
				Assert.AreEqual (10+ 20*TestBlock.Size,rbe.Y);
			}
			foreach (Point2D lbe in TestBlock.BottomLeftEdges)
			{
				Assert.AreEqual (20 ,lbe.X);
				Assert.AreEqual (10+ 20*TestBlock.Size,lbe.Y);
			}
		}
		[Test()]
		public void TestEdgesAndMovement()
		{
			Block TestBlock = new Block_Line (Color.Blue,20,10,20,4,1);
			TestBlock.Rotate = false;
			TestBlock.Assign ();
			TestBlock.AssignEdges ();
			int x = 20* (TestBlock.Size-1);

			TestBlock.MoveRight (x);
			TestBlock.MoveRight (x);
			TestBlock.MoveRight (x);
			TestBlock.AssignEdges ();

			foreach (Point2D lte in TestBlock.TopLeftEdges)
			{
				Assert.AreEqual (20 + 20*3 ,lte.X);
				Assert.AreEqual (10,lte.Y);
			}

			TestBlock.MoveDown (x);
			TestBlock.MoveDown (x);
			TestBlock.AssignEdges ();

			foreach (Point2D rbe in TestBlock.BottomRightEdges)
			{
				Assert.AreEqual (20+ 20*TestBlock.Size + 20*3,rbe.X);
				Assert.AreEqual (10 + TestBlock.Length + 20*2,rbe.Y);
			}
		}
	}
}

