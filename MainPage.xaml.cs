namespace tictactoe
{
    public partial class MainPage : ContentPage
    {
        private readonly Game _game;

        public MainPage()
        {
            InitializeComponent();
            _game = new Game();
        }

        // Initialize the game board
        private void OnCellClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int row = Grid.GetRow(button);
                int col = Grid.GetColumn(button);

                var result = _game.MakeMove(row, col);

                foreach (var child in GameGrid.Children)
                {
                    if (child is Button btn)
                    {
                        int r = Grid.GetRow(btn);
                        int c = Grid.GetColumn(btn);
                        btn.Text = _game.Board[r, c];
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    statusLabel.Text = result;
                    if (statusLabel.Parent is Grid grid)
                    {
                        DisableAllButtons(grid);
                    }
                }
                else
                {
                    statusLabel.Text = $"Player {_game.CurrentPlayer}'s turn";
                }
            }
        }

        // Reset game board 
        private void OnResetClicked(object sender, EventArgs e)
        {
            _game.Reset();

            foreach (var child in GameGrid.Children)
            {
                if (child is Button btn)
                {
                    btn.Text = string.Empty;
                    btn.IsEnabled = true; // Enable buttons for a new game
                }
            }
            statusLabel.Text = "Player X's turn";
        }

        // Disable all buttons after game over

        private static void DisableAllButtons(Grid grid)
        {
            foreach (var child in grid.Children)
            {
                if (child is Button btn)
                {
                    btn.IsEnabled = false;
                }
            }
        }
    }
}

