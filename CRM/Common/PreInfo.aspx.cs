using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NF.BLL;
using NF.MODEL;
using NF.Framework;
using System.Web.Services;
using System.Data;

namespace CRM.Common
{
    public partial class PreInfo : System.Web.UI.Page
    {
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();
     
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {

                        ltlUserID.Text = vUser.Id;
                        ltlCustID.Text = vUser.CustId;
                        hCustID.Value = vUser.CustId;

                        BindArea();

                        Mod_TS_USER mod = ts_user.GetModel(vUser.Id);
                        if (mod != null)
                        {
                            #region //基本信息
                            txtUserName.Value = mod.C_ACCOUNT;
                            txtName.Value = mod.C_NAME;
                            txtPhone.Value = mod.C_MOBILE;
                            txtFax.Value = mod.C_MOBILE2;
                            txtTel.Value = mod.C_PHONE;
                            txtEMail.Value = mod.C_EMAIL;
                            #endregion

                            #region //余额
                            DataTable dt = ts_custfile.GetCusetMoney(vUser.CustId).Tables[0];
                            if(dt.Rows.Count>0)
                            {
                                ltltime.Text = Convert.ToDateTime(dt.Rows[0]["TS"].ToString()).ToString();
                                txtMoney.Value =decimal.Parse(dt.Rows[0]["KHYE"].ToString()).ToString("###,##0.00");
                            }
                            #endregion

                            #region //公司档案
                            if (!string.IsNullOrEmpty(mod.C_CJNAME))
                            {
                                txtC_CJNAME.Text = mod.C_CJNAME;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(ltlCustID.Text))
                                {
                                    Mod_TS_CUSTFILE modCustFile = ts_custfile.GetModel(ltlCustID.Text);
                                    txtC_CJNAME.Text = modCustFile.C_NAME;
                                }
                            }
                            txtC_CJINTRO.Text = mod.C_CJINTRO;
                            txtC_STL_GRD.Text = mod.C_STL_GRD;
                            txtC_LEGALREPRES.Text = mod.C_LEGALREPRES;
                            txtC_CGJCR.Text = mod.C_CGJCR;
                            txtC_JOB.Text = mod.C_JOB;
                            txtC_JCTEL.Text = mod.C_JCTEL;
                            txtC_ADDRESS.Text = mod.C_ADDRESS;
                            dropArea.SelectedIndex = dropArea.Items.IndexOf(dropArea.Items.FindByText(mod.C_AREA));
                            txtC_MANAGER.Text = mod.C_MANAGER;
                            #endregion

                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 区域
        /// </summary>
        private void BindArea()
        {
            DataTable dt = tmb_areamax.GetAreaList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_NAME";
                dropArea.DataValueField = "C_NAME";
                dropArea.DataBind();
            }
        }




        //个人信息保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TS_USER mod = ts_user.GetModel(ltlUserID.Text);
                mod.C_NAME = txtName.Value;
                mod.C_PHONE = txtTel.Value;
                mod.C_MOBILE = txtPhone.Value;
                mod.C_MOBILE2 = txtFax.Value;
                mod.C_EMAIL = txtEMail.Value;
                if (ts_user.UpdateInfo(mod))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('保存成功');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "alert('" + ex.ToString() + "');", true);
            }

        }

        /// <summary>
        /// 公司档案
        /// </summary>

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TS_USER mod = ts_user.GetModel(ltlUserID.Text);
                mod.C_CJNAME = txtC_CJNAME.Text;
                mod.C_CJINTRO = txtC_CJINTRO.Text;
                mod.C_STL_GRD = txtC_STL_GRD.Text;
                mod.C_LEGALREPRES = txtC_LEGALREPRES.Text;
                mod.C_CGJCR = txtC_CGJCR.Text;
                mod.C_JOB = txtC_JOB.Text;
                mod.C_JCTEL = txtC_JCTEL.Text;
                mod.C_ADDRESS = txtC_ADDRESS.Text;
                mod.C_AREA = dropArea.SelectedValue;
                mod.C_MANAGER = txtC_MANAGER.Text;
                if (ts_user.UpdateInfo(mod))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.Page.GetType(), "", "alert('保存成功');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.Page.GetType(), "", "alert('" + ex.ToString() + "');", true);
            }
        }

        //修改密码
        protected void btnSavePwd_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TS_USER mod = new Mod_TS_USER();
                mod.C_ID = ltlUserID.Text;
                mod.C_PASSWORD = Encrypt.MD5(txtPwd.Value);
                if(ts_user.UpdatePwd(mod))
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel5, this.Page.GetType(), "", "alert('修改成功');", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel5, this.Page.GetType(), "", "alert('" + ex.ToString() + "');", true);
            }
        }
    }
}