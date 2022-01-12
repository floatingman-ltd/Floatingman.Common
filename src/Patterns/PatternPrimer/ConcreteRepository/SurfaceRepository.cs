namespace ConcreteRepository
{
    using InterfaceRepository;
    using Repository.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class SurfaceRepository : ISurfaceRepository<int>
    {
        private IUnitOfWork<NHibernateContext> _context;

        private SurfaceRepository(IUnitOfWork<NHibernateContext> context)
        {
            _context = context;
        }

        #region Implementation of ISurfaceRepository<int>

        public IList<ISurface> AdjacentTo(IFeature feature)
        {
            throw new NotImplementedException();
        }

        public ISurface By(int id)
        {
            throw new NotImplementedException();
        }

        public ISurface Containing(IFeature feature)
        {
            throw new NotImplementedException();
        }

        public ISurfaceRepository<int> Get
        {
            get { return this; }
        }

        public IList<ISurface> Matching(Expression query)
        {
            throw new NotImplementedException();
        }

        #endregion Implementation of ISurfaceRepository<int>
    }
}