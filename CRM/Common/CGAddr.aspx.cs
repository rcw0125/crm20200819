using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


using NF.BLL;
using NF.MODEL;

namespace CRM.Common
{
    public partial class CGAddr : System.Web.UI.Page
    {
        private Bll_TS_CUSTADDR custaddr = new Bll_TS_CUSTADDR();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               if(!string .IsNullOrEmpty(Request .QueryString ["ID"]))
                {
                    string id = Request.QueryString["ID"];
                    //默认收货单位
                    DataTable dt = custaddr.GetAddr("","",id,"","").Tables[0];
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
            }
        }
    }
}