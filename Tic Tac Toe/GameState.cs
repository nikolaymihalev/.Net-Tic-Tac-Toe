﻿using System;
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

        bool IsGridFull() 
        {
            return TurnPassed == 9;
        }

        void SwitchPlayer() 
        {
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }

        bool AreSquaresMarked((int, int)[] squares,Player player) 
        {
            foreach ((int r, int c) in squares)
            {
                if (GameGrid[r, c] != player)
                    return false;
            }
            return true;
        }

        bool DidMoveWin(int r,int c, out WinInfo winInfo) 
        {
            (int, int)[] row = new[] { (r, 0), (r, 1), (r, 2) };
            (int, int)[] col = new[] { (0, c), (1, c), (2, c) };
            (int, int)[] mainDiag = new[] { (0, 0), (1, 1), (2, 2) };
            (int, int)[] antiDiag = new[] { (0, 2), (1, 1), (2, 0) };

            if (AreSquaresMarked(row, CurrentPlayer)) 
            {
                winInfo = new WinInfo { Type = WinType.Row, Number = r};
                return true;
            }
            
            if (AreSquaresMarked(col, CurrentPlayer)) 
            {
                winInfo = new WinInfo { Type = WinType.Column, Number = c};
                return true;
            }
            
            if (AreSquaresMarked(mainDiag, CurrentPlayer)) 
            {
                winInfo = new WinInfo { Type = WinType.MainDiagonal};
                return true;
            }
            
            if (AreSquaresMarked(antiDiag, CurrentPlayer)) 
            {
                winInfo = new WinInfo { Type = WinType.AntiDiagonal};
                return true;
            }

            winInfo = null;
            return false;
        }
    }
}
