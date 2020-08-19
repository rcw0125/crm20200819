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
    public partial class Bll_TMB_NCADDRESS_COST
    {
        private readonly Dal_TMB_NCADDRESS_COST dal = new Dal_TMB_NCADDRESS_COST();
        public Bll_TMB_NCADDRESS_COST()
        { }

        /// <summary>
        /// 获取到货地点档案
        /// </summary>
        /// <param name="areaID"></param>
        /// <returns></returns>
        public DataSet GetList(string areaID)
        {
            return dal.GetList(areaID);
        }

        /// <summary>
        /// 获取到货地点运费信息
        /// </summary>
        /// <param name="cys">承运商</param>
        /// <param name="fy">发运方式</param>
        /// <param name="addr">到货地点</param>
        /// <returns></returns>
        public DataSet GetList(string fy, string addr)
        {
            return dal.GetList(fy, addr);
        }

        /// <summary>
        /// 获取到货地点运费信息
        /// </summary>
        /// <param name="cys">承运商</param>
        /// <param name="fy">发运方式</param>
        /// <param name="addr">到货地点</param>
        /// <returns></returns>
        public DataSet GetAddr( string fy, string addr)
        {
            return dal.GetAddr( fy, addr);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists( string fyfs, string addr)
        {
            return dal.Exists(fyfs, addr);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Add(List<Mod_TMB_NCADDRESS_COST> list)
        {
            return dal.Add(list);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mod">修改参数：费用，生效日期，失效日期，修改人</param>
        /// <returns></returns>
        public bool Update(Mod_TMB_NCADDRESS_COST mod)
        {
            return dal.Update(mod);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="mod">修改参数：费用，生效日期，失效日期，修改人</param>
        /// <returns></returns>
        public bool UpdateList(List<Mod_TMB_NCADDRESS_COST> list)
        {
            return dal.UpdateList(list);
        }

        public bool Del(List<Mod_TMB_NCADDRESS_COST> list)
        {
            return dal.Del(list);
        }

    }
}

