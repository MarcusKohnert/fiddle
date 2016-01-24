using Models;

namespace EF6.Interface
{
    public interface IPersist<T> where T : class
    {
        IResult<T> Persist(T entity);
    }
}