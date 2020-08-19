using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 钢坯库信息
    /// </summary>
    public partial class Bll_TPB_SLABWH
    {
        private readonly Dal_TPB_SLABWH dal = new Dal_TPB_SLABWH();
        public Bll_TPB_SLABWH()
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
        public bool Add(Mod_TPB_SLABWH model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TPB_SLABWH model)
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
        public Mod_TPB_SLABWH GetModel(string C_ID)
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
        public List<Mod_TPB_SLABWH> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TPB_SLABWH> DataTableToList(DataTable dt)
        {
            List<Mod_TPB_SLABWH> modelList = new List<Mod_TPB_SLABWH>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TPB_SLABWH model;
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByStatus(int iStatus)
        {

            return dal.GetListByStatus(iStatus);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }


        #endregion  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_SLABWH_CODE">仓库编码</param>
        /// <param name="C_SLABWH_NAME">仓库描述</param>
        /// <returns></returns>
        public DataSet GetList_id(string C_SLABWH_CODE, string C_SLABWH_NAME)
        {
            return dal.GetList_id(C_SLABWH_CODE, C_SLABWH_NAME);
        }

        /// <summary>
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_SLABWH_CODE">仓库编码</param>
        /// <returns></returns>
        public string GetList_id(string C_SLABWH_CODE)
        {
            object obj = dal.GetList_id(C_SLABWH_CODE);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSlabwh()
        {
            return dal.GetSlabwh();
        }
    }
}

