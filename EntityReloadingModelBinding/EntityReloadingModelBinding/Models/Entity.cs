namespace EntityReloadingModelBinding.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string SomeComplexType { get; private set; }
    }
}