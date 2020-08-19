using System;
using System.Data;
using System.Collections.Generic;
using NF.MODEL;
using NF.DAL;
namespace NF.BLL
{
	/// <summary>
	/// 订单条例
	/// </summary>
	public partial class Bll_TMO_CONRULES
    {
		private readonly Dal_TMO_CONRULES dal=new Dal_TMO_CONRULES();
		public Bll_TMO_CONRULES()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_CON_NO)
		{
			return dal.Exists(C_CON_NO);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMO_CONRULES model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mod_TMO_CONRULES model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string C_CON_NO)
		{
			
			return dal.Delete(C_CON_NO);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string C_CON_NOlist )
		{
			return dal.DeleteList(C_CON_NOlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mod_TMO_CONRULES GetModel(string C_CON_NO)
		{
			
			return dal.GetModel(C_CON_NO);
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
		public List<Mod_TMO_CONRULES> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Mod_TMO_CONRULES> DataTableToList(DataTable dt)
		{
			List<Mod_TMO_CONRULES> modelList = new List<Mod_TMO_CONRULES>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Mod_TMO_CONRULES model;
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

