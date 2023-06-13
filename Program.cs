namespace HW
{
    public class Program {
        public static void Main() {
            int opt = 0;
            while(opt != 4){
                opt = IntInput("===MENU===\n1)Tic-Tac-Toe\n2)Locked Door\n3)Password Validator\n4)Exit");
                switch(opt){
                    // Tic-Tac-Toe
                    case 1:
                        RunTicTacToe();
                    break;
                    // Locked Door
                    case 2:
                        RunDoor();
                    break;
                    // Password Validator
                    case 3:
                        RunValidator();
                    break;
                }
            }
        }

        public static void RunDoor() {
            Console.Write("Enter the starting passcode: ");
            string startingPasscode = Console.ReadLine();

            Door door = new Door(startingPasscode);

            string command;
            do
            {
                Console.WriteLine("Enter a command (open, close, lock, unlock, change):");
                command = Console.ReadLine();

                switch (command)
                {
                    case "open":
                        door.Open();
                        break;
                    case "close":
                        door.Close();
                        break;
                    case "lock":
                        Console.Write("Enter the passcode to lock the door: ");
                        string lockPasscode = Console.ReadLine();
                        door.Lock(lockPasscode);
                        break;
                    case "unlock":
                        Console.Write("Enter the passcode to unlock the door: ");
                        string unlockPasscode = Console.ReadLine();
                        door.Unlock(unlockPasscode);
                        break;
                    case "change":
                        Console.Write("Enter the current passcode: ");
                        string currentPasscode = Console.ReadLine();
                        Console.Write("Enter the new passcode: ");
                        string newPasscode = Console.ReadLine();
                        door.ChangePasscode(currentPasscode, newPasscode);
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
                    Console.WriteLine();
                } while (command != "exit");
        }

        // Asks user to input a number and validates it
        public static int IntInput(string memssage) {
            System.Console.WriteLine(memssage);
            string input = Console.ReadLine();
            int output;
            while(!Int32.TryParse(input, out output)) {
                System.Console.WriteLine("Please type a number: ");
                input = Console.ReadLine();
            }
            return output;
        }
        // Runs the tic-tac-toe
        public static void RunTicTacToe() {
            // TicTacToe game = new TicTacToe();
            // game.StartGame();
            int rounds = 5;
            int player1Wins = 0;
            int player2Wins = 0;

            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine("Round {0}", i + 1);

                TicTacToe game = new TicTacToe();
                game.StartGame();

                if (game.CheckWinCondition())
                {
                    if (game.GetCurrentPlayer() == 'X')
                    {
                        player1Wins++;
                    }
                    else
                    {
                        player2Wins++;
                    }
                }

                Console.WriteLine("Player 1 wins: {0}", player1Wins);
                Console.WriteLine("Player 2 wins: {0}", player2Wins);
                Console.WriteLine();
            }
        }
        
        public static void RunValidator() {
            PasswordValidator validator = new PasswordValidator();

            while (true)
            {
                Console.Write("Enter a password: ");
                string password = Console.ReadLine();

                if (validator.IsValidPassword(password))
                {
                    Console.WriteLine("Password is valid.");
                }
                else
                {
                    Console.WriteLine("Password is not valid. Please try again.");
                }

                Console.WriteLine();
            }
        }

    }
}