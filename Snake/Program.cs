using System;
using System.Threading;
namespace Snake
{
	class Game
	{

		private const int SPEED = 200;
		private static bool stop = false;
		private static int direction;
		private static int correctDirection;

		public static void Main (string[] args)
		{
			drawWall ();
			startGame ();
		}

		/**
		 * Create new snake
		 * */
		private static void startGame ()
		{
			Snake snake = new Snake ();
			direction = snake.getDirection ();
			// set key listener in new thread,
			Thread listener = new Thread (setListener);
			listener.Start ();
			snake.setDirection (Constants.DIRECTION_UP);
			while (!stop) {
				System.Threading.Thread.Sleep (SPEED);
				snake.setDirection ((int)direction);
				correctDirection = snake.getDirection ();
				if (!snake.move ()) {
					listener.Abort ();
					stop = true;
				}
			};
		}

		/**
		 * we set listeners for check move
		 * 
			*/
		public static void setListener ()
		{
			while (!stop) {
				ConsoleKeyInfo info = Console.ReadKey (true);
				if (info.KeyChar == 'w') {
					if (correctDirection != Constants.DIRECTION_DOWN) {
						direction = Constants.DIRECTION_UP;
					}
				} else if (info.KeyChar == 'a') {
					if (correctDirection != Constants.DIRECTION_RIGHT) {
						direction = Constants.DIRECTION_LEFT;
					}
				} else if (info.KeyChar == 's') {
					if (correctDirection != Constants.DIRECTION_UP) {
						direction = Constants.DIRECTION_DOWN;
					}
				} else if (info.KeyChar == 'd') {
					if (correctDirection != Constants.DIRECTION_LEFT) {
						direction = Constants.DIRECTION_RIGHT;
					}
				}
			}
		}

		/**
		 * draw borders for world
		 * */
		public static void drawWall ()
		{
			for (int i = 0; i <= Constants.FIELD_WIDTH; i++) {
				Console.SetCursorPosition (i, 0);
				Console.Write (Constants.WALL);
				Console.SetCursorPosition (i, Constants.FIELD_HEIGHT);
				Console.Write (Constants.WALL);
			}
			for (int i = 0; i < Constants.FIELD_HEIGHT; i++) {
				Console.SetCursorPosition (0, i);
				Console.Write (Constants.WALL);
				Console.SetCursorPosition (Constants.FIELD_WIDTH, i);
				Console.Write (Constants.WALL);
			}
		}
	}
}