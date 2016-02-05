using EF6.Interface;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EF6
{
    public class ReadOnlyEntity<T> : IReadOnly<T> where T : class
    {
        private readonly DatabaseContext dBContext;

        public ReadOnlyEntity(IUnitOfWorkReadOnly unitOfWorkReadonly)
        {
            this.dBContext = (DatabaseContext)unitOfWorkReadonly;
        }

        public T ById(int id)
        {
            return this.dBContext
                       .Set<T>()
                       .AsNoTracking()
                       .SingleOrDefault();
        }

        public Task<T> ByIdAsync(int id)
        {
            return this.dBContext
                       .Set<T>()
                       .AsNoTracking()
                       .SingleOrDefaultAsync();
        }
    }
}