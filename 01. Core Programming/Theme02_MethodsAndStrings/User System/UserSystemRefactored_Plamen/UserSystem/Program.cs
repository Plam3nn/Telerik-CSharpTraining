using System;

namespace UserSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] userTable = new string[4, 2];

            while (true)
            {
                ChangeConsoleColor();

                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] commandArgs = command.Split(" ");
                string requestType = commandArgs[0];

                if (!HaveEnoughArguments(commandArgs))
                {
                    ChangeConsoleColor("Red");
                    Console.WriteLine("Too few parameters.");
                    continue;
                }

                string username = commandArgs[1];
                string password = commandArgs[2];

                if (!CredentialsAreValid(username, password))
                {
                    continue;
                }

                ProcessRequest(userTable, requestType, username, password);
            }
        }

        static void ProcessRequest(string[,] userTable, string requestType, string username, string password)
        {
            if (requestType == "register")
            {
                RegisterUser(userTable, username, password);
            }
            else if (requestType == "delete")
            {
                DeleteUser(userTable, username, password);
            }
        }

        static bool CredentialsAreValid(string username, string password)
        {
            if (!UsernameLengthIsValid(username))
            {
                ChangeConsoleColor("Red");
                Console.WriteLine("Username must be at least 3 characters long.");
                return false;
            }

            if (!PasswordLengthIsValid(password))
            {
                ChangeConsoleColor("Red");
                Console.WriteLine("Password must be at least 3 characters long.");
                return false;
            }

            return true;
        }        
             
        static void DeleteUser(string[,] table, string username, string password)
        {
            int accountIndex = GetAccountIndex(table, username, password);
            
            if (accountIndex == -1)
            {
                ChangeConsoleColor("Red");
                Console.WriteLine("Invalid account/password.");
                return;
            }

            table[accountIndex, 0] = null;
            table[accountIndex, 1] = null;

            ChangeConsoleColor("Dark green");
            Console.WriteLine("Deleted account.");
        }

        static int GetAccountIndex(string[,] table, string username, string password)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, 0] == username &&
                    table[i, 1] == password)
                {
                    return i;
                }
            }

            return -1;
        }

        static void RegisterUser(string[,] table, string username, string password)
        {
            if (UserAlreadyExists(table, username))
            {
                ChangeConsoleColor("Red");
                Console.WriteLine("Username already exists.");
                return;
            }

            bool isSavedUser = SaveUser(table, username, password);

            if (isSavedUser)
            {
                ChangeConsoleColor("Dark green");
                Console.WriteLine("Registered user.");
            }
            else
            {
                ChangeConsoleColor("Red");
                Console.WriteLine("The system supports a maximum number of 4 users.");
            }
        }

        static int GetFreeSlotIndex(string[,] talbe)
        {
            for (int i = 0; i < talbe.GetLength(0); i++)
            {
                if (talbe[i, 0] == null)
                {
                    return i;
                }
            }

            return -1;
        }

        static bool SaveUser(string[,] table, string username, string password)
        {
            int freeSlotIndex = GetFreeSlotIndex(table);
            
            if (freeSlotIndex == -1)
            {                
                return false;
            }

            table[freeSlotIndex, 0] = username;
            table[freeSlotIndex, 1] = password;

            return true;
        }

        static bool UserAlreadyExists(string[,] table, string username)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, 0] == username)
                {
                    return true;
                }
            }

            return false;
        }

        static bool PasswordLengthIsValid(string password)
        {
            if (password.Length < 3)
            {
                return false;
            }

            return true;
        }

        static bool UsernameLengthIsValid(string username)
        {
            if (username.Length < 3)
            {
                return false;
            }

            return true;
        }

        static void ChangeConsoleColor(string color = "White")
        {
            switch (color)
            {
                case "Red": Console.ForegroundColor = ConsoleColor.Red; break;
                case "Dark green": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case "White": Console.ForegroundColor = ConsoleColor.White; break;
            }
        }

        static bool HaveEnoughArguments(string[] args)
        {
            if (args.Length < 3)
            {
                return false;
            }

            return true;
        }
    }
}