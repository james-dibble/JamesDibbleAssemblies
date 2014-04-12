// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceLocationConfigurationElementCollection.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The resource location configuration element collection.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", 
        Justification = "No thank you.  I don't need any more functionality from my collection.")]
    [ConfigurationCollection(typeof(ResourceConfigurationElement))]
    public class ResourceLocationConfigurationElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets the raw path.
        /// </summary>
        [ConfigurationProperty("basePath")]
        public string BasePath
        {
            get
            {
                return (string)this["basePath"];
            }
        }

        /// <summary>
        /// Gets a value indicating whether to use minified sources if available for a resource.
        /// </summary>
        [ConfigurationProperty("useMinified")]
        public bool UseMinified
        {
            get
            {
                return (bool)this["useMinified"];
            }
        }

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
                return "Resource";
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="ResourceConfigurationElement"/>.
        /// </returns>
        public ResourceConfigurationElement Resource(string index)
        {
            return (ResourceConfigurationElement)BaseGet(index);
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
            return new ResourceConfigurationElement();
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
            return ((ResourceConfigurationElement)element).ResourceType;
        }
    }
}