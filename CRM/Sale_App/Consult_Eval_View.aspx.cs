using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using NF.BLL;
using NF.Framework;
using NF.MODEL;
using System.Web.Services;

namespace CRM.Sale_App
{
    public partial class Consult_Eval_View : System.Web.UI.Page
    {
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private static Bll_TMC_TECH_CONSULT_RESULT tmc_tech_consult_result = new Bll_TMC_TECH_CONSULT_RESULT();
        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    hidUserID.Value = BaseUser.Id;

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        ltlID.Text = Request.QueryString["ID"];

                        GetList();
                    }
                }
            }
        }

        /// <summary>
        /// 获取技术咨询数据
        /// </summary>
        private void GetList()
        {
            if (!string.IsNullOrEmpty(ltlID.Text))
            {
                Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                if (mod != null)
                {
                    Mod_TMC_QUESTION modQuestion = tmc_question.GetModel(mod.C_QUEST_ID);
                    ltlQuest.Text = modQuestion.C_NAME;
                    ltlSTL_GRD.Text = mod.C_STL_GRD;

                    ltlCust.Text = mod.C_CUST_NAME;
                    ltlUseDesc.Text = mod.C_USE_DESC;
                    ltlQuestContent.Text = mod.C_REMARK;

                    GetQuestList();

                }
            }
        }


        /// <summary>
        /// 获取技术处理结果
        /// </summary>
        private void GetQuestList()
        {
            DataTable dt = tmc_tech_consult_result.GetConsult_ResultList(ltlID.Text).Tables[0];
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
        /// 评价
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="num">分数</param>
        /// <returns></returns>
        [WebMethod]
        public static bool SetEval(string id,string num,string emp)
        {
            return tmc_tech_consult_result.UpdateXG_Eval(id, Convert.ToInt32(num), emp, DateTime.Now);
        }
        
    }
}