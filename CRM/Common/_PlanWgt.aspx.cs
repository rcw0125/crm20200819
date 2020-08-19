using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.BLL;
using NF.MODEL;


namespace CRM.Common
{
    public partial class _PlanWgt : System.Web.UI.Page
    {
        private Bll_TMB_AREAPLAN tmb_areaplan = new Bll_TMB_AREAPLAN();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_STD_MAIN tqb_std_main = new Bll_TQB_STD_MAIN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInfo();

                if (!string.IsNullOrEmpty(Request.QueryString["area"]))
                {
                    ltlarea.Text = Request.QueryString["area"];
                    GetList();
                }
            }
        }
        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }

        private void GetInfo()
        {
            #region //钢种大类
            DataTable dtclass = GetData("GZCLASS");
            if (dtclass.Rows.Count > 0)
            {
                dropclass.DataSource = dtclass;
                dropclass.DataTextField = "C_DETAILNAME";
                dropclass.DataValueField = "C_DETAILNAME";
                dropclass.DataBind();
                dropclass.Items.Insert(0, new ListItem("全部", ""));
            }

            DataTable dtsubclass = tqb_std_main.GetPMList().Tables[0];
            if (dtsubclass.Rows.Count > 0)
            {
                dropsubclass.DataSource = dtsubclass;
                dropsubclass.DataTextField = "C_PROD_NAME";
                dropsubclass.DataValueField = "C_PROD_NAME";
                dropsubclass.DataBind();
                dropsubclass.Items.Insert(0, new ListItem("全部", ""));
            }

            #endregion
        }

        private void GetList()
        {
            DataTable dt = tmb_areaplan.GetPlanStlGRD(ltlarea.Text, dropclass.SelectedItem.Value, dropsfjk.SelectedItem.Value == "全部" ? "" : dropsfjk.SelectedItem.Value, dropsubclass.SelectedItem.Value).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}