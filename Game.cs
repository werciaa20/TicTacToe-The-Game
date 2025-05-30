using System;
namespace tictactoe
{
    public class Game
    {
        public string[,] Board { get; private set; } = new string[3, 3];
        public string CurrentPlayer { get; private set; } = "X";
        public bool IsGameOver { get; private set; } = false;

        public Game()
        {
            Reset();
        }

        // First we need to make move on the game board
        public string MakeMove(int row, int col)
        {
            if (IsGameOver || !string.IsNullOrEmpty(Board[row, col]))
                return string.Empty;  // Return an empty string instead of null

            Board[row, col] = CurrentPlayer;
            if (CheckWin(CurrentPlayer))
            {
                IsGameOver = true;
                return $"{CurrentPlayer} wins!";
            }

            if (IsBoardFull())
            {
                IsGameOver = true;
                return "Draw!";
            }

            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
            return string.Empty; // No winner yet, continue the game
        }

        // Now we need to make code for resetting game board
        public void Reset()
        {
            Board = new string[3, 3];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    Board[r, c] = string.Empty;
            CurrentPlayer = "X";
            IsGameOver = false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in Board)
                if (string.IsNullOrEmpty(cell)) return false;
            return true;
        }

        // Now we need to check board for win/draw/lose
        private bool CheckWin(string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player)
                    return true;
                if (Board[0, i] == player && Board[1, i] == player && Board[2, i] == player)
                    return true;
            }
            return (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player)
                || (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player);
        }

    }

}