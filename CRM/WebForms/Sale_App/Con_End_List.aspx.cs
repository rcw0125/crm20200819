using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using NF.BLL;
using NF.Framework;
using NF.MODEL;

namespace CRM.WebForms.Sale_App
{
    public partial class Con_End_List : System.Web.UI.Page
    {

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        private void BindList()
        {
            
            string flag = string.Empty;
            if (dropflag.SelectedValue == "全部")
            {
                flag = "'-1','0','1'";
            }
            else
            {
                flag = $"'{dropflag.SelectedValue}'";
            }
            DataTable dt = tmo_con.GetCustCon_End_List(txtconno.Text, "", flag, txtStart.Value, txtEnd.Value).Tables[0];
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

        protected void btnendcon_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = true;
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        rs = tmo_con.CheckCustCon_End(cbxselect.Value, vUser.Id);
                    }
                }
                if (rs)
                {
                    WebMsg.MessageBox("批准成功");
                    BindList();
                }
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}