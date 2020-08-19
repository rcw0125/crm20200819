using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
    /// <summary>
    /// 折扣-税率-单价表
    /// </summary>
    public partial class Bll_TMB_ACTIVITY
    {
        private readonly Dal_TMB_ACTIVITY dal = new Dal_TMB_ACTIVITY();
        public Bll_TMB_ACTIVITY()
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
        public bool Add(Mod_TMB_ACTIVITY model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_ACTIVITY model)
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            return dal.DeleteList(C_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMB_ACTIVITY GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获取钢种单价-税率-折扣
        /// </summary>
        /// <param name="C_MAT_CODE">物料编码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_SPEC">规格</param>
        /// <returns></returns>
        public DataRow GetActivityRow(string c_mat_code, string c_stl_grd, string c_spec)
        {
            return dal.GetActivityRow(c_mat_code, c_stl_grd, c_spec);
        }

  
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string Start, string End, string AreaMax)
        {
            return dal.GetList(Start, End, AreaMax);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_INVSHORTNAME, string AreaMax, string C_MAT_CODE, string C_STL_GRD, string C_SPEC, string Start, string End)
        {
            return dal.GetList(C_INVSHORTNAME, AreaMax, C_MAT_CODE, C_STL_GRD, C_SPEC, Start, End);
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
        public List<Mod_TMB_ACTIVITY> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_ACTIVITY> DataTableToList(DataTable dt)
        {
            List<Mod_TMB_ACTIVITY> modelList = new List<Mod_TMB_ACTIVITY>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMB_ACTIVITY model;
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
        public int GetRecordCount(string matCode, string STLGRD, string SPEC, string start_dt, string end_dt, string matName, string Area)
        {
            return dal.GetRecordCount(matCode, STLGRD, SPEC, start_dt, end_dt, matName, Area);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string matCode, string STLGRD, string SPEC, string start_dt, string end_dt, string matName, string Area)
        {
            return dal.GetListByPage(pageSize, startIndex, matCode, STLGRD, SPEC, start_dt, end_dt, matName, Area);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="activityList">数据集合</param>
        /// <returns></returns>
        public bool UpdateMatCode(List<Mod_TMB_ACTIVITY> activityList)
        {
            return dal.UpdateMatCode(activityList);
        }

        #endregion  BasicMethod

    }
}

