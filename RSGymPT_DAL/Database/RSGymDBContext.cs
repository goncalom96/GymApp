using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Policy;

namespace RSGymPT_DAL.Database
{
    internal class RSGymDBContext : DbContext
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
        // ToDo: Completar
        /*
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }
        */
        #endregion
    }
}
