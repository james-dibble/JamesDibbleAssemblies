// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeMappingConfigurationCollection.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Data.Persistence.TypeMapping.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The type mapping configuration collection.
    /// </summary>
    public class TypeMappingConfigurationCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets the type of the <see cref="T:System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Configuration.ConfigurationElementCollectionType"/> of this collection.
        /// </returns>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// The name of the collection; otherwise, an empty string. The default is an empty string.
        /// </returns>
        protected override string ElementName
        {
            get
            {
                return "TypeMapping";
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="TypeMappingConfigurationElement"/>.
        /// </returns>
        public TypeMappingConfigurationElement TypeMapping(string index)
        {
            return (TypeMappingConfigurationElement)BaseGet(index);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="T:System.Configuration.ConfigurationElement"/> exists in the <see cref="T:System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>
        /// true if the element exists in the collection; otherwise, false. The default is false.
        /// </returns>
        /// <param name="elementName">The name of the element to verify. </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "I is.")]
        protected override bool IsElementName(string elementName)
        {
            Argument.CannotBeNull(elementName, "elementName");

            return elementName.Equals(this.ElementName, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new TypeMappingConfigurationElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TypeMappingConfigurationElement)element).InterfaceType;
        }
    }
}