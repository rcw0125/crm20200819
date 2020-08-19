using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 客户档案
    /// </summary>
    public partial class Bll_TS_CUST_SF
    {
        private readonly Dal_TS_CUST_SF dal = new Dal_TS_CUST_SF();
        public Bll_TS_CUST_SF()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string custCode)
        {
            return dal.Exists(custCode);
        }

        /// <summary>
        /// 检查三方关系是否存在
        /// </summary>
        /// <param name="twoCustCode">二级客户</param>
        /// <param name="threeCustCode">三级客户</param>
        /// <returns></returns>
        public bool Exists(string twoCustCode, string threeCustCode)
        {
            return dal.Exists(twoCustCode, threeCustCode);
        }

        /// <summary>
        /// 获取三方数据列表
        /// </summary>
        /// <param name="twoCustCode"></param>
        /// <param name="threeCustCode"></param>
        /// <returns></returns>
        public DataSet GetList(string twoCustCode, string threeCustCode)
        {
            return dal.GetList(twoCustCode, threeCustCode);
        }
        public bool InsertList(Mod_TS_CUST_SF mod)
        {
            return dal.InsertList(mod);
        }

        public bool DelList(List<Mod_TS_CUST_SF> list)
        {
            return dal.DelList(list);
        }

    }
}

