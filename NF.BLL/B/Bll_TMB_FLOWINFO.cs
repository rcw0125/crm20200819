﻿using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
	/// <summary>
	/// 流程信息表
	/// </summary>
	public partial class Bll_TMB_FLOWINFO
    {
		private readonly Dal_TMB_FLOWINFO dal=new Dal_TMB_FLOWINFO();
		public Bll_TMB_FLOWINFO()
		{}
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
		public bool Add(Mod_TMB_FLOWINFO model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mod_TMB_FLOWINFO model)
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
		public bool DeleteList(string C_IDlist )
		{
			return dal.DeleteList(C_IDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mod_TMB_FLOWINFO GetModel(string C_ID)
		{
			
			return dal.GetModel(C_ID);
		}

        /// <summary>
        /// 审批流程列表
        /// </summary>
        /// <param name="N_TYPE">流程类型(1合同 2质量异议,3线材资源)</param>
        /// <returns></returns>
        public DataSet GetFlowList(string N_TYPE)
        {
            return dal.GetFlowList(N_TYPE);
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
		public List<Mod_TMB_FLOWINFO> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Mod_TMB_FLOWINFO> DataTableToList(DataTable dt)
		{
			List<Mod_TMB_FLOWINFO> modelList = new List<Mod_TMB_FLOWINFO>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Mod_TMB_FLOWINFO model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		#endregion  BasicMethod
	
	}
}
