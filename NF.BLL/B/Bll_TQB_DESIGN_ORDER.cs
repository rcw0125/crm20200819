using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 订单质量设计信息
    /// </summary>
    public partial class Bll_TQB_DESIGN_ORDER
    {
        private readonly Dal_TQB_DESIGN_ORDER dal = new Dal_TQB_DESIGN_ORDER();
        public Bll_TQB_DESIGN_ORDER()
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
        public bool Add(Mod_TQB_DESIGN_ORDER model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TQB_DESIGN_ORDER model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDesign(string C_ORDER_ID, string C_DESIGN_ID)
        {
            return dal.UpdateDesign(C_ORDER_ID, C_DESIGN_ID);
        }

        /// <summary>
        /// 根据订单号删除订单质量
        /// </summary>
        /// <param name="C_ORDER_ID">订单号</param>
        /// <returns></returns>
        public bool DeleteOder(string C_ORDER_ID)
        {
            return dal.DeleteOder(C_ORDER_ID);
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
        public Mod_TQB_DESIGN_ORDER GetModel(string C_ID)
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
        /// 根据订单号获取质量设计信息
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns></returns>
        public DataSet GetDesignByOrder(string strOrderNo)
        {
            return dal.GetDesignByOrder(strOrderNo);
        }

        /// <summary>
        /// 根据执行标准和钢种查询质量设计信息
        /// </summary>
        /// <param name="strStdcode"></param>
        /// <param name="strGrd"></param>
        /// <returns></returns>
        public DataSet GetDesignByStdGrd(string strStdcode, string strGrd)
        {
            return dal.GetDesignByStdGrd(strStdcode, strGrd);
        }

        /// <summary>
        /// 根据订单号获取质量设计变更信息
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns></returns>
        public DataSet GetDesignChange(string strOrderNo)
        {
            return dal.GetDesignChange(strOrderNo);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TQB_DESIGN_ORDER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TQB_DESIGN_ORDER> DataTableToList(DataTable dt)
        {
            List<Mod_TQB_DESIGN_ORDER> modelList = new List<Mod_TQB_DESIGN_ORDER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TQB_DESIGN_ORDER model;
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

        #endregion  ExtensionMethod
    }
}

