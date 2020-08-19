﻿using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 问题-处理部门
    /// </summary>
    public partial class Bll_TMC_QUESTION_DEPT
    {
        private readonly Dal_TMC_QUESTION_DEPT dal = new Dal_TMC_QUESTION_DEPT();
        public Bll_TMC_QUESTION_DEPT()
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
        public bool Add(Mod_TMC_QUESTION_DEPT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_QUESTION_DEPT model)
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
        public Mod_TMC_QUESTION_DEPT GetModel(string C_ID)
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
        public List<Mod_TMC_QUESTION_DEPT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_QUESTION_DEPT> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_QUESTION_DEPT> modelList = new List<Mod_TMC_QUESTION_DEPT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_QUESTION_DEPT model;
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod


        /// <summary>
        /// 获取技术处理部门
        /// </summary>
        /// <param name="C_QUESTION_ID">问题ID</param>
        /// <param name="C_DEPT_ID">部门ID</param>
        /// <returns></returns>
        public DataSet GetQuestion_Dept(string C_QUESTION_ID, string C_DEPT_ID)
        {
            return dal.GetQuestion_Dept(C_QUESTION_ID, C_DEPT_ID);
        }

        /// <summary>
        /// 根据问题主表ID删除字表数据
        /// </summary>
        /// <param name="C_QUESTION_ID">主表ID</param>
        /// <returns></returns>
        public bool DeleteQuestion_Dept(string C_QUESTION_ID)
        {
            return dal.DeleteQuestion_Dept(C_QUESTION_ID);
        }

        #endregion  ExtensionMethod
    }
}
