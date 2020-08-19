using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;

namespace CRM.WebForms.Sale_App
{
    public partial class FlowStep_View : System.Web.UI.Page
    {
        private Bll_TMB_FLOWPROC tmb_flowproc = new Bll_TMB_FLOWPROC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page .IsPostBack)
            {
                if(!string .IsNullOrEmpty(Request .QueryString ["taskID"]))
                {
                    string taskID = Request.QueryString["taskID"];
                    DataTable dt = tmb_flowproc.GetFlowSteps(taskID).Tables[0];
                    if(dt.Rows .Count >0)
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
            }
        }
    }
}