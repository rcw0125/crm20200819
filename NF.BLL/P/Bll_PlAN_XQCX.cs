using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NF.MODEL;
using NF.DAL;
using System.Data;
using NF.DLL.P;

namespace NF.BLL.P
{
    public class Bll_PlAN_XQCX
    {
        Dal_PLAN_XQCX dal = new Dal_PLAN_XQCX();
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetChanXian()
        {
            return dal.GetChanXian();
        }

        /// <summary>
        /// 线材计划订单执行情况
        /// </summary>
        /// <param name="C_ORDER_NO"></param>
        /// <param name="C_STL_GRD"></param>
        /// <param name="C_SPEC"></param>
        /// <param name="C_STD_CODE"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet ListPlanData(string C_ORDER_NO, string C_STL_GRD, string C_SPEC, string C_STD_CODE, string start, string end, string area, string matcode, string cust)
        {
            return dal.ListPlanData(C_ORDER_NO, C_STL_GRD, C_SPEC, C_STD_CODE, start, end, area,matcode,cust);
        }

        /// <summary>
        /// 线材订单执行情况
        /// </summary>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <returns></returns>
        public DataSet ListPlanData(string C_ORDER_NO)
        {
            return dal.ListPlanData(C_ORDER_NO);
        }


        /// <summary>
        /// 线材订单执行情况
        /// </summary>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <returns></returns>
        public DataSet ListPlanData2(string C_ORDER_NO)
        {
            return dal.ListPlanData2(C_ORDER_NO);
        }
    }
}
