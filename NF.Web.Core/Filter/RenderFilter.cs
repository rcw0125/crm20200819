
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Microsoft.Practices.Unity;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using NF.Bussiness.Interface;

namespace NF.Web.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RenderFilter : ActionFilterAttribute
    {
        IMenuButtonService service = DIFactory.GetContainer().Resolve<IMenuButtonService>();

        /// <summary>
        /// render之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            string url = string.Empty;
            foreach (var v in context.Request.RequestContext.RouteData.Values)
            {
                url += "/" + v.Value;
            }
            if (url.IndexOf("Home") < 0)
            {
                List<TS_BUTTON> buttons = service.GetButtons(url).ToList();
                List<TS_BUTTON> useButtons = new List<TS_BUTTON>();
                if (buttons == null)
                {
                    buttons = new List<TS_BUTTON>();
                }
                CurrentUser currentUser = (CurrentUser)filterContext.RequestContext.HttpContext.Session["CurrentUser"];
                List<TS_FUNCTIONDTO> fDtos = currentUser.ButtonFuncs;
                foreach (var m in buttons)
                {
                    if (fDtos.Exists(x => x.ButtonID.Equals(m.C_ID)))
                    {
                        useButtons.Add(m);
                    }
                }
                filterContext.HttpContext.Session["button"] = useButtons;
            }
        }

        /// <summary>
        /// render之后
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            string extension = Path.GetExtension(context.Request.Url.AbsoluteUri);
            //if (string.IsNullOrWhiteSpace(extension) && !context.Request.Url.AbsolutePath.Contains("Verify"))
            //    context.Response.Write(string.Format("<h1 style='color:#00f'>来自OnResultExecuted 的处理，{0}请求结束</h1><hr>", DateTime.Now.ToString()));
            //base.OnResultExecuted(filterContext);
        }
    }
}
