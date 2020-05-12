using System;
using System.Linq;
using System.Reflection;

namespace Topdev.Bittrex
{
    /// <summary>
    /// Pagenable resources should have property labeled with PageToken to identifies value which represents nextPageToken
    /// </summary>
    public class PageTokenAttribute : Attribute
    {
        public static PropertyInfo GetPageTokenProperty<T>()
        {
            var nextPageTokenProperty = typeof(T).GetProperties()
                .FirstOrDefault(x => x.GetCustomAttributes(true).Any(c => c is PageTokenAttribute));

            if (nextPageTokenProperty == null)
                throw new InvalidOperationException("Paginated resource must have page token attribute set.");

            return nextPageTokenProperty;
        }
    }
}