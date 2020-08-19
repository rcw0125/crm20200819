using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.Data;

namespace CRM.WebForms.Roll
{
    public partial class nc_stlgrd_price : System.Web.UI.Page
    {
        private Bll_TMB_STLGRD_PRICE_WGT tmb_stlgrd_price_wgt = new Bll_TMB_STLGRD_PRICE_WGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        private void BindList()
        {
            DataTable dt = tmb_stlgrd_price_wgt.GetNCStlGrd(txtStart.Value).Tables[0];
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

        protected void btnCX_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var list = new List<Mod_TMB_STLGRD_PRICE_WGT>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        Literal ltlC_DAY = (Literal)rptList.Items[i].FindControl("ltlC_DAY");
                        Literal ltlC_MAT_GROUP_CODE = (Literal)rptList.Items[i].FindControl("ltlC_MAT_GROUP_CODE");
                        Literal ltlC_MAT_GROUP_NAME = (Literal)rptList.Items[i].FindControl("ltlC_MAT_GROUP_NAME");
                        Literal ltlC_PROD_KIND = (Literal)rptList.Items[i].FindControl("ltlC_PROD_KIND");
                        Literal ltlC_SPEC_MIN = (Literal)rptList.Items[i].FindControl("ltlC_SPEC_MIN");
                        Literal ltlC_SPEC_MAX = (Literal)rptList.Items[i].FindControl("ltlC_SPEC_MAX");
                        Literal ltlC_PRICE = (Literal)rptList.Items[i].FindControl("ltlC_PRICE");
                        Literal ltlC_MAOLI = (Literal)rptList.Items[i].FindControl("ltlC_MAOLI");
                        Literal ltlC_COST = (Literal)rptList.Items[i].FindControl("ltlC_COST");
                        Literal ltlC_SALESORG = (Literal)rptList.Items[i].FindControl("ltlC_SALESORG");

                        var mod = new Mod_TMB_STLGRD_PRICE_WGT()
                        {
                            D_MONTH = Convert.ToDateTime(ltlC_DAY.Text),
                            C_MAT_GROUP_CODE = ltlC_MAT_GROUP_CODE.Text,
                            C_MAT_GROUP_NAME = ltlC_MAT_GROUP_NAME.Text,
                            C_PROD_KIND = ltlC_PROD_KIND.Text,
                            C_SPEC_MIN = ltlC_SPEC_MIN.Text,
                            C_SPEC_MAX = ltlC_SPEC_MAX.Text,
                            C_PRICE = ltlC_PRICE.Text,
                            C_MAOLI = ltlC_MAOLI.Text,
                            C_COST = ltlC_COST.Text,
                            C_SALESORG = ltlC_SALESORG.Text,
                            N_WGT = 0,
                            C_EMPID = vUser?.Id ?? "",
                            C_EMPNAME = vUser?.Name ?? ""
                        };
                        list.Add(mod);
                    }
                }
                if (tmb_stlgrd_price_wgt.InsertMonthStlGrd(list))
                {
                    WebMsg.MessageBox("生成成功");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}