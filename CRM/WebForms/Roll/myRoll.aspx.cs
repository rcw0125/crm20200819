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

namespace CRM.WebForms.Roll
{
    public partial class myRoll : System.Web.UI.Page
    {
        private Bll_TMC_ROLL_APPLY tmc_roll_apply = new Bll_TMC_ROLL_APPLY();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempID.Text = vUser.Id;
                    txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                }
                else
                {
                    //WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetList()
        {
            string status = dropStatus.SelectedValue == "全部" ? "" : dropStatus.SelectedValue;

            DataTable dt = tmc_roll_apply.GetList(txtStart.Value, txtEnd.Value, status, ltlempID.Text).Tables[0];
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
            GetList();
        }

        protected void btnSQ_Click(object sender, EventArgs e)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            string ID = Guid.NewGuid().ToString("N");

            var mod = new Mod_TMC_ROLL_APPLY()
            {
                C_ID = ID,
                C_TITLE = vUser.Name + ",资源申请",
                C_EMPID = vUser.Id,
                C_EMPNAME = vUser.Name
            };
            if (tmc_roll_apply.Insert(mod))
            {
                string url = $@"roll_apply.aspx?ID={ID}";
                Response.Redirect(url);
            }
        }
    }
}