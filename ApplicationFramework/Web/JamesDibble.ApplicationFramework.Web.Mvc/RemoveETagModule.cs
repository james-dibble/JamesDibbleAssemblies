namespace JamesDibble.ApplicationFramework.Web.Mvc
{
    using System.Web;

    /// <summary>
    /// An <see cref="IHttpModule"/> to remove useless ETag HTTP header.
    /// </summary>
    public class RemoveETagModule : IHttpModule
    {
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += (sender, args) => HttpContext.Current.Response.Headers.Remove("ETag");
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }
    }
}