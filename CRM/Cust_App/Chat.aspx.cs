using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using System.Web.Services;
using NF.Framework;
using NF.MODEL;

namespace CRM.Cust_App
{
    public partial class Chat : System.Web.UI.Page
    {
        private static Bll_TMC_CHAT tmc_chat = new Bll_TMC_CHAT();
        private static Bll_TMC_CHAT_EMP tmc_chat_emp = new Bll_TMC_CHAT_EMP();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    hidUserID.Value = BaseUser.Id;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetChat(string user)
        {
            DataTable dt = tmc_chat.GetChatList(user).Tables[0];
            return SerializationHelper.Dtb2Json(dt);
        }

        /// <summary>
        /// 插入聊天记录
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="uid">发送者</param>
        /// <returns></returns>
        [WebMethod]
        public static bool SetChat(string content,string uid)
        {
            DataRow dr = tmc_chat_emp.GetChatEmp();
            if(dr!=null)
            {
                string fid = dr["c_user_id"].ToString();
                Mod_TMC_CHAT mod = new Mod_TMC_CHAT();
                mod.C_UID = uid;
                mod.C_FID = fid;
                mod.C_CONTENT = content;
                mod.D_DT = DateTime.Now;
                return tmc_chat.Add(mod);
            }
            else
            {
                return false;
            }
        }
    }
}