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
    public partial class CONFYCXMX_CUST2 : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();

        public static DataTable dtOrderEx = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                txtckkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtckjssj.Value = DateTime.Now.ToString("yyy-MM-dd");

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    var custinfo = vUser.CustFile;
                    ltlempID.Text = custinfo.C_NO;


                }
            }
        }

        /// <summary>
        /// 获取发运统计
        /// </summary>
        private void GetList()
        {
            string ckkssj = cbx_ck_dt.Checked == true ? txtckkssj.Value : "";
            string ckjssj = cbx_ck_dt.Checked == true ? txtckjssj.Value : "";

            DataTable dt = tmd_dispatch.GetConFYMX_Statistic_Cust2(txtcon.Text, txtcust.Text, txtfyd.Text, txtstlgrd.Text, txtspec.Text, txtbatch.Text, ckkssj, ckjssj, ltlempID.Text).Tables[0];


            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dt.DefaultView;
            Pager1.RecordCount = ps.Count;
            if (Pager1.RecordCount > 0)
            {
                dtOrderEx = dt;//导出文件

                ltlsumwgt.Text = decimal.Round(Convert.ToDecimal(dt.Compute("sum(N_WGT)", "true")),4).ToString();
                ltlsumqua.Text = dt.Rows.Count.ToString();

                ps.AllowPaging = true;
                ps.PageSize = Pager1.PageSize;
                ps.CurrentPageIndex = Pager1.CurrentPageIndex - 1;

                rptList.DataSource = ps;
                rptList.DataBind();

            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                ltlsumwgt.Text = "";
                ltlsumqua.Text = "";
            }
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetList();
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
                dic.Add("C_LIC_PLA_NO", "车牌号");
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_STOVE", "炉号");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("N_WGT", "重量*");
                dic.Add("D_CKSJ2", "发货时间");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_MAT_DESC", "物料名称");
                dic.Add("C_CON_NO", "合同号");
                dic.Add("C_CUST_NAME", "客户");

                ExportHelper.BudgetExport(dtOrderEx, dic, "合同发运执行明细表", Response);
                dtOrderEx = null;
            }
        }
    }
}