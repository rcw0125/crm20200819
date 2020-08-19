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


namespace CRM.WebForms.Sale_App
{
    public partial class Cust_Book : System.Web.UI.Page
    {
        private Bll_TMC_CUST_BOOK tmc_cust_book = new Bll_TMC_CUST_BOOK();

        public static DataTable dtExport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        private void BindList()
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            DataTable dt = tmc_cust_book.GetList(txtcust.Text, txtstlgrd.Text, txtStart.Value, txtEnd.Value, vUser.Id).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                dtExport = dt;
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("D_ZF_DT", "日期");
                dic.Add("N_TYPE", "类型");
                dic.Add("C_CUST_NAME", "客户名称");
                dic.Add("C_AREA", "区域");
                dic.Add("C_CUST_MANAGE", "区域经理");
                dic.Add("C_CUST_EMP", "人员");
                dic.Add("C_CUST_EMP_TEL", "电话");
                dic.Add("C_MEETING_CUST", "参会客户");
                dic.Add("C_MEETING_XG", "参会邢钢");
                dic.Add("C_MAIN_CONTENT", "主要交流内容");
                dic.Add("C_NEED_S_Q", "需解决问题");
                dic.Add("C_LEAVE_Q", "遗留问题");
                dic.Add("C_REMARK", "备注");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_PRO_USE", "用途");
                dic.Add("C_SITE", "交流地点");

                ExportHelper.BudgetExport(dtExport, dic, "客户档案", Response);
                dtExport = null;
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = false;

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    if (cbxselect.Checked)
                    {
                        res = tmc_cust_book.Delete(cbxselect.Value);
                    }
                }
                if (res)
                {
                    WebMsg.MessageBox("删除成功");
                    BindList();
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}