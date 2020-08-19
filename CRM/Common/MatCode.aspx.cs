using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;

namespace CRM.Common
{
    public partial class MatCode : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetGRD();
            }
        }


        private void GetGRD()
        {
            DataTable dt = tb_matrl_main.GetMaxGRD().Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddl_mat.DataSource = dt;
                ddl_mat.DataTextField = "c_invshortname";
                ddl_mat.DataValueField = "c_invshortname";
                ddl_mat.DataBind();
                ddl_mat.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                ddl_mat.DataSource = null;
                ddl_mat.DataBind();
                ddl_mat.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            DataTable dt = tb_matrl_main.GetList(txtName.Value, txtCode.Value, txt_GRD.Value, txtSPEC.Value,ddl_mat.SelectedItem.Value,"").Tables[0];
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