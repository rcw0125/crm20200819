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
    public partial class OTCompany : System.Web.UI.Page
    {
        private Bll_TS_CUSTOTCOMPANY custotcompany = new Bll_TS_CUSTOTCOMPANY();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        //加载收货单位
        private void BindData()
        {
            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (BaseUser != null)
            {
                //默认收货单位
                DataTable dt = custotcompany.GetOT(BaseUser.CustId, "").Tables[0];
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