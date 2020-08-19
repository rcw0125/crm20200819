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
using CRM.Common;
using NF.EF.Model;
using NF.Bussiness.Interface;
using Microsoft.Practices.Unity;
using NF.Web.Core;

namespace CRM.WebForms.Report
{
    public partial class FYZB_DAY : System.Web.UI.Page
    {
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        private static DataTable dtOrderEx = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetFun();//加载按钮权限

                txtDate.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
        }

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Report/FYZB_DAY.aspx", user, Session);
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

        private void GetList()
        {
            string zzb = txtzzb.Text == "" ? "0" : txtzzb.Text;
            string jkzb = txtjkzb.Text == "" ? "0" : txtjkzb.Text;
            string cqzb = txtcqzb.Text == "" ? "0" : txtcqzb.Text;

            DataTable dt = tmd_dispatch.GetFyZbDay(txtDate.Value, zzb, jkzb, cqzb);
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumzkc.Text = dt.Compute("sum(N_ZKWGT)", "true").ToString();
                ltlsumjkkc.Text = dt.Compute("sum(N_JKWGT)", "true").ToString();
                ltlsumcqkc.Text = dt.Compute("sum(N_CQWGT)", "true").ToString();
                ltlsumzzb.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlsumjkzb.Text = dt.Compute("sum(N_FYJKZB)", "true").ToString();
                ltlsumcqzb.Text = dt.Compute("sum(N_FYCQZB)", "true").ToString();
                ltlsumqyfy.Text = dt.Compute("sum(N_QYFY)", "true").ToString();
                ltlsumqyfy_jk.Text = dt.Compute("sum(N_QYJKFY)", "true").ToString();
                ltlsumhyfy.Text = dt.Compute("sum(N_HYFY)", "true").ToString();
                ltlsumhyfy_jk.Text = dt.Compute("sum(N_HYJKFY)", "true").ToString();
                ltlsumfy_cq.Text = dt.Compute("sum(N_CQFY)", "true").ToString();
                ltlsumfy_cz.Text = dt.Compute("sum(N_FY_CZ)", "true").ToString();
                ltlsumfyjk_cz.Text = dt.Compute("sum(N_JK_CZ)", "true").ToString();
                ltlsumdpkc.Text = dt.Compute("sum(N_DPWGT)", "true").ToString();
                ltlsumkfl.Text = dt.Compute("sum(N_KFY)", "true").ToString();

                dtOrderEx = dt;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();

                ltlsumzkc.Text = "";
                ltlsumjkkc.Text = "";
                ltlsumcqkc.Text = "";
                ltlsumzzb.Text = "";
                ltlsumjkzb.Text = "";
                ltlsumcqzb.Text = "";
                ltlsumqyfy.Text = "";
                ltlsumqyfy_jk.Text = "";
                ltlsumhyfy.Text = "";
                ltlsumhyfy_jk.Text = "";
                ltlsumfy_cq.Text = "";
                ltlsumfy_cz.Text = "";
                ltlsumfyjk_cz.Text = "";
                ltlsumdpkc.Text = "";
                ltlsumkfl.Text = "";

                dtOrderEx = null;
            }
        }
        //查询
        protected void btncx_Click(object sender, EventArgs e)
        {
            txtzzb.Text = "";
            txtjkzb.Text = "";
            txtcqzb.Text = "";

            GetList();

            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
        }

        protected void btnZbView_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtzzb.Text) && !string.IsNullOrEmpty(txtjkzb.Text) && !string.IsNullOrEmpty(txtcqzb.Text))
            {
                GetZB();
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            else
            {
                WebMsg.MessageBox("请输入指标");
            }

        }
        /// <summary>
        /// 总指标分配预览
        /// </summary>
        private void GetZB()
        {
            string zzb = txtzzb.Text == "" ? "0" : txtzzb.Text;
            string jkzb = txtjkzb.Text == "" ? "0" : txtjkzb.Text;
            string cqzb = txtcqzb.Text == "" ? "0" : txtcqzb.Text;

            DataTable dt = tmd_dispatch.GetFyZbView(txtDate.Value, zzb, jkzb, cqzb);
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumzkc.Text = dt.Compute("sum(N_ZKWGT)", "true").ToString();
                ltlsumjkkc.Text = dt.Compute("sum(N_JKWGT)", "true").ToString();
                ltlsumcqkc.Text = dt.Compute("sum(N_CQWGT)", "true").ToString();
                ltlsumzzb.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlsumjkzb.Text = dt.Compute("sum(N_FYJKZB)", "true").ToString();
                ltlsumcqzb.Text = dt.Compute("sum(N_FYCQZB)", "true").ToString();
                ltlsumqyfy.Text = dt.Compute("sum(N_QYFY)", "true").ToString();
                ltlsumqyfy_jk.Text = dt.Compute("sum(N_QYJKFY)", "true").ToString();
                ltlsumhyfy.Text = dt.Compute("sum(N_HYFY)", "true").ToString();
                ltlsumhyfy_jk.Text = dt.Compute("sum(N_HYJKFY)", "true").ToString();
                ltlsumfy_cq.Text = dt.Compute("sum(N_CQFY)", "true").ToString();
                ltlsumfy_cz.Text = dt.Compute("sum(N_FY_CZ)", "true").ToString();
                ltlsumfyjk_cz.Text = dt.Compute("sum(N_JK_CZ)", "true").ToString();

                dtOrderEx = dt;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();

                ltlsumzkc.Text = "";
                ltlsumjkkc.Text = "";
                ltlsumcqkc.Text = "";
                ltlsumzzb.Text = "";
                ltlsumjkzb.Text = "";
                ltlsumcqzb.Text = "";
                ltlsumqyfy.Text = "";
                ltlsumqyfy_jk.Text = "";
                ltlsumhyfy.Text = "";
                ltlsumhyfy_jk.Text = "";
                ltlsumfy_cq.Text = "";
                ltlsumfy_cz.Text = "";
                ltlsumfyjk_cz.Text = "";

                dtOrderEx = null;
            }
        }

        //生成发运指标日报表
        protected void btnZbAdd_Click(object sender, EventArgs e)
        {
            try
            {


                List<Mod_TMD_FYZB> list = new List<Mod_TMD_FYZB>();

                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    Literal ltlC_DEPT = (Literal)rptList.Items[i].FindControl("ltlC_DEPT");
                    Literal ltlN_ZKWGT = (Literal)rptList.Items[i].FindControl("ltlN_ZKWGT");
                    Literal ltlN_JKWGT = (Literal)rptList.Items[i].FindControl("ltlN_JKWGT");
                    Literal ltlN_CQWGT = (Literal)rptList.Items[i].FindControl("ltlN_CQWGT");
                    Literal ltlN_DPWGT = (Literal)rptList.Items[i].FindControl("ltlN_DPWGT");
                    Literal ltlN_KCZB = (Literal)rptList.Items[i].FindControl("ltlN_KCZB");
                    Literal ltlN_JKZB = (Literal)rptList.Items[i].FindControl("ltlN_JKZB");
                    Literal ltlN_CQZB = (Literal)rptList.Items[i].FindControl("ltlN_CQZB");
                    Literal ltlN_FYJKZB = (Literal)rptList.Items[i].FindControl("ltlN_FYJKZB");
                    Literal ltlN_FYCQZB = (Literal)rptList.Items[i].FindControl("ltlN_FYCQZB");
                    Literal ltlC_TYPE = (Literal)rptList.Items[i].FindControl("ltlC_TYPE");
                    HtmlInputText txtN_WGT = (HtmlInputText)rptList.Items[i].FindControl("txtN_WGT");
                    HtmlInputText txtN_QYFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_QYFY");
                    HtmlInputText txtN_QYJKFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_QYJKFY");
                    HtmlInputText txtN_HYFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_HYFY");
                    HtmlInputText txtN_HYJKFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_HYJKFY");
                    HtmlInputText txtN_CQFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_CQFY");

                    if (string.IsNullOrEmpty(cbxID.Value) && ltlC_TYPE.Text == "N")
                    {
                        Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
                        mod.C_DEPT = ltlC_DEPT.Text;
                        mod.D_DAY = Convert.ToDateTime(txtDate.Value);
                        mod.N_ZKWGT = Convert.ToDecimal(ltlN_ZKWGT.Text);
                        mod.N_JKWGT = Convert.ToDecimal(ltlN_JKWGT.Text);
                        mod.N_CQWGT = Convert.ToDecimal(ltlN_CQWGT.Text);
                        mod.N_KCZB = Convert.ToDecimal(ltlN_KCZB.Text);
                        mod.N_JKZB = Convert.ToDecimal(ltlN_JKZB.Text);
                        mod.N_CQZB = Convert.ToDecimal(ltlN_CQZB.Text);
                        mod.N_FYJKZB = Convert.ToDecimal(ltlN_FYJKZB.Text);
                        mod.N_FYCQZB = Convert.ToDecimal(ltlN_FYCQZB.Text);
                        mod.N_WGT = Convert.ToDecimal(txtN_WGT.Value);
                        mod.N_QYFY = Convert.ToDecimal(txtN_QYFY.Value);
                        mod.N_QYJKFY = Convert.ToDecimal(txtN_QYFY.Value);
                        mod.N_HYFY = Convert.ToDecimal(txtN_HYFY.Value);
                        mod.N_HYJKFY = Convert.ToDecimal(txtN_HYJKFY.Value);
                        mod.N_CQFY = Convert.ToDecimal(txtN_CQFY.Value);
                        mod.C_FLAG = "N";
                        mod.N_SORT = i;
                        mod.C_TYPE = "N";
                        mod.N_DPWGT = Convert.ToDecimal(ltlN_DPWGT.Text);
                        list.Add(mod);
                    }
                    else
                    {
                        //修改指标
                        Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
                        mod.C_ID = cbxID.Value;
                        mod.N_KCZB = Convert.ToDecimal(ltlN_KCZB.Text);
                        mod.N_JKZB = Convert.ToDecimal(ltlN_JKZB.Text);
                        mod.N_CQZB = Convert.ToDecimal(ltlN_CQZB.Text);
                        mod.N_FYJKZB = Convert.ToDecimal(ltlN_FYJKZB.Text);
                        mod.N_FYCQZB = Convert.ToDecimal(ltlN_FYCQZB.Text);
                        mod.N_WGT = Convert.ToDecimal(txtN_WGT.Value);
                        mod.C_TYPE = "Y";
                        list.Add(mod);
                    }
                }


                if (list.Count > 0)
                {
                    if (tmd_dispatch.InsertFYZB(list))
                    {
                        GetList();

                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('发运指标生成成功');</script>", false);
                    }
                }

            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }

        //区域总指标修改
        protected void btnZbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;
                List<Mod_TMD_FYZB> list = new List<Mod_TMD_FYZB>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");

                    HtmlInputText txtN_WGT = (HtmlInputText)rptList.Items[i].FindControl("txtN_WGT");

                    if (cbxID.Checked)
                    {
                        if (!string.IsNullOrEmpty(cbxID.Value))
                        {
                            Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
                            mod.N_WGT = Convert.ToDecimal(txtN_WGT.Value);
                            mod.C_ID = cbxID.Value;
                            list.Add(mod);
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
                    if (tmd_dispatch.UpdateAreaFyZb(list, 1))
                    {

                        GetList();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('修改成功');</script>", false);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('请生成发运指标日报表,再修改操作！');</script>", false);
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }
        //汽运/火运/超期发运录入
        protected void btnQyHyAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;
                List<Mod_TMD_FYZB> list = new List<Mod_TMD_FYZB>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    HtmlInputText txtN_QYFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_QYFY");
                    HtmlInputText txtN_QYJKFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_QYJKFY");
                    HtmlInputText txtN_HYFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_HYFY");
                    HtmlInputText txtN_HYJKFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_HYJKFY");
                    HtmlInputText txtN_CQFY = (HtmlInputText)rptList.Items[i].FindControl("txtN_CQFY");

                    if (cbxID.Checked)
                    {
                        if (!string.IsNullOrEmpty(cbxID.Value))
                        {
                            Mod_TMD_FYZB mod = new Mod_TMD_FYZB();
                            mod.N_QYFY = Convert.ToDecimal(txtN_QYFY.Value);
                            mod.N_QYJKFY = Convert.ToDecimal(txtN_QYJKFY.Value);
                            mod.N_HYFY = Convert.ToDecimal(txtN_HYFY.Value);
                            mod.N_HYJKFY = Convert.ToDecimal(txtN_HYJKFY.Value);
                            mod.N_CQFY = Convert.ToDecimal(txtN_CQFY.Value);
                            mod.C_ID = cbxID.Value;
                            list.Add(mod);
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
                    if (tmd_dispatch.UpdateAreaFyZb(list, 2))
                    {
                        GetList();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('录入成功');</script>", false);
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('还没有生成发运指标日报表记录,暂无录入，请联系相关负责人！');</script>", false);
                }
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }

        //控制发运
        protected void btnKzFy_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;
                List<Mod_TMD_FYZB> list = new List<Mod_TMD_FYZB>();
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HtmlInputCheckBox cbxID = (HtmlInputCheckBox)rptList.Items[i].FindControl("cbxID");
                    Literal ltlC_FLAG = (Literal)rptList.Items[i].FindControl("ltlC_FLAG");
                    if (cbxID.Checked)
                    {
                        if (!string.IsNullOrEmpty(cbxID.Value))
                        {
                            Mod_TMD_FYZB mod = new Mod_TMD_FYZB();

                            mod.C_FLAG = ltlC_FLAG.Text == "N" ? "Y" : "N";
                            mod.C_ID = cbxID.Value;
                            list.Add(mod);
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
                    if (tmd_dispatch.UpdateAreaFyZb(list, 3))
                    {
                        GetList();
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('设置成功');</script>", false);

                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('还没有生成发运指标日报表记录，请联系相关负责人！');</script>", false);
                }
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }
        //导出
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtOrderEx.Rows.Count > 0)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("C_DEPT", "区域");
                dic.Add("N_ZKWGT", "总库存*");
                dic.Add("N_JKWGT", "监控库存*");
                dic.Add("N_CQWGT", "超期库存*");
                dic.Add("N_DPWGT", "待判库存*");
                dic.Add("N_KFY", "可发运库存*");
                dic.Add("N_KCZB", "总占比*");
                dic.Add("N_JKZB", "监控占比*");
                dic.Add("N_CQZB", "超期占比*");
                dic.Add("N_WGT", "总指标*");
                dic.Add("N_FYJKZB", "监控指标*");
                dic.Add("N_FYCQZB", "超期指标*");
                dic.Add("N_QYFY", "汽运总发运量*");
                dic.Add("N_QYJKFY", "汽运监控发运*");
                dic.Add("N_HYFY", "火运总发运量*");
                dic.Add("N_HYJKFY", "火运监控发运*");
                dic.Add("N_CQFY", "超期库存发运*");
                dic.Add("N_FY_CZ", "总发运量(指标差值)*");
                dic.Add("N_JK_CZ", "监控发运(指标差值)*");
                dic.Add("C_FLAG", "是否控制发运");
                ExportHelper.BudgetExport(dtOrderEx, dic, "发运指标日报表", Response);
                dtOrderEx = null;
            }
        }
    }
}