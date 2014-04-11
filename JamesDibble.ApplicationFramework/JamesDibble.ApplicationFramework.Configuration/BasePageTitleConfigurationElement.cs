// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePageTitleConfigurationElement.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The base page title configuration element.
    /// </summary>
    public class BasePageTitleConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get
            {
                return (string)this["title"];
            }
        }
    }
}