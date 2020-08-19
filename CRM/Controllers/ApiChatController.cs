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
using System.Web;
using Newtonsoft.Json;

namespace CRM.Controllers
{

    /// <summary>
    /// 在线咨询
    /// </summary>
    public class ApiChatController : ApiBaseController
    {

        private static Bll_TMC_CHAT tmc_chat = new Bll_TMC_CHAT();
        private static Bll_TMC_CHAT_EMP tmc_chat_emp = new Bll_TMC_CHAT_EMP();
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TMC_CUST_BOOK tmc_cust_book = new Bll_TMC_CUST_BOOK();

        #region //手机端

        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ChatAdd([FromBody]dynamic Json)
        {


            #region //接收参数

            string Content = Json.Content;//发送内容

            #endregion

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            #region //数据操作

            DataRow dr = tmc_chat_emp.GetChatEmp();
            if (dr != null)
            {
                Mod_TS_USER modUser = GetUserID();

                string fid = dr["c_user_id"].ToString();
                Mod_TMC_CHAT mod = new Mod_TMC_CHAT();
                mod.C_UID = modUser.C_ID;
                mod.C_FID = fid;
                mod.C_CONTENT = Content;
                mod.D_DT = DateTime.Now;
                if (tmc_chat.Add(mod))
                {
                    result.Result = "提交成功";
                }
                else
                {
                    result.Result = "提交失败";
                }

            }
            else
            {
                result.Result = "提交失败";
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetChat([FromBody]dynamic Json)
        {

            #region //接收参数
            string Count = Json.Count;//条数
            string LastDT = Json.LastDT;//最后一条时间
            string FristDT = Json.FristDT;//第一条时间
            #endregion

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            #region//数据操作

            Mod_TS_USER modUser = GetUserID();
            DataTable dt = tmc_chat.GetChatList2(modUser.C_ID, LastDT, FristDT, Count).Tables[0];
            result.Result = SerializationHelper.Dtb2Json(dt);
            #endregion

            return result;
        }
        #endregion

        #region //获取客服列表人员
        /// <summary>
        /// 获取销售员名单
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetSaleEmp([FromBody]dynamic Json)
        {
            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmc_chat_emp.GetSaleEmp().Tables[0];
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion
            return result;
        }
        #endregion

        #region //PC端
        /// <summary>
        /// 插入信息 
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult ChatAddPC([FromBody]dynamic Json)
        {


            #region //接收参数
            string fID = Json.fID;//接收者
            string content = Json.content;//发送内容

            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                Mod_TMC_CHAT mod = new Mod_TMC_CHAT();
                mod.C_UID = vUser.Id;
                mod.C_FID = fID;
                mod.C_CONTENT = content;

                if (tmc_chat.Add(mod))
                {
                    result.Code = DoResult.Success;
                    result.Result = "提交成功";
                }
                else
                {
                    result.Code = DoResult.Failed;
                    result.Result = "提交失败";
                }
            }
            #endregion

            return result;
        }


        /// <summary>
        /// 获取聊天记录 PC端
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetChatPC([FromBody]dynamic Json)
        {

            #region //接收参数
            string fID = Json.fID;//接收者
            string Count = Json.Count;//条数
            string LastDT = Json.LastDT;//最后一条时间
            string FristDT = Json.FristDT;//第一条时间
            #endregion

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            #region//数据操作

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                DataTable dt = tmc_chat.GetChatList(vUser.Id, fID, LastDT, FristDT, Count).Tables[0];
                result.Result = JsonConvert.SerializeObject(dt);
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 获取当前用户ID PC端
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetUserID([FromBody]dynamic Json)
        {
            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {

                result.Result = vUser.Id;
            }
            #endregion
            return result;
        }
        #endregion



        #region //来访/走访台账


        /// <summary>
        /// 销售区域
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetArea([FromBody]dynamic Json)
        {

            AjaxResult result = new AjaxResult();
            #region //数据操作
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = "ConArea";
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion
            return result;
        }

        /// <summary>
        /// 走访/来访录入
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult AddBook([FromBody]dynamic Json)
        {

            AjaxResult result = new AjaxResult();

            #region //接收参数
            string zf_dt = Json.zf_dt;//走访日期
            string cust_name = Json.cust_name;//客户名称
            string area = Json.area;//区域
            string cust_manage = Json.cust_manage;//客户经理
            string cust_emp = Json.cust_emp;//客户人员
            string cust_emp_tel = Json.cust_emp_tel;//客户人员电话
            string meeting_cust = Json.meeting_cust;//参会客户名单
            string meeting_xg = Json.meeting_xg;//参会邢钢名单
            string main_content = Json.main_content;//主要交流内容
            string need_s_q = Json.need_s_q;//需解决问题
            string leave_q = Json.leave_q;//遗留问题
            string stl_grd = Json.stl_grd;//钢种
            string pro_use = Json.pro_use;//用途
            string site = Json.site;//交流地点
            string remark = Json.remark;//备注
            string type = Json.type;//0：走访用户，1来访客户
            #endregion

            #region //数据操作
            result.Code = DoResult.Success;
            Mod_TS_USER modUser = GetUserID();

            Mod_TMC_CUST_BOOK mod = new Mod_TMC_CUST_BOOK();
            mod.D_ZF_DT = Convert.ToDateTime(zf_dt);
            mod.C_CUST_NAME = cust_name;
            mod.C_AREA = area;
            mod.C_CUST_MANAGE = cust_manage;
            mod.C_CUST_EMP = cust_emp;
            mod.C_CUST_EMP_TEL = cust_emp_tel;
            mod.C_MEETING_CUST = meeting_cust;
            mod.C_MEETING_XG = meeting_xg;
            mod.C_MAIN_CONTENT = main_content;
            mod.C_NEED_S_Q = need_s_q;
            mod.C_LEAVE_Q = leave_q;
            mod.C_STL_GRD = stl_grd;
            mod.C_PRO_USE = pro_use;
            mod.C_SITE = site;
            mod.C_REMARK = remark;
            mod.N_TYPE = Convert.ToDecimal(type);
            mod.C_EMPID = modUser.C_ID;
            if (tmc_cust_book.Add(mod))
            {
                result.Result = "录入成功！";
            }
            else
            {
                result.Result = "录入失败！";
            }

            #endregion

            return result;
        }

        /// <summary>
        /// 获取来访/走访记录
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetBook([FromBody]dynamic Json)
        {

            AjaxResult result = new AjaxResult();

            #region //接收参数
            string cust_name = Json.cust_name;//客户
            string area = Json.area;//区域
            string type = Json.type;//0：走访用户，1来访客户
            string start_dt = Json.start_dt;//走访开始时间
            string end_dt = Json.end_dt;//走访结束时间
            #endregion

            #region //数据操作
            Mod_TS_USER modUser = GetUserID();
            result.Code = DoResult.Success;
            DataTable dt = tmc_cust_book.GetList(cust_name, area, type, start_dt, end_dt, modUser.C_ID).Tables[0];
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }


        #endregion

    }
}
