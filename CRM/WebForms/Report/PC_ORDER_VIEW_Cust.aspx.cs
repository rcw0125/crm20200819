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
    public partial class PC_ORDER_VIEW_Cust : System.Web.UI.Page
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


                    Mod_TMO_ORDER mod = tmo_order.GetOrderModel(id);
                    string order = id.StartsWith("YC") == true ? "'" + id + "'" : "'" + mod?.C_ORDER_NO + "'";
                    if (!string.IsNullOrEmpty(mod?.C_ORDER_NO_OLD))
                    {
                        order += ",'" + mod?.C_ORDER_NO_OLD + "'";
                    }

                    DataTable dt = plan_xqcx.ListPlanData(order).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ltlNEEDWGT.Text = dt.Compute("sum(计划需求量)", "true").ToString();
                        ltlWGWGT.Text = dt.Compute("sum(分配量)", "true").ToString();
                       
                       
                        rptList.DataSource = dt;
                        rptList.DataBind();
                    }
                    else
                    {
                        ltlNEEDWGT.Text = "";
                        ltlWGWGT.Text = "";
                      
                       
                        rptList.DataSource = null;
                        rptList.DataBind();
                    }
                }
            }
        }
    }
}