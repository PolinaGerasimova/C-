namespace Mazes
{
	public static class SnakeMazeTask
	{
		private static void MoveToTillEnd(Robot robot, int length, Direction direction)
		{
			MoveAside(robot, length, direction);
			if (!robot.Finished) MoveDown(robot, direction);
		}

		public static void MoveAside(Robot robot, int length, Direction direction)
		{
			for (int i = 0; i < length; i++) robot.MoveTo(direction);
		}

		public static void MoveDown(Robot robot, Direction direction)
		{
			for (int i = 0; i < 2; i++) robot.MoveTo(Direction.Down);			
		}

		public static void MoveOutVariants(Robot robot, int width, int i)
		{	
			if (i % 4 == 0) MoveToTillEnd(robot, width - 3, Direction.Right);
			else if (i % 2 == 0) MoveToTillEnd(robot, width - 3, Direction.Left);
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
			for (int i = 0; i < height - 2; i++) MoveOutVariants(robot, width, i);			
		}
	}
}