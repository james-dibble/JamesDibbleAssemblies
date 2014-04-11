// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyDirectoryConfigurationElement.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Configuration
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Hosting;

    /// <summary>
    /// The assembly directory configuration element.
    /// </summary>
    public class AssemblyDirectoryConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// The map using type.
        /// </summary>
        private enum MapUsingType
        {
            /// <summary>
            /// The raw path.
            /// </summary>
            RawPath = 1,

            /// <summary>
            /// The hosting environment.
            /// </summary>
            HostingEnvironment = 2,

            /// <summary>
            /// The server.
            /// </summary>
            Server = 3,

            /// <summary>
            /// The undefined.
            /// </summary>
            Undefined = 0
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The value in the "mapUsing" element is unrecognized.
        /// </exception>
        public string Path
        {
            get
            {
                string path = null;
                switch (this.MapUsing)
                {
                    case MapUsingType.RawPath:
                        return this.RawPath;

                    case MapUsingType.HostingEnvironment:
                        path = HostingEnvironment.MapPath(this.RawPath);
                        return path;

                    case MapUsingType.Server:
                        path = HttpContext.Current.Server.MapPath(this.RawPath);
                        return path;

                    default:
                        throw new InvalidOperationException(@"The value for mapping type element is unrecognized.");
                }
            }
        }

        /// <summary>
        /// Gets the raw path.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string RawPath
        {
            get
            {
                return (string)this["path"];
            }
        }

        /// <summary>
        /// Gets the map using.
        /// </summary>
        [ConfigurationProperty("mapUsing", IsRequired = true)]
        private MapUsingType MapUsing
        {
            get
            {
                return (MapUsingType)this["mapUsing"];
            }
        }
    }
}