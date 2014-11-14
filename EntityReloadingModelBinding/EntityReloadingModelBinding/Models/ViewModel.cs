namespace EntityReloadingModelBinding.Models
{
    public abstract class ViewModel<T>
    {
        public ViewModel()
        {
            this.Entity = default(T);
        }

        public ViewModel(T entity)
        {
            this.Entity = entity;
        }

        public T Entity { get; private set; }
    }
}