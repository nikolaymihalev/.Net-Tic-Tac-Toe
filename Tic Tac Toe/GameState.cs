using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe
{
    public class GameState
    {
        public Player[,] GameGrid { get; set; }
        public Player CurrentPlayer { get; set; }
        public int TurnPassed { get; set; }
        public bool GameOver { get; set; }
    }
}
