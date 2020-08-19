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

namespace CRM.Cust_App
{
    public partial class MyConsult_View : System.Web.UI.Page
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

                    try
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            ltlID.Text = Request.QueryString["ID"];
                            pf();
                            GetList();
                        }
                    }
                    catch (Exception ex)
                    {
                        WebMsg.MessageBox(ex.Message);
                    }
                }
                else
                {
                    WebMsg.CheckUserLogin();
                }
            }
        }

        private void pf()
        {
            for (int i = 60; i <= 100; i++)
            {
                dropNum.Items.Add(new ListItem(i.ToString(), i.ToString()));
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

                    btnSave.Visible = mod.N_STATE == 1 ? true : false;

                    ltlDt.Text = Convert.ToDateTime(mod.D_MOD_DT).ToString("yyy-MM-dd");
                    ltlC_EMP_NAME.Text = mod.C_EMP_NAME;

                    Mod_TMC_QUESTION modQuestion = tmc_question.GetModel(mod.C_QUEST_ID);
                    ltlQuest.Text = modQuestion.C_NAME;
                    ltlC_STL_GRD.Text = mod.C_STL_GRD;
                    ltlUseDesc.Text = mod.C_USE_DESC;
                    ltlQuestContent.Text = mod.C_REMARK;
                    if(!string .IsNullOrEmpty(mod.D_PLAN_DT.ToString ()))
                    {
                        ltlD_PLAN_DT.Text = Convert.ToDateTime(mod.D_PLAN_DT).ToString("yyy-MM-dd");
                    }
                    if(!string .IsNullOrEmpty(mod.D_PLAN_DT.ToString()))
                    {
                        ltlD_FINISH_DT.Text = Convert.ToDateTime(mod.D_FINISH_DT).ToString("yyy-MM-dd");
                    }
                    ltlC_EMP.Text = mod.C_EMP;
                   

                    ltlC_REAL_TIME.Text = mod.C_REAL_TIME;
                    ltlC_RESULT.Text = mod.C_RESULT;
                    ltlC_LEAVE_Q.Text = mod.C_LEAVE_Q;
                    ltlC_REMARK2.Text = mod.C_REMARK2;
                    dropNum.SelectedIndex = dropNum.Items.IndexOf(dropNum.Items.FindByValue(mod.N_CUST_EVAL.ToString()));
                   
                    ltlN_XG_EVAL.Text = mod.N_XG_EVAL.ToString();

                }
            }
        }

        //评分
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                mod.N_CUST_EVAL =Convert .ToDecimal(dropNum.SelectedItem.Value);
                mod.N_STATE = 2;
                mod.D_CUST_EVAL_DT = DateTime.Now;
                if (tmc_tech_consult.Update(mod))
                {
                    WebMsg.MessageBox("评分成功", "MyConsult.aspx");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}