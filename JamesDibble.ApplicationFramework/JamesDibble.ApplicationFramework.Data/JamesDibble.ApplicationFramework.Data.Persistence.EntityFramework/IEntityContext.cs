// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFramework
{
    using System.Data.Entity;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// Implementing classes define a manager for persistence sources managed
    /// by the Entity Framework.
    /// </summary>
    public interface IEntityContext
    {
        /// <summary>
        /// Retrieve the object set for the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The <see cref="IPersistedObject"/> to get the set of.
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/> in the current object graph.
        /// </returns>
        DbSet<T> GetSet<T>() where T : class, IPersistedObject;

        /// <summary>
        /// Execute <see cref="M:System.Data.Entity.DbContext.SaveChanges"/> upon the object graph as it stands.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database..
        /// </returns>
        int SaveChanges();
    }
}