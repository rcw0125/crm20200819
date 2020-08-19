using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.Framework;
using NF.MODEL;
using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class TS_CUST_SF : System.Web.UI.Page
    {
        private Bll_TS_CUST_SF ts_cust_sf = new Bll_TS_CUST_SF();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        private void GetList()
        {
            DataTable dt = ts_cust_sf.GetList(txt_twocust.Text, txt_threecust.Text).Tables[0];
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

        protected void btnsave_Click(object sender, EventArgs e)
        {

            bool result = true;
            result = ts_cust_sf.Exists(txt_twocust.Text);
            result = ts_cust_sf.Exists(txt_threecust.Text);

            if (result)
            {
                if (ts_cust_sf.Exists(txt_twocust.Text, txt_threecust.Text))
                {
                    Mod_TS_CUST_SF mod = new Mod_TS_CUST_SF();
                    mod.C_CUSTCODE = txt_threecust.Text;
                    mod.C_CUSTCODE_PARENT = txt_twocust.Text;
                    mod.C_EMPNAME = ltlemp.Text;
                    if (ts_cust_sf.InsertList(mod))
                    {
                        GetList();
                    }
                }
                else
                {
                    WebMsg.MessageBox("已重复添加");
                }
            }
            else
            {
                WebMsg.MessageBox("客户编码不存在，请联系销售客服");
            }



        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txt_twocust.Text)&&string .IsNullOrEmpty(txt_threecust.Text))
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
            else
            {
                GetList();
            }
        }
    }
}