using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.Unity;

using NF.MODEL;
using NF.Framework;
using NF.BLL;
using NF.Bussiness.Interface;
using NF.Web.Core;
using NF.EF.Model;

namespace CRM.Sale_App
{
    public partial class Consult_View : System.Web.UI.Page
    {
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();

        IComService buttonService = DIFactory.GetContainer().Resolve<IComService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取用户所属公司名称
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    GetFun();//加载按钮权限
                    pf();


                    ltlUserName.Text = BaseUser.Name;

                    try
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            ltlID.Text = Request.QueryString["ID"];

                            Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                            if (mod != null)
                            {
                                Mod_TMC_QUESTION modQuestion = tmc_question.GetModel(mod.C_QUEST_ID);
                                ltlQuest.Text = modQuestion.C_NAME;
                                ltlDT.Text = Convert.ToDateTime(mod.D_MOD_DT).ToString("yyy年MM月dd日");
                                ltlC_EMP_NAME.Text = mod.C_EMP_NAME;
                                ltlSTL_GRD.Text = mod.C_STL_GRD;
                                ltlCust.Text = mod.C_CUST_NAME;
                                ltlUseDesc.Text = mod.C_USE_DESC;
                                ltlQuestContent.Text = mod.C_REMARK;
                                ltlCUSTEVAL.Text = mod.N_CUST_EVAL.ToString();

                                if(!string.IsNullOrEmpty(mod.D_PLAN_DT.ToString ()))
                                {
                                    Start.Value = Convert.ToDateTime(mod.D_PLAN_DT).ToString("yyy-MM-dd");
                                }
                                else
                                {
                                    Start.Value = DateTime.Now.ToString("yyy-MM-dd");
                                }
                                if (!string.IsNullOrEmpty(mod.D_FINISH_DT.ToString()))
                                {
                                    End.Value = Convert.ToDateTime(mod.D_FINISH_DT).ToString("yyy-MM-dd");
                                }
                                else
                                {
                                    End.Value = DateTime.Now.ToString("yyy-MM-dd");
                                }

                                txtEmp.Value = mod.C_EMP;
                                txtTIMECONTENT.Value = mod.C_REAL_TIME;
                                txtRESULTCONTENT.Value = mod.C_RESULT;
                                txtQUESTCONTENT.Value = mod.C_LEAVE_Q;
                                txtRemark.Value = mod.C_REMARK2;
                                dropNum.SelectedIndex = dropNum.Items.IndexOf(dropNum.Items.FindByText(mod.N_XG_EVAL.ToString()));
                               

                                EA.Visible = mod.N_STATE >=2 ? false : true;//保存
                                EB.Visible = mod.N_STATE ==2 ? true : false;//评分
                                dropNum.Enabled = mod.N_STATE == 2 ? true : false;

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
        private void pf()
        {
            for (int i = 60; i <= 100; i++)
            {
                dropNum.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        private void GetFun()
        {
            var user = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (user != null)
            {
                buttonService.RefreshButton("/WebForms/Sale_App/Consult_List.aspx", user, Session);
                List<TS_BUTTON> button = (List<TS_BUTTON>)Session["button"];

                foreach (var item in button)
                {
                    if (Page.FindControl(item.C_CODE) != null)
                    {
                        Page.FindControl(item.C_CODE).Visible = true;
                    }
                }
            }
            else
            {
                WebMsg.CheckUserLogin();
            }
        }


        //保存
        protected void EA_Click(object sender, EventArgs e)
        {
            try
            {

                Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                if (mod != null)
                {
                    mod.D_PLAN_DT = Convert.ToDateTime(Start.Value);
                    mod.D_FINISH_DT = Convert.ToDateTime(End.Value);
                    if (!string.IsNullOrEmpty(mod.C_EMP))
                    {
                        if (!mod.C_EMP.Contains(ltlUserName.Text))
                        {
                            mod.C_EMP = mod.C_EMP + "," + ltlUserName.Text;
                        }
                    }
                    else
                    {
                        mod.C_EMP = ltlUserName.Text;
                    }
                    mod.C_REAL_TIME = txtTIMECONTENT.Value;
                    mod.C_RESULT = txtRESULTCONTENT.Value;
                    mod.C_LEAVE_Q = txtQUESTCONTENT.Value;
                    mod.C_REMARK2 = txtRemark.Value;
                    mod.N_STATE = 1;
                    if (tmc_tech_consult.Update(mod))
                    {
                        WebMsg.MessageBox("保存成功", "Consult_List.aspx");
                    }

                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        //评分
        protected void EB_Click(object sender, EventArgs e)
        {

            try
            {
                Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ltlID.Text);
                if (mod != null)
                {
                    mod.N_XG_EVAL = Convert.ToDecimal(dropNum.SelectedItem.Text);
                    mod.N_STATE = 3;
                    mod.C_XG_EVAL_EMP = ltlUserName.Text;
                    mod.D_XG_EVAL_DT = DateTime.Now;
                    if (tmc_tech_consult.Update(mod))
                    {
                        WebMsg.MessageBox("评分成功", "Consult_List.aspx");
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