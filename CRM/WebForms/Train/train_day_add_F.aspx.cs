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
using NF.Framework;
using CRM.Common;

namespace CRM.WebForms.Train
{
    public partial class train_day_add_F : System.Web.UI.Page
    {
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ltlID.Text = Request.QueryString["ID"];
                }
            }
        }

        private void BindList()
        {
            DataTable dt = tb_matrl_main.GetCustStlGrd_FCP(txtmatcode.Text, txtmatname.Text).Tables[0];
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

        protected void btncx_Click(object sender, EventArgs e)
        {
            BindList();

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<Mod_TMC_TRAIN_ITEM>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        //Literal ltlC_AREA = (Literal)rptList.Items[i].FindControl("ltlC_AREA");
                        //Literal ltlC_CONNO = (Literal)rptList.Items[i].FindControl("ltlC_CONNO");
                        TextBox txtdhdw = (TextBox)rptList.Items[i].FindControl("txtdhdw");
                        //TextBox txtC_SH_COMPANY = (TextBox)rptList.Items[i].FindControl("txtC_SH_COMPANY");
                        //Literal ltlC_SPEC = (Literal)rptList.Items[i].FindControl("ltlC_SPEC");
                        //Literal ltlC_STL_GRD = (Literal)rptList.Items[i].FindControl("ltlC_STL_GRD");
                        TextBox txtN_WGT = (TextBox)rptList.Items[i].FindControl("txtN_WGT");
                        TextBox txtRemark = (TextBox)rptList.Items[i].FindControl("txtRemark");
                        TextBox txtC_CUSTNO = (TextBox)rptList.Items[i].FindControl("txtC_CUSTNO");
                        TextBox txtC_CUSTNAME = (TextBox)rptList.Items[i].FindControl("txtC_CUSTNAME");
                        TextBox txtC_KH_BANK = (TextBox)rptList.Items[i].FindControl("txtC_KH_BANK");
                        TextBox txtC_TAXNO = (TextBox)rptList.Items[i].FindControl("txtC_TAXNO");
                        TextBox txtC_ACCOUNT = (TextBox)rptList.Items[i].FindControl("txtC_ACCOUNT");
                        TextBox txtC_TEL = (TextBox)rptList.Items[i].FindControl("txtC_TEL");
                        TextBox txtC_ADDRESS = (TextBox)rptList.Items[i].FindControl("txtC_ADDRESS");

                        var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                        var mod = new Mod_TMC_TRAIN_ITEM()
                        {
                            C_EMPNAME = vUser.Name,
                            C_PKID = ltlID.Text,
                            C_AREA = "副产品销售部",
                            C_CONNO = "",
                            C_DH_COMPANY = txtdhdw.Text,
                            C_SH_COMPANY = "",
                            C_CUSTNO = txtC_CUSTNO.Text,
                            C_CUSTNAME = txtC_CUSTNAME.Text,
                            C_KH_BANK = txtC_KH_BANK.Text,
                            C_TAXNO = txtC_TAXNO.Text,
                            C_ADDRESS = txtC_ADDRESS.Text,
                            C_TEL = txtC_TEL.Text,
                            C_ACCOUNT = txtC_ACCOUNT.Text,
                            C_FLAG = "1",
                            C_BILLCODE = cbxselect.Value,
                            C_SPEC = "",
                            C_STL_GRD = "",
                            N_WGT = Convert.ToDecimal(txtN_WGT.Text == "" ? "0" : txtN_WGT.Text),
                            C_REMARK = txtRemark.Text
                        };
                        list.Add(mod);
                    }

                }
                if (tmc_train_item.AddTrain(list))
                {
                    Response.Write("<script>window.parent.document.getElementById('imgbtnJz').click();window.parent.close();</script>");
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}