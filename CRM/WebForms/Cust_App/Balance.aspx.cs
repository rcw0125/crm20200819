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

namespace CRM.WebForms.Cust_App
{
    public partial class Balance : System.Web.UI.Page
    {
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    #region //余额
                    DataTable dt = ts_custfile.GetCusetMoney(vUser.CustId).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ltltime.Text = Convert.ToDateTime(dt.Rows[0]["TS"].ToString()).ToString();

                        ltlMoney.Text = decimal.Parse(dt.Rows[0]["KHYE"].ToString()).ToString("###,##0.00");
                    }
                    #endregion
                }
            }
        }
    }
}