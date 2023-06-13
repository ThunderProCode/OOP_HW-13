namespace HW
{
    class TicTacToe
    {
        private char[] board;
        private char currentPlayer;
        private bool gameEnded;

        public TicTacToe()
        {
            board = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            currentPlayer = 'X';
            gameEnded = false;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            do
            {
                DrawBoard();
                GetPlayerMove();

                if (CheckWinCondition())
                {
                    DrawBoard();
                    Console.WriteLine("Player {0} wins!", currentPlayer);
                    gameEnded = true;
                }
                else if (IsBoardFull())
                {
                    DrawBoard();
                    Console.WriteLine("It's a draw!");
                    gameEnded = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            } while (!gameEnded);

            Console.WriteLine("Game Over");
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        private void DrawBoard()
        {
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
            Console.WriteLine();
        }

        private void GetPlayerMove()
        {
            Console.WriteLine("Player {0}, enter your move (1-9):", currentPlayer);
            int move = -1;
            bool validMove = false;

            while (!validMove)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out move))
                {
                    if (move >= 1 && move <= 9)
                    {
                        if (board[move - 1] == ' ')
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("That square is already occupied. Choose another square.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
                }
            }

            board[move - 1] = currentPlayer;
        }

        public bool CheckWinCondition()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] != ' ' && board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
            {
                return true;
            }

            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}