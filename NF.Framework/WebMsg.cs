using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace NF.Framework
{
    /// <summary>
    /// 脚本提示
    /// </summary>
    public class WebMsg
    {


        /// <summary>
        /// 提示，并转页
        /// </summary>
        public static void MessageBox(string msg, string url)
        {
            //System.Web.HttpContext.Current.Response.Write("<script>alert('"+msg+"');</script>");
            //System.Web.HttpContext.Current.Response.Write("<script>window.location.href='"+url+"';</script>");
            Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
            pa.ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>alert('" + msg + "');window.location.href='" + url + "';</script>");

        }

        /// <summary>
        /// 提示不转页
        /// </summary>
        public static void MessageBox(string msg)
        {
            // System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg + "');</script>");
            Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
            pa.ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>alert('" + msg + "');</script>");
        }

        /// <summary>
        /// 检查用户是否登录跳转
        /// </summary>
        public static void CheckUserLogin()
        {
            WebMsg.MessageBox("没有登录！请用正确的账号登录");
            System.Web.HttpContext.Current.Response.Write("<script>window.parent.parent.location.href='/Auth/Login';</script>");
        }

    }


}
