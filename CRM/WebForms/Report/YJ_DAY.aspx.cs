using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class YJ_DAY : System.Web.UI.Page
    {
        private Bll_TB_OVERDUE_CONFIGURE tb_overdue_configure = new Bll_TB_OVERDUE_CONFIGURE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetList();
            }
        }

        public void GetList()
        {
            DataTable dt = tb_overdue_configure.GetList().Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string id = e.CommandArgument.ToString();
                HtmlInputText txtN_YJ_DAYS = (HtmlInputText)e.Item.FindControl("txtN_YJ_DAYS");

                Mod_TB_OVERDUE_CONFIGURE mod = new Mod_TB_OVERDUE_CONFIGURE();
                mod.C_ID = id;
                mod.N_YJ_DAYS = Convert.ToDecimal(txtN_YJ_DAYS.Value == "" ? "0" : txtN_YJ_DAYS.Value);
                if(tb_overdue_configure.Update(mod))
                {
                    WebMsg.MessageBox("保存成功");
                    GetList();
                }
            }
        }
    }
}