using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 销售订单
    /// </summary>
    public partial class Bll_TMO_SALEORDER
    {
        private readonly Dal_TMO_SALEORDER dal = new Dal_TMO_SALEORDER();
        public Bll_TMO_SALEORDER()
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
        public bool Add(Mod_TMO_SALEORDER model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMO_SALEORDER model)
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
        public Mod_TMO_SALEORDER GetModel(string C_ID)
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
        public List<Mod_TMO_SALEORDER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMO_SALEORDER> DataTableToList(DataTable dt)
        {
            List<Mod_TMO_SALEORDER> modelList = new List<Mod_TMO_SALEORDER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMO_SALEORDER model;
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


        #region 自定义方法

        /// <summary>
        /// 更新销售订单状态
        /// </summary>
        /// <param name="pkID">主键</param>
        /// <param name="status">状态:0停用,1启用,2导入NC成功,3失败</param>
        /// <returns></returns>
        public bool UpdateStatus(string pkID, int status)
        {
            return dal.UpdateStatus(pkID, status);
        }
        /// <summary>
        /// 插入销售订单
        /// </summary>
        /// <param name="parem">合同参数列表,返回DataTable:ID,CODE</param>
        /// <returns></returns>
        public DataTable InsertSaleOrder(List<string> parem)
        {
            return dal.InsertSaleOrder(parem);
        }
        #endregion


    }
}

