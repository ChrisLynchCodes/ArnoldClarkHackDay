using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Concretes
{
    public class Player : IPlayer
    {   
        /// <summary>
        /// The players name
        /// </summary>
          public string Name { get; set; }
    }
}
