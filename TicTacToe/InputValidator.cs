using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class InputValidator
    {
        private readonly int _minVal = 1;
        private readonly int _maxVal = 9;
        private int _output;

        public InputValidator()
        {

        }

        public bool InputValidation(string playerInput)
        {
            if (int.TryParse(playerInput, out _output) && IsInBound(playerInput))
            {
                return true;
            }

            return false;
        }

        public bool IsInBound(string playerInput)
        {
            if (_output >= _minVal && _output <= _maxVal)
            {
                return true;
            }

            return false;
        }
    }
}
