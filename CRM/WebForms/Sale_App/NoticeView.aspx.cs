using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NF.BLL;
using NF.MODEL;
using System.Data;

namespace CRM.WebForms.Sale_App
{
    public partial class NoticeView : System.Web.UI.Page
    {
        private Bll_TMB_NOTICE tmb_notice = new Bll_TMB_NOTICE();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(!string .IsNullOrEmpty(Request .QueryString ["ID"]))
                {
                    Mod_TMB_NOTICE mod = tmb_notice.GetModel(Request.QueryString["ID"]);
                    if(mod!=null)
                    {
                        ltltitle.Text = mod.C_TITLE;
                        ltlcontent.Text = mod.C_CONTENT;
                    }
                }
            }
        }
    }
}