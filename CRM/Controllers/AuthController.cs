using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

using NF.Bussiness.Interface;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using NF.Framework;
using NF.Framework.DTO;
using NF.Web.Core;
using System.Data;
using System.Xml;

namespace CRM.Controllers
{
    [AuthorityFilter]
    public class AuthController : BaseController
    {
        IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="verify">验证码</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public ActionResult Login(string account, string password, string verify)
        {
            // 获取客户端IP地址
            var clientIp = this.HttpContext.Request.ServerVariables["REMOTE_ADDR"];

            LoginResult result = this.HttpContext.UserLogin(account, password, verify);
            if (result.Equals(LoginResult.Success))
            {
                bool flag = false;

                try
                {
                    //using (var client = new CRMSocket.SocketMgtServiceClient())
                    //{
                    //    flag =
                    //        new CRMSocket.SocketMgtServiceClient().HasLogged(account, clientIp);
                    //    //new NF.BLL.Bll_TMO_ORDER().HasOtherUser(account);
                    //}
                }
                catch (Exception ex)
                {

                }

                if (flag == false)
                {
                   // return RedirectToAction("Index", "Home");
                    return RedirectToAction(nameof(Redirector));
                }
                else
                {
                    return RedirectToAction(nameof(Redirector));
                }

            }
            else
            {
                ModelState.AddModelError("error", result.GetRemark());
                return View();
            }
        }


        /// <summary>
        /// 登录提示跳转信息
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Redirector()
        {
            return View();
        }

        /// <summary>
        /// 验证码 FileContentResult
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public FileContentResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }

        /// <summary>
        /// 验证码  直接写入Response
        /// </summary>
        [AllowAnonymous]
        public void Verify()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }

        /// <summary>
        ///注销
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            this.HttpContext.UserLogOut();
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult RetrievePsw()
        {
            return View();
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="account">登录名</param>
        /// <param name="verify">验证码</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RetrievePsw(string account, string verify)
        {
            //检查验证码
            if (string.IsNullOrWhiteSpace(verify) || base.HttpContext.Session["CheckCode"].Equals(null) || !verify.Equals(base.HttpContext.Session["CheckCode"].ToString(), StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("error", LoginResult.WrongVerify.GetRemark());
            }
            else
            {
                TS_USER user = new TS_USER();
                //获取用户
                user = service.GetUser(account);
                //用户不存在
                if (user == null)
                {
                    ModelState.AddModelError("error", "用户不存在");
                }
                //邮箱为空或者邮箱格式错误
                else if (string.IsNullOrWhiteSpace(user.C_EMAIL) || !RegExp.IsEmail(user.C_EMAIL))
                {
                    ModelState.AddModelError("error", "邮箱不存在或邮箱格式错误!");
                }
                //密码重置
                else
                {
                    string str = user.C_ACCOUNT + "|" + Constant.RESET_PWD_TOKEN;
                    string content = "http://" + Request.Url.Authority + Request.Url.Segments[0] + Request.Url.Segments[1] + "ResetPsw?str=" + str;
                    MailHelper.SendMail(user.C_EMAIL, "确认重置密码!", null, content, "bjzs578@163.com", "woaiwobaba578");
                    return Content("<script>alert('请登陆邮箱确认重置密码！');window.location.href='../Auth/Login';</script>");
                }
            }
            return View();
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            TS_USERDTO userDto = new TS_USERDTO();
            return View(userDto);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userDto">用户实体DTO</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(TS_USERDTO userDto)
        {
            #region 

            #endregion
            //DTO转换EF实体
            TS_USER user = AutoMapper.Mapper.Map<TS_USER>(userDto);
            //验证实体字段
            if (!ModelState.IsValid)
                return View();
            //验证登录名是否重复
            if (service.GetUser(user.C_ACCOUNT) == null)
            {
                user.C_ID = Guid.NewGuid().ToString();
                user.N_STATUS = 2;
                user.N_TYPE = 1;
                user.D_LASTLOGINTIME = DateTime.Now;
                user.D_MOD_DT = DateTime.Now;
                user.C_PASSWORD = Encrypt.MD5(user.C_PASSWORD);
                service.UserRegister(user);
                return Content("<script>alert('注册成功！');window.location.href='../Auth/Login';</script>");
            }
            //登录名重复
            else
                ModelState.AddModelError("C_ACCOUNT", "登录名重复");
            return View(userDto);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="str">重置密码字符串(帐户名|Token）</param>
        [AllowAnonymous]
        public ActionResult ResetPsw(string str)
        {
            string[] arr = str.Split('|');
            string account = arr[0];
            string token = arr[1];
            if (token.Equals(Constant.RESET_PWD_TOKEN))
            {
                TS_USER user = service.GetUser(account);
                user.C_PASSWORD = "E1-0A-DC-39-49-BA-59-AB-BE-56-E0-57-F2-0F-88-3E";
                service.UserUpdate(user);
                return Content("<script>alert('重置密码成功！');window.location.href='../Auth/Login';</script>");
            }
            else
                return Content("<script>alert('密码重置失败！');window.location.href='../Auth/Login';</script>");
        }


    }
}