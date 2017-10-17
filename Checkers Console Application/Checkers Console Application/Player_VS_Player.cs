using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_Console_Application
{
	class Player_VS_Player
	{
		public static void Players_Names(ref int selection)
		{
			//this class will most likely need to be renamed and recreated under the new name.
			// could be a good idea to move this code into the player interactions class and use that as a storage class for player inputs that are not specilised to one class type only (example like the AI vs Player methods)
			if (selection == 1)
			{
				string player_one, player_two;

				Console.WriteLine("Player One please enter your name ...");
				player_one = Console.ReadLine();

				Console.WriteLine("");
				Console.WriteLine("Player Two please enter your name ...");
				player_two = Console.ReadLine();
			}
			else if (selection == 2)
			{
				string player_solo;

				Console.WriteLine("Please enter your name ...");
				player_solo = Console.ReadLine();
			}

			Program.Board_Array();
		}




		public static void Player_Ones_Turn(ref int[,] array)
		{
			//getting a grid cords from the player and checking to make sure that it is correct.
			string cords, newcords;
			int a, b, c, d;
			bool valid_piece = false, valid_position = false;




			while (valid_piece == false)
			{
				Console.WriteLine(" Enter the position of the piece you wish to move.");
				cords = Console.ReadLine();

				string[] gridpoints = cords.Split(',');

				a = Convert.ToInt32(gridpoints[0]);
				b = Convert.ToInt32(gridpoints[1]);


				if ((array[a, b] == 1) || (array[a, b] == 2))
				{
					//check to make sure this piece can move.
					if (array[a, b] == 1)
					{

						if ((array[a + 1, b + 1] != 0) && (array[a + 1, b - 1] != 0))
						{
							valid_piece = false;
							Console.WriteLine("Selected piece is not able to move.");
							Console.WriteLine("Please pick another piece to move");
						}


						else if ((array[a + 1, b + 1] == 0) || (array[a - 1, b + 1] == 0))
						{
							valid_piece = true;
							Console.WriteLine("Please Enter the position which you want this piece to move to.");
							newcords = Console.ReadLine();

							string[] newgridpoints = newcords.Split(',');

							c = Convert.ToInt32(newgridpoints[0]);
							d = Convert.ToInt32(newgridpoints[1]);

							while (valid_position == false)
							{
								if ((array[c, d] != array[a + 1, b - 1]) || (array[c, d] != array[a + 1, b + 1]))
								{
									Console.WriteLine("This Piece cannot move to that position please pick a valid move.");
								}

								else
								{
									valid_position = true;
									array[a, b] = 0;
									array[c, d] = 1;
									Program.View_Board(ref array);
								}
							}
						}
					}


					else if (array[a, b] == 2)
					{
						valid_piece = true;
						if ((array[a - 1, b - 1] != 0) && (array[a - 1, b + 1] != 0) && (array[a + 1, b - 1] != 0) && (array[a + 1, b + 1] != 0))
						{
							Console.WriteLine("Selected piece is not able to move.");
							Console.WriteLine("Please pick another piece to move");
						}
					}
				}


				else if ((array[a, b] == 3) || (array[a, b] == 4))
				{
					valid_piece = false;
					Console.WriteLine("Please enter the position of your own piece");
				}


				else if (array[a, b] == 0)
				{
					valid_piece = false;
					Console.WriteLine("Please enter the position of one of your pieces.");
				}
			}
		}




		public static void Player_Twos_Turn(ref int[,] array)
		{
			//getting a grid cords from the player and checking to make sure that it is correct.
			string cords, newcords;
			int a, b, c, d;
			bool valid_piece = false, valid_position = false;




			while (valid_piece == false)
			{
				Console.WriteLine(" Enter the position of the piece you wish to move.");
				cords = Console.ReadLine();

				string[] gridpoints = cords.Split(',');

				a = Convert.ToInt32(gridpoints[0]);
				b = Convert.ToInt32(gridpoints[1]);


				if ((array[a, b] == 1) || (array[a, b] == 2))
				{
					//check to make sure this piece can move.
					if (array[a, b] == 1)
					{

						if ((array[a + 1, b + 1] != 0) && (array[a + 1, b - 1] != 0))
						{
							valid_piece = false;
							Console.WriteLine("Selected piece is not able to move.");
							Console.WriteLine("Please pick another piece to move");
						}


						else if ((array[a + 1, b + 1] == 0) || (array[a - 1, b + 1] == 0))
						{
							valid_piece = true;
							Console.WriteLine("Please Enter the position which you want this piece to move to.");
							newcords = Console.ReadLine();

							string[] newgridpoints = newcords.Split(',');

							c = Convert.ToInt32(newgridpoints[0]);
							d = Convert.ToInt32(newgridpoints[1]);

							while (valid_position == false)
							{
								if ((array[c, d] != array[a + 1, b - 1]) || (array[c, d] != array[a + 1, b + 1]))
								{
									Console.WriteLine("This Piece cannot move to that position please pick a valid move.");
								}

								else
								{
									valid_position = true;
									array[a, b] = 0;
									array[c, d] = 1;
									Program.View_Board(ref array);
								}
							}
						}
					}


					else if (array[a, b] == 2)
					{
						valid_piece = true;
						if ((array[a - 1, b - 1] != 0) && (array[a - 1, b + 1] != 0) && (array[a + 1, b - 1] != 0) && (array[a + 1, b + 1] != 0))
						{
							Console.WriteLine("Selected piece is not able to move.");
							Console.WriteLine("Please pick another piece to move");
						}
					}
				}


				else if ((array[a, b] == 3) || (array[a, b] == 4))
				{
					valid_piece = false;
					Console.WriteLine("Please enter the position of your own piece");
				}


				else if (array[a, b] == 0)
				{
					valid_piece = false;
					Console.WriteLine("Please enter the position of one of your pieces.");
				}
			}
		}
	}
}
