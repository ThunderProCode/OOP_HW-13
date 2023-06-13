namespace HW {
    class Door
    {
        private string passcode;
        private bool locked;
        private bool open;

        public Door(string passcode)
        {
            this.passcode = passcode;
            this.locked = true;
            this.open = false;
        }

        public void Open()
        {
            if (!open)
            {
                Console.WriteLine("The door is now open.");
                open = true;
            }
            else
            {
                Console.WriteLine("The door is already open.");
            }
        }

        public void Close()
        {
            if (open)
            {
                Console.WriteLine("The door is now closed.");
                open = false;
            }
            else
            {
                Console.WriteLine("The door is already closed.");
            }
        }

        public void Lock(string passcode)
        {
            if (open)
            {
                Console.WriteLine("Cannot lock the door while it's open. Please close the door first.");
            }
            else if (locked)
            {
                Console.WriteLine("The door is already locked.");
            }
            else if (passcode == this.passcode)
            {
                Console.WriteLine("The door is now locked.");
                locked = true;
            }
            else
            {
                Console.WriteLine("Incorrect passcode. The door remains unlocked.");
            }
        }

        public void Unlock(string passcode)
        {
            if (open)
            {
                Console.WriteLine("Cannot unlock the door while it's open.");
            }
            else if (!locked)
            {
                Console.WriteLine("The door is already unlocked.");
            }
            else if (passcode == this.passcode)
            {
                Console.WriteLine("The door is now unlocked.");
                locked = false;
            }
            else
            {
                Console.WriteLine("Incorrect passcode. The door remains locked.");
            }
        }

        public void ChangePasscode(string currentPasscode, string newPasscode)
        {
            if (currentPasscode == passcode)
            {
                Console.WriteLine("Passcode successfully changed.");
                passcode = newPasscode;
            }
            else
            {
                Console.WriteLine("Incorrect current passcode. Passcode remains unchanged.");
            }
        }
    }
}