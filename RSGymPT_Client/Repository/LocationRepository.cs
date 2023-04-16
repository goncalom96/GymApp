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

        #region Features
        public static void CreateLocation(User user)
        {

            Console.Clear();

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

                        Console.WriteLine("\n\nLocation created with succeed!");

                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("\n\nAlready exist one location with the same postal code and city.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

            } while (!newLocationSucceed);

        }

        public static void ListLocations(User user)
        {

            // Locations ordenadas por cidades 
            using (var db = new RSGymDBContext())
            {

                var queryLocations = db.Location.Select(l => l).OrderBy(l => l.LocationID);

                Console.WriteLine("LIST OF LOCATIONS:");
                queryLocations.ToList().ForEach(l => Utility.WriteMessage($"\tLocation ID: {l.LocationID} - Postal Code: {l.PostalCode} - City: {l.City}\n", "", ""));

            }

        }

        public static void UpdateLocation(User user)
        {

            Console.Clear();

            bool locationUpdateSucceed = false;

            do
            {

                Utility.WriteTitle("Locations - Update - New data");

                Console.Write("Location ID: ");
                bool tryParseLocation = Int32.TryParse(Console.ReadLine(), out Int32 locationID);

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

                            Console.WriteLine("\n\nLocation updated with succeed!");
                        }
                        else
                        {
                            Console.WriteLine("\n\nAlready exist one location with the same postal code and city.");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }

                }

            } while (!locationUpdateSucceed);

        }

        public static void DeleteLocation(User user)
        {

            Console.Clear();

            Utility.WriteTitle("Locations - Delete");

            Console.Write("Location ID: ");
            bool tryParseLocation = Int32.TryParse(Console.ReadLine(), out Int32 locationID);

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
        #endregion

        #region Starting Locations

        public static void StartingLocations()
        {

            ICollection<Location> locations = new Collection<Location>
            {
                new Location { PostalCode = "1700-306", City = "Lisboa"},
                new Location { PostalCode = "4049-019" , City = "Porto"},
                new Location { PostalCode = "4700-432", City = "Braga"},
                new Location { PostalCode = "2520-400", City = "Peniche"},
                new Location { PostalCode = "8500-290", City = "Portimão"},
                new Location { PostalCode = "6000-111", City = "Castelo Branco"}
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
