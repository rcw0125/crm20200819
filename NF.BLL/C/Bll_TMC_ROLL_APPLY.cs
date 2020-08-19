using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 资源申请记录
    /// </summary>
    public partial class Bll_TMC_ROLL_APPLY
    {
        private readonly Dal_TMC_ROLL_APPLY dal = new Dal_TMC_ROLL_APPLY();
        public Bll_TMC_ROLL_APPLY()
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
        public bool Add(Mod_TMC_ROLL_APPLY model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_ROLL_APPLY model)
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

        public bool Insert(Mod_TMC_ROLL_APPLY mod)
        {
            return dal.Insert(mod);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_ROLL_APPLY GetModel(string C_ID)
        {

            return dal.GetModel(C_ID);
        }

        /// <summary>
        /// 质量异议审批
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveQua(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
        {
            return dal.ApproveQua(modFile, modNextEmp);
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
        public DataSet GetList(string startDate, string endDate, string status, string empID)
        {
            return dal.GetList(startDate, endDate, status, empID);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_ROLL_APPLY> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_ROLL_APPLY> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_ROLL_APPLY> modelList = new List<Mod_TMC_ROLL_APPLY>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_ROLL_APPLY model;
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

