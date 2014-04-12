// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMappingConfigurationSection.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The type mapping configuration section.
    /// </summary>
    public class TypeMappingConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the type mappings.
        /// </summary>
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TypeMappingConfigurationCollection TypeMappings
        {
            get
            {
                return (TypeMappingConfigurationCollection)this[string.Empty];
            }
        }
    }
}