using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Policy;
using RSGymPT_DAL.Model;

namespace RSGymPT_DAL.Database
{
    public class RSGymDBContext : DbContext
    {
        #region Constructor

        public RSGymDBContext() : base("name=RSGymDBContext")
        {

        }

        #endregion

        #region BD Creation
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion

        #region dbSets

        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Location> Location { get; set; }


        #endregion
    }
}
