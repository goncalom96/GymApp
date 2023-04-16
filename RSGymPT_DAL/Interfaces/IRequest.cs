using System;
using static RSGymPT_DAL.Model.Request;

namespace RSGymPT_DAL.Interfaces
{
    public interface IRequest
    {

        int RequestID { get; }

        int ClientID { get; }

        int PersonalTrainerID { get; }

        DateTime Date { get; }

        TimeSpan Hour { get; }

        EnumStatus Status { get; }

        string Comments { get; }

    }
}
