using Display.Interfaces;
using GameLogic.Concretes;
using GameLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;


namespace RockPaperScissorsLizardSpock_Test
{   //test all possible moves for Paper
    //Denotes a class that contains unit tests
    [TestFixture]
    public class GameResult_Paper_Test
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
        public void PaperVRock()
        {
            var result = game.GameResult(Moves.Paper, Moves.Rock);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Scissors beats paper
        /// </summary>
        [Test]
        public void PaperVScissors()
        {
            var result = game.GameResult(Moves.Paper, Moves.Scissors);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        ///Lizard beats paper
        /// </summary>
        [Test]
        public void PaperVLizard()
        {
            var result = game.GameResult(Moves.Paper, Moves.Lizard);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Paper beats Spock
        /// </summary>
        [Test]
        public void PaperVSpock()
        {
            var result = game.GameResult(Moves.Paper, Moves.Spock);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Paper draws papers
        /// </summary>
        [Test]
        public void PaperVPaperk()
        {
            var result = game.GameResult(Moves.Paper, Moves.Paper);
            Assert.AreEqual(-1, result);
        }

    }
}