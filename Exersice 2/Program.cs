using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Exercise_2
{
    internal class Program
    {
        // Creating a TicTacToe Game with Classes
        public class Player
        {
            public string Name { get; }
            public bool IsCircle { get; }

            public Player(string name, bool isCircle)
            {
                Name = name;
                IsCircle = isCircle;
            }
        }

        public class Board
        {
            private bool?[,] boardArray = new bool?[3, 3];

            public Board()
            {
                // Initialize the board with null values
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        boardArray[i, j] = null;
                    }
                }
            }

            public bool PlayAt(Player player, int x, int y)
            {
                if (boardArray[x, y] == null)
                {
                    boardArray[x, y] = player.IsCircle;
                    return true;
                }
                else
                {
                    Console.WriteLine("The cell is already occupied!");
                    return false;
                }
            }

            public bool WinCheck(Player player)
            {
                
                for (int i = 0; i < 3; i++)
                {
                    // Checking rows
                    if (boardArray[i, 0] == player.IsCircle && boardArray[i, 1] == player.IsCircle && boardArray[i, 2] == player.IsCircle)
                        return true;

                    // Checking columns
                    if (boardArray[0, i] == player.IsCircle && boardArray[1, i] == player.IsCircle && boardArray[2, i] == player.IsCircle)
                        return true;
                }

                // Checking diagonals
                if ((boardArray[0, 0] == player.IsCircle && boardArray[1, 1] == player.IsCircle && boardArray[2, 2] == player.IsCircle) ||
                    (boardArray[0, 2] == player.IsCircle && boardArray[1, 1] == player.IsCircle && boardArray[2, 0] == player.IsCircle))
                {
                    return true;
                }

                return false;
            }

            public void DisplayBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (boardArray[i, j] == null)
                            Console.Write(" . ");
                        else if (boardArray[i, j] == true)
                            Console.Write(" O ");
                        else
                            Console.Write(" X ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    // Creating the players
                    Console.Write("Please enter your name for Player 1: ");
                    Player player1 = new Player(Console.ReadLine(), true);
                    Console.Clear();
                    Console.Write("Please enter your name for Player 2: ");
                    Player player2 = new Player(Console.ReadLine(), false);

                    // Creating the board
                    Board board = new Board();
                    int x, y;

                    // Main game loop
                    while (true)
                    {
                        Console.Clear();
                        board.DisplayBoard();

                        // Player 1's turn
                        Console.Write($"{player1.Name} (O), enter X: ");
                        x = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"{player1.Name} (O), enter Y: ");
                        y = Convert.ToInt32(Console.ReadLine());

                        if (board.PlayAt(player1, x, y))
                        {
                            if (board.WinCheck(player1))
                            {
                                Console.WriteLine($"{player1.Name} wins!");
                                Console.ReadLine();
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        Console.Clear();
                        board.DisplayBoard();

                        // Player 2's turn
                        Console.Write($"{player2.Name} (X), enter X: ");
                        x = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"{player2.Name} (X), enter Y: ");
                        y = Convert.ToInt32(Console.ReadLine());

                        if (board.PlayAt(player2, x, y))
                        {
                            if (board.WinCheck(player2))
                            {
                                Console.WriteLine($"{player2.Name} wins!");
                                Console.ReadLine();
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{e.Message} Press Enter to start over!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
