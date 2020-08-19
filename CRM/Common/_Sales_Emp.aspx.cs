using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using System.Data;

namespace CRM.Common
{
    public partial class _Sales_Emp : System.Web.UI.Page
    {
        private Bll_TS_USER ts_user = new Bll_TS_USER();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            GetSales();
        }

        private void GetSales()
        {
            DataTable dt = ts_user.GetSales(txtName.Text,txtCode.Text).Tables[0];
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

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            GetSales();
        }
    }
}