// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtomResult.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ApplicationFramework.Web.Rss
{
    using System.Web.Mvc;
    using System.ServiceModel.Syndication;
    using System.Xml;

    /// <summary>
    /// An <see cref="T:System.Web.Mvc.ActionResult"/> for building Atom Feeds.
    /// </summary>
    public class AtomResult : ActionResult
    {
        private readonly SyndicationFeed _feed;

        /// <summary>
        /// Initialises a new instace of the <see cref="AtomResult"/> class.
        /// </summary>
        /// <param name="feed">The feed context to output.</param>
        public AtomResult(SyndicationFeed feed)
        {
            this._feed = feed;
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits 
        /// from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">
        /// The context in which the result is executed. The context information includes the 
        /// controller, HTTP content, request context, and route data.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/atom+xml";

            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                writer.Settings.Indent = true;

                new Atom10FeedFormatter(this._feed).WriteTo(writer);
            }

            context.HttpContext.Response.End();
        }
    }
}