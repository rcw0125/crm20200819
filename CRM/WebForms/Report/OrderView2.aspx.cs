using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.Unity;

using System.Data;
using NF.BLL;
using NF.MODEL;
using NF.Framework;
using CRM.Common;
using NF.Bussiness.Interface;
using NF.Web.Core;
using NF.EF.Model;

namespace CRM.WebForms.Report
{
    public partial class OrderView2 : System.Web.UI.Page
    {
        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private static DataTable dtExport = new DataTable();
        private Bll_TMO_ORDER_PCZB tmo_order_pczb = new Bll_TMO_ORDER_PCZB();


        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlempid.Text = vUser.Id;
                    ltlempName.Text = vUser.Name;

                    GetFun();//加载按钮权限
                    GetArea();
                    GetZb();

                }
            }
        }

        private void GetZb()
        {
            int day = Convert.ToInt32((DateTime.Now.Day - 1) / 10);
            switch (day)
            {
                case 0:
                    dropZB.SelectedIndex = 0;
                    break;
                case 1:
                    dropZB.SelectedIndex = 1;
                    break;
                default:
                    dropZB.SelectedIndex = 2;
                    break;
            }
        }



        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Report/OrderView2.aspx", user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
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
            DataTable dt = tmo_order.GetConOrderList(txtcustname.Text, txtconno.Text, txtyewuyuan.Text, txtstlgrd.Text, "", "", "", "", dropArea.SelectedItem.Value, dropstatus.SelectedItem.Text == "全部" ? "" : dropstatus.SelectedItem.Value, Convert.ToInt32(droptype.SelectedItem.Value), txtspec.Text,txtmatcode.Text).Tables[0];

            dtExport = dt;

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            Pager1.RecordCount = ps.Count;
            if (Pager1.RecordCount > 0)
            {
                ps.AllowPaging = true;
                ps.PageSize = Pager1.PageSize;
                ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                rptList.DataSource = ps;
                rptList.DataBind();

                ltlwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlylxwgt.Text = dt.Compute("sum(YLXWGT)", "true").ToString();
                ltldlxwgt.Text = dt.Compute("sum(DLXWGT)", "true").ToString();
                ltlpcwgt.Text = dt.Compute("sum(XFWGT)", "true").ToString();

            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlwgt.Text = "";
                ltlylxwgt.Text = "";
                ltldlxwgt.Text = "";
                ltlpcwgt.Text = "";
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
                dic.Add("XFWGT", "已下发排产量*");
                dic.Add("YLXWGT", "已履行*");
                dic.Add("DLXWGT", "待履行*");
                dic.Add("N_ORIGINALCURTAXPRICE", "含税单价*");
                dic.Add("N_ORIGINALCURSUMMNY", "价税合计*");
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

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetList();
        }

        //批量排产
        protected void btnPLPC_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;//判定是否超出原合同订单量
                bool result2 = true;//判定排产量是否有效数字

                bool result3 = true;//判定是否满足排产指标

                List<Mod_TMO_ORDER> orderList = new List<Mod_TMO_ORDER>();
                List<string[]> list_log = new List<string[]>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbx_order = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbx_order");
                    Literal ltlwgt = (Literal)rptList.Items[i].FindControl("ltlwgt");
                    Literal ltldlxwgt = (Literal)rptList.Items[i].FindControl("ltldlxwgt");
                    Literal ltlpcwgt = (Literal)rptList.Items[i].FindControl("ltlpcwgt");
                    if (cbx_order.Checked)
                    {
                        if (Convert.ToDecimal(ltldlxwgt.Text) > 0)
                        {
                            //decimal sum = Convert.ToDecimal(ltlpcwgt.Text) + Convert.ToDecimal(ltldlxwgt.Text);
                            decimal sum = Convert.ToDecimal(ltlpcwgt.Text);
                            decimal wgt = Convert.ToDecimal(ltlwgt.Text);

                            //判定是否排产量大于订单量
                            if (sum > Convert.ToDecimal(ltlwgt.Text))
                            {
                                result = false;
                                break;
                            }
                            else
                            {
                                decimal n = wgt - sum;//订单量减去已排产量

                                if (n > 0)//判定剩余排产是否大于0
                                {
                                    Mod_TMO_ORDER modOrder = tmo_order.GetModel(cbx_order.Value);

                                    //校验是否满足排产指标
                                    if (tmo_order_pczb.CheckStl_Grd_ZB(n, modOrder.C_AREA, modOrder.C_ORDER_NO,dropZB.SelectedItem.Value))
                                    {
                                        #region //生产订单号
                                        int no = tmo_order.GetOrderPlanNum(modOrder.C_ORDER_NO, modOrder.C_CON_NO);
                                        string pc = modOrder.C_ORDER_NO + "/" + no.ToString();

                                        if (tmo_order.Exists_OrderPlan(pc, modOrder.C_CON_NO))
                                        {
                                            no += 1;
                                            pc = modOrder.C_ORDER_NO + "/" + no.ToString();
                                        }
                                        #endregion

                                        modOrder.C_ORDER_NO = pc;
                                        modOrder.N_EXEC_STATUS = -1;//执行状态：提报订单
                                        modOrder.C_PCTBEMP = ltlempName.Text;//提报人
                                        modOrder.N_WGT = wgt - sum; //需求排产量  Convert.ToDecimal(ltldlxwgt.Text);//待履行量
                                        orderList.Add(modOrder);
                                        string[] arr_log = { "提报订单", "合同履行表页面", GetClientIP(), ltlempid.Text, modOrder.C_ORDER_NO, modOrder.C_ID };
                                        list_log.Add(arr_log);
                                    }
                                    else
                                    {
                                        result3 = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    result2 = false;
                                    break;
                                }

                            }
                        }
                    }
                }

                if (result)//判断排产量是否超出原订单量
                {
                    if (result2)//排产量是否有效数字
                    {
                        if (result3)
                        {

                            if (tmo_con.InsertNeedOrder(orderList))
                            {
                                //日志
                                tmo_order.InsertOrderPlanLog(list_log);

                                WebMsg.MessageBox("下发成功");
                                GetList();
                            }
                        }
                        else
                        {
                            WebMsg.MessageBox("其中批量排产订单量,不符合当月当旬排产指标");
                        }
                    }
                    else
                    {
                        WebMsg.MessageBox("其中批量排产订单有0排产量，请重新检查再次提交");
                    }


                }
                else
                {
                    WebMsg.MessageBox("当前需求排产量已超原合同订单量,请单独下发排产！");
                }

            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        private string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }
    }
}