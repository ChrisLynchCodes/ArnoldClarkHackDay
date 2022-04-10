using Display.Interfaces;
using GameLogic.Concretes;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace RockPaperScissorsLizardSpock_Test
{  //Tests all possible moves for Scissors
    //Denotes a class that contains unit tests
    [TestFixture]
    public class GameResult_Scissors_Test
    {

        

        private Game game;

        private readonly Mock<ILogger<Game>> _mockLogger = new();
        private readonly Mock<IDisplay> _mockDisplay = new();
        private readonly Mock<IPlayer> _mockPlayer = new();
        private readonly IMove _move = new Move();


        /// <summary>
        /// inject mock dependencies into Game
        /// </summary>
        [SetUp]
        public void Setup() => game = new Game(_mockLogger.Object, _mockDisplay.Object, _mockPlayer.Object, _move);

        /// <summary>
        /// Rock beats Scissors
        /// </summary>
        [Test]
        public void ScissorsVRock()
        {
            var result = game.GameResult(Moves.Scissors, Moves.Rock);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Scissors beats paper
        /// </summary>
        [Test]
        public void ScissorsVPaper()
        {
            var result = game.GameResult(Moves.Scissors, Moves.Paper);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        ///Scissors beats lizard 
        /// </summary>
        [Test]
        public void ScissorsVLizard()
        {
            var result = game.GameResult(Moves.Scissors, Moves.Lizard);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Spock beats Scissors
        /// </summary>
        [Test]
        public void ScissorsVSpock()
        {
            var result = game.GameResult(Moves.Scissors, Moves.Spock);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Scissors draws Scissors
        /// </summary>
        [Test]
        public void ScissorsVScissors()
        {
            var result = game.GameResult(Moves.Scissors, Moves.Scissors);
            Assert.AreEqual(-1, result);
        }

    }
}