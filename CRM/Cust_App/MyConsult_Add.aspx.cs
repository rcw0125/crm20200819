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

namespace CRM.Cust_App
{
    public partial class MyConsult_Add : System.Web.UI.Page
    {

        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();
        private Bll_TMC_QUESTION_DEPT tmc_question_dept = new Bll_TMC_QUESTION_DEPT();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private Bll_TMC_TECH_CONSULT_RESULT tmc_tech_consult_result = new Bll_TMC_TECH_CONSULT_RESULT();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    ltlUserID.Text = BaseUser.Id;
                    ltlUserName.Text = BaseUser.Name;

                    //获取客户信息
                    if (!string.IsNullOrEmpty(BaseUser.CustId))
                    {
                        Mod_TS_CUSTFILE mod = ts_custfile.GetModel(BaseUser.CustId);
                        ltlCustNo.Text = mod.C_NO;
                        txtCust.Value = mod.C_NAME;                        
                    }


                    GetQuestion();

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
            if(dt.Rows .Count >0)
            {
                dropQuest.DataSource = dt;
                dropQuest.DataTextField = "C_NAME";
                dropQuest.DataValueField = "C_ID";
                dropQuest.DataBind();
            }
            else
            {
                dropQuest.DataSource = null;
                dropQuest.DataBind();
            }
        }

        //添加
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Mod_TMC_TECH_CONSULT mod = new Mod_TMC_TECH_CONSULT();

            string C_ID = Guid.NewGuid().ToString();

            mod.C_ID = C_ID;
            mod.C_QUEST_ID = dropQuest.SelectedValue;
            mod.C_CUST_NAME = txtCust.Value;
            mod.C_CUST_CODE = ltlCustNo.Text;
            mod.C_STL_GRD = txt_STL_GRD.Value;
            mod.C_USE_DESC = txtUseDesc.Value;
            mod.C_REMARK = txtRemark.Value;
            mod.C_EMP_ID = ltlUserID.Text;
            mod.C_EMP_NAME = ltlUserName.Text;
            if(tmc_tech_consult.Add(mod))
            {
                DataTable dt = tmc_question_dept.GetQuestion_Dept(dropQuest.SelectedValue, "").Tables[0];
                if(dt.Rows .Count>0)
                {
                    Mod_TMC_TECH_CONSULT_RESULT mod2 = new Mod_TMC_TECH_CONSULT_RESULT();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mod2.C_TECH_CONSULT_ID = C_ID;
                        mod2.C_DEPT = dt.Rows[i]["C_DEPT_ID"].ToString();
                        tmc_tech_consult_result.Add(mod2);
                    }
                }
                Response.Write("<script>alert('提交成功');window.close();window.opener.location.reload('MyConsult.aspx');</script>");
            }

        }
    }
}