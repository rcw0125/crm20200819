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
    public partial class NoticeAdd : System.Web.UI.Page
    {


        private Bll_TS_DIC dic = new Bll_TS_DIC();
        private Bll_TMB_NOTICE notice = new Bll_TMB_NOTICE();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetClass();
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

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {

            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            Mod_TMB_NOTICE mod = new Mod_TMB_NOTICE();

            mod.C_CLASS = dropClass.SelectedValue;
            mod.C_TITLE = txtTitle.Text;
            mod.C_CONTENT = content1.Value;
            mod.C_EMP_ID = BaseUser.Id;
            mod.C_EMP_NAME = BaseUser.Name;
            if (notice.Add(mod))
            {
                WebMsg.MessageBox("添加成功", "Notice.aspx");
            }


        }


        //跳转
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notice.aspx");
        }
    }
}