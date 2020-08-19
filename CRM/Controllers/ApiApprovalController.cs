using NF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NF.BLL;
using NF.MODEL;

namespace CRM.Controllers
{
    /// <summary>
    /// 事务审批
    /// </summary>
    public class ApiApprovalController : ApiBaseController
    {
        #region //实例化

        #region //审批
        private Bll_TMB_FLOWINFO tmb_flowinfo = new Bll_TMB_FLOWINFO();
        private Bll_TMF_FILEINFO tmf_fileinfo = new Bll_TMF_FILEINFO();
        private Bll_TMB_FLOWPROC tmb_flowproc = new Bll_TMB_FLOWPROC();
        private Bll_TMB_FLOWSTEP tmb_flowstep = new Bll_TMB_FLOWSTEP();
        private Bll_TS_USER_ROLE ts_user_role = new Bll_TS_USER_ROLE();
        private Bll_TS_ROLE ts_role = new Bll_TS_ROLE();
        private Bll_TMB_FILE_NEXT_EMP tmb_file_next_emp = new Bll_TMB_FILE_NEXT_EMP();
        #endregion

        private Bll_TMO_CON tmo_con = new Bll_TMO_CON();

        #region //质量异议
        private Bll_TMQ_QUALITY_MAIN tmq_quality_main = new Bll_TMQ_QUALITY_MAIN();
        private Bll_TMQ_QUALITY_STL_GRD tmq_quality_stl_grd = new Bll_TMQ_QUALITY_STL_GRD();
        #endregion

        #endregion


