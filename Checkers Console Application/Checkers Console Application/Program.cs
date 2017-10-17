using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_Console_Application
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu();
		}

		static void Menu()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Clear();
			Console.WriteLine("Welcome to Draughts");
			Console.WriteLine("");
			Console.WriteLine("Please select one of the following options by inputting its number.");
			Console.WriteLine("1 - Player VS Player");
			Console.WriteLine("2 - Player VS Computer");
			Console.WriteLine("3 - Computer VS Computer");
			Console.WriteLine("4 - Exit Game");
			Console.WriteLine("");
			Console.WriteLine("Please Enter your choice");
			Console.ForegroundColor = ConsoleColor.White;

			try
			{
				int selection = Int32.Parse(Console.ReadLine());
				bool valid_number = false;

				while (valid_number != true)
				{
					if ((selection >= 1) && (selection <= 4))
					{
						valid_number = true;

						if (selection == 1)
						{
							Player_VS_Player.Players_Names(ref selection);
							break;
						}

						else if (selection == 2)
						{
							Player_VS_Player.Players_Names(ref selection);
							break;
						}

						else if (selection == 3)
						{
							break;
						}

						else if (selection == 4)
						{
							Environment.Exit(0);
							break;
						}
					}
					else
					{
						Console.WriteLine("");
						Console.WriteLine("Please enter a number between 1 and 4");
						selection = Int32.Parse(Console.ReadLine());
						valid_number = false;
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Enter numbers only", e);
				Console.WriteLine("Press Enter to continue ...");
				Console.ReadLine();
				Menu();
			}
		}



		//This Method creates the array that will be used throught the proccess to store all of the grid data
		public static void Board_Array()
		{
			int[,] array = new int[8, 8];
			Create_Board(ref array);
			View_Board(ref array);
			//test(ref array);
		}



		static void Create_Board(ref int[,] array)
		{
			for (int x = 0; x < 1; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 1;
					}
					else
					{
						array[x, y] = 0;
					}
				}
			}


			for (int x = 1; x < 2; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 0;
					}
					else
					{
						array[x, y] = 1;
					}
				}
			}


			for (int x = 2; x < 3; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 1;
					}
					else
					{
						array[x, y] = 0;
					}
				}
			}





			for (int x = 5; x < 6; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 0;
					}
					else
					{
						array[x, y] = 3;
					}
				}
			}


			for (int x = 6; x < 7; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 3;
					}
					else
					{
						array[x, y] = 0;
					}
				}
			}


			for (int x = 7; x < 8; x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (IsOdd(y))
					{
						array[x, y] = 0;
					}
					else
					{
						array[x, y] = 3;
					}
				}
			}
		}


		public static void View_Board(ref int[,] array)
		{

			//This block of code should be working but it is not and only checks what the first index of the array contains and then copys it fore the rest
			//this block of code is not in use due to it not fully working yet and when testing it takes ages to get past as its not fully implemented
			//for (int x = 0; x < 8; x++)
			//{
			//	for (int y = 0; y < 8; y++)
			//	{
			//		if (array[x, y] == 1)
			//		{
			//			Console.ForegroundColor = ConsoleColor.Blue;
			//			Console.Write( y + " ==1");
			//		}
			//		else if (array[x, y] == 0)
			//		{
			//			Console.ForegroundColor = ConsoleColor.White;
			//			Console.Write(y + " ==0");
			//			Console.Read();
			//		}
			//		else if (array[x, y] == 3)
			//		{
			//			Console.ForegroundColor = ConsoleColor.Red;
			//			Console.Write(y + " ==2");
			//			Console.Read();
			//		}
			//	}
			//}

			Console.Clear();
			Console.WriteLine("   " + "0" + " " + "1" + " " + "2" + " " + "3" + " " + "4" + " " + "5" + " " + "6" + " " + "7");
			Console.WriteLine();
			for (int x = 0; x < 8; x++)
			{
				Console.WriteLine(x + "  " +array[x, 0] + " " + array[x, 1] + " " + array[x, 2] + " " + array[x, 3] + " " + array[x, 4] + " " + array[x, 5] + " " + array[x, 6] + " " + array[x, 7]);
			}

			//if (turn == 1)
			//{
			Player_VS_Player.Player_Ones_Turn(ref array);
			//}
			//else if (turn == 2)
			//{
			Player_VS_Player.Player_Twos_Turn(ref array);
			//}
		}



		//Used to check if the 2d array's grid Y value is odd.
		public static bool IsOdd(int value)
		{
			return value % 2 != 0;
		}
	}
}
