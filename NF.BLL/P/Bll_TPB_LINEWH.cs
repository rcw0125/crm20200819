using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 线材库信息
    /// </summary>
    public partial class Bll_TPB_LINEWH
    {
        private readonly Dal_TPB_LINEWH dal = new Dal_TPB_LINEWH();
        public Bll_TPB_LINEWH()
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
        /// 根据仓库编码判断数据是否存在
        /// </summary>
        public bool ExistsByCode(string C_LINEWH_CODE)
        {
            return dal.ExistsByCode(C_LINEWH_CODE);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TPB_LINEWH model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TPB_LINEWH model)
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
        public Mod_TPB_LINEWH GetModel(string C_ID)
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
		public DataSet GetListByStatus(int iStatus)
        {
            return dal.GetListByStatus(iStatus);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TPB_LINEWH> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TPB_LINEWH> DataTableToList(DataTable dt)
        {
            List<Mod_TPB_LINEWH> modelList = new List<Mod_TPB_LINEWH>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TPB_LINEWH model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_ID(string C_LINEWH_CODE, string C_LINEWH_NAME)
        {
            return dal.GetList_ID(C_LINEWH_CODE, C_LINEWH_NAME);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_LINEWH_CODE">仓库编码</param>
        /// <returns></returns>
        public object GetList_id(string C_LINEWH_CODE)
        {
            return dal.GetList_id(C_LINEWH_CODE);
        }
        #endregion  ExtensionMethod
    }
}

