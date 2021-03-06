﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Routing;

namespace System.Web.Http.WebHost.Routing
{
    /// <summary>
    /// Mimics the System.Web.Routing.Route class to work better for Web API scenarios. The only
    /// difference between the base class and this class is that this one will match only when
    /// a special "httproute" key is specified when generating URLs. There is no special behavior
    /// for incoming URLs.
    /// </summary>
    public class HttpWebRoute : Route
    {
        /// <summary>
        /// Key used to signify that a route URL generation request should include HTTP routes (e.g. Web API).
        /// If this key is not specified then no HTTP routes will match.
        /// </summary>
        private const string HttpRouteKey = "httproute";

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Matches the base class's parameter names.")]
        public HttpWebRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Matches the base class's parameter names.")]
        public HttpWebRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Matches the base class's parameter names.")]
        public HttpWebRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Justification = "Matches the base class's parameter names.")]
        public HttpWebRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            // Only perform URL generation if the "httproute" key was specified. This allows these
            // routes to be ignored when a regular MVC app tries to generate URLs. Without this special
            // key an HTTP route used for Web API would normally take over almost all the routes in a
            // typical app.
            if (!values.ContainsKey(HttpRouteKey))
            {
                return null;
            }
            // Remove the value from the collection so that it doesn't affect the generated URL
            RouteValueDictionary newValues = GetRouteDictionaryWithoutHttpRouteKey(values);

            return base.GetVirtualPath(requestContext, newValues);
        }

        private static RouteValueDictionary GetRouteDictionaryWithoutHttpRouteKey(IDictionary<string, object> routeValues)
        {
            var newRouteValues = new RouteValueDictionary();
            foreach (var routeValue in routeValues)
            {
                if (!String.Equals(routeValue.Key, HttpRouteKey, StringComparison.OrdinalIgnoreCase))
                {
                    newRouteValues.Add(routeValue.Key, routeValue.Value);
                }
            }
            return newRouteValues;
        }
    }
}
