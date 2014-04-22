namespace JamesDibble.ApplicationFramework.Data.UnitOfWork
{
    using System;
    using System.Data.Entity;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    public interface IUnitOfWork : IDisposable
    {
        DbContext CurrentContext { get; }

        void Commit();

        IRepository<T> GetRepository<T>() where T : class, IPersistedObject;
    }
}

