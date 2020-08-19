using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;

namespace NF.DAL
{
	/// <summary>
	/// 合同条例
	/// </summary>
	public partial class Dal_TMO_CONRULES
    {
		public Dal_TMO_CONRULES()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_CON_NO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMO_CONRULES");
			strSql.Append(" where C_CON_NO=:C_CON_NO ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_CON_NO;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMO_CONRULES model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMO_CONRULES(");
			strSql.Append("C_CON_NO,C_NAME,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_CON_NO,:C_NAME,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_NAME", OracleDbType.Char,10),
					new OracleParameter(":C_REMARK", OracleDbType.Char,10),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_CON_NO;
			parameters[1].Value = model.C_NAME;
			parameters[2].Value = model.C_REMARK;
			parameters[3].Value = model.C_EMP_ID;
			parameters[4].Value = model.C_EMP_NAME;
			parameters[5].Value = model.D_MOD_DT;

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
		public bool Update(Mod_TMO_CONRULES model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMO_CONRULES set ");
			strSql.Append("C_NAME=:C_NAME,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_CON_NO=:C_CON_NO ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_NAME", OracleDbType.Char,10),
					new OracleParameter(":C_REMARK", OracleDbType.Char,10),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_NAME;
			parameters[1].Value = model.C_REMARK;
			parameters[2].Value = model.C_EMP_ID;
			parameters[3].Value = model.C_EMP_NAME;
			parameters[4].Value = model.D_MOD_DT;
			parameters[5].Value = model.C_CON_NO;

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
		public bool Delete(string C_CON_NO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMO_CONRULES ");
			strSql.Append(" where C_CON_NO=:C_CON_NO ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_CON_NO;

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
		public bool DeleteList(string C_CON_NOlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMO_CONRULES ");
			strSql.Append(" where C_CON_NO in ("+C_CON_NOlist + ")  ");
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
		public Mod_TMO_CONRULES GetModel(string C_CON_NO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_CON_NO,C_NAME,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMO_CONRULES ");
			strSql.Append(" where C_CON_NO=:C_CON_NO ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_CON_NO;

			Mod_TMO_CONRULES model=new Mod_TMO_CONRULES();
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
		public Mod_TMO_CONRULES DataRowToModel(DataRow row)
		{
			Mod_TMO_CONRULES model=new Mod_TMO_CONRULES();
			if (row != null)
			{
				if(row["C_CON_NO"]!=null)
				{
					model.C_CON_NO=row["C_CON_NO"].ToString();
				}
				if(row["C_NAME"]!=null)
				{
					model.C_NAME=row["C_NAME"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["C_EMP_ID"]!=null)
				{
					model.C_EMP_ID=row["C_EMP_ID"].ToString();
				}
				if(row["C_EMP_NAME"]!=null)
				{
					model.C_EMP_NAME=row["C_EMP_NAME"].ToString();
				}
				if(row["D_MOD_DT"]!=null && row["D_MOD_DT"].ToString()!="")
				{
					model.D_MOD_DT=DateTime.Parse(row["D_MOD_DT"].ToString());
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
			strSql.Append("select C_CON_NO,C_NAME,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMO_CONRULES ");
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
			strSql.Append("select count(1) FROM TMO_CONRULES ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj =DbHelperOra.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.C_CON_NO desc");
			}
			strSql.Append(")AS Row, T.*  from TMO_CONRULES T ");
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

