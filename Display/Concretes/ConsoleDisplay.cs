using Display.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Display.Concretes
{

    //Provides display methods to Game class. No user interaction in here.
    public class ConsoleDisplay : IDisplay
    {


        /// <summary>
        /// Display the main menu on program start
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("Welcome to the \"Rock Paper Scissors Lizard Spock\".\n");
            Thread.Sleep(500);
            Console.Write("Do you want to start a game? [Y/N] -- ");



        }

        /// <summary>
        /// Display the current scores
        /// </summary>
        /// <param name="scores">player scores</param>
        /// <param name="playerNames">player names</param>
        public void GetScores(IList<int> scores, IList<string> playerNames)
        {
            if (scores.Count > 0 && playerNames.Count > 0)
            {
                Console.Write("\nScores - ", Console.ForegroundColor = ConsoleColor.White);
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.Write($"{playerNames[i]}:{scores[i]}  ");
                }
                Console.WriteLine("", Console.ForegroundColor = ConsoleColor.Green);
            }

        }
        /// <summary>
        ///Display  the winner of the round
        /// </summary>
        /// <param name="winner">"0 = player", "1 = computer", "-1 = draw"</param>
        /// <param name="playerName">players name</param>
        /// <param name="moves">valid moves</param>
        /// <param name="moveOne">player move</param>
        /// <param name="moveTwo">computer move</param>
        public void GetWinner(int winner, string playerName, string moveOne, string moveTwo)
        {

            if (winner == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{playerName} wins {moveOne} beats {moveTwo}");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (winner == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nComputer wins {moveTwo} beats {moveOne}");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nIt was a draw - {moveOne} draws with {moveTwo}");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        /// <summary>
        ///Display Exit the game before giving name
        /// </summary>
        public void ExitGame()
        {

            Console.WriteLine($"Goodbye, thanks for playing");
            Environment.Exit(0);


        }
        /// <summary>
        /// overloading ExitGame() called after player has provided name
        /// </summary>
        /// <param name="playerName">players name</param>
        public void ExitGame(string playerName)
        {
            if (playerName is not null)
            {
                Console.WriteLine($"Goodbye {playerName}, thanks for playing");
                Environment.Exit(0);
            }

        }
        /// <summary>
        /// Display Invalid input
        /// </summary>
        public void InvalidInput()
        {
            Console.WriteLine("Invalid selection please try again\n");
        }
        /// <summary>
        /// display valid moves
        /// </summary>
        /// <param name="Moves">enum of valid moves</param>
        public void GameMoves(Enum Moves)
        {

            if (Moves is not null)
            {
                //for every move in the enum display the move and its index+1
                foreach (var move in Enum.GetValues(Moves.GetType()))
                {
                    if(move.ToString() != "Invalid")
                    {
                        Console.Write($"[{(int)move + 1}]{move} ", Console.ForegroundColor = ConsoleColor.Cyan);
                    }
                   

                }
                Console.Write("\n", Console.ForegroundColor = ConsoleColor.Green);


            }

        }
        /// <summary>
        /// Display play again
        /// </summary>
        public void PlayAgain()
        {
            Console.WriteLine("Play Again? [Y] [N]\n");

        }
        /// <summary>
        /// Display make your move 
        /// </summary>
        /// <param name="playerName">players name</param>
        public void MakeMove(string playerName)
        {
            if (playerName is not null)
            {
                Console.WriteLine($"Make your move {playerName}");
            }

        }
        /// <summary>
        /// Display request the players name
        /// </summary>
        public void RequestPlayerName()
        {
            Console.WriteLine("Please enter your name");
        }

        /// <summary>
        /// Display request for number of rounds to play
        /// </summary>
        /// <param name="playerName">players name</param>
        public void NumberOfRounds(string playerName)
        {
            if (playerName is not null)
            {
                Console.WriteLine($"How many rounds would you like to play {playerName}? 1-10?");

            }
        }
    }

}
