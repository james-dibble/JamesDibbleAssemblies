namespace JamesDibble.ApplicationFramework.Web.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// An <see cref="MvcRouteHandler"/> for parsing key value pairs from URLs.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class DictionaryRouteHandler<TKey, TValue> : MvcRouteHandler
    {
        private readonly string _key;

        /// <summary>
        /// Initialises a new instance of the <see cref="DictionaryRouteHandler{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="key">The route value identifier to extract the key value pairs from.</param>
        public DictionaryRouteHandler(string key)
        {
            this._key = key;
        }

        /// <summary>
        /// Returns the HTTP handler by using the specified HTTP context.
        /// </summary>
        /// <returns>
        /// The HTTP handler.
        /// </returns>
        /// <param name="requestContext">The request context.</param>
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var dictionaryParameter = requestContext.RouteData.Values[this._key] as string;

            requestContext.RouteData.Values[this._key] = string.IsNullOrEmpty(dictionaryParameter) ? null : ParseUrlDictionary(dictionaryParameter);

            return base.GetHttpHandler(requestContext);
        }

        private static IDictionary<TKey, TValue> ParseUrlDictionary(string dictionaryParameter)
        {
            var dictionaryElements = Regex.Split(dictionaryParameter, @"([^/]+/[^/]+)+").Where(dp => Regex.IsMatch(dp, @"^[^/]+/[^/]+$"));

            var urlDictionary = dictionaryElements.Select(ParseElement).ToDictionary(kvpk => kvpk.Key, kvpv => kvpv.Value);

            return urlDictionary;
        }

        private static KeyValuePair<TKey, TValue> ParseElement(string element)
        {
            var elementParts = element.Split('/');

            var key = (TKey)Convert.ChangeType(elementParts[0], typeof(TKey));
            var value = (TValue)Convert.ChangeType(elementParts[1], typeof(TValue));

            return new KeyValuePair<TKey, TValue>(key, value);
        }
    }
}