namespace Repository.UnitOfWork
{
    using System;

    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : IDataContext
    {
        TContext Context { get; }

        void Commit();

        void Rollback();
    }
}