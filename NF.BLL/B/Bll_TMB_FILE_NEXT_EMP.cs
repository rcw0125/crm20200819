using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 下一处理人表
    /// </summary>
    public partial class Bll_TMB_FILE_NEXT_EMP
    {
        private readonly Dal_TMB_FILE_NEXT_EMP dal = new Dal_TMB_FILE_NEXT_EMP();
        public Bll_TMB_FILE_NEXT_EMP()
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
        public bool Add(Mod_TMB_FILE_NEXT_EMP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_FILE_NEXT_EMP model)
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
        public Mod_TMB_FILE_NEXT_EMP GetModel(string C_ID)
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
        public List<Mod_TMB_FILE_NEXT_EMP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_FILE_NEXT_EMP> DataTableToList(DataTable dt)
        {
            List<Mod_TMB_FILE_NEXT_EMP> modelList = new List<Mod_TMB_FILE_NEXT_EMP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMB_FILE_NEXT_EMP model;
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

        /// <summary>
        /// 更新下一步
        /// </summary>
        /// <param name="fileID">文件ID</param>
        /// <param name="stepID">当前步骤</param>
        /// <param name="nextStep">下一步骤</param>
        /// <param name="NextEmp">下一处理人</param>
        /// <param name="empID">当前处理人</param>
        /// <returns></returns>
        public bool UpdateNextSetp(string fileID, string stepID, string nextStep, string nextEmp, string empID)
        {
            return dal.UpdateNextSetp(fileID, stepID, nextStep, nextEmp, empID);
        }

        /// <summary>
        /// 驳回步骤处理
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="stepID"></param>
        /// <param name="nextStep"></param>
        /// <param name="upStep"></param>
        /// <returns></returns>
        public bool BackSetp(string fileID, string stepID, string nextStep,string upStep)
        {
            return dal.BackSetp(fileID, stepID, nextStep, upStep);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

