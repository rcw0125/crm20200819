using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NF.BLL;
using System.Data;
using NF.MODEL;

namespace CRM.WebForms.Sale_App
{
    public partial class _ZTFYD : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["matcode"]) && !string.IsNullOrEmpty(Request.QueryString["stdcode"]) && !string.IsNullOrEmpty(Request.QueryString["area"]) && !string.IsNullOrEmpty(Request.QueryString["lev"]))
                {
                    ltlmatcode.Text = Request.QueryString["matcode"];
                    ltlstdcode.Text = Request.QueryString["stdcode"];
                    ltlarea.Text = Request.QueryString["area"];
                    ltlpack.Text = Request.QueryString["pack"];
                    ltllev.Text = Request.QueryString["lev"];
                    ltlorderid.Text = Request.QueryString["orderid"];
                    GetList();
                }
            }
        }

        private void GetList()
        {
            Mod_TMO_ORDER mod = tmo_order.GetModel(ltlorderid.Text);

            string areafalg = ts_dic.GetAreaFlag(ltlarea.Text);//获取区域是否按客户发运Y/N

            DataTable dt = areafalg == "N" ? tmo_order.ZTWGT(ltlmatcode.Text, ltlstdcode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text).Tables[0] : tmo_order.ZTWGT(ltlmatcode.Text, ltlstdcode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text, mod.C_CUST_NAME,mod.C_CON_NO).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
                ltlsumwgt.Text = dt.Compute("sum(N_FYWGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "0";
            }

            DataTable dtkcwgt = areafalg == "N" ? tmo_order.KCWGT(ltlmatcode.Text, ltlstdcode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text).Tables[0] : tmo_order.KCWGT(ltlmatcode.Text, ltlstdcode.Text, ltlarea.Text, ltlpack.Text, ltllev.Text, mod.C_CUST_NAME,mod.C_CON_NO).Tables[0];
            if (dtkcwgt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtkcwgt.Rows[0]["N_WGT"].ToString()))
                {
                    ltlkcwgt.Text = dtkcwgt.Rows[0]["N_WGT"].ToString();
                }
                else
                {
                    ltlkcwgt.Text = "0";
                }
            }

            ltlkfwgt.Text = Convert.ToString(Convert.ToDecimal(ltlkcwgt.Text) - Convert.ToDecimal(ltlsumwgt.Text));
        }


    }
}