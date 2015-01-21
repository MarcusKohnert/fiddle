using System.Collections.Generic;
using System.Linq;

namespace DISample.Data
{
    public class InMemorySession : IUnitOfWork
    {
        private readonly IList<IIdentifiable> store;

        public InMemorySession()
        {
            this.store = new List<IIdentifiable>();
        }

        public void Delete(IIdentifiable e)
        {
            this.store.Remove(e);
        }

        public IQueryable<IIdentifiable> Query { get { return this.store.AsQueryable(); } }

        public void Save(IIdentifiable entity)
        {
            if (entity.Id == 0)
            {
                if (this.store.Any() == false)
                    entity.Id = 1;
                else
                    entity.Id = this.store.Max(_ => _.Id) + 1;
            }

            this.store.Add(entity);
        }
        
        public void SaveChanges()
        {
        }

        public void Dispose()
        {
        }
    }
}