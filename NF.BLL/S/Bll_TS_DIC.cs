using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public partial class Bll_TS_DIC
    {
        private readonly Dal_TS_DIC dal = new Dal_TS_DIC();
        public Bll_TS_DIC()
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
        public bool Add(Mod_TS_DIC model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获取区域是否按客户发运
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public string GetAreaFlag(string area)
        {
            return dal.GetAreaFlag(area);
        }

        /// <summary>
        /// 获取发运标识状态Y/N
        /// </summary>
        /// <param name="code">标识代码</param>
        /// <param name="name">标识名称</param>
        /// <returns></returns>
        public string GetDicFlag(string code, string name)
        {
            return dal.GetDicFlag(code, name);
        }

        /// <summary>
        /// 区域GPS与区域客户发运
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateAreaGPS(List<Mod_TS_DIC> list)
        {
            return dal.UpdateAreaGPS(list);
        }

        /// <summary>
        /// 区域按客户发运
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateAreaCust(List<Mod_TS_DIC> list)
        {
            return dal.UpdateAreaCust(list);
        }

        /// <summary>
        /// 更新是否GPS
        /// </summary>
        public bool UpdateN_ISGPS(int isGPS, String idList)
        {
            return dal.UpdateN_ISGPS(isGPS, idList);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_DIC model)
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
        public Mod_TS_DIC GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDis(string C_TYPECODE)
        {
            return dal.GetDis(C_TYPECODE);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Mod_TS_DIC model)
        {
            return dal.GetList(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDicArea(string C_PARENT_ID)
        {
            return dal.GetDicArea(C_PARENT_ID);
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
        public List<Mod_TS_DIC> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TS_DIC> DataTableToList(DataTable dt)
        {
            List<Mod_TS_DIC> modelList = new List<Mod_TS_DIC>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TS_DIC model;
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

    }
}

