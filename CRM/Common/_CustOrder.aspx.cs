using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.MODEL;

namespace CRM.WebForms.Cust_App
{
    public partial class _CustOrder : System.Web.UI.Page
    {
        //private Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    Session["xm"] = null;
                    DateTime dt = DateTime.Now;
                    txtStart.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    txtEnd.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
                    Mod_TS_CUSTFILE mod = ts_custfile.GetModel(vUser.CustId);
                    if (mod != null)
                    {
                        ltlcustno.Text = mod.C_NO;
                    }
                    if(!string .IsNullOrEmpty(Request .QueryString ["flag"]))
                    {
                        hidflag.Value = Request.QueryString["flag"];
                    }
                }

            }
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        private void GetOrder()
        {
            DataTable dt = tmo_order.GetConOrderList(txtConNo.Text, "", txtstlgrd.Text, txtStart.Value, txtEnd.Value,ltlcustno.Text).Tables[0];
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetOrder();
        }


    }
}