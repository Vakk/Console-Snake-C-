using System;

namespace Snake
{
	public class Constants
	{
		// types
		public static char SNAKE_BODY = '•';
		public static char SNAKE_HEAD = 'O';
		public static char FOOD = '@';
		public static char WALL = '#';

		// directions
		public static int DIRECTION_UP=0;
		public static int DIRECTION_RIGHT=1;
		public static int DIRECTION_DOWN=2;
		public static int DIRECTION_LEFT=3;

		// game field
		public static int FIELD_HEIGHT = 20;
		public static int FIELD_WIDTH = 40;
	}
}

