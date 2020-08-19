using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 技术咨询处理结果表
    /// </summary>
    public partial class Bll_TMC_TECH_CONSULT_RESULT
    {
        private readonly Dal_TMC_TECH_CONSULT_RESULT dal = new Dal_TMC_TECH_CONSULT_RESULT();
        public Bll_TMC_TECH_CONSULT_RESULT()
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
        public bool Add(Mod_TMC_TECH_CONSULT_RESULT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_TECH_CONSULT_RESULT model)
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
        public Mod_TMC_TECH_CONSULT_RESULT GetModel(string C_ID)
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
        public List<Mod_TMC_TECH_CONSULT_RESULT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_TECH_CONSULT_RESULT> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_TECH_CONSULT_RESULT> modelList = new List<Mod_TMC_TECH_CONSULT_RESULT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_TECH_CONSULT_RESULT model;
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

        public List<Mod_TMC_TECH_CONSULT_RESULT2> DataTableToList2(DataTable dt)
        {
            List<Mod_TMC_TECH_CONSULT_RESULT2> modelList = new List<Mod_TMC_TECH_CONSULT_RESULT2>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_TECH_CONSULT_RESULT2 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel2(dt.Rows[n]);
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string deptID, string start, string end)
        {
            return dal.GetRecordCount(deptID, start, end);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string deptID, string start, string end)
        {
            return dal.GetListByPage(pageSize, startIndex, deptID, start, end);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="C_TECH_CONSULT_ID">咨询主表ID</param>
        /// <param name="DeptID">部门</param>
        /// <returns></returns>
        public DataRow GetConsult_ResultList(string C_TECH_CONSULT_ID, string DeptID)
        {
            return dal.GetConsult_ResultList(C_TECH_CONSULT_ID, DeptID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConsult_ResultList(string C_TECH_CONSULT_ID)
        {
            return dal.GetConsult_ResultList(C_TECH_CONSULT_ID);
        }

        /// <summary>
        /// 客户评分
        /// </summary>
        /// <param name="C_ID">ID </param>
        /// <param name="NUM">评分</param>
        /// <param name="TIME">评分时间</param>
        /// <returns></returns>
        public bool UpdateCust_Eval(string C_ID, int NUM, DateTime TIME)
        {
            return dal.UpdateCust_Eval(C_ID, NUM, TIME);
        }

        /// <summary>
        /// 邢钢评分
        /// </summary>
        /// <param name="C_ID">ID</param>
        /// <param name="Num">评分</param>
        /// <param name="emp">评分人</param>
        /// <param name="time">评分时间</param>
        /// <returns></returns>
        public bool UpdateXG_Eval(string C_ID, int Num, string emp, DateTime time)
        {
            return dal.UpdateXG_Eval(C_ID, Num, emp, time);
        }

        #endregion  ExtensionMethod
    }
}

