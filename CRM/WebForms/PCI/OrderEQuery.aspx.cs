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
using Aspose.Cells;
using CRM.Common;

namespace CRM.WebForms.PCI
{
    public partial class OrderEQuery : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();

        Bll_PlAN_XQCX bll = new Bll_PlAN_XQCX();
        public static DataTable dtExport = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Start.Value = DateTime.Now.ToString("yyy-MM-dd");
                //End.Value = DateTime.Now.ToString("yyy-MM-dd");

                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    GetArea();
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void GetArea()
        {

            #region //需求区域

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropsalearea.DataSource = dt;
                dropsalearea.DataTextField = "C_DETAILNAME";
                dropsalearea.DataValueField = "C_DETAILNAME";
                dropsalearea.DataBind();
                dropsalearea.Items.Insert(0, new ListItem("全部区域", ""));
            }
           
            #endregion
        }

        protected void btncx3_Click(object sender, EventArgs e)
        {
           


            DataTable dt = bll.ListPlanData(txtOrder.Text, txtGrd.Text, txtSpec.Text, txtExcuteB.Text, Start.Value, End.Value,dropsalearea.SelectedItem.Value,txtmatcode.Text,txtcust.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ltlfpsum.Text = dt.Compute("sum(分配量)", "true").ToString();
                lstJHXQ.Text = dt.Compute("sum(计划需求量)", "true").ToString();
                lstWG.Text = dt.Compute("sum(完工数量)", "true").ToString();
                lstKC.Text = dt.Compute("sum(库存数量)", "true").ToString();
                lstCK.Text = dt.Compute("sum(出库数量)", "true").ToString();
                lstGPXCL.Text = dt.Compute("sum(钢坯现存量)", "true").ToString();
                lstXCK.Text = dt.Compute("sum(线材库存量)", "true").ToString();
                lstXD.Text = dt.Compute("sum(计划下达量)", "true").ToString();
                lstHG.Text = dt.Compute("sum(合格数量)", "true").ToString();
                lstDJ.Text = dt.Compute("sum(待检数量)", "true").ToString();
                lstGP.Text = dt.Compute("sum(改判数量)", "true").ToString();
                lstXY.Text = dt.Compute("sum(协议品数量)", "true").ToString();
                lstTWC.Text = dt.Compute("sum(头尾材数量)", "true").ToString();
                lstBHG.Text = dt.Compute("sum(不合格品数量)", "true").ToString();
                lstHGP.Text = dt.Compute("sum(合格品入库数量)", "true").ToString();
                lstGPRK.Text = dt.Compute("sum(改判入库数量)", "true").ToString();
                lstXYRK.Text = dt.Compute("sum(协议品入库数量)", "true").ToString();
                lstTWCRK.Text = dt.Compute("sum(头尾材入库数量)", "true").ToString();
                lstBHGRK.Text = dt.Compute("sum(不合格品入库数量)", "true").ToString();
                lstGPCK.Text = dt.Compute("sum(改判出库数量)", "true").ToString();
                lstTWCK.Text = dt.Compute("sum(头尾材出库数量)", "true").ToString();
                lstXYCK.Text = dt.Compute("sum(协议品入库数量)", "true").ToString();
                lstBHGCK.Text = dt.Compute("sum(不合格品出库数量)", "true").ToString();
                lstHGCK.Text = dt.Compute("sum(合格品出库数量)", "true").ToString();
                dtExport = dt;
                rptList2.DataSource = dt;
                rptList2.DataBind();
            }
            else
            {
                ltlfpsum.Text = "";
                lstJHXQ.Text = "";
                lstWG.Text = "";
                lstKC.Text = "";
                lstCK.Text = "";
                lstGPXCL.Text = "";
                lstXCK.Text = "";
                lstXD.Text = "";
                lstHG.Text = "";
                lstDJ.Text = "";
                lstGP.Text = "";
                lstXY.Text = "";
                lstTWC.Text = "";
                lstBHG.Text = "";
                lstHGP.Text = "";
                lstGPRK.Text = "";
                lstXYRK.Text = "";
                lstTWCRK.Text = "";
                lstBHGRK.Text = "";
                lstGPCK.Text = "";
                lstXYCK.Text = "";
                lstTWCK.Text = "";
                lstBHGCK.Text = "";
                rptList2.DataSource = null;
                rptList2.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtExport.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("计划订单号", "计划订单号");
                dic.Add("原计划日期", "原计划日期");
                dic.Add("计划日期", "计划日期");
                dic.Add("需求日期", "需求日期");
                dic.Add("销售区域", "销售区域");
                dic.Add("客户名称", "客户名称");
                dic.Add("物料编码", "物料编码");
                dic.Add("物料名称", "物料名称");
                dic.Add("钢种", "钢种");
                dic.Add("规格", "规格");
                dic.Add("自由项1", "自由项1");
                dic.Add("自由项2", "自由项2");
                dic.Add("包装要求", "包装要求");
                dic.Add("计划需求量", "计划需求量*");
                dic.Add("完工数量", "完工数量*");
                dic.Add("分配量", "分配量*");
                dic.Add("库存数量", "库存数量*");
                dic.Add("出库数量", "出库数量*");
                dic.Add("实际需求量", "实际需求量*");
                dic.Add("钢坯现存量", "钢坯现存量*");
                dic.Add("线材库存量", "线材库存量*");
                dic.Add("计划下达量", "计划下达量*");
                dic.Add("合格数量", "合格数量*");
                dic.Add("待检数量", "待检数量*");
                dic.Add("改判数量", "改判数量*");
                dic.Add("协议品数量", "协议品数量*");
                dic.Add("头尾材数量", "头尾材数量*");
                dic.Add("不合格品数量", "不合格品数量*");
                dic.Add("合格品入库数量", "合格品入库数量*");
                dic.Add("改判入库数量", "改判入库数量*");
                dic.Add("协议品入库数量", "协议品入库数量*");
                dic.Add("头尾材入库数量", "头尾材入库数量*");
                dic.Add("不合格品入库数量", "不合格品入库数量*");
                dic.Add("合格品出库数量", "合格品出库数量*");
                dic.Add("改判出库数量", "改判出库数量*");
                dic.Add("协议品出库数量", "协议品出库数量*");
                dic.Add("头尾材出库数量", "头尾材出库数量*");
                dic.Add("不合格品出库数量", "不合格品出库数量*");
                dic.Add("销售出库最小时间", "销售出库最小时间");
                dic.Add("销售出库最大时间", "销售出库最大时间");
                dic.Add("生产最小时间", "生产最小时间");
                dic.Add("生产最大时间", "生产最大时间");
                dic.Add("运输方式", "运输方式");
                dic.Add("修磨要求", "修磨要求");              
                dic.Add("到站", "到站");
                dic.Add("产品类型", "产品类型");
                dic.Add("产品分类", "产品分类");
                dic.Add("是否不锈钢", "是否不锈钢");
                dic.Add("执行标准", "执行标准");
                dic.Add("用途", "用途");
                dic.Add("特殊要求", "特殊要求");
                dic.Add("是否线材", "是否线材");
                dic.Add("备注", "备注");
                dic.Add("执行状态", "执行状态");
                dic.Add("是否出口", "是否出口");
                dic.Add("监控钢种", "监控钢种");
                dic.Add("工艺路线", "工艺路线");
                ExportHelper.BudgetExport(dtExport, dic, "排产计划查询", Response);
                dtExport = null;
            }
        }

        /// <summary>       
        /// 
        /// 设置表页的列宽度自适应   
        /// /// </summary>       
        /// /// <param name="sheet">worksheet对象</param>  
        /// 
        public static void setColumnWithAuto(Worksheet sheet)
        {
            Cells cells = sheet.Cells;
            int columnCount = cells.MaxColumn;  //获取表页的最大列数   
            int rowCount = cells.MaxRow;        //获取表页的最大行数      
            for (int col = 0; col <= columnCount; col++)
            {
                sheet.AutoFitColumn(col, 0, rowCount);
            }
            for (int col = 0; col <= columnCount; col++)
            {
                int width = 50;
                cells.SetColumnWidthPixel(col, cells.GetColumnWidthPixel(col) + width);
            }
        }
    }
}