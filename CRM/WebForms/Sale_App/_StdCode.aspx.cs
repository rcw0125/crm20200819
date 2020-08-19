using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;

namespace CRM.WebForms.Sale_App
{
    public partial class _StdCode : System.Web.UI.Page
    {
        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["gz"]) && !string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    ltlstl_grd.Text = Request.QueryString["gz"];
                    hidID.Value = Request.QueryString["ID"];
                    GetStdCod();
                }
            }
        }

        private void GetStdCod()
        {
            DataTable dt = tb_matrl_main.GetSTD(ltlstl_grd.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropstd.DataSource = dt;
                dropstd.DataValueField = "c_std_code";
                dropstd.DataTextField = "c_std_code";
                dropstd.DataBind();
                dropstd.Items.Insert(0, new ListItem("请选择", ""));
            }
        }

        public void GetFree()
        {
            DataTable dtzyx1 = tb_matrl_main.GetFree(ltlstl_grd.Text,dropstd.SelectedItem.Value).Tables[0];
            if (dtzyx1.Rows.Count > 0)
            {
                dropzyx1.DataSource = dtzyx1;
                dropzyx1.DataTextField = "ZYX1";
                dropzyx1.DataValueField = "ZYX1";
                dropzyx1.DataBind();
            }
            else
            {
                dropzyx1.DataSource = null;
                dropzyx1.DataBind();
            }

            DataTable dtzyx2 = tb_matrl_main.GetFree2(ltlstl_grd.Text, dropstd.SelectedItem.Value).Tables[0];
            if (dtzyx2.Rows.Count > 0)
            {
                dropzyx2.DataSource = dtzyx2;
                dropzyx2.DataTextField = "ZYX2";
                dropzyx2.DataValueField = "ZYX2";
                dropzyx2.DataBind();
            }
            else
            {
                dropzyx2.DataSource = null;
                dropzyx2.DataBind();
            }

        }

        //执行标准选择
        protected void dropstd_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropzyx1.Items.Clear();
            dropzyx2.Items.Clear();

            GetFree();//自由项
        }
    }
}