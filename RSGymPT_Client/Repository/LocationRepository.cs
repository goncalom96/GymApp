using System.Collections.Generic;
using System.Collections.ObjectModel;
using AppUtility;
using System.Linq;
using RSGymPT_DAL.Database;
using RSGymPT_DAL.Model;
using System;

namespace RSGymPT_Client.Repository
{
    static class LocationRepository
    {

        public static void CreateLocation(string postalCode, string city)
        {

            ICollection<Location> locations = new Collection<Location>
            {
                new Location { PostalCode = postalCode, City = city}
            };

            using (var db = new RSGymDBContext())
            {
                db.Location.AddRange(locations);
                db.SaveChanges();
            }

        }

        public static void ListLocations(ICollection<Location> locations)
        {

            // Locations ordenadas por cidades 
            using (var db = new RSGymDBContext())
            {

                var queryLocations = db.Location.Select(l => l).OrderBy(l => l.City);

                Utility.WriteTitle("Locations - All locations");

                queryLocations.ToList().ForEach(l => Utility.WriteMessage($"Postal Code: {l.PostalCode}\nCity: {l.City}\n\n", "", "\n"));

            }

        }

        public static void UpdateLocation(int locationID)
        {
            using (var db = new RSGymDBContext())
            {
                var result = db.Location.FirstOrDefault(l => l.LocationID == locationID);

                if (result != null)
                {

                    Utility.WriteTitle("Locations - Update - New data");

                    #region Postal code
                    Console.Write("Postal code: ");
                    string postalCode = Console.ReadLine();

                    var result2 = db.Location.FirstOrDefault(l => l.PostalCode == postalCode);
                    if (result2 == null)
                    {
                        result.PostalCode = postalCode;
                    }
                    else
                    {
                        Console.WriteLine("Already exist one postal code.\nDo you wanna update that postal code?\n1 - Yes\n2 - No");
                        bool tryParseValue = Int16.TryParse(Console.ReadLine(), out Int16 value);

                        switch (value)
                        {
                            case 1:
                                result.PostalCode = postalCode;
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Non-existent operation");
                                break;
                        }

                    }
                    #endregion

                    #region City
                    Console.Write("City: ");
                    string city = Console.ReadLine();

                    result.City = city;
                    #endregion

                    db.SaveChanges();

                }


            }


        }

        public static void DeleteLocation(int locationID)
        {

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

    }
}
