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

namespace CRM.WebForms.Train
{
    public partial class train_add : System.Web.UI.Page
    {
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindArea();

                txtStart.Value = DateTime.Now.AddMonths(1).ToString("yyy-MM");
            }
        }

        private void BindArea()
        {
            #region //需求区域

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                droparea.DataSource = dt;
                droparea.DataTextField = "C_DETAILNAME";
                droparea.DataValueField = "C_DETAILNAME";
                droparea.DataBind();
            }
            else
            {
                droparea.DataSource = null;
                droparea.DataBind();
            }
            #endregion
        }

        private void BindInfo()
        {

            if (!string.IsNullOrEmpty(txtconno.Text))
            {
                #region //合同搜索
                Mod_TMO_CON modCon = tmo_con.GetModel(txtconno.Text);
                if (modCon != null)
                {
                    droparea.SelectedIndex = droparea.Items.IndexOf(droparea.Items.FindByText(modCon.C_AREA));
                    txtC_CONNO.Text = modCon.C_CON_NO;
                    txtC_DH_COMPANY.Text = modCon.C_CUSTNAME;
                    txtC_SH_COMPANY.Text = modCon.C_CUSTNAME;
                    txtC_STATION.Text = modCon.C_STATION;
                    txtC_CUSTNO.Text = modCon.C_CUST_NO;

                    Mod_TS_CUSTFILE mod = ts_custfile.GetModelCode(modCon.C_CUST_NO);
                    if (mod != null)
                    {
                        txtC_CUSTNAME.Text = mod.C_NAME;//客户名称
                        txtC_KH_BANK.Text = mod.C_EXTEND1;//开户行
                        txtC_TAXNO.Text = mod.C_TAXPAYERNO;//税号
                        txtC_ACCOUNT.Text = mod.C_EXTEND2;//账号
                        txtC_ADDRESS.Text = mod.C_EXTEND3;//地址
                        txtC_TEL.Text = mod.C_EXTEND4;//电话
                    }

                }


                #endregion
            }

            if (!string.IsNullOrEmpty(txtcustno.Text))
            {
                #region //客户编码搜索
                Mod_TS_CUSTFILE mod = ts_custfile.GetModelCode(txtcustno.Text);
                if (mod != null)
                {
                    txtC_CUSTNO.Text = mod.C_NO;
                    txtC_CUSTNAME.Text = mod.C_NAME;//客户名称
                    txtC_KH_BANK.Text = mod.C_EXTEND1;//开户行
                    txtC_TAXNO.Text = mod.C_TAXPAYERNO;//税号
                    txtC_ACCOUNT.Text = mod.C_EXTEND2;//账号
                    txtC_ADDRESS.Text = mod.C_EXTEND3;//地址
                    txtC_TEL.Text = mod.C_EXTEND4;//电话
                }
                #endregion
            }

        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            BindInfo();
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                var mod = new Mod_TMC_TRAIN_ITEM()
                {
                    C_EMPNAME = vUser.Name,
                    C_PKID = vUser.Id,
                    C_AREA = droparea.SelectedItem.Text,
                    C_CONNO = txtC_CONNO.Text,
                    C_DH_COMPANY = txtC_DH_COMPANY.Text,
                    C_SH_COMPANY = txtC_SH_COMPANY.Text,
                    C_STATION = txtC_STATION.Text,
                    N_TRAIN_NUM = Convert.ToDecimal(txtN_TRAIN_NUM.Text),
                    C_CUSTNO = txtC_CUSTNO.Text,
                    C_CUSTNAME = txtC_CUSTNAME.Text,
                    C_KH_BANK = txtC_KH_BANK.Text,
                    C_TAXNO = txtC_TAXNO.Text,
                    C_ADDRESS = txtC_ADDRESS.Text,
                    C_TEL = txtC_TEL.Text,
                    C_ACCOUNT = txtC_ACCOUNT.Text,
                    C_FLAG = dropflag.SelectedValue,
                    C_BILLCODE = randomnumber.GetTrainCode(),
                    D_MONTH = Convert.ToDateTime(txtStart.Value + "-1"),
                    C_LINE=txtLine.Text

                };

                if (tmc_train_item.Add(mod))
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