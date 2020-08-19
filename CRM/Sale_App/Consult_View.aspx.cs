using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NF.MODEL;
using NF.Framework;
using NF.BLL;

namespace CRM.Sale_App
{
    public partial class Consult_View : System.Web.UI.Page
    {
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private Bll_TMC_TECH_CONSULT_RESULT tmc_tech_consult_result = new Bll_TMC_TECH_CONSULT_RESULT();
        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlEmpID.Text = BaseUser.Id;
                    txtEmp.Value = BaseUser.Name;

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"])&& !string.IsNullOrEmpty(Request.QueryString["dept"]))
                    {
                        ltlID.Text = Request.QueryString["ID"];
                        ltlDeptID.Text = Request.QueryString["dept"];

                        Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                        if (mod != null)
                        {
                            Mod_TMC_QUESTION modQuestion = tmc_question.GetModel(mod.C_QUEST_ID);
                            ltlQuest.Text = modQuestion.C_NAME;
                            ltlSTL_GRD.Text = mod.C_STL_GRD;
                            ltlCust.Text = mod.C_CUST_NAME;
                            ltlUseDesc.Text = mod.C_USE_DESC;
                            ltlQuestContent.Text = mod.C_REMARK;

                            GetSubList();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取处理结果
        /// </summary>
        private void GetSubList()
        {
            DataRow dr = tmc_tech_consult_result.GetConsult_ResultList(ltlID.Text, ltlDeptID.Text);
            if(dr!=null)
            {
                ltlQuestID.Text = dr["C_ID"].ToString();
                btnSubmit.Visible = dr["D_CUST_EVAL_DT"].ToString() == "" ? true : false;
                Start.Value = dr["D_PLAN_DT"].ToString() == "" ? DateTime.Now.ToString("yyy-MM-dd") : Convert.ToDateTime(dr["D_PLAN_DT"]).ToString ("yyy-MM-dd");
                End.Value = dr["D_PLAN_DT"].ToString() == "" ? DateTime.Now.ToString("yyy-MM-dd") : Convert.ToDateTime(dr["D_FINISH_DT"]).ToString("yyy-MM-dd");

                txtTIMECONTENT.Value = dr["C_REAL_TIME"].ToString();
                txtRESULTCONTENT.Value = dr["C_RESULT"].ToString();
                txtQUESTCONTENT.Value = dr["C_LEAVE_Q"].ToString();
                txtCUSTEVAL.Value = dr["N_CUST_EVAL"].ToString();
                txtXGEVAL.Value = dr["N_XG_EVAL"].ToString();

            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Mod_TMC_TECH_CONSULT_RESULT mod = tmc_tech_consult_result.GetModel(ltlQuestID.Text);
            if(mod!=null)
            {
                mod.D_PLAN_DT = Convert.ToDateTime(Start.Value);
                mod.D_FINISH_DT = Convert.ToDateTime(End.Value);
                mod.C_EMP_ID = ltlEmpID.Text;
                mod.C_REAL_TIME = txtTIMECONTENT.Value;
                mod.C_RESULT = txtRESULTCONTENT.Value;
                mod.C_LEAVE_Q = txtQUESTCONTENT.Value;
                if(tmc_tech_consult_result.Update(mod))
                {
                    WebMsg.MessageBox("提交成功", "Consult_List.aspx");
                }
            }
        }
    }
}