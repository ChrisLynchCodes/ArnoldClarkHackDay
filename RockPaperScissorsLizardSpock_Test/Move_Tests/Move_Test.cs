using GameLogic.Concretes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock_Test.Move_Tests
{

    //Denotes a class that contains unit tests
    [TestFixture]
    public class Move_Test
    {

        private Move move;
        [SetUp]
        public void Setup() => move = new Move();


        /// <summary>
        /// Tests computer move is valid
        /// </summary>
        [Test]
        public void ComputerValidMove()
        {
            var validMove = move.ComputerMove();
            Assert.AreNotEqual("Invalid", validMove.ToString());
        }





        /// <summary>
        /// Tests Spock is successfully swapped with lizard
        /// </summary>
        [Test]
        public void SwapIndexSpock()
        {
            var spock = Moves.Spock;
            var lizard = Moves.Lizard;

            move.SwapIndex(ref spock, ref lizard);

            //check Spock successfully swaps with lizard
            Assert.AreEqual(Moves.Lizard, spock);

        }


        /// <summary>
        /// Tests Lizard is successfully swapped with Spock
        /// </summary>
        [Test]
        public void SwapIndexLiazrd()
        {
            var spock = Moves.Spock;
            var lizard = Moves.Lizard;




            move.SwapIndex(ref lizard, ref spock);

            Assert.AreEqual(Moves.Spock, lizard);

        }


        /// <summary>
        /// Tests when a no swap move set is entered 
        /// </summary>
        [Test]
        public void NoSwapPerformed()
        {
            var rock = Moves.Rock;
            var paper = Moves.Paper;




            move.SwapIndex(ref rock, ref paper);

            Assert.AreEqual(0, (int)rock);
            Assert.AreEqual(1, (int)paper);

        }
    }
}
