using EF6.Interface;
using System.Threading.Tasks;

namespace EF6
{
    internal class ReadModel<T> : IRead<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        public ReadModel()
        {
            this.dbContext = new DatabaseContext();
        }

        public ReadModel(DatabaseContext databaseContext)
        {
            this.dbContext = databaseContext;
        }

        public T By(int id)
        {
            return this.dbContext
                       .Set<T>()
                       .Find(id);
        }

        public Task<T> ByAsync(int id)
        {
            return this.dbContext
                       .Set<T>()
                       .FindAsync(id);
        }
    }
}