using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using NF.MODEL;
using NF.Framework;
using NF.BLL;
using Aspose.Cells;
using NF.Bussiness.Interface;
using Microsoft.Practices.Unity;
using NF.Web.Core;
using NF.EF.Model;
using CRM.Common;

namespace CRM.WebForms.Report
{
    public partial class Order_Plan : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_STD_MAIN tqb_std_main = new Bll_TQB_STD_MAIN();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TQB_PACK pack = new Bll_TQB_PACK();

        public static DataTable dtOrderEx = null;

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ////获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    GetFun();//加载按钮权限

                    ltllempname.Text = vUser.Name;
                    ltllempid.Text = vUser.Id;

                    GetInfo();

                    txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txttbkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txttbjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtshkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                    txtshjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                }
            }
        }

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Report/Order_Plan.aspx", user, Session);
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
        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }

        private void GetInfo()
        {

            try
            {

                #region //物料名称
                DataTable dtMat = tmo_order.GetOrderMat().Tables[0];
                if (dtMat.Rows.Count > 0)
                {
                    dropMatName.DataSource = dtMat;
                    dropMatName.DataTextField = "C_MAT_NAME";
                    dropMatName.DataValueField = "C_MAT_NAME";
                    dropMatName.DataBind();
                    dropMatName.Items.Insert(0, new ListItem("全部", ""));//

                }
                #endregion

                #region /区域

                Mod_TS_DIC mod = new Mod_TS_DIC();
                mod.C_TYPECODE = "ConArea";
                DataTable dtArea = ts_dic.GetList(mod).Tables[0];
                if (dtArea.Rows.Count > 0)
                {
                    dropArea.DataSource = dtArea;
                    dropArea.DataTextField = "C_DETAILNAME";
                    dropArea.DataValueField = "C_DETAILNAME";
                    dropArea.DataBind();
                    dropArea.Items.Insert(0, new ListItem("全部", ""));//
                }


                #endregion

                #region 规格
                DataTable dtSpec = tmo_order.GetSpec().Tables[0];
                if (dtSpec.Rows.Count > 0)
                {
                    dropSpec.DataSource = dtSpec;
                    dropSpec.DataValueField = "C_SPEC";
                    dropSpec.DataTextField = "C_SPEC";
                    dropSpec.DataBind();
                    dropSpec.Items.Insert(0, new ListItem("全部规格", ""));
                }
                #endregion

                #region //包装
                DataTable dtpack = pack.GetPackList("", "").Tables[0];
                if (dtpack.Rows.Count > 0)
                {
                    dropPack.DataSource = dtpack;
                    dropPack.DataValueField = "C_PACK_TYPE_CODE";
                    dropPack.DataTextField = "C_PACK_TYPE_CODE";
                    dropPack.DataBind();
                    dropPack.Items.Insert(0, new ListItem("全部", ""));
                }
                #endregion
            }

            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetList();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }

        private void GetList()
        {

            var list = new List<string>();

            if (txtorderno.Text.Trim() != "")
            {
                string[] OrderNo = txtorderno.Text.Trim().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                OrderNo = OrderNo.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                if (OrderNo.Length > 0)
                {
                    for (int i = 0; i < OrderNo.Length; i++)
                    {
                        list.Add(OrderNo[i]);
                    }
                }
            }

            var strOrder = string.Empty;
            if (list.Count > 0)
            {
                strOrder = "'" + string.Join("','", list.ToArray()) + "'";
            }

            string jh_dt = cbx_jh.Checked == true ? txtStart.Value : "";//计划日期
            string xq_dt = cbx_xq.Checked == true ? txtEnd.Value : "";//需求日期
            string orderkssj = cbxtb_DT.Checked == true ? txttbkssj.Value : "";//提报开始时间
            string orderjssj = cbxtb_DT.Checked == true ? txttbjssj.Value : "";//提报结束时间
            string shkssj = cbxsh_DT.Checked == true ? txtshkssj.Value : "";//审核开始时间
            string shjssj = cbxsh_DT.Checked == true ? txtshjssj.Value : "";//审核结束时间

            string pj = dropPJ.SelectedItem.Text == "全部" ? "" : dropPJ.SelectedItem.Value;

            string exestatus = dropStatus.SelectedItem.Value == "全部" ? "-1,0, 2, 6" : dropStatus.SelectedItem.Value;

            DataTable dt = tmo_order.GetOrderPlan(txtStlGrd.Text, dropSpec.SelectedItem.Value, txtMatCode.Text, txtcon.Text, txtCust.Text, txtSaleEmp.Text, dropOrderType.SelectedItem.Value == "全部" ? "" : dropOrderType.SelectedItem.Value, exestatus, dropArea.SelectedItem.Value, jh_dt, xq_dt, dropMatName.SelectedItem.Value, dropPack.SelectedItem.Value, txtstdcode.Text, orderkssj, orderjssj, shkssj, shjssj, strOrder, pj).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;//导出文件

                rptList.DataSource = dt;
                rptList.DataBind();
                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                //ltlsumwgt_wg.Text = dt.Compute("sum(WG_WGT)", "true").ToString();
                //ltlsumwgt_fp.Text = dt.Compute("sum(N_LINE_MATCH_WGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
                //ltlsumwgt_wg.Text = "";
                //ltlsumwgt_fp.Text = "";

            }
        }





        //取消确认
        protected void btnCancelOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;

                List<string[]> list = new List<string[]>();
                List<string[]> list_log = new List<string[]>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxSelect");

                    Literal ltlN_EXEC_STATUS = (Literal)rptList.Items[i].FindControl("ltlN_EXEC_STATUS");
                    Literal ltlC_SFPJ = (Literal)rptList.Items[i].FindControl("ltlC_SFPJ");


                    if (cbxSelect.Checked)
                    {
                        if (ltlN_EXEC_STATUS.Text == "已审核" && ltlC_SFPJ.Text == "未评价")
                        {
                            result = true;
                            string[] arr = { "-1", cbxSelect.Value };
                            string[] arr_log = { "弃审操作", "旬订单排产提报页面", ltllempid.Text, GetClientIP(), "", cbxSelect.Value };
                            list.Add(arr);
                            list_log.Add(arr_log);
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
                if (result)
                {
                    if (tmo_order.UpdateCancelSubmission(list))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);

                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('取消成功！');</script>", false);
                        GetList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('当前状态不可进行操作');</script>", false);
                }

            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }

        //确认
        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;

                List<string[]> list = new List<string[]>();
                List<string[]> list_log = new List<string[]>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxSelect");
                    Literal ltlN_EXEC_STATUS = (Literal)rptList.Items[i].FindControl("ltlN_EXEC_STATUS");
                    if (cbxSelect.Checked)
                    {
                        if (ltlN_EXEC_STATUS.Text == "已提报")
                        {
                            //参数列表：状态，审核人，计划日期，需求日期，订单主键
                            result = true;
                            string[] arr = { "0", ltllempname.Text, txtStart.Value, txtEnd.Value, cbxSelect.Value };
                            string[] arr_log = { "已审核", "旬订单排产提报页面", ltllempid.Text, GetClientIP(), "", cbxSelect.Value };
                            list.Add(arr);
                            list_log.Add(arr_log);
                        }
                        else
                        {
                            result = false;
                            break;
                        }

                    }
                }
                if (result)
                {
                    if (tmo_order.UpdateCheck(list))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('确认成功！');</script>", false);
                        GetList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('当前状态不可进行操作');</script>", false);
                }

            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }
        /// <summary>
        /// 获取客户端ID
        /// </summary>
        /// <returns></returns>
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

        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_ORDER_NO", "订单号");
                dic.Add("D_PCTBTS", "计划日期");
                dic.Add("D_NEED_DT", "需求日期");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("N_WGT", "数量*");
                dic.Add("WG_WGT", "完工量*");
                dic.Add("N_LINE_MATCH_WGT", "分配量*");
                dic.Add("OUTWGT", "出库量*");
                dic.Add("C_FREE1", "自由项1");
                dic.Add("C_FREE2", "自由项2");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_PACK", "包装要求");
                dic.Add("C_AREA", "销售区域");
                dic.Add("N_EXEC_STATUS", "处理状态");
                dic.Add("N_FLAG", "订单类型");
                dic.Add("C_SFPJ", "订单评价");
                dic.Add("D_DT", "提报日期");
                dic.Add("D_STL_ROL_DT", "审核日期");
                dic.Add("C_CUST_NAME", "客户");
                dic.Add("C_CON_NO", "合同号");
                dic.Add("N_STATUS", "合同状态");
                dic.Add("C_YWY", "业务员");
                dic.Add("C_PCTBEMP", "提报人");
                dic.Add("C_ISSUE_EMP_ID", "审核人");
                dic.Add("C_REMARK", "评价原因");
                dic.Add("C_REMARK4", "备注说明");
                ExportHelper.BudgetExport(dtOrderEx, dic, "销售区域旬订单提报", Response);
                dtOrderEx = null;
            }
        }

        #region //导出文件
        private void BudgetExport(DataTable dt, string tableName)
        {

            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 


            #region//表格样式



            //字体样式1
            Aspose.Cells.Style font1 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font1.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font1.Font.Name = "宋体";//文字字体
            font1.Font.Size = 10;//文字大小
            font1.Font.IsBold = true;//粗体
            font1.IsTextWrapped = true;//自动换行
            font1.Pattern = BackgroundType.Solid; //设置背景样式
            font1.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font1.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font1.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font1.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            //字体样式2
            Aspose.Cells.Style font2 = workbook.Styles[workbook.Styles.Add()];//新增样式
            font2.HorizontalAlignment = TextAlignmentType.Left;//文字居中
            font2.Font.Name = "宋体";//文字字体
            font2.Font.Size = 10;//文字大小
            font2.IsTextWrapped = true;//自动换行
            font2.Pattern = BackgroundType.Solid; //设置背景样式
            font2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin; //应用边界线 左边界线
            font2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin; //应用边界线 右边界线
            font2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin; //应用边界线 上边界线
            font2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin; //应用边界线 下边界线

            #endregion

            int Rownum = dt.Rows.Count;//表格行数
            int Colnum = dt.Columns.Count;//表格列数

            //生成数据行
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[i, k].PutValue(dt.Rows[i][k].ToString());
                    cells[i, k].SetStyle(font2);
                }
                cells.SetRowHeight(i, 24);
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "utf-8";
            string strTemp = System.Web.HttpUtility.UrlEncode(tableName, System.Text.Encoding.UTF8);//解决文件名乱码
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + strTemp + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            Response.BinaryWrite(workbook.SaveToStream().ToArray());
            Response.End();
            WebMsg.MessageBox("导出成功");

        }
        #endregion

        //关闭订单
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;


                List<string[]> list = new List<string[]>();
                List<string[]> list_log = new List<string[]>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxSelect");

                    Literal ltlN_EXEC_STATUS = (Literal)rptList.Items[i].FindControl("ltlN_EXEC_STATUS");
                    Literal ltlC_SFPJ = (Literal)rptList.Items[i].FindControl("ltlC_SFPJ");
                    Literal ltlC_ORDER_NO = (Literal)rptList.Items[i].FindControl("ltlC_ORDER_NO");
                    Literal ltlwgt = (Literal)rptList.Items[i].FindControl("ltlwgt");

                    if (cbxSelect.Checked)
                    {
                        if (ltlC_SFPJ.Text == "未评价" && ltlN_EXEC_STATUS.Text == "已提报")
                        {
                            result = true;
                            string[] arr = { "5", cbxSelect.Value };
                            list.Add(arr);

                            //日志
                            string[] arr2 = { "关闭订单", ltlwgt.Text, ltllempid.Text, GetClientIP(), ltlC_ORDER_NO.Text, cbxSelect.Value };
                            list_log.Add(arr2);
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                }
                if (result)
                {
                    if (tmo_order.UpdateCancelSubmission(list))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);

                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('关闭成功！');</script>", false);
                        GetList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('请先取消订单评价或弃审状态');</script>", false);
                }

            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }

        //区域置空
        protected void btnUpdateArea_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;

                List<string[]> list = new List<string[]>();
                List<string[]> list_log = new List<string[]>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxSelect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxSelect");
                    Literal ltlN_EXEC_STATUS = (Literal)rptList.Items[i].FindControl("ltlN_EXEC_STATUS");
                    if (cbxSelect.Checked)
                    {
                        if (ltlN_EXEC_STATUS.Text == "已提报")
                        {
                            //参数列表：区域，订单主键
                            result = true;
                            string[] arr = { "", cbxSelect.Value };
                            string[] arr_log = { "区域置空", "旬订单排产提报页面", ltllempid.Text, GetClientIP(), "", cbxSelect.Value };
                            list.Add(arr);
                            list_log.Add(arr_log);
                        }
                        else
                        {
                            result = false;
                            break;
                        }

                    }
                }
                if (result)
                {
                    if (tmo_order.UpdateArea(list))
                    {
                        //日志
                        tmo_order.InsertOrderPlanLog(list_log);
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('置空成功！');</script>", false);
                        GetList();
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('当前状态不可进行操作');</script>", false);
                }

            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }
    }
}