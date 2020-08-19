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
using Aspose.Cells;
using CRM.Common;

namespace CRM.WebForms.PCI
{
    public partial class FYCX : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        public static DataTable dtOrderEx = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindInfo();

                txtStart.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtjckssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtjcjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtcckssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtccjssj.Value = DateTime.Now.ToString("yyy-MM-dd");

            }
        }

        #region //基础数据
        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }
        private void BindInfo()
        {
            DataTable dt = GetData("ShipVia");
            if (dt.Rows.Count > 0)
            {
                dropfyfs.DataSource = dt;
                dropfyfs.DataTextField = "C_DETAILNAME";
                dropfyfs.DataValueField = "C_DETAILNAME";
                dropfyfs.DataBind();
                dropfyfs.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropfyfs.DataSource = null;
                dropfyfs.DataBind();
                dropfyfs.Items.Insert(0, new ListItem("全部", ""));
            }
            DataTable dtArea = GetData("ConArea");
            if (dtArea.Rows.Count > 0)
            {

                droparea.DataSource = dtArea;
                droparea.DataTextField = "C_DETAILNAME";
                droparea.DataValueField = "C_DETAILNAME";
                droparea.DataBind();
                droparea.Items.Insert(0, new ListItem("全部区域", ""));
            }
            else
            {
                droparea.DataSource = null;
                droparea.DataBind();
                droparea.Items.Insert(0, new ListItem("全部区域", ""));
            }


            #region //质量
            DataTable dtzl = tmo_order.GetXC_JUDGE_LEV_ZH("").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropzldj.DataSource = dtzl;
                dropzldj.DataTextField = "C_JUDGE_LEV_ZH";
                dropzldj.DataValueField = "C_JUDGE_LEV_ZH";
                dropzldj.DataBind();
                dropzldj.Items.Insert(0, new ListItem("全部", ""));
            }
            #endregion

            #region//承运商
            DataTable dt2 = GetData("TRANCUST");
            if (dt.Rows.Count > 0)
            {

                dropcys.DataSource = dt2;
                dropcys.DataTextField = "C_DETAILNAME";
                dropcys.DataValueField = "C_DETAILNAME";
                dropcys.DataBind();
                dropcys.Items.Insert(0, new ListItem("全部承运商", "全部承运商"));
            }
            else
            {
                dropcys.DataSource = null;
                dropcys.DataBind();
                dropcys.Items.Insert(0, new ListItem("全部承运商", "全部承运商"));
            }
            #endregion


        }
        #endregion

        /// <summary>
        /// 获取发运统计
        /// </summary>
        private void GetList()
        {
            string kssj = cbx_dt.Checked == true ? txtStart.Value : "";
            string jssj = cbx_dt.Checked == true ? txtEnd.Value : "";

            string ckkssj = cbx_ck_dt.Checked == true ? txtckkssj.Value : "";
            string ckjssj = cbx_ck_dt.Checked == true ? txtckjssj.Value : "";

            string jckssj = cbx_RFINTIME.Checked == true ? txtjckssj.Value : "";
            string jcjssj = cbx_RFINTIME.Checked == true ? txtjcjssj.Value : "";
            string cckssj = cbx_RFOUTTIME.Checked == true ? txtckjssj.Value : "";
            string ccjssj = cbx_RFOUTTIME.Checked == true ? txtccjssj.Value : "";

            string ztRF = string.Empty;
            if (dropzt.SelectedValue == "1")
            {
                ztRF = "'3', '8', '7', '9'";
            }
            if (dropzt.SelectedValue == "2")
            {
                ztRF = "'0','2','10'";
            }

            DataTable dt = tmd_dispatch.GetFYStatistic(txtfyd.Text, txtzdr.Text, txtcph.Text, txtconno.Text, txtcust.Text, txtmatcode.Text, txtstlgrd.Text, txtspec.Text, dropfyfs.SelectedItem.Value, droparea.SelectedItem.Value, kssj, jssj, dropzldj.SelectedItem.Value, ckkssj, ckjssj, dropsfxc.SelectedItem.Text, dropsfbdj.SelectedValue == "全部" ? "" : dropsfbdj.SelectedValue, txtstation.Text, txtaddr.Text, ztRF, dropzxzt.SelectedValue == "全部" ? "" : dropzxzt.SelectedValue, txtgps.Text, jckssj, jcjssj, cckssj, ccjssj, dropcys.SelectedValue == "全部承运商" ? "" : dropcys.SelectedValue).Tables[0];


            //PagedDataSource ps = new PagedDataSource();
            //ps.DataSource = dt.DefaultView;
            //Pager1.RecordCount = ps.Count;
            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;//导出文件

                //ps.AllowPaging = true;
                //ps.PageSize = Pager1.PageSize;
                //ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsum_jhnum.Text = dt.Compute("sum(N_FYZS)", "true").ToString();
                ltlsum_sjnum.Text = dt.Compute("sum(N_NUM)", "true").ToString();
                ltlsum_jhwgt.Text = dt.Compute("sum(N_FYWGT)", "true").ToString();
                ltlsum_sjwgt.Text = dt.Compute("sum(N_JZ)", "true").ToString();

                ltlsum_kjwgt.Text = dt.Compute("sum(N_JZ)", "C_FLAG='Y'").ToString();

            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsum_jhnum.Text = "";
                ltlsum_sjnum.Text = "";
                ltlsum_jhwgt.Text = "";
                ltlsum_sjwgt.Text = "";
                ltlsum_kjwgt.Text = "";
            }
        }
        ////分页
        //protected void Pager1_PageChanged(object sender, EventArgs e)
        //{
        //    GetList();
        //}

        //导出文件
        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetList();

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_DISPATCH_ID", "发运单号");
                dic.Add("C_SHIPVIA", "发运方式");
                dic.Add("C_LIC_PLA_NO", "车牌号");
                dic.Add("CARTYPE", "通行证类别");
                dic.Add("C_SEND_STOCK_CODE", "仓库");
                dic.Add("N_FYZS", "计划数量*");
                dic.Add("N_NUM", "实际数量*");
                dic.Add("N_FYWGT", "计划重量*");
                dic.Add("N_JZ", "实际重量*");
                dic.Add("N_ORIGINALCURTAXPRICE", "含税单价*");
                dic.Add("N_RFSTATUS", "条码执行状态");
                dic.Add("D_RFINTIME", "进厂时间");
                dic.Add("D_RFOUTTIME", "出厂时间");
                dic.Add("C_ATSTATION", "到站");
                dic.Add("C_AOG_SITE", "到货地点");
                dic.Add("N_PRICE", "运费");
                dic.Add("C_COMCAR", "承运商");
                dic.Add("C_GPS_NO", "GPS号");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_FREE_TERM", "自由项1");
                dic.Add("C_FREE_TERM2", "自由项2");
                dic.Add("C_QUALIRY_LEV", "质量等级");
                dic.Add("C_PACK", "包装要求");
                dic.Add("C_CREATE_ID", "需求提报人");
                dic.Add("D_CREATE_DT2", "需求提报时间");
                dic.Add("C_XGEMP", "制单日期");
                dic.Add("D_XGTIME", "制单日期");
                dic.Add("D_CKSJ2", "出库时间");
                dic.Add("C_AREA", "区域");
                dic.Add("C_CON_NO", "合同号");
                dic.Add("C_CUST_NAME", "客户名称");
                dic.Add("SHDW", "收货单位");
                dic.Add("C_EXTEND3", "司机姓名/电话");
                dic.Add("C_EXTEND4", "客户姓名/电话");
               

                ExportHelper.BudgetExport(dtOrderEx, dic, "发运统计查询", Response);
                dtOrderEx = null;
            }
        }

        protected void btnTB_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbx_dt.Checked)
                {
                    tmd_dispatch.TBRFFYD(txtStart.Value, txtEnd.Value);
                }
                if (cbx_ck_dt.Checked)
                {
                    tmd_dispatch.TBRFFYD2(txtStart.Value, txtEnd.Value);
                }

                if (cbx_dt.Checked || cbx_ck_dt.Checked)
                {
                    WebMsg.MessageBox("同步成功");
                    GetList();

                }
            }
            catch (Exception)
            {
                WebMsg.MessageBox("同步成功");
                GetList();
            }
        }
    }
}