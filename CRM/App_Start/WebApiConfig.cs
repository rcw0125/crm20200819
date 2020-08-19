using CRM.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CRM
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API 路由
            config.MapHttpAttributeRoutes();

            RouteTable.Routes.MapHttpRoute(

     name: "DefaultApi2",

     routeTemplate: "api/{controller}/{action}/{id}",

     defaults: new { id = RouteParameter.Optional }

     ).RouteHandler = new SessionControllerRouteHandler();


            //    config.Routes.MapHttpRoute(
            //    name: "DefaultApi2",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);//新增api路由到指定action
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}