using System;

namespace Snake
{
	public class HelloWorld
	{
		public HelloWorld ()
		{
			Console.WriteLine ("HelloWorld->constructor");

		}

		public void test ()
		{
			Console.WriteLine ("HelloWorld->test");
		}

		~HelloWorld ()
		{
			Console.WriteLine ("HelloWorld->destructor");
		}
	}
}
