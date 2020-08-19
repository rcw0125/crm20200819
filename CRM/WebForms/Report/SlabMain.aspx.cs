using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NF.BLL;
using NF.Framework;
using CRM.Common;

namespace CRM.WebForms.Report
{
    public partial class SlabMain : System.Web.UI.Page
    {
        private Bll_TSC_SLAB_MAIN tsc_slab_main = new Bll_TSC_SLAB_MAIN();
        private static DataTable dtOrderEx = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void GetList()
        {
            DataTable dt = tsc_slab_main.GetSlabList(txtmatcode.Value, txtstlgrd.Value, txtspec.Value, txtStart.Value, txtEnd.Value, dropSlabCK.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtOrderEx = dt;
                rptList.DataSource = dt;
                rptList.DataBind();

            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        protected void btnCX_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_SLABWH_CODE", "仓库");
                dic.Add("C_SLABWH_LOC_CODE", "库位");
                dic.Add("C_BATCH_NO", "批号");
                dic.Add("C_STOVE", "炉号");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_MAT_NAME", "物料名称");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("N_LEN", "长度");
                dic.Add("SUMWGT", "重量*");
                dic.Add("SUMQUA", "支数*");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_ZYX1", "自由项1");
                dic.Add("C_ZYX2", "自由项2");
                dic.Add("C_JUDGE_LEV_ZH", "质量等级");
                dic.Add("D_WE_DATE", "入库时间");
                ExportHelper.BudgetExport(dtOrderEx, dic, "商品坯统计", Response);
                dtOrderEx = null;
            }
        }
    }
}