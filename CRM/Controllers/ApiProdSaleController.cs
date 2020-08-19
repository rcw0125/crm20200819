using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using CRM.ApiDtos;

using NF.BLL;
using NF.Framework;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    /// <summary>
    /// 产、销报表
    /// </summary>
    public class ApiProdSaleController : ApiBaseController
    {
        private Bll_TRC_ROLL_PRODCUT trc_roll_prodcut = new Bll_TRC_ROLL_PRODCUT();


        #region //生产运营
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetProdSale([FromBody]dynamic Json)
        {


            trc_roll_prodcut.ExeProc();//执行钢坯/线材库存类型

            Prod_Sale_Dto dto = new Prod_Sale_Dto();

            #region //参数

            string date = Json.date;//日期
            #endregion

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            dto.ProdSlabList = DataTableToList(trc_roll_prodcut.GetProdSlab(date).Tables[0]);
            dto.ProdRollList = DataTableToList(trc_roll_prodcut.GetProdRoll(date).Tables[0]);
            dto.SaleShipList = DataTableToList2(trc_roll_prodcut.GetSaleShip(date).Tables[0]);
            dto.SaleRollList = DataTableToList(trc_roll_prodcut.GetSaleRoll(date).Tables[0]);
            dto.SaleSlabList = DataTableToList3(trc_roll_prodcut.GetSaleSlab(date).Tables[0]);
            result.Result = JsonConvert.SerializeObject(dto);

            #endregion


            return result;
        }
        #endregion


        #region //火运车皮计划执行情况
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetHYCP([FromBody]dynamic Json)
        {

            Bll_TMD_HY_PLAN tmd_hy_plan = new Bll_TMD_HY_PLAN();

            #region //参数

            string date = Json.date;//日期
            #endregion

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_hy_plan.GetList(date).Tables[0]);

            #endregion

            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetHYCP2([FromBody]dynamic Json)
        {

            Bll_TMD_HY_PLAN tmd_hy_plan = new Bll_TMD_HY_PLAN();

            #region //参数

            string date = Json.date;//日期
            #endregion

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_hy_plan.GetListFrist(date).Tables[0]);

            #endregion

            return result;
        }

        #endregion

        #region //厂内车皮信息
        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetCNCP([FromBody]dynamic Json)
        {

            Bll_TMD_HY_PLAN tmd_hy_plan = new Bll_TMD_HY_PLAN();

            #region //参数

            string date = Json.date;//日期
            #endregion

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_hy_plan.GetListInfo(date));

            #endregion

            return result;
        }
        #endregion

        #region //销售出库

        [HttpPost]
        [AllowAnonymous]
        public AjaxResult GetSaleOut([FromBody]dynamic Json)
        {

            Bll_TMD_HY_PLAN tmd_hy_plan = new Bll_TMD_HY_PLAN();

            #region //参数

            string date = Json.date;//日期
            #endregion

            #region//数据操作
            AjaxResult result = new AjaxResult();
            result.Code = DoResult.Success;
            result.Result = JsonConvert.SerializeObject(tmd_hy_plan.GetSaleOutList(date));

            #endregion

            return result;
        }
        #endregion


        public List<ModCX> DataTableToList(DataTable dt)
        {
            List<ModCX> modelList = new List<ModCX>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModCX model = new ModCX();

                model.C_TYPE = dt.Rows[i]["C_TYPE"].ToString();
                model.N_WGT_MONTH = dt.Rows[i]["N_WGT_MONTH"].ToString();
                model.N_WGT_DAY = dt.Rows[i]["N_WGT_DAY"].ToString();
                model.N_WGT_CK = dt.Rows[i]["N_WGT_CK"].ToString();
                model.FLAG = dt?.Rows[i]["FLAG"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }

        public List<ModCX> DataTableToList2(DataTable dt)
        {
            List<ModCX> modelList = new List<ModCX>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModCX model = new ModCX();

                model.C_TYPE = dt.Rows[i]["C_TYPE"].ToString();
                model.N_WGT_MONTH = dt.Rows[i]["N_WGT_MONTH"].ToString();
                model.N_WGT_DAY = dt.Rows[i]["N_WGT_DAY"].ToString();
                model.N_WGT_CK = dt.Rows[i]["N_WGT_CK"].ToString();
                modelList.Add(model);
            }
            return modelList;
        }

        public List<ModCX> DataTableToList3(DataTable dt)
        {
            List<ModCX> modelList = new List<ModCX>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModCX model = new ModCX();

                model.C_TYPE = dt.Rows[i]["C_TYPE"].ToString();
                model.N_WGT_MONTH = dt.Rows[i]["N_WGT_MONTH"].ToString();
                model.N_WGT_DAY = dt.Rows[i]["N_WGT_DAY"].ToString();
                model.N_WGT_CK = dt.Rows[i]["N_WGT_CK"].ToString();
                model.FLAG ="Y";
                modelList.Add(model);
            }
            return modelList;
        }


    }
}