using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class PersonalTrainerRepository
    {

        public static void CreatePersonalTrainer(string codePT, string name, string nif, int locationID, string address, string phoneNumber, string email)
        {


            // ToDo: Validar a existência do PT antes de o criar

            ICollection<PersonalTrainer> personalTrainers = new Collection<PersonalTrainer>
            {
                new PersonalTrainer { CodePT = "PT01", Name = "TestePT01", NIF = "288654647", LocationID = 1, Address = "Rua do PT01", PhoneNumber = "915673821", Email = "personaltrainer01@hotmail.com"},
                new PersonalTrainer { CodePT = "PT02", Name = "TestePT02", NIF = "272653636", LocationID = 4, Address = "Rua do PT02", PhoneNumber = "962738521", Email = "personaltrainer02@hotmail.com"},
                new PersonalTrainer { CodePT = codePT, Name = name, NIF = nif, LocationID = locationID, Address = address, PhoneNumber = phoneNumber, Email = email}
            };


            using (var db = new RSGymDBContext())
            {
                db.PersonalTrainer.AddRange(personalTrainers);
                db.SaveChanges();
            }

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

    }
}
