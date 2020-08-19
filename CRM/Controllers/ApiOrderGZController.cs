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
using Newtonsoft.Json.Converters;
using CRM.ApiDtos;
using CRM.Common;
using NF.MODEL.D;
using System.Text;

namespace CRM.Controllers
{
    public class ApiOrderGZController : ApiBaseController
    {
        #region //实例化
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();
        private Bll_TMD_DISPATCHDETAILS tmd_dispatchdetails = new Bll_TMD_DISPATCHDETAILS();
        private Bll_TS_USER ts_user = new Bll_TS_USER();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TS_CUSTFILE ts_custfile = new Bll_TS_CUSTFILE();
        private Bll_TSC_SLAB_MAIN tsc_slab_main = new Bll_TSC_SLAB_MAIN();
        private Bll_RandomNumber randomnumber = new Bll_RandomNumber();

        private Bll_TMD_ZZSCONFIRM_RECORD record = new Bll_TMD_ZZSCONFIRM_RECORD();

        private Bll_TB_MATRL_MAIN tb_matrl_main = new Bll_TB_MATRL_MAIN();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private static Bll_TQC_ZZS_FILE tqc_zzs_file = new Bll_TQC_ZZS_FILE();

        public static DataTable dtExport = null;

        #endregion

        #region //客户余额查询GetCustMoney/2018/12/4
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCustMoney([FromBody]dynamic Json)
        {
            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(ts_custfile.GetCusetMoney(BaseUser.CustId).Tables[0]);
            #endregion
            return result;
        }
        #endregion

        #region //订单跟踪记录_GetOrder手机
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetOrderTail([FromBody]dynamic Json)
        {
            #region //参数
            string ConNO = Json.ConNO;//合同号
            string StartDate = Json.StartDate;//开始时间
            string EndDate = Json.EndDate;//结束时间
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();

            Mod_TS_USER modUser = GetUserID();
            if (modUser != null)
            {
                Mod_TS_CUSTFILE mod = ts_custfile.GetModel(modUser.C_CUST_ID);
                result.Code = DoResult.Success;
                result.Result = SerializationHelper.Dtb2Json(tmo_order.GetOrderJL(ConNO, StartDate, EndDate, mod.C_NO).Tables[0]);
            }

            #endregion

            return result;
        }
        #endregion

        #region //订单跟踪记录_GetOrderZG_PC端
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetOrderZG([FromBody]dynamic Json)
        {
            #region //参数
            string conNO = Json.conNO;//合同号
            string startDate = Json.startDate;//开始时间
            string endDate = Json.endDate;//结束时间
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                Mod_TS_CUSTFILE mod = ts_custfile.GetModel(vUser.CustId);
                DataTable dt = tmo_order.GetOrderJL(conNO, startDate, endDate, mod.C_NO).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    result.Code = DoResult.Success;
                    result.Result = SerializationHelper.Dtb2Json(dt);
                }
                else
                {
                    result.Code = DoResult.Failed;
                }

            }

            #endregion

