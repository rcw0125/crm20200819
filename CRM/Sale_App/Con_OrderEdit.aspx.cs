using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class Con_OrderEdit : System.Web.UI.Page
    {
        Bll_TMO_CONDETAILS tmo_condetails = new Bll_TMO_CONDETAILS();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["orderNo"]))
                    {
                        txtOrderNo.Value = Request.QueryString["orderNo"];
                        GetList();
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetList()
        {
            Mod_TMO_CONDETAILS mod = tmo_condetails.GetModel(txtOrderNo.Value);
            if(mod!=null)
            {
                txtMatCode.Value = mod.C_MAT_CODE;
                txtMatName.Value = mod.C_MAT_NAME;
                txtStlGrd.Value = mod.C_STL_GRD;
                txtSpec.Value = mod.C_SPEC;
                txTechProt.Value = mod.C_TECH_PROT;
                txtstdcode.Value = mod.C_STD_CODE;
                txtPack.Value = mod.C_PACK;
                txtUse.Value = mod.C_PRO_USE;
                txtUnit.Value = mod.C_UNITIS;
                dropLEV.SelectedIndex = dropLEV.Items.IndexOf(dropLEV.Items.FindByText(mod.C_LEV));
                txtNum.Value = mod.N_WGT.ToString();
                txtDate.Value = Convert.ToDateTime(mod.D_DELIVERY_DT).ToString ("yyy-MM-dd");
                txtNeedDate.Value= Convert.ToDateTime(mod.D_NEED_DT).ToString("yyy-MM-dd");
                hidSysDate.Value= Convert.ToDateTime(mod.D_SYS_DELIVERY_DT).ToString("yyy-MM-dd");
                txtAddress.Value = mod.C_CGC;
                txtOTCompany.Value = mod.C_OTC;

            }
        }

        /// <summary>
        /// 获取计划交货时间
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="stdcode">执行标准</param>
        /// <param name="num">重量</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetTime(string stlgrd, string spec, string stdcode, string num)
        {
            return Date.GetDeliveryDate(stlgrd, spec, stdcode, num).ToString("yyy-MM-dd");
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if(tmo_condetails.UpdateOrder(txtOrderNo.Value,Convert .ToDateTime(txtNeedDate.Value),Convert.ToDateTime (txtDate.Value),Convert .ToDateTime(hidSysDate.Value),Convert .ToDecimal(txtNum.Value),dropLEV.SelectedValue,txtMatCode.Value,txtStlGrd.Value,txtSpec.Value))
            {
                Response.Write("<script>alert('提交成功');window.close();window.opener.location.reload();</script>");
            }
        }
    }
}