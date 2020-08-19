using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 流程-步骤对应表
    /// </summary>
    public partial class Bll_TMB_FLOWSTEP
    {
        private readonly Dal_TMB_FLOWSTEP dal = new Dal_TMB_FLOWSTEP();
        public Bll_TMB_FLOWSTEP()
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
        public bool Add(Mod_TMB_FLOWSTEP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_FLOWSTEP model)
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
        public Mod_TMB_FLOWSTEP GetModel(string C_ID)
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
        public List<Mod_TMB_FLOWSTEP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_FLOWSTEP> DataTableToList(DataTable dt)
        {
            List<Mod_TMB_FLOWSTEP> modelList = new List<Mod_TMB_FLOWSTEP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMB_FLOWSTEP model;
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
        /// 获取当前步骤上一处理步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <param name="step">步骤</param>
        /// <returns></returns>
        public string GetUpStep(string flow, string step)
        {
            return dal.GetUpStep(flow, step);
        }


        /// <summary>
        /// 获取流程第一步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <returns></returns>
        public string GetFirstStep(string flow)
        {
            return dal.GetFirstStep(flow);
        }

        /// <summary>
        /// 获取流程最后步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <returns></returns>
        public string GetLastStep(string flow)
        {
            return dal.GetLastStep(flow);
        }
        /// <summary>
        /// 获取当前步骤下一处理步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <param name="step">当前步骤</param>
        /// <returns></returns>
        public string GetNextStep(string flow, string step)
        {
            return dal.GetNextStep(flow, step);
        }

        #endregion  ExtensionMethod
    }
}

