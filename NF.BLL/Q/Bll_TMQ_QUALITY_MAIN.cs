using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 质量异议主表
    /// </summary>
    public partial class Bll_TMQ_QUALITY_MAIN
    {
        private readonly Dal_TMQ_QUALITY_MAIN dal = new Dal_TMQ_QUALITY_MAIN();
        public Bll_TMQ_QUALITY_MAIN()
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
        public bool Add(Mod_TMQ_QUALITY_MAIN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMQ_QUALITY_MAIN model)
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
        public Mod_TMQ_QUALITY_MAIN GetModel(string C_ID)
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
        public List<Mod_TMQ_QUALITY_MAIN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMQ_QUALITY_MAIN> DataTableToList(DataTable dt)
        {
            List<Mod_TMQ_QUALITY_MAIN> modelList = new List<Mod_TMQ_QUALITY_MAIN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMQ_QUALITY_MAIN model;
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
        /// 更新状态
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态：-1未提交,0待处理,1处理中,2办结</param>
        /// <returns></returns>
        public bool UpdateStatus(string id, string status)
        {
            return dal.UpdateStatus(id, status);
        }

        /// <summary>
        /// 更新审批人/时间
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="empID">审批人</param>
        /// <param name="status">状态</param>
        /// <param name="time">审批时间</param>
        /// <returns></returns>
        public bool UpdateCheckEmp(string id, string empID, string status, DateTime time)
        {
            return dal.UpdateCheckEmp(id, empID, status, time);
        }

        #endregion  ExtensionMethod
    }
}

