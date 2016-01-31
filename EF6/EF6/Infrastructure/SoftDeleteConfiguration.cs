using System.Data.Entity;

namespace EF6.Infrastructure
{
    internal class SoftDeleteConfiguration : DbConfiguration
    {
        public SoftDeleteConfiguration()
        {
            this.AddInterceptor(new SoftDeleteInterceptor());
        }
    }
}
