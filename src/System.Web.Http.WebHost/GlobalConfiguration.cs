﻿using System.Web.Http.Dispatcher;
using System.Web.Http.WebHost;
using System.Web.Http.WebHost.Routing;
using System.Web.Routing;

namespace System.Web.Http
{
    /// <summary>
    /// Provides a global <see cref="T:System.Web.Http.HttpConfiguration"/> for ASP applications.
    /// </summary>
    public static class GlobalConfiguration
    {
        private static Lazy<HttpConfiguration> _configuration = new Lazy<HttpConfiguration>(
            () =>
            {
                HttpConfiguration config = new HttpConfiguration(new HostedHttpRouteCollection(RouteTable.Routes));
                config.ServiceResolver.SetService(typeof(IBuildManager), new WebHostBuildManager());
                return config;
            });

        private static Lazy<HttpControllerDispatcher> _dispatcher = new Lazy<HttpControllerDispatcher>(
            () =>
            {
                return new HttpControllerDispatcher(_configuration.Value);
            });

        /// <summary>
        /// Gets the global <see cref="T:System.Web.Http.HttpConfiguration"/>.
        /// </summary>
        public static HttpConfiguration Configuration
        {
            get { return _configuration.Value; }
        }

        /// <summary>
        /// Gets the global <see cref="T:System.Web.Http.Dispatcher.HttpControllerDispatcher"/>.
        /// </summary>
        public static HttpControllerDispatcher Dispatcher
        {
            get { return _dispatcher.Value; }
        }
    }
}
