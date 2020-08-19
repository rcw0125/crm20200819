﻿using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
    /// <summary>
    /// 客服
    /// </summary>
    public partial class Bll_TMC_CHAT_EMP
    {
        private readonly Dal_TMC_CHAT_EMP dal = new Dal_TMC_CHAT_EMP();
        public Bll_TMC_CHAT_EMP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_CHAT_EMP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMC_CHAT_EMP model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMC_CHAT_EMP GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
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
        public List<Mod_TMC_CHAT_EMP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mod_TMC_CHAT_EMP> DataTableToList(DataTable dt)
        {
            List<Mod_TMC_CHAT_EMP> modelList = new List<Mod_TMC_CHAT_EMP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mod_TMC_CHAT_EMP model;
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
        /// 随机获取客服
        /// </summary>
        /// <returns></returns>
        public DataRow GetChatEmp()
        {
            return dal.GetChatEmp();
        }
        /// <summary>
        /// 获取客服列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSaleEmp()
        {
            return dal.GetSaleEmp();
        }
        #endregion  ExtensionMethod
    }
}

