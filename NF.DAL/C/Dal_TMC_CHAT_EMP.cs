using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMC_CHAT_EMP
	/// </summary>
	public partial class Dal_TMC_CHAT_EMP
    {
		public Dal_TMC_CHAT_EMP()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMC_CHAT_EMP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMC_CHAT_EMP(");
			strSql.Append("C_ID,C_USER_ID,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_USER_ID,:C_REMARK,:N_STATUS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_USER_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_USER_ID;
			parameters[2].Value = model.C_REMARK;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.C_EMP_ID;
			parameters[5].Value = model.C_EMP_NAME;
			parameters[6].Value = model.D_MOD_DT;

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
		public bool Update(Mod_TMC_CHAT_EMP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMC_CHAT_EMP set ");
			
			strSql.Append("C_USER_ID=:C_USER_ID,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("N_STATUS=:N_STATUS,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_USER_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_USER_ID;
			parameters[2].Value = model.C_REMARK;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.C_EMP_ID;
			parameters[5].Value = model.C_EMP_NAME;
			parameters[6].Value = model.D_MOD_DT;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TMC_CHAT_EMP ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Mod_TMC_CHAT_EMP GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_USER_ID,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMC_CHAT_EMP ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Mod_TMC_CHAT_EMP model=new Mod_TMC_CHAT_EMP();
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
		public Mod_TMC_CHAT_EMP DataRowToModel(DataRow row)
		{
			Mod_TMC_CHAT_EMP model=new Mod_TMC_CHAT_EMP();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_USER_ID"]!=null)
				{
					model.C_USER_ID=row["C_USER_ID"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_USER_ID,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMC_CHAT_EMP ");
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
			strSql.Append("select count(1) FROM TMC_CHAT_EMP ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from TMC_CHAT_EMP T ");
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

        /// <summary>
        /// 随机获取客服
        /// </summary>
        /// <returns></returns>
        public DataRow GetChatEmp()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_user_id  from ts_user_role t where t.c_role_id in (select t.c_user_id from tmc_chat_emp t) and rownum = 1 order by dbms_random.value");
            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获取客服列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSaleEmp()
        {
            string strSql = string.Format(@"SELECT A.C_NAME, A.C_ID
                                              FROM TS_USER_ROLE T
                                             INNER JOIN TS_USER A
                                                ON A.C_ID = T.C_USER_ID
                                             INNER JOIN TS_ROLE B
                                                ON B.C_ID = T.C_ROLE_ID
                                             WHERE B.C_CODE = 'z-002'
                                               AND A.C_NAME IS NOT NULL");
            return DbHelperOra.Query(strSql);
        }

		#endregion  ExtensionMethod
	}
}

