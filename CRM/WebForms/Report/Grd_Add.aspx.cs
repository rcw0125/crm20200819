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
    public partial class Grd_Add : System.Web.UI.Page
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
               
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    hid.Value = Request.QueryString["ID"];                 
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Mod_TMb_MONI_STLGRD mod = new Mod_TMb_MONI_STLGRD();
            if (!string.IsNullOrEmpty(txtGrd.Value))
            {
                mod.C_STL_GRD = txtGrd.Value.Trim();
            }
            mod.N_STATUS =1;
            if (!string.IsNullOrEmpty(hid.Value))
            {
                mod.C_ID = hid.Value;            
            }
            else
            {   
                if (tmd.AddGrd(mod))
                {
                    Response.Write("<script>alert('添加成功');window.parent.refers();</script>");                  
                }
            }
        }
    }
}