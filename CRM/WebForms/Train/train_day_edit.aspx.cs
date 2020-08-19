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
    public partial class train_day_edit : System.Web.UI.Page
    {

        private Bll_TMC_TRAIN_MAIN tmc_train_main = new Bll_TMC_TRAIN_MAIN();
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    txtcode.Text = Request.QueryString["ID"];

                    var mod = tmc_train_main.GetModel(txtcode.Text);

                    if (mod != null)
                    {
                        txtplanno.Text = mod.C_PLANNO;
                        txtstation.Text = mod.C_STATION;
                        txtline.Text = mod.C_LINE;                      
                        txtdate.Value = mod.D_DT.ToString("yyy-MM-dd");
                        txtdate_edit.Text = mod.D_EDIT_DT.ToString();
                        txtnum.Text = mod.N_TRAIN_NUM.ToString();
                        txtshdw.Text = mod.C_REMARK;

                        BindList();
                    }


                }
            }
        }


        private void BindList()
        {
            DataTable dt = tmc_train_main.GetList(txtcode.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
            }
        }


        //删除火运计划
        protected void btndelall_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmc_train_main.Del(txtcode.Text))
                {
                    WebMsg.MessageBox("删除成功", "train_day_apply.aspx");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
        //删除行
        protected void btndelrow_Click(object sender, EventArgs e)
        {

            var list = new List<Mod_TMC_TRAIN_ITEM>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    var mod = new Mod_TMC_TRAIN_ITEM();
                    mod.C_ID = cbxselect.Value;
                    list.Add(mod);
                }
            }

            if (tmc_train_main.Del_ITEM(list))
            {
                BindList();
            }
        }

        protected void imgbtnJz_Click(object sender, ImageClickEventArgs e)
        {
            BindList();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {

                var list = new List<Mod_TMC_TRAIN_ITEM>();

                var mod = new Mod_TMC_TRAIN_MAIN()
                {
                    C_ID = txtcode.Text,
                    C_STATION = txtstation.Text,
                    C_PLANNO = txtplanno.Text,
                    C_LINE = txtline.Text,
                    N_TRAIN_NUM = Convert.ToDecimal(txtnum.Text == "" ? "0" : txtnum.Text),
                    D_EDIT_DT = DateTime.Now,
                    C_REMARK=txtshdw.Text,
                    D_DT=Convert.ToDateTime(txtdate.Value)
                };

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    TextBox txtwgt = (TextBox)rptList.Items[i].FindControl("txtwgt");
                    TextBox txtremark = (TextBox)rptList.Items[i].FindControl("txtremark");

                    var moditem = new Mod_TMC_TRAIN_ITEM() { C_ID = cbxselect.Value, N_WGT = Convert.ToDecimal(txtwgt.Text == "" ? "0" : txtwgt.Text),C_REMARK=txtremark.Text };
                    list.Add(moditem);
                }

                if (tmc_train_main.UpdateTrainDay(mod, list))
                {
                    WebMsg.MessageBox("保存成功", "train_day_apply.aspx");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}