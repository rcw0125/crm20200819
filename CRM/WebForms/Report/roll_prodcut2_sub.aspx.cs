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
using NF.Framework;

namespace CRM.WebForms.Report
{
    public partial class roll_prodcut2_sub : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMC_ROLL_DEPLOY_LOG tmc_roll_deploy_log = new Bll_TMC_ROLL_DEPLOY_LOG();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    ltlbatch.Text = Request.QueryString["batch"];
                    ltlmatcode.Text = Request.QueryString["matcode"];
                    ltlarea.Text = Request.QueryString["area"];
                    ltllev.Text = Request.QueryString["lev"];

                    BindInfo();
                    BindList();
                    ltlempid.Text = vUser.Id;
                    ltlempname.Text = vUser.Name;

                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }


        private void BindInfo()
        {
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
        }

        private void BindList()
        {

            DataTable dt = trc_roll_prodcut.GetRollProdcut2(ltlbatch.Text, "", "", "", ltlmatcode.Text, ltllev.Text, ltlarea.Text, "", "", "","","").Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
            }
            else
            {
                ltlsumwgt.Text = "";
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }


        protected void btn_xc_Click(object sender, EventArgs e)
        {
            BindList();
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
                    Literal ltlN_WGT = (Literal)rptList.Items[i].FindControl("ltlN_WGT");//重量
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
                      
                        #region//参数
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
                        mod.C_STD_CODE = ltlstdcode.Text;
                        mod.C_JUDGE_LEV = ltllev.Text;
                        mod.C_PACK = ltlpack.Text;
                        list.Add(mod);
                        #endregion
                    }
                }

                #region //在途量/库存量
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
                #endregion

                #region //执行调配资源
                kfwgt = kcwgt - ztwgt;

                if (tpwgt <= kfwgt)
                {
                    if (list.Count > 0)
                    {
                        if (tmc_roll_deploy_log.InsertRoll_Proc2(list))
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
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配资源，存在发运单占用其中资源');</script>", false);
                }
                #endregion
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('"+ex.Message+"');</script>", false);
            }
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}