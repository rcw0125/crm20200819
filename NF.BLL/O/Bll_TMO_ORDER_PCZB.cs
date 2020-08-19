using NF.DAL;
using NF.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.BLL
{
    /// <summary>
    /// 订单排产指标
    /// </summary>
    public partial class Bll_TMO_ORDER_PCZB
    {
        private readonly Dal_TMO_ORDER_PCZB dal = new Dal_TMO_ORDER_PCZB();

        public Bll_TMO_ORDER_PCZB() { }


        /// <summary>
        /// 校验当前区域下发订单是否满足排产指标
        /// </summary>
        /// <param name="wgt">订单排产量</param>
        /// <param name="area">区域</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool CheckStl_Grd_ZB(decimal wgt, string area, string orderNo, string xday)
        {
            return dal.CheckStl_Grd_ZB(wgt, area, orderNo, xday);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string startDt, string endDt)
        {
            return dal.Exists(startDt, endDt);
        }

        /// <summary>
        /// 获取订单排产指标
        /// </summary>
        /// <param name="startDt">计划开始日期</param>
        /// <param name="endDt">计划截至日期</param>
        /// <returns></returns>
        public DataSet GetList(string startDt)
        {
            return dal.GetList(startDt);
        }

        /// <summary>
        /// 获取订单排产指标
        /// </summary>
        /// <param name="startDt">计划开始日期</param>
        /// <param name="endDt">计划截至日期</param>
        /// <returns></returns>
        public DataSet GetList(string startDt, string endDt, int n_type)
        {
            return dal.GetList(startDt, endDt, n_type);
        }

        /// <summary>
        /// 获取下旬指标
        /// </summary>
        /// <param name="endDt">计划日期</param>
        /// <param name="area">区域</param>
        /// <returns></returns>
        public DataSet GetZB(string endDt, string area)
        {
            return dal.GetZB(endDt, area);
        }

        #region 添加/更新指标2
        /// <summary>
        /// 添加/更新指标
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update2(List<Mod_TMO_ORDER_PCZB> list)
        {
            return dal.Insert_Update2(list);
        }

        /// <summary>
        /// 添加/更新指标
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(List<Mod_TMO_ORDER_PCZB> list)
        {
            return dal.Insert_Update(list);
        }

        /// <summary>
        /// 指标控制
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateFlag(List<Mod_TMO_ORDER_PCZB> list)
        {
            return dal.UpdateFlag(list);
        }

        /// <summary>
        /// 删除当月旬指标
        /// </summary>
        /// <param name="endDt">提报日期</param>
        /// <param name="type">旬1上旬，2中旬，3下旬</param>
        /// <returns></returns>
        public bool DelZB(string endDt, int type)
        {
            return dal.DelZB(endDt, type);
        }

        /// <summary>
        /// 删除当月旬指标
        /// </summary>
        /// <param name="endDt">提报日期</param>
        /// <param name="type">旬1上旬，2中旬，3下旬</param>
        /// <returns></returns>
        public bool DelZB2(List<Mod_TMO_ORDER_PCZB> list)
        {
            return dal.DelZB2(list);
        }
        #endregion
    }
}
