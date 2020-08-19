using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 发运单
    /// </summary>
    public partial class Bll_TMD_DISPATCH
    {
        private readonly Dal_TMD_DISPATCH dal = new Dal_TMD_DISPATCH();
        public Bll_TMD_DISPATCH()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            return dal.Exists(C_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_DISPATCH model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMD_DISPATCH model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            return dal.Delete(C_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMD_DISPATCH GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string sfbj)
        {
            return dal.GetList(sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime, sfbj);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_WL(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string sfbj, string ischeck)
        {
            return dal.GetList_WL(sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime, sfbj, ischeck);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMD_DISPATCH> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMD_DISPATCH> DataTableToList(DataTable dt)
        {
            List<Mod_TMD_DISPATCH> modelList = new List<Mod_TMD_DISPATCH>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMD_DISPATCH model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime)
        {
            return dal.GetRecordCount(sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <param name="cheHao">车号</param>
        /// <param name="custName">客户</param>
        /// <param name="empName">制单人</param>
        /// <param name="fyFS">发运方式</param>
        /// <param name="YN">是否线材销售</param>
        /// <param name="startTime">制单开始时间</param>
        /// <param name="endTime">制单截至时间</param>
        /// <param name="dz">到站</param>
        /// <returns></returns>
        public int GetRecordCount(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string dz)
        {
            return dal.GetRecordCount(sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime, dz);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="startIndex">起始页数</param>
        /// <param name="sendCode">发运单号</param>
        /// <param name="cheHao">车号</param>
        /// <param name="custName">客户</param>
        /// <param name="empName">制单人</param>
        /// <param name="fyFS">发运方式</param>
        /// <param name="YN">是否线材销售</param>
        /// <param name="startTime">制单开始时间</param>
        /// <param name="endTime">制单截至时间</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime)
        {
            return dal.GetListByPage(pageSize, startIndex, sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="startIndex">起始页数</param>
        /// <param name="sendCode">发运单号</param>
        /// <param name="cheHao">车号</param>
        /// <param name="custName">客户</param>
        /// <param name="empName">制单人</param>
        /// <param name="fyFS">发运方式</param>
        /// <param name="YN">是否线材销售</param>
        /// <param name="startTime">制单开始时间</param>
        /// <param name="endTime">制单截至时间</param>
        /// <param name="dz">到站</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string dz)
        {
            return dal.GetListByPage(pageSize, startIndex, sendCode, cheHao, custName, empName, fyFS, YN, startTime, endTime, dz);
        }

        #endregion  BasicMethod

        /// <summary>
        /// 出库单查询
        /// </summary>
        /// <param name="sendCode"></param>
        /// <param name="chehao"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataSet GetStockOut(string sendCode, string chehao, string startDate, string endDate)
        {
            return dal.GetStockOut(sendCode, chehao, startDate, endDate);
        }
        /// <summary>
        /// 出库单查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetStockOut(string sendCode)
        {
            return dal.GetStockOut(sendCode);
        }

        /// <summary>
        /// 修改钢坯销售出库量
        /// </summary>
        /// <param name="list">参数 ID，发运单号，净重</param>
        /// <returns></returns>
        public bool UpdateStockOut(List<Mod_TMD_DISPATCH_SJZJB> list)
        {
            return dal.UpdateStockOut(list);
        }

        /// <summary>
        /// 获取仓库主键
        /// </summary>
        /// <param name="code">仓库编码</param>
        /// <returns></returns>
        public DataRow GetStock(string code)
        {
            return dal.GetStock(code);
        }


        /// <summary>
        ///批量添加发运单
        /// </summary>
        /// <param name="modhead">表头</param>
        /// <param name="item">表体</param>
        /// <returns></returns>
        public bool InsertFYD(Mod_TMD_DISPATCH modhead, List<Mod_TMD_DISPATCHDETAILS> item)
        {
            return dal.InsertFYD(modhead, item);
        }

        /// <summary>
        /// 单条插入发运单表体数据
        /// </summary>
        /// <param name="item">表体参数</param>
        /// <returns></returns>
        public bool InsertFYD_ITEM(List<Mod_TMD_DISPATCHDETAILS> item)
        {
            return dal.InsertFYD_ITEM(item);
        }

        /// <summary>
        /// 批量更新发运单
        /// </summary>
        /// <param name="modhead"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateFYD(Mod_TMD_DISPATCH modhead, List<Mod_TMD_DISPATCHDETAILS> item)
        {
            return dal.UpdateFYD(modhead, item);
        }

        /// <summary>
        ///执行线材库销售S,发运单状态8线材实绩已导入NC
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="status">状态</param>
        /// <param name="empid">操作人ID</param>
        /// <param name="empName">操作人姓名</param>
        /// <returns></returns>
        public bool UpdateFydWW(string sendcode, int status, string empid, string empName)
        {
            return dal.UpdateFydWW(sendcode, status, empid, empName);
        }

        /// <summary>
        /// 批量删除发运单与明细
        /// </summary>
        /// <param name="sendcode"></param>
        /// <returns></returns>
        public bool DelFYD(string sendcode, string empID)
        {
            return dal.DelFYD(sendcode, empID);
        }

        /// <summary>
        /// 更新发运单导入条码次数
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="num">当前次数</param>
        /// <returns></returns>
        public bool UpdateFydRF_Num(string sendcode, string num)
        {
            return dal.UpdateFydRF_Num(sendcode, num);
        }

        /// <summary>
        /// 物流车号录入
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="ch">车牌号</param>
        /// <returns></returns>
        public bool UpdateFyd_CH_WL(Mod_TMD_DISPATCH modhead)
        {
            return dal.UpdateFyd_CH_WL(modhead);
        }

        /// <summary>
        /// 更新发运单车牌号
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="ch">车牌号</param>
        /// <returns></returns>
        public bool UpdateFyd_CH(Mod_TMD_DISPATCH modhead)
        {
            return dal.UpdateFyd_CH(modhead);
        }

        /// <summary>
        /// 更新发运单状态
        /// </summary>
        /// <param name="sendcode">发运单单据号</param>
        /// <param name="status">发运单状态 0自由状态 2已导入NC 3已导入条码 4已导入物流 7 已做实绩，8线材实绩已导入NC，9钢坯实绩已导入NC，10审核</param>
        /// <param name="mod">参数</param>
        /// <param name="flag">1保存，2审批,3其他</param>
        /// <returns></returns>
        public bool UpdateFydStatus(string sendcode, int status, string empid, string empName, string flag)
        {
            return dal.UpdateFydStatus(sendcode, status, empid, empName, flag);
        }

        /// <summary>
        /// 检测NC是否删除发运单
        /// </summary>
        /// <param name="ncpk">NC主键</param>
        /// <returns></returns>
        public bool DelNCFYD(string ncpk)
        {
            return dal.DelNCFYD(ncpk);
        }
        /// <summary>
        /// 检测条码是否删除发运单
        /// </summary>
        /// <param name="ncpk"></param>
        /// <returns></returns>
        public bool DelRFFYD(string ncpk)
        {
            return dal.DelRFFYD(ncpk);
        }

        /// <summary>
        /// 检测NC是否关闭发运单
        /// </summary>
        /// <param name="ncpk">发运单号</param>
        /// <returns></returns>
        public bool DelNCFYD_GP(string ncpk)
        {
            return dal.DelNCFYD_GP(ncpk);
        }

        /// <summary>
        /// 质证书/出库单打印
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="cph">车牌号</param>
        /// <param name="ysfs">发运方式</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库结束时间</param>
        /// <returns></returns>
        public DataSet GetPrintInfo(string fyd, string cph, string ysfs, string startDate, string endDate, string batch, int printStatus, string attostor, string cno, string mb)
        {
            return dal.GetPrintInfo(fyd, cph, ysfs, startDate, endDate, batch, printStatus, attostor, cno, mb);
        }
        public DataSet GetWWPrintInfo(string fyd, string cph, string ysfs, string batch, string qzr, int printStatus, string start, string end)
        {
            return dal.GetWWPrintInfo(fyd, cph, ysfs, batch, qzr, printStatus, start, end);
        }



        #region //发运统计

        /// <summary>
        /// 发运统计
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="zhidanren">制单人</param>
        /// <param name="cph">车牌号</param>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="fyfs">发运方式</param>
        /// <param name="area">区域</param>
        /// <param name="zdStart_DT">制单开始日期</param>
        /// <param name="zdEnd_DT">制单结束日期</param>
        /// <param name="isLineSale">是否线材销售</param>
        /// <param name="dz">到站</param>
        /// <param name="addr">到货地点</param>
        /// <param name="ztRF">是否导入条码</param>
        /// <param name="rfexe">条码执行状态</param>
        /// <param name="gps">gps号</param>
        /// <param name="jckssj">进厂开始时间</param>
        /// <param name="jcjssj">进厂结束时间</param>
        /// <param name="cckssj">出厂开始时间</param>
        /// <param name="ccjssj">出厂结束时间</param>
        /// <param name="cys">承运商</param>
        /// <returns></returns>
        public DataSet GetFYStatistic(string fyd, string zhidanren, string cph, string con, string cust, string matCode, string stlGrd, string spec, string fyfs, string area, string zdStart_DT, string zdEnd_DT, string judge_Lev_Zh, string ckStart_DT, string ckEnd_DT, string isLineSale, string sfbd, string dz, string addr, string ztRF, string rfexe, string gps, string jckssj, string jcjssj, string cckssj, string ccjssj, string cys)
        {
            return dal.GetFYStatistic(fyd, zhidanren, cph, con, cust, matCode, stlGrd, spec, fyfs, area, zdStart_DT, zdEnd_DT, judge_Lev_Zh, ckStart_DT, ckEnd_DT, isLineSale, sfbd, dz, addr, ztRF, rfexe, gps, jckssj, jcjssj, cckssj, ccjssj, cys);
        }

        /// <summary>
        /// 获取发运区域统计
        /// </summary>
        /// <param name="createStartTime"></param>
        /// <param name="createEndTime"></param>
        /// <param name="outStartTime"></param>
        /// <param name="outEndTime"></param>
        /// <returns></returns>
        public DataSet GetFyAreaStatistics(string createStartTime, string createEndTime, string outStartTime, string outEndTime, string custName, string shipWay, string isLineSale)
        {
            return dal.GetFyAreaStatistics(createStartTime, createEndTime, outStartTime, outEndTime, custName, shipWay, isLineSale);
        }
        #endregion

        #region //客户按整批次查询

        /// <summary>
        /// 合同发运执行明细表
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic_Cust(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            return dal.GetConFYMX_Statistic_Cust(con, cust, fyd, stlgrd, spec, batch, ckkssj, ckjssj, empid);
        }
        #endregion

        #region //客户单卷明细查询

        /// <summary>
        /// 客户单卷明细查询
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic_Cust2(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            return dal.GetConFYMX_Statistic_Cust2(con, cust, fyd, stlgrd, spec, batch, ckkssj, ckjssj, empid);
        }
        #endregion

        #region //合同发运执行明细表
        /// <summary>
        /// 合同发运执行明细表
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            return dal.GetConFYMX_Statistic(con, cust, fyd, stlgrd, spec, batch, ckkssj, ckjssj, empid);
        }
        #endregion


        #region //插入发运指标
        /// <summary>
        /// 发运指标
        /// </summary>
        /// <param name="list">参数：部门，数量，日期</param>
        /// <returns></returns>
        public bool InsertFYZB(List<Mod_TMD_FYZB> list)
        {
            return dal.InsertFYZB(list);
        }

        /// <summary>
        /// 发运单-每日发运指标控制
        /// </summary>
        /// <param name="area">区域</param>
        /// <param name="fywgt">当前发运量</param>
        /// <returns></returns>
        public bool GetAreaFyZb(string area, decimal fywgt)
        {
            return dal.GetAreaFyZb(area, fywgt);
        }

        /// <summary>
        ///获取发运指标数据列表
        /// </summary>
        /// <param name="date">发运日期</param>
        /// <returns></returns>
        public DataSet GetAreaFyZbList(string date)
        {
            return dal.GetAreaFyZbList(date);
        }
        /// <summary>
        /// 更新发运指标
        /// </summary>
        /// <param name="list">参数</param>
        /// <param name="flag">flag 1修改指标，2汽运/火运/超期发运录入，3 控制发运</param>
        /// <returns></returns>
        public bool UpdateAreaFyZb(List<Mod_TMD_FYZB> list, int flag)
        {
            return dal.UpdateAreaFyZb(list, flag);
        }

        /// <summary>
        /// 发运指标日报表查询
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetFyZbDay(string date, string zzb, string jkzb, string cqzb)
        {
            return dal.GetFyZbDay(date, zzb, jkzb, cqzb);
        }

        /// <summary>
        /// 发运指标日报表查询-2次指标预览
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetFyZbView(string date, string zzb, string jkzb, string cqzb)
        {
            return dal.GetFyZbView(date, zzb, jkzb, cqzb);
        }
        #endregion

        #region //PCI
        /// <summary>
        /// 获取钢坯发运单
        /// </summary>
        /// <param name="C_ID">发运单号</param>
        /// <param name="dt1">时间1</param>
        /// <param name="dt2">时间2</param>
        /// <param name="status">状态</param>
        /// <param name="cph">车牌号</param>
        /// <returns></returns>
        public DataSet GetFYDList(string C_ID, DateTime dt1, DateTime dt2, string status, string cph, string movetype)
        {
            return dal.GetFYDList(C_ID, dt1, dt2, status, cph, movetype);
        }

        #endregion
        /// <summary>
        /// 变更发运单
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="empid">操作人id</param>
        /// <param name="empName">操作人名称</param>
        /// <param name="sendcode">发运单号</param>
        /// <returns></returns>
        public int UPFYD(string status, string empid, string empName, string sendcode)
        {
            return dal.UPFYD(status, empid, empName, sendcode);
        }

        #region //同步条码入厂时间/装车状态/出厂时间

        /// <summary>
        /// 制单时间同步条码信息
        /// </summary>
        /// <param name="kssj"></param>
        /// <param name="jssj"></param>
        /// <returns></returns>
        public bool TBRFFYD(string kssj, string jssj)
        {
            return dal.TBRFFYD(kssj, jssj);
        }

        /// <summary>
        /// 出库时间同步条码信息
        /// </summary>
        /// <param name="kssj"></param>
        /// <param name="jssj"></param>
        /// <returns></returns>
        public bool TBRFFYD2(string kssj, string jssj)
        {
            return dal.TBRFFYD2(kssj, jssj);
        }
        #endregion

        #region //自动生成火运/汽运日计划
        public bool AddTrainPlan(Mod_TMC_TRAIN_MAIN mod, List<Mod_TMC_TRAIN_ITEM> list)
        {
            return dal.AddTrainPlan(mod, list);
        }
        #endregion
    }
}

