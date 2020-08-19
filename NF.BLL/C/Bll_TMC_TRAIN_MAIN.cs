using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 质证书附件
    /// </summary>
    public partial class Bll_TMC_TRAIN_MAIN
    {
        private readonly Dal_TMC_TRAIN_MAIN dal = new Dal_TMC_TRAIN_MAIN();
        public Bll_TMC_TRAIN_MAIN()
        { }

        /// <summary>
        /// 删除火运日计划计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Del(string C_ID)
        {
            return dal.Del(C_ID);
        }

        /// <summary>
        /// 批量删除火运计划具体钢种信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Del_ITEM(List<Mod_TMC_TRAIN_ITEM> list)
        {
            return dal.Del_ITEM(list);
        }
        /// <summary>
        /// 添加火运日计划单据号
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Insert(Mod_TMC_TRAIN_MAIN mod)
        {
            return dal.Insert(mod);
        }

        /// <summary>
        /// 火运发运日计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool AddTrainDay(List<Mod_TMC_TRAIN_ITEM> list)
        {
            return dal.AddTrainDay(list);
        }

        /// <summary>
        /// 更新火运日计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateTrainDay(Mod_TMC_TRAIN_MAIN mod, List<Mod_TMC_TRAIN_ITEM> list)
        {
            return dal.UpdateTrainDay(mod, list);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_TRAIN_MAIN GetModel(string C_ID)
        {
            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获取火运日计划数据列表
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="station"></param>
        /// <param name="planno"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public DataSet GetList(string empID, string station, string planno, string startDT, string endDT)
        {
            return dal.GetList(empID, station, planno, startDT, endDT);
        }

        /// <summary>
        /// 获取火运计划子表数据
        /// </summary>
        /// <param name="pkID"></param>
        /// <returns></returns>
        public DataSet GetList(string pkID)
        {
            return dal.GetList(pkID);
        }

        /// <summary>
        /// 批量火运/汽运审核
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateTrainMain(List<string> list, string emp)
        {
            return dal.UpdateTrainMain(list, emp);
        }

        /// <summary>
        /// 火运/汽运审核
        /// </summary>
        /// <param name="fyd">发运单</param>
        /// <param name="emp">制单人</param>
        /// <param name="conno">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="ischeck">是否审核</param>
        /// <param name="flag">是否监控</param>
        /// <param name="startDT">提报开始时间</param>
        /// <param name="endDT">提报截至时间</param>
        /// <returns></returns>
        public DataSet GetTrainMain(string fyd, string emp, string conno, string cust, string stlgrd, string spec, string ischeck, string flag, string startDT, string endDT, string fyfs, string station, string area, string xfwgt)
        {
            return dal.GetTrainMain(fyd, emp, conno, cust, stlgrd, spec, ischeck, flag, startDT, endDT, fyfs, station, area, xfwgt);
        }
    }
}

