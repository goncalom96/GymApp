using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;
using AppUtility;
using System.Collections.ObjectModel;

namespace RSGymPT_Client.Repository
{
    static class UserRepository
    {

        public static void CreateUser(string username, string userCode, string password, User.EnumProfile enumProfile)
        {

            // ToDo: Validar a existência do User antes de o criar

            ICollection<User> users = new Collection<User>
            {
                new User { Username = "UserTest01", UserCode = "User01", Password = "test12345678", Profile = User.EnumProfile.admin},
                new User { Username = "UserTest02", UserCode = "User02", Password = "test12345678", Profile = User.EnumProfile.colab},
                new User { Username = "UserTest03", UserCode = "User03", Password = "test12345678", Profile = User.EnumProfile.colab},
                new User { Username = username, UserCode = userCode, Password = password, Profile = enumProfile}
            };

            using (var db = new RSGymDBContext())
            {
                db.User.AddRange(users);
                db.SaveChanges();
            }

        }

        public static void ListUsers()
        {

            // Users ordenadas por code 
            using (var db = new RSGymDBContext())
            {

                var queryUsers = db.User.Select(u => u).OrderBy(u => u.UserCode);

                Utility.WriteTitle("Users - All users");

                queryUsers.ToList().ForEach(u => Utility.WriteMessage($"Username: {u.Username}\nCode: {u.UserCode}\nPassword: {u.Password}\nProfile: {u.Profile}\n\n", "", "\n"));

            }

        }

        public static void UpdateUser(string userCode)
        {
            using (var db = new RSGymDBContext())
            {
                var result = db.User.FirstOrDefault(u => u.UserCode == userCode);

                if (result != null)
                {

                    Utility.WriteTitle("User - Update - New password");

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    result.Password = password;

                    db.SaveChanges();

                }

            }


        }

    }
}
