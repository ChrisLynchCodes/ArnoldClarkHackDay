using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display.Interfaces
{
    public interface IDisplay
    {
        void ExitGame(string playerName);
        void ExitGame();
        void GameMoves(Enum Moves);
        void GetScores(IList<int> scores, IList<string> playerNames);
        void GetWinner(int winner, string playerName, string moveOne, string moveTwo);
        void InvalidInput();
        void MainMenu();
        void MakeMove(string playerName);
        void NumberOfRounds(string playerName);
        void PlayAgain();
        void RequestPlayerName();
    }
}
