// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceSearcher.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The persistence searcher.
    /// </summary>
    /// <typeparam name="T">
    /// The <see cref="IPersistedObject"/> to search for.
    /// </typeparam>
    public class PersistenceSearcher<T> : IPersistenceSearcher<T> where T : class, IPersistedObject
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceSearcher{T}"/> class.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        public PersistenceSearcher(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            this.Predicate = predicate;
            this.Includes = includeProperties;
        }

        /// <summary>
        /// Gets the search criteria.
        /// </summary>
        public Func<T, bool> Predicate { get; private set; }

        /// <summary>
        /// Gets the objects that should also be loaded as part of the persistence query.
        /// </summary>
        public IEnumerable<Expression<Func<T, object>>> Includes { get; private set; }
    }
}