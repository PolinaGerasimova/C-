namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveTo(Robot robot, int size, Direction direction)
		{
			for (int i = 0; i < size; i++)
			robot.MoveTo(direction);
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
			MoveTo(robot, width - 3, Direction.Right);
			MoveTo(robot, height - 3, Direction.Down);
		}
	}
}