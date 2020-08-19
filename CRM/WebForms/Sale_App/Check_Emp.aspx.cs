using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using NF.MODEL;
using NF.Framework;
using NF.BLL;

using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class Check_Emp : System.Web.UI.Page
    {
        private Bll_TS_USER_ROLE ts_user_role = new Bll_TS_USER_ROLE();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    try
                    {
                        ltlStepID.Text = Request.QueryString["ID"];
                        Mod_TS_ROLE mod = ts_role.GetModel(Request.QueryString["ID"]);
                        if (mod != null)
                        {
                            ltlRoleName.Text = mod.C_NAME;
                        }
                        GetList();

                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
        }

        private void GetList()
        {

            DataTable dt = ts_user_role.GetCheckEmp(ltlStepID.Text,txtCode.Text,txtName.Text).Tables[0];
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

        protected void btnok_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}