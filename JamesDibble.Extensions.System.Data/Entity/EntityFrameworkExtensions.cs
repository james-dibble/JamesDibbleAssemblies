// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityFrameworkExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace System.Data.Entity
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    
    /// <summary>
    /// The entity framework extensions.
    /// </summary>
    public static class EntityFrameworkExtensions
    {
        /// <summary>
        /// Retrieve related objects for the given <typeparamref name="T"/>.
        /// </summary>
        /// <param name="query">
        /// The set of objects to include objects onto.
        /// </param>
        /// <param name="includeProperties">
        /// The related objects to include in the set.
        /// </param>
        /// <typeparam name="T">
        /// The type of the <see cref="IQueryable{T}"/>.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "I is.")]
        public static IQueryable<T> Includes<T>(
           this IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            Argument.CannotBeNull(includeProperties, "includeProperties");

            foreach (var property in includeProperties)
            {
                query.Include(property).Load();
            }

            return query;
        } 
    }
}