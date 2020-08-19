
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using NF.Bussiness.Interface;
using NF.Framework;
using NF.Web.Core;
using Microsoft.Practices.Unity;

namespace CRM.Auth
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        IApiService service = DIFactory.GetContainer().Resolve<IApiService>();

        ////重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Scheme != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var tokenID = authorization.Scheme;
                if (ValidateTicket(tokenID))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }


        protected override void HandleUnauthorizedRequest(HttpActionContext actioncontext)
        {
            base.HandleUnauthorizedRequest(actioncontext);

            var response = actioncontext.Response = actioncontext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            var content = new
            {
                Code = 0,
                Result = "服务端拒绝访问：你没有权限，或者掉线了"
            };
            response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateTicket(string tokenID)
        {
            var user = service.CheckToken(tokenID);

            if (user != null && !string.IsNullOrWhiteSpace(user.C_ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}