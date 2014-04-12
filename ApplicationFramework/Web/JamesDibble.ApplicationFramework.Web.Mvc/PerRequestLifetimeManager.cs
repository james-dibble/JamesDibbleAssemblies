// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerRequestLifetimeManager.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace JamesDibble.ApplicationFramework.Web.Mvc
{
    using System.Web;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The per request lifetime manager.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the object to add as a singleton for the request.
    /// </typeparam>
    public class PerRequestLifetimeManager<T> : LifetimeManager
    {
        private readonly object _key;

        /// <summary>
        /// Initialises a new instance of the <see cref="PerRequestLifetimeManager{T}"/> class.
        /// </summary>
        public PerRequestLifetimeManager()
        {
            this._key = typeof(T).FullName;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object GetValue()
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(this._key))
            {
                return HttpContext.Current.Items[this._key];
            }
            
            return null;
        }

        /// <summary>
        /// The remove value.
        /// </summary>
        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items.Remove(this._key);
            }
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[this._key] = newValue;
            }
        }
    }
}