namespace EF6.Interface
{
    public interface IQueryReadonly<T> : IQuery<T> where T : class
    { }
}