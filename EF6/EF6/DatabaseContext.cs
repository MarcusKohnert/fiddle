using EF6.Infrastructure;
using EF6.Interface;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace EF6
{
    internal class DatabaseContext : DbContext, IUnitOfWork
    {
        public DatabaseContext()
            : base("efConString")
        {
            Database.SetInitializer<DatabaseContext>(null);

            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Machine> Machines { get; set; }

        public void Commit()
        {
            this.SaveChanges();
        }

        public Task CommitAsync()
        {
            return this.SaveChangesAsync();
        }

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