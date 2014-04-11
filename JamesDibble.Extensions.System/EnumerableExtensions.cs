// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="James Dibble">
//   Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace System
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions methods for <see cref="IEnumerable{T}"/> objects
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Group a <see cref="IEnumerable{T}"/> of <typeparamref name="T"/> by a given
        /// set of keys and return the first result to gain the distinct values in the
        /// <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">
        /// The collection to evaluate distinct elements upon.
        /// </param>
        /// <param name="predicate">
        /// The keys to distinct by.
        /// </param>
        /// <typeparam name="T">
        /// The type of the collection.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key to distinct by.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> predicate)
        {
            var result = collection.GroupBy(predicate).Select(c => c.First());

            return result;
        }
    }
}
