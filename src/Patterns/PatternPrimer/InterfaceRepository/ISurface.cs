namespace InterfaceRepository
{
    using Repository;

    public interface ISurface<TIdentifier> : ISurface, IEntity<TIdentifier>
        where TIdentifier : struct
    {
    }

    public interface ISurface
    {
    }
}