// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityFrameworkPersistenceManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFrameworkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// An <see cref="IPersistenceManager"/> for use with Entity Framework databases.
    /// </summary>
    public class EntityFrameworkPersistenceManager : IPersistenceManager
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityFrameworkPersistenceManager"/> class.
        /// </summary>
        /// <param name="context">
        /// Inject an object set into the persistence manager.
        /// </param>
        public EntityFrameworkPersistenceManager(DbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Find an <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        public T Find<T>(IPersistenceSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            Argument.CannotBeNull(searchCriteria, "searchCriteria");

            var discoveredObject = this._context.Set<T>()
                .Includes(searchCriteria.Includes.ToArray())
                .SingleOrDefault(searchCriteria.Predicate);

            return discoveredObject;
        }

        /// <summary>
        /// Find a collection of <see cref="IPersistedObject"/>
        /// </summary>
        /// <param name="searchCriteria">
        /// An object defining how to find the collection of <typeparamref name="T"/>.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable{T}"/> of <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        public IEnumerable<T> Find<T>(IPersistenceCollectionSearcher<T> searchCriteria) where T : class, IPersistedObject
        {
            Argument.CannotBeNull(searchCriteria, "searchCriteria");

            IQueryable<T> collection = this._context.Set<T>().Includes(searchCriteria.Includes.ToArray());

            if (searchCriteria.Predicate != null)
            {
                collection = collection.Where(searchCriteria.Predicate).AsQueryable();
            }

            if (searchCriteria.Limit != Constants.NoLimitQuery)
            {
                collection = collection.Take(searchCriteria.Limit);
            }

            return collection;
        }

        /// <summary>
        /// Update an object that already exists in the persistence source.
        /// </summary>
        /// <param name="updatedObject">
        /// The object that has changed.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Change<T>(T updatedObject) where T : class, IPersistedObject
        {
            this._context.Set<T>().Attach(updatedObject);
            this._context.Entry(updatedObject).State = EntityState.Modified;
        }

        /// <summary>
        /// Insert a new object into the persistence source.
        /// </summary>
        /// <param name="newObject">
        /// The new object.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Add<T>(T newObject) where T : class, IPersistedObject
        {
            this._context.Set<T>().Add(newObject);
        }

        /// <summary>
        /// Delete an object from the persistence source.
        /// </summary>
        /// <param name="objectToRemove">
        /// The object to remove.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        public void Remove<T>(T objectToRemove) where T : class, IPersistedObject
        {
            this._context.Set<T>().Remove(objectToRemove);
        }

        /// <summary>
        /// Save changes that have been added to the <see cref="IPersistenceManager"/>.
        /// </summary>
        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}