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
using Aspose.Cells;
using CRM.Common;

namespace CRM.WebForms.Report
{


    public partial class roll_prodcut_excel : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMC_ROLL_DEPLOY_LOG tmc_roll_deploy_log = new Bll_TMC_ROLL_DEPLOY_LOG();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();


        private static DataTable dtOrderEx = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                BindList();
            }
        }

    

        private void BindList()
        {

           
            DataTable dt = trc_roll_prodcut.GetRollProdcut3("", "", "", "", "", "", "-1","", "", "", "全部", "", "").Tables[0];
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


       

    }
}