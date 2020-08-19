using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 排班表
    /// </summary>
    public partial class Bll_TB_BCBZ
    {
        private readonly Dal_TB_BCBZ dal = new Dal_TB_BCBZ();
        public Bll_TB_BCBZ()
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
        public bool Add(Mod_TB_BCBZ model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TB_BCBZ model)
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
        public Mod_TB_BCBZ GetModel(string C_ID)
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
        public List<Mod_TB_BCBZ> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TB_BCBZ> DataTableToList(DataTable dt)
        {
            List<Mod_TB_BCBZ> modelList = new List<Mod_TB_BCBZ>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TB_BCBZ model;
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
        #region  ExtensionMethod
        /// <summary>
        /// 根据开始时间删除数据
        /// </summary>
        public bool Delete(DateTime dateTime, string pro)
        {
            return dal.Delete(dateTime, pro);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string pro, DateTime st, DateTime et)
        {
            return dal.GetList(pro, st, et);
        }
        /// <summary>
        /// 根据类型,时间或取当前班次班组
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataSet GetList(string type, DateTime dt)
        {
            return dal.GetList(type, dt);
        }
        /// <summary>
        /// 根据工序，班次获得NC班次
        /// </summary>
        /// <param name="stacode">工位代码</param>
        /// <param name="bc">班次</param>
        /// <returns></returns>
        public DataSet GetNCBCList(string stacode, string bc)
        {
            return dal.GetNCBCList(stacode, bc);
        }
        /// <summary>
        /// 根据工位，班组获得NC班组
        /// </summary>
        /// <param name="gzzxid">工作中心ID</param>
        /// <param name="bz">班组</param>
        /// <returns></returns>
        public DataSet GetNCBZList(string gzzxid, string bz)
        {
            return dal.GetNCBZList(gzzxid, bz);
        }
        #endregion  ExtensionMethod
    }
}
