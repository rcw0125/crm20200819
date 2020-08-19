using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;

namespace CRM.Common
{
    public partial class _CustList : System.Web.UI.Page
    {
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["flag"]))
                {
                    hflag.Value = Request.QueryString["flag"];
                    //ltlMC.Text = Request.QueryString["flag"] == "1" ? "收货单位" : "客户";
                }
            }
        }

        private void BindList()
        {
            DataTable dt = ts_custfile.GetListByPage(50, 1, txtcustNo.Text, txtName.Text).Tables[0];
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

        protected void btnok_Click(object sender, EventArgs e)
        {
            BindList();
        }
    }
}