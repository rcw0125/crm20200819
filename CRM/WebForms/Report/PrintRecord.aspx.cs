using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using System.Data;
using NF.Framework;
using System.Web.UI.HtmlControls;

namespace CRM.WebForms.Report
{
    public partial class PrintRecord : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                DateTime dt = DateTime.Now;
                this.ddlDel.SelectedIndex = 0;
                this.ddlCerType.SelectedIndex = 0;
                //默认打印状态
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    hidempname.Value = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }


        public string ShowType(string type)
        {
            if (type == "1")
            {
                return "普通质证书打印";
            }
            else
            {
                return "委外质证书打印";
            }
        }
        private void GetList()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtNo.Text.Trim()))
            {
                strWhere += " and t.C_CERTIFICATE_NO like '%" + txtNo.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtFYD.Text.Trim()))
            {
                strWhere += " and t.C_DISPATCH_ID like '%" + txtFYD.Text.Trim() + "%' ";
            }
            if (txtStart.Value.Trim() != "")
            {
                strWhere += " and t.D_MOD_DT>=TO_DATE('" + txtStart.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (txtEnd.Value.Trim() != "")
            {
                strWhere += " and t.D_MOD_DT<=TO_DATE('" + txtEnd.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (!string.IsNullOrEmpty(txtUpdateUser.Text.Trim()))
            {
                strWhere += " and t.C_EMP_ID like '%" + txtUpdateUser.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(ddlCerType.SelectedValue))
            {
                strWhere += " and t.C_TYPE="+this.ddlCerType.SelectedValue;
            }
            DataTable dt = tmd_dispatch.GetRePrintList(strWhere,this.ddlDel.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {           

            GetList();
            Page pa = (Page)System.Web.HttpContext.Current.CurrentHandler;
            ClientScript.RegisterClientScriptBlock(pa.GetType(), "aa", "<script language='javascript'>close();</script>");
        }
    }
}