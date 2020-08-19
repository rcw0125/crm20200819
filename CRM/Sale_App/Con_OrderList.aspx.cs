using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.MODEL;
using NF.BLL;
using NF.Framework;
using System.Data;

namespace CRM.Sale_App
{
    public partial class Con_OrderList : System.Web.UI.Page
    {
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        private static DataTable orderdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ltlConN0.Text = Request.QueryString["ID"];
                    hidconNo.Value = Request.QueryString["ID"];

                    orderdata = tmo_order.GetOrderList(ltlConN0.Text).Tables[0];//订单

                    GetOrderList();
                }
            }
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        private void GetOrderList()
        {
            DataTable dt = condetails.GetConOrderList(ltlConN0.Text, "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                DataTable dt2 = condetails.GetOrderSum(ltlConN0.Text).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    ltlWGTSUM.Text = dt2.Rows[0]["N_WGT"].ToString();
                    ltlN_NOMONEY.Text = dt2.Rows[0]["N_NOMONEY"].ToString();
                    ltlPRICETAX_SUM.Text = dt2.Rows[0]["N_DC_PRICETAX_SUM"].ToString();
                    ltlN_AMOUNT_FAX.Text = dt2.Rows[0]["N_AMOUNT_FAX"].ToString();
                }
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        public static string getExecStatus(string orderNo)
        {
            DataRow[] row = orderdata.Select("C_ORDER_NO='" + orderNo + "'");
            if (row.Length > 0)
            {
                return row[0]["N_EXEC_STATUS"].ToString() == "0" ? "未排产" : "已排产";
            }
            else
            {
                return "";
            }
        }

        public static string IsShow(string orderNo)
        {
            string result = "";
            DataRow[] row = orderdata.Select("C_ORDER_NO='" + orderNo + "'");
            if (row.Length > 0)
            {
                if(row[0]["N_EXEC_STATUS"].ToString()=="1")
                {
                    result = " disabled=\"disabled\"";
                }
            }
            return result;
        }
    }
}