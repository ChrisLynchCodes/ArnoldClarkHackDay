using GameLogic.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    public interface IGame
    {
        IList<int> AddScore(int winner, IList<int> scores);
        int GameResult(Moves moveOne, Moves moveTwo);
        void MainMenu();
        void MakeMove();
        int NumberOfRounds();
        void PlayerInformation();
        void PlayGame(int numberOfRounds);
        void RestScore();
        public void StartGame();
        void StartRound(int numberOfRounds);
    }
}
