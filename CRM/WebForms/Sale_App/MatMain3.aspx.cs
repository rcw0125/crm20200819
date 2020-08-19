using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.BLL;
using NF.Framework;

namespace CRM.WebForms.Sale_App
{
    public partial class MatMain3 : System.Web.UI.Page
    {

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetStlGrd();
        }

        private void GetStlGrd()
        {
            DataTable dt = new DataTable();
            if (dropType.SelectedItem.Value == "0")
            {
                dt = tb_matrl_main.GetStlGrd(txtmatcode.Text, txtstlgrd.Text, tstspec.Text).Tables[0];
            }
            else
            {
                dt = tb_matrl_main.GetGP_StlGrd(txtmatcode.Text, txtstlgrd.Text, tstspec.Text).Tables[0];
            }
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

        //添加产品
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session[ltlempid.Text] = null;

            #region //DataTable初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("C_ID", typeof(string));//物料主键
            dt.Columns.Add("C_MAT_CODE", typeof(string));//物料编码
            dt.Columns.Add("C_MAT_NAME", typeof(string));//物料名称
            dt.Columns.Add("C_STL_GRD", typeof(string));//钢种
            dt.Columns.Add("C_SPEC", typeof(string));//规格
            dt.Columns.Add("C_STD_CODE", typeof(string));//执行标准
            dt.Columns.Add("ZYX1", typeof(string));//自由项1
            dt.Columns.Add("ZYX2", typeof(string));//自由项2
            dt.Columns.Add("C_BY4", typeof(string));//是否不锈钢
            #endregion

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("chkMat_Code");//物料ID
                Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                Literal ltlmatname = (Literal)rptList.Items[i].FindControl("ltlmatname");//物料名称
                Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");//钢种
                Literal ltlspec = (Literal)rptList.Items[i].FindControl("ltlspec");//规格
                Literal ltlstdcode = (Literal)rptList.Items[i].FindControl("ltlstdcode");//执行标准
                Literal ltlzyx1 = (Literal)rptList.Items[i].FindControl("ltlzyx1");//自由项1
                Literal ltlzyx2 = (Literal)rptList.Items[i].FindControl("ltlzyx2");//自由项2
                Literal ltlC_IS_BXG = (Literal)rptList.Items[i].FindControl("ltlC_IS_BXG");//是否不锈钢

                if (cbxSelect.Checked)
                {
                    dt.Rows.Add(new object[] { cbxSelect.Value, ltlmatcode.Text, ltlmatname.Text, ltlstlgrd.Text, ltlspec.Text, ltlstdcode.Text, ltlzyx1.Text, ltlzyx2.Text, ltlC_IS_BXG.Text });
                }

            }

            Session[ltlempid.Text] = dt;

            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.Page.GetType(), "", "window.parent.document.getElementById('imgbtnJz').click();", true);

            }
        }
    }
}