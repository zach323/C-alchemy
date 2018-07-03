using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int curr_player = 1;
            char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            int user_input = 0;
            char p1_marker = 'x';
            char p2_marker = 'o';
            DisplayBoard(board);
            bool reset;
            bool win = CheckWin(board);
           
            while (win == false)
            {
                //game logic for player 1
                if (curr_player == 1 && win == false)
                {
                    Console.WriteLine("Enter your choice player {0}", curr_player);
                    try
                    {
                        user_input = Int16.Parse(Console.ReadLine());
                    }
                    catch (Exception) { }
                    Console.Clear();
                    UpdateBoard(board, p1_marker, user_input);
                    CheckWin(board);
                    if (CheckWin(board) == true)
                    {
                        reset = ResetGame(board);
                        if (reset == true)
                        {
                            board = ResetBoard();
                            win = false;
                        }
                    }
                    DisplayBoard(board);
                    curr_player = 2;

                   
                }
                //game logic for player 2
                else if (curr_player == 2 && win == false)
                {
                    Console.WriteLine("Enter your choice player {0}", curr_player);
                    try
                    {
                        user_input = Int16.Parse(Console.ReadLine());
                    }
                    catch (Exception) { }
                    Console.Clear();
                    UpdateBoard(board, p2_marker, user_input);
                    CheckWin(board);
                    if (CheckWin(board) == true)
                    {
                       reset = ResetGame(board);
                        if (reset == true)
                        {
                            board = ResetBoard();
                            win = false;
                        }
                    }
                    DisplayBoard(board);
                    curr_player = 1;
                }

            }
            Console.Read();
            
            
           

            }
        

       



        public static void UpdateBoard(char[,] brd, char p_marker, int p_choice)
        {
            switch (p_choice)
            {
                //verify user input and set player's x or o marker if area is not already occupied. 
                case 1:
                    if (brd[0,0]!= 'x' && brd[0, 0] != 'o')
                    {
                        brd[0, 0] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                    
                case 2:
                    if (brd[0, 1] != 'x' && brd[0, 1] != 'o')
                    {
                        brd[0, 1] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                    
                case 3:
                    if (brd[0, 2] != 'x' && brd[0, 2] != 'o')
                    {
                        brd[0, 2] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break; 
                    }
                 
                case 4:
                    if (brd[1, 0] != 'x' && brd[1, 0] != 'o')
                    {
                        brd[1, 0] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                    
                case 5:
                    if (brd[1, 1] != 'x' && brd[1, 1] != 'o')
                    {
                        brd[1, 1] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                    
                case 6:
                    if (brd[1, 2] != 'x' && brd[1, 2] != 'o')
                    {
                        brd[1, 2] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                   
                case 7:
                    if (brd[2, 0] != 'x' && brd[2, 0] != 'o')
                    {
                        brd[2, 0] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                  
                case 8:
                    if (brd[2, 1] != 'x' && brd[2, 1] != 'o')
                    {
                        brd[2, 1] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                   
                case 9:
                    if (brd[2, 2] != 'x' && brd[2, 2] != 'o')
                    {
                        brd[2, 2] = p_marker;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This spot is already occupied");
                        break;
                    }
                   
                default:
                    Console.WriteLine("Invalid input");
                    Console.Read();
                    break;
                    
            }
            //Console.Read();
            
        }



        public static void DisplayBoard(char[,] brd)
        {
            Console.WriteLine("     |      |     ");
            Console.WriteLine("  {0}  |  {1}   |   {2}", brd[0,0], brd[0,1], brd[0,2]);
            Console.WriteLine("_____|______|______");
            Console.WriteLine("     |      |     ");
            Console.WriteLine("  {0}  |  {1}   |   {2}", brd[1, 0], brd[1, 1], brd[1, 2]);
            Console.WriteLine("_____|______|______");
            Console.WriteLine("     |      |     ");
            Console.WriteLine("  {0}  |  {1}   |   {2}", brd[2, 0], brd[2, 1], brd[2, 2]);
            Console.WriteLine("     |      |     ");
            /*for (int row = 0; row < 3; row++)
            {
                
                for (int col = 0; col < 3; col++)
                {
                    if (col == 2)
                    {
                        Console.WriteLine(" " + brd[row, col]);
                    }
                    else
                    {
                        Console.Write("   " + brd[row, col] + "   |");
                    }
                }
                if(row < 2)
                {

                    Console.WriteLine("________________________");
                }
                
                Console.WriteLine();
            }*/
            

        }

        public static bool CheckWin(char[,] brd)
        {
            //check if player 1 wins
            if (brd[0,0] == 'x' && brd[0,1] == 'x' && brd[0,2] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[0, 0] == 'x' && brd[1, 0] == 'x' && brd[2, 0] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[1, 0] == 'x' && brd[1, 1] == 'x' && brd[1, 2] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[2, 0] == 'x' && brd[2, 1] == 'x' && brd[2, 2] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[0, 1] == 'x' && brd[1, 1] == 'x' && brd[2, 1] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[1, 2] == 'x' && brd[1, 1] == 'x' && brd[2, 0] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }
            else if (brd[0, 2] == 'x' && brd[1, 2] == 'x' && brd[2, 2] == 'x')
            {
                Console.WriteLine("Player 1 wins");
                return true;
            }

            //check if player 2 wins
            if (brd[0, 0] == 'o' && brd[0, 1] == 'o' && brd[0, 2] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[0, 0] == 'o' && brd[1, 0] == 'o' && brd[2, 0] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[1, 0] == 'o' && brd[1, 1] == 'o' && brd[1, 2] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[2, 0] == 'o' && brd[2, 1] == 'o' && brd[2, 2] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[0, 1] == 'o' && brd[1, 1] == 'o' && brd[2, 1] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[1, 2] == 'o' && brd[1, 1] == 'o' && brd[2, 0] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[0, 2] == 'o' && brd[1, 2] == 'o' && brd[2, 2] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else if (brd[0, 2] == 'o' && brd[1, 1] == 'o' && brd[2, 0] == 'o')
            {
                Console.WriteLine("Player 2 wins");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ResetGame(char[,] brd)
        {
            Console.WriteLine("Do you want to play again? Press \"y\" to play again. \"n\" to exit");

            string input = Console.ReadLine();
            input.ToLower();
            
            if (input == "y")
            {
                //for conditional testing if player wants to continue.
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        public static char[,] ResetBoard()
        {
            //reset board
            char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            return board;
        }
    }
}
