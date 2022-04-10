using GameLogic.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Interfaces
{
    public interface IMove
    {
        Moves ComputerMove();
        Moves HumanMove();
        void SwapIndex(ref Moves moveOne, ref Moves moveTwo);
    }
}
