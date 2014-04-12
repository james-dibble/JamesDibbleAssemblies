// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUniqueObject.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence
{
    /// <summary>
    /// Implementing classes represent an object that can be identified by a single primary key.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the unique identifier.
    /// </typeparam>
    public interface IUniqueObject<T> : IPersistedObject
    {
        /// <summary>
        /// Gets unique identifier of this <see cref="object"/>.
        /// </summary>
        T Id { get; }

        /// <summary>
        /// Set the unique identifier of this <see cref="IUniqueObject{T}"/>.
        /// </summary>
        /// <param name="newId">
        /// The new identifier.
        /// </param>
        void SetNewId(T newId);
    }
}