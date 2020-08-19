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
using Aspose.Cells;
using CRM.Common;

namespace CRM.WebForms.Report
{


    public partial class roll_prodcut_gp : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMC_ROLL_DEPLOY_LOG tmc_roll_deploy_log = new Bll_TMC_ROLL_DEPLOY_LOG();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();


        private static DataTable dtOrderEx = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtkssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                txtjssj.Value = DateTime.Now.ToString("yyy-MM-dd");
                BindInfo();
            }
        }

        #region //基础数据
        private void BindInfo()
        {

            #region //特殊信息
            DataTable dtts = tmo_order.GetTS().Tables[0];
            if (dtts.Rows.Count > 0)
            {
                droptsxx.DataSource = dtts;
                droptsxx.DataTextField = "C_PCINFO";
                droptsxx.DataValueField = "C_PCINFO";
                droptsxx.DataBind();
                droptsxx.Items.Insert(0, new ListItem("全部", ""));
            }
            #endregion

            #region //销售区域

            DataTable dt = ts_dic.GetDicArea("-1").Tables[0];

            if (dt.Rows.Count > 0)
            {
                dropsalearea.DataSource = dt;
                dropsalearea.DataTextField = "C_DETAILNAME";
                dropsalearea.DataValueField = "C_DETAILNAME";
                dropsalearea.DataBind();
                dropsalearea.Items.Insert(0, new ListItem("全部", "-1"));//
            }
            else
            {
                dropsalearea.DataSource = null;
                dropsalearea.DataBind();
            }

            dropMinArea.Items.Insert(0, new ListItem("全部", ""));
            #endregion

            #region //质量
            DataTable dtzl = tqb_checkstate.GetCheckState("线材").Tables[0];
            if (dtzl.Rows.Count > 0)
            {
                dropzldj.DataSource = dtzl;
                dropzldj.DataTextField = "C_CHECKSTATE_NAME";
                dropzldj.DataValueField = "C_CHECKSTATE_NAME";
                dropzldj.DataBind();
                dropzldj.Items.Insert(0, new ListItem("全部", ""));
            }
            #endregion
        }



        #endregion

        private void BindList()
        {

            string kssj = cbx_dt.Checked == true ? txtkssj.Value : "";
            string jssj = cbx_dt.Checked == true ? txtjssj.Value : "";

            DataTable dt = trc_roll_prodcut.GetRollProdcut_GP(txtbatchno.Text, txtckcode.Text, txtstlgrd.Text, txtspec.Text, txtmatcode.Text, dropzldj.SelectedItem.Value, dropsalearea.SelectedItem.Value, dropMinArea.SelectedItem.Value, txtcustname.Text, droptsxx.SelectedItem.Value, dropflag.SelectedItem.Value, kssj, jssj).Tables[0];
            if (dt.Rows.Count > 0)
            {

                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlcount.Text = dt.Compute("sum(JIANSHU)", "true").ToString();
                ltlsum_kjwgt.Text = dt.Compute("sum(N_WGT)", "C_FLAG='Y'").ToString();

                dtOrderEx = dt;


            }
            else
            {
                ltlsumwgt.Text = "";
                ltlcount.Text = "";
                ltlsum_kjwgt.Text = "";
                rptList.DataSource = null;
                rptList.DataBind();

            }
        }

        protected void btn_xc_Click(object sender, EventArgs e)
        {
            BindList();

            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }

        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_LINEWH_CODE", "仓库");
                dic.Add("C_SALE_AREA", "销售区域");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("C_JUDGE_LEV_ZH", "质量等级");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_ZYX1", "自由项1");
                dic.Add("C_ZYX2", "自由项2");
                dic.Add("C_BZYQ", "包装要求");
                dic.Add("C_PCINFO", "特殊信息");                
                dic.Add("JIANSHU", "件数*");
                dic.Add("N_WGT", "吨数*");
                dic.Add("D_PRODUCE_DATE", "生产日期");
                dic.Add("D_QR_DATE", "终判时间");
                dic.Add("PD_TIME", "判定耗时");
                dic.Add("N_DAY", "库龄*");
                dic.Add("SF_CQ", "是否超期");
                dic.Add("C_FLAG", "是否监控");
                dic.Add("C_CUST_NAME", "客户信息");
                dic.Add("C_MAT_DESC", "物料名称");
                ExportHelper.BudgetExport(dtOrderEx, dic, "线材仓库", Response);
                dtOrderEx = null;
            }
        }

        //质量
        protected void dropzldj_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropsalearea.Items.Clear();
            dropMinArea.Items.Clear();

            #region //线材库区域

            if (!string.IsNullOrEmpty(dropzldj.SelectedItem.Value))
            {
                DataTable dtxcarea = tmo_order.GetXCAREA(dropzldj.SelectedItem.Value).Tables[0];
                if (dtxcarea.Rows.Count > 0)
                {
                    dropsalearea.DataSource = dtxcarea;
                    dropsalearea.DataTextField = "C_SALE_AREA";
                    dropsalearea.DataValueField = "C_SALE_AREA";
                    dropsalearea.DataBind();
                    dropsalearea.Items.Insert(0, new ListItem("全部", "-1"));//
                }
                else
                {
                    dropsalearea.DataSource = null;
                    dropsalearea.DataBind();

                }
            }
            else
            {
                #region //销售区域

                DataTable dt = ts_dic.GetDicArea("-1").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dropsalearea.DataSource = dt;
                    dropsalearea.DataTextField = "C_DETAILNAME";
                    dropsalearea.DataValueField = "C_DETAILCODE";
                    dropsalearea.DataBind();
                    dropsalearea.Items.Insert(0, new ListItem("全部", "-1"));//
                }
                else
                {
                    dropsalearea.DataSource = null;
                    dropsalearea.DataBind();
                }


                #endregion
            }


            #endregion

            dropMinArea.Items.Insert(0, new ListItem("全部", ""));
        }

        protected void dropsalearea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMinArea(dropsalearea.SelectedValue);
        }

        private void GetMinArea(string area)
        {
            dropMinArea.Items.Clear();
            DataTable dt = ts_dic.GetDicArea(area).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropMinArea.DataSource = dt;
                dropMinArea.DataTextField = "C_DETAILNAME";
                dropMinArea.DataValueField = "C_DETAILNAME";
                dropMinArea.DataBind();
                dropMinArea.Items.Insert(0, new ListItem("全部", ""));//
            }
            else
            {
                dropMinArea.DataSource = null;
                dropMinArea.DataBind();
                dropMinArea.Items.Insert(0, new ListItem("全部", ""));//

            }
        }
    }
}