using System;
using System.Linq;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT.Classes
{
    static class LoginMenu
    {

        #region LoginMenu
        public static void FirstMenu()
        {

            Console.Clear();

            int value;

            do
            {
                PrintFirstMenu();

                value = ReadValues();

                switch (value)
                {
                    case 1: // Login
                        Console.Clear();
                        Login();
                        break;
                    case 2: // Exit
                        Console.WriteLine("The application will be closed ...");
                        Exit();
                        break;
                    default:
                        Utility.OperationNotFoundAlert();

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (value != 2);
        }
        #endregion

        #region Features

        public static void Login()
        {

            bool loginSucceed = false;

            int attempts = 0;

            do
            {

                (string, string) userResult = ReadCredentials();

                string username = userResult.Item1;

                string password = userResult.Item2;


                using (var db = new RSGymDBContext())
                {

                    var result = db.User.FirstOrDefault(u => u.Username == username && u.Password == password);


                    if (result != null)
                    {
                        loginSucceed = true;
                        attempts = 0;

                        User user = result;

                        if (user.Profile == User.EnumProfile.admin)
                        {

                            NavigationMenu.MainMenuAdmin(user);

                        }
                        else
                        {
                            // ToDo: Meter menu colab
                        }

                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine("\nIncorrect credentials!");

                        Console.ReadKey();
                        Console.Clear();
                    }

                    if (attempts >= 3)
                    {
                        Console.WriteLine("\nYou have reached your limit!\n\nThe application will be closed...");
                        Exit();
                    }

                }


            } while (!loginSucceed && attempts < 3);

        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        #endregion

        #region Print Methods

        public static void PrintFirstMenu()
        {

            string[] firstMenuOptions = new string[]
            {
                "1. Login",
                "2. Exit"
            };

            Utility.WriteTitle("RSGymPT");

            foreach (var firstMenu in firstMenuOptions)
            {
                Console.WriteLine(firstMenu);
            }

        }

        #endregion

        #region Read Methods

        public static int ReadValues()
        {
            
            bool validValue = false;
            int answerConverted;

            do
            {

                Console.Write("\n\n>> ");
                bool parseSucceded = int.TryParse(Console.ReadLine(), out answerConverted);


                if (parseSucceded)
                {
                    validValue = true;
                }
                else
                {
                    Utility.OperationWithNumbers();
                }


            } while (!validValue);

            return answerConverted;

        }


        public static (string, string) ReadCredentials()
        {

            Utility.WriteTitle("RSGymPT - Login");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            return (username, password);

        }

        #endregion

    }

}
