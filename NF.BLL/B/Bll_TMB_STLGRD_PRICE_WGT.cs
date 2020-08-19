using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;

namespace NF.BLL
{
    /// <summary>
    /// 地理区域
    /// </summary>
    public partial class Bll_TMB_STLGRD_PRICE_WGT
    {
        private readonly Dal_TMB_STLGRD_PRICE_WGT dal = new Dal_TMB_STLGRD_PRICE_WGT();
        public Bll_TMB_STLGRD_PRICE_WGT()
        { }


        /// <summary>
        /// 销售组织
        /// </summary>
        /// <returns></returns>
        public DataSet GetSaleOrg()
        {
            return dal.GetSaleOrg();
        }
        /// <summary>
        /// 获取每月低毛利限量指标
        /// </summary>
        /// <param name="matname"></param>
        /// <param name="saleorg"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetMonth(string matname, string saleorg, string date, string spec)
        {
            return dal.GetMonth(matname, saleorg, date, spec);
        }

        /// <summary>
        /// 修改低毛利限量指标
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wgt"></param>
        /// <param name="empid"></param>
        /// <param name="empname"></param>
        /// <returns></returns>
        public bool UpdateMonthWgt(string id, string wgt, string empid, string empname)
        {
            return dal.UpdateMonthWgt(id, wgt, empid, empname);
        }

        /// <summary>
        /// 获取NC调价单
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetNCStlGrd(string date)
        {
            return dal.GetNCStlGrd(date);
        }

        /// <summary>
        /// 生成当月低毛利限制指标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertMonthStlGrd(List<Mod_TMB_STLGRD_PRICE_WGT> list)
        {
            return dal.InsertMonthStlGrd(list);
        }

        /// <summary>
        /// 修改低毛利限量指标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateMonthWgt(List<Mod_TMB_STLGRD_PRICE_WGT> list)
        {
            return dal.UpdateMonthWgt(list);
        }


        /// <summary>
        /// 更新订单毛利/成本
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="maoli"></param>
        /// <param name="cost"></param>
        public void UpdateOrderMAOLI(string conno)
        {
            dal.UpdateOrderMAOLI(conno);
        }
        /// <summary>
        /// 检测每条订单是否低毛利
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <param name="date">合同生效起始日期</param>
        /// <returns></returns>
        public bool CheckMAOLI(string orderID, string matCode, string date)
        {
            return dal.CheckMAOLI(orderID, matCode, date);
        }

        /// 低毛利订单录入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertMAOLI(List<Mod_TMO_LOWMAOLI_ORDER> list)
        {
            return dal.InsertMAOLI(list);
        }

        /// <summary>
        /// 获取低毛利订单
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="stlgrd"></param>
        /// <param name="saleorg"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetOrderMAOLI(string cust, string stlgrd, string saleorg, string date)
        {
            return dal.GetOrderMAOLI(cust, stlgrd, saleorg, date);
        }

    }
}

