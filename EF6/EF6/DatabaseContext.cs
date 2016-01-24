using Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace EF6
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("efConString")
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
        }
    }
}