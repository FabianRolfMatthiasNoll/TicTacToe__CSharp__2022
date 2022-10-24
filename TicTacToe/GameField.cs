using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameField
    {
        readonly GameHandler _gameHandler;
        readonly MoveValidator _moveValidator;
        readonly InputValidator _inputValidator;
        private char[] _gameField;
        private Player _currentPlayer;

        public GameField()
        {
            _inputValidator = new InputValidator();
            _moveValidator = new MoveValidator();
            _gameHandler = new GameHandler();
            _currentPlayer = new Player(' ');
            _gameField = new char[9];
            GetCurrentPlayer();
        }

        public void StartGame()
        {
            while(true)
            {
                GetBoardData();
                ShowGameField();
                MakeMove();
                if (CheckForWinner()) break;
                SwitchPlayer();
            }
            Console.Clear();
            Console.WriteLine($"Congrats Player {_currentPlayer.Symbol} you won!!!!");
        }

        public bool CheckForWinner()
        {
            if (_gameHandler.CheckIfPlayerWon()) return true;
            return false;
        }

        public void SwitchPlayer()
        {
            _gameHandler.SwitchPlayer();
            GetCurrentPlayer();
        }

        public void GetCurrentPlayer()
        {
            _currentPlayer = _gameHandler.ReturnCurrentPlayer();
        }

        public void GetBoardData()
        {
            _gameField = _gameHandler.ReturnBoardData();
        }

        public void ShowGameField()
        {
            Console.Clear();
            Console.WriteLine(_gameField[0] + "|" + _gameField[1] + "|" + _gameField[2]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(_gameField[3] + "|" + _gameField[4] + "|" + _gameField[5]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(_gameField[6] + "|" + _gameField[7] + "|" + _gameField[8]);
        }

        public void MakeMove()
        {
            Return:
            Console.Write($"Player {_currentPlayer.Symbol} what is your next move? ");
            var playerInput = Console.ReadLine();
            while (!_inputValidator.InputValidation(playerInput))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Program.ClearCurrentConsoleLine();
                Console.Write($"Please enter a valid number:");
                playerInput = Console.ReadLine();
            }

            while (!_moveValidator.ValidateMove(_gameField, playerInput, _currentPlayer))
            {
                Program.ClearCurrentConsoleLine();
                Console.Write($"The Field is already taken. Please choose another: ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Program.ClearCurrentConsoleLine();
                goto Return;
            }
            _gameHandler.UpdateBoard(playerInput);
        }

        
    }
}
