using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class MoveValidator
    {
        public MoveValidator()
        {

        }

        public bool ValidateMove(char[] gameBoard, string playerInput, Player currentPlayer)
        {
            int.TryParse(playerInput, out int playerMove);

            if (gameBoard[playerMove - 1] == 'O' || gameBoard[playerMove - 1] == 'X')
            {
                return false;
            }

            return true;
        }
    }
}
