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
    public partial class maoli : System.Web.UI.Page
    {
        private Bll_TMB_STLGRD_PRICE_WGT tmb_stlgrd_price_wgt = new Bll_TMB_STLGRD_PRICE_WGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM");

                BindSaleOrg();
            }
        }

        private void BindSaleOrg()
        {
            DataTable dt = tmb_stlgrd_price_wgt.GetSaleOrg().Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropsaleorg.DataSource = dt;
                dropsaleorg.DataValueField = "C_SALESORG";
                dropsaleorg.DataTextField = "C_SALESORG";
                dropsaleorg.DataBind();
                dropsaleorg.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropsaleorg.DataSource = null;
                dropsaleorg.DataBind();
                dropsaleorg.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        private void BindList()
        {
            DataTable dt = tmb_stlgrd_price_wgt.GetMonth(txtmatname.Text, dropsaleorg.SelectedValue, txtStart.Value,"").Tables[0];
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

                        TextBox txtwgt = (TextBox)rptList.Items[i].FindControl("txtwgt");

                        var mod = new Mod_TMB_STLGRD_PRICE_WGT()
                        {
                            C_ID = cbxselect.Value,
                            N_WGT = Convert.ToDecimal(txtwgt.Text),
                            C_EMPID = vUser?.Id ?? "",
                            C_EMPNAME = vUser?.Name ?? ""
                        };
                        list.Add(mod);
                    }
                }
                if (tmb_stlgrd_price_wgt.UpdateMonthWgt(list))
                {
                    WebMsg.MessageBox("保存成功");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}