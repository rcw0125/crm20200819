using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Train
{
    public partial class custEdit : System.Web.UI.Page
    {
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        private void BindInfo()
        {
            Mod_TS_CUSTFILE mod = ts_custfile.GetCustInfo(txtcustcode.Text);
            if (mod != null)
            {
                txtcustno.Text = mod.C_NO;
                txtcustname.Text = mod.C_NAME;
                txtkhh.Text = mod.C_EXTEND1;
                txtsh.Text = mod.C_TAXPAYERNO;
                txtzh.Text = mod.C_EXTEND2;
                txtdz.Text = mod.C_EXTEND3;
                txttel.Text = mod.C_EXTEND4;
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
                if (!string.IsNullOrEmpty(txtcustno.Text))
                {
                    var mod = new Mod_TS_CUSTFILE()
                    {
                        C_NO = txtcustno.Text,//客户编码
                        C_EXTEND1 = txtkhh.Text,//开户行
                        C_TAXPAYERNO = txtsh.Text,//税号
                        C_EXTEND2 = txtzh.Text,//账号
                        C_EXTEND3 = txtdz.Text,//地址
                        C_EXTEND4 = txttel.Text//电话
                    };
                    if (ts_custfile.UpdateInfo(mod))
                    {
                        WebMsg.MessageBox("保存成功");
                    }
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}