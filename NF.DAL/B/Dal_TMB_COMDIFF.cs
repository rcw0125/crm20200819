using System;
using System.Data;
using System.Text;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
using System.Linq;

namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_COMDIFF
	/// </summary>
	public partial class Dal_TMB_COMDIFF
    {
		public Dal_TMB_COMDIFF()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMB_COMDIFF");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_COMDIFF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_COMDIFF(");
			strSql.Append("C_ID,D_MIN,D_MAX,C_RANGE,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:D_MIN,:D_MAX,:C_RANGE,:N_STATUS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":D_MIN", OracleDbType.Decimal,9),
					new OracleParameter(":D_MAX", OracleDbType.Decimal,9),
					new OracleParameter(":C_RANGE", OracleDbType.Varchar2,20),
					new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.D_MIN;
			parameters[2].Value = model.D_MAX;
			parameters[3].Value = model.C_RANGE;
			parameters[4].Value = model.N_STATUS;
			parameters[5].Value = model.C_EMP_ID;
			parameters[6].Value = model.C_EMP_NAME;
			parameters[7].Value = model.D_MOD_DT;

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
		public bool Update(Mod_TMB_COMDIFF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_COMDIFF set ");
			strSql.Append("D_MIN=:D_MIN,");
			strSql.Append("D_MAX=:D_MAX,");
			strSql.Append("C_RANGE=:C_RANGE,");
			strSql.Append("N_STATUS=:N_STATUS,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":D_MIN", OracleDbType.Decimal,9),
					new OracleParameter(":D_MAX", OracleDbType.Decimal,9),
					new OracleParameter(":C_RANGE", OracleDbType.Varchar2,20),
					new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.D_MIN;
			parameters[1].Value = model.D_MAX;
			parameters[2].Value = model.C_RANGE;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.C_EMP_ID;
			parameters[5].Value = model.C_EMP_NAME;
			parameters[6].Value = model.D_MOD_DT;
			parameters[7].Value = model.C_ID;

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
			strSql.Append("delete from TMB_COMDIFF ");
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
			strSql.Append("delete from TMB_COMDIFF ");
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
		public Mod_TMB_COMDIFF GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,D_MIN,D_MAX,C_RANGE,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_COMDIFF ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMB_COMDIFF model=new Mod_TMB_COMDIFF();
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
		public Mod_TMB_COMDIFF DataRowToModel(DataRow row)
		{
			Mod_TMB_COMDIFF model=new Mod_TMB_COMDIFF();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["D_MIN"]!=null && row["D_MIN"].ToString()!="")
				{
					model.D_MIN=decimal.Parse(row["D_MIN"].ToString());
				}
				if(row["D_MAX"]!=null && row["D_MAX"].ToString()!="")
				{
					model.D_MAX=decimal.Parse(row["D_MAX"].ToString());
				}
				if(row["C_RANGE"]!=null)
				{
					model.C_RANGE=row["C_RANGE"].ToString();
				}
				if(row["N_STATUS"]!=null && row["N_STATUS"].ToString()!="")
				{
					model.N_STATUS=decimal.Parse(row["N_STATUS"].ToString());
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
		/// 获取工差范围
		/// </summary>
		public DataSet GetRangeList(decimal num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_range from TMB_COMDIFF t where  "+num+">t.d_min and "+num+"<=t.d_max  and  t.n_status=1 ");
            
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,D_MIN,D_MAX,C_RANGE,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMB_COMDIFF ");
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
			strSql.Append("select count(1) FROM TMB_COMDIFF ");
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
			strSql.Append(")AS Row, T.*  from TMB_COMDIFF T ");
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

