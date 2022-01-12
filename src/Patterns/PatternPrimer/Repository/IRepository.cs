namespace Repository
{
    public interface IRepository<TEntity, TIdentifier>
        where TEntity : IEntity<TIdentifier>
        where TIdentifier : struct
    {
    }
}