            return result;
        }
        #endregion

        #region //获取发运单_GetFYD
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFYD([FromBody]dynamic Json)
        {
            #region //参数
            string orderNo = Json.orderNo;//订单号
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            DataTable dt = tmd_dispatchdetails.GetOrderFYD(orderNo).Tables[0];
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

        #region //获取发运单明细_GetFYDList
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFYDList([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            string orderType = Json.orderType;//订单类型
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            DataTable dt = tmd_dispatchdetails.GetOrderFYDList(sendCode, orderType).Tables[0];
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

        #region //合同跟踪_GetConTrace
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConTrace([FromBody]dynamic Json)
        {
            #region //参数
            string custName = Json.custName;//客户名称
            string saleEmp = Json.saleEmp;//业务员
            string conNO = Json.conNO;//合同号
            string startDate = Json.startDate;//开始时间
            string endDate = Json.endDate;//结束时间
            #endregion

            //SerializationHelper.Dtb2Json(tmo_order.GetConTrace(custName, saleEmp, conNO, startDate, endDate).Tables[0]);

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            result.Result = JsonConvert.SerializeObject(tmo_order.GetConTrace(custName, saleEmp, conNO, startDate, endDate).Tables[0], new DataTableConverter());

            #endregion

            return result;
        }
        #endregion

        #region //线材&钢坯_GetRollAndSlab
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetRollAndSlab([FromBody]dynamic Json)
        {
            #region //参数
            string orderNo = Json.orderNo;//订单号 
            string flag = Json.flag;//8线材，6钢坯
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmo_order.GetRollAndSlab(orderNo, flag).Tables[0], new DataTableConverter());// SerializationHelper.Dtb2Json(tmo_order.GetRollAndSlab(orderNo, flag).Tables[0]);

            #endregion

            return result;
        }
        #endregion

        #region //出库量_GetCKWGT
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCKWGT([FromBody]dynamic Json)
        {
            #region //参数
            string matCode = Json.matCode;//物料编码
            string orderNo = Json.orderNo;//订单号
            string flag = Json.flag;//8线材，6钢坯
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataRow dr = tmo_order.GetOrderExeNum(matCode, orderNo, Convert.ToInt32(flag));
            if (dr != null)
            {
                result.Result = dr["YLXNUM"].ToString();
            }
            #endregion

            return result;
        }
        #endregion

        #region //钢坯库查询_GetSlab
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetSlab([FromBody]dynamic Json)
        {

            #region //参数
            string matCode = Json.orderNo;//物料编码
            string stlGrd = Json.stlGrd;//钢种
            string spec = Json.spec;//规格
            string startDate = Json.startDate;//开始时间
            string endDate = Json.endDate;//截至时间
            string slabCK = Json.slabCK;//钢坯仓库
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            dtExport = tsc_slab_main.GetSlabList(matCode, stlGrd, spec, startDate, endDate, slabCK).Tables[0];
            result.Result = JsonConvert.SerializeObject(dtExport, new DataTableConverter());
            #endregion

            return result;
        }
        [AllowAnonymous]
        [HttpPost]
        public AjaxResult Export()
        {
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            var name = "钢坯仓库" + DateTime.Now.ToString("yyyymmddHH24mm") + ".xls";
            var fullPath = HttpContext.Current.Server.MapPath("/ExportExcel/" + name);
            var dic = new Dictionary<string, string>();
            dic.Add("C_BATCH_NO", "批号");
            dic.Add("C_STOVE", "炉号");
            dic.Add("C_STA_DESC", "工位");
            dic.Add("C_MAT_CODE", "物料编码");
            dic.Add("C_MAT_NAME", "物料名称");
            dic.Add("C_STL_GRD", "钢种");
            dic.Add("C_SPEC", "规格");
            dic.Add("N_LEN", "长度");
            dic.Add("SUMWGT", "总重量(吨)");
            dic.Add("C_STD_CODE", "执行标准");
            dic.Add("C_MAT_TYPE", "判定等级");
            dic.Add("C_STOCK_STATE", "库存状态");
            dic.Add("D_WE_DATE", "入库时间");
            dic.Add("C_SLABWH_TIER_CODE", "层编码");
            dic.Add("C_SLABWH_LOC_CODE", "库位编号");
            dic.Add("C_SLABWH_AREA_CODE", "钢坯库区域编码");
            dic.Add("C_SLABWH_CODE", "钢坯仓库编码");
            ExportHelper.BudgetSaveExport(dtExport, dic, fullPath);
            result.Result = name;
            return result;
        }
        #endregion

        #region 质证书打印

        #region 质证书备注下拉框
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetRemarkddl([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            Bll_TQB_REMARKPRINT tmd = new Bll_TQB_REMARKPRINT();
            var strWhere = "";
            string type = Json.type;
            if (type != "")
            {
                strWhere += " and N_TYPE=" + type;
            }
            DataTable dt = tmd.GetList(strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(dt);
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            return result;
        }

        #endregion

        #region 质证书更新打印状态

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult UpdatePrint([FromBody]dynamic Json)
        {
            #region //参数
            string batch = Json.batch;//发运单号
            string ckd = Json.chd;//钢种
            string stove = Json.stove;//炉号
            int printStatus = Json.printStatus;
            string type = Json.type;//类型
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            var arrBatch = batch.Split(',');
            var arrCKD = ckd.Split(',');
            var arrStove = stove.Split(',');
            var strWhere = "";
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            var lsConfirm = new List<Mod_TMD_ZZSCONFIRM_RECORD>();
            for (int i = 0; i < arrBatch.Length; i++)
            {

                strWhere += i == 0 ? " " : " or ";

                if (type == "4")
                {
                    strWhere += " nvl(t.c_batch_no,' ')=nvl('" + arrBatch[i] + "',' ') and t.c_ckdh='" + arrCKD[i] + "' and t.c_stove='" + arrStove[i] + "' ";
                }
                else
                {
                    strWhere += " t.c_batch_no='" + arrBatch[i] + "' and t.c_ckdh='" + arrCKD[i] + "' ";
                }
                lsConfirm.Add(AddConfirmModel(arrBatch[i], arrCKD[i], "", 1, vUser, printStatus));
            }
            bool isSuccess = tmd_dispatch.UpdatePrintStatus(strWhere, printStatus);
            record.AddList(lsConfirm);

            if (isSuccess)
            {
                result.Code = DoResult.Success;
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            #endregion

            return result;
        }

        private Mod_TMD_ZZSCONFIRM_RECORD AddConfirmModel(string batch, string ckd, string fyd, decimal type, NF.Framework.CurrentUser user, int status)
        {
            return new Mod_TMD_ZZSCONFIRM_RECORD()
            {
                C_ID = Guid.NewGuid().ToString(),
                C_BATCH = batch,
                C_CKD = ckd,
                C_FYD = fyd,
                C_EMP_ID = user.Id,
                C_EMP_NAME = user.Name,
                C_STATE = EnumHelper.GetEnumDisplayName<PrintStateEnum>((PrintStateEnum)status),
                D_MOD_DT = DateTime.Now,
                N_TYPE = type
            };
        }
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult UpdateWWPrint([FromBody]dynamic Json)
        {
            #region //参数

            string fyd = Json.fyd;//发运单号           
            int printStatus = Json.printStatus;
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();
            var arrFYD = fyd.Split(',');
            var strWhere = "";
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            var lsConfirm = new List<Mod_TMD_ZZSCONFIRM_RECORD>();
            for (int i = 0; i < arrFYD.Length; i++)
            {
                strWhere += i == 0 ? " " : " or ";
                strWhere += $"  c_id='{arrFYD[i]}'  ";
                lsConfirm.Add(AddConfirmModel("", "", arrFYD[i], 2, vUser, printStatus));
            }
            bool isSuccess = tmd_dispatch.UpdateWWPrintStatus(strWhere, printStatus);
            record.AddList(lsConfirm);
            if (isSuccess)
            {
                result.Code = DoResult.Success;
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            #endregion

            return result;
        }
        #endregion

        #region 质证书检查执行标准备注
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult CheckStdCodeRemark([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();

            Bll_TQB_REMARKPRINT tmd = new Bll_TQB_REMARKPRINT();
            DataSet ds = new DataSet();
            string str = Json.stdcode;
            string flaNo = Json.flaNo;
            string grd = Json.stlgrd;//钢种
            string stdCode = Json.stdcode;//执行标准
            string fyd = Json.fyd;//发运单号
            string spec = Json.spec;//规格
            if (!string.IsNullOrEmpty(str))
            {
                string stdgrd = str.Trim() + "+" + grd.Trim();
                ds = tmd.GetList(" and UPPER(REPLACE(C_KEY,' ','')) = '" + stdgrd.ToUpper() + "'");
            }


            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string strWhere = " and t.C_TYPE=1 and t.C_SPEC='" + Json.spec + "' and t.C_STL_GRD='" + Json.stlgrd
              + "' and t.C_STD_CODE='" + Json.stdcode + "' and t.C_DISPATCH_ID='" + Json.fyd + "' and t.C_LIC_PLA_NO='" + Json.flaNo + "'";
                var dsPatch = tmd_dispatch.GetRePrintList(strWhere);
                if (dsPatch != null && dsPatch.Tables[0].Rows.Count > 0)
                {
                    result.Code = DoResult.Success;
                    result.Result = JsonConvert.SerializeObject(2);
                }
                else
                {
                    result.Code = DoResult.Success;
                    result.Result = JsonConvert.SerializeObject(1);
                }
            }
            else
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(2);
            }
            return result;
        }

        #endregion

        #region //质证书号_GetZZH
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetZZH([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser == null)
            {
                result.Code = DoResult.OverTime;
                result.Result = JsonConvert.SerializeObject("");
                return result;
            }
            var zsNo = "";
            var mod = new Mod_TMD_ZZS_REPRINT();
            #region 参数
            string strWhere = " and t.C_TYPE=1 and t.C_SPEC='" + Json.spec + "' and t.C_STL_GRD='" + Json.stlgrd
                + "' and t.C_STD_CODE='" + Json.stdcode + "' and t.C_DISPATCH_ID='" + Json.fyd + "' and t.C_LIC_PLA_NO='" + Json.flaNo + "'";
            DataTable dt = tmd_dispatch.GetRePrintList(strWhere).Tables[0];

            if (dt.Rows.Count > 0)
            {
                mod.C_certificate_no = dt.Rows[0]["c_certificate_no"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["C_REMARK"].ToString()) || string.IsNullOrEmpty(dt.Rows[0]["C_REMARK"].ToString()) && dt.Rows[0]["N_UPDATE"].ToString() == "0")
                {
                    mod.C_remark = dt.Rows[0]["C_REMARK"].ToString();
                }
                // 如果之前加过记录且备注信息为空 状态是修改，则修改备注信息
                else if (dt.Rows[0]["N_UPDATE"].ToString() == "1" && string.IsNullOrEmpty(dt.Rows[0]["C_REMARK"].ToString()))
                {
                    string strBz = Json.bz;
                    mod.C_remark = strBz;
                    tmd_dispatch.UpdateReprintRemark(strWhere, strBz);
                }
            }
            else
            {
                zsNo = randomnumber.GetZZS();
                mod = new Mod_TMD_ZZS_REPRINT()
                {
                    C_lic_pla_no = Json.flaNo,
                    C_stl_grd = Json.stlgrd,//钢种
                    C_std_code = Json.stdcode,//执行标准
                    C_dispatch_id = Json.fyd,//发运单号
                    C_spec = Json.spec,//规格
                    C_attestor = Json.empname,//签证人
                    C_print_templates = Json.mb,//模板
                    C_print_type = Json.printType,//打印
                    C_certificate_no = zsNo,
                    D_mod_dt = DateTime.Now,
                    D_visa_dt = DateTime.Now,
                    C_remark = Json.bz,
                    N_status = 1,
                    N_type = 1,
                    C_emp_id = vUser.Name
                };
                if (!string.IsNullOrEmpty(mod.C_attestor))
                {
                    tmd_dispatch.AddRePrint(mod);
                }
            }
            string strCKDWhere = " and t.C_DISPATCH_ID='" + Json.fyd + "'";
            DataTable dtCKDPrint = tmd_dispatch.GetCKDRePrintList(strCKDWhere).Tables[0];
            if (dtCKDPrint.Rows.Count > 0)
            {
                mod.C_attestor = dtCKDPrint.Rows[0]["c_attestor"].ToString();
                mod.D_visa_dt = DateTime.Parse(dtCKDPrint.Rows[0]["d_visa_dt"].ToString());
            }
            else
            {
                mod.C_attestor = Json.empname;
                mod.D_visa_dt = DateTime.Now;
            }
            #endregion

            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(mod);
            return result;
        }


        #endregion

        #region 保存签证人签证日期

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SaveCKDPrint([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser == null)
            {
                result.Code = DoResult.OverTime;
                result.Result = JsonConvert.SerializeObject("");
                return result;
            }
            var mod = new Mod_TMD_CKD_REPRINT();
            mod = new Mod_TMD_CKD_REPRINT()
            {
                C_dispatch_id = Json.fyd,
                C_attestor = Json.empname,//签证人
                D_visa_dt = DateTime.Now,
                N_status = 1,
                N_type = 1
            };
            if (!string.IsNullOrEmpty(mod.C_attestor))
            {
                var ds = tmd_dispatch.ListPrintFyd(mod.C_dispatch_id);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    tmd_dispatch.AddCKDPrint(mod);
                }
                else
                {
                    mod.C_attestor = ds.Tables[0].Rows[0]["C_ATTESTOR"].ToString();
                    mod.D_visa_dt = DateTime.Parse(ds.Tables[0].Rows[0]["D_VISA_DT"].ToString());
                }
            }
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(mod);
            return result;
        }
        #endregion

        #region //质证书号_GetWWZZH
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetWWZZH([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser == null)
            {
                result.Code = DoResult.OverTime;
                result.Result = JsonConvert.SerializeObject("");
                return result;
            }
            var zsNo = "";
            var mod = new Mod_TMD_ZZS_REPRINT();
            #region 参数
            string strWhere = " and t.C_TYPE=2 and t.C_SPEC='" + Json.spec + "' and t.C_STL_GRD='" + Json.stlgrd
                + "' and t.C_STD_CODE='" + Json.stdcode + "' and t.C_DISPATCH_ID='" + Json.fyd + "' and t.C_LIC_PLA_NO='" + Json.flaNo + "'";
            DataTable dt = tmd_dispatch.GetRePrintList(strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                mod.C_certificate_no = dt.Rows[0]["c_certificate_no"].ToString();
                if (dt.Rows[0]["c_attestor"].ToString().Trim() == "")
                {
                    mod.C_attestor = Json.empname;
                    var dtTime = DateTime.Now;
                    mod.D_visa_dt = dtTime;
                    tmd_dispatch.UpdateWWVTAndAttor(mod.C_certificate_no, mod.C_attestor, dtTime);
                }
                else
                {
                    mod.C_attestor = dt.Rows[0]["c_attestor"].ToString();
                    mod.D_visa_dt = DateTime.Parse(dt.Rows[0]["d_visa_dt"].ToString());
                }
            }
            else
            {
                zsNo = randomnumber.GetZZS();
                mod = new Mod_TMD_ZZS_REPRINT()
                {
                    C_lic_pla_no = Json.flaNo,
                    C_stl_grd = Json.stlgrd,//钢种
                    C_std_code = Json.stdcode,//执行标准
                    C_dispatch_id = Json.fyd,//发运单号
                    C_spec = Json.spec,//规格
                    C_attestor = Json.empname,//签证人
                    C_print_templates = Json.mb,//模板
                    C_print_type = Json.printType,//打印     
                    C_certificate_no = zsNo,
                    D_mod_dt = DateTime.Now,
                    D_visa_dt = DateTime.Now,
                    C_remark = Json.bz,
                    N_status = 1,
                    N_type = 2,
                    C_emp_id = vUser.Name
                };
                if (!string.IsNullOrEmpty(mod.C_attestor))
                {
                    tmd_dispatch.AddRePrint(mod);
                }
            }
            #endregion

            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(mod);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult SaveWWZZH([FromBody]dynamic Json)
        {
            AjaxResult result = new AjaxResult();
            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser == null)
            {
                result.Code = DoResult.OverTime;
                result.Result = JsonConvert.SerializeObject("");
                return result;
            }
            var mod = new Mod_TMD_ZZS_REPRINT();
            #region 参数
            string strWhere = " and t.C_TYPE=2 and t.C_SPEC='" + Json.spec + "' and t.C_STL_GRD='" + Json.stlgrd
                + "' and t.C_STD_CODE='" + Json.stdcode + "' and t.C_DISPATCH_ID='" + Json.fyd + "' and t.C_LIC_PLA_NO='" + Json.flaNo + "'";
            DataTable dt = tmd_dispatch.GetRePrintList(strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                mod.C_certificate_no = dt.Rows[0]["c_certificate_no"].ToString();
                mod.C_attestor = dt.Rows[0]["c_attestor"].ToString();
                mod.D_visa_dt = DateTime.Parse(dt.Rows[0]["d_visa_dt"].ToString());
            }
            else
            {
                mod = new Mod_TMD_ZZS_REPRINT()
                {
                    C_lic_pla_no = Json.flaNo,
                    C_stl_grd = Json.stlgrd,//钢种
                    C_std_code = Json.stdcode,//执行标准
                    C_dispatch_id = Json.fyd,//发运单号
                    C_spec = Json.spec,//规格
                    C_attestor = Json.empname,//签证人
                    C_print_templates = Json.mb,//模板
                    C_print_type = Json.printType,//打印
                    C_certificate_no = Json.zsNo,
                    D_mod_dt = DateTime.Now,
                    D_visa_dt = Json.visTime,
                    C_remark = Json.bz,
                    N_status = 1,
                    N_type = 2,
                    C_emp_id = vUser.Name

                };
                tmd_dispatch.AddRePrint(mod);
            }
            #endregion

            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(mod);
            return result;
        }

        #endregion

        #region //质证书基本信息_GetCQInfo
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCQInfo([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            DataTable dt = tmd_dispatchdetails.GetFydInfo(sendCode).Tables[0];
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

        #region //质证书钢种_GetCQStlGrd
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCQStlGrd([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            DataTable dt = tmd_dispatchdetails.GetFydStlGrd(sendCode).Tables[0];
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

        #region //质证书执行标准_GetCQStdCode
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCQStdCode([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            string stlGrd = Json.stlGrd;//钢种
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            DataTable dt = tmd_dispatchdetails.GetFydStdCode(sendCode, stlGrd).Tables[0];
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

        #region //发运单明细_GetCQFyd
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCQFyd([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            string flag = Json.flag;//钢种类型
            string stlGrd = Json.stlGrd;//钢种
            string stdCode = Json.stdCode;//执行标准

            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            DataTable dt = tmd_dispatchdetails.GetFYDList(sendCode, flag, stlGrd, stdCode).Tables[0];
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

        #region //批号成分性能_GetCQCFXN
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCQCFXN([FromBody]dynamic Json)
        {
            #region //参数
            string batchNo = Json.batchNo;//批号
            string stlgrd = Json.stlgrd;//钢种
            string stdcode = Json.stdcode;//执行标准
            string stove = Json.stove;//炉号
            string type = Json.type;//炉号
            #endregion

            #region //数据操作

            AjaxResult result = new AjaxResult();

            DataTable dt = tmd_dispatchdetails.GetBatchCFXN(batchNo.Trim(), stlgrd, stdcode, stove, type).Tables[0];
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

        #endregion

        #region //出库单查询

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetStock([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            string chehao = Json.chehao;//车号
            string startDate = Json.startDate;//开始时间
            string endDate = Json.endDate;//截至时间
            #endregion
            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmd_dispatch.GetStockOut(sendCode, chehao, startDate, endDate).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result.Result = JsonConvert.SerializeObject(dt);
            }
            #endregion

            return result;
        }

        #endregion

        #region //发运单跟踪

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFydTrace([FromBody]dynamic Json)
        {
            #region //参数
            string sendCode = Json.sendCode;//发运单号
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmd_dispatch.GetStockOut(sendCode).Tables[0];
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

        #region //获取PC登录信息

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetUserInfo([FromBody]dynamic Json)
        {

            #region //数据操作

            AjaxResult result = new AjaxResult();

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];
            if (vUser != null)
            {
                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(vUser.Name);
            }
            else
            {
                result.Code = DoResult.Failed;
            }
            #endregion

            return result;
        }
        #endregion

        #region//客户合同执行明细查询
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConFYMC([FromBody]dynamic Json)
        {
            #region //参数
            string con = Json.con;//合同号
            string fyd = Json.fyd;//发运单
            string stlGrd = Json.stlGrd;//钢种
            string spec = Json.spec;//规格
            string batch = Json.batch;//批次
            string startTime = Json.startTime;//出库开始时间
            string endTime = Json.endTime;//出库结束时间
            string custName = Json.custName;//客户名称
            string type = Json.type ?? "0";//0整批，1单卷
            #endregion

            #region //数据操作

            var cust = BaseUser.CustFile;

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmd_dispatch.GetConFYMX_Statistic_Cust(con, custName, fyd, stlGrd, spec, batch, startTime, endTime, cust.C_NO).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion



        #region//客户合同履行表
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetConLX([FromBody]dynamic Json)
        {
            #region //参数
            string conNo = Json.conNO;//合同号
            string stlGrd = Json.stlGrd;//钢种
            int orderType = Json.orderType;//6钢坯/8线材
            string spec = Json.spec;//规格
            #endregion

            #region //数据操作

            var cust = BaseUser.CustFile;

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt = tmo_order.GetConOrderList(cust.C_NAME, conNo, "", stlGrd, "", "", "", "", "", "2", orderType, spec).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }
        #endregion

        #region//客户质证数据列表/预览
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCustZZS([FromBody]dynamic Json)
        {
            #region //参数
            string fyd = Json.fyd;//发运单号
            string zsh = Json.zsh;//证书号
            string batch = Json.batch;//批号
            string ch = Json.ch;//车牌号
            string conNO = Json.conNO;//合同号
            string ckkssj = Json.ckkssj;//出库开始日期
            string ckjssj = Json.ckjssj;//出库结束日期
            string type = Json.type;//8线材/6钢坯
            #endregion

            #region //数据操作

            var cust = BaseUser.CustFile;

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            DataTable dt =trc_roll_prodcut.GetCustZZS(fyd, zsh, batch, ch,conNO, ckkssj, ckjssj, cust.C_NO, type).Tables[0];
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(dt);
            #endregion

            return result;
        }

        /// <summary>
        /// 客户质证书预览
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCustZZSView([FromBody]dynamic Json)
        {
            #region //参数

           
            string zsh = Json.zsh;//证书号
            string batch = Json.batch;//批号
            string stlgrd = Json.stlgrd;//钢种
            string stove = Json.stove;//炉号
            string stdcode = Json.stdcode;//执行标准
            string zldj = Json.zldj;//质量等级
            string fyd = Json.fyd;//发运单号
            string type = Json.type;//8线材/6钢坯
            #endregion

            #region //数据操作



            var cust = BaseUser.CustFile;

            string result = string.Empty;

            if (!string.IsNullOrEmpty(zsh.ToString()))
            {
                string cpt = string.Empty;

                string strpdf = string.Empty;

                DataTable dtpdf = tqc_zzs_file.GetList(batch.ToString(), stlgrd.ToString(), stove.ToString(), stdcode.ToString()).Tables[0];
                if (dtpdf.Rows.Count > 0)
                {
                    strpdf = dtpdf.Rows[0]["PDF"].ToString();
                }


                string[] dj = { "B1", "B2", "C1", "C2" };

                if (dj.Contains(zldj.ToString()))
                {
                    cpt = "ZZS_YCDY_BHG.cpt";
                    string[] arr = { fyd.ToString(), zsh.ToString() };
                    StringBuilder strHtml = new StringBuilder();

                    strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&ZSH={1}", arr);

                    result = strHtml.ToString();
                }
                else
                {

                    string printType = trc_roll_prodcut.GetZZSType(stlgrd.ToString(), stdcode.ToString());
                    switch (printType)
                    {
                        case "1":
                            cpt = "ZZS_YCDY_YL.cpt";
                            break;
                        case "2":
                            cpt = "ZZS_YCDY_RZ_YL.cpt";
                            break;
                        case "3":
                            cpt = "ZZS_YCDY_D_YL.cpt";
                            break;
                        case "4":
                            cpt = "ZZS_YCDY_YL_RBZH.cpt";
                            break;
                        default:
                            cpt = "ZZS_YCDY_YL.cpt";
                            break;

                    }

                    string rownum = trc_roll_prodcut.GetZZSPrintRowNum(stlgrd.ToString(), stdcode.ToString());

                    string[] arr = { fyd.ToString(), rownum, zsh.ToString() };
                    StringBuilder strHtml = new StringBuilder();

                    if (type.ToString() == "8")
                    {
                        strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}", arr);
                    }
                    else
                    {
                        cpt = "ZZS_YCDY_GP_YL.cpt";
                        strHtml.AppendFormat("http://60.6.254.52:8685/webroot/decision/view/report?viewlet=xgcap/" + cpt + "&FYD={0}&COU={1}&ZSH={2}", arr);
                    }



                    //if (!string.IsNullOrEmpty(strpdf))
                    //{
                    //    string pdfpath = NF.Framework.StringFormat.ResolveUrl(strpdf);
                    //    strHtml.AppendFormat(" &nbsp;<a href='{0}' target=\"_blank\" class=\"btn btn-success btn-xs\">金相图片</a>", pdfpath);
                    //}
                  

                    result = strHtml.ToString();
                }
            }

            AjaxResult result2 = new AjaxResult();
            result2.Code = DoResult.Success;
            result2.Result = result;
            #endregion

            return result2;
        }


        #endregion


        #region //火运计划查看日志
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult InertTrainLog([FromBody]dynamic Json)
        {

            Bll_TMC_TRAIN_ITEM tmc_train_item = new Bll_TMC_TRAIN_ITEM();

            var vUser = (NF.Framework.CurrentUser)HttpContext.Current.Session["CurrentUser"];

            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            tmc_train_item.AddExportLog(vUser.Name);

            return result;
        }
        #endregion

    }
}
