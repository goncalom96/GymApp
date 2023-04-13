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
    static class RequestRepository
    {
        public static void CreateRequest()
        {

            // ToDo: Validar a existência do Client, PersonalTrainer e Agendamento antes de o criar

            Console.Write("Client ID: ");
            bool tryParseClientID = Int16.TryParse(Console.ReadLine(), out Int16 clientID);

            Console.Write("PersonalTrainer ID: ");
            bool tryParsePersonalTrainerID = Int16.TryParse(Console.ReadLine(), out Int16 personalTrainerID);

            Console.Write("Date: ");
            bool tryParseDate = DateTime.TryParse(Console.ReadLine(), out DateTime date);

            Console.Write("Hour: ");
            bool tryParseHour = DateTime.TryParse(Console.ReadLine(), out DateTime hour);

            Console.Write("Status: ");
            Request.EnumStatus status = (Request.EnumStatus)Convert.ToInt16(Console.ReadLine());

            Console.Write("Comments: ");
            string comments = Console.ReadLine();


            using (var db = new RSGymDBContext())
            {

                var result1 = db.Client.FirstOrDefault(c => c.ClientID == clientID);

                var result2 = db.PersonalTrainer.FirstOrDefault(p => p.PersonalTrainerID == personalTrainerID);

                var result3 = db.Request.FirstOrDefault(r => r.Date == date && r.Hour == hour);


                if (result1 != null && result2 != null && (result2 == null && result3 != null))
                {

                    ICollection<Request> requests = new Collection<Request>
                    {
                        new Request { ClientID = clientID, PersonalTrainerID = personalTrainerID, Date = date, Hour = hour, Status = Request.EnumStatus.Booked , Comments = comments}
                    };

                    db.Request.AddRange(requests);
                    db.SaveChanges();

                    Utility.WriteTitle("Request - New request");
                    Console.WriteLine("Request created with succeed!");
                }
                else
                {
                    Utility.WriteTitle("Request - Error");
                    Console.WriteLine("The NIF entered already exists. Please confirm your details again.");
                }

            }


        }

        public static void ListRequests()
        {
            // Requests ordenados por Status, data e hora
            using (var db = new RSGymDBContext())
            {

                var queryClients = db.Request.Select(r => r).OrderBy(r => r.Status).ThenBy(r => r.Date).ThenBy(r => r.Hour);

                Utility.WriteTitle("Requests - Request History");

                queryClients.ToList().ForEach(r => Utility.WriteMessage($"Client: {r.Client.Name}\nPersonal Trainer: {r.PersonalTrainer.Name}\nDate: {r.Date}\nHour: {r.Hour}\nStatus: {r.Status}\nComments: {r.Comments}\n\n", "", "\n"));

            }

        }


    }
}
