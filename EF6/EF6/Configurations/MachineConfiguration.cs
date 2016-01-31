using Models;
using System.Data.Entity.ModelConfiguration;

namespace EF6.Configurations
{
    internal class MachineConfiguration : EntityTypeConfiguration<Machine>
    {
        public MachineConfiguration()
        {
            this.ToTable("Machine");

            this.HasKey(_ => _.Id);
            this.Property(_ => _.Name)
                .HasColumnName("Name");

            this.Property(_ => _.Version)
                .IsConcurrencyToken();
        }
    }
}