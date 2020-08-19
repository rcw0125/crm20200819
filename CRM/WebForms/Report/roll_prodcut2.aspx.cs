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
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class roll_prodcut2 : System.Web.UI.Page
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

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    BindInfo();
                    ltlempid.Text = vUser.Id;
                    ltlempname.Text = vUser.Name;
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        #region //基础数据
        private void BindInfo()
        {
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

            #region //线材库区域
            DataTable dtxcarea = tmo_order.GetXCAREA("").Tables[0];
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
            #endregion

            #region //需求区域

            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropneedarea.DataSource = dt;
                dropneedarea.DataTextField = "C_DETAILNAME";
                dropneedarea.DataValueField = "C_DETAILNAME";
                dropneedarea.DataBind();
                dropneedarea.Items.Add(new ListItem("空白", ""));
            }
            else
            {

                dropneedarea.DataSource = null;
                dropneedarea.DataBind();
            }
            #endregion


        }



        #endregion

        private void BindList()
        {

            string kssj = cbx_dt.Checked == true ? txtkssj.Value : "";
            string jssj = cbx_dt.Checked == true ? txtjssj.Value : "";

            DataTable dt = trc_roll_prodcut.GetRollProdcut(txtbatchno.Text, "", txtstlgrd.Text, txtspec.Text, txtmatcode.Text, dropzldj.SelectedItem.Value, dropsalearea.SelectedItem.Value, txtcustname.Text, droptsxx.SelectedItem.Value, dropflag.SelectedItem.Value, kssj, jssj, txtconno.Text, dropgp.SelectedValue == "全部改判/超订单" ? "" : dropgp.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {

                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlsumqua.Text = dt.Compute("sum(JIANSHU)", "true").ToString();

                dtOrderEx = dt;

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            else
            {
                ltlsumwgt.Text = "";
                ltlsumqua.Text = "";
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }


        protected void btn_xc_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_BATCH_NO", "批次号");
                dic.Add("C_LINEWH_CODE", "仓库");
                dic.Add("C_STL_GRD", "钢种");
                dic.Add("C_SPEC", "规格");
                dic.Add("D_PRODUCE_DATE", "生产日期");
                dic.Add("C_JUDGE_LEV_ZH", "质量等级");
                dic.Add("jianshu", "件数*");
                dic.Add("N_WGT", "重量*");
                dic.Add("C_SALE_AREA", "销售区域");
                dic.Add("C_PCINFO", "特殊信息");
                dic.Add("C_MAT_DESC", "物料名称");
                dic.Add("C_MAT_CODE", "物料编码");
                dic.Add("C_STD_CODE", "执行标准");
                dic.Add("C_ZYX1", "自由项1");
                dic.Add("C_ZYX2", "自由项2");
                dic.Add("C_BZYQ", "包装要求");
                dic.Add("C_CUST_NAME", "客户信息");
                dic.Add("C_CON_NO", "合同号");
                dic.Add("C_ORDER_NO", "订单号");
                dic.Add("计划需求量", "计划需求量");
                dic.Add("完工数量", "完工数量");
                dic.Add("计划日期", "计划日期");
                dic.Add("需求日期", "需求日期");
                ExportHelper.BudgetExport(dtOrderEx, dic, "资源分配", Response);
                dtOrderEx = null;
            }
        }


        //修改资源区域
        protected void btnedit_Click(object sender, EventArgs e)
        {
            try
            {

                #region //初始化DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("matCode", typeof(string));//物料编码
                dt.Columns.Add("stdCode", typeof(string));//执行标准
                dt.Columns.Add("area", typeof(string));//区域
                dt.Columns.Add("pack", typeof(string));//包装
                dt.Columns.Add("lev", typeof(string));//等级
                #endregion

                decimal ztwgt = 0;//在途量
                decimal kcwgt = 0;//库存量
                decimal tpwgt = 0;//调配量
                decimal kfwgt = 0;//可发量

                List<Mod_TMC_ROLL_DEPLOY_LOG> list = new List<Mod_TMC_ROLL_DEPLOY_LOG>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxselect = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxselect");
                    Literal ltlbatch = (Literal)rptList.Items[i].FindControl("ltlbatch");//批次号
                    Literal ltlmatcode = (Literal)rptList.Items[i].FindControl("ltlmatcode");//物料编码
                    Literal ltlstlgrd = (Literal)rptList.Items[i].FindControl("ltlstlgrd");//钢种
                    Literal ltlspec = (Literal)rptList.Items[i].FindControl("ltlspec");//规格
                    Literal ltlsalearea = (Literal)rptList.Items[i].FindControl("ltlsalearea");//销售区域
                    Literal ltlstdcode = (Literal)rptList.Items[i].FindControl("ltlstdcode");//执行标准
                    Literal ltlpack = (Literal)rptList.Items[i].FindControl("ltlpack");//包装要求
                    Literal ltllev = (Literal)rptList.Items[i].FindControl("ltllev");//质量等级
                    Literal ltllev_bp = (Literal)rptList.Items[i].FindControl("ltllev_bp");//表判等级
                    Literal ltlN_WGT = (Literal)rptList.Items[i].FindControl("ltlN_WGT");//重量
                    Literal ltlC_IS_QR = (Literal)rptList.Items[i].FindControl("ltlC_IS_QR");//是否确认
                    Literal ltlqua = (Literal)rptList.Items[i].FindControl("ltlqua");//件数
                    if (cbxselect.Checked)
                    {

                        if (!string.IsNullOrEmpty(ltlN_WGT.Text))
                        {
                            tpwgt += Convert.ToDecimal(ltlN_WGT.Text);//合计调配量
                        }

                        DataRow[] dr = dt.Select("matCode='" + ltlmatcode.Text + "' and stdCode='" + ltlstdcode.Text + "' and area='" + ltlsalearea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "'");
                        if (dr.Length <= 0)
                        {
                            dt.Rows.Add(new object[] { ltlmatcode.Text, ltlstdcode.Text, ltlsalearea.Text, ltlpack.Text, ltllev.Text });
                        }

                        #region 参数
                        Mod_TMC_ROLL_DEPLOY_LOG mod = new Mod_TMC_ROLL_DEPLOY_LOG();
                        mod.C_ROLL_PROCID = cbxselect.Value;
                        mod.C_BATCH_NO = ltlbatch.Text;
                        mod.C_MAT_CODE = ltlmatcode.Text;
                        mod.C_STL_GRD = ltlstlgrd.Text;
                        mod.C_SPEC = ltlspec.Text;
                        mod.C_OLDAREA = ltlsalearea.Text;
                        mod.C_NEWAREA = dropneedarea.SelectedItem.Value;
                        mod.C_EMPID = ltlempid.Text;
                        mod.C_EMPNAME = ltlempname.Text;
                        mod.C_QUA = ltlqua.Text;
                        mod.C_JUDGE_LEV_BP = ltllev_bp.Text;
                        mod.C_STD_CODE = ltlstdcode.Text;
                        mod.C_JUDGE_LEV = ltllev.Text;
                        mod.C_PACK = ltlpack.Text;
                        list.Add(mod);
                        #endregion
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable dtfyzt = tmo_order.ZTWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()).Tables[0];
                        if (dtfyzt.Rows.Count > 0)//在途量
                        {
                            ztwgt += Convert.ToDecimal(dtfyzt.Compute("sum(N_FYWGT)", "true"));//合计在途量

                        }
                        DataTable dtkc = tmo_order.KCWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString()).Tables[0];
                        if (dtkc.Rows.Count > 0)//库存量
                        {
                            if (!string.IsNullOrEmpty(dtkc.Rows[0]["N_WGT"].ToString()))
                            {
                                kcwgt += Convert.ToDecimal(dtkc.Rows[0]["N_WGT"]);//合计在途量
                            }
                        }
                    }


                }

                #region //执行调配资源

                kfwgt = kcwgt - ztwgt;//可调配量

                if (tpwgt <= kfwgt)
                {
                    if (list.Count > 0)
                    {
                        if (tmc_roll_deploy_log.InsertRoll_Proc(list))
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配成功');</script>", false);
                            BindList();
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配失败');</script>", false);
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配资源量，存在发运单占用其中资源');</script>", false);
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);

            }
        }

        //质量
        protected void dropzldj_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region //线材库区域
            dropsalearea.Items.Clear();
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
                dropsalearea.Items.Insert(0, new ListItem("全部", "-1"));//

            }
            #endregion
        }

    }
}