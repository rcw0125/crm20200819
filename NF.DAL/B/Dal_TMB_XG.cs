using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_XG
	/// </summary>
	public partial class Dal_TMB_XG
    {
		public Dal_TMB_XG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMB_XG");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_XG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_XG(");
			strSql.Append("C_ID,C_NAME,C_FR,C_WT,C_JB,C_TEL,C_FAX,C_BANK_NAME,C_BANK_NO,C_REMARK,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_NAME,:C_FR,:C_WT,:C_JB,:C_TEL,:C_FAX,:C_BANK_NAME,:C_BANK_NO,:C_REMARK,:C_EXTEND1,:C_EXTEND2,:C_EXTEND3,:C_EXTEND4)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FR", OracleDbType.Varchar2,100),
					new OracleParameter(":C_WT", OracleDbType.Varchar2,100),
					new OracleParameter(":C_JB", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TEL", OracleDbType.Varchar2,15),
					new OracleParameter(":C_FAX", OracleDbType.Varchar2,15),
					new OracleParameter(":C_BANK_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_BANK_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_NAME;
			parameters[2].Value = model.C_FR;
			parameters[3].Value = model.C_WT;
			parameters[4].Value = model.C_JB;
			parameters[5].Value = model.C_TEL;
			parameters[6].Value = model.C_FAX;
			parameters[7].Value = model.C_BANK_NAME;
			parameters[8].Value = model.C_BANK_NO;
			parameters[9].Value = model.C_REMARK;
			parameters[10].Value = model.C_EXTEND1;
			parameters[11].Value = model.C_EXTEND2;
			parameters[12].Value = model.C_EXTEND3;
			parameters[13].Value = model.C_EXTEND4;

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
		public bool Update(Mod_TMB_XG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_XG set ");
			strSql.Append("C_NAME=:C_NAME,");
			strSql.Append("C_FR=:C_FR,");
			strSql.Append("C_WT=:C_WT,");
			strSql.Append("C_JB=:C_JB,");
			strSql.Append("C_TEL=:C_TEL,");
			strSql.Append("C_FAX=:C_FAX,");
			strSql.Append("C_BANK_NAME=:C_BANK_NAME,");
			strSql.Append("C_BANK_NO=:C_BANK_NO,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EXTEND1=:C_EXTEND1,");
			strSql.Append("C_EXTEND2=:C_EXTEND2,");
			strSql.Append("C_EXTEND3=:C_EXTEND3,");
			strSql.Append("C_EXTEND4=:C_EXTEND4");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FR", OracleDbType.Varchar2,100),
					new OracleParameter(":C_WT", OracleDbType.Varchar2,100),
					new OracleParameter(":C_JB", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TEL", OracleDbType.Varchar2,15),
					new OracleParameter(":C_FAX", OracleDbType.Varchar2,15),
					new OracleParameter(":C_BANK_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_BANK_NO", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_NAME;
			parameters[1].Value = model.C_FR;
			parameters[2].Value = model.C_WT;
			parameters[3].Value = model.C_JB;
			parameters[4].Value = model.C_TEL;
			parameters[5].Value = model.C_FAX;
			parameters[6].Value = model.C_BANK_NAME;
			parameters[7].Value = model.C_BANK_NO;
			parameters[8].Value = model.C_REMARK;
			parameters[9].Value = model.C_EXTEND1;
			parameters[10].Value = model.C_EXTEND2;
			parameters[11].Value = model.C_EXTEND3;
			parameters[12].Value = model.C_EXTEND4;
			parameters[13].Value = model.C_ID;

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
			strSql.Append("delete from TMB_XG ");
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
			strSql.Append("delete from TMB_XG ");
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
		public Mod_TMB_XG GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_NAME,C_FR,C_WT,C_JB,C_TEL,C_FAX,C_BANK_NAME,C_BANK_NO,C_REMARK,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4 from TMB_XG ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMB_XG model=new Mod_TMB_XG();
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
		public Mod_TMB_XG DataRowToModel(DataRow row)
		{
			Mod_TMB_XG model=new Mod_TMB_XG();
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
				if(row["C_FR"]!=null)
				{
					model.C_FR=row["C_FR"].ToString();
				}
				if(row["C_WT"]!=null)
				{
					model.C_WT=row["C_WT"].ToString();
				}
				if(row["C_JB"]!=null)
				{
					model.C_JB=row["C_JB"].ToString();
				}
				if(row["C_TEL"]!=null)
				{
					model.C_TEL=row["C_TEL"].ToString();
				}
				if(row["C_FAX"]!=null)
				{
					model.C_FAX=row["C_FAX"].ToString();
				}
				if(row["C_BANK_NAME"]!=null)
				{
					model.C_BANK_NAME=row["C_BANK_NAME"].ToString();
				}
				if(row["C_BANK_NO"]!=null)
				{
					model.C_BANK_NO=row["C_BANK_NO"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["C_EXTEND1"]!=null)
				{
					model.C_EXTEND1=row["C_EXTEND1"].ToString();
				}
				if(row["C_EXTEND2"]!=null)
				{
					model.C_EXTEND2=row["C_EXTEND2"].ToString();
				}
				if(row["C_EXTEND3"]!=null)
				{
					model.C_EXTEND3=row["C_EXTEND3"].ToString();
				}
				if(row["C_EXTEND4"]!=null)
				{
					model.C_EXTEND4=row["C_EXTEND4"].ToString();
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
			strSql.Append("select C_ID,C_NAME,C_FR,C_WT,C_JB,C_TEL,C_FAX,C_BANK_NAME,C_BANK_NO,C_REMARK,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4 ");
			strSql.Append(" FROM TMB_XG ");
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
			strSql.Append("select count(1) FROM TMB_XG ");
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
			strSql.Append(")AS Row, T.*  from TMB_XG T ");
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

