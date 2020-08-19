using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 公告
    /// </summary>
    public partial class Bll_TMB_NOTICE
    {
        private readonly Dal_TMB_NOTICE dal = new Dal_TMB_NOTICE();
        public Bll_TMB_NOTICE()
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
        public bool Add(Mod_TMB_NOTICE model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStatus(string IDList, int status)
        {
            return dal.UpdateStatus(IDList, status);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_NOTICE model)
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
        public Mod_TMB_NOTICE GetModel(string C_ID)
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
        public DataSet GetList(string top, string type)
        {
            return dal.GetList(top, type);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_NOTICE> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_NOTICE> DataTableToList(DataTable dt)
        {
            List<Mod_TMB_NOTICE> modelList = new List<Mod_TMB_NOTICE>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMB_NOTICE model;
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
        public int GetRecordCount(string classID, string title, string start, string end)
        {
            return dal.GetRecordCount(classID, title, start, end);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string classID, string title, string start, string end)
        {
            return dal.GetListByPage(pageSize, startIndex, classID, title, start, end);
        }

        public object GetListByPage(int pageSize, int currentPageIndex, string value1, string value2, string value3, object value4)
        {
            throw new NotImplementedException();
        }

        #endregion  BasicMethod

    }
}

