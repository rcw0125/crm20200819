using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NF.EF.Model;
using NF.Framework.DTO;
using NF.Framework;
using System.Web;
using System.Web.SessionState;

namespace NF.Bussiness.Interface
{
    public interface IComService : IBaseService
    {
        /// <summary>
        /// 获取到站信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        List<TMB_AREADTO> GetStation(string parentID);

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        List<TS_DIC> GetTypeCodeDic(params string[] arr);

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        List<TS_DEPTDTO> GetDetp(string parentID);

        /// <summary>
        /// 刷新页面按钮
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="request"></param>
        void RefreshButton(string url, CurrentUser user, HttpSessionState session);


        /// 获取线材库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        List<TRC_ROLL_PRODCUTDTO> GetRollProducts(string stlGrd, string spec, string area, string stdCode);

        /// <summary>
        /// 获取线材库产品
        /// </summary>
        /// <param name="conDetailNo">订单号</param>
        /// <returns></returns>
        List<TRC_ROLL_PRODCUTDTO> GetRollProducts(string conDetailNo);

        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="area">地区</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, string area, string stdCode);

        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="conDetailNo"></param>
        /// <returns></returns>
        List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, int len, string area, string stdCode, int fNum);

        /// <summary>
        /// 获取钢坯库产品
        /// </summary>
        /// <param name="stlGrd"></param>
        /// <param name="spec"></param>
        /// <param name="len"></param>
        /// <param name="area"></param>
        /// <param name="stdCode"></param>
        /// <returns></returns>
        List<TSC_SLAB_MAINDTO> GetSlabMain(string stlGrd, string spec, string len, string area, string stdCode);

        /// <summary>
        /// 取消线材占位
        /// </summary>
        /// <param name="stoveID"></param>
        void CancelPlace(string stoveID);

        /// <summary>
        /// 线材占位
        /// </summary>
        /// <param name="stoveid"></param>
        /// <returns></returns>
        string TrcPlace(string stoveid);

        /// <summary>
        /// 取消钢坯占位
        /// </summary>
        /// <param name="stoveID"></param>
        void CancelPlaceSecond(string stoveID);

        /// <summary>
        /// 钢坯占位
        /// </summary>
        /// <param name="stoveid"></param>
        /// <returns></returns>
        string TscPlace(string stoveid);

        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="ef"></param>
        void SystemLog(TMB_LOG ef);

    }
}
