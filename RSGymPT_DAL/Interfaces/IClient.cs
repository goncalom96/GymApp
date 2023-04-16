using System;

namespace RSGymPT_DAL.Interfaces
{
    public interface IClient : IPerson
    {

        int ClientID { get; }
        int LocationID { get; }
        DateTime DateBirth { get; }
        string Comments { get; }
        bool Active { get; }

    }
}
