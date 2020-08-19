using NF.Bussiness.Interface;
using NF.Framework;
using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NF.EF.Model;

namespace NF.Web.Core
{
    /// <summary>
    /// http://www.cnblogs.com/Showshare/p/exception-handle-with-mvcfilter.html
    /// LogExceptionAttribute设置了自己的AttributeUsage特性，
    /// AttributeTargets.Class指定该过滤器只能用于类一级，即Controller；
    /// AllowMultiple = false设置不允许多次执行，即仅在Controller级执行一次。
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class LogExceptionFilter : HandleErrorAttribute
    {
        private static Logger logger = Logger.CreateLogger(typeof(LogExceptionFilter));
        private static IComService service = DIFactory.GetContainer().Resolve<IComService>();
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)//异常有没有被处理过
            {
                string ip = GetIP();
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                string msgTemplate = "在执行 controller[{0}] 的 action[{1}] 时产生异常";
                logger.Error(string.Format(msgTemplate, controllerName, actionName), filterContext.Exception);
                SystemLog(filterContext, ip, controllerName, actionName, msgTemplate);
                if (filterContext.HttpContext.Request.IsAjaxRequest())//检查请求头
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new AjaxResult()
                        {
                            Code = DoResult.Failed,
                            Result = filterContext.Exception.Message
                        }//这个就是返回的结果
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
                filterContext.ExceptionHandled = true;
            }
        }

        private static void SystemLog(ExceptionContext filterContext, string ip, string controllerName, string actionName, string msgTemplate)
        {
            CurrentUser user = (CurrentUser)filterContext.HttpContext.Request.RequestContext.HttpContext.Session["CurrentUser"];
            TMB_LOG log = new TMB_LOG();
            log.C_IP = ip;
            log.C_URL = "/" + controllerName + "/" + actionName;
            log.C_OPER_CONTEXT = msgTemplate;
            log.N_STATUS = 1;
            log.C_REMARK = filterContext.Exception.Message;
            log.D_MOD_DT = DateTime.Now;
            if (user != null)
                log.C_EMP_ID = user.Id;
            else
                log.C_EMP_ID = "-1";
            service.SystemLog(log);
        }

        /// <summary>
        /// 获取客户IP
        /// </summary>
        /// <returns></returns>
        private static string GetIP()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}
