using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMO_ORDER_MATCH
	/// </summary>
	public partial class Dal_TMO_ORDER_MATCH
    {
		public Dal_TMO_ORDER_MATCH()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMO_ORDER_MATCH");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMO_ORDER_MATCH model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMO_ORDER_MATCH(");
			strSql.Append("C_ORDER_NO,C_MATCH_ID,C_OLD_ORDER_NO,C_TYPE)");
			strSql.Append(" values (");
			strSql.Append(":C_ORDER_NO,:C_MATCH_ID,:C_OLD_ORDER_NO,:C_TYPE)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_MATCH_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_OLD_ORDER_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TYPE", OracleDbType.Decimal,2)};
			
			parameters[0].Value = model.C_ORDER_NO;
			parameters[1].Value = model.C_MATCH_ID;
			parameters[2].Value = model.C_OLD_ORDER_NO;
			parameters[3].Value = model.C_TYPE;

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
		public bool Update(Mod_TMO_ORDER_MATCH model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMO_ORDER_MATCH set ");
			strSql.Append("C_ORDER_NO=:C_ORDER_NO,");
			strSql.Append("C_MATCH_ID=:C_MATCH_ID,");
			strSql.Append("C_OLD_ORDER_NO=:C_OLD_ORDER_NO,");
			strSql.Append("C_TYPE=:C_TYPE,");
			strSql.Append("D_DT=:D_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_MATCH_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_OLD_ORDER_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TYPE", OracleDbType.Decimal,2),
					new OracleParameter(":D_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_ORDER_NO;
			parameters[1].Value = model.C_MATCH_ID;
			parameters[2].Value = model.C_OLD_ORDER_NO;
			parameters[3].Value = model.C_TYPE;
			parameters[4].Value = model.D_DT;
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
			strSql.Append("delete from TMO_ORDER_MATCH ");
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
			strSql.Append("delete from TMO_ORDER_MATCH ");
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
		public Mod_TMO_ORDER_MATCH GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_ORDER_NO,C_MATCH_ID,C_OLD_ORDER_NO,C_TYPE,D_DT from TMO_ORDER_MATCH ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMO_ORDER_MATCH model=new Mod_TMO_ORDER_MATCH();
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
		public Mod_TMO_ORDER_MATCH DataRowToModel(DataRow row)
		{
			Mod_TMO_ORDER_MATCH model=new Mod_TMO_ORDER_MATCH();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_ORDER_NO"]!=null)
				{
					model.C_ORDER_NO=row["C_ORDER_NO"].ToString();
				}
				if(row["C_MATCH_ID"]!=null)
				{
					model.C_MATCH_ID=row["C_MATCH_ID"].ToString();
				}
				if(row["C_OLD_ORDER_NO"]!=null)
				{
					model.C_OLD_ORDER_NO=row["C_OLD_ORDER_NO"].ToString();
				}
				if(row["C_TYPE"]!=null && row["C_TYPE"].ToString()!="")
				{
					model.C_TYPE=decimal.Parse(row["C_TYPE"].ToString());
				}
				if(row["D_DT"]!=null && row["D_DT"].ToString()!="")
				{
					model.D_DT=DateTime.Parse(row["D_DT"].ToString());
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
			strSql.Append("select C_ID,C_ORDER_NO,C_MATCH_ID,C_OLD_ORDER_NO,C_TYPE,D_DT ");
			strSql.Append(" FROM TMO_ORDER_MATCH ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TMO_ORDER_MATCH ");
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
			strSql.Append(")AS Row, T.*  from TMO_ORDER_MATCH T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

		

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