        #region //审批流_GetFlow
        /// <summary>
        /// 获取审批流
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFlow([FromBody]dynamic Json)
        {

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tmb_flowinfo.GetFlowList("").Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region //获取事务列表_GetAffair
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetAffair([FromBody]dynamic Json)
        {
            #region //参数
            string title = Json.title;//文件名称
            string status = Json.status;//状态0待办，1已办
            string flowID = Json.flowID;//工作流ID
            string startTime = Json.startTime;//开始时间
            string endTime = Json.endTime;//结束时间
            #endregion

            #region //数据操作

            Mod_TS_USER modUser = GetUserID();

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tmf_fileinfo.GetFileTran(title, status, flowID, startTime, endTime, modUser.C_ID).Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region //获取审批记录_GetApprovalRecords
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetApprovalRecords([FromBody]dynamic Json)
        {
            #region //参数
            string taskID = Json.taskID;//文件ID
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tmb_flowproc.GetFlowSteps(taskID).Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region //获取下一处理步骤_GetNextStep
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetNextStep([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            #endregion

            #region //数据操作

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            string nextStep = "0";
            if (modFile.C_STEP_ID != "0")
            {
                nextStep = tmb_flowstep.GetNextStep(modFile.C_FLOW_ID, modFile.C_STEP_ID);
            }
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = nextStep;
            #endregion

            return result;
        }
        #endregion

        #region //获取下一步骤审批人列表_GetNextStepApprEmp
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetNextStepApprEmp([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            #endregion

            #region //数据操作
            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            string nextStep = "0";
            if (modFile.C_STEP_ID != "0")
            {
                nextStep = tmb_flowstep.GetNextStep(modFile.C_FLOW_ID, modFile.C_STEP_ID);
            }

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(ts_user_role.GetCheckEmp(nextStep).Tables[0]);
            #endregion

            return result;
        }
        #endregion


        #region //审批日志
        /// <summary>
        /// 审批日志
        /// </summary>
        /// <param name="status">处理状态</param>
        /// <param name="content">批语</param>
        /// <param name="userName">审批人姓名</param>
        /// <param name="userID">审批人ID</param>
        /// <param name="stepID">步骤ID</param>
        /// <param name="fileID">文件ID</param>
        /// <returns></returns>
        private string ProAdd(string status, string content, string userName, string userID, string stepID, string fileID)
        {
            #region //添加流程明细

            Mod_TMB_FLOWPROC modPro = new Mod_TMB_FLOWPROC();
            modPro.C_FILE_ID = fileID;
            modPro.C_STEP_ID = stepID;
            modPro.C_STEP_EMP_ID = userID;
            if (!string.IsNullOrEmpty(content))
            {
                modPro.C_STEPNOTE = content;
               
            }
            else
            {
                modPro.C_STEPNOTE= status;
            }
            modPro.N_PROCRESULT = status == "批准" ? 1 : 0;
            Mod_TS_ROLE modRloe = ts_role.GetModel(stepID);
            modPro.C_REMARK = modRloe.C_NAME;
          
            #endregion

            if (tmb_flowproc.Add(modPro))
            {
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }
        #endregion

        #region //合同审批工作流程

        #region//批准_GetConOK
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConOK([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            string content = Json.content;//批语
            string nextApprEmpID = Json.nextApprEmpID;//下一步骤审批人ID,注意:多人审批"#"隔开,如(张三ID#李四)
            #endregion

            #region //数据操作

            string jg = string.Empty;

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            Mod_TS_USER modUser = GetUserID();
            string nextStep = tmb_flowstep.GetNextStep(modFile.C_FLOW_ID, modFile.C_STEP_ID);
            if (nextStep == "0")
            {
                #region //最后步骤操作

                Mod_ApproveCon mod = new Mod_ApproveCon();



                mod.C_EMP_ID = modUser.C_ID;
                mod.NEXTSTEPID = nextStep;
                mod.FILE_STATUS = "1";
                mod.FILEID = fileID;
                mod.CON_STATUS = "2";
                mod.CON_NO = modFile.C_TASK_ID;
                if (tmf_fileinfo.UpdateLastStep(mod))
                {
                    jg = ProAdd("批准", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
                }
                #endregion
            }
            else
            {
                #region //下一步骤操作

                if (tmb_file_next_emp.UpdateNextSetp(fileID, modFile.C_STEP_ID, nextStep, nextApprEmpID, modUser.C_ID))
                {
                    jg = ProAdd("批准", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
                }
                #endregion
            }

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = jg;
            #endregion

            return result;
        }




        #endregion

        #region //驳回_GetConBack
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConBack([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            string content = Json.content;//批语

            #endregion

            #region //数据操作

            string jg = string.Empty;

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            Mod_TS_USER modUser = GetUserID();

            #region //驳回最后步骤操作
            Mod_ApproveCon mod = new Mod_ApproveCon();
            mod.UPSTEPID = "0";
            mod.FILE_STATUS = "1";
            mod.FILEID = fileID;
            mod.STEPID = modFile.C_STEP_ID;
            mod.CON_STATUS = "0";
            mod.CON_NO = modFile.C_TASK_ID;
            mod.C_EMP_ID = modUser.C_ID;
            if (tmf_fileinfo.UpdateBackLastSetp(mod))
            {
                jg = ProAdd("驳回", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
            }
            #endregion

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = jg;
            #endregion

            return result;
        }
        #endregion

        #endregion

        #region//质量异议相关审批

        #region //获取质量异议基本信息_GetQualityInfo
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQualityInfo([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            #endregion

            #region //数据操作

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            Mod_TMQ_QUALITY_MAIN mod = tmq_quality_main.GetModel(modFile.C_TASK_ID);

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.JsonSerialize(mod);
            #endregion

            return result;
        }
        #endregion

        #region //获取客户质量异议钢种_GetQualityStl_GRD

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQualityStl_GRD([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            #endregion

            #region //数据操作

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.Dtb2Json(tmq_quality_stl_grd.GetQUALITY_STL_GRD(modFile.C_TASK_ID).Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region //批准_GetQualOK
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQualOK([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            string content = Json.content;//批语
            string nextApprEmpID = Json.nextApprEmpID;//下一步骤审批人ID,注意:多人审批"#"隔开,如(张三ID#李四)
            #endregion

            #region //数据操作

            string jg = string.Empty;

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            Mod_TS_USER modUser = GetUserID();
            string nextStep = tmb_flowstep.GetNextStep(modFile.C_FLOW_ID, modFile.C_STEP_ID);
            if (nextStep == "0")
            {
                #region //最后步骤操作

                if (tmf_fileinfo.UpdateStepStatus(nextStep, 1, fileID))//更新文件事务状态为办结
                {
                    ////更新当前审批人/时间/状态
                    tmq_quality_main.UpdateCheckEmp(modFile.C_TASK_ID, modUser.C_ID, "2", DateTime.Now);
                    jg = ProAdd("批准", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
                }

                #endregion
            }
            else
            {
                #region //下一步骤操作

                if (tmb_file_next_emp.UpdateNextSetp(fileID, modFile.C_STEP_ID, nextStep, nextApprEmpID, modUser.C_ID))
                {
                    jg = ProAdd("批准", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
                }
                #endregion
            }

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = jg;
            #endregion

            return result;
        }
        #endregion

        #region //驳回_GetQualBack
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQualBack([FromBody]dynamic Json)
        {
            #region //参数
            string fileID = Json.fileID;//文件ID
            string content = Json.content;//批语

            #endregion

            #region //数据操作

            string jg = string.Empty;

            Mod_TMF_FILEINFO modFile = tmf_fileinfo.GetModel(fileID);
            Mod_TS_USER modUser = GetUserID();

            //删除当前步骤与下一步骤
            if (tmb_file_next_emp.BackSetp(fileID, "0", "0", "0"))
            {
                //更新当前审批人/时间/状态
                if (tmq_quality_main.UpdateCheckEmp(modFile.C_TASK_ID, modUser.C_ID, "0", DateTime.Now))
                {
                    jg = ProAdd("驳回", content, modUser.C_NAME, modUser.C_ID, modFile.C_STEP_ID, fileID);
                }
            }

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = jg;
            #endregion

            return result;
        }
        #endregion

        #endregion

    }
}
