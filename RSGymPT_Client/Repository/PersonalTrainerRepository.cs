using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppUtility;
using RSGymPT_Client.InputValidation;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class PersonalTrainerRepository
    {

        #region Features
        public static void CreatePersonalTrainer(User user)
        {

            Console.Clear();

            bool newPersonalTrainerSucceed = false;

            do
            {

                Utility.WriteTitle("Personal Trainer - Create");

                string codePT = Validation.ValidatePersonalTrainerCode();

                string name = Validation.ValidateName();

                string nif = Validation.ValidateNIF();

                string address = Validation.ValidateAddress();

                int locationID = Validation.ValidateLocationIntNumber();

                string phoneNumber = Validation.ValidatePhoneNumber();

                string email = Validation.ValidateEmail();


                using (var db = new RSGymDBContext())
                {

                    var result1 = db.PersonalTrainer.FirstOrDefault(p => p.NIF == nif);

                    var result2 = db.PersonalTrainer.FirstOrDefault(p => p.CodePT == codePT);

                    var result3 = db.Location.FirstOrDefault(l => l.LocationID == locationID);

                    if (result1 == null && result2 == null && result3 != null)
                    {
                        newPersonalTrainerSucceed = true;

                        ICollection<PersonalTrainer> personalTrainers = new Collection<PersonalTrainer>
                        {
                            new PersonalTrainer { CodePT = codePT, Name = name, NIF = nif, LocationID = locationID, Address = address, PhoneNumber = phoneNumber, Email = email}
                        };

                        db.PersonalTrainer.AddRange(personalTrainers);
                        db.SaveChanges();

                        Console.WriteLine("\n\nPersonal Trainer created with succeed!");

                    }
                    else if (result3 == null)
                    {
                        Console.WriteLine("\n\nThis location does not exist.");

                        // Perguntar se quer adicionar?
                        // LocationRepository.CreateLocation(user);

                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nThis Personal Trainer already exists. Please confirm your details again.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }


            } while (!newPersonalTrainerSucceed);

        }

        public static void ListPersonalTrainers(User user)
        {

            Console.Clear();

            // PTs ordenados pelo nome
            using (var db = new RSGymDBContext())
            {

                var queryPersonalTrainers = db.PersonalTrainer.Select(p => p).OrderBy(p => p.Name);

                Console.Clear();

                Utility.WriteTitle("Personal Trainers - All PTs");

                queryPersonalTrainers.ToList().ForEach(p => Utility.WriteMessage($"Code: {p.CodePT}\nName: {p.Name}\nNIF: {p.NIF}\nAddress: {p.Address}\nPostal Code: {p.Location.PostalCode}\nCity: {p.Location.City}\n\n", "", "\n"));

            }

        }
        #endregion

        #region Starting PersonalTrainers
        public static void StartingPersonalTrainers()
        {

            ICollection<PersonalTrainer> personalTrainers = new Collection<PersonalTrainer>
            {
                new PersonalTrainer { CodePT = "PT01", Name = "TestePTOne", NIF = "288654647", LocationID = 4, Address = "Rua do PT01", PhoneNumber = "915673821", Email = "personaltrainer01@hotmail.com"},
                new PersonalTrainer { CodePT = "PT02", Name = "TestePTTwo", NIF = "272653636", LocationID = 5, Address = "Rua do PT02", PhoneNumber = "962738521", Email = "personaltrainer02@hotmail.com"}
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
