using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class Chat_List : System.Web.UI.Page
    {
        private static Bll_TMC_CHAT tmc_chat = new Bll_TMC_CHAT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    hidUserID.Value = BaseUser.Id;

                    GetUID();

                }
            }
        }

        /// <summary>
        /// 获取聊天者名单
        /// </summary>
        /// <returns></returns>

        public void GetUID()
        {
            if (!string.IsNullOrEmpty(hidUserID.Value))
            {
                DataTable dt = tmc_chat.GetUID(hidUserID.Value).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptChat.DataSource = dt;
                    rptChat.DataBind();

                    ltlUID.Text = dt.Rows[0]["c_id"].ToString();
                    GetChat();
                }
            }

        }

        protected void rptChat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "send")
            {
                ltlUID.Text = e.CommandArgument.ToString();
                //Button btnchat = (Button)e.Item.FindControl("btnchat");
                

                foreach (RepeaterItem rpt in rptChat.Items)
                {
                    Button btnchat = (Button)rpt.FindControl("btnchat");
                    if(ltlUID.Text ==btnchat.CommandArgument.ToString ())
                    {
                        btnchat.CssClass = "btn btn-primary btn-sm";
                    }
                    else
                    {
                        btnchat.CssClass = "btn btn-info btn-sm";
                    }
                }
                GetChat();
            }
        }

        private void GetChat()
        {
            DataTable dt = tmc_chat.GetChatList(hidUserID.Value, ltlUID.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string html = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["c_uid"].ToString() == hidUserID.Value)
                    {
                        html += "<p style=\"padding: 10px 0px 10px 0px; text-align: right\">" + dt.Rows[i]["USERNAME"].ToString() + "&nbsp;&nbsp;" + dt.Rows[i]["D_DT"].ToString() + "</p> <p style=\"text-align: right;\"><code style=\"white-space: pre-wrap; font-size: 14px; background: #eff3f6; color: black\">" + dt.Rows[i]["C_CONTENT"].ToString() + "</code></p>";
                      
                    }
                    else
                    {
                        html += "<p style=\"padding: 10px 0px 10px 0px; text-align: left\">" + dt.Rows[i]["USERNAME"].ToString() + "&nbsp;&nbsp;" + dt.Rows[i]["D_DT"].ToString() + "</p> <p><code style=\"white-space: pre-wrap; font-size: 14px; background: #eff3f6; color: black\">" + dt.Rows[i]["C_CONTENT"].ToString() + "</code></p>";
                    }

                }

                ltlContent.Text = html;

                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "sorll();", true);

                
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if(!string .IsNullOrEmpty(txtContent.Value))
            {
                Mod_TMC_CHAT mod = new Mod_TMC_CHAT();
                mod.C_UID = hidUserID.Value;
                mod.C_FID = ltlUID.Text;
                mod.C_CONTENT = txtContent.Value;
                mod.D_DT = DateTime.Now;
                if(tmc_chat.Add(mod))
                {
                    GetChat();
                   
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GetChat();
            if(rptChat.Items.Count<0)
            {
                GetUID();
            }
           
        }
    }
}