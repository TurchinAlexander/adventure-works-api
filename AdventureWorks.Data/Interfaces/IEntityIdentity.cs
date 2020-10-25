namespace AdventureWorks.Data.Interfaces
{
    public interface IEntityIdentity<T>
    {
        public T Id { get; set; }
    }
}