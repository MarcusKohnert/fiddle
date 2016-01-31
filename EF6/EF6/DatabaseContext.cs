using EF6.Infrastructure;
using Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EF6
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("efConString")
        {
            Database.SetInitializer<DatabaseContext>(null);

            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);

            var softDeleteConvention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                                       "SoftDeleteColumnName",
                                       (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(softDeleteConvention);
        }
    }
}