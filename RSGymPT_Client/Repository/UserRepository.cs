using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;
using AppUtility;
using System.Collections.ObjectModel;
using static RSGymPT_DAL.Model.User;

namespace RSGymPT_Client.Repository
{
    static class UserRepository
    {

        public static void CreateUser()
        {

            // ToDo: Validar a existência do User antes de o criar

            bool newUserSucceed = false;

            do
            {

                Utility.WriteTitle("User - New User");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("UserCode: ");
                string userCode = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write($"Profile Options:\n");
                foreach (var item in Enum.GetValues(typeof(User.EnumProfile)))
                {
                    Console.Write($"{(int)item} - {item}\n");
                }
                User.EnumProfile profile = (User.EnumProfile)Convert.ToInt16(Console.ReadLine());

                Console.Clear();

                using (var db = new RSGymDBContext())
                {

                    var result = db.User.FirstOrDefault(u => u.Username == username || u.UserCode == userCode);


                    if (result == null)
                    {
                        newUserSucceed = true;

                        ICollection<User> users = new Collection<User>
                        {
                            new User { Username = username, UserCode = userCode, Password = password, Profile = profile }
                        };

                        db.User.AddRange(users);
                        db.SaveChanges();

                        Utility.WriteTitle("User - New User");
                        Console.WriteLine("User created with succeed!");
                    }
                    else if (result.Username == username && result.UserCode == userCode)
                    {
                        Utility.WriteTitle("User - Error");
                        Console.WriteLine("You need to choose another Username and UserCode");
                    }
                    else if (result.Username == username)
                    {
                        Utility.WriteTitle("User - Error");
                        Console.WriteLine("You need to choose another Username");
                    }
                    else
                    {
                        Utility.WriteTitle("User - Error");
                        Console.WriteLine("You need to choose another UserCode");
                    }

                }

            } while (!newUserSucceed);

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

        public static void UpdateUser()
        {

            bool updateSucceed = false;

            do
            {

                Utility.WriteTitle("User - Update - New password");

                Console.Write("Please confirm your code: ");
                string userCode = Console.ReadLine();

                Console.Write("New password: ");
                string password = Console.ReadLine();

                Console.Clear();

                using (var db = new RSGymDBContext())
                {
                    var result = db.User.FirstOrDefault(u => u.UserCode == userCode);

                    if (result != null)
                    {

                        updateSucceed = true;

                        result.Password = password;

                        db.SaveChanges();

                        Utility.WriteTitle("User - Update - New password");
                        Console.WriteLine("Successful update! You have a new password.");

                    }
                    else
                    {
                        Utility.WriteTitle("User - Update error");
                        Console.WriteLine("Check your code.");
                    }

                }

            } while (!updateSucceed);

        }

        #region Starting Users
        public static void StartingUsers()
        {

            ICollection<User> users = new Collection<User>
            {
                new User { Username = "UserTest01", UserCode = "User01", Password = "test12345678", Profile = User.EnumProfile.admin},
                new User { Username = "UserTest02", UserCode = "User02", Password = "test12345678", Profile = User.EnumProfile.colab},
                new User { Username = "UserTest03", UserCode = "User03", Password = "test12345678", Profile = User.EnumProfile.colab},
            };

            using (var db = new RSGymDBContext())
            {
                db.User.AddRange(users);
                db.SaveChanges();
            }

        }
        #endregion

        #region Validations
        public static (string, string) ReadCredentials()
        {

            Utility.WriteTitle("User - Login");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            return (username, password);
        }


        #endregion

    }
}
