namespace DISample.Data
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }

    public class Identifiable : IIdentifiable
    {
        public int Id { get; set; }
    }
}