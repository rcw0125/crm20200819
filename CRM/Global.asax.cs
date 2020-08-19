
using CRM.App_Start;
using NF.Framework.DTO;
using NF.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //扩展IOC创建实体对象
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());
            MAPPING mapping = new MAPPING();
        }
    }
}
