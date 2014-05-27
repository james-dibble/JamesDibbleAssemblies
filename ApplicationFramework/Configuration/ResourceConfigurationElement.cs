// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceConfigurationElement.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The resource configuration element.
    /// </summary>
    public class ResourceConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the base path of the resource type.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get
            {
                return (string)this["path"];
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [ConfigurationProperty("resourceType", IsKey = true, IsRequired = true)]
        public string ResourceType
        {
            get
            {
                return (string)this["resourceType"];
            }
        }

        /// <summary>
        /// Gets a value indicating whether this resource type is in the base path.
        /// </summary>
        [ConfigurationProperty("useBasePath", IsKey = false, IsRequired = false, DefaultValue = true)]
        public bool UseBasePath
        {
            get
            {
                return (bool) this["useBasePath"];
            }
        }

        /// <summary>
        /// Gets a value indicating whether this resource type can be fingerprinted.
        /// </summary>
        [ConfigurationProperty("fingerprint", IsKey = false, IsRequired = false, DefaultValue = false)]
        public bool Fingerprint
        {
            get
            {
                return (bool) this["fingerprint"];
            }
        }
    }
}