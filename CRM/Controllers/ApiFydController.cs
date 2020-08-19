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
using NF.Framework;

namespace CRM.Controllers
{
    /// <summary>
    /// 发运单
    /// </summary>
    public class ApiFydController : ApiBaseController
    {
        private Bll_TS_DIC ts_dic = new Bll_TS_DIC();
        private Bll_TQB_CHECKSTATE tqb_checkstate = new Bll_TQB_CHECKSTATE();
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();
        private Bll_TMO_ORDER tmo_order = new Bll_TMO_ORDER();
        private Bll_TMD_DISPATCH tmd_dispatch = new Bll_TMD_DISPATCH();


        #region //获取当前钢种-执行标准对应库存量与支数_GetKCWGT
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetKCWGT([FromBody]dynamic Json)
        {
            #region //参数
            string orderID = Json.orderID;//订单主键
            string top = Json.top;//支数
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            if (!string.IsNullOrEmpty(top))
            {
                result.Result = JsonConvert.SerializeObject(tmo_order.GetKCWGT(orderID, top));//获取发运支数库存量
            }
            else
            {
                result.Result = JsonConvert.SerializeObject(tmo_order.GetKCWGT(orderID));//检测当前库存支数是否可发
            }

            #endregion

            return result;
        }
        #endregion


        #region //获取发运单原本支数重量
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFydWgt([FromBody]dynamic Json)
        {
            #region //参数
            string type = Json.type;//订单类型
            string fydid = Json.fydid;//发运明细主键ID
            string top = Json.top;//支数
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmo_order.GetFydWgt(type, fydid, top));//获取发运支数库存量

            #endregion

            return result;
        }
        #endregion

        #region //储运获取发运单原本支数重量
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCyFydWgt([FromBody]dynamic Json)
        {
            #region //参数
            string type = Json.type;//订单类型
            string fydid = Json.fydid;//发运明细主键ID
            string procid = Json.procid;//产品ID
            string delprocid = Json.delprocid;//删除产品ID
            string top = Json.top;//支数

            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmo_order.GetCyFydWgt(type, fydid, procid, delprocid, top));//获取发运支数库存量

            #endregion

