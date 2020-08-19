using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.BLL;

namespace CRM.WebForms.Sale_App
{
    public partial class _ckw : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"])&& !string.IsNullOrEmpty(Request.QueryString["fyID"]))
                {
                    hidID.Value = Request.QueryString["ID"];
                    hidfyID.Value = Request.QueryString["fyID"];
                  
                    BindList();
                }
            }
        }

        private void BindList()
        {
            DataTable dt =  tmo_order.GetCKW(txtcode.Text, hidfyID.Value,txtbatch.Text).Tables[0];
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