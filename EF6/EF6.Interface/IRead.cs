using System.Threading.Tasks;

namespace EF6.Interface
{
    public interface IRead<T> where T : class
    {
        T ById(int id);

        Task<T> ByIdAsync(int id);
    }
}