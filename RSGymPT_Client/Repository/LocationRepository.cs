using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppUtility;
using System.Linq;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;
using System;
using System.Data.Entity.Validation;

namespace RSGymPT_Client.Repository
{
    static class LocationRepository
    {

        public static void CreateLocation()
        {

            bool newLocationSucceed = false;

            do
            {

                Utility.WriteTitle("Locations - Create - New Location");

                Console.Write("Postal code: ");
                string postalCode = Console.ReadLine();

                Console.Write("City: ");
                string city = Console.ReadLine();

                using (var db = new RSGymDBContext())
                {
                    var result = db.Location.FirstOrDefault(l => l.PostalCode == postalCode && l.City == city);

                    if (result == null)
                    {

                        newLocationSucceed = true;

                        ICollection<Location> locations = new Collection<Location>
                            {
                                new Location { PostalCode = postalCode, City = city}
                            };

                        Utility.WriteTitle("Location - New Location");
                        Console.WriteLine("Location created with succeed!");

                        db.SaveChanges();
                    }
                    else
                    {
                        Utility.WriteTitle("Location - Error");
                        Console.WriteLine("Already exist one location with the same postal code and city.");
                    }

                }

            } while (!newLocationSucceed);

        }

        public static void ListLocations()
        {

            // Locations ordenadas por cidades 
            using (var db = new RSGymDBContext())
            {

                var queryLocations = db.Location.Select(l => l).OrderBy(l => l.City);

                Utility.WriteTitle("Locations - All locations");

                queryLocations.ToList().ForEach(l => Utility.WriteMessage($"Postal Code: {l.PostalCode}\nCity: {l.City}\n\n", "", "\n"));

            }

        }

        public static void UpdateLocation()
        {

            bool locationUpdateSucceed = false;

            do
            {

                Utility.WriteTitle("Locations - Update - New data");

                Console.Write("Location ID: ");
                bool tryParseLocation = Int16.TryParse(Console.ReadLine(), out Int16 locationID);

                Console.Write("Postal code: ");
                string postalCode = Console.ReadLine();

                Console.Write("City: ");
                string city = Console.ReadLine();

                using (var db = new RSGymDBContext())
                {
                    var result1 = db.Location.FirstOrDefault(l => l.LocationID == locationID);

                    if (result1 != null)
                    {
                        var result2 = db.Location.FirstOrDefault(l => l.PostalCode == postalCode && l.City == city);

                        if (result2 == null)
                        {
                            locationUpdateSucceed = true;

                            result1.PostalCode = postalCode;
                            result1.City = city;
                            db.SaveChanges();

                            Utility.WriteTitle("Location - Update");
                            Console.WriteLine("Location updated with succeed!");
                        }
                        else
                        {
                            Utility.WriteTitle("Location - Error");
                            Console.WriteLine("Already exist one location with the same postal code and city.");
                        }

                    }

                }

            } while (!locationUpdateSucceed);

        }

        public static void DeleteLocation()
        {

            Utility.WriteTitle("Locations - Delete");

            Console.Write("Location ID: ");
            bool tryParseLocation = Int16.TryParse(Console.ReadLine(), out Int16 locationID);

            using (var db = new RSGymDBContext())
            {
                var result = db.Location.FirstOrDefault(l => l.LocationID == locationID);

                if (result != null)
                {

                    db.Location.Remove(result);
                    db.SaveChanges();

                }

            }

        }


        #region Starting Locations

        public static void StartingLocations()
        {

            ICollection<Location> locations = new Collection<Location>
            {
                new Location { PostalCode = "1700-306", City = "Lisboa"},
                new Location { PostalCode = "1500-503", City = "Lisboa"},
                new Location { PostalCode = "4000-996" , City = "Porto"},
                new Location { PostalCode = "4049-019" , City = "Porto"},
                new Location { PostalCode = "4700-442", City = "Braga"},
                new Location { PostalCode = "2520-400", City = "Peniche"}
            };

            using (var db = new RSGymDBContext())
            {

                db.Location.AddRange(locations);
                db.SaveChanges();

            }

        }

        #endregion


    }


}
