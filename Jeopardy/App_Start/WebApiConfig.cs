﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Jeopardy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

             config.Routes.MapHttpRoute(
                name: "AspNet",
                routeTemplate: "api/{controller}/aspnet/{id}",
                defaults: new { controller="Categories", id =4});

             config.Routes.MapHttpRoute(
                 name: "AdoNet",
                 routeTemplate: "api/{controller}/adonet/{id}",
                 defaults: new { controller = "Categories", id = 2 });


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
        }
    }
}
