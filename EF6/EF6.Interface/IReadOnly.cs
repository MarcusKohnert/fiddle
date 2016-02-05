namespace EF6.Interface
{
    public interface IReadOnly<T> : IRead<T> where T : class
    { }
}