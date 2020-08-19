using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 执行标准信息主表
    /// </summary>
    public partial class Bll_TQB_STD_MAIN
    {
        private readonly Dal_TQB_STD_MAIN dal = new Dal_TQB_STD_MAIN();
        public Bll_TQB_STD_MAIN()
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
        public bool Add(Mod_TQB_STD_MAIN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TQB_STD_MAIN model)
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
        public Mod_TQB_STD_MAIN GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_Type(string C_STL_GRD)
        {
            return dal.GetList_Type(C_STL_GRD);
        }
        /// <summary>
        /// 获取标准列表
        /// </summary>              
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetList_Std(string C_STL_GRD)
        {
            return dal.GetList_Std(C_STL_GRD);
        }
        public DataSet GetList_STD(string C_STL_GRD)
        {
            return dal.GetList_STD(C_STL_GRD);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_STD_TYPE, string C_STD_CODE, string C_STL_GRD)
        {
            return dal.GetList(C_STD_TYPE, C_STD_CODE, C_STL_GRD);
        }

        /// <summary>
        /// 获取标准列表
        /// </summary>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <returns></returns>
        public DataSet GetList(string C_STL_GRD, string C_STD_CODE)
        {
            return dal.GetList(C_STL_GRD, C_STD_CODE);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TQB_STD_MAIN> GetModelList(string C_STD_TYPE, string C_STD_CODE, string C_STL_GRD)
        {
            DataSet ds = dal.GetList(C_STD_TYPE, C_STD_CODE, C_STL_GRD);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TQB_STD_MAIN> DataTableToList(DataTable dt)
        {
            List<Mod_TQB_STD_MAIN> modelList = new List<Mod_TQB_STD_MAIN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TQB_STD_MAIN model;
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
        /// 获取可代轧钢种标准列表
        /// </summary>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetListByGZ(string C_STL_GRD, string C_STD_CODE)
        {
            return dal.GetListByGZ(C_STL_GRD, C_STD_CODE);
        }
        /// <summary>
        /// 获取标准列表
        /// </summary>
        /// <param name="C_PROD_NAME">钢类</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetGLList(string C_STL_GRD, string C_PROD_NAME)
        {
            return dal.GetGLList(C_STL_GRD, C_PROD_NAME);
        }
        /// <summary>
        /// 获得所有钢类
        /// </summary>
        public DataSet GetPMList()
        {
            return dal.GetPMList();
        }
        /// <summary>
        /// 获得所有钢种
        /// </summary>
        public DataSet GetGZList(string grd)
        {
            return dal.GetGZList(grd);
        }

        /// <summary>
        /// 获取标准列表(可代轧钢种维护)
        /// </summary>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_ID">主键</param>
        /// <returns></returns>
        public DataSet GetListKDZ(string C_STD_CODE, string C_STL_GRD, string C_ID)
        {
            return dal.GetListKDZ( C_STD_CODE,  C_STL_GRD,  C_ID);
        }
            #endregion  ExtensionMethod
        }
}

