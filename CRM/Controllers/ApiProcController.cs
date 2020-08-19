using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using NF.BLL;
using NF.Framework;
using NF.MODEL;
using System.Data;

namespace CRM.Controllers
{
    /// <summary>
    /// 产品展示
    /// </summary>
    public class ApiProcController : ApiBaseController
    {
        #region //实例化
        private Bll_TMB_PROC tmb_proc = new Bll_TMB_PROC();
        #endregion


        #region //产品类型_GetProcType
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetProcType([FromBody]dynamic Json)
        {

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmb_proc.GetProcType().Tables[0]);
            #endregion

            return result;
        }
        #endregion

        #region //产品列表_GetProcList
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetProcList([FromBody]dynamic Json)
        {
            #region //参数
            string ProcType = Json.ProcType;//产品类型名称
            string StlGrd = Json.StlGrd;//钢种
            string PageIndex = Json.PageIndex;//当前页
            string PageSize = Json.PageSize;//显示页数
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            
            result.Result = JsonConvert.SerializeObject(tmb_proc.GetProcList(ProcType, StlGrd,PageIndex,PageSize).Tables[0]);
            #endregion

            return result;
        }
        #endregion


        #region //添加产品类型_AddProcType
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult AddProcType([FromBody]dynamic Json)
        {

            #region //参数
            string procType = Json.procType;//名称
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmb_proc.AddProcType(procType));
            #endregion

            return result;
        }
        #endregion

        #region //更新产品类型_UpdateProcType
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult UpdateProcType([FromBody]dynamic Json)
        {

            #region //参数
            string procType = Json.procType;//名称
            string status = Json.status;//状态
            string id = Json.id;//ID
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmb_proc.UpdateProcType(procType,status,id));
            #endregion

            return result;
        }
        #endregion

        #region //添加产品_AddProc
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult AddProc([FromBody]dynamic Json)
        {

            #region //参数
            string stlGrd = Json.stlGrd;//钢种
            string spec = Json.spec;//规格
            string stdCode= Json.stdCode;//执行标准
            string desc = Json.desc;//用途
            string remark = Json.remark;//备注
            string procType = Json.procType;//产品类型
            string imgUrl = Json.imgUrl;//图片地址
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TMB_PROC mod = new Mod_TMB_PROC();
            mod.C_STLGRD = stlGrd;
            mod.C_SPEC = spec;
            mod.C_STDCODE = stdCode;
            mod.C_REMARK = remark;
            mod.C_PROCTYPE = procType;
            mod.C_IMGURL = imgUrl;

            result.Result = JsonConvert.SerializeObject(tmb_proc.AddProc(mod));
            #endregion

            return result;
        }
        #endregion

        #region //更新产品_UpdateProc
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult UpdateProc([FromBody]dynamic Json)
        {

            #region //参数
            string stlGrd = Json.stlGrd;//钢种
            string spec = Json.spec;//规格
            string stdCode = Json.stdCode;//执行标准
            string desc = Json.desc;//用途
            string remark = Json.remark;//备注
            string procType = Json.procType;//产品类型
            string imgUrl = Json.imgUrl;//图片地址
            string id = Json.id;//产品ID
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            Mod_TMB_PROC mod = new Mod_TMB_PROC();
            mod.C_STLGRD = stlGrd;
            mod.C_SPEC = spec;
            mod.C_STDCODE = stdCode;
            mod.C_REMARK = remark;
            mod.C_PROCTYPE = procType;
            mod.C_IMGURL = imgUrl;
            mod.C_ID = id;

            result.Result = JsonConvert.SerializeObject(tmb_proc.UpdateProc(mod));
            #endregion

            return result;
        }
        #endregion


        #region //产品列表_GetProc
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetProc([FromBody]dynamic Json)
        {
            #region //参数
            string ProcType = Json.ProcType;//产品类型名称
            string StlGrd = Json.StlGrd;//钢种
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();           
            DataTable dt = tmb_proc.GetProcList(ProcType, StlGrd,"","").Tables[0];
            if(dt.Rows.Count>0)
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(dt);
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            #endregion

            return result;
        }
        #endregion

        #region //更新产品_DelProc
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult DelProc([FromBody]dynamic Json)
        {

            #region //参数
            string id = Json.id;//产品ID
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmb_proc.DelProc(id));
            #endregion

            return result;
        }
        #endregion

    }
}
