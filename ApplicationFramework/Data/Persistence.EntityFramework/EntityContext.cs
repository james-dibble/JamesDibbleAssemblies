// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.EntityFramework
{
    using System;
    using System.Data.Entity;

    using JamesDibble.ApplicationFramework.Configuration;
    using JamesDibble.ApplicationFramework.Data.Persistence;
    using JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping;

    /// <summary>
    /// A manager for Entity Framework persistence sources.
    /// </summary>
    public sealed class EntityContext : DbContext, IEntityContext
    {
        private readonly ITypeMappingDictionary _typeMapping;
        private readonly DateTime _createTime;

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="typeMapping">
        /// Inject interface type mappings into the persistence source.
        /// </param>
        public EntityContext(IConfigurationManager configuration, ITypeMappingDictionary typeMapping)
            : this(ConfigurationManagerGuard(configuration).ConnectionString("default"), typeMapping)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="EntityContext"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string to create this <see cref="EntityContext"/> with.
        /// </param>
        /// <param name="typeMapping">
        /// Inject interface type mappings into the persistence source.
        /// </param>
        public EntityContext(string connectionString, ITypeMappingDictionary typeMapping)
            : base(connectionString)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this._typeMapping = typeMapping;
            this._createTime = DateTime.Now;
        }

        /// <summary>
        /// Retrieve the object set for the type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The <see cref="IPersistedObject"/> to get the set of.
        /// </typeparam>
        /// <returns>
        /// The <see cref="DbSet"/> in the current object graph.
        /// </returns>
        public DbSet<T> GetSet<T>() where T : class, IPersistedObject
        {
            if (!typeof(T).IsInterface)
            {
                return this.Set<T>();
            }

            throw new ArgumentException(
                string.Format("A DbSet for the type {0} could not be created", typeof(T).Name));
        }

        /////// <summary>
        /////// Execute <see cref="M:System.Data.Entity.DbContext.SaveChanges"/> upon the object graph as it stands.
        /////// </summary>
        /////// <returns>
        /////// The number of objects written to the underlying database..
        /////// </returns>
        ////public override int SaveChanges()
        ////{
        ////    this.ChangeTracker.DetectChanges();
        ////    return base.SaveChanges();
        ////}

        private static IConfigurationManager ConfigurationManagerGuard(IConfigurationManager configuration)
        {
            Argument.CannotBeNull(configuration, "configuration");

            return configuration;
        }
    }
}