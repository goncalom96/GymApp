using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class ClientRepository
    {

        public static void CreateClient(int locationID, int personalTrainerID, string name, DateTime dateBirth, string nif, string address, string phoneNumber, string email, string comments, bool active)
        {

            ICollection<Client> clients = new Collection<Client>
            {
                new Client { LocationID = 1, PersonalTrainerID = 1, Name = "client01", DateBirth = new DateTime (1996, 02, 26), NIF = "214456389", Address = "Rua do Client01", PhoneNumber = "919991872", Email = "client01@hotmail.com", Comments = "test1", Active = true},
                new Client { LocationID = 2, PersonalTrainerID = 2, Name = "client02", DateBirth = new DateTime (1990, 10, 02), NIF = "213459781", Address = "Rua do Client02", PhoneNumber = "964321942", Email = "client02@hotmail.com", Active = true},
                new Client { LocationID = 1, PersonalTrainerID = 1, Name = "client03", DateBirth = new DateTime (1988, 07, 22), NIF = "217458786", Address = "Rua do Client03", PhoneNumber = "931662873", Email = "client03@hotmail.com", Comments = "test3", Active = false},
                new Client { LocationID = locationID, PersonalTrainerID = personalTrainerID, Name = name, DateBirth = dateBirth, NIF = nif, Address = address, PhoneNumber = phoneNumber, Email = email, Comments = comments, Active = active}
            };

            // clients.Add() -> Adiciono os clients à parte?


            using (var db = new RSGymDBContext())
            {
                db.Client.AddRange(clients);
                db.SaveChanges();
            }

        }

        // REVER
        public static void UpdateClient(string name)
        {
            using (var db = new RSGymDBContext())
            {
                var result = db.Client.FirstOrDefault(c => c.Name == name);

                /*
                if (result != null)
                {
                    result.LocationID = locationID;
                    result.PersonalTrainerID = personalTrainerID;
                    result.Name = name;
                    result.DateBirth = dateBirth;
                    result.Address = address;
                    result.PhoneNumber = phoneNumber;
                    result.Email = email;
                    result.Comments = comments;

                    db.SaveChanges();
                }
                */
            }

        }

        public static void ListClients(ICollection<Client> clients)
        {

            foreach (var c in clients)
            {
                Console.WriteLine($"Name: {c.Name}\nDate of birth: {c.DateBirth}\nNIF: {c.NIF}\nAddress: {c.Address}\nPostal Code: {c.Location.PostalCode}\nCity: {c.Location.City}\nComments: {c.Comments}\nActive: {c.Active}\n\n");
            }

        }
        
        // REVER
        public static void ChangeClientStatus(int clientID)
        {
            using (var db = new RSGymDBContext())
            {
                var result = db.Client.FirstOrDefault(c => c.ClientID == clientID);

                /*
                if (result != null)
                {
                    result.Active = active;

                    db.SaveChanges();
                }
                */
            }
        }


    }
}
