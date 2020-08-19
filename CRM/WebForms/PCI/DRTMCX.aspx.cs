using NF.BLL;
using NF.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM.WebForms.PCI
{
    public partial class DRTMCX : System.Web.UI.Page
    {
        Bll_Interface_FR bll_Interface_FR = new Bll_Interface_FR();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncx_Click(object sender, EventArgs e)
        {
            Query();
        }
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "xc")
            {

       
            }

        }
        private void Query()
        {
            try
            {
                DataTable dt = null;
                dt = bll_Interface_FR.GetTMFYDBZ(txtFYDH.Text.Trim(),"",txtGG.Text.Trim(),txtGZ.Text.Trim()).Tables[0];
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
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.ToString());
            }
        }
    }
}