using NF.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class APPRptController : Controller
    {
        Bll_TMO_ORDER bll = new Bll_TMO_ORDER();


        [AllowAnonymous]
        public JsonResult StatiChartCust(string cus, DateTime? begin, DateTime? end)
        {
            if (begin.HasValue == false)
            {
                begin = DateTime.Today.AddMonths(-6);
                end = DateTime.Today;
            }
            var list = bll.GetCusChart(cus, begin.Value, end.Value);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult StatiChartGrd(string stdGrd, DateTime? begin, DateTime? end)
        {
            begin = DateTime.Today.AddYears(-1);
            end = DateTime.Today;
            var list = bll.StatiChartGrd(stdGrd, begin.Value, end.Value);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 产品类型_GetProcType
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult GetProcType()
        {
            try
            {
                var result = bll.GetProductType();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(Enumerable.Empty<string>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 产品列表_GetProcList
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult GetProcList(string type = "", string gz = "")
        {
            try
            {
                var result = bll.GetProduct(type, gz, 1, 1);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(Enumerable.Empty<string>(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}