using System.Linq;
namespace DISample.Data
{
    public interface IRepository<T> where T : IIdentifiable
    {
        T Get(int id);

        IQueryable<IIdentifiable> Query();

        void Save(T entity);

        void Delete(T entity);

        void Delete(int id);
    }
}