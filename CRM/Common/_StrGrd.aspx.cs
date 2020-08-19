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
    public partial class _StrGrd : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        //钢种
        private void GetStlGrd()
        {
            DataTable dt = tb_matrl_main.GetStlGrd(txtstlgrd.Text).Tables[0];
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

        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetStlGrd();
        }
    }
}