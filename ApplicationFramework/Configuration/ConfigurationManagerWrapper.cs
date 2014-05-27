// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationManagerWrapper.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Hosting;

    /// <summary>
    /// A wrapper for the <see cref="ConfigurationManager"/> class.
    /// </summary>
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        private readonly ApplicationConfigurationSection _configuration;

        /// <summary>
        /// Initialises a new instance of the <see cref="ConfigurationManagerWrapper"/> class.
        /// </summary>
        public ConfigurationManagerWrapper()
        {
            this._configuration = this.GetSection<ApplicationConfigurationSection>("applicationConfiguration");
        }

        /// <summary>
        /// Gets the app settings collection.
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        /// <summary>
        /// Gets a configured value for the title of a window.
        /// </summary>
        public string BaseTitle
        {
            get
            {
                return this._configuration.BaseTitle.Title;
            }
        }

        /// <summary>
        /// Gets a value indicating whether to use minified resources.
        /// </summary>
        public bool UseMinified
        {
            get
            {
                return this._configuration.ResourceLocations.UseMinified;
            }
        }

        /// <summary>
        /// Get a named connection.
        /// </summary>
        /// <param name="name">
        /// The name of the connection.
        /// </param>
        /// <returns>
        /// A named connection string.
        /// </returns>
        public string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

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
        public T GetSection<T>(string sectionName) where T : ConfigurationSection
        {
            var section = ConfigurationManager.GetSection(sectionName) as T;

            return section;
        }

        /// <summary>
        /// The resource path.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="relativePath">
        /// The static resource path to retrieve.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ResourcePath(string type, string relativePath)
        {
            //// Jesus this is a mess..

            var configurationSection = this._configuration.ResourceLocations;

            var resourceType = configurationSection.Resource(type);

            var filePath = resourceType.UseBasePath ?
                Path.Combine(configurationSection.BasePath, configurationSection.Resource(type).Path, relativePath)
                :
                Path.Combine(resourceType.Path, relativePath);

            // We don't want the minified source
            if (this._configuration.ResourceLocations.UseMinified && (relativePath.EndsWith(".css") || relativePath.EndsWith(".js")))
            {
                var minifiedFileNameArray = filePath.Split('.').ToList();

                minifiedFileNameArray.Reverse();

                minifiedFileNameArray.Insert(1, "min");

                minifiedFileNameArray.Reverse();

                filePath = string.Join(".", minifiedFileNameArray);
            }

            // This is a local resource and it should be cached, add it to the cache and return its address.
            // Cheers to Mads for this (http://madskristensen.net/post/cache-busting-in-aspnet)
            if (resourceType.Fingerprint && HttpRuntime.Cache[filePath] == null)
            {
                var absolute = HostingEnvironment.MapPath("~" + filePath);
                var date = File.GetLastWriteTime(absolute);
                var index = relativePath.LastIndexOf('/');
                var fingerprint = relativePath.Insert(index, "/v-" + date.Ticks);
                HttpRuntime.Cache.Insert(relativePath, fingerprint, new CacheDependency(absolute));
            }

            if (resourceType.Fingerprint)
            {
                return HttpRuntime.Cache[filePath] as string;
            }

            return filePath;
        }
    }
}