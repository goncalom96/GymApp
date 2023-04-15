using System;
using System.Text.RegularExpressions;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.InputValidation
{
    static class Validation
    {

        #region User
        public static string ValidateUserName()
        {

            bool validName = false;

            string username;

            Console.Write("Username: ");

            do
            {

                username = Console.ReadLine();

                if (username.Length <= 100)
                {
                    validName = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Username should have a maximum of 100 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validName);

            return username;

        }

        public static string ValidateUserCode()
        {

            bool validCode = false;

            string userCode;

            Console.Write("UserCode: ");

            do
            {

                userCode = Console.ReadLine();

                if (userCode.Length >= 4 && userCode.Length <= 6)
                {
                    validCode = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! The UserCode must be between 4 and 6 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validCode);

            return userCode;

        }

        public static string ValidatePassword()
        {

            bool validPassword = false;

            string password;

            Console.Write("Password: ");

            do
            {

                password = Console.ReadLine();

                if (password.Length >= 8 && password.Length <= 12)
                {
                    validPassword = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! The password must be between 8 and 12 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validPassword);

            return password;

        }

        public static User.EnumProfile ValidateProfile()
        {

            bool validProfile = false;

            User.EnumProfile profile;

            Console.Write("Profile (1 - admin | 2 - colab): ");

            do
            {

                if (Enum.TryParse(Console.ReadLine(), out profile))
                {
                    if (Enum.IsDefined(typeof(User.EnumProfile), profile))
                    {
                        validProfile = true;
                    }
                    else
                    {
                        Console.WriteLine("\tInvalid! This profile does not exist. Try again.");
                        Console.Write("\t>> ");
                    }
                }
                else
                {
                    Console.WriteLine("\tInvalid input. Please try again.");
                    Console.Write("\t>> ");
                }


            } while (!validProfile);

            return profile;

        }
        #endregion

        #region Client and Personal Trainer

        public static string ValidateName()
        {

            bool validName = false;

            string name;

            Console.Write("Name: ");

            do
            {

                name = Console.ReadLine();

                if (Regex.IsMatch(name, @"^[^0-9]+$") && name.Length <= 100)
                {
                    validName = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Name should have a maximum of 100 characters and numbers are not allowed.");
                    Console.Write("\t>> ");
                }

            } while (!validName);

            return name;

        }

        public static DateTime ValidateDateBirth()
        {

            bool validDateBirth = false;

            DateTime dateBirth;

            Console.Write("Date Birth (dd/MM/yyyy): ");

            do
            {

                if (DateTime.TryParse(Console.ReadLine(), out dateBirth) == true)
                {
                    validDateBirth = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you put the date in the correct format.");
                    Console.Write("\t>> ");
                }

            } while (!validDateBirth);

            return dateBirth;

        }

        public static string ValidateNIF()
        {

            bool validNIF = false;

            string nif;

            Console.Write("NIF: ");

            do
            {

                nif = Console.ReadLine();

                if (Regex.IsMatch(nif, @"([0-9]+)") && nif.Length == 9)
                {
                    validNIF = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! NIF must contain exactly 9 numbers.");
                    Console.Write("\t>> ");
                }

            } while (!validNIF);

            return nif;

        }

        public static string ValidateEmail()
        {

            bool validEmail = false;

            string email;

            Console.Write("Email: ");

            do
            {

                email = Console.ReadLine();

                if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") && email.Length >= 5 && email.Length <= 100)
                {
                    validEmail = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you put the Email in the correct format and contain between 5 to 100 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validEmail);

            return email;

        }

        public static string ValidatePhoneNumber()
        {

            bool validPhoneNumber = false;

            string phoneNumber;

            Console.Write("Phone number: ");

            do
            {

                phoneNumber = Console.ReadLine();

                if (Regex.IsMatch(phoneNumber, @"([0-9]+)") && phoneNumber.Length == 9)
                {
                    validPhoneNumber = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Phone number must contain exactly 9 numbers.");
                    Console.Write("\t>> ");
                }

            } while (!validPhoneNumber);

            return phoneNumber;

        }

        public static int ValidateLocationIntNumber()
        {

            bool validNumber = false;

            int locationID;

            Console.Write("Location ID: ");

            do
            {

                if (Int32.TryParse(Console.ReadLine(), out locationID) == true)
                {
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you only enter the location ID with numbers.");
                    Console.Write("\t>> ");
                }

            } while (!validNumber);

            return locationID;

        }

        public static string ValidateAddress()
        {

            bool validAddress = false;

            string address;

            Console.Write("Address: ");

            do
            {

                address = Console.ReadLine();

                if (address.Length <= 100)
                {
                    validAddress = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Address should have a maximum of 100 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validAddress);

            return address;

        }

        public static string ValidateComments()
        {

            bool validComments = false;

            string comments;

            Console.Write("Comments: ");
            do
            {

                comments = Console.ReadLine();

                if (comments.Length <= 255)
                {
                    validComments = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Comments should have a maximum of 255 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validComments);

            return comments;

        }

        public static string ValidatePersonalTrainerCode()
        {

            bool validCode = false;

            string code;

            Console.Write("Code: ");

            do
            {

                code = Console.ReadLine();

                if (code.Length == 4)
                {
                    validCode = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! The code must be exactly 4 characters.");
                    Console.Write("\t>> ");
                }

            } while (!validCode);

            return code;

        }

        #endregion

        #region Request
        public static int ValidatePersonalTrainerIntNumber()
        {

            bool validNumber = false;

            int personalTrainerID;

            Console.Write("PersonalTrainer ID: ");

            do
            {

                if (Int32.TryParse(Console.ReadLine(), out personalTrainerID) == true)
                {
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you only enter the PersonalTrainer ID with numbers.");
                    Console.Write("\t>> ");
                }

            } while (!validNumber);

            return personalTrainerID;

        }

        public static int ValidateClientIntNumber()
        {

            bool validNumber = false;

            int clientID;

            Console.Write("Client ID: ");

            do
            {

                if (Int32.TryParse(Console.ReadLine(), out clientID) == true)
                {
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you only enter the Client ID with numbers.");
                    Console.Write("\t>> ");
                }

            } while (!validNumber);

            return clientID;

        }

        public static DateTime ValidateFutureDate()
        {

            bool validDate = false;

            DateTime date;

            Console.Write("Date (dd/MM/yyyy): ");

            do
            {

                DateTime.TryParse(Console.ReadLine(), out date);

                if (date >= DateTime.Now)
                {
                    validDate = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Do you want to book a session in the past?");
                    Console.Write("\t>> ");
                }

            } while (!validDate);

            return date;
        }

        public static DateTime ValidateHour()
        {

            bool validHour = false;

            DateTime hour;

            Console.Write("Hour (hh:mm): ");

            do
            {

                if (DateTime.TryParse(Console.ReadLine(), out hour) == true)
                {
                    validHour = true;
                }
                else
                {
                    Console.WriteLine("\tInvalid! Make sure you put the hour in the correct format.");
                    Console.Write("\t>> ");
                }

            } while (!validHour);

            return hour;

        }

        public static Request.EnumStatus ValidateStatus()
        {

            bool validStatus = false;

            Request.EnumStatus status;

            Console.Write("Status: ");

            do
            {

                if (Enum.TryParse(Console.ReadLine(), out status))
                {
                    if (Enum.IsDefined(typeof(Request.EnumStatus), status))
                    {
                        validStatus = true;
                    }
                    else
                    {
                        Console.WriteLine("\tInvalid! This status does not exist. Try again.");
                        Console.Write("\t>> ");
                    }
                }
                else
                {
                    Console.WriteLine("\tInvalid input. Please try again.");
                    Console.Write("\t>> ");
                }


            } while (!validStatus);

            return status;

        }
        #endregion

    }
}
