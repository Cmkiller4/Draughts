using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_Console_Application
{
	//this class contains all of the player vs player interactions.
	class Player_VS_Player
	{
		// the Players_Names method is used to the player/players names so the program can use the players name instead of just player 1 and player 2.
		public static void Players_Names(ref int selection)
		{
			// when the user selects choice one from the menu method they will be displayed this option which will asked for two names, player 1 and player 2
			if (selection == 1)
			{
				string player_one, player_two;

				Console.WriteLine("Player One please enter your name ...");
				player_one = Console.ReadLine();

				Console.WriteLine("");
				Console.WriteLine("Player Two please enter your name ...");
				player_two = Console.ReadLine();
			}
			// when the user selects choice two from the menu method they will be displayed this option which only asks for one name as there will only be one human player
			else if (selection == 2)
			{
				string player_solo;

				Console.WriteLine("Please enter your name ...");
				player_solo = Console.ReadLine();
			}

			Program.Board_Array();
		}



		//this is the method that contains all of the interactions that are needed in order for the player one to be able to move and take pieces from the other player during the player vs player game.
		public static void Player_Ones_Turn(ref int[,] array)
		{
			//getting a grid cords from the player and checking to make sure that it is correct.
			//string cords, newcords;
			//int a, b, c, d;
			//bool valid_piece = false, valid_position = false, Game_Won = false;
			bool Game_Won = false;
			int turn = 0;

			do
			{
				string cords, newcords;
				int a, b, c, d;
				bool valid_piece = false, valid_position = false;
				if ((turn == 1) || (turn == 0))
				{

					//Player One turn
					//This part of the method is used to make sure Player Ones's choices are legal.
					//while loop is used to make that player one is cannot progress until they choose a valid piece that is theres to move.
					while (valid_piece == false)
					{
						InvalidMove:
						//asks for the grid position of the piece they wish to move.
						Console.WriteLine(" Player One Please Enter the position of the piece you wish to move.");
						cords = Console.ReadLine();


						//breaks down the users input so the array is able to use it.
						string[] gridpoints = cords.Split(',');

						a = Convert.ToInt32(gridpoints[0]);
						b = Convert.ToInt32(gridpoints[1]);


						//checks to make sure the selected piece is owned by player one.
						if ((array[a, b] == 1) || (array[a, b] == 2))
						{

							//check to make sure this piece can move.
							if (array[a, b] == 1)
							{

								//displays if the piece is unable to move.
								if ((array[a + 1, b + 1] != 0) && (array[a + 1, b - 1] != 0))
								{
									valid_piece = false;
									Console.WriteLine("Selected piece is not able to move.");
									Console.WriteLine("Please pick another piece to move");
								}


								//if the selected piece is able to move this asks the user where they wish to move the piece to.
								else if ((array[a + 1, b + 1] == 0) || (array[a - 1, b + 1] == 0))
								{
									valid_piece = true;
									Console.WriteLine("Player One Please Enter the position which you want this piece to move to.");
									newcords = Console.ReadLine();

									//like above this breaks down the users input so the array is able to use it as grid positions within the 2d array.
									string[] newgridpoints = newcords.Split(',');

									c = Convert.ToInt32(newgridpoints[0]);
									d = Convert.ToInt32(newgridpoints[1]);


									//this while loop makes sure that player one cannot progress until they select a valid position
									while (valid_position == false)
									{

										//if the position selected by player one is valid then this moves the piece into the selected grid position.
										//current system does not work fully
										//THE PLAYER CAN TAKE PIECES THAT SHOULD NOT BE ABLE TO BE TAKEN
										//EXAMPLE INSTEAD OF GOING DIAGONALY TO TAKE A PIECE, THE PIECE CAN MAKE A C SHAPE TO TAKE A PIECE
										//
										//
										//
										//The if statements need to be broken up and split into 2 diffrent if statements, this would cause the pieces to not be able to choose where they land meaning an invalid move cannot be made anymore.
										if ((array[c, d] == array[a + 1, b - 1]) || (array[c, d] == array[a + 1, b + 1]))
										{
											if ((array[c, d] == 3) || (array[c, d] == 4))
											{
												if ((array[c, d] == array[a + 1, b + 1]) && (array[c + 1, d + 1] == 0))
												{
													valid_position = true;
													array[a, b] = 0;
													array[c, d] = 0;
													array[c + 1, d + 1] = 1;
													turn = 2;
													Program.View_Board(ref array);
												}

												else if ((array[c, d] == array[a + 1, b - 1]) && (array[c + 1, d - 1] == 0))
												{
													valid_position = true;
													array[a, b] = 0;
													array[c, d] = 0;
													array[c + 1, d - 1] = 1;
													turn = 2;
													Program.View_Board(ref array);
												}

												else
												{
													Console.WriteLine("Invalid move, please select a valid move.");
													valid_piece = false;
													goto InvalidMove;
												}
											}
											else if ((array[c, d] == 0) || (array[c, d] == 0))
											{
												valid_position = true;
												array[a, b] = 0;
												array[c, d] = 1;
												turn = 2;
												Program.View_Board(ref array);
											}
										}

										else
										{
											Console.WriteLine("This Piece cannot move to that position please pick a valid move.");
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



				//Player Twos turn
				//This part of the method is used to make sure Player Twos's choices are legal.
				else if (turn == 2)
				{

					//while loop is used to make that player one is cannot progress until they choose a valid piece that is theres to move.
					while (valid_piece == false)
					{

						//asks for the grid position of the piece they wish to move.
						Console.WriteLine(" Player Two Please Enter the position of the piece you wish to move.");
						cords = Console.ReadLine();


						//breaks down the users input so the array is able to use it.
						string[] gridpoints = cords.Split(',');

						a = Convert.ToInt32(gridpoints[0]);
						b = Convert.ToInt32(gridpoints[1]);


						//checks to make sure the selected piece is owned by player one.
						if ((array[a, b] == 3) || (array[a, b] == 4))
						{

							//check to make sure this piece can move.
							if (array[a, b] == 3)
							{

								//displays if the piece is unable to move.
								if ((array[a - 1, b + 1] != 0) && (array[a - 1, b - 1] != 0))
								{
									if ((array[a - 1, b + 1] == 3) || (array[a - 1, b + 1] == 4) || (array[a - 1, b - 1] == 3) || (array[a - 1, b - 1] == 4))
									{
										valid_piece = true;
										Console.WriteLine("Player Two Please Enter the position which you want this piece to move to.");
										newcords = Console.ReadLine();

										//like above this breaks down the users input so the array is able to use it as grid positions within the 2d array.
										string[] newgridpoints = newcords.Split(',');

										c = Convert.ToInt32(newgridpoints[0]);
										d = Convert.ToInt32(newgridpoints[1]);


										//this while loop makes sure that player one cannot progress until they select a valid position
										//ERROR
										//ERROR
										//ERROR
										//ERROR contained within this part.
										while (valid_position == false)
										{
											if ((array[c, d] == 1) || (array[c, d] == 2))
											{
												if (array[c - 1, d + 1] == 0)
												{
													valid_position = true;
													array[a, b] = 0;
													array[c, d] = 0;
													array[c - 1, d + 1] = 3;
													turn = 1;
													Program.View_Board(ref array);
												}

												else if (array[c - 1, d - 1] == 0)
												{
													valid_position = true;
													array[a, b] = 0;
													array[c, d] = 0;
													array[c - 1, d - 1] = 3;
													turn = 1;
													Program.View_Board(ref array);
												}

												else
												{
													Console.WriteLine("Invalid move, please select a valid move.");
												}
											}
											else if ((array[c, d] == 0) || (array[c, d] == 0))
											{
												valid_position = true;
												array[a, b] = 0;
												array[c, d] = 3;
												turn = 1;
												Program.View_Board(ref array);
											}
										}
									}

									else
									{
										valid_piece = false;
										Console.WriteLine("Selected piece is not able to move.");
										Console.WriteLine("Please pick another piece to move");
									}
								}


								//if the selected piece is able to move this asks the user where they wish to move the piece to.
								else if ((array[a + 1, b + 1] == 0) || (array[a - 1, b + 1] == 0))
								{
									valid_piece = true;
									Console.WriteLine("Player Two Please Enter the position which you want this piece to move to.");
									newcords = Console.ReadLine();

									//like above this breaks down the users input so the array is able to use it as grid positions within the 2d array.
									string[] newgridpoints = newcords.Split(',');

									c = Convert.ToInt32(newgridpoints[0]);
									d = Convert.ToInt32(newgridpoints[1]);


									//this while loop makes sure that player one cannot progress until they select a valid position
									while (valid_position == false)
									{
										if ((array[c, d] == 1) || (array[c, d] == 2))
										{
											if (array[c - 1, d + 1] == 0)
											{
												valid_position = true;
												array[a, b] = 0;
												array[c, d] = 0;
												array[c - 1, d + 1] = 3;
												turn = 1;
												Program.View_Board(ref array);
											}

											else if (array[c - 1, d - 1] == 0)
											{
												valid_position = true;
												array[a, b] = 0;
												array[c, d] = 0;
												array[c - 1, d - 1] = 3;
												turn = 1;
												Program.View_Board(ref array);
											}

											else
											{
												Console.WriteLine("Invalid move, please select a valid move.");
											}
										}
										else if ((array[c, d] == 0) || (array[c, d] == 0))
										{
											valid_position = true;
											array[a, b] = 0;
											array[c, d] = 3;
											turn = 1;
											Program.View_Board(ref array);
										}
									}
								}
							}


							else if (array[a, b] == 4)
							{
								valid_piece = true;
								if ((array[a - 1, b - 1] != 0) && (array[a - 1, b + 1] != 0) && (array[a + 1, b - 1] != 0) && (array[a + 1, b + 1] != 0))
								{
									Console.WriteLine("Selected piece is not able to move.");
									Console.WriteLine("Please pick another piece to move");
								}
							}
						}


						else if ((array[a, b] == 1) || (array[a, b] == 2))
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


			while (Game_Won == false);

			//This could be made alot easier if i just turn the player one and player two methods into one larget method that would mean i dont need a complex system for choosing between the two methods.
			//Although this is alot more demanding for the System it solves the problem that is stopping me from continuing to program just now.
			//This system could be used in all 3 diffrent game modes as it allows for both users to move without changing anything within each items turn.
			//The way to achive this would be to have a while loop that will loop between the two players/computers/player and computer until there is a winner.
		}



		//this is the method that contains all of the interactions that are needed in order for the player two to be able to move and take pieces from the other player during the player vs player game.
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
