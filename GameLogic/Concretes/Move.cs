using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Concretes
{
    public class Move : IMove
    {
        /// <summary>
        /// Randomly selects integer between 1 & 5 and assigns enum value based on result
        /// </summary>
        /// <returns>computers move</returns>
        public Moves ComputerMove()
        {
            //computer move range 0-4 
            var rand = new Random();
            var computerMove = (Moves) rand.Next(0, 5); ;
            return computerMove;
        }
        /// <summary>
        /// parses player move input from console
        /// </summary>
        /// <returns>players move else 'invalid' enum value if invalid move</returns>
        public Moves HumanMove()
        {
            if (int.TryParse(Console.ReadLine(), out int playerMove) && playerMove > 0 && playerMove <= 5)
            {
                
                return (Moves)playerMove - 1; //-1 to zero index - moves are displayed 1-n

            }
            return Moves.Invalid;
           
        }
   

        /// <summary>
        /// if move is Spock or lizard swap the value
        /// </summary>
        /// <param name="moveOne">first move</param>
        /// <param name="moveTwo">second move</param>
        public void SwapIndex(ref Moves moveOne, ref Moves moveTwo)
        {
            //swap lizard & Spock moveOne
            if ((int)moveOne == 3)
            {
                moveOne = Moves.Spock;
            }
            else if ((int)moveOne == 4)
            {
                moveOne = Moves.Lizard;
            }
            //swap lizard & Spock moveTwo
            if ((int)moveTwo == 3)
            {
                moveTwo = Moves.Spock;
            }
            else if ((int)moveTwo == 4)
            {
                moveTwo = Moves.Lizard;
            }
        }


    }
}
