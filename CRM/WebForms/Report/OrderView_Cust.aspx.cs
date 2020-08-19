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

namespace CRM.WebForms.Report
{
    public partial class OrderView_Cust : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private static DataTable dtExport = new DataTable();

        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ////获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    GetArea();

                    Mod_TS_CUSTFILE mod = ts_custfile.GetModel(vUser.CustId);
                    ltlcustname.Text = mod.C_NAME;
                  

                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        /// <summary>
        /// 获取订单区域
        /// </summary>
        private void GetArea()
        {
            DataTable dt = tmo_order.GetOrderArea().Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropArea.DataSource = dt;
                dropArea.DataTextField = "C_AREA";
                dropArea.DataValueField = "C_AREA";
                dropArea.DataBind();
                dropArea.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropArea.DataSource = null;
                dropArea.DataBind();
            }
        }
        private void GetList()
        {
            DataTable dt = tmo_order.GetConOrderList(ltlcustname.Text, txtconno.Text, txtyewuyuan.Text, txtstlgrd.Text,"", "", "","", dropArea.SelectedItem.Value, dropstatus.SelectedItem.Text == "全部" ? "" : dropstatus.SelectedItem.Value,Convert.ToInt32(droptype.SelectedItem.Value),txtspec.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                dtExport = dt;
                rptList.DataBind();


                ltlwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlylxwgt.Text = dt.Compute("sum(YLXWGT)", "true").ToString();
                ltldlxwgt.Text = dt.Compute("sum(DLXWGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlwgt.Text = "";
                ltlylxwgt.Text = "";
                ltldlxwgt.Text = "";
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_CON_NO", "合同编码");
                dic.Add("D_DT2", "签订日期");
                dic.Add("D_DELIVERY_DT", "计划终止日期");
                dic.Add("C_FLOWID", "审批类型");
                dic.Add("C_DEPTID", "部门");
                dic.Add("C_CUST_NAME", "客户名称");
                dic.Add("N_STATUS2", "合同状态");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("N_WGT", "数量*");
                dic.Add("N_ORIGINALCURTAXPRICE", "含税单价*");
                dic.Add("N_ORIGINALCURSUMMNY", "价税合计*");
                dic.Add("YLXWGT", "已履行*");
                dic.Add("DLXWGT", "待履行*");
                dic.Add("C_FREE1", "自由项1");
                dic.Add("C_FREE2", "自由项2");
                dic.Add("C_PACK", "包装要求");
                dic.Add("C_RECEIPTCORPID", "收货单位");
                dic.Add("C_TRANSMODE", "发运方式");
                dic.Add("C_EMPLOYEEID", "业务员");
                dic.Add("C_APPROVEID", "审批人");
                ExportHelper.BudgetExport(dtExport, dic, "合同履行表", Response);
                dtExport = null;
            }
        }
        protected void btncx_Click(object sender, EventArgs e)
        {
            GetList();

            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }


       
    }
}