// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// Wrapper interface for <see cref="ConfigurationManager"/>
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the app settings collection.
        /// </summary>
        NameValueCollection AppSettings { get; }

        /// <summary>
        /// Gets a configured value for the title of a window.
        /// </summary>
        string BaseTitle { get; }
        
        /// <summary>
        /// Gets a value indicating whether to use minified resources.
        /// </summary>
        bool UseMinified { get; }

        /// <summary>
        /// Get a named connection.
        /// </summary>
        /// <param name="name">
        /// The name of the connection.
        /// </param>
        /// <returns>
        /// A named connection string.
        /// </returns>
        string ConnectionString(string name);

        /// <summary>
        /// Get a named configuration section of a given type.
        /// </summary>
        /// <param name="sectionName">
        /// The section name.
        /// </param>
        /// <typeparam name="T">
        /// The <see cref="ConfigurationSection"/> type.
        /// </typeparam>
        /// <returns>
        /// The configuration section of type <typeparamref name="T"/>.
        /// </returns>
        T GetSection<T>(string sectionName) where T : ConfigurationSection;

        /// <summary>
        /// The resource path.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="resourcePath">
        /// The path of the actual resource.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ResourcePath(string type, string resourcePath);
    }
}