// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeMappingDictionary.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes expose methods to map an <see cref="IPersistedObject"/> 
    /// to a concrete type of <see cref="IPersistedObject"/>.
    /// </summary>
    public interface ITypeMappingDictionary : IDictionary<Type, Type>
    {
        /// <summary>
        /// Configure a type mapping.
        /// </summary>
        /// <typeparam name="TInterface">
        /// The type of interface that the <typeparamref name="TConcrete" /> is implemented from.
        /// </typeparam>
        /// <typeparam name="TConcrete">
        /// The type <typeparamref name="TInterface"/> maps too.
        /// </typeparam>
        void Add<TInterface, TConcrete>() 
            where TInterface : class, IPersistedObject
            where TConcrete : class, TInterface;

        /// <summary>
        /// Clear the current dictionary and pull all the mappings from the executing applications
        /// configuration file.
        /// </summary>
        /// <returns>The <see cref="ITypeMappingDictionary"/> as configured</returns>
        ITypeMappingDictionary PopulateFromConfiguration();
    }
}