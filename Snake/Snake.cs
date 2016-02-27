using System;
using System.Collections;

namespace Snake
{
	/**
		 Our snake. Can move, eat
	*/
	public class Snake
	{
		// snake direction. Can be up,right,down,left
		private int direction;
		// massive of snake body
		private ArrayList body;
		// object for food. Have coordinates x,y and symbol for show
		private Cell food;
		private bool isFood = false;

		/**
		 * Create snake, snake heave head and body
		 * */
		public Snake ()
		{
			body = new ArrayList ();
			body.Add (new Cell (9, 11, Constants.SNAKE_HEAD));
			body.Add (new Cell (10, 11, Constants.SNAKE_BODY));
			body.Add (new Cell (10, 12, Constants.SNAKE_BODY));
			body.Add (new Cell (10, 13, Constants.SNAKE_BODY));
			direction = Constants.DIRECTION_UP;
			drawSnake ();
			placeFood ();
		}

		/**
		 * place new food on field
		 */
		private void placeFood ()
		{
			Random random = new Random ();
			food = new Cell (0, 0, Constants.FOOD);
			food.setX (random.Next (Constants.FIELD_WIDTH - 10) + 5);
			food.setY (random.Next (Constants.FIELD_HEIGHT - 6) + 3);
			food.draw ();
		}

		/**
		 * set direction for move
		 */
		public void setDirection (int direction)
		{
			this.direction = direction;
		}

		/**
		 * moves snake in a given direction
		 */
		public bool move ()
		{
			erase ();
			if (!isBarrier ((Cell)body [0])) {
				for (int i = body.Count - 1; i >= 0; i--) {
					Cell obj = (Cell)body [i];

					if (isFood && i == body.Count - 1) {
						body.Add (new Cell (obj.getX (), obj.getY (), Constants.SNAKE_BODY));
					}
					if (obj.getType ().Equals (Constants.SNAKE_HEAD)) {
						switch (direction) {
						case (0):
							{
								obj.setY (obj.getY () - 1);
								break;
							}
						case (1):
							{
								obj.setX (obj.getX () + 1);
								break;
							}
						case (2):
							{
								obj.setY (obj.getY () + 1);
								break;
							}
						case (3):
							{
								obj.setX (obj.getX () - 1);
								break;
							}
						}
					} else {
						Cell previous = (Cell)body [i - 1];
						obj.setX (previous.getX ());
						obj.setY (previous.getY ());
					}
				}
				drawSnake ();
				if (isFood) {
					isFood = false;
					placeFood ();
				}
				return true;
			}
			return false;
		}

		/**
		 * delete snake
		 */
		private void erase ()
		{
			foreach (Cell obj in body) {
				obj.erase ();
			}

		}

		/**
		 * check cell for obstruction
		 */
		private bool isBarrier (Cell head)
		{
			int x;
			int y;
			x = head.getX ();
			y = head.getY ();
			if (x <= 1 || x >= Constants.FIELD_WIDTH - 1) {
				return true;
			} else if (y <= 1 || y >= Constants.FIELD_HEIGHT - 1) {
				return true;
			} else if (x == food.getX () && y == food.getY ()) {
				isFood = true;
			}
			foreach (Cell obj in body) {
				if (!obj.getType ().Equals (Constants.SNAKE_HEAD)) {
					if (obj.getX () == x && obj.getY () == y) {
						return true;
					}
				}
			}
			return false;
		}

		/**
		 * get current direction
		 */
		public int getDirection ()
		{
			return direction;
		}

		/**
		 * draw snake and food
		 */
		private void drawSnake ()
		{
			foreach (Cell obj in body) {
				obj.draw ();
			}
			if (food != null) {
				food.draw ();
			}
		}
	}
}
