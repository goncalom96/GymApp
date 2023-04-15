using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppUtility;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    static class UserRepository
    {

        #region Features
        public static void CreateUser(User user)
        {

            bool newUserSucceed = false;

            do
            {

                Utility.WriteTitle("User - Create");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("UserCode: ");
                string userCode = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write($"Profile (1 - admin | 2 - colab): ");
                User.EnumProfile profile = (User.EnumProfile)Convert.ToInt16(Console.ReadLine());


                using (var db = new RSGymDBContext())
                {

                    var result1 = db.User.FirstOrDefault(u => u.Username == username);

                    var result2 = db.User.FirstOrDefault(u => u.UserCode == userCode);

                    if (result1 == null && result2 == null)
                    {
                        newUserSucceed = true;

                        ICollection<User> users = new Collection<User>
                        {
                            new User { Username = username, UserCode = userCode, Password = password, Profile = profile }
                        };

                        db.User.AddRange(users);
                        db.SaveChanges();

                        Console.WriteLine("\n\nUser created with succeed!");

                    }
                    else if (result1 != null && result2 != null) // ToDo: Está a dar erro
                    {
                        Console.WriteLine("\n\nYou need to choose another Username and UserCode.");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (result1 != null)
                    {
                        Console.WriteLine("\n\nYou need to choose another Username.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou need to choose another UserCode.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

            } while (!newUserSucceed);

        }

        public static void ListUsers(User user)
        {

            // Users ordenadas por code 
            using (var db = new RSGymDBContext())
            {

                var queryUsers = db.User.Select(u => u).OrderBy(u => u.UserCode);

                Utility.WriteTitle("Users - All users");

                queryUsers.ToList().ForEach(u => Utility.WriteMessage($"Username: {u.Username}\nCode: {u.UserCode}\nPassword: {u.Password}\nProfile: {u.Profile}\n\n", "", "\n"));

            }

        }

        public static void UpdateUser(User user)
        {

            Console.Clear();

            bool updateSucceed = false;

            do
            {

                Utility.WriteTitle("User - Update");

                Console.Write("Confirm your UserCode: ");
                string userCode = Console.ReadLine();

                Console.Write("New password: ");
                string password = Console.ReadLine();


                using (var db = new RSGymDBContext())
                {
                    var result = db.User.FirstOrDefault(u => u.UserCode == userCode);

                    if (result != null)
                    {

                        updateSucceed = true;

                        result.Password = password;

                        db.SaveChanges();

                        Console.WriteLine("\n\nUser updated with succeed!\nYou have a new password.");

                    }
                    else
                    {
                        Console.WriteLine("\n\nPlease confirm your UserCode.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

            } while (!updateSucceed);

        }

        #endregion

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
