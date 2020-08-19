using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 排产初始化子表
    /// </summary>
    public partial class Bll_TPP_INITIALIZE_ORDER
    {
        private readonly Dal_TPP_INITIALIZE_ORDER dal = new Dal_TPP_INITIALIZE_ORDER();
        public Bll_TPP_INITIALIZE_ORDER()
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
        public bool Add(Mod_TPP_INITIALIZE_ORDER model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TPP_INITIALIZE_ORDER model)
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
        public Mod_TPP_INITIALIZE_ORDER GetModel(string C_ID)
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
        /// 获取订单是否已排产 0未排产,1已排产
        /// </summary>
        /// <param name="C_ORDER_ID">订单号</param>
        /// <returns></returns>
        public int GetOrder(string C_ORDER_ID)
        {
            return dal.GetOrder(C_ORDER_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TPP_INITIALIZE_ORDER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TPP_INITIALIZE_ORDER> DataTableToList(DataTable dt)
        {
            List<Mod_TPP_INITIALIZE_ORDER> modelList = new List<Mod_TPP_INITIALIZE_ORDER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TPP_INITIALIZE_ORDER model;
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
        /// 得到已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <returns></returns>
        public DataTable GetIniOrderByIniID(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype)
        {

            return dal.GetIniOrderByIniID(strIniID, strGZ, strBZ, strRollID, strCCMID, rolltype, ccmtype);
        }

        /// <summary>
        /// 按类统计已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <param name="strTJ">统计类别:1轧钢2连铸，3钢种,4产线规格</param>
        /// <returns></returns>
        public DataTable GetOrderIniTJ(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype, string strTJ)
        {
            return dal.GetOrderIniTJ(strIniID, strGZ, strBZ, strRollID, strCCMID, rolltype, ccmtype, strTJ);
        }

        /// <summary>
        /// 获取方案和钢坯库统计结果
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <returns></returns>
        public DataTable GetOrderAndKCP(string strIniID, string strGZ, string strBZ)
        {
            return dal.GetOrderAndKCP(strIniID, strGZ, strBZ);
        }

        /// <summary>
        /// 得到已初始化订单信息
        /// </summary>
        /// <param name="strIniID">方案主键</param>
        /// <param name="strGZ">钢种</param>
        /// <param name="strBZ">标准</param>
        /// <param name="strRollID">轧线</param>
        /// <param name="strCCMID">连铸</param>
        /// <param name="rolltype">轧钢是否排产</param>
        /// <param name="ccmtype">炼钢是否排产</param>
        /// <returns></returns>
        public DataTable Get_Order_PC(string strIniID, string strGZ, string strBZ, string strRollID, string strCCMID, int? rolltype, int? ccmtype)
        {
            return dal.Get_Order_PC(strIniID, strGZ, strBZ, strRollID, strCCMID, rolltype, ccmtype);
        }
        #endregion  ExtensionMethod
    }
}

