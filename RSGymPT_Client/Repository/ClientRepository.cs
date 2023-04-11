using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class ClientRepository
    {

        public static void CreateClient(int locationID, int personalTrainerID, string name, DateTime dateBirth, string nif, string address, string phoneNumber, string email, string comments, bool active)
        {


            // ToDo: Validar a existência do Client antes de o criar

            ICollection<Client> clients = new Collection<Client>
            {
                new Client { LocationID = 2, PersonalTrainerID = 1, Name = "client01", DateBirth = new DateTime (1996, 02, 26), NIF = "214456389", Address = "Rua do Client01", PhoneNumber = "919991872", Email = "client01@hotmail.com", Comments = "test1", Active = true},
                new Client { LocationID = 3, PersonalTrainerID = 2, Name = "client02", DateBirth = new DateTime (1990, 10, 02), NIF = "213459781", Address = "Rua do Client02", PhoneNumber = "964321942", Email = "client02@hotmail.com", Active = true},
                new Client { LocationID = 6, PersonalTrainerID = 1, Name = "client03", DateBirth = new DateTime (1988, 07, 22), NIF = "217458786", Address = "Rua do Client03", PhoneNumber = "931662873", Email = "client03@hotmail.com", Comments = "test3", Active = false},
                new Client { LocationID = locationID, PersonalTrainerID = personalTrainerID, Name = name, DateBirth = dateBirth, NIF = nif, Address = address, PhoneNumber = phoneNumber, Email = email, Comments = comments, Active = active}
            };

            // ToDo: clients.Add() -> Adiciono os clients à parte?

            using (var db = new RSGymDBContext())
            {
                db.Client.AddRange(clients);
                db.SaveChanges();
            }

        }

        public static void UpdateClient()
        {

            Utility.WriteTitle("Clients - Update");

            Console.Write("Confirm your name: ");
            string name = Console.ReadLine();

            Console.Clear();

            using (var db = new RSGymDBContext())
            {
                var result = db.Client.FirstOrDefault(c => c.Name == name);

                if (result != null)
                {

                    Utility.WriteTitle("Clients - Update - New data");

                    Console.Write("Name: ");
                    string newName = Console.ReadLine();

                    Console.Write("Location: ");
                    // Método a confirmar a localização?
                    bool tryParseLocation = Int16.TryParse(Console.ReadLine(), out Int16 locationID);

                    Console.Write("Date Birth: ");
                    // Método a confirmar data?
                    bool tryParseDateBirth = DateTime.TryParse(Console.ReadLine(), out DateTime dateBirth);

                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    Console.Write("Phone number: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Comments: ");
                    string comments = Console.ReadLine();

                    result.Name = newName;
                    result.LocationID = locationID;
                    result.DateBirth = dateBirth;
                    result.Address = address;
                    result.PhoneNumber = phoneNumber;
                    result.Email = email;
                    result.Comments = comments;

                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Wrong name!");
                }

            }

        }

        public static void ListClients()
        {
            // Clientes ativos ordenados pelo nome
            using (var db = new RSGymDBContext())
            {

                var queryClients = db.Client.Select(c => c).Where(c => c.Active == true).OrderBy(c => c.Name);

                Utility.WriteTitle("Clients - All Clients");

                queryClients.ToList().ForEach(c => Utility.WriteMessage($"Name: {c.Name}\nDate of birth: {c.DateBirth}\nNIF: {c.NIF}\nAddress: {c.Address}\nPostal Code: {c.Location.PostalCode}\nCity: {c.Location.City}\nComments: {c.Comments}\nActive: {c.Active}\n\n", "", "\n"));

            }

        }

        public static void ChangeClientStatus()
        {

            Utility.WriteTitle("Clients - Update Status");

            Console.Write("Confirm your ID number: ");
            bool tryParseClient = Int16.TryParse(Console.ReadLine(), out Int16 clientID);

            Console.Clear();

            using (var db = new RSGymDBContext())
            {
                var result = db.Client.FirstOrDefault(c => c.ClientID == clientID);

                if (result != null)
                {

                    Utility.WriteTitle("Clients - Update Status");

                    Console.Write("Update your status: ");
                    bool tryParseStatus = Boolean.TryParse(Console.ReadLine(), out Boolean active);


                    result.Active = active;

                    db.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Wrong ID!");
                }

            }
        }

    }
}
