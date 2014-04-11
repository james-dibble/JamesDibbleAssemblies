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
    }
}