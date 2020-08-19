using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 线材资源调配记录
    /// </summary>
    public partial class Bll_TMC_ROLL_DEPLOY_LOG
    {
        private readonly Dal_TMC_ROLL_DEPLOY_LOG dal = new Dal_TMC_ROLL_DEPLOY_LOG();
        public Bll_TMC_ROLL_DEPLOY_LOG()
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
        public bool Add(Mod_TMC_ROLL_DEPLOY_LOG model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_ROLL_DEPLOY_LOG model)
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
        public Mod_TMC_ROLL_DEPLOY_LOG GetModel(string C_ID)
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
        public List<Mod_TMC_ROLL_DEPLOY_LOG> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_ROLL_DEPLOY_LOG> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_ROLL_DEPLOY_LOG> modelList = new List<Mod_TMC_ROLL_DEPLOY_LOG>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_ROLL_DEPLOY_LOG model;
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
        /// 线材批次查询
        /// </summary>
        /// <param name="batch">批次</param>
        /// <returns></returns>
        public DataSet GetCheckRollProc(string batch)
        {
            return dal.GetCheckRollProc(batch);
        }

        /// <summary>
        /// 线材区域调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            return dal.InsertRoll_Proc(list);
        }

        /// <summary>
        /// 按单卷线材区域调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc2(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            return dal.InsertRoll_Proc2(list);
        }

        /// <summary>
        /// 线材区域客户调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc3(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            return dal.InsertRoll_Proc3(list);
        }

        /// <summary>
        /// 按批次线材区域客户调整
        /// </summary>
        /// <param name="list">日志</param>
        /// <returns></returns>
        public bool InsertRoll_Proc4(List<Mod_TMC_ROLL_DEPLOY_LOG> list)
        {
            return dal.InsertRoll_Proc4(list);
        }

        /// <summary>
        /// D质量线材区域分配
        /// </summary>
        /// <returns></returns>
        public bool Update_D_Roll_Proc()
        {
            return dal.Update_D_Roll_Proc();
        }

        #endregion  BasicMethod

    }
}

