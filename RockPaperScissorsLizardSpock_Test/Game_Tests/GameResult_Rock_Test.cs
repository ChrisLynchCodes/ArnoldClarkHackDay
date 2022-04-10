using Display.Interfaces;
using GameLogic.Concretes;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace RockPaperScissorsLizardSpock_Test
{  //Tests all possible moves by Rock
    //Denotes a class that contains unit tests
    [TestFixture]
    public class GameResult_Rock_Test
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
        /// Paper beats rock 
        /// </summary>
        [Test]
        public void RockVPaper()
        {
            var result = game.GameResult(Moves.Rock, Moves.Paper);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Rock beats scissors
        /// </summary>
        [Test]
        public void RockVScissors()
        {
            var result = game.GameResult(Moves.Rock, Moves.Scissors);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        ///Rock beats lizard 
        /// </summary>
        [Test]
        public void RockVLizard()
        {
            var result = game.GameResult(Moves.Rock, Moves.Lizard);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Spock beats rock
        /// </summary>
        [Test]
        public void RockVSpock()
        {
            var result = game.GameResult(Moves.Rock, Moves.Spock);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Rock draws rock
        /// </summary>
        [Test]
        public void RockVRock()
        {
            var result = game.GameResult(Moves.Rock, Moves.Rock);
            Assert.AreEqual(-1, result);
        }
    }
}