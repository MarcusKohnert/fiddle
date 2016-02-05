using System;
using System.Threading.Tasks;

namespace EF6.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}