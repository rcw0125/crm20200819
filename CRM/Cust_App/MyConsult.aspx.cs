using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NF.BLL;
using System.Data;
using NF.Framework;

namespace CRM.Cust_App
{
    public partial class MyConsult : System.Web.UI.Page
    {
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                   
                    //初始化时间
                    DateTime dt = DateTime.Now;
                    Start.Value = dt.AddDays(-(dt.Day) + 1).ToString("yyy-MM-dd");
                    End.Value = dt.AddMonths(1).AddDays(-(dt.Day)).ToString("yyy-MM-dd");

                    ltlUserID.Text = BaseUser.Id;
                    GetQuestion();
                    ByPageBind();

                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        /// <summary>
        /// 获取技术问题
        /// </summary>
        private void GetQuestion()
        {
            DataTable dt = tmc_question.GetQuestionList("").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropQuest.DataSource = dt;
                dropQuest.DataTextField = "C_NAME";
                dropQuest.DataValueField = "C_ID";
                dropQuest.DataBind();
                dropQuest.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                dropQuest.DataSource = null;
                dropQuest.DataBind();
                dropQuest.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        /// <summary>
        /// 分页绑定
        /// </summary>

        private void ByPageBind()
        {
            Pager1.RecordCount = tmc_tech_consult.GetRecordCount(dropQuest.SelectedValue,ltlUserID.Text , Start.Value, End.Value);
            if (Pager1.RecordCount > 0)
            {
                GetListBind();
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        private void GetListBind()
        {
            rptList.DataSource = tmc_tech_consult.GetListByPage(Pager1.PageSize, Pager1.CurrentPageIndex, dropQuest.SelectedValue,ltlUserID.Text, Start.Value, End.Value);
            rptList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ByPageBind();
        }

        protected void Pager1_PageChanged(object sender, EventArgs e)
        {
            GetListBind();
        }
    }
}