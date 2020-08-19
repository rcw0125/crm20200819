using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 区域计划量表
    /// </summary>
    public partial class Bll_TMB_AREAPLAN
    {
        private readonly Dal_TMB_AREAPLAN dal = new Dal_TMB_AREAPLAN();
        public Bll_TMB_AREAPLAN()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string areaID, string start, string end)
        {
            return dal.Exists(areaID, start, end);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddList(List<Mod_TMB_AREAPLAN> list)
        {
            return dal.AddList(list);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_AREAPLAN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_AREAPLAN model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新多条数据
        /// </summary>
        public bool UpdateList(List<Mod_TMB_AREAPLAN> list)
        {
            return dal.UpdateList(list);
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
        public Mod_TMB_AREAPLAN GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 获取当前时间区域计划量/实际订单量
        /// </summary>
        /// <returns></returns>
        public DataSet GetPlanWGT()
        {
            return dal.GetPlanWGT();
        }
        /// <summary>
        /// 获取区域计划量具体钢种接单量
        /// </summary>
        /// <param name="saleArea">销售区域</param>
        /// <param name="maxclass">大类</param>
        /// <param name="sfkj">监控钢种</param>
        /// <param name="stlgrdcalss">钢类</param>
        /// <returns></returns>
        public DataSet GetPlanStlGRD(string saleArea, string maxclass, string sfkj, string stlgrdcalss)
        {
            return dal.GetPlanStlGRD(saleArea, maxclass, sfkj, stlgrdcalss);
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
        public List<Mod_TMB_AREAPLAN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMB_AREAPLAN> DataTableToList(DataTable dt)
        {
            List<Mod_TMB_AREAPLAN> modelList = new List<Mod_TMB_AREAPLAN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMB_AREAPLAN model;
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
        public int GetRecordCount(string areaID)
        {
            return dal.GetRecordCount(areaID);
        }
        /// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(int pageSize, int startIndex, string areaID)
        {
            return dal.GetListByPage(pageSize, startIndex, areaID);
        }

        #endregion  BasicMethod

        /// <summary>
        /// 获取签单指标
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetAreaPlan(string startDate, string endDate)
        {
            return dal.GetAreaPlan(startDate, endDate);
        }

    }
}

