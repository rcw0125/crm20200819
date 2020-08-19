using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_ACTIVITY_LOG
	/// </summary>
	public partial class Dal_TMB_ACTIVITY_LOG
    {
		public Dal_TMB_ACTIVITY_LOG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMB_ACTIVITY_LOG");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_ACTIVITY_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_ACTIVITY_LOG(");
			strSql.Append("C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_DISCOUNT,N_RATE,N_ORIMOTO,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME)");
			strSql.Append(" values (");
			strSql.Append(":C_MAT_CODE,:C_MAT_NAME,:C_STL_GRD,:C_SPEC,:N_PRICE,:N_DISCOUNT,:N_RATE,:N_ORIMOTO,:C_STATUS,:C_REMARK,:C_EMP_ID,:C_EMP_NAME)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
					new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
					new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_DISCOUNT", OracleDbType.Decimal,15),
					new OracleParameter(":N_RATE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIMOTO", OracleDbType.Decimal,15),
					new OracleParameter(":C_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20)};
			
			parameters[0].Value = model.C_MAT_CODE;
			parameters[1].Value = model.C_MAT_NAME;
			parameters[2].Value = model.C_STL_GRD;
			parameters[3].Value = model.C_SPEC;
			parameters[4].Value = model.N_PRICE;
			parameters[5].Value = model.N_DISCOUNT;
			parameters[6].Value = model.N_RATE;
			parameters[7].Value = model.N_ORIMOTO;
			parameters[8].Value = model.C_STATUS;
			parameters[9].Value = model.C_REMARK;
			parameters[10].Value = model.C_EMP_ID;
			parameters[11].Value = model.C_EMP_NAME;
			

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
		public bool Update(Mod_TMB_ACTIVITY_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_ACTIVITY_LOG set ");
			strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
			strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
			strSql.Append("C_STL_GRD=:C_STL_GRD,");
			strSql.Append("C_SPEC=:C_SPEC,");
			strSql.Append("N_PRICE=:N_PRICE,");
			strSql.Append("N_DISCOUNT=:N_DISCOUNT,");
			strSql.Append("N_RATE=:N_RATE,");
			strSql.Append("N_ORIMOTO=:N_ORIMOTO,");
			strSql.Append("C_STATUS=:C_STATUS,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
					new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
					new OracleParameter(":N_PRICE", OracleDbType.Decimal,15),
					new OracleParameter(":N_DISCOUNT", OracleDbType.Decimal,15),
					new OracleParameter(":N_RATE", OracleDbType.Decimal,15),
					new OracleParameter(":N_ORIMOTO", OracleDbType.Decimal,15),
					new OracleParameter(":C_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_MAT_CODE;
			parameters[1].Value = model.C_MAT_NAME;
			parameters[2].Value = model.C_STL_GRD;
			parameters[3].Value = model.C_SPEC;
			parameters[4].Value = model.N_PRICE;
			parameters[5].Value = model.N_DISCOUNT;
			parameters[6].Value = model.N_RATE;
			parameters[7].Value = model.N_ORIMOTO;
			parameters[8].Value = model.C_STATUS;
			parameters[9].Value = model.C_REMARK;
			parameters[10].Value = model.C_EMP_ID;
			parameters[11].Value = model.C_EMP_NAME;
			parameters[12].Value = model.D_MOD_DT;
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
			strSql.Append("delete from TMB_ACTIVITY_LOG ");
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
			strSql.Append("delete from TMB_ACTIVITY_LOG ");
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
		public Mod_TMB_ACTIVITY_LOG GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_DISCOUNT,N_RATE,N_ORIMOTO,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_ACTIVITY_LOG ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMB_ACTIVITY_LOG model=new Mod_TMB_ACTIVITY_LOG();
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
		public Mod_TMB_ACTIVITY_LOG DataRowToModel(DataRow row)
		{
			Mod_TMB_ACTIVITY_LOG model=new Mod_TMB_ACTIVITY_LOG();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_MAT_CODE"]!=null)
				{
					model.C_MAT_CODE=row["C_MAT_CODE"].ToString();
				}
				if(row["C_MAT_NAME"]!=null)
				{
					model.C_MAT_NAME=row["C_MAT_NAME"].ToString();
				}
				if(row["C_STL_GRD"]!=null)
				{
					model.C_STL_GRD=row["C_STL_GRD"].ToString();
				}
				if(row["C_SPEC"]!=null)
				{
					model.C_SPEC=row["C_SPEC"].ToString();
				}
				if(row["N_PRICE"]!=null && row["N_PRICE"].ToString()!="")
				{
					model.N_PRICE=decimal.Parse(row["N_PRICE"].ToString());
				}
				if(row["N_DISCOUNT"]!=null && row["N_DISCOUNT"].ToString()!="")
				{
					model.N_DISCOUNT=decimal.Parse(row["N_DISCOUNT"].ToString());
				}
				if(row["N_RATE"]!=null && row["N_RATE"].ToString()!="")
				{
					model.N_RATE=decimal.Parse(row["N_RATE"].ToString());
				}
				if(row["N_ORIMOTO"]!=null && row["N_ORIMOTO"].ToString()!="")
				{
					model.N_ORIMOTO=decimal.Parse(row["N_ORIMOTO"].ToString());
				}
				if(row["C_STATUS"]!=null && row["C_STATUS"].ToString()!="")
				{
					model.C_STATUS=decimal.Parse(row["C_STATUS"].ToString());
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
			strSql.Append("select C_ID,C_MAT_CODE,C_MAT_NAME,C_STL_GRD,C_SPEC,N_PRICE,N_DISCOUNT,N_RATE,N_ORIMOTO,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMB_ACTIVITY_LOG ");
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
			strSql.Append("select count(1) FROM TMB_ACTIVITY_LOG ");
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
			strSql.Append(")AS Row, T.*  from TMB_ACTIVITY_LOG T ");
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

