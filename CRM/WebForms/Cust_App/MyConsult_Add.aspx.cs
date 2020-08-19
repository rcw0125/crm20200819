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
                    try
                    {
                        ltlUserID.Text = BaseUser.Id;
                        ltlUserName.Text = BaseUser.Name;
                        //获取客户信息
                        if (!string.IsNullOrEmpty(BaseUser.CustId))
                        {
                            Mod_TS_CUSTFILE mod = ts_custfile.GetModel(BaseUser.CustId);
                            ltlCustNo.Text = mod.C_NO;
                            txtcust.Text = mod.C_NAME;
                        }

                        GetQuestion();

                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            ltlID.Text = Request.QueryString["ID"];
                            Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                            if (mod != null)
                            {
                                dropQuest.SelectedIndex = dropQuest.Items.IndexOf(dropQuest.Items.FindByText(mod.C_QUEST_ID));
                                txtgrd.Text = mod.C_STL_GRD;
                                txtUseDesc.Value = mod.C_USE_DESC;
                                txtRemark.Value = mod.C_REMARK;
                                horderNO.Value = mod.C_ORDER_NO;
                            }
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
            }
            else
            {
                dropQuest.DataSource = null;
                dropQuest.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ltlID.Text))
                {
                    Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                    mod.C_QUEST_ID = dropQuest.SelectedValue;
                    mod.C_CUST_NAME = txtcust.Text;
                    mod.C_CUST_CODE = ltlCustNo.Text;
                    mod.C_STL_GRD = txtgrd.Text;
                    mod.C_USE_DESC = txtUseDesc.Value;
                    mod.C_REMARK = txtRemark.Value;
                    mod.C_EMP_ID = ltlUserID.Text;
                    mod.C_EMP_NAME = ltlUserName.Text;
                    mod.C_ORDER_NO = horderNO.Value;
                    if (tmc_tech_consult.Update(mod))
                    {
                        WebMsg.MessageBox("修改成功", "MyConsult.aspx");
                        //Response.Write("<script>alert('修改成功');window.close();window.opener.location.reload('MyConsult.aspx');</script>");
                    }
                }
                else
                {
                    Mod_TMC_TECH_CONSULT mod = new Mod_TMC_TECH_CONSULT();
                    mod.C_QUEST_ID = dropQuest.SelectedValue;
                    mod.C_CUST_NAME = txtcust.Text;
                    mod.C_CUST_CODE = ltlCustNo.Text;
                    mod.C_STL_GRD = txtgrd.Text;
                    mod.C_USE_DESC = txtUseDesc.Value;
                    mod.C_REMARK = txtRemark.Value;
                    mod.C_EMP_ID = ltlUserID.Text;
                    mod.C_EMP_NAME = ltlUserName.Text;
                    mod.C_ORDER_NO = horderNO.Value;
                    if (tmc_tech_consult.Add(mod))
                    {
                        WebMsg.MessageBox("提交成功", "MyConsult.aspx");
                        //Response.Write("<script>alert('提交成功');window.close();window.opener.location.reload('MyConsult.aspx');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
    }
}