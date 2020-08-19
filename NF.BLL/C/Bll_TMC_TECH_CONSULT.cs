using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 技术咨询主表
    /// </summary>
    public partial class Bll_TMC_TECH_CONSULT
    {
        private readonly Dal_TMC_TECH_CONSULT dal = new Dal_TMC_TECH_CONSULT();
        public Bll_TMC_TECH_CONSULT()
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
        public bool Add(Mod_TMC_TECH_CONSULT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_TECH_CONSULT model)
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
        public Mod_TMC_TECH_CONSULT GetModel(string C_ID)
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
        public List<Mod_TMC_TECH_CONSULT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_TECH_CONSULT> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_TECH_CONSULT> modelList = new List<Mod_TMC_TECH_CONSULT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_TECH_CONSULT model;
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
        /// 获取记录总数
        /// </summary>
        /// <param name="classID">类别</param>
        /// <param name="empID">当前用户</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="title">产品</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public int GetRecordCount(string classID, string empID, string start, string end,string title,string state)
        {
            return dal.GetRecordCount(classID, empID, start, end,title,state);
        }

        /// <summary>
        ///  分页获取数据列表
        /// </summary>
        /// <param name="pageSize">页数</param>
        /// <param name="startIndex">开始页数</param>
        /// <param name="classID">类别</param>
        /// <param name="empID">当前用户</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="title">产品</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string classID, string empID, string start, string end,string title,string state)
        {
            return dal.GetListByPage(pageSize, startIndex, classID, empID, start, end,title,state);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_QUEST_ID">技术问题主表ID</param>
        /// <returns></returns>
        public DataSet GetConsultList(string C_QUEST_ID)
        {
            return dal.GetConsultList(C_QUEST_ID);
        }

        #endregion  ExtensionMethod
    }
}

