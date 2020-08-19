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
    public partial class OrderView : System.Web.UI.Page
    {
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private static DataTable dtExport = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        ltlempid.Text = vUser.Id;
                        DateTime dt = DateTime.Now;
                        Start.Value = dt.AddMonths(-2).ToString("yyy-MM-dd");
                        End.Value = dt.ToString("yyy-MM-dd");

                        GetArea();

                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }

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
            DataTable dt = tmo_order.GetConOrderList(txtcustname.Text, txtconno.Text, txtyewuyuan.Text, txtstlgrd.Text, Start.Value, End.Value, "", dropexestatus.SelectedItem.Text == "全部" ? "" : dropexestatus.SelectedValue, dropArea.SelectedItem.Value, dropstatus.SelectedItem.Text == "全部" ? "" : dropstatus.SelectedItem.Value,Convert.ToInt32(droptype.SelectedItem.Value),txtspec.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtExport = dt;

                rptList.DataSource = dt;
                rptList.DataBind();


                ltlwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlylxwgt.Text = dt.Compute("sum(YLXWGT)", "true").ToString();
                ltldlxwgt.Text = dt.Compute("sum(DLXWGT)", "true").ToString();
                //ltlprice.Text = dt.Compute("sum(N_ORIGINALCURSUMMNY)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlwgt.Text = "";
                //ltlprice.Text = "";
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
                dic.Add("C_NCSTATUS2", "NC状态");
                dic.Add("SCZT", "执行状态");
                dic.Add("D_DT2", "签订日期");
                dic.Add("D_DELIVERY_DT", "计划终止日期");
                dic.Add("C_FLOWID", "审批类型");
                dic.Add("C_AREA", "部门");
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
                ExportHelper.BudgetExport(dtExport, dic, "合同明细", Response);
                dtExport = null;
            }
        }
        protected void btncx_Click(object sender, EventArgs e)
        {
            GetList();

            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)e.Item.FindControl("cbxselect");
                Literal ltlexestatus = (Literal)e.Item.FindControl("ltlexestatus");//执行状态
                Literal ltlncstatus = (Literal)e.Item.FindControl("ltlncstatus");//NC状态
                Literal ltlN_STATUS = (Literal)e.Item.FindControl("ltlN_STATUS");//合同状态

                if (ltlexestatus.Text != "5" && ltlncstatus.Text == "0" && ltlN_STATUS.Text == "2")
                {
                    cbxselect.Visible = true;
                }
                else
                {
                    cbxselect.Visible = false;
                }
            }
        }

        /// <summary>
        /// 生成销售订单&日计划
        /// </summary>
        protected void btnscorder_Click(object sender, EventArgs e)
        {
            List<string> orderID = new List<string>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                if (cbxselect.Checked)
                {
                    orderID.Add(cbxselect.Value);
                }
            }
            if (orderID.Count > 0)
            {
                if (tmo_order.CreateSaleOrderDayPlan(ltlempid.Text, orderID))
                {
                    WebMsg.MessageBox("生成成功");
                    GetList();
                }
                else
                {
                    WebMsg.MessageBox("生成失败");
                }
            }
        }
    }
}