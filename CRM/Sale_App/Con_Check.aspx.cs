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
    public partial class Con_Check : System.Web.UI.Page
    {
       
        private Bll_TMO_CON con = new Bll_TMO_CON();
        private Bll_TMO_CONDETAILS condetails = new Bll_TMO_CONDETAILS();

        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWINFO flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FILE_NEXT_EMP file_next_emp = new Bll_TMB_FILE_NEXT_EMP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (BaseUser != null)
                {
                   
                    ltlUserID.Text = BaseUser.Id;

                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        ltlConN0.Text = Request.QueryString["ID"];

                        GetFlow();
                        GetCon();

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
            DataTable dt = flowinfo.GetFlowList().Tables[0];
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
            Mod_TMO_CON mod = con.GetModel(ltlConN0.Text);
            if (mod != null)
            {
                txtTitle.Text = mod.C_CON_NAME;
                txtContent.Text = mod.C_DESC;
            }
        }

        //提交审批
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var BaseUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (BaseUser != null)
            {
                string stepID = flowstep.GetFirstStep(dropFlow.SelectedValue);//获取流程第一步骤
                if (!string.IsNullOrEmpty(stepID))
                {
                    //插入新数据
                    Mod_TMF_FILEINFO mod = new Mod_TMF_FILEINFO();
                    mod.C_FLOW_ID = dropFlow.SelectedValue;
                    mod.C_EMP_ID = ltlUserID.Text;
                    mod.C_TITLE = txtTitle.Text;
                    mod.C_CONTENT = txtContent.Text;
                    mod.N_TYPE = 0;
                    mod.C_TASK_ID = ltlConN0.Text;
                    mod.C_STEP_ID = stepID;
                    mod.D_SB_DT = DateTime.Now;
                    if (fileinfo.Add(mod))//插入文件事务
                    {
                        #region //更新合同/明细状态
                        if (con.UpdateConStatus(1, ltlConN0.Text))//更新合同
                        {
                            if (condetails.UpdateStatus(1, ltlConN0.Text))//更新合同明细
                            {
                                WebMsg.MessageBox("提交成功", "ConList.aspx");
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    WebMsg.MessageBox("当前没有流程节点，请联系管理员");
                    return;
                }
            }
        }

        //返回
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConEdit.aspx?ID="+ltlConN0.Text+"");
        }
    }
}