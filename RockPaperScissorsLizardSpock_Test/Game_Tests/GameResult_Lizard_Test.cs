using Display.Interfaces;
using GameLogic.Concretes;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace RockPaperScissorsLizardSpock_Test
{  //Tests all possible moves for Lizard
    //Denotes a class that contains unit tests
    [TestFixture]
    public class GameResult_Lizard_Test
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
        /// Rock beats lizard 
        /// </summary>
        [Test]
        public void LizardVRock()
        {
            var result = game.GameResult(Moves.Lizard, Moves.Rock);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Lizard beats paper
        /// </summary>
        [Test]
        public void LizardVPaper()
        {
            var result = game.GameResult(Moves.Lizard, Moves.Paper);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        ///Scissors beats lizard
        /// </summary>
        [Test]
        public void LizardVScissors()
        {
            var result = game.GameResult(Moves.Lizard, Moves.Scissors);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Lizard beats Spock
        /// </summary>
        [Test]
        public void LizardVSpock()
        {
            var result = game.GameResult(Moves.Lizard, Moves.Spock);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Rock draws rock
        /// </summary>
        [Test]
        public void LizardVLizard()
        {
            var result = game.GameResult(Moves.Lizard, Moves.Lizard);
            Assert.AreEqual(-1, result);
        }

    }
}