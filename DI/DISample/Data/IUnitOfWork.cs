using System;

namespace DISample.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}