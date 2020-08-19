using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NF.DAL;
using NF.MODEL;

namespace NF.BLL
{
    public class Bll_TMB_PROC
    {
        private readonly Dal_TMB_PROC dal = new Dal_TMB_PROC();
        public Bll_TMB_PROC() { }

        /// <summary>
        /// 获取产品类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetProcType()
        {
            return dal.GetProcType();
        }
        /// <summary>
        /// 添加产品类型
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool AddProcType(string name)
        {
            return dal.AddProcType(name);
        }
        /// <summary>
        ///更新产品类型
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="status">0正常，1停用</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool UpdateProcType(string name, string status, string id)
        {
            return dal.UpdateProcType(name, status, id);
        }
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="procType">产品类型</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetProcList(string procType, string stlGrd, string pageIndex, string pageSize)
        {
            return dal.GetProcList(procType, stlGrd, pageIndex, pageSize);
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>

        /// <returns></returns>
        public DataSet GetProcList(string id)
        {
            return dal.GetProcList(id);
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="mod">产品属性</param>
        /// <returns></returns>
        public bool AddProc(Mod_TMB_PROC mod)
        {
            return dal.AddProc(mod);
        }
        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="mod">产品属性</param>
        /// <returns></returns>
        public bool UpdateProc(Mod_TMB_PROC mod)
        {
            return dal.UpdateProc(mod);
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelProc(string id)
        {
            return dal.DelProc(id);
        }

    }
}
