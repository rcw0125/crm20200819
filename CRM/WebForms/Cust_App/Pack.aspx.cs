using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.BLL;

namespace CRM.Cust_App
{
    public partial class Pack : System.Web.UI.Page
    {
        private Bll_TQB_PACK pack = new Bll_TQB_PACK();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                if(!string .IsNullOrEmpty(Request .QueryString ["ID"]))
                {
                    hidID.Value = Request.QueryString["ID"];
                    BindData();
                }
            }
        }

        //绑定包装要求
        private void BindData()
        {
            DataTable dt = pack.GetPackList(txtCode.Value, txtName.Value).Tables[0];
            if(dt.Rows .Count >0)
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

        //搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}