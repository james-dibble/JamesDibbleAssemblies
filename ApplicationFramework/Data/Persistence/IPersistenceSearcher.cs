// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceSearcher.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Implementing classes define an object to search a persistence source.
    /// </summary>
    /// <typeparam name="T">
    /// The type to search for.
    /// </typeparam>
    public interface IPersistenceSearcher<T> where T : class, IPersistedObject
    {
        /// <summary>
        /// Gets the search criteria.
        /// </summary>
        Func<T, bool> Predicate { get; }

        /// <summary>
        /// Gets the objects that should also be loaded as part of the persistence query.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "Refactoring of this method is not possible.")]
        IEnumerable<Expression<Func<T, object>>> Includes { get; } 
    }
}