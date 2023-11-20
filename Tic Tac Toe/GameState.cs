using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Data;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe
{
    public class GameState
    {
        public Player[,] GameGrid { get; set; }
        public Player CurrentPlayer { get; set; }
        public int TurnPassed { get; set; }
        public bool GameOver { get; set; }

        public event Action<int, int> MoveMade;
        public event Action<GameResult> GameEnded;
        public event Action GameRestarted;

        public GameState()
        {
            GameGrid = new Player[3, 3];
            CurrentPlayer = Player.X;
            TurnPassed = 0;
            GameOver = false;
        }

        bool CanMakeMove(int r,int c) 
        {
            return !GameOver && GameGrid[r, c] == Player.None;
        }
    }
}
