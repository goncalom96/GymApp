using System;
using System.Diagnostics.Eventing.Reader;
using AppUtility;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;

namespace RSGymPT.Classes
{
    public static class NavigationMenu
    {

        #region Navigation Menu

        public static void MainMenu(User user)
        {

            int value;

            do
            {

                PrintMenuOptions(user);
                value = ReadValues(user);

                switch (value)
                {

                    case 1: // Users

                        if (user.Profile == User.EnumProfile.admin && value == 1) // ToDo: Controla o acesso dos Admins/Colab ao SubMenu do User
                        {
                            int valueUser;
                            do
                            {

                                PrintUserOptions(user);
                                valueUser = ReadValues(user);

                                Console.Clear();

                                switch (valueUser)
                                {
                                    case 1: // Create
                                        UserRepository.CreateUser(user);
                                        Utility.TerminateConsole();
                                        break;
                                    case 2: // Update
                                        UserRepository.UpdateUser(user);
                                        Utility.TerminateConsole();
                                        break;
                                    case 3: // List
                                        UserRepository.ListUsers(user);
                                        Utility.TerminateConsole();
                                        break;
                                    case 0: // Back
                                        break;
                                    default:
                                        Utility.OperationNotFoundAlert();
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                }

                            } while (valueUser != 0);

                        }
                        else
                        {
                            Console.WriteLine("Access denied!"); // Se for "colab" o acesso é negado
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case 2: // Clients
                        int valueClient;
                        do
                        {

                            PrintClientOptions(user);
                            valueClient = ReadValues(user);

                            Console.Clear();

                            switch (valueClient)
                            {
                                case 1: // Create
                                    ClientRepository.CreateClient(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 2: // Update
                                    ClientRepository.UpdateClient(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 3: // List
                                    ClientRepository.ListClients(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 4: // Active
                                    ClientRepository.ChangeClientStatus(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }

                        } while (valueClient != 0);
                        break;
                    case 3: // PersonalTrainers
                        int valuePersonalTrainer;
                        do
                        {
                            PrintPersonalTrainerOptions(user);
                            valuePersonalTrainer = ReadValues(user);

                            Console.Clear();

                            switch (valuePersonalTrainer)
                            {
                                case 1: // Create
                                    PersonalTrainerRepository.CreatePersonalTrainer(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 2: // List
                                    PersonalTrainerRepository.ListPersonalTrainers(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }

                        } while (valuePersonalTrainer != 0);
                        break;
                    case 4: // Requests
                        int valueRequest;
                        do
                        {
                            PrintRequestOptions(user);
                            valueRequest = ReadValues(user);

                            Console.Clear();

                            switch (valueRequest)
                            {
                                case 1: // Create
                                    RequestRepository.CreateRequest(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 2: // List
                                    RequestRepository.ListRequests(user);
                                    Utility.TerminateConsole();
                                    break;
                                case 0: // Back
                                    break;
                                default:
                                    Utility.OperationNotFoundAlert();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }

                        } while (valueRequest != 0);
                        break;
                    case 5:
                        LoginMenu.FirstMenu();
                        break;
                    default:
                        Utility.OperationNotFoundAlert();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (value != 5);

        }

        #endregion

        #region Read Methods

        public static int ReadValues(User user)
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

        #endregion

        #region Print Methods

        public static void PrintMenuOptions(User user)
        {

            Console.Clear();

            string[] menuOptions = new string[]
            {
                "1. User",
                "2. Client",
                "3. Personal Trainer",
                "4. Request",
                "5. Logout"
            };


            Utility.WriteTitle($"RSGym Menu | {user.Username} | {user.Profile} |");

            foreach (var listMenu in menuOptions)
            {
                Console.WriteLine(listMenu);
            }

        }

        private static void PrintRequestOptions(User user)
        {

            Console.Clear();

            string[] menuRequest = new string[]
            {
                "1. Create",
                "2. List",
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

            Console.Clear();

            string[] menuPersonalTrainer = new string[]
            {
                "1. Create",
                "2. List",
                "0. Back"
            };

            Utility.WriteTitle($"Personal Trainer - {user.Username}");

            foreach (var listMenu in menuPersonalTrainer)
            {
                Console.WriteLine(listMenu);
            }

        }

        public static void PrintUserOptions(User user)
        {

            Console.Clear();

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

        public static void PrintClientOptions(User user)
        {

            Console.Clear();

            string[] menuClient = new string[]
            {
                "1. Create",
                "2. Update",
                "3. List",
                "4. Active",
                "0. Back"
            };

            Utility.WriteTitle($"Client - {user.Username}");

            foreach (var listMenu in menuClient)
            {
                Console.WriteLine(listMenu);
            }

        }

        #endregion

    }
}
