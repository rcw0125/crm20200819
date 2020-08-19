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
    public partial class PrintCkdRecord : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                DateTime dt = DateTime.Now;
                this.ddlDel.SelectedIndex = 0;
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


        private void GetList()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtFyd.Text.Trim()))
            {
                strWhere += " and t.c_dispatch_id like '%" + txtFyd.Text.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtAttestor.Text.Trim()))
            {
                strWhere += " and t.c_attestor like '%" + txtAttestor.Text.Trim() + "%' ";
            }
            if (txtStart.Value.Trim() != "")
            {
                strWhere += " and t.d_visa_dt>=TO_DATE('" + txtStart.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (txtEnd.Value.Trim() != "")
            {
                strWhere += " and t.d_visa_dt<=TO_DATE('" + txtEnd.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
           
            DataTable dt = tmd_dispatch.GetCKDRePrintList(strWhere,this.ddlDel.SelectedValue).Tables[0];
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

        protected void btnDel_Click(object sender, EventArgs e)
        {
            var cids = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox chkOrder = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkSelect");
                if (chkOrder.Checked)
                {
                    cids += "'" + chkOrder.Value + "',";
                }
            }
            cids = cids.Substring(0, cids.Length - 1);
            if (tmd_dispatch.DeleteCkdRecord(cids,""))
            {
                WebMsg.MessageBox("删除成功");
                GetList();
            }
        }
    }
}