using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUtility;
using RSGymPT.Classes;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

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
            catch (DbEntityValidationException ex)
            {

                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            Utility.TerminateConsole();

        }
    }
}
