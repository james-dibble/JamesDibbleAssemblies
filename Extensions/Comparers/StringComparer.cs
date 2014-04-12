// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringComparer.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.Extensions.System.Comparers
{
    using global::System.Collections.Generic;

    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> for strings using the invariant culture.
    /// </summary>
    public class StringComparer : IEqualityComparer<string>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
        public bool Equals(string x, string y)
        {
            return x.ToUpperInvariant() == y.ToUpperInvariant();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}