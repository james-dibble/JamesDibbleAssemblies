// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerExtensions.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JamesDibble.ApplicationFramework.Web.Rss
{
    using System.ServiceModel.Syndication;
    using System.Web.Mvc;

    /// <summary>
    /// Extenions for the <see cref="System.Web.Mvc.Controller"/> class to add RSS feed Action Results.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Build an <see cref="T:System.Web.Mvc.ActionResult"/> for publishing Rss Feeds.
        /// </summary>
        /// <param name="controller">The <see cref="T:System.Web.Mvc.Controller"/> being extended.</param>
        /// <param name="feed">The <see cref="T:System.ServiceModel.Syndication.SyndicationFeed"/> to publish.</param>
        /// <returns>An instance of the <see cref="RssResult"/> <see cref="T:System.Web.Mvc.ActionResult"/>.</returns>
        public static ActionResult RssResult(this Controller controller, SyndicationFeed feed)
        {
            return new RssResult(feed);
        }
    }
}