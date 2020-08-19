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

namespace CRM.WebForms.Report
{
    public partial class roll_prodcut_CKFYD : System.Web.UI.Page
    {

        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ck"]) && !string.IsNullOrEmpty(Request["ID"]))
                {
                    ltlckcdoe.Text = Request.QueryString["ck"];
                    ltlfydID.Text = Request.QueryString["ID"];

                    BindList();
                }               
            }
        }


        private void BindList()
        {

            DataTable dt = trc_roll_prodcut.GetCKRollProdcut(ltlckcdoe.Text, ltlfydID.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlcount.Text = dt.Compute("sum(JIANSHU)", "true").ToString();
            }
            else
            {
                ltlsumwgt.Text = "";
                ltlcount.Text = "";
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }



    }
}