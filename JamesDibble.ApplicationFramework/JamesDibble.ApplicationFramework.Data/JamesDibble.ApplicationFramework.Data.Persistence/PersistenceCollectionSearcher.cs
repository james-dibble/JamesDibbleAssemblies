// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceCollectionSearcher.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The persistence collection searcher.
    /// </summary>
    /// <typeparam name="T">
    /// The collection of <see cref="IPersistedObject"/> to search for.
    /// </typeparam>
    public class PersistenceCollectionSearcher<T> : PersistenceSearcher<T>, IPersistenceCollectionSearcher<T>
        where T : class, IPersistedObject
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceCollectionSearcher{T}"/> class.
        /// </summary>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        public PersistenceCollectionSearcher(params Expression<Func<T, object>>[] includeProperties)
            : base(null, includeProperties)
        {
            this.Limit = Constants.NoLimitQuery;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceCollectionSearcher{T}"/> class.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        public PersistenceCollectionSearcher(
            Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
            : base(predicate, includeProperties)
        {
            this.Limit = Constants.NoLimitQuery;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceCollectionSearcher{T}"/> class.
        /// </summary>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "I is.")]
        public PersistenceCollectionSearcher(IPersistenceSearcher<T> searcher)
            : base(searcher.Predicate, searcher.Includes.ToArray())
        {
            Argument.CannotBeNull(searcher, "searcher");

            this.Limit = Constants.NoLimitQuery;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceCollectionSearcher{T}"/> class.
        /// </summary>
        /// <param name="limit">
        /// The maximum number of records to return.
        /// </param>
        /// <param name="searcher">
        /// The searcher.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "I is.")]
        public PersistenceCollectionSearcher(int limit, IPersistenceSearcher<T> searcher)
            : base(searcher.Predicate, searcher.Includes.ToArray())
        {
            Argument.CannotBeNull(searcher, "searcher");

            this.Limit = limit;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PersistenceCollectionSearcher{T}"/> class.
        /// </summary>
        /// <param name="limit">
        /// The maximum number of records to return.
        /// </param>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <param name="includeProperties">
        /// The include properties.
        /// </param>
        public PersistenceCollectionSearcher(int limit, Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
            : base(predicate, includeProperties)
        {
            this.Limit = limit;
        }

        /// <summary>
        /// Gets the maximum number of records to return.
        /// </summary>
        public int Limit { get; private set; }
    }
}