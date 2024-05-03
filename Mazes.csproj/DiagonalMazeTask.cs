using System;
using System.Windows.Forms;

namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static int Steps(int x, int y)
		{
			return (x - 3) / (y - 3);
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				var direction = new Direction();
				var direction1 = new Direction();
				SideToStep(robot, width, height, direction, direction1);
			}
		}
		public static void SideToStep(Robot robot, int width, int height, Direction direction, Direction direction1)
		{
			if (width > height)
			{
				CountToStep(robot, width, height, Direction.Right, Direction.Down);
			}

			else
				CountToStep(robot, height, width, Direction.Down, Direction.Right);
		}

		public static void CountToStep(Robot robot, int x, int y, Direction direction, Direction direction1)
		{			
			for (int i = 0; i < Steps(x, y); i++)
				robot.MoveTo(direction);
			if (!robot.Finished) robot.MoveTo(direction1);
		}
	}
}