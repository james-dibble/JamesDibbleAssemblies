// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationConfigurationSection.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The application configuration section.
    /// </summary>
    public class ApplicationConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the environment.
        /// </summary>
        [ConfigurationProperty("environment", IsRequired = true)]
        public string Environment
        {
            get
            {
                return (string)this["environment"];
            }
        }

        /// <summary>
        /// Gets the assembly directory.
        /// </summary>
        [ConfigurationProperty("assemblies", IsRequired = true)]
        public AssemblyDirectoryConfigurationElement AssemblyDirectory
        {
            get
            {
                return (AssemblyDirectoryConfigurationElement)this["assemblies"];
            }
        }

        /// <summary>
        /// Gets the base title for this application.
        /// </summary>
        [ConfigurationProperty("baseTitle", IsRequired = true)]
        public BasePageTitleConfigurationElement BaseTitle
        {
            get
            {
                return (BasePageTitleConfigurationElement)this["baseTitle"];
            }
        }

        /// <summary>
        /// Gets the resource locations.
        /// </summary>
        [ConfigurationProperty("ResourceLocations")]
        public ResourceLocationConfigurationElementCollection ResourceLocations
        {
            get
            {
                return (ResourceLocationConfigurationElementCollection)this["ResourceLocations"];
            }
        }
    }
}