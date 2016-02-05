using EF6.Interface;
using System.Threading.Tasks;

namespace EF6
{
    internal class ReadEntity<T> : IRead<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        public ReadEntity(IUnitOfWork unitOfWork)
        {
            this.dbContext = (DatabaseContext)unitOfWork;
        }

        public T ById(int id)
        {
            return this.dbContext
                       .Set<T>()
                       .Find(id);
        }

        public Task<T> ByIdAsync(int id)
        {
            return this.dbContext
                       .Set<T>()
                       .FindAsync(id);
        }
    }
}