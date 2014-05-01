// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RssResult.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ApplicationFramework.Web.Rss
{
    using System.Web.Mvc;
    using System.ServiceModel.Syndication;
    using System.Xml;

    /// <summary>
    /// An <see cref="T:System.Web.Mvc.ActionResult"/> for building Rss Feeds.
    /// </summary>
    public class RssResult : ActionResult
    {
        private readonly SyndicationFeed _feed;

        /// <summary>
        /// Initialises a new instace of the <see cref="RssResult"/> class.
        /// </summary>
        /// <param name="feed">The feed context to output.</param>
        public RssResult(SyndicationFeed feed)
        {
            this._feed = feed;
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type 
        /// that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information includes 
        /// the controller, HTTP content, request context, and route data.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output, new XmlWriterSettings { Indent = true }))
            {
                new Rss20FeedFormatter(this._feed).WriteTo(writer);
            }

            context.HttpContext.Response.End();
        }
    }
}