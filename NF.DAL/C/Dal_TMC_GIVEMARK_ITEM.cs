using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMC_GIVEMARK_ITEM
	/// </summary>
	public partial class Dal_TMC_GIVEMARK_ITEM
    {
		public Dal_TMC_GIVEMARK_ITEM()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMC_GIVEMARK_ITEM");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMC_GIVEMARK_ITEM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMC_GIVEMARK_ITEM(");
			strSql.Append("C_ID,C_NAME,C_FLAG,N_SCORE,N_STATUS,C_REMARK)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_NAME,:C_FLAG,:N_SCORE,:N_STATUS,:C_REMARK)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
					new OracleParameter(":C_FLAG", OracleDbType.Varchar2,100),
					new OracleParameter(":N_SCORE", OracleDbType.Decimal,2),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_NAME;
			parameters[2].Value = model.C_FLAG;
			parameters[3].Value = model.N_SCORE;
			parameters[4].Value = model.N_STATUS;
			parameters[5].Value = model.C_REMARK;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Mod_TMC_GIVEMARK_ITEM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMC_GIVEMARK_ITEM set ");
			strSql.Append("C_NAME=:C_NAME,");
			strSql.Append("C_FLAG=:C_FLAG,");
			strSql.Append("N_SCORE=:N_SCORE,");
			strSql.Append("N_STATUS=:N_STATUS,");
			strSql.Append("C_REMARK=:C_REMARK");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
					new OracleParameter(":C_FLAG", OracleDbType.Varchar2,100),
					new OracleParameter(":N_SCORE", OracleDbType.Decimal,2),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_NAME;
			parameters[1].Value = model.C_FLAG;
			parameters[2].Value = model.N_SCORE;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.C_REMARK;
			parameters[5].Value = model.C_ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMC_GIVEMARK_ITEM ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string C_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMC_GIVEMARK_ITEM ");
			strSql.Append(" where C_ID in ("+C_IDlist + ")  ");
			int rows=DbHelperOra.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mod_TMC_GIVEMARK_ITEM GetModel(string C_ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_NAME,C_FLAG,N_SCORE,N_STATUS,C_REMARK from TMC_GIVEMARK_ITEM ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMC_GIVEMARK_ITEM model=new Mod_TMC_GIVEMARK_ITEM();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mod_TMC_GIVEMARK_ITEM DataRowToModel(DataRow row)
		{
			Mod_TMC_GIVEMARK_ITEM model=new Mod_TMC_GIVEMARK_ITEM();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_NAME"]!=null)
				{
					model.C_NAME=row["C_NAME"].ToString();
				}
				if(row["C_FLAG"]!=null)
				{
					model.C_FLAG=row["C_FLAG"].ToString();
				}
				if(row["N_SCORE"]!=null && row["N_SCORE"].ToString()!="")
				{
					model.N_SCORE=decimal.Parse(row["N_SCORE"].ToString());
				}
				if(row["N_STATUS"]!=null && row["N_STATUS"].ToString()!="")
				{
					model.N_STATUS=decimal.Parse(row["N_STATUS"].ToString());
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_NAME,C_FLAG,N_SCORE,N_STATUS,C_REMARK ");
			strSql.Append(" FROM TMC_GIVEMARK_ITEM ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append("order by N_SORT asc");
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TMC_GIVEMARK_ITEM ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOra.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.C_ID desc");
			}
			strSql.Append(")AS Row, T.*  from TMC_GIVEMARK_ITEM T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMC_GIVEMARK_ITEM";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
	
	}
}

