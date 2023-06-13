namespace HW
{
    class PasswordValidator
    {
        public bool IsValidPassword(string password)
        {
            if (password.Length < 6 || password.Length > 13)
            {
                Console.WriteLine("Password must be between 6 and 13 characters long.");
                return false;
            }

            if (!ContainsUppercaseLetter(password))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                return false;
            }

            if (!ContainsLowercaseLetter(password))
            {
                Console.WriteLine("Password must contain at least one lowercase letter.");
                return false;
            }

            if (!ContainsNumber(password))
            {
                Console.WriteLine("Password must contain at least one number.");
                return false;
            }

            if (ContainsInvalidCharacters(password))
            {
                Console.WriteLine("Password cannot contain 'T' or '&'.");
                return false;
            }

            return true;
        }

        private bool ContainsUppercaseLetter(string password)
        {
            foreach (char letter in password)
            {
                if (char.IsUpper(letter))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsLowercaseLetter(string password)
        {
            foreach (char letter in password)
            {
                if (char.IsLower(letter))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsNumber(string password)
        {
            foreach (char letter in password)
            {
                if (char.IsDigit(letter))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsInvalidCharacters(string password)
        {
            return password.Contains('T') || password.Contains('&');
        }
    }
}