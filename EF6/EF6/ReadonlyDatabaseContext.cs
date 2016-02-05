using EF6.Interface;

namespace EF6
{
    internal class ReadDatabaseContext : DatabaseContext, IUnitOfWorkReadOnly
    {
    }
}