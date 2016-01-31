namespace Models
{
    public class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int Version { get; protected set; }
    }
}