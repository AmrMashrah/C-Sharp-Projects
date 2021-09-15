using System;

namespace TicTacToe2
{
    class Program
    {
        static void Main(string[] args)
        {
            int status = 0;
            int player = -1;
            char[] markers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                player = players(player);
                printBoard(markers, player);
                Engine(markers, player);
                status = checkWin(markers);
            } while (status.Equals(0));
            Console.Clear();
            printBoard(markers, player);
            if (status.Equals(1))
            {
                Console.WriteLine($"Player {player} is the winner!");
            }
            if (status.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
            }
        }
        static int players(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        static char playerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }
        static int checkWin(char[] gameMarkers)
        {
            if (winner(gameMarkers))
            {
                return 1;
            }
            if (checkDraw(gameMarkers))
            {
                return 2;
            }
            return 0;
        }
        static void printBoard(char[] gameMarkers, int player)
        {
            Console.WriteLine("Welcome to the Super Duper Tic Tac Toe Game!");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine($"Player {player} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
            Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");
        }
        static void Engine(char[] gameMarkers, int player)
        {
            bool notValidMove = true;
            do
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) &&
                      (userInput.Equals("1") ||
                      userInput.Equals("2") ||
                      userInput.Equals("3") ||
                      userInput.Equals("4") ||
                      userInput.Equals("5") ||
                      userInput.Equals("6") ||
                      userInput.Equals("7") ||
                      userInput.Equals("8") ||
                      userInput.Equals("9")))
                {
                    int.TryParse(userInput, out var Marker);
                    char currentMarker = gameMarkers[Marker - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        gameMarkers[Marker - 1] = playerMarker(player);
                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }
       
        static bool sameMarkers(char[] gameMarkers, int pos1, int pos2, int pos3)
        {
            return gameMarkers[pos1].Equals(gameMarkers[pos2]) && gameMarkers[pos2].Equals(gameMarkers[pos3]);
        }
        static bool checkDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                  gameMarkers[1] != '2' &&
                  gameMarkers[2] != '3' &&
                  gameMarkers[3] != '4' &&
                  gameMarkers[4] != '5' &&
                  gameMarkers[5] != '6' &&
                  gameMarkers[6] != '7' &&
                  gameMarkers[7] != '8' &&
                  gameMarkers[8] != '9';
        }
        static bool winner(char[] gameMarkers)
        {
            if (sameMarkers(gameMarkers, 0, 1, 2))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 3, 4, 5))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 6, 7, 8))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 0, 3, 6))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 1, 4, 7))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 2, 5, 8))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 0, 4, 8))
            {
                return true;
            }
            if (sameMarkers(gameMarkers, 2, 4, 6))
            {
                return true;
            }
            return false;
        }
    }
}
