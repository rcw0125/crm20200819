using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;

namespace NF.BLL
{
    /// <summary>
    /// 客户开票单位
    /// </summary>
    public partial class Bll_TS_CUSTOTCOMPANY
    {
        private readonly Dal_TS_CUSTOTCOMPANY dal = new Dal_TS_CUSTOTCOMPANY();
        public Bll_TS_CUSTOTCOMPANY()
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
        public bool Add(Mod_TS_CUSTOTCOMPANY model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_CUSTOTCOMPANY model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
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
        public Mod_TS_CUSTOTCOMPANY GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获取开票单位
        /// </summary>
        /// <param name="C_CUST_ID"></param>
        /// <param name="N_ISDEFAULT"></param>
        /// <returns></returns>
        public DataSet GetOT(string C_CUST_ID, string N_ISDEFAULT)
        {
            return dal.GetOT(C_CUST_ID, N_ISDEFAULT);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_CUST_ID)
        {
            return dal.GetList(C_CUST_ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_CUSTOTCOMPANY> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_CUSTOTCOMPANY> DataTableToList(DataTable dt)
        {
            List<Mod_TS_CUSTOTCOMPANY> modelList = new List<Mod_TS_CUSTOTCOMPANY>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TS_CUSTOTCOMPANY model;
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

    }
}

