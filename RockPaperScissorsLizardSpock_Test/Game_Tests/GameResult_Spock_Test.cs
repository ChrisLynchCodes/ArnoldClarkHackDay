using Display.Interfaces;
using GameLogic.Concretes;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace RockPaperScissorsLizardSpock_Test
{
    //Tests all possible moves by Spock
    ////Denotes a class that contains unit tests
    [TestFixture]
    public class GameResult_Spock_Test
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
        /// Spock beats rock
        /// </summary>
        [Test]
        public void SpockVRock()
        {
            var result = game.GameResult(Moves.Spock, Moves.Rock);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Paper beats Spock
        /// </summary>
        [Test]
        public void SpockVPaper()
        {
            var result = game.GameResult(Moves.Spock, Moves.Paper);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        ///Spock beats scissors
        /// </summary>
        [Test]
        public void SpockVScissors()
        {
            var result = game.GameResult(Moves.Spock, Moves.Scissors);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Lizard beats Spock
        /// </summary>
        [Test]
        public void SpockVLizard()
        {
            var result = game.GameResult(Moves.Spock, Moves.Lizard);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Spock draws Spock
        /// </summary>
        [Test]
        public void SpockVSpock()
        {
            var result = game.GameResult(Moves.Spock, Moves.Spock);
            Assert.AreEqual(-1, result);
        }


    }
}