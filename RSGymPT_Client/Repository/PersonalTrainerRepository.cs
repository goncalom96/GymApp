using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class PersonalTrainerRepository
    {

        public static void CreatePersonalTrainer()
        {


            bool newPersonalTrainerSucceed = false;

            do
            {

                Utility.WriteTitle("Personal Trainer - New PT");

                Console.Write("Code: ");
                string codePT = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("NIF: ");
                string nif = Console.ReadLine();

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("Location: ");
                bool tryParseLocation = Int16.TryParse(Console.ReadLine(), out Int16 locationID);

                Console.Write("Phone number: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();


                using (var db = new RSGymDBContext())
                {

                    var result = db.PersonalTrainer.FirstOrDefault(p => p.NIF == nif);


                    if (result != null)
                    {
                        newPersonalTrainerSucceed = true;

                        ICollection<PersonalTrainer> personalTrainers = new Collection<PersonalTrainer>
                        {
                            new PersonalTrainer { CodePT = codePT, Name = name, NIF = nif, LocationID = locationID, Address = address, PhoneNumber = phoneNumber, Email = email}
                        };

                        db.PersonalTrainer.AddRange(personalTrainers);
                        db.SaveChanges();

                        Utility.WriteTitle("Client - New Client");
                        Console.WriteLine("Client created with succeed!");
                    }
                    else
                    {
                        Utility.WriteTitle("Client - Error");
                        Console.WriteLine("The NIF entered already exists. Please confirm your details again.");
                    }

                }


            } while (!newPersonalTrainerSucceed);

        }

        public static void ListPersonalTrainers()
        {
            // PTs ordenados pelo nome
            using (var db = new RSGymDBContext())
            {

                var queryPersonalTrainers = db.PersonalTrainer.Select(p => p).OrderBy(p => p.Name);

                Utility.WriteTitle("Personal Trainers - All PTs");

                queryPersonalTrainers.ToList().ForEach(p => Utility.WriteMessage($"Code: {p.CodePT}\nName: {p.Name}\nNIF: {p.NIF}\nAddress: {p.Address}\nPostal Code: {p.Location.PostalCode}\nCity: {p.Location.City}\n\n", "", "\n"));

            }

        }


        #region Starting PersonalTrainers

        public static void StartingPersonalTrainers()
        {

            ICollection<PersonalTrainer> personalTrainers = new Collection<PersonalTrainer>
            {
                new PersonalTrainer { CodePT = "PT01", Name = "TestePTOne", NIF = "288654647", LocationID = 1, Address = "Rua do PT01", PhoneNumber = "915673821", Email = "personaltrainer01@hotmail.com"},
                new PersonalTrainer { CodePT = "PT02", Name = "TestePTTwo", NIF = "272653636", LocationID = 4, Address = "Rua do PT02", PhoneNumber = "962738521", Email = "personaltrainer02@hotmail.com"}
            };

            using (var db = new RSGymDBContext())
            {
                db.PersonalTrainer.AddRange(personalTrainers);
                db.SaveChanges();
            }

        }

        #endregion


    }
}
