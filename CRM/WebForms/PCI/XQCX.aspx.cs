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
using NF.DAL;
using NF.BLL.P;

namespace CRM.WebForms.PCI
{
    public partial class XQCX : System.Web.UI.Page
    {
        Bll_PlAN_XQCX bll = new Bll_PlAN_XQCX();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    InitDdl();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        protected void btncx3_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (txtOrder.Text != "")
            {
                strWhere += " and T.C_ORDER_NO = '" + txtOrder.Text.Trim() + "'";
            }
            if (txtBatchNo.Text != "")
            {
                strWhere += " and d.c_batch_no = '" + txtBatchNo.Text.Trim() + "'";
            }
            if (txtGrd.Text != "")
            {
                strWhere += " and T.C_STL_GRD like '%"+txtGrd.Text.Trim()+"%'";
            }
            if (txtSpec.Text != "")
            {
                strWhere += " and T.C_SPEC like '%" + txtSpec.Text.Trim() + "%'";
            }
            if (ddlChanXian.SelectedIndex != 0)
            {
                strWhere += " and T.C_LINE_DESC = '" + ddlChanXian.SelectedValue + "'";
            }
            if (Start.Value.Trim() != "")
            {
                strWhere += " and d.D_PRODUCE_DATE_B>=TO_DATE('" + Start.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (End.Value.Trim() != "")
            {
                strWhere += " and d.D_PRODUCE_DATE_B<=TO_DATE('" + End.Value.Trim() + "', 'yyyy-mm-dd hh24:mi:ss')";
            }
            DataTable dt = bll.GetList(strWhere).Tables[0];
            rptList2.DataSource = dt;
            rptList2.DataBind();
        }

        private void InitDdl()
        {
            ddlChanXian.Items.Clear();       
            DataTable dt = bll.GetChanXian().Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlChanXian.Items.Add(new ListItem(dt.Rows[i]["C_LINE_DESC"].ToString(), dt.Rows[i]["C_LINE_DESC"].ToString()));
                    
                }
            }
            ddlChanXian.Items.Insert(0,new ListItem("--全部--", "-1"));
            ddlChanXian.SelectedIndex = 0;
         
        }
    }
}