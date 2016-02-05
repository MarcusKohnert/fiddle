using System.Linq;
using System.Threading.Tasks;

namespace EF6.Interface
{
    public interface IQuery<T> where T : class
    {
        IQueryable<T> Query();

        Task<IQueryable<T>> QueryAsync();
    }
}