using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.Framework;
using NF.BLL;

namespace CRM.WebForms.Report
{
    public partial class Order_Plan_FX : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_STD_MAIN tqb_std_main = new Bll_TQB_STD_MAIN();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");

            }
        }


        private void GetList()
        {

            string jh_dt = txtStart.Value;
            string xq_dt = txtEnd.Value;

            DataTable dtStlGrd = tmo_order.GetOrderPlanStlGrd(1, jh_dt, xq_dt).Tables[0];
            if (dtStlGrd.Rows.Count > 0)
            {
                rptStlGrd.DataSource = dtStlGrd;
                rptStlGrd.DataBind();
                ltlStlGrdSum.Text = dtStlGrd.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptStlGrd.DataSource = null;
                rptStlGrd.DataBind();
                ltlStlGrdSum.Text = "";
            }

            DataTable dtSpec = tmo_order.GetOrderPlanStlGrd(2, jh_dt, xq_dt).Tables[0];
            if (dtSpec.Rows.Count > 0)
            {
                rptSpec.DataSource = dtSpec;
                rptSpec.DataBind();
                ltlSpecSum.Text = dtSpec.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptSpec.DataSource = null;
                rptSpec.DataBind();
                ltlSpecSum.Text = "";
            }

            DataTable dtArea = tmo_order.GetOrderPlanStlGrd(3, jh_dt, xq_dt).Tables[0];
            if (dtArea.Rows.Count > 0)
            {
                rptArea.DataSource = dtArea;
                rptArea.DataBind();
                ltlsumjk.Text = dtArea.Compute("sum(N_WGT_JK)", "true").ToString();
                ltlsumjp.Text = dtArea.Compute("sum(N_WGT_JP)", "true").ToString();
                ltlsumpz.Text = dtArea.Compute("sum(N_WGT_PZ)", "true").ToString();
                ltlsum_jp_pz.Text = dtArea.Compute("sum(SUM_JP_PZ)", "true").ToString();
            }
            else
            {
                rptArea.DataSource = null;
                rptArea.DataBind();
                ltlsumjk.Text = "";
                ltlsumjp.Text = "";
                ltlsumpz.Text = "";
                ltlsum_jp_pz.Text = "";
            }


        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}