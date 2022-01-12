namespace InterfaceRepository
{
    using Repository;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ISurfaceRepository<TIdentifer> : IRepository<ISurface<TIdentifer>, TIdentifer>
        where TIdentifer : struct
    {
        IList<ISurface> AdjacentTo(IFeature feature);

        ISurface By(TIdentifer id);

        ISurface Containing(IFeature feature);

        // syntacitic sugar ... so functions can be written "Get.By(id)", perhaps this should be
        // pushed off to a base class as a static member.
        ISurfaceRepository<TIdentifer> Get { get; }

        IList<ISurface> Matching(Expression query);
    }
}