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
using System.Web.Services;
using NF.BLL.Q;
using NF.MODEL.Q;

namespace CRM.WebForms.Roll
{
    public partial class rollCheck : System.Web.UI.Page
    {

        private Bll_TMC_ROLL_APPLY tmc_roll_apply = new Bll_TMC_ROLL_APPLY();

        private Bll_TMF_FILEINFO tmf_fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private static Bll_TMB_FLOWSTEP tmb_flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                    try
                    {
                        ltlUserID.Text = BaseUser.Id;

                        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                        {
                            Mod_TMC_ROLL_APPLY mod = tmc_roll_apply.GetModel(Request.QueryString["ID"]);
                            if (mod != null)
                            {
                                txtTitle.Text = mod.C_TITLE;
                            }

                            hidQualityID.Value = Request.QueryString["ID"];
                            GetFlow();
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
        /// 获取流程
        /// </summary>
        private void GetFlow()
        {
            DataTable dt = tmb_flowinfo.GetFlowList("3").Tables[0];
            if (dt.Rows.Count > 0)
            {
                dropFlow.DataSource = dt;
                dropFlow.DataTextField = "C_NAME";
                dropFlow.DataValueField = "C_ID";
                dropFlow.DataBind();
            }
            else
            {
                dropFlow.DataSource = null;
                dropFlow.DataBind();
            }
        }



        //提交审批
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(hidEmpID.Value))
                {
                    //文件
                    Mod_TMF_FILEINFO modFile = new Mod_TMF_FILEINFO();
                    modFile.C_FLOW_ID = dropFlow.SelectedValue;//流程
                    modFile.C_EMP_ID = ltlUserID.Text;
                    modFile.C_TITLE = txtTitle.Text;
                    modFile.N_TYPE = 2;//资源
                    modFile.C_TASK_ID = hidQualityID.Value;
                    modFile.C_STEP_ID = hidSetpID.Value;//步骤
                    //步骤操作人
                    Mod_TMB_FILE_NEXT_EMP modNextEmp = new Mod_TMB_FILE_NEXT_EMP();
                    modNextEmp.C_FILE_ID = ID;
                    modNextEmp.C_NEXT_EMP_ID = hidEmpID.Value;
                    modNextEmp.C_STEP_ID = hidSetpID.Value;
                    if (tmc_roll_apply.ApproveQua(modFile, modNextEmp))
                    {
                        WebMsg.MessageBox("提交成功", "myRoll.aspx");
                    }
                    else
                    {
                        WebMsg.MessageBox("提交失败");
                    }
                }
                else
                {
                    WebMsg.MessageBox("请选择下一处理人");
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }

        /// <summary>
        /// 获取流程步骤
        /// </summary>
        /// <param name="flowID"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetStep(string flowID)
        {
            return tmb_flowstep.GetFirstStep(flowID);//获取流程第一步骤           
        }

        //返回
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("roll_apply.aspx?ID=" + hidQualityID.Value + "");
        }
    }
}