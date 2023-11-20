using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe.Data
{
    public class GameResult
    {
        public Player Winner { get; set; }
        public WinInfo WinInfo { get; set; }
    }
}
