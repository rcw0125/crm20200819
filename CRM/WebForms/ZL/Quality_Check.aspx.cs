using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NF.MODEL;
using NF.BLL;
using System.IO;
using NF.Framework;
using System.Web.UI.HtmlControls;
using NF.BLL.Q;
using NF.MODEL.Q;

namespace CRM.WebForms.ZL
{
    public partial class Quality_Check : System.Web.UI.Page
    {

        private Bll_TMQ_QUA_MAIN qua = new Bll_TMQ_QUA_MAIN();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMB_FLOWSTEP flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();
        private Bll_TMB_FLOWPROC flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMF_FILEINFO fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
                if (vUser == null)
                {
                    WebMsg.CheckUserLogin();
                    return;
                }
                else
                {
                    ltlUserID.Text = vUser.Id;
                    ltlUserName.Text = vUser.Name;
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]) && !string.IsNullOrEmpty(Request.QueryString["flag"]))
                    {
                        ltlFileID.Text = Request.QueryString["ID"];
                        ltlFlag.Text = Request.QueryString["flag"];

                        Mod_TMF_FILEINFO modFile = fileinfo.GetModel(ltlFileID.Text);
                        if (modFile != null)
                        {
                            GetZLInfo(modFile.C_TASK_ID);//质量异议基本信息
                            hid.Value = modFile.C_TASK_ID;

                            ltlTaskID.Text = modFile.C_TASK_ID;
                            ltlFlowID.Text = modFile.C_FLOW_ID;
                            ltlStepID.Text = modFile.C_STEP_ID;
                            GetFlowProc();//加载审批记录                         

                            div_check.Visible = ltlFlag.Text == "0" ? true : false;
                            hidNextSetpID.Value = flowstep.GetNextStep(ltlFlowID.Text, ltlStepID.Text);

                            //最后步骤操作
                            if (hidNextSetpID.Value == "0")
                            {
                                trNextEmp.Visible = false;
                            }
                            else
                            {
                                trNextEmp.Visible = true;
                            }

                        }


                    }


                }
            }
        }

        //质量异议基本信息
        private void GetZLInfo(string id)
        {

            var mod = qua.GetModel(id);
            if (mod != null)
            {
                hidstatus.Value = Convert.ToString(mod.N_status);

                #region 详细信息

                ltlStat.Text = mod.N_statusname;//当前状态

                ltlArea.Text = mod.C_area_id;

                if (!string.IsNullOrEmpty(mod.C_distributor))
                {
                    txtDistributor.Value = mod.C_distributor;
                }
                if (!string.IsNullOrEmpty(mod.C_directuser))
                {
                    txtDirectuser.Value = mod.C_directuser;
                }
                if (!string.IsNullOrEmpty(mod.C_contact))
                {
                    txtContact.Value = mod.C_contact;
                }
                if (!string.IsNullOrEmpty(mod.C_con_phone))
                {
                    txtConPhone.Value = mod.C_con_phone;
                }
                if (!string.IsNullOrEmpty(mod.C_grd))
                {
                    txtGrd.Value = mod.C_grd;
                }
                if (mod.D_ship_start_dt != null)
                {
                    txtShipStart.Value = DateTime.Parse(mod.D_ship_start_dt.ToString()).ToString("yyyy-MM-dd");
                }
                if (mod.D_ship_end_dt != null)
                {
                    txtShipEnd.Value = DateTime.Parse(mod.D_ship_end_dt.ToString()).ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(mod.C_prod_use))
                {
                    txtProUse.Value = mod.C_prod_use;
                }
                if (!string.IsNullOrEmpty(mod.C_object_content))
                {
                    txtObjContent.Text = mod.C_object_content;
                }
                if (!string.IsNullOrEmpty(mod.C_tech_desc))
                {
                    txtTechDesc.Text = mod.C_tech_desc;
                }
                if (!string.IsNullOrEmpty(mod.C_remark))
                {
                    txtBz.Text = mod.C_remark;
                }
                if (mod.N_object_count_wgt != null)
                {
                    txtOBJECT_COUNT_WGT.Value = mod.N_object_count_wgt.ToString();
                }
                if (mod.C_site_survey_content != null)
                {
                    txtSite_SURVEY_CONTENT.Text = mod.C_site_survey_content.ToString();
                }
                if (mod.N_parent_qua != null)
                {
                    txtPARENT_QUA.Value = mod.N_parent_qua.ToString();
                }
                if (mod.N_quest_qua != null)
                {
                    txtQUEST_QUA.Value = mod.N_quest_qua.ToString();
                }
                if (mod.N_middle_qua != null)
                {
                    txtMIDDLE_QUA.Value = mod.N_middle_qua.ToString();
                }
                if (mod.N_else_qua != null)
                {
                    txtELSE_QUA.Value = mod.N_else_qua.ToString();
                }
                if (!string.IsNullOrEmpty(mod.C_dept))
                {
                    txtDEPT.Value = mod.C_dept;
                }
                if (!string.IsNullOrEmpty(mod.C_quality_dept))
                {
                    txtQUALITY_DEPT.Value = mod.C_quality_dept;
                }
                if (!string.IsNullOrEmpty(mod.C_technology))
                {
                    txtTECHNOLOGY.Value = mod.C_technology;
                }
                if (!string.IsNullOrEmpty(mod.C_qt))
                {
                    txtQT.Value = mod.C_qt;
                }
                if (!string.IsNullOrEmpty(mod.C_cust_making))
                {
                    txtCUST_MAKING.Value = GetUserName(mod.C_cust_making);
                }
                if (mod.D_cust_making_dt != null)
                {
                    txtCUST_MAKING_DT.Value = Convert.ToDateTime(mod.D_cust_making_dt.ToString()).ToString("yyy-MM-dd");
                }
                if (mod.N_flag != null)
                {
                    ddlType.SelectedValue = mod.N_flag.ToString();
                }
                if (!string.IsNullOrEmpty(mod.C_salesman))
                {
                    txtSaleUser.Value = mod.C_salesman;
                }

                if (!string.IsNullOrEmpty(mod.C_quality_result))
                {
                    txtQUALITY_RESULT.Value = mod.C_quality_result;
                }

                txtGrdType.Value = mod.C_objection_type;//钢种类型

                txtQUEXIAN.Value = mod.C_ourreasons;//缺陷


                txtCUST_MAKING.Value = mod.C_cust_making;
                txtCUST_MAKING_DT.Value = mod.D_cust_making_dt.ToString();

                #endregion


                DataTable dt = qua.GetItemList(" and c_parentid='" + id + "'").Tables[0];
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        private string GetUserName(string id)
        {
            string name = string.Empty;
            Mod_TS_USER mod = ts_user.GetModel(id);
            if (mod != null)
            {
                name = mod.C_NAME;
            }
            return name;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string nextStep = hidNextSetpID.Value;//下一步骤

                if (nextStep == "0")
                {
                    #region //最后步骤操作

                    Mod_ApproveCon mod = new Mod_ApproveCon();

                    mod.C_EMP_ID = ltlUserID.Text;//当前审批人
                    mod.NEXTSTEPID = nextStep;//下一步骤
                    mod.FILE_STATUS = "1";// 办结
                    mod.FILEID = ltlFileID.Text;
                    mod.CON_STATUS = "2";//审核通过
                    mod.CON_NO = ltlTaskID.Text;
                    mod.STEPID = ltlStepID.Text;//当前步骤

                    mod.JYRESULT = txtQUALITY_RESULT.Value;//质量检验结果

                    mod.PFMONEY = Convert.ToDecimal(txtPFMONEY.Value == "" ? "0" : txtPFMONEY.Value);
                    mod.PFDATE = Convert.ToDateTime(txtPFDATE.Value == "" ? DateTime.Now.ToString() : txtPFDATE.Value);

                    if (fileinfo.UpdateLastStep_QUA(mod))
                    {
                        ProAdd("批准");
                    }
                    #endregion
                }
                else
                {
                    #region //下一步骤操作

                    if (tmb_file_next_emp.UpdateNextSetp(ltlFileID.Text, ltlStepID.Text, nextStep, hidEmpID.Value, ltlUserID.Text))
                    {
                        ProAdd("批准");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
        /// <summary>
        /// 流程列表
        /// </summary>
        private void GetFlowProc()
        {
            DataTable dt = flowproc.GetFlowSteps(ltlTaskID.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptCheckList.DataSource = dt;
                rptCheckList.DataBind();
            }
            else
            {
                rptCheckList.DataSource = null;
                rptCheckList.DataBind();
            }
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {

                #region //驳回最后步骤操作
                Mod_ApproveCon mod = new Mod_ApproveCon();

                mod.UPSTEPID = "0";//步骤
                mod.FILE_STATUS = "1";//办结
                mod.FILEID = ltlFileID.Text;
                mod.STEPID = ltlStepID.Text;
                mod.CON_STATUS = "0";//待办
                mod.CON_NO = ltlTaskID.Text;
                mod.C_EMP_ID = ltlUserID.Text;
                if (fileinfo.UpdateBackLastSetp_QUA(mod))
                {
                    ProAdd("驳回");
                }
                #endregion


            }
            catch (Exception ex)
            {
                WebMsg.MessageBox(ex.Message);
            }
        }
        /// <summary>
        /// 记录审批内容
        /// </summary>
        /// <param name="status">状态</param>
        private void ProAdd(string status)
        {
            #region //添加流程明细
            string content = string.Empty;

            if (!string.IsNullOrEmpty(txtContent.Text))
            {
                content += txtContent.Text;
            }
            else
            {
                content += status;
            }

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = ltlFileID.Text;
            modPro.C_STEP_ID = ltlStepID.Text;
            modPro.C_STEP_EMP_ID = ltlUserID.Text;
            modPro.C_STEPNOTE = content;
            modPro.N_PROCRESULT = status == "批准" ? 1 : 0;
            Mod_TS_ROLE modRloe = ts_role.GetModel(ltlStepID.Text);
            modPro.C_REMARK = modRloe.C_NAME;
            #endregion
            if (flowproc.Add(modPro))
            {
                WebMsg.MessageBox("提交成功", "../Sale_App/WorkFlow_F.aspx");
            }
        }



    }
}