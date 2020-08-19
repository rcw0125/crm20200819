using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;

namespace NF.BLL
{
    /// <summary>
    /// 合同明细表
    /// </summary>
    public partial class Bll_TMO_CONDETAILS
    {
        private readonly Dal_TMO_CONDETAILS dal = new Dal_TMO_CONDETAILS();
        public Bll_TMO_CONDETAILS()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_NO)
        {
            return dal.Exists(C_NO);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_CONDETAILS model)
        {
            return dal.Add(model);
        }





        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateStatus(int status, string conNO)
        {
            return dal.UpdateStatus(status, conNO);
        }

        /// <summary>
        /// 更新客户处理状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool UpdateCustStatus(int status, string orderNo)
        {
            return dal.UpdateCustStatus(status, orderNo);
        }

        /// <summary>,
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMO_CONDETAILS model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_NO)
        {

            return dal.Delete(C_NO);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DelOrder(string C_NO)
        {
            return dal.DelOrder(C_NO);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string C_NOlist)
        {
            return dal.DeleteList(C_NOlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMO_CONDETAILS GetModel(string C_NO)
        {

            return dal.GetModel(C_NO);
        }

        /// <summary>
        /// 获取订单总数
        /// </summary>
        /// <param name="C_MAT_NAME">物料名称</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="N_CUSTSTATUS">状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="C_EMP_ID">订单人</param>
        /// <returns></returns>
        public int GetOrderCount(string C_MAT_NAME, string C_STL_GRD, string C_SPEC, string N_CUSTSTATUS, string startdate, string enddate, string C_EMP_ID)
        {
            return dal.GetOrderCount(C_MAT_NAME, C_STL_GRD, C_SPEC, N_CUSTSTATUS, startdate, enddate, C_EMP_ID);
        }
        /// <summary>
        /// 获取订单分页记录
        /// </summary>
        /// <param name="pageSize">显示条数</param>
        /// <param name="startIndex">起始条数</param>
        /// <param name="C_MAT_NAME">物料名称</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="N_CUSTSTATUS">状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="C_EMP_ID">订单人ID</param>
        /// <returns></returns>
        public DataSet GetOrderByPage(int pageSize, int startIndex, string C_MAT_NAME, string C_STL_GRD, string C_SPEC, string N_CUSTSTATUS, string startdate, string enddate, string C_EMP_ID)
        {
            return dal.GetOrderByPage(pageSize, startIndex, C_MAT_NAME, C_STL_GRD, C_SPEC, N_CUSTSTATUS, startdate, enddate, C_EMP_ID);
        }



        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string conNo, string orderNo)
        {
            return dal.GetConOrderList(conNo, orderNo);
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="conNo">合同号</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="start">签单开始时间</param>
        /// <param name="end">签单截至时间</param>
        /// <returns></returns>
        public DataSet GetConOrderList(string conNo, string orderNo, string stlGrd, string start, string end, string custNO)
        {
            return dal.GetConOrderList(conNo, orderNo, stlGrd, start, end,custNO);
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
        public DataSet GetList(string C_CON_NO, string C_MAT_CODE, string C_MAT_NAME, string C_SPEC, string C_STL_GRD)
        {
            return dal.GetList(C_CON_NO, C_MAT_CODE, C_MAT_NAME, C_SPEC, C_STL_GRD);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMO_CONDETAILS> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMO_CONDETAILS> DataTableToList(DataTable dt)
        {
            List<Mod_TMO_CONDETAILS> modelList = new List<Mod_TMO_CONDETAILS>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMO_CONDETAILS model;
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
        public List<Mod_TMO_CONDETAILS2> DataTableToList2(DataTable dt)
        {
            List<Mod_TMO_CONDETAILS2> modelList = new List<Mod_TMO_CONDETAILS2>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMO_CONDETAILS2 model;
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

        #region  自定义方法

        /// <summary>
        /// 更新订单匹配量
        /// </summary>
        public bool UpdateMatch(decimal WGT, string orderNo, int type)
        {
            return dal.UpdateMatch(WGT, orderNo, type);
        }


        #endregion  ExtensionMethod
    }
}

