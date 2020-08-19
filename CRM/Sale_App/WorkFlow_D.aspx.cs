using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NF.MODEL;
using NF.BLL;


namespace CRM.Sale_App
{
    public partial class WorkFlow_D : System.Web.UI.Page
    {
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWINFO flowinfo = new Bll_TMB_FLOWINFO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlEmpID.Text = BaseUser.Id;

                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");
                    GetFlow();

                    GetWork();
                }
            }
        }


        /// <summary>
        /// 获取流程
        /// </summary>
        private void GetFlow()
        {
            DataTable dt = flowinfo.GetFlowList().Tables[0];
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


        /// <summary>
        /// 获取未处理事务
        /// </summary>
        private void GetWork()
        {
            DataTable dt = fileinfo.GetUntrWork(dropFlow.SelectedValue, ltlEmpID.Text, txtTitle.Text, Start.Value, End.Value).Tables[0];
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
        /// <param name="taskID"></param>
        /// <returns></returns>
        public static string GetUrl(object type, object flieID, object taskID, object flowID, object stepID)
        {
            string result = "";
            switch (Convert.ToInt32(type))
            {
                case 0://合同
                    result = "Con_CheckList.aspx?ID=" + flieID.ToString() + "&task=" + taskID.ToString() + "&flow=" + flowID + "&step=" + stepID + "&flag=0";
                    break;
                case 1://质量
                    result = "Quality_CheckList.aspx?ID=" + flieID.ToString() + "&task=" + taskID.ToString() + "&flow=" + flowID + "&step=" + stepID + "&flag=0";
                    break;
            }
            return result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetWork();
        }
    }
}