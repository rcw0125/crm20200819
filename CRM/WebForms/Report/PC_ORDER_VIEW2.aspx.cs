using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL.P;
using NF.BLL;
using NF.MODEL;

namespace CRM.WebForms.Report
{
    public partial class PC_ORDER_VIEW2 : System.Web.UI.Page
    {

        Bll_PlAN_XQCX plan_xqcx = new Bll_PlAN_XQCX();

        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    string id = Request.QueryString["ID"];



                    DataTable dt = plan_xqcx.ListPlanData2(id).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ltlNEEDWGT.Text = dt.Compute("sum(计划需求量)", "true").ToString();
                        ltlWGWGT.Text = dt.Compute("sum(完工数量)", "true").ToString();
                        ltlHGWGT.Text = dt.Compute("sum(合格数量)", "true").ToString();
                        ltlDJWGT.Text = dt.Compute("sum(待检数量)", "true").ToString();
                        ltlDJWGT.Text = dt.Compute("sum(待检数量)", "true").ToString();
                        ltlGPWGT.Text = dt.Compute("sum(改判数量)", "true").ToString();
                        ltlXYPWGT.Text = dt.Compute("sum(协议品数量)", "true").ToString();
                        ltlTWCWGT.Text = dt.Compute("sum(头尾材数量)", "true").ToString();
                        ltlBHGPWGT.Text = dt.Compute("sum(不合格品数量)", "true").ToString();
                        rptList.DataSource = dt;
                        rptList.DataBind();
                    }
                    else
                    {
                        ltlNEEDWGT.Text = "";
                        ltlWGWGT.Text = "";
                        ltlHGWGT.Text = "";
                        ltlDJWGT.Text = "";
                        ltlDJWGT.Text = "";
                        ltlGPWGT.Text = "";
                        ltlXYPWGT.Text = "";
                        ltlTWCWGT.Text = "";
                        ltlBHGPWGT.Text = "";
                        rptList.DataSource = null;
                        rptList.DataBind();
                    }
                }
            }
        }
    }
}