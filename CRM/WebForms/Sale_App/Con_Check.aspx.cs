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

namespace CRM.Sale_App
{
    public partial class Con_Check : System.Web.UI.Page
    {

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();

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
                            ltlConN0.Text = Request.QueryString["ID"];

                            GetFlow();
                            GetCon();
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
            DataTable dt = tmb_flowinfo.GetFlowList("1").Tables[0];
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

        /// <summary>
        /// 获取合同信息
        /// </summary>

        private void GetCon()
        {
            Mod_TMO_CON mod = tmo_con.GetModel(ltlConN0.Text);
            if (mod != null)
            {
                txtTitle.Text = mod.C_CON_NO;
                txtContent.Text = mod.C_REAMRK;
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
                    modFile.C_CONTENT = txtContent.Text;
                    modFile.N_TYPE = 0;
                    modFile.C_TASK_ID = ltlConN0.Text;
                    modFile.C_STEP_ID = hidSetpID.Value;//步骤

                    //步骤操作人
                    Mod_TMB_FILE_NEXT_EMP modNextEmp = new Mod_TMB_FILE_NEXT_EMP();
                    modNextEmp.C_FILE_ID = ID;
                    modNextEmp.C_NEXT_EMP_ID = hidEmpID.Value;
                    modNextEmp.C_STEP_ID = hidSetpID.Value;

                    if (tmo_con.ApproveCon(modFile, modNextEmp))
                    {
                        WebMsg.MessageBox("提交成功", "ConList.aspx");
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
            Response.Redirect("ConEdit.aspx?ID=" + ltlConN0.Text + "");
        }
    }
}