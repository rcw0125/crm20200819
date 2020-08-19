using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 客户评分主表
    /// </summary>
    public partial class Bll_TMC_CUSTGMARK_MAIN
    {
        private readonly Dal_TMC_CUSTGMARK_MAIN dal = new Dal_TMC_CUSTGMARK_MAIN();
        public Bll_TMC_CUSTGMARK_MAIN()
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
        public bool Add(Mod_TMC_CUSTGMARK_MAIN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_CUSTGMARK_MAIN model)
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
        public Mod_TMC_CUSTGMARK_MAIN GetModel(string C_ID)
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
        public List<Mod_TMC_CUSTGMARK_MAIN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_CUSTGMARK_MAIN> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_CUSTGMARK_MAIN> modelList = new List<Mod_TMC_CUSTGMARK_MAIN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_CUSTGMARK_MAIN model;
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
        /// 检测当前月是否评分
        /// </summary>
        /// <param name="empID">操作人ID</param>
        /// <returns></returns>
        public bool CheckMonth(string empID)
        {
            return dal.CheckMonth(empID);
        }

        /// <summary>
        /// 插入综合评分数据
        /// </summary>
        /// <param name="mod">基本信息</param>
        /// <param name="dt">项目得分数据</param>
        /// <returns></returns>
        public bool InsertData(Mod_TMC_CUSTGMARK_MAIN mod, DataTable dt)
        {
            return dal.InsertData(mod, dt);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string title, string start, string end, string empID)
        {
            return dal.GetRecordCount(title, start, end, empID);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string title, string start, string end, string empID)
        {
            return dal.GetListByPage(pageSize, startIndex, title, start, end, empID);
        }

        #endregion  BasicMethod

    }
}

