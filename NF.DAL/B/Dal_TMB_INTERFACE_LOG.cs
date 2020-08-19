using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMB_INTERFACE_LOG
	/// </summary>
	public partial class Dal_TMB_INTERFACE_LOG
    {
		public Dal_TMB_INTERFACE_LOG()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMB_INTERFACE_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMB_INTERFACE_LOG(");
			strSql.Append("C_PKID,N_SENDNUM,C_EMPID,D_SENDTIME,C_RESULTCODE,C_RESULTDESC,C_CONTENT,C_REMARK,C_FLAG)");
			strSql.Append(" values (");
			strSql.Append(":C_PKID,:N_SENDNUM,:C_EMPID,:D_SENDTIME,:C_RESULTCODE,:C_RESULTDESC,:C_CONTENT,:C_REMARK,:C_FLAG)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":C_PKID", OracleDbType.Varchar2,500),
					new OracleParameter(":N_SENDNUM", OracleDbType.Decimal,2),
					new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
					new OracleParameter(":D_SENDTIME", OracleDbType.Date),
					new OracleParameter(":C_RESULTCODE", OracleDbType.Varchar2,3000),
					new OracleParameter(":C_RESULTDESC", OracleDbType.Varchar2,1000),
					new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,500),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_FLAG", OracleDbType.Varchar2,100)};
			
			parameters[0].Value = model.C_PKID;
			parameters[1].Value = model.N_SENDNUM;
			parameters[2].Value = model.C_EMPID;
			parameters[3].Value = model.D_SENDTIME;
			parameters[4].Value = model.C_RESULTCODE;
			parameters[5].Value = model.C_RESULTDESC;
			parameters[6].Value = model.C_CONTENT;
			parameters[7].Value = model.C_REMARK;
			parameters[8].Value = model.C_FLAG;

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
		public bool Update(Mod_TMB_INTERFACE_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMB_INTERFACE_LOG set ");
			strSql.Append("C_ID=:C_ID,");
			strSql.Append("C_PKID=:C_PKID,");
			strSql.Append("N_SENDNUM=:N_SENDNUM,");
			strSql.Append("C_EMPID=:C_EMPID,");
			strSql.Append("D_SENDTIME=:D_SENDTIME,");
			strSql.Append("C_RESULTCODE=:C_RESULTCODE,");
			strSql.Append("C_RESULTDESC=:C_RESULTDESC,");
			strSql.Append("C_CONTENT=:C_CONTENT,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_FLAG=:C_FLAG");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PKID", OracleDbType.Varchar2,100),
					new OracleParameter(":N_SENDNUM", OracleDbType.Decimal,2),
					new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
					new OracleParameter(":D_SENDTIME", OracleDbType.Date),
					new OracleParameter(":C_RESULTCODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_RESULTDESC", OracleDbType.Varchar2,500),
					new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,200),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_FLAG", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_PKID;
			parameters[2].Value = model.N_SENDNUM;
			parameters[3].Value = model.C_EMPID;
			parameters[4].Value = model.D_SENDTIME;
			parameters[5].Value = model.C_RESULTCODE;
			parameters[6].Value = model.C_RESULTDESC;
			parameters[7].Value = model.C_CONTENT;
			parameters[8].Value = model.C_REMARK;
			parameters[9].Value = model.C_FLAG;

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
			strSql.Append("delete from TMB_INTERFACE_LOG ");
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
		public Mod_TMB_INTERFACE_LOG GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_PKID,N_SENDNUM,C_EMPID,D_SENDTIME,C_RESULTCODE,C_RESULTDESC,C_CONTENT,C_REMARK,C_FLAG from TMB_INTERFACE_LOG ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Mod_TMB_INTERFACE_LOG model=new Mod_TMB_INTERFACE_LOG();
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
		public Mod_TMB_INTERFACE_LOG DataRowToModel(DataRow row)
		{
			Mod_TMB_INTERFACE_LOG model=new Mod_TMB_INTERFACE_LOG();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_PKID"]!=null)
				{
					model.C_PKID=row["C_PKID"].ToString();
				}
				if(row["N_SENDNUM"]!=null && row["N_SENDNUM"].ToString()!="")
				{
					model.N_SENDNUM=decimal.Parse(row["N_SENDNUM"].ToString());
				}
				if(row["C_EMPID"]!=null)
				{
					model.C_EMPID=row["C_EMPID"].ToString();
				}
				if(row["D_SENDTIME"]!=null && row["D_SENDTIME"].ToString()!="")
				{
					model.D_SENDTIME=DateTime.Parse(row["D_SENDTIME"].ToString());
				}
				if(row["C_RESULTCODE"]!=null)
				{
					model.C_RESULTCODE=row["C_RESULTCODE"].ToString();
				}
				if(row["C_RESULTDESC"]!=null)
				{
					model.C_RESULTDESC=row["C_RESULTDESC"].ToString();
				}
				if(row["C_CONTENT"]!=null)
				{
					model.C_CONTENT=row["C_CONTENT"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["C_FLAG"]!=null)
				{
					model.C_FLAG=row["C_FLAG"].ToString();
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
			strSql.Append("select C_ID,C_PKID,N_SENDNUM,C_EMPID,D_SENDTIME,C_RESULTCODE,C_RESULTDESC,C_CONTENT,C_REMARK,C_FLAG ");
			strSql.Append(" FROM TMB_INTERFACE_LOG ");
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
			strSql.Append("select count(1) FROM TMB_INTERFACE_LOG ");
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
				strSql.Append("order by T.C_NO desc");
			}
			strSql.Append(")AS Row, T.*  from TMB_INTERFACE_LOG T ");
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

