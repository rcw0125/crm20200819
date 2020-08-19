using CRM.Common;
using NF.BLL;
using NF.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM.WebForms.PCI
{
    public partial class XCKCX : System.Web.UI.Page
    {
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private static DataTable dtOrderEx = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    try
                    {
                        DataTable dtzl = tqb_checkstate.GetCheckState("线材").Tables[0];
                        if (dtzl.Rows.Count > 0)
                        {
                            ddlzldj.DataSource = dtzl;
                            ddlzldj.DataTextField = "C_CHECKSTATE_NAME";
                            ddlzldj.DataValueField = "C_CHECKSTATE_NAME";
                            ddlzldj.DataBind();
                            ddlzldj.Items.Insert(0, new ListItem("全部", ""));
                        }
                        // InitCK();
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
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_LINEWH_CODE", "仓库");
                dic.Add("C_LINEWH_AREA_CODE", "区域");
                dic.Add("C_LINEWH_LOC_CODE", "库位");
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_BARCODE", "单卷号");
                dic.Add("C_TICK_NO", "钩号");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_MAT_DESC", "物料名称");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_JUDGE_LEV_ZH", "质量等级");
                dic.Add("C_ZYX1", "自由项1");
                dic.Add("C_ZYX2", "自由项2");
                dic.Add("C_BZYQ", "包装要求");
                dic.Add("C_MOVE_TYPE", "库存状态");
                dic.Add("C_SALE_AREA", "销售区域");
                dic.Add("D_PRODUCE_DATE", "生产日期");
                dic.Add("N_WGT", "卷重");
                ExportHelper.BudgetExport(dtOrderEx, dic, "线材库存", Response);
                dtOrderEx = null;
            }
        }


        protected void btn_xc_Click(object sender, EventArgs e)
        {
            BindList();
        }
        private void BindList()
        {
            try
            {
                DataTable dt = trc_roll_prodcut.GetXCKList(txtckcode.Text.Trim(), txtkwcode.Text.Trim(), txtstlgrd.Text.Trim(), txtbz.Text.Trim(), txtbatchno.Text.Trim(), txtbarcode.Text.Trim(), ddlsfdp.SelectedValue, ddlzldj.SelectedValue, txtBegTime.Text, txtEndTime.Text, txtqy.Text.Trim(), ddlkczt.SelectedValue, txtGG.Text.Trim()).Tables[0];
                dtOrderEx = dt;
                if (dt.Rows.Count > 0)
                {
                    rptSL.Text = dt.Compute("sum(N_NUM)", "true").ToString();
                    rptZL.Text = Math.Round(Convert.ToDouble(dt.Compute("sum(N_WGT)", "true")), 6).ToString();
                }
                else
                {
                    rptSL.Text = "";
                    rptZL.Text = "";
                }
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
                }
                else
                {
                    rptList.DataSource = null;
                    rptList.DataBind();
                }

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}