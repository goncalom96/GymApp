using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class ClientRepository
    {

        public static void CreateClient(User user)
        {

            Console.Clear();

            bool newClientSucceed = false;

            do
            {

                Utility.WriteTitle("Client - New Client");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Date Birth: ");
                bool tryParseDateBirth = DateTime.TryParse(Console.ReadLine(), out DateTime dateBirth);

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

                Console.Write("Comments: ");
                string comments = Console.ReadLine();

                Console.Write("Active: ");
                bool tryParseActive = Boolean.TryParse(Console.ReadLine(), out Boolean active);


                using (var db = new RSGymDBContext())
                {

                    var result = db.Client.FirstOrDefault(c => c.NIF == nif);


                    if (result == null)
                    {
                        newClientSucceed = true;

                        ICollection<Client> clients = new Collection<Client>
                        {
                            new Client { LocationID = locationID, Name = name, DateBirth = dateBirth, NIF = nif, Address = address, PhoneNumber = phoneNumber, Email = email, Comments = comments, Active = active}
                        };

                        db.Client.AddRange(clients);
                        db.SaveChanges();

                        Console.WriteLine("\n\nClient created with succeed!");
                    }
                    else
                    {
                        Console.WriteLine("\n\nThis Client already exists. Please confirm your details again.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }


            } while (!newClientSucceed);

        }

        public static void UpdateClient(User user)
        {

            Console.Clear();

            bool clientUpdatedSucceed = false;

            do
            {

                Utility.WriteTitle("Clients - Update");

                Console.Write("Name: ");
                string name = Console.ReadLine();


                using (var db = new RSGymDBContext())
                {
                    var result = db.Client.FirstOrDefault(c => c.Name == name);

                    if (result != null)
                    {

                        clientUpdatedSucceed = true;

                        Utility.WriteTitle("Clients - Update - New data");

                        Console.Write("Name: ");
                        string newName = Console.ReadLine();

                        Console.Write("Location: ");
                        bool tryParseLocation = Int16.TryParse(Console.ReadLine(), out Int16 locationID);

                        Console.Write("Date Birth: ");
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

                        Console.WriteLine("\n\nClient updated with succeed!");

                    }
                    else
                    {
                        Console.WriteLine("\n\nPlease confirm your name.");
                        Console.ReadKey();
                        Console.Clear();
                    }


                }

            } while (!clientUpdatedSucceed);

        }

        public static void ListClients(User user)
        {

            // Clientes ativos ordenados pelo nome
            using (var db = new RSGymDBContext())
            {

                var queryClients = db.Client.Select(c => c).Where(c => c.Active == true).OrderBy(c => c.Name);

                Console.Clear();

                Utility.WriteTitle("Clients - All Clients");

                queryClients.ToList().ForEach(c => Utility.WriteMessage($"Name: {c.Name}\nDate of birth: {c.DateBirth}\nNIF: {c.NIF}\nAddress: {c.Address}\nPostal Code: {c.Location.PostalCode}\nCity: {c.Location.City}\nComments: {c.Comments}\nActive: {c.Active}\n\n", "", "\n"));

            }

        }

        public static void ChangeClientStatus(User user)
        {

            Console.Clear();

            Utility.WriteTitle("Clients - Update Status");

            Console.Write("Confirm your NIF: ");
            string nif = Console.ReadLine();


            using (var db = new RSGymDBContext())
            {
                var result = db.Client.FirstOrDefault(c => c.NIF == nif);

                if (result != null)
                {

                    if (result.Active == true)
                    {
                        result.Active = false;


                        Console.WriteLine($"\n\nUpdate done successfully. Now your have a new status\n\nNew Status: {result.Active}");
                    }
                    else
                    {
                        result.Active = true;

                        Console.WriteLine($"\n\nUpdate done successfully. Now your have a new status\n\nNew Status: {result.Active}");
                    }


                    db.SaveChanges();

                }
                else
                {
                    Console.WriteLine("\n\nThe NIF entered does not exist. Please confirm your details again.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }


        #region Starting Clients

        public static void StartingClients()
        {

            ICollection<Client> clients = new Collection<Client>
            {
                new Client { LocationID = 2, PersonalTrainerID = 1, Name = "Client One", DateBirth = new DateTime (1996, 02, 26), NIF = "214456389", Address = "Rua do Client01", PhoneNumber = "919991872", Email = "client01@hotmail.com", Comments = "test1", Active = true},
                new Client { LocationID = 3, PersonalTrainerID = 2, Name = "Client Two", DateBirth = new DateTime (1990, 10, 02), NIF = "213459781", Address = "Rua do Client02", PhoneNumber = "964321942", Email = "client02@hotmail.com", Active = true},
                new Client { LocationID = 6, PersonalTrainerID = 1, Name = "Client Three", DateBirth = new DateTime (1988, 07, 22), NIF = "217458786", Address = "Rua do Client03", PhoneNumber = "931662873", Email = "client03@hotmail.com", Comments = "test3", Active = true},
            };

            using (var db = new RSGymDBContext())
            {
                db.Client.AddRange(clients);
                db.SaveChanges();
            }

        }

        #endregion

    }
}
