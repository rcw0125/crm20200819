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
using CRM.Common;

namespace CRM.WebForms.Train
{
    public partial class train_plan_view : System.Web.UI.Page
    {
        private Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int day = DateTime.Now.Day;

                txtStart.Value = DateTime.Now.AddDays(-day).AddDays(1).ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");

                BindList();
            }
        }

        private void BindList()
        {
            DataTable dt = tmc_train_item.GetTrainPlan(txtplancode.Text, txtdz.Text, txtcust.Text, txtStart.Value, txtEnd.Value, "", droptype.SelectedValue).Tables[0];
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

    }
}