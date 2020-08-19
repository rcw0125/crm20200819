using System;
using System.Data;
using System.Collections.Generic;
using NF.DAL;
using NF.MODEL;
namespace NF.BLL
{
	/// <summary>
	/// 钢种生成条件主表
	/// </summary>
	public partial class Bll_TPB_STEEL_PRO_CONDITION
	{
		private readonly Dal_TPB_STEEL_PRO_CONDITION dal=new Dal_TPB_STEEL_PRO_CONDITION();
		public Bll_TPB_STEEL_PRO_CONDITION()
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
		public bool Add(Mod_TPB_STEEL_PRO_CONDITION model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mod_TPB_STEEL_PRO_CONDITION model)
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
			return dal.DeleteList(C_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mod_TPB_STEEL_PRO_CONDITION GetModel(string C_ID)
		{
			
			return dal.GetModel(C_ID);
		}
        /// <summary>
        /// 获得数据列表_条件模糊查询
        /// </summary>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <returns></returns>
        public DataSet GetList_Query(string C_STL_GRD, string C_STD_CODE)
        {
            return dal.GetList_Query(C_STL_GRD, C_STD_CODE);
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
		public List<Mod_TPB_STEEL_PRO_CONDITION> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Mod_TPB_STEEL_PRO_CONDITION> DataTableToList(DataTable dt)
		{
			List<Mod_TPB_STEEL_PRO_CONDITION> modelList = new List<Mod_TPB_STEEL_PRO_CONDITION>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Mod_TPB_STEEL_PRO_CONDITION model;
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
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		
	}
}

