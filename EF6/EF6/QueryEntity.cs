using EF6.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6
{
    internal class QueryEntity<T> : IQuery<T> where T : class
    {
        private readonly DatabaseContext dbContext;

        public QueryEntity(IUnitOfWork unitOfWork)
        {
            this.dbContext = (DatabaseContext)unitOfWork;
        }

        public IQueryable<T> Query()
        {
            return this.dbContext
                       .Set<T>();
        }

        public Task<IQueryable<T>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}