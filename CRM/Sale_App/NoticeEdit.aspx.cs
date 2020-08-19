using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class NoticeEdit : System.Web.UI.Page
    {


        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TMB_NOTICE notice = new Bll_TMB_NOTICE();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetClass();

                if(!string .IsNullOrEmpty(Request .QueryString ["ID"]))
                {
                    ltlID.Text = Request.QueryString["ID"];
                    
                    Mod_TMB_NOTICE mod = notice.GetModel(ltlID.Text);
                    if(mod!=null)
                    {
                        dropClass.SelectedIndex = dropClass.Items.IndexOf(dropClass.Items.FindByValue(mod.C_CLASS));
                        txtTitle.Text = mod.C_TITLE;
                        content1.Value = mod.C_CONTENT;
                    }
                }
            }
        }

        /// <summary>
        /// 获取公告分类
        /// </summary>
        private void GetClass()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "NoticeType";
            DataTable dt = dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropClass.DataSource = dt;
                dropClass.DataTextField = "C_DETAILNAME";
                dropClass.DataValueField = "C_ID";
                dropClass.DataBind();
            }
            else
            {
                dropClass.DataSource = null;
                dropClass.DataBind();
            }
        }

        //修改
        protected void btnSave_Click(object sender, EventArgs e)
        {

            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            Mod_TMB_NOTICE mod = new Mod_TMB_NOTICE();
            mod.C_CLASS = dropClass.SelectedValue;
            mod.C_ID = ltlID.Text;
            mod.C_TITLE = txtTitle.Text;
            mod.C_CONTENT = content1.Value;
            mod.C_EMP_ID = BaseUser.Id;
            mod.C_EMP_NAME = BaseUser.Name;

            if (notice.Update(mod))
            {
                WebMsg.MessageBox("更新成功", "Notice.aspx");
            }


        }

        //跳转
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notice.aspx");
        }
    }
}