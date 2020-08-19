using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using NF.BLL;
using NF.MODEL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NF.Framework;
using System.Web;
using ZXing;
using System.Drawing;

namespace CRM.Controllers
{
    //CRM主页面加载数据
    public class ApiMainController : ApiBaseController
    {
        private Bll_TMB_NOTICE tmb_notice = new Bll_TMB_NOTICE();
        private Bll_TMF_FILEINFO tmf_fileinfo = new Bll_TMF_FILEINFO();

       


        #region //获取公告列表_GetNotice
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetNotice([FromBody]dynamic Json)
        {
            #region //参数
            string rowNum = Json.rowNum; //显示行数
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            DataTable dt = tmb_notice.GetList(rowNum, "").Tables[0];
            if (dt.Rows.Count > 0)
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

        #region //获取公告详情_GetNoticeView
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetNoticeView([FromBody]dynamic Json)
        {
            #region //参数
            string ID = Json.ID; //主键ID
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmb_notice.GetModel(ID));
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
            string title = ""; //Json.title;//文件名称
            string status = Json.status;//状态0待办，1已办
            string flowID = "";// Json.flowID;//工作流ID
            string startTime = ""; //Json.startTime;//开始时间
            string endTime = ""; //Json.endTime;//结束时间
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(tmf_fileinfo.GetFileTran(title, status, flowID, startTime, endTime, vUser.Id).Tables[0]);
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            #endregion

            return result;
        }
        #endregion


     


    }
}
