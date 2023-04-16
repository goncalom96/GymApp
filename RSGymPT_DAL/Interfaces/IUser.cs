using static RSGymPT_DAL.Model.User;

namespace RSGymPT_DAL.Interfaces
{
    public interface IUser
    {

        int UserID { get; }

        string Username { get; set; }

        string UserCode { get; }

        string Password { get; }

        EnumProfile Profile { get; }

    }
}
