using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_Console_Application
{
	class Player_Interactions
	{
		public static void Player_Input(ref int[,] array)
		{
			//getting a grid cords from the player and checking to make sure that it is correct.
			string cords;
			int a, b;

			Console.WriteLine("Enter Grid Position");
			cords = Console.ReadLine();

			string[] gridpoints = cords.Split(',');

			a = Convert.ToInt32(gridpoints[0]);
			b = Convert.ToInt32(gridpoints[1]);

			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(array[a, b]);
		}

		static void Player_1_Turn()
		{
		}

		static void Player_2_Turn()
		{
		}
	}
}
