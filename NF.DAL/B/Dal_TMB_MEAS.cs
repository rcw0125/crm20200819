using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_MEAS
	/// </summary>
	public partial class Dal_TMB_MEAS
    {
		public Dal_TMB_MEAS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMB_MEAS");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_MEAS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_MEAS(");
			strSql.Append("C_ID,C_TYPE,C_NAME,N_SCALEF_ACTOR,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_TYPE,:C_NAME,:N_SCALEF_ACTOR,:C_STATUS,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":N_SCALEF_ACTOR", OracleDbType.Decimal,15),
					new OracleParameter(":C_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_TYPE;
			parameters[2].Value = model.C_NAME;
			parameters[3].Value = model.N_SCALEF_ACTOR;
			parameters[4].Value = model.C_STATUS;
			parameters[5].Value = model.C_REMARK;
			parameters[6].Value = model.C_EMP_ID;
			parameters[7].Value = model.C_EMP_NAME;
			parameters[8].Value = model.D_MOD_DT;

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
		public bool Update(Mod_TMB_MEAS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_MEAS set ");
			strSql.Append("C_TYPE=:C_TYPE,");
			strSql.Append("C_NAME=:C_NAME,");
			strSql.Append("N_SCALEF_ACTOR=:N_SCALEF_ACTOR,");
			strSql.Append("C_STATUS=:C_STATUS,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":N_SCALEF_ACTOR", OracleDbType.Decimal,15),
					new OracleParameter(":C_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_TYPE;
			parameters[1].Value = model.C_NAME;
			parameters[2].Value = model.N_SCALEF_ACTOR;
			parameters[3].Value = model.C_STATUS;
			parameters[4].Value = model.C_REMARK;
			parameters[5].Value = model.C_EMP_ID;
			parameters[6].Value = model.C_EMP_NAME;
			parameters[7].Value = model.D_MOD_DT;
			parameters[8].Value = model.C_ID;

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
			strSql.Append("delete from TMB_MEAS ");
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
			strSql.Append("delete from TMB_MEAS ");
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
		public Mod_TMB_MEAS GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_TYPE,C_NAME,N_SCALEF_ACTOR,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_MEAS ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMB_MEAS model=new Mod_TMB_MEAS();
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
		public Mod_TMB_MEAS DataRowToModel(DataRow row)
		{
			Mod_TMB_MEAS model=new Mod_TMB_MEAS();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_TYPE"]!=null)
				{
					model.C_TYPE=row["C_TYPE"].ToString();
				}
				if(row["C_NAME"]!=null)
				{
					model.C_NAME=row["C_NAME"].ToString();
				}
				if(row["N_SCALEF_ACTOR"]!=null && row["N_SCALEF_ACTOR"].ToString()!="")
				{
					model.N_SCALEF_ACTOR=decimal.Parse(row["N_SCALEF_ACTOR"].ToString());
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
		public DataSet GetTypeList(string typeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPE,C_NAME,N_SCALEF_ACTOR,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_MEAS where C_STATUS=1 ");
            
            if(!string .IsNullOrEmpty(typeName))
            {
                strSql.Append(" and C_TYPE='"+typeName+"'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_TYPE,C_NAME,N_SCALEF_ACTOR,C_STATUS,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMB_MEAS ");
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
			strSql.Append("select count(1) FROM TMB_MEAS ");
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
			strSql.Append(")AS Row, T.*  from TMB_MEAS T ");
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

