// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes contain methods for interacting with persisted data.
    /// </summary>
    public interface IPersistenceManager
    {
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
        T Find<T>(IPersistenceSearcher<T> searchCriteria) where T : class, IPersistedObject;

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
        /// An <see cref="IEnumerable{T}"/> of <see cref="IPersistedObject"/> retrieved from the persistence source.
        /// </returns>
        IEnumerable<T> Find<T>(IPersistenceCollectionSearcher<T> searchCriteria) where T : class, IPersistedObject;

        /// <summary>
        /// Update an object that already exists in the persistence source.
        /// </summary>
        /// <param name="updatedObject">
        /// The object that has changed.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        void Change<T>(T updatedObject) where T : class, IPersistedObject;

        /// <summary>
        /// Insert a new object into the persistence source.
        /// </summary>
        /// <param name="newObject">
        /// The new object.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        void Add<T>(T newObject) where T : class, IPersistedObject;

        /// <summary>
        /// Delete an object from the persistence source.
        /// </summary>
        /// <param name="objectToRemove">
        /// The object to remove.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPersistedObject"/>.
        /// </typeparam>
        void Remove<T>(T objectToRemove) where T : class, IPersistedObject;

        /// <summary>
        /// Save changes that have been added to the <see cref="IPersistenceManager"/>.
        /// </summary>
        void Commit();
    }
}