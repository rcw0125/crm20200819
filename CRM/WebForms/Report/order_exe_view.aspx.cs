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
using CRM.Common;


namespace CRM.WebForms.Report
{
    public partial class order_exe_view : System.Web.UI.Page
    {

        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if(!string .IsNullOrEmpty(Request .QueryString["ID"]))
                {
                    DataTable dt = tmo_order.GetOrderPlan(Request.QueryString["ID"]).Tables[0];
                    if(dt.Rows.Count>0)
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
            }
        }
    }
}