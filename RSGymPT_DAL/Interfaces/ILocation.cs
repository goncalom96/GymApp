namespace RSGymPT_DAL.Interfaces
{
    public interface ILocation
    {

        int LocationID { get; }
        string PostalCode { get; }
        string City { get; }

    }
}
