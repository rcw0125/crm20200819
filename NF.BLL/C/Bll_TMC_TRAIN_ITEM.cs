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
    public partial class Bll_TMC_TRAIN_ITEM
    {
        private readonly Dal_TMC_TRAIN_ITEM dal = new Dal_TMC_TRAIN_ITEM();
        public Bll_TMC_TRAIN_ITEM()
        { }


        public bool Del(Mod_TMC_TRAIN_ITEM mod)
        {
            return dal.Del(mod);
        }

        /// <summary>
        /// 删除计划号
        /// </summary>
        /// <param name="C_ID"></param>
        /// <returns></returns>
        public bool DelTrainPlan(string C_ID)
        {
            return dal.DelTrainPlan(C_ID);
        }
        /// <summary>
        /// 火运计划号录入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddTrainPlan(List<Mod_TMC_TRAIN> list)
        {
            return dal.AddTrainPlan(list);
        }

        /// <summary>
        /// 火运发运日计划申请
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool AddTrain(List<Mod_TMC_TRAIN_ITEM> list)
        {
            return dal.AddTrain(list);
        }
        /// <summary>
        /// 火运计划(内/外)申请
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Add(Mod_TMC_TRAIN_ITEM mod)
        {
            return dal.Add(mod);
        }

        /// <summary>
        /// 获取计划号
        /// </summary>
        /// <param name="planNo"></param>
        /// <param name="station"></param>
        /// <param name="cust"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public DataSet GetTrainPlan(string planNo, string station, string cust, string startDT, string endDT, string emp,string type)
        {
            return dal.GetTrainPlan(planNo, station, cust, startDT, endDT, emp,type);
        }

        /// <summary>
        /// 获取火运报备计划-发运日计划申请
        /// </summary>
        /// <param name="conno"></param>
        /// <returns></returns>
        public DataSet GetTrain(string conno, string stlgrd, string spec, string custname, string startdt, string enddt, string area)
        {
            return dal.GetTrain(conno, stlgrd, spec, custname, startdt, enddt, area);
        }
        /// <summary>
        /// 获取火运计划(内/外)列表
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="cust"></param>
        /// <param name="custno"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <param name="conno"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataSet GetList(string empID, string cust, string custno, string startDT, string endDT, string conno, string flag)
        {
            return dal.GetList(empID, cust, custno, startDT, endDT, conno, flag);
        }
        /// <summary>
        /// 获取火运日计划列表
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="cust"></param>
        /// <param name="custno"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <param name="conno"></param>
        /// <param name="flag"></param>
        /// <param name="plancode"></param>
        /// <param name="stlgrd"></param>
        /// <returns></returns>
        public DataSet GetList(string empID, string cust, string custno, string startDT, string endDT, string conno, string plancode, string stlgrd, string area)
        {
            return dal.GetList(empID, cust, custno, startDT, endDT, conno, plancode, stlgrd, area);
        }
        /// <summary>
        /// 导出日志
        /// </summary>
        /// <param name="dt"></param>
        public void AddExportLog(string empName)
        {
            dal.AddExportLog(empName);
        }
    }
}

