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
using NF.Bussiness.Interface;
using NF.Web.Core;
using Microsoft.Practices.Unity;
using NF.EF.Model;
using System.Web.Services;

namespace CRM.Sale_App
{
    public partial class ConList : System.Web.UI.Page
    {

        private static Bll_TMO_CON tmo_con = new Bll_TMO_CON();
        private static Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private static Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    DateTime dt = DateTime.Now;

                    Start.Value = dt.AddMonths(-2).ToString("yyy-MM-dd");
                    End.Value = dt.ToString("yyy-MM-dd");
                    BindContractType();
                    GetListBind();
                }
                catch (Exception ex)
                {
                    WebMsg.MessageBox(ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取数字字典名称
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public string GetDic(object id)
        {
            string str;
            Mod_TS_DIC mod = ts_dic.GetModel(id.ToString());
            str = mod.C_DETAILNAME;
            return str;
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        private void BindContractType()
        {

            DataTable dt = tmo_order.GetConArea().Tables[0];
            if (dt.Rows.Count > 0)
            {

                dropType.DataSource = dt;
                dropType.DataTextField = "C_AREA";
                dropType.DataValueField = "C_AREA";
                dropType.DataBind();
                dropType.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropType.DataSource = null;
                dropType.DataBind();
            }
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {
            DataTable dt = tmo_con.GetListByPage3(txtCon.Value, txtConName.Value, Start.Value, End.Value, dropType.SelectedItem.Value, dropState.SelectedItem.Value == "全部" ? "" : dropState.SelectedItem.Value,txtcustname.Value,txtcustcode.Value).Tables[0];

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

                //ltl_sum.Text= dt.Compute("sum(N_WGT)", "true").ToString();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
                //ltl_sum.Text = "";
            }
        }

        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetListBind();
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
           
        }

        /// <summary>
        /// 获取流程
        /// </summary>
        /// <returns></returns>
        public static string GetFlow(object id)
        {
            string result = "";
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                Mod_TMB_FLOWINFO mod = tmb_flowinfo.GetModel(id.ToString());
                result = mod.C_NAME;
            }
            return result;
        }

        //分页
        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }
    }
}