namespace RSGymPT_DAL.Interfaces
{
    public interface IPersonalTrainer : IPerson
    {

        int PersonalTrainerID { get; }
        int LocationID { get; }
        string CodePT { get; }

    }
}
