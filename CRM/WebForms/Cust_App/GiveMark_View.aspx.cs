using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Cust_App
{
    public partial class GiveMark_View : System.Web.UI.Page
    {
       
        private Bll_TMC_CUSTGMARK_MAIN tmc_custgmark_main = new Bll_TMC_CUSTGMARK_MAIN();
        private Bll_TMC_CUSTGIVEMARK tmc_custgivemark = new Bll_TMC_CUSTGIVEMARK();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    if(!string .IsNullOrEmpty(Request .QueryString ["ID"]))
                    {
                        Mod_TMC_CUSTGMARK_MAIN mod = tmc_custgmark_main.GetModel(Request.QueryString["ID"]);
                        if(mod!=null)
                        {
                            ltltitle.Text = mod.C_TITLE;
                            ltlstlgrd.Text = mod.C_STLGRD;
                            ltltime.Text = mod.D_TIME.ToString();
                            ltlremark.Text = mod.C_REMARK;

                            DataTable dt = tmc_custgivemark.GetGiveMark(mod.C_ID).Tables[0];
                            if(dt.Rows.Count>0)
                            {
                                rptList.DataSource = dt;
                                rptList.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }

            }
        }
    }
}