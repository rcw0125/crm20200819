using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.Framework;
using NF.BLL;
using NF.MODEL;

namespace CRM.WebForms.Sale_App
{
    public partial class Cust_BookAdd : System.Web.UI.Page
    {
        private Bll_TMB_AREAMAX tmb_areamax = new Bll_TMB_AREAMAX();
        private Bll_TMC_CUST_BOOK tmc_cust_book = new Bll_TMC_CUST_BOOK();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtD_ZF_DT.Value = DateTime.Now.ToString("yyy-MM-dd");


                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempID.Text = vUser.Id;
                    txtC_CUST_MANAGE.Text = vUser.Name;
                    BindArea();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void BindArea()
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_DETAILNAME";
                dropArea.DataValueField = "C_DETAILNAME";
                dropArea.DataBind();


            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();

            }
        }

        //走访台账记录
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Mod_TMC_CUST_BOOK mod = new Mod_TMC_CUST_BOOK();
            mod.D_ZF_DT = Convert.ToDateTime(txtD_ZF_DT.Value);
            mod.C_CUST_NAME = txtC_CUST_NAME.Text;
            mod.C_AREA = dropArea.SelectedValue;
            mod.C_CUST_MANAGE = txtC_CUST_MANAGE.Text;
            mod.C_CUST_EMP = txtC_CUST_EMP.Text;
            mod.C_CUST_EMP_TEL = txtC_CUST_EMP_TEL.Text;
            mod.C_MEETING_CUST = txtC_MEETING_CUST.Text;
            mod.C_MEETING_XG = txtC_MEETING_XG.Text;
            mod.C_MAIN_CONTENT = txtC_MAIN_CONTENT.Text;
            mod.C_NEED_S_Q = txtC_NEED_S_Q.Text;
            mod.C_LEAVE_Q = txtC_LEAVE_Q.Text;
            mod.C_STL_GRD = txtC_STL_GRD.Text;
            mod.C_PRO_USE = txtC_PRO_USE.Text;
            mod.C_SITE = txtC_SITE.Text;
            mod.C_REMARK = txtC_REMARK.Text;
            mod.N_TYPE = Convert.ToDecimal(droptype.SelectedValue);
            mod.C_EMPID = ltlempID.Text;
            if (tmc_cust_book.Add(mod))
            {
                WebMsg.MessageBox("保存成功", "Cust_BookAdd.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", "0");
        }



        protected void btnRest2_Click(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", "0");
        }
    }
}