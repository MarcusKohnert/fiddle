namespace EF6.Interface
{
    public interface IRead<T>
    {
        T By(int id);
    }
}