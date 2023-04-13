using System;
using AppUtility;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;

namespace RSGymPT.Classes
{
    public static class NavigationMenu
    {

        #region Navigation Menu

        public static void MainMenuAdmin(User user)
        {

            int value;
            bool stop = false;

            do
            {
                PrintMenuOptions(user);
                value = ReadValues(user);

                switch (value)
                {
                    case 1: // Requests
                        int valuePedido;
                        do
                        {
                            PrintRequestOptions(user);
                            valuePedido = ReadValues(user);

                            switch (valuePedido)
                            {
                                case 1: // Create
                                    RequestRepository.CreateRequest();
                                    break;
                                case 2: // List
                                    RequestRepository.ListRequests();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    break;
                            }
                        } while (valuePedido != 0);
                        break;
                    case 2: // PersonalTrainers
                        int valuePersonalTrainer;
                        do
                        {
                            PrintPersonalTrainerOptions(user);
                            valuePersonalTrainer = ReadValues(user);

                            switch (valuePersonalTrainer)
                            {
                                case 1: // Create
                                    PersonalTrainerRepository.CreatePersonalTrainer();
                                    break;
                                case 2: // List
                                    PersonalTrainerRepository.ListPersonalTrainers();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    break;
                            }

                        } while (valuePersonalTrainer != 0);
                        break;
                    case 3: // Users
                        int valueUser;
                        do
                        {
                            PrintUserOptions(user);
                            valueUser = ReadValues(user);

                            switch (valueUser)
                            {
                                case 1: // Create
                                    UserRepository.CreateUser();
                                    Utility.TerminateConsole();
                                    break;
                                case 2: // Update
                                    UserRepository.UpdateUser();
                                    Utility.TerminateConsole();
                                    break;
                                case 3: // List
                                    UserRepository.ListUsers();
                                    Utility.TerminateConsole();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    break;
                            }

                        } while (valueUser != 0);
                        break;
                    case 4:
                        //int valueLogout;
                        LoginMenu.FirstMenu();
                        /*
                        do
                        {
                            valueLogout = ReadValues(user);
                            //stop = true;
                            LoginMenu.FirstMenu();
                            // ToDo: Método para fazer logout UserRepository.Logout
                            // Voltar para o menu login
                        } while (valueLogout != 4);
                        */
                        break;
                    default:
                        Utility.OperationNotFoundAlert();
                        break;
                } 

            } while (!stop);

        }

        #endregion

        #region Read Methods

        public static int ReadValues(User user)
        {

            bool parseSucceded;
            int answerConverted;

            do
            {

                Console.Write("\n\n>> ");
                parseSucceded = int.TryParse(Console.ReadLine(), out answerConverted);
                Console.Clear();

                if (!parseSucceded)
                {
                    Console.WriteLine($"\n{user.Username}, remember that you can only answer with numbers.");
                    Console.Clear();

                    //Menu(user);
                }


            } while (!parseSucceded);

            return answerConverted;

        }

        #endregion

        #region Print Methods

        public static void PrintMenuOptions(User user)
        {

            string[] menuOptions = new string[]
            {
                "1. Request",
                "2. Personal Trainer",
                "3. User",
                "4. Logout"
            };


            Utility.WriteTitle($"RSGym Menu - {user.Username}");

            foreach (var listMenu in menuOptions)
            {
                Console.WriteLine(listMenu);
            }

        }

        private static void PrintRequestOptions(User user)
        {

            string[] menuRequest = new string[]
            {
                "1. Create",
                "2. Update",
                "3. List",
                "0. Back"
            };

            Utility.WriteTitle($"Request - {user.Username}");

            foreach (var listRequest in menuRequest)
            {
                Console.WriteLine(listRequest);
            }

        }

        public static void PrintPersonalTrainerOptions(User user)
        {

            string[] menuPersonalTrainer = new string[]
            {
                "1. Create",
                "2. List",
                "0. Back"
            };

            Utility.WriteTitle($"User - {user.Username}");

            foreach (var listMenu in menuPersonalTrainer)
            {
                Console.WriteLine(listMenu);
            }

        }

        public static void PrintUserOptions(User user)
        {

            string[] menuUser = new string[]
            {
                "1. Create",
                "2. Update",
                "3. List",
                "0. Back"
            };

            Utility.WriteTitle($"User - {user.Username}");

            foreach (var listMenu in menuUser)
            {
                Console.WriteLine(listMenu);
            }

        }

        #endregion

    }
}
