using Display.Interfaces;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Concretes
{
    public enum Moves { Rock, Paper, Scissors, Lizard, Spock, Invalid }
    public class Game : IGame
    {
        private readonly ILogger<Game> _logger;
        private readonly IDisplay _display;
        private readonly IPlayer _player;
        private readonly IMove _move;
        // private readonly IPlayer _playerTwo; - if implementing 2 human players
        private readonly List<int> _scores;



        /// <summary>
        /// Constructor - initialize _scores collection and get injected dependencies 
        /// </summary>
        /// <param name="logger">logger for application</param>
        /// <param name="display">injected IDisplay dependency</param>
        /// <param name="player">injected IPlayer dependency</param>
        /// <param name="move">injected IMove dependency</param>
        public Game(ILogger<Game> logger, IDisplay display, IPlayer player, IMove move)
        {
            _display = display;
            _player = player;
            _move = move;
            // _playerTwo = playerTwo;
            _logger = logger;
            _scores = new List<int> { 0, 0 };

        }



        /// <summary>
        ///StartGame acts as a container for the flow of the game
        /// </summary>
        public void StartGame()
        {
            _logger.LogInformation("LOG: Start Game");
            MainMenu();
            PlayerInformation();
            PlayGame(NumberOfRounds());
            _logger.LogInformation("LOG: End Game");

        }




        //Methods called in StartGame()


        /// <summary>
        ///Displays main menu & confirms user wishes to play via console input
        /// </summary>
        public void MainMenu()
        {

            bool continueLoop = false;
            do
            {
                //display main menu - prompts user to confirm they wish to play
                _display.MainMenu();
                var wantToStart = Console.ReadLine().ToUpper();

                if (wantToStart.Equals("Y"))//return to normal game flow in StartGame
                {

                    return;
                }
                else if (wantToStart.Equals("N"))//exit game
                {

                    if (_player.Name is not null)
                    {
                        _display.ExitGame(_player.Name);
                    }
                    else
                        _display.ExitGame();


                }
                else//invalid input ask again
                {

                    continueLoop = true;
                    _display.InvalidInput();
                }
            } while (continueLoop);
        }



        /// <summary>
        /// Gets player name - assigns to injected dependency _player.Name
        /// </summary>
        public void PlayerInformation()
        {
            var validName = false;
            do
            {
                //requests player name & ensures it is at least 1 character
                _display.RequestPlayerName();
                _player.Name = Console.ReadLine();
                if (_player.Name == "")
                {
                    Console.WriteLine("**Please enter at least one character** \n", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else
                {
                    validName = true;

                }
            } while (!validName);
        }



        /// <summary>
        /// prompts user to select number of rounds to play
        /// </summary>
        /// <returns>number of rounds selected</returns>
        public int NumberOfRounds()
        {
            while (true)
            {
                _display.NumberOfRounds(_player.Name);
                //ensure user input is integer & rounds in range 1 - 10
                if (int.TryParse(Console.ReadLine(), out int numberOfRounds) && numberOfRounds > 0 && numberOfRounds <= 10)
                {
                    return numberOfRounds;
                }

            }
        }



        /// <summary>
        /// the game is run for number of iterations specified in numberOfRounds param
        /// </summary>
        /// <param name="numberOfRounds">rounds to play</param>
        public void PlayGame(int numberOfRounds)
        {
            StartRound(numberOfRounds);
            PlayAgain();

        }




        //called from PlayGame()


        /// <summary>
        /// Asks player if they would like to play again & acts on player input
        /// </summary>
        public void PlayAgain()
        {
            string response;
            do
            {
                _display.PlayAgain();
                response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    RestScore();
                    PlayGame(NumberOfRounds());
                }
                else if (response == "N") //else if to continue loop when input != 'Y' or 'N'
                {
                    _display.ExitGame(_player.Name);
                }

            } while (response != "Y" || response != "N");
        }


        /// <summary>
        /// Starts the round & iterates for the provided number of rounds
        /// </summary>
        /// <param name="numberOfRounds">number of rounds player has selected</param>
        public void StartRound(int numberOfRounds)
        {
            for (int i = 1; i <= numberOfRounds; i++)
            {

                Console.WriteLine($"\nRound {i}");
                //prompt player to make move
                if (_player.Name is not null)
                {
                    _display.MakeMove(_player.Name);
                }


                MakeMove();


            }//End of round
        }

        /// <summary>
        /// prompts human move & generates computer move 
        /// </summary>
        public void MakeMove()
        {
            //init as false & make true if valid move is recorded
            bool validMove = false;
            do
            {   //display available moves pass in enum
                _display.GameMoves(new Moves());

                //get human move
                var moveOne = _move.HumanMove();

                if (moveOne != Moves.Invalid)
                {
                    validMove = true;
                    //get computer move
                    var moveTwo = _move.ComputerMove();
                    //get the winner of the two moves
                    var winner = GameResult(moveOne, moveTwo);

                    //display the winner & moves played
                    _display.GetWinner(winner, _player.Name, moveOne.ToString(), moveTwo.ToString());
                    //update the scores
                    UpdateScores(winner);


                }


            } while (!validMove);
        }



        /// <summary>
        /// calculates the winner of the round based of the index of the moves
        /// </summary>
        /// <param name="moveOne">index of first move</param>
        /// <param name="moveTwo">index of second move</param>
        /// <returns></returns>
        public int GameResult(Moves moveOne, Moves moveTwo)
        {
            //- [0]Rock, [1]Paper, [2]Scissors, [3]Spock, [4]Lizard
            //Listed as above and each assigned a zero based index
            //Evaluating the list cyclically as follows
            //Every move beats exactly 2 other moves - 2 index positions ahead   [2]Scissors beats +2 index[4]Lizard  - 2 index ahead (W)
            //And  4 index positions ahead/(1 behind)                            [2]Scissors beats +4 index[1]Paper   - 4 index ahead (W)
            //Every move is beaten by the move 1 index position ahead            [2]Scissors loses +1 index[3]Spock   - 1 index ahead (L)



            //Swap Spock and lizard 
            _move.SwapIndex(ref moveOne, ref moveTwo);

            //If move one - move two is odd the greater index wins
            var winner = ((int)moveOne - (int)moveTwo) % 2;

            if (winner == 0)//difference between both numbers is even
            {
                if (moveOne == moveTwo)// & numbers the same - draw 
                {
                    return -1;
                }
                else if (moveOne < moveTwo)//both numbers are not the same -- the smaller one wins
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else//difference between both numbers is odd -  the bigger one wins
            {
                if (moveOne > moveTwo)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }//end else

        }


        //Called from MakeMove()

        /// <summary>
        /// /update the scores collection & pass to display
        /// </summary>
        /// <param name="winner">winner of the round 0=move 1 --- 1 = move 2 ---- -1 = draw </param>
        public void UpdateScores(int winner)
        {

            AddScore(winner, _scores);
            _display.GetScores(_scores, new List<string>
                            {
                                _player.Name,
                                "Computer"
                            });
        }

        /// <summary>
        /// Adds to the score following a round
        /// </summary>
        /// <param name="winner">winner of round</param>
        /// <param name="scores">current scores</param>
        /// <returns></returns>
        public IList<int> AddScore(int winner, IList<int> scores)
        {
            if (winner == 0)//player won
            {
                _scores[0] += 1;
            }
            else if (winner == 1)//Computer/Player2 won
            {
                _scores[1] += 1;
            }
            else //draw
            {
                //if giving a point for a draw
                //_scores[0] += 1;
                //_scores[1] += 1;
            }

            return scores;
        }



        //Called from PlayAgain()
        /// <summary>
        /// Resets the scores to 0
        /// </summary>
        public void RestScore()
        {
            //assign all scores 0
            for (int i = 0; i < _scores.Count; i++)
            {
                _scores[i] = 0;
            }
        }
    }
}


//first implementation - extensible
//var winner = (5 + moveOne - moveTwo) % 5;
// 5+0-2 = 3 

//if (winner == 1 || winner == 3) //If the difference between both numbers is odd, moveOne wins
//{

//    return 0;
//}
//else if (winner == 2 || winner == 4)//If the difference between both numbers is even, move 2 wins
//{
//    return 1;
//}
//else //If both numbers are the same, 0
//{
//    return -1;
//}