            return result;
        }
        #endregion


        #region //线材仓库

        #region //特殊信息
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetSpecial([FromBody]dynamic Json)
        {


            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmo_order.GetTS());

            #endregion

            return result;
        }
        #endregion

        #region //质量等级
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetQuality([FromBody]dynamic Json)
        {


            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tqb_checkstate.GetCheckState("线材"));
            #endregion

            return result;
        }
        #endregion

        #region //区域
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetArea([FromBody]dynamic Json)
        {

            #region //参数
            string quality = Json.quality;//质量
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(quality == "" ? ts_dic.GetDicArea("-1") : tmo_order.GetXCAREA_APP(quality));
            #endregion

            return result;
        }
        #endregion

        #region //小区域
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetArea_Min([FromBody]dynamic Json)
        {
            #region //参数
            string area = Json.area;//区域
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(ts_dic.GetDicArea(area));
            #endregion

            return result;
        }
        #endregion

        #region //线材数据列表
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetRoll_Proc([FromBody]dynamic Json)
        {
            #region //参数
            string batchno = Json.batchno;//批号
            string ckcode = Json.ckcode;//仓库编码
            string stlgrd = Json.stlgrd;//钢种
            string spec = Json.spec;//规格
            string matcode = Json.matcode;//物料编码
            string quality = Json.quality;//质量等级//全部传空值
            string areaMax = Json.areaMax;//大区域：全部传-1
            string areaMin = Json.areaMin;//小区域：全部传空值
            string custName = Json.custName;//客户名称
            string special = Json.special;//特殊属性//全部传空值
            string flag = Json.flag;//待判：Y/N
            string outStartDt = Json.outStartDt;//出库开始时间
            string outEndDt = Json.outEndDt;//出库结束时间
            string isCq = Json.isCq;//不为空显示超期库存
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;

            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(isCq))
            {
                result.Result = JsonConvert.SerializeObject(trc_roll_prodcut.GetRollProdcut_CQ(batchno, ckcode, stlgrd, spec, matcode, quality, areaMax, areaMin, custName, special, flag == "" ? "全部" : flag, outStartDt, outEndDt));
            }
            else
            {
                result.Result = JsonConvert.SerializeObject(trc_roll_prodcut.GetRollProdcut3(batchno, ckcode, stlgrd, spec, matcode, quality, areaMax, areaMin, custName, special, flag == "" ? "全部" : flag, outStartDt, outEndDt));
            }


            #endregion

            return result;
        }
        #endregion


        #region //线材各区域总量/监控/超期
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetRollArea([FromBody]dynamic Json)
        {

            AjaxResult result = new AjaxResult();

            try
            {

                string stlGrd = Json.stlGrd == null ? "" : Json.stlGrd;
                string spec = Json.spec == null ? "" : Json.spec;

                #region //数据操作

                result.Code = DoResult.Success;
                result.Result = JsonConvert.SerializeObject(trc_roll_prodcut.GetRollArea(stlGrd, spec).Tables[0]);
                #endregion
            }
            catch (Exception ex)
            {
                result.Code = DoResult.Success;
                result.Result = ex.Message;
            }

            return result;
        }
        #endregion




        #endregion


        #region 发运统计

        /// <summary>
        /// 获取数字字典
        /// </summary>
        /// <param name="code">编码</param>
        /// <returns></returns>
        private DataTable GetData(string code)
        {
            Mod_TS_DIC mod = new Mod_TS_DIC();
            mod.C_TYPECODE = code;
            DataTable dt = ts_dic.GetList(mod).Tables[0];
            return dt;
        }

        #region //发运方式
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetShipVia([FromBody]dynamic Json)
        {
            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(GetData("ShipVia"));

            #endregion

            return result;
        }
        #endregion

        #region //发运数据列表
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFYStatistic([FromBody]dynamic Json)
        {

            #region //参数
            string fyd = Json.fyd;//发运单号
            string empName = Json.empName;//制单人
            string cph = Json.cph;//车牌号
            string conNO = Json.conNO;//合同号
            string custName = Json.custName;//客户名称
            string matCode = Json.matCode;//物料名称
            string stlGrd = Json.stlGrd;//钢种
            string spec = Json.spec;//规格
            string shipVia = Json.shipVia;//发运方式
            string area = Json.area;//区域
            string zdStart_DT = Json.zdStart_DT;//制单开始时间
            string zdEnd_DT = Json.zdEnd_DT;//制单结束时间
            string quality = Json.quality;//质量等级
            string outStartDt = Json.outStartDt;//出库开始时间
            string outEndDt = Json.outEndDt;//出库结束时间
            string isLineSale = Json.isLineSale == null ? "" : Json.isLineSale;//是否线材销售
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_dispatch.GetFYStatistic(fyd, empName, cph, conNO, custName, matCode, stlGrd, spec, shipVia, area, zdStart_DT, zdEnd_DT, quality, outStartDt, outEndDt, "", "","","","","","","","","","",""));
            #endregion

            return result;
        }

        #endregion

        #region //获取发运各区域量统计
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetFYAreaStatistic([FromBody]dynamic Json)
        {

            #region //参数

            string createStartTime = Json.createStartTime;
            string createEndTime = Json.createEndTime;
            string outStartTime = Json.outStartTime;
            string outEndTime = Json.outEndTime;
            string custName = Json.custName ?? "";//客户名称
            string shipWay = Json.shipWay ?? "";//发运方式
            string isLineSale = Json.isLineSale == null ? "是" : Json.isLineSale;//是否线材销售
            #endregion

            #region //数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_dispatch.GetFyAreaStatistics(createStartTime, createEndTime, outStartTime, outEndTime, custName, shipWay, isLineSale).Tables[0]);
            #endregion

            return result;
        }

        #endregion

        #endregion
    }
}
