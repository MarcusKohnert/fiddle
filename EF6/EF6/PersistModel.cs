using EF6.Interface;
using Models;

namespace EF6
{
    internal class PersistModel<T> : IPersist<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        public PersistModel()
        {
            this.dbContext = new DatabaseContext();
        }

        public IResult<T> Persist(T entity)
        {
            this.dbContext
                .Set<T>()
                .Attach(entity);

            return Result<T>.Ok(entity);
        }
    }
}