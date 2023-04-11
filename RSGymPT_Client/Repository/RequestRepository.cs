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
    static class RequestRepository
    {
        public static void CreateRequest(int clientID, int personalTrainerID, DateTime date, DateTime hour, Request.EnumStatus enumStatus, string comments)
        {


            // ToDo: Validar a existência do Client, PersonalTrainere e Agendamento antes de o criar

            ICollection<Request> requests = new Collection<Request>
            {
                new Request { ClientID = clientID, PersonalTrainerID = personalTrainerID, Date = date, Hour = hour, Status = enumStatus, Comments = comments}
            };

            // ToDo: clients.Add() -> Adiciono os clients à parte?

            using (var db = new RSGymDBContext())
            {
                db.Request.AddRange(requests);
                db.SaveChanges();
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
