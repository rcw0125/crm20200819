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
    public partial class CONFYCXMX : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();

        public static DataTable dtOrderEx = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        /// <summary>
        /// 获取发运统计
        /// </summary>
        private void GetList()
        {
            string ckkssj = cbx_ck_dt.Checked == true ? txtckkssj.Value : "";
            string ckjssj = cbx_ck_dt.Checked == true ? txtckjssj.Value : "";

            DataTable dt = tmd_dispatch.GetConFYMX_Statistic(txtcon.Text, txtcust.Text, txtfyd.Text, txtstlgrd.Text, txtspec.Text, txtbatch.Text, ckkssj, ckjssj, "").Tables[0];



            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;//导出文件

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                rptList.DataSource =dt;
                rptList.DataBind();

            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
            }
        }
        protected void btnxc_Click(object sender, EventArgs e)
        {
            GetList();
        }

        //导入
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_FYDH", "发运单号");
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_STOVE", "炉号");
                dic.Add("C_ID", "条码");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("N_WGT", "重量*");
                dic.Add("D_CKSJ", "发货时间");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_MAT_DESC", "物料名称");
                dic.Add("C_CUST_NAME", "客户");
                dic.Add("C_CON_NO", "合同号");

                ExportHelper.BudgetExport(dtOrderEx, dic, "合同发运执行明细表", Response);
                dtOrderEx = null;
            }
        }
    }
}