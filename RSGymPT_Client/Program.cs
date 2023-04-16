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

                // ToDo: Descrevi apenas o método do Create do Client e Personal Trainer pois usei a mesma abordagem para os restantes
                
                // Dados iniciais estão comentados e ainda vou lançar
                #region Starting Data
                /*
                UserRepository.StartingUsers();
                LocationRepository.StartingLocations();
                PersonalTrainerRepository.StartingPersonalTrainers();
                ClientRepository.StartingClients();
                RequestRepository.StartingRequests();
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
