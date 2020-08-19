using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.Unity;
using System.Data;
using NF.BLL;
using NF.MODEL;
using Aspose.Cells;
using CRM.Common;
using NF.Framework;
using NF.Bussiness.Interface;
using NF.Web.Core;
using NF.EF.Model;

namespace CRM.WebForms.Report
{
    public partial class roll_prodcut3 : System.Web.UI.Page
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMC_ROLL_DEPLOY_LOG tmc_roll_deploy_log = new Bll_TMC_ROLL_DEPLOY_LOG();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TS_USER ts_user = new Bll_TS_USER();


        private static DataTable dtOrderEx = new DataTable();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //获取用户所属公司名称
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser != null)
                {
                    GetFun();//加载按钮权限

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

        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Report/roll_prodcut3.aspx", user, Session);
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

            #region //线材库区域

            DataTable dtxcarea = tmo_order.GetXCAREA().Tables[0];
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

            DataTable dt = trc_roll_prodcut.GetRollProdcut2(txtbatchno.Text, "", txtstlgrd.Text, txtspec.Text, txtmatcode.Text, dropzldj.SelectedItem.Value, dropsalearea.SelectedItem.Value, txtcustname.Text, droptsxx.SelectedItem.Value, dropflag.SelectedValue == "全部" ? "" : dropflag.SelectedValue, txtcon.Text,txtrow.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {

                rptList.DataSource = dt;
                rptList.DataBind();

                ltlsumwgt.Text = dt.Compute("sum(N_WGT)", "true").ToString();
                ltlsumqua.Text = dt.Rows.Count.ToString();

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

                int jianshu = 0;

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
                        jianshu += 1;


                        if (!string.IsNullOrEmpty(ltlN_WGT.Text))
                        {
                            tpwgt += Convert.ToDecimal(ltlN_WGT.Text);//合计调配量
                        }

                        DataRow[] dr = dt.Select("matCode='" + ltlmatcode.Text + "' and stdCode='" + ltlstdcode.Text + "' and area='" + ltlsalearea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "'");
                        if (dr.Length <= 0)
                        {
                            dt.Rows.Add(new object[] { ltlmatcode.Text, ltlstdcode.Text, ltlsalearea.Text, ltlpack.Text, ltllev.Text });
                        }

                        #region //参数
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
                                kcwgt += Convert.ToDecimal(dtkc.Rows[0]["N_WGT"]);//合计库存量
                            }
                        }
                    }
                }
                #endregion

                #region //执行调配资源
                kfwgt = kcwgt - ztwgt;

                if (jianshu > 10)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('已超出调配卷数范围！');</script>", false);
                }
                else
                {
                    if (tpwgt <= kfwgt)
                    {
                        if (list.Count > 0)
                        {
                            if (tmc_roll_deploy_log.InsertRoll_Proc2(list))
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配成功');</script>", false);
                                BindList();
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
                }
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
            #endregion

        }
        //批量单卷修改
        protected void btneditAll_Click(object sender, EventArgs e)
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


                    #region //参数
                    Mod_TMC_ROLL_DEPLOY_LOG mod = new Mod_TMC_ROLL_DEPLOY_LOG();
                    mod.C_ROLL_PROCID = cbxselect.Value;
                    mod.C_BATCH_NO = ltlbatch.Text;
                    mod.C_MAT_CODE = ltlmatcode.Text;
                    mod.C_STL_GRD = ltlstlgrd.Text;
                    mod.C_SPEC = ltlspec.Text;
                    mod.C_OLDAREA = ltlsalearea.Text;
                    mod.C_NEWAREA = dropneedarea.SelectedItem.Text;
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


        //D质量副产品销售部区域调配
        protected void btnD_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmc_roll_deploy_log.Update_D_Roll_Proc())
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配成功');</script>", false);
                    BindList();
                }
            }
            catch (Exception ex)
            {

                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('" + ex.Message + "');</script>", false);
            }
        }

        //客户调配
        protected void btneditCust_Click(object sender, EventArgs e)
        {
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            string dept = ts_user.GetDept(vUser.Account);



            bool result = true;//判断当前发运数量已超出可发运量

            bool result2 = true;//调配区域是否一致

            string stlgrd = string.Empty;

            #region //初始化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("matCode", typeof(string));//物料编码
            dt.Columns.Add("stdCode", typeof(string));//执行标准
            dt.Columns.Add("area", typeof(string));//区域
            dt.Columns.Add("pack", typeof(string));//包装
            dt.Columns.Add("lev", typeof(string));//等级
            dt.Columns.Add("custname", typeof(string));//客户
            dt.Columns.Add("conno", typeof(string));//合同号
            dt.Columns.Add("stlgrd", typeof(string));//钢种
            dt.Columns.Add("wgt", typeof(string));//重量
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
                Literal ltlC_CUST_NAME = (Literal)rptList.Items[i].FindControl("ltlC_CUST_NAME");//客户信息
                Literal ltlC_CON_NO = (Literal)rptList.Items[i].FindControl("ltlC_CON_NO");//合同号
                if (cbxselect.Checked)
                {
                    //if (ltlsalearea.Text != dept)
                    //{
                    //    result = false;
                    //    break;
                    //}

                    DataRow[] dr = dt.Select("matCode='" + ltlmatcode.Text + "' and stdCode='" + ltlstdcode.Text + "' and area='" + ltlsalearea.Text + "' and pack='" + ltlpack.Text + "' and lev='" + ltllev.Text + "' and custname='" + ltlC_CUST_NAME.Text + "' and conno='" + ltlC_CON_NO.Text + "'");
                    if (dr.Length <= 0)
                    {
                        dt.Rows.Add(new object[] { ltlmatcode.Text, ltlstdcode.Text, ltlsalearea.Text, ltlpack.Text, ltllev.Text, ltlC_CUST_NAME.Text, ltlC_CON_NO.Text, ltlstlgrd.Text, ltlN_WGT.Text });
                    }
                    else
                    {
                        foreach (var item in dr)
                        {
                            item["wgt"] = Convert.ToString(Convert.ToDecimal(item["wgt"]) + Convert.ToDecimal(ltlN_WGT.Text));
                        }
                    }

                    #region //参数
                    Mod_TMC_ROLL_DEPLOY_LOG mod = new Mod_TMC_ROLL_DEPLOY_LOG();
                    mod.C_ROLL_PROCID = cbxselect.Value;
                    mod.C_BATCH_NO = ltlbatch.Text;
                    mod.C_MAT_CODE = ltlmatcode.Text;
                    mod.C_STL_GRD = ltlstlgrd.Text;
                    mod.C_SPEC = ltlspec.Text;
                    mod.C_OLDAREA = ltlsalearea.Text;
                    mod.C_NEWAREA = dropneedarea.SelectedValue;
                    mod.C_OLDCUST = ltlC_CUST_NAME.Text;
                    mod.C_NEWCUST = txtC_CGC.Value.Trim();

                    mod.C_OLDCON = ltlC_CON_NO.Text;//原资源合同
                    mod.C_NEWCON = txtNeedCon.Text.Trim() == "" ? ltlC_CON_NO.Text : txtNeedCon.Text.Trim();//需求合同

                    mod.C_EMPID = ltlempid.Text;
                    mod.C_EMPNAME = ltlempname.Text;
                    mod.C_STD_CODE = ltlstdcode.Text;
                    mod.C_JUDGE_LEV = ltllev.Text;
                    mod.C_PACK = ltlpack.Text;
                    list.Add(mod);
                    #endregion
                }
            }

            if (result2)
            {
                #region //在途量/库存量
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        tpwgt = Convert.ToDecimal(dt.Rows[i]["wgt"]);

                        DataTable dtfyzt = tmo_order.ZTWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString(), dt.Rows[i]["custname"].ToString(), dt.Rows[i]["conno"].ToString()).Tables[0];
                        if (dtfyzt.Rows.Count > 0)//在途量
                        {
                            ztwgt = Convert.ToDecimal(dtfyzt.Compute("sum(N_FYWGT)", "true"));//合计在途量

                        }
                        DataTable dtkc = tmo_order.KCWGT(dt.Rows[i]["matCode"].ToString(), dt.Rows[i]["stdCode"].ToString(), dt.Rows[i]["area"].ToString(), dt.Rows[i]["pack"].ToString(), dt.Rows[i]["lev"].ToString(), dt.Rows[i]["custname"].ToString(), dt.Rows[i]["conno"].ToString()).Tables[0];
                        if (dtkc.Rows.Count > 0)//库存量
                        {
                            if (!string.IsNullOrEmpty(dtkc.Rows[0]["N_WGT"].ToString()))
                            {
                                kcwgt = Convert.ToDecimal(dtkc.Rows[0]["N_WGT"]);//合计在途量
                            }
                        }
                        kfwgt = kcwgt - ztwgt;
                        if (tpwgt > kfwgt)
                        {
                            result = false;
                            break;
                        }

                    }
                }
                #endregion

                #region //执行调配资源

                if (dropflag.SelectedValue == "Y")//已判执行
                {

                    if (result)//判断当前发运数量已超出可发运量
                    {
                        if (list.Count > 0)
                        {
                            if (tmc_roll_deploy_log.InsertRoll_Proc3(list))
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配成功');</script>", false);
                                BindList();
                            }
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配资源，存在发运单占用其中客户资源');</script>", false);
                    }
                }
                else
                {
                    #region//待判执行
                    if (list.Count > 0)
                    {
                        if (tmc_roll_deploy_log.InsertRoll_Proc3(list))
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('调配成功');</script>", false);
                            BindList();
                        }
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> close();</script>", false);
                    }
                    #endregion

                }
                #endregion
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script language='javascript'> _closemsg('其中资源涉及跨区调配，请重新选择！');</script>", false);
            }
        }
    }
}