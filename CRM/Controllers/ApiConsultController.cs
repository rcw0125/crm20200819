using NF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using NF.BLL;
using NF.MODEL;
using CRM.ApiDtos;

namespace CRM.Controllers
{
    /// <summary>
    /// 技术咨询
    /// </summary>
    public class ApiConsultController : ApiBaseController
    {

        private Bll_TMC_QUESTION tmc_question = new Bll_TMC_QUESTION();
        private Bll_TMC_QUESTION_DEPT tmc_question_dept = new Bll_TMC_QUESTION_DEPT();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TMC_TECH_CONSULT tmc_tech_consult = new Bll_TMC_TECH_CONSULT();
        private Bll_TMC_TECH_CONSULT_RESULT tmc_tech_consult_result = new Bll_TMC_TECH_CONSULT_RESULT();



        /// <summary>
        /// 技术列表
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQuestion([FromBody]dynamic Json)
        {

            #region //数据操作   
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmc_question.GetQuestionList("").Tables[0];
            result.Result = SerializationHelper.Dtb2Json(dt);

            #endregion

            return result;
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConsultEdit([FromBody]dynamic Json)
        {
            #region //接收参数
            string ID = Json.ID;//主键
            string QuestID = Json.QuestID;//技术问题ID
            string Stl_Grd = Json.Stl_Grd;//钢种
            string UseDesc = Json.UseDesc;//用途及工艺
            string Remark = Json.Remark;//问题描述
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TS_USER modUser = GetUserID();

            Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ID);

            if (mod.N_STATE == 0)
            {
                mod.C_QUEST_ID = QuestID;
                mod.C_STL_GRD = Stl_Grd;
                mod.C_USE_DESC = UseDesc;
                mod.C_REMARK = Remark;
                mod.C_EMP_ID = modUser.C_ID;
                mod.C_EMP_NAME = modUser.C_NAME;
                if (tmc_tech_consult.Update(mod))
                {
                    result.Result = "保存成功";
                }
                else
                {
                    result.Result = "保存失败";
                }
            }
            else
            {
                result.Result = "当前状态咱不可修改";
            }

            #endregion

            return result;
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConsultAdd([FromBody]dynamic Json)
        {
            #region //接收参数
            string QuestID = Json.QuestID;//技术问题ID
            string Stl_Grd = Json.Stl_Grd;//钢种
            string UseDesc = Json.UseDesc;//用途及工艺
            string Remark = Json.Remark;//问题描述
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TS_USER modUser = GetUserID();
            Mod_TS_CUSTFILE modcustfile = ts_custfile.GetModel(modUser.C_CUST_ID);
            Mod_TMC_TECH_CONSULT mod = new Mod_TMC_TECH_CONSULT();

            mod.C_QUEST_ID = QuestID;
            mod.C_CUST_NAME = modcustfile.C_NAME;
            mod.C_CUST_CODE = modcustfile.C_NO;
            mod.C_STL_GRD = Stl_Grd;
            mod.C_USE_DESC = UseDesc;
            mod.C_REMARK = Remark;
            mod.C_EMP_ID = modUser.C_ID;
            mod.C_EMP_NAME = modUser.C_NAME;

            if (tmc_tech_consult.Add(mod))
            {
                result.Result = "提交成功";
            }
            else
            {
                result.Result = "提交失败";
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConsultList([FromBody]dynamic Json)
        {

            #region //接收参数
            string QuestID = Json.QuestID;//技术问题ID
            int PageSize = Json.PageSize;//显示页数
            int StartIndex = Json.StartIndex;//起始页数
            string StartDT = Json.StartDT;//开始时间
            string EndDT = Json.EndDT;//结束时间
            string State = Json.State;//状态
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TS_USER mod = GetUserID();
            DataTable dt = tmc_tech_consult.GetListByPage(PageSize, StartIndex, QuestID, mod.C_ID, StartDT, EndDT, "", State).Tables[0];

            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;
        }

        /// <summary>
        /// 查看详细内容
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ConsultView([FromBody]dynamic Json)
        {

            #region //接收参数
            string ConsultID = Json.ConsultID;//技术咨询ID

            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = SerializationHelper.JsonSerialize(tmc_tech_consult.GetModel(ConsultID));
            #endregion

            return result;
        }

        /// <summary>
        /// 服务评分
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SetEval([FromBody]dynamic Json)
        {

            #region //接收参数
            string ResulID = Json.ResulID;//问题列表ID
            string Score = Json.Score;//分数
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            Mod_TMC_TECH_CONSULT mod = tmc_tech_consult.GetModel(ResulID);
            mod.N_CUST_EVAL = Score == "" ? 0 : Convert.ToDecimal(Score);
            mod.N_STATE = 2;
            mod.D_CUST_EVAL_DT = DateTime.Now;
            if (tmc_tech_consult.Update(mod))
            {
                result.Result = "评分成功";
            }
            else
            {
                result.Result = "评分失败";
            }

            #endregion

            return result;
        }

    }
}
