using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 部门表
    /// </summary>
    public partial class Bll_TS_DEPT
    {
        private readonly Dal_TS_DEPT dal = new Dal_TS_DEPT();
        public Bll_TS_DEPT()
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
        public bool Add(Mod_TS_DEPT model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新状态
        /// </summary>
        public bool UpdateStatus(string id)
        {
            return dal.UpdateStatus(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_DEPT model)
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
        public Mod_TS_DEPT GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获取部门人员列表
        /// </summary>
        /// <param name="deptID">部门ID</param>
        /// <returns></returns>
        public DataSet GetDeptEMPList(string deptID)
        {
            return dal.GetDeptEMPList(deptID);
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        public DataSet GetDeptList(string parentID)
        {
            return dal.GetDeptList(parentID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDeptCode(string C_CODE)
        {
            return dal.GetDeptCode(C_CODE);
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
        public List<Mod_TS_DEPT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_DEPT> DataTableToList(DataTable dt)
        {
            List<Mod_TS_DEPT> modelList = new List<Mod_TS_DEPT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TS_DEPT model;
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

