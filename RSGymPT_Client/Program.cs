using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUtility;
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

                UserRepository.StartingUsers();

                //UserRepository.CreateUser();

                UserRepository.ListUsers();

            }
            catch (Exception)
            {

                throw;
            }


            Utility.TerminateConsole();

        }
    }
}
