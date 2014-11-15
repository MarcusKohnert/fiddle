namespace EntityReloadingModelBinding.Models
{
    public class VMEntity : ViewModel<Entity>
    {
        public VMEntity()
            :base()
        { }

        public VMEntity(Entity entity)
            :base(entity)
        { }

        public int Id { get { return this.Entity.Id; } set { this.Entity.Id = value; } }

        public string Firstname { get { return this.Entity.Firstname; } set { this.Entity.Firstname = value; } }

        public string Lastname { get { return this.Entity.Lastname; } set { this.Entity.Lastname = value; } }

        public string SomeComplexType { get { return this.Entity.SomeComplexType; } }
    }
}