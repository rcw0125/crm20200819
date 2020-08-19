
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

using NF.Bussiness.Interface;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using Microsoft.Practices.Unity;
using NF.Web.Core;

namespace NF.Web.Core
{
    /// <summary>
    /// 检验登陆和权限的filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class AuthorityFilter : AuthorizeAttribute
    {
        IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();

        /// <summary>
        /// 未登录时反回到登录页
        /// </summary>
        private string _loginPath = "";

        public AuthorityFilter()
        {
            this._loginPath = "/Auth/Login";
        }

        public AuthorityFilter(string loginPath)
        {
            this._loginPath = loginPath;
        }

        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;//表示支持控制器、action的AllowAnonymousAttribute
            }
            var sessionUser = HttpContext.Current.Session["CurrentUser"];//使用session         
            //var memberValidation = HttpContext.Current.Request.Cookies.Get("CurrentUser");//使用cookie
            //也可以使用数据库、nosql等介质
            if (sessionUser == null || !(sessionUser is CurrentUser))
            {
                HttpContext.Current.Session["CurrentUrl"] = filterContext.RequestContext.HttpContext.Request.RawUrl;
                //filterContext.Result = new RedirectResult(this._loginPath);           
                //filterContext.HttpContext.Response.Write("<script>window.parent.location.href='/Auth/Login';</script>");
                filterContext.Result = new RedirectResult(this._loginPath);
            }
            else
            {
                CurrentUser currentUser = (CurrentUser)filterContext.RequestContext.HttpContext.Session["CurrentUser"];
                string url = filterContext.RequestContext.HttpContext.Request.RawUrl;
                List<TS_MENU> menus = new List<TS_MENU>();
                List<TS_MENU> useMenus = new List<TS_MENU>();
                var logger = NF.Framework.Logger.CreateLogger(this.GetType());
                object oMenu = Caching.Get("menu" + currentUser.Id);
                if (oMenu != null)
                {
                    logger.Info($"menu{ currentUser.Id} 菜单使用缓存");
                    return;
                }
                else
                {
                    logger.Info($"menu{ currentUser.Id} 菜单刷新");
                    //menus 一级菜单
                    menus = service.GetMenus(1);
                    List<TS_FUNCTIONDTO> fDtos = currentUser.MenuFuncs;
                    foreach (var m in menus)
                    {
                        //useMenus.Add(m);
                        if (fDtos.ExistsOrDefault<TS_FUNCTIONDTO>(x => x.MenuID == m.C_ID))
                        {
                            useMenus.Add(m);
                        }
                    }
                }
                List<TS_MENUDTO> menuDtos = MAPPING.ConvertEntityToDtoList<TS_MENU, TS_MENUDTO>(useMenus);
                List<TS_MENUDTO> newMenus = new List<TS_MENUDTO>();
                List<TS_MENUDTO> pMenus = menuDtos.FindAll(x => x.C_PARENT_ID == null);
                foreach (var parent in pMenus)
                {
                    var parentDto = parent;
                    List<TS_MENUDTO> childrenMenus = menuDtos.FindAll(x => x.C_PARENT_ID == parent.C_ID);
                    if (childrenMenus.Count > 0)
                    {
                        foreach (var children in childrenMenus)
                        {
                            parentDto.Menus.Add(children);
                        }
                    }
                    newMenus.Add(parentDto);
                }

                List<MENUDTO> menu = MAPPING.ConvertMenu(newMenus);

                string strMenu = NF.Framework.SerializationHelper.JsonSerialize(menu);
                string path = "/Common/main.html";
                if (currentUser.Type == "1")
                {
                    path = "/Common/main2.html";
                }
                string newUrl = "{ id: '0',text: '首页',icon: 'icon-cog',url: '',menus: [{ id: '00',text: '首页',icon: 'icon-glass',close: false,url: '" + path + "' }]},";
                string str = strMenu.Insert(1, newUrl);
                Caching.Set("menu" + currentUser.Id, str);
            }

        }

    }
}
