// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceCollectionSearcher.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    /// <summary>
    /// Implementing classes define an object to search a persistence source for a collection.
    /// </summary>
    /// <typeparam name="T">
    /// The type to search for.
    /// </typeparam>
    public interface IPersistenceCollectionSearcher<T> : IPersistenceSearcher<T> where T : class, IPersistedObject
    {
        /// <summary>
        /// Gets the maximum number of records to return.
        /// </summary>
        int Limit { get; }
    }
}