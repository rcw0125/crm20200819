using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_TAXITEMS
	/// </summary>
	public partial class Dal_TMB_TAXITEMS
    {
		public Dal_TMB_TAXITEMS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMB_TAXITEMS");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_TAXITEMS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_TAXITEMS(");
			strSql.Append("C_ID,C_TAXCODE,C_TAXNAME,N_TAXRATIO,D_TS,C_SOURCE)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_TAXCODE,:C_TAXNAME,:N_TAXRATIO,:D_TS,:C_SOURCE)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TAXCODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TAXNAME", OracleDbType.Varchar2,100),
					new OracleParameter(":N_TAXRATIO", OracleDbType.Decimal,15),
					new OracleParameter(":D_TS", OracleDbType.Date),
					new OracleParameter(":C_SOURCE", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_TAXCODE;
			parameters[2].Value = model.C_TAXNAME;
			parameters[3].Value = model.N_TAXRATIO;
			parameters[4].Value = model.D_TS;
			parameters[5].Value = model.C_SOURCE;

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
		public bool Update(Mod_TMB_TAXITEMS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_TAXITEMS set ");
			strSql.Append("C_TAXCODE=:C_TAXCODE,");
			strSql.Append("C_TAXNAME=:C_TAXNAME,");
			strSql.Append("N_TAXRATIO=:N_TAXRATIO,");
			strSql.Append("D_TS=:D_TS,");
			strSql.Append("C_SOURCE=:C_SOURCE");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_TAXCODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TAXNAME", OracleDbType.Varchar2,100),
					new OracleParameter(":N_TAXRATIO", OracleDbType.Decimal,15),
					new OracleParameter(":D_TS", OracleDbType.Date),
					new OracleParameter(":C_SOURCE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_TAXCODE;
			parameters[1].Value = model.C_TAXNAME;
			parameters[2].Value = model.N_TAXRATIO;
			parameters[3].Value = model.D_TS;
			parameters[4].Value = model.C_SOURCE;
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
			strSql.Append("delete from TMB_TAXITEMS ");
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
			strSql.Append("delete from TMB_TAXITEMS ");
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
		public Mod_TMB_TAXITEMS GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_TAXCODE,C_TAXNAME,N_TAXRATIO,D_TS,C_SOURCE from TMB_TAXITEMS ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMB_TAXITEMS model=new Mod_TMB_TAXITEMS();
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
		public Mod_TMB_TAXITEMS DataRowToModel(DataRow row)
		{
			Mod_TMB_TAXITEMS model=new Mod_TMB_TAXITEMS();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_TAXCODE"]!=null)
				{
					model.C_TAXCODE=row["C_TAXCODE"].ToString();
				}
				if(row["C_TAXNAME"]!=null)
				{
					model.C_TAXNAME=row["C_TAXNAME"].ToString();
				}
				if(row["N_TAXRATIO"]!=null && row["N_TAXRATIO"].ToString()!="")
				{
					model.N_TAXRATIO=decimal.Parse(row["N_TAXRATIO"].ToString());
				}
				if(row["D_TS"]!=null && row["D_TS"].ToString()!="")
				{
					model.D_TS=DateTime.Parse(row["D_TS"].ToString());
				}
				if(row["C_SOURCE"]!=null)
				{
					model.C_SOURCE=row["C_SOURCE"].ToString();
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
			strSql.Append("select C_ID,C_TAXCODE,C_TAXNAME,N_TAXRATIO,D_TS,C_SOURCE ");
			strSql.Append(" FROM TMB_TAXITEMS ");
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
			strSql.Append("select count(1) FROM TMB_TAXITEMS ");
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
			strSql.Append(")AS Row, T.*  from TMB_TAXITEMS T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

	

		#endregion  BasicMethod
		
	}
}

