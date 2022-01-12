namespace Repository
{
    public interface IEntity<TIdentifier>
        where TIdentifier : struct
    {
        TIdentifier Identifier { get; set; }
    }
}