// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMappingConfigurationElement.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The type mapping configuration element.
    /// </summary>
    public class TypeMappingConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the implemented type.
        /// </summary>
        [ConfigurationProperty("concreteType", IsRequired = true)]
        public string ConcreteType
        {
            get
            {
                return (string)this["concreteType"];
            }
        }

        /// <summary>
        /// Gets the base type.
        /// </summary>
        [ConfigurationProperty("interfaceType", IsKey = true, IsRequired = true)]
        public string InterfaceType
        {
            get
            {
                return (string)this["interfaceType"];
            }
        }
    }
}