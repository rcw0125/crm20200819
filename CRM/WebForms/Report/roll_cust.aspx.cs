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
using Aspose.Cells;
using CRM.Common;

namespace CRM.WebForms.Report
{
    public partial class roll_cust : System.Web.UI.Page
    {

        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindArea();
            }
        }

        private void BindArea()
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            var cust = vUser.CustFile;
            DataTable dt = tmo_order.GetCustRollArea(cust.C_NAME).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_SALE_AREA";
                dropArea.DataValueField = "C_SALE_AREA";
                dropArea.DataBind();
                dropArea.Items.Insert(0, new ListItem("全部区域", ""));
            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();
            }
        }


        private void BindList()
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            var cust = vUser.CustFile;
            DataTable dt = trc_roll_prodcut.GetCustRollProc(txtstlgrd.Text, txtspec.Text, txtconno.Text, cust.C_NAME, dropArea.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlqua.Text = dt.Compute("sum(QUA)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlqua.Text = "";
                ltlsumwgt.Text = "";
            }
        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            BindList();
        }
    }
}