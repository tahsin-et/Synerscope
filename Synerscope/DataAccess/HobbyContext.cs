using Synerscope.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Synerscope.DataAccess
{
    public class HobbiesContext : DbContext
    {
        // DB definition
        public HobbiesContext() : base("HobbiesContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}