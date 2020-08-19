using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 发运日计划
    /// </summary>
    public partial class Bll_TMP_DAYPLAN
    {
        private readonly Dal_TMP_DAYPLAN dal = new Dal_TMP_DAYPLAN();
        public Bll_TMP_DAYPLAN()
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
        public bool Add(Mod_TMP_DAYPLAN model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMP_DAYPLAN model)
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
        public Mod_TMP_DAYPLAN GetModelID(string C_ID)
        {
            return dal.GetModelID(C_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMP_DAYPLAN GetModel(string C_PLCODE)
        {

            return dal.GetModel(C_PLCODE);
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
        public List<Mod_TMP_DAYPLAN> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMP_DAYPLAN> DataTableToList(DataTable dt)
        {
            List<Mod_TMP_DAYPLAN> modelList = new List<Mod_TMP_DAYPLAN>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMP_DAYPLAN model;
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



        #endregion  BasicMethod


        #region //更新日计划导入NC状态
        /// <summary>
        /// 更新日计划导入NC状态
        /// </summary>
        /// <param name="plancode">发运日计划单据号</param>
        /// <returns></returns>
        public bool UpdateDayPlanStatus(string plancode)
        {
            return dal.UpdateDayPlanStatus(plancode);
        }
        #endregion

    }
}

