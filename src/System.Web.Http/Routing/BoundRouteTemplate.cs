﻿namespace System.Web.Http.Routing
{
    /// <summary>
    /// Represents a URI generated from a <see cref="HttpParsedRoute"/>. 
    /// </summary>
    internal class BoundRouteTemplate
    {
        public string BoundTemplate { get; set; }

        public HttpRouteValueDictionary Values { get; set; }
    }
}
