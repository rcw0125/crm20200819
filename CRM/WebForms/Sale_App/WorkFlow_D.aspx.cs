using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NF.MODEL;
using NF.BLL;
using NF.Framework;

namespace CRM.Sale_App
{
    public partial class WorkFlow_D : System.Web.UI.Page
    {
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWINFO flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    try
                    {
                        ltlEmpID.Text = BaseUser.Id;

                        txtStart.Text = DateTime.Now.AddDays(-1).ToString("yyy-MM-dd");
                        txtEnd.Text = DateTime.Now.ToString("yyy-MM-dd");
                        GetFlow();

                        GetWork();
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 获取流程
        /// </summary>
        private void GetFlow()
        {
            DataTable dt = flowinfo.GetFlowList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropFlow.DataSource = dt;
                dropFlow.DataTextField = "C_NAME";
                dropFlow.DataValueField = "C_ID";
                dropFlow.DataBind();
                dropFlow.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropFlow.DataSource = null;
                dropFlow.DataBind();
                dropFlow.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        public string GetRole(object stepID)
        {
            string str = "";
            if (!string.IsNullOrEmpty(stepID.ToString()))
            {
                Mod_TS_ROLE modRloe = ts_role.GetModel(stepID.ToString());
                str = modRloe.C_NAME;
            }
            return str;


        }


        /// <summary>
        /// 获取未处理事务
        /// </summary>
        private void GetWork()
        {
            string kssj = cbx_dt.Checked == true ? txtStart.Text : "";
            string jssj = cbx_dt.Checked == true ? txtEnd.Text : "";

            DataTable dt = fileinfo.GetUntrWork(dropFlow.SelectedValue, ltlEmpID.Text, txtTitle.Text, kssj, jssj).Tables[0];
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

        /// <summary>
        /// 根据类型跳转页面
        /// </summary>
        /// <param name="type"></param>
        /// <param name="flieID"></param>
        /// <returns></returns>
        public static string GetUrl(object type, object flieID)
        {
            string result = "";
            switch (Convert.ToInt32(type))
            {
                case 0://合同
                    result = "Con_CheckList.aspx?ID=" + flieID.ToString() + "&flag=0";
                    break;
                case 1://质量
                    result = "../ZL/Quality_Check.aspx?ID=" + flieID.ToString() + "&flag=0";
                    break;
                case 2://线材
                    result = "../Roll/roll_applyCheck.aspx?ID=" + flieID.ToString() + "&flag=0";
                    break;

            }
            return result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetWork();
            }
            catch (Exception ex)
            {

                WebMsg.MessageBox(ex.Message);
            }

        }
    }
}