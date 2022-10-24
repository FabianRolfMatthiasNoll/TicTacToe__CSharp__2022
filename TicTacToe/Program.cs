using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameField gameBoard = new GameField();
            gameBoard.StartGame();
            Console.ReadKey();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}