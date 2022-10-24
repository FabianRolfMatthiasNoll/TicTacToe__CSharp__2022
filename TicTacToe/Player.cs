using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public char Symbol { get; set; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }
    }
}
