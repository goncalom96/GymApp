using System;
using AppUtility;
using RSGymPT.Classes;
using RSGymPT_Client.Repository;

namespace RSGymPT_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Utility.SetUnicodeConsole();

            try
            {
                
                #region Starting Data
                /*
                UserRepository.StartingUsers();
                LocationRepository.StartingLocations();
                PersonalTrainerRepository.StartingPersonalTrainers();
                ClientRepository.StartingClients();
                */
                #endregion
                
                LoginMenu.FirstMenu();

            }
            catch (Exception)
            {

            }

            Utility.TerminateConsole();

        }
    }
}
