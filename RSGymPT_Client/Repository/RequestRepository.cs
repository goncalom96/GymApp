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
    static class RequestRepository
    {

        #region Features
        public static void CreateRequest(User user)
        {

            Console.Clear();

            int clientID = Validation.ValidateClientIntNumber();

            int personalTrainerID = Validation.ValidatePersonalTrainerIntNumber();

            DateTime date = Validation.ValidateFutureDate();

            DateTime hour = Validation.ValidateHour();

            string comments = Validation.ValidateComments();

            using (var db = new RSGymDBContext())
            {

                var result1 = db.Client.FirstOrDefault(c => c.ClientID == clientID);

                var result2 = db.PersonalTrainer.FirstOrDefault(p => p.PersonalTrainerID == personalTrainerID);

                var result3 = db.Request.FirstOrDefault(r => r.Date == date && r.Hour == hour);


                if (result1 != null && result2 != null && result3 == null)
                {

                    ICollection<Request> requests = new Collection<Request>
                    {
                        new Request { ClientID = clientID, PersonalTrainerID = personalTrainerID, Date = date, Hour = hour, Status = Request.EnumStatus.Booked , Comments = comments}
                    };

                    db.Request.AddRange(requests);
                    db.SaveChanges();

                    Console.WriteLine("\n\nRequest created with succeed!");
                }
                else if(result3 != null)
                {
                    Console.WriteLine("\n\nYou need to choose another date.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\n\nPlease confirm your details again.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }


        }

        public static void ListRequests(User user)
        {

            Console.Clear();

            // Requests ordenados por Status, data e hora
            using (var db = new RSGymDBContext())
            {

                var queryClients = db.Request.Select(r => r).OrderBy(r => r.Status).ThenBy(r => r.Date).ThenBy(r => r.Hour);

                Console.Clear();

                Utility.WriteTitle("Requests - Request History");

                queryClients.ToList().ForEach(r => Utility.WriteMessage($"Client: {r.Client.Name}\nPersonal Trainer: {r.PersonalTrainer.Name}\nDate: {r.Date}\nHour: {r.Hour}\nStatus: {r.Status}\nComments: {r.Comments}\n\n", "", "\n"));

            }

        }
        #endregion

    }
}
