using System;
using System.Linq;

namespace DISample.Data
{
    public class MemoryRepository<T> : IRepository<T> where T : IIdentifiable
    {
        private InMemorySession unitOfWork;

        public MemoryRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (InMemorySession)unitOfWork;

            if(this.unitOfWork == null)
                throw new ApplicationException("Received wrong concrete type of IUnitOfWork. Check DI configuration.");
        }

        public T Get(int id)
        {
            return (T)this.unitOfWork
                          .Query
                          .SingleOrDefault(_ => _.Id == id);
        }

        public void Save(T entity)
        {
            this.unitOfWork.Save(entity);
        }

        public void Delete(T entity)
        {
            this.unitOfWork.Delete(entity);
        }

        public void Delete(int id)
        {
            var e = this.Get(id);
            this.unitOfWork.Delete(e);
        }
        
        public IQueryable<IIdentifiable> Query()
        {
            return this.unitOfWork.Query;
        }
    }
}