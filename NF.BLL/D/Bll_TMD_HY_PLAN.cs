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
    public partial class Bll_TMD_HY_PLAN
    {
        private readonly Dal_TMD_HY_PLAN dal = new Dal_TMD_HY_PLAN();


        public Bll_TMD_HY_PLAN() { }


        public bool Del(Mod_TMD_HY_PLAN mod)
        {
            return dal.Del(mod);
        }
        public DataSet GetListFrist(string date)
        {
            return dal.GetListFrist(date);
        }

        /// <summary>
        /// 火运车皮计划执行情况
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetList(string date)
        {
            return dal.GetList(date);
        }

        /// <summary>
        /// 添加/更新
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(Mod_TMD_HY_PLAN mod)
        {
            return dal.Insert_Update(mod);
        }
        /// <summary>
        /// 添加/更新
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(List<Mod_TMD_HY_PLAN> list)
        {
            return dal.Insert_Update(list);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DelList(List<Mod_TMD_HY_PLAN> list)
        {
            return dal.DelList(list);
        }


        /// <summary>
        /// 厂内车皮信息
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetListInfo(string date)
        {
            return dal.GetListInfo(date);
        }


        /// <summary>
        /// 添加/更新厂内车皮信息
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update_Info(List<Mod_TMD_HY_INFO> list)
        {
            return dal.Insert_Update_Info(list);
        }


        /// <summary>
        /// 批量删除厂内车皮信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DelList_Info(List<Mod_TMD_HY_INFO> list)
        {
            return dal.DelList_Info(list);
        }

        public DataSet GetSaleOutList(string date)
        {
            return dal.GetSaleOutList(date);
        }

    }
}
