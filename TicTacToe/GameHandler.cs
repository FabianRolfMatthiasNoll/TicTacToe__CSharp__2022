using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameHandler
    {
        private readonly char[] _gameField;
        private readonly Player _playerX;
        private readonly Player _playerO;
        private readonly Player _currentPlayer;


        public GameHandler()
        {
            _gameField = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            _playerO = new Player('O');
            _playerX = new Player('X');
            _currentPlayer = new Player('X');
        }

        public char[] ReturnBoardData()
        {
            return _gameField;
        }

        public bool CheckIfPlayerWon()
        {
            if (_gameField[0] == _currentPlayer.Symbol && _gameField[4] == _currentPlayer.Symbol &&
                _gameField[8] == _currentPlayer.Symbol) return true;

            if (_gameField[2] == _currentPlayer.Symbol && _gameField[4] == _currentPlayer.Symbol &&
                _gameField[6] == _currentPlayer.Symbol) return true;

            for (int i = 0; i < 9; i++)
            {
                if (_gameField[i] == _currentPlayer.Symbol && _gameField[i + 1] == _currentPlayer.Symbol &&
                    _gameField[i + 2] == _currentPlayer.Symbol) return true;
                i += 2;
            }

            for (int i = 0; i < 3; i++)
            {
                if (_gameField[i] == _currentPlayer.Symbol && _gameField[i + 3] == _currentPlayer.Symbol &&
                    _gameField[i + 6] == _currentPlayer.Symbol) return true;
            }

            return false;
        }

        public void UpdateBoard(string playerInput)
        {
            int.TryParse(playerInput, out int playerMove);
            _gameField[playerMove - 1] = _currentPlayer.Symbol;
        }

        public void SwitchPlayer()
        {
            if (_currentPlayer.Symbol == _playerX.Symbol)
            {
                _currentPlayer.Symbol = _playerO.Symbol;
            }
            else
            {
                _currentPlayer.Symbol = _playerX.Symbol;
            }
        }
        public Player ReturnCurrentPlayer()
        {
            return _currentPlayer;
        }
    }
}
