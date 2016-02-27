using System;
using System.Collections;
namespace Snake
{
	/**
	 * It's base cell class, have position and symbol
	 * 
	 */
	public class Cell : Point
	{
		private char symbol;
		public Cell (int x,int y, char symbol):base (x,y)
		{
			this.symbol = symbol;
		}
		public void draw(){
			Console.SetCursorPosition(x,y);
			Console.WriteLine (symbol);
		}
		public void erase(){
			Console.SetCursorPosition(x,y);
			Console.WriteLine (" ");
		}
		public int getX(){
			return x;
		}
		public int getY(){
			return y;
		}
		public void setX(int x){
			base.x = x;
		}
		public void setY(int y){
			base.y = y;
		}
		public char getType(){
			return symbol;
		}
	}
	
}

