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
    static class ClientRepository
    {

        #region Features
        public static void CreateClient(User user)
        {

            Console.Clear();

            bool newClientSucceed = false;

            do
            {

                Utility.WriteTitle("Client - Create");

                string name = Validation.ValidateName();

                DateTime dateBirth = Validation.ValidateDateBirth();

                string nif = Validation.ValidateNIF();

                int locationID = Validation.ValidateLocationIntNumber(user);

                string address = Validation.ValidateAddress();

                string phoneNumber = Validation.ValidatePhoneNumber();

                string email = Validation.ValidateEmail();

                string comments = Validation.ValidateComments();


                using (var db = new RSGymDBContext())
                {

                    var result1 = db.Client.FirstOrDefault(c => c.NIF == nif);

                    var result2 = db.Location.FirstOrDefault(l => l.LocationID == locationID);


                    if (result1 == null && result2 != null)
                    {
                        newClientSucceed = true;

                        ICollection<Client> clients = new Collection<Client>
                        {
                            new Client { LocationID = locationID, Name = name, DateBirth = dateBirth, NIF = nif, Address = address, PhoneNumber = phoneNumber, Email = email, Comments = comments, Active = true}
                        };

                        db.Client.AddRange(clients);
                        db.SaveChanges();

                        Console.WriteLine("\n\nClient created with succeed!");
                    }
                    else if (result2 == null)
                    {
                        Console.WriteLine("\n\nInvalid! This location does not exist.");

                        // Perguntar se quer adicionar?
                        // LocationRepository.CreateLocation(user);

                        Console.ReadKey();
                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("\n\nInvalid! This Client already exists. Please confirm your details again.");
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

                Console.WriteLine("Validation data");
                string name = Validation.ValidateName();


                using (var db = new RSGymDBContext())
                {
                    var result1 = db.Client.FirstOrDefault(c => c.Name == name);

                    if (result1 != null)
                    {

                        Console.Clear();

                        Utility.WriteTitle("Clients - Update - New data");

                        string newName = Validation.ValidateName();

                        DateTime dateBirth = Validation.ValidateDateBirth();

                        int locationID = Validation.ValidateLocationIntNumber(user);

                        string address = Validation.ValidateAddress();

                        string phoneNumber = Validation.ValidatePhoneNumber();

                        string email = Validation.ValidateEmail();

                        string comments = Validation.ValidateComments();

                        var result2 = db.Location.FirstOrDefault(l => l.LocationID == locationID);

                        if (result2 != null)
                        {

                            clientUpdatedSucceed = true;

                            result1.Name = newName;
                            result1.LocationID = locationID;
                            result1.DateBirth = dateBirth;
                            result1.Address = address;
                            result1.PhoneNumber = phoneNumber;
                            result1.Email = email;
                            result1.Comments = comments;

                            db.SaveChanges();

                            Console.WriteLine("\n\nClient updated with succeed!");

                        }

                    }
                    else
                    {
                        Console.WriteLine("\n\nInvalid! Please confirm your name.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

            } while (!clientUpdatedSucceed);

        }

        public static void ListClients(User user)
        {

            Console.Clear();

            // Clientes ativos ordenados pelo nome
            using (var db = new RSGymDBContext())
            {

                var queryClients = db.Client.Where(c => c.Active == true).OrderBy(c => c.Name);

                Utility.WriteTitle("Clients - All Clients");

                queryClients.ToList().ForEach(c => Utility.WriteMessage($"Name: {c.Name}\nDate of birth: {c.DateBirth.ToShortDateString()}\nNIF: {c.NIF}\nAddress: {c.Address}\nPostal Code: {c.Location.PostalCode}\nCity: {c.Location.City}\nComments: {c.Comments}\nActive: {c.Active}\n\n", "", "\n"));

            }

        }

        public static void ChangeClientStatus(User user)
        {

            Console.Clear();

            bool clientUpdatedStatusSucceed = false;

            do
            {
                Utility.WriteTitle("Clients - Update Status");

                Console.WriteLine("Validation data");
                string nif = Validation.ValidateNIF();


                using (var db = new RSGymDBContext())
                {
                    var result = db.Client.FirstOrDefault(c => c.NIF == nif);

                    if (result != null)
                    {

                        clientUpdatedStatusSucceed = true;

                        if (result.Active == true)
                        {
                            result.Active = false;

                            Console.WriteLine($"\n\nClient updated with succeed! Now your have a new status\n\nActive: {result.Active}");
                        }
                        else
                        {
                            result.Active = true;

                            Console.WriteLine($"\n\nClient updated with succeed! Now your have a new status\n\nActive: {result.Active}");
                        }

                        db.SaveChanges();

                    }
                    else
                    {
                        Console.WriteLine("\n\nInvalid! The NIF entered does not exist. Please confirm your details again.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            } while (!clientUpdatedStatusSucceed);


        }
        #endregion

        #region Starting Clients

        public static void StartingClients()
        {

            ICollection<Client> clients = new Collection<Client>
            {
                new Client {  Name = "Client One", DateBirth = new DateTime (1996, 02, 26), NIF = "214456389", LocationID = 1, Address = "Rua do Client01", PhoneNumber = "919991872", Email = "client01@hotmail.com", Comments = "test1", Active = true},
                new Client {  Name = "Client Two", DateBirth = new DateTime (1990, 10, 02), NIF = "213459781", LocationID = 2, Address = "Rua do Client02", PhoneNumber = "964321942", Email = "client02@hotmail.com", Active = true},
                new Client {  Name = "Client Three", DateBirth = new DateTime (1988, 07, 22), NIF = "217458786", LocationID = 3, Address = "Rua do Client03", PhoneNumber = "931662873", Email = "client03@hotmail.com", Comments = "test3", Active = true},
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
