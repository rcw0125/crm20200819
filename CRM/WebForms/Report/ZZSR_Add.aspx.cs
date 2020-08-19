using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.BLL;
using System.IO;
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class ZZSR_Add : System.Web.UI.Page
    {
        private Bll_TQB_REMARKPRINT tmd = new Bll_TQB_REMARKPRINT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser == null)
                {
                    WebMsg.CheckUserLogin();
                }
                InitDDL();
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];
                    var model= tmd.GetModel(hid.Value);
                    txtKey.Value = model.C_KEY;
                    txtremark.Value = model.C_VALUE;
                    ddlType.SelectedValue = model.N_TYPE.ToString();
                }
            }
        }
        private void InitDDL()
        {
            var dic = EnumHelper.GetEnumDic<PrintRemarkEnum>();
            dic.Keys.ToList().ForEach(x =>
                this.ddlType.Items.Add(new ListItem()
                {
                    Text = x,
                    Value = dic[x].ToString()
                }));
            this.ddlType.SelectedIndex = 0;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            Mod_TQB_REMARKPRINT mod = new Mod_TQB_REMARKPRINT();
            if (!string.IsNullOrEmpty(txtKey.Value))
            {
                mod.C_KEY = txtKey.Value;
            }
            if (!string.IsNullOrEmpty(txtremark.Value))
            {
                mod.C_VALUE = txtremark.Value;
            }
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                mod.N_TYPE = decimal.Parse(ddlType.SelectedValue);
            }
            mod.D_MOD_DT = DateTime.Now;
            mod.C_EMP_ID = vUser.Account;
            if (!string.IsNullOrEmpty(hid.Value))
            {
                mod.C_ID = hid.Value;                
                if (tmd.Update(mod))
                {
                    Response.Write("<script>alert('修改成功');window.parent.refers();</script>");
                }
            }
            else
            {
                mod.C_ID = Guid.NewGuid().ToString();
                if (tmd.Add(mod))
                {
                    Response.Write("<script>alert('添加成功');window.parent.refers();</script>");                  
                }
            }
        }
    }
}