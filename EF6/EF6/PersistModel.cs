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

        public PersistModel(DatabaseContext databaseContext)
        {
            this.dbContext = databaseContext;
        }

        public IResult<T> Persist(T entity)
        {
            this.dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return Result<T>.Ok(entity);
        }
    }
}