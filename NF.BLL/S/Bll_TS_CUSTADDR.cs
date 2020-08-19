using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;

namespace NF.BLL
{
    /// <summary>
    /// 客户地址
    /// </summary>
    public partial class Bll_TS_CUSTADDR
    {
        private readonly Dal_TS_CUSTADDR dal = new Dal_TS_CUSTADDR();
        public Bll_TS_CUSTADDR()
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
        public bool Add(Mod_TS_CUSTADDR model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_CUSTADDR model)
        {
            return dal.Update(model);
        }

        /// <summary>
		/// 更新默认值
		/// </summary>
		public bool UpdateISDEFAULTNotIn(string C_ID, int ISDEFAULT)
        {
            return dal.UpdateISDEFAULTNotIn(C_ID, ISDEFAULT);
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
        public Mod_TS_CUSTADDR GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAddrList(string cust_id, string N_ISDEFAULT)
        {
            return dal.GetAddrList(cust_id, N_ISDEFAULT);
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
        public List<Mod_TS_CUSTADDR> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_CUSTADDR> DataTableToList(DataTable dt)
        {
            List<Mod_TS_CUSTADDR> modelList = new List<Mod_TS_CUSTADDR>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TS_CUSTADDR model;
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod


        #region //自定义

        /// <summary>
        /// 根据主键获取地址名称
        /// </summary>
        /// <param name="ncid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataRow GetAddrName(string C_CGADDR)
        {
            return dal.GetAddrName(C_CGADDR);
        }
        /// <summary>
        /// 获取客户地址NC主键
        /// </summary>
        /// <param name="ncid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataRow GetAddr(string ncid, string name)
        {
            return dal.GetAddr(ncid, name);
        }
        /// <summary>
        /// 获取客户收货地址
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="nc_id">NC客商档案主键</param>
        /// <param name="nc_m_id">NC客商管理档案主键</param>
        /// <param name="no">客商编号</param>
        /// <param name="flag">标识：0或1默认值</param>
        /// <returns></returns>
        public DataSet GetAddr(string id, string nc_id, string nc_m_id, string no, string flag)
        {
            return dal.GetAddr(id, nc_id, nc_m_id, no, flag);
        }
        #endregion
    }
}

