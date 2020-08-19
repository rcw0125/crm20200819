using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TB_FILE
	/// </summary>
	public partial class Dal_TB_FILE
	{
		public Dal_TB_FILE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_FILELINK,string C_FILENAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_FILE");
			strSql.Append(" where C_FILELINK='"+ C_FILELINK + "' and C_FILENAME='"+ C_FILENAME + "' ");
			return DbHelperOra.Exists(strSql.ToString());
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TB_FILE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_FILE(");
			strSql.Append("C_FILENAME,C_FILETYPE,C_FILEPATH,C_FILELINK,C_EMPID)");
			strSql.Append(" values (");
			strSql.Append(":C_FILENAME,:C_FILETYPE,:C_FILEPATH,:C_FILELINK,:C_EMPID)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_FILENAME", OracleDbType.Varchar2,500),
					new OracleParameter(":C_FILETYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FILEPATH", OracleDbType.Varchar2,500),
					new OracleParameter(":C_FILELINK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_FILENAME;
			parameters[1].Value = model.C_FILETYPE;
			parameters[2].Value = model.C_FILEPATH;
			parameters[3].Value = model.C_FILELINK;
			parameters[4].Value = model.C_EMPID;

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
		public bool Update(Mod_TB_FILE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_FILE set ");
			strSql.Append("C_FILENAME=:C_FILENAME,");
			strSql.Append("C_FILETYPE=:C_FILETYPE,");
			strSql.Append("C_FILEPATH=:C_FILEPATH,");
			strSql.Append("D_DT=:D_DT,");
			strSql.Append("C_EMPID=:C_EMPID");
			strSql.Append(" where C_FILELINK=:C_FILELINK ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_FILENAME", OracleDbType.Varchar2,500),
					new OracleParameter(":C_FILETYPE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FILEPATH", OracleDbType.Varchar2,500),
					new OracleParameter(":D_DT", OracleDbType.Date),
					new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_FILELINK", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_FILENAME;
			parameters[1].Value = model.C_FILETYPE;
			parameters[2].Value = model.C_FILEPATH;
			parameters[3].Value = model.D_DT;
			parameters[4].Value = model.C_EMPID;
			parameters[5].Value = model.C_FILELINK;

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
			strSql.Append("delete from TB_FILE ");
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
			strSql.Append("delete from TB_FILE ");
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
		public Mod_TB_FILE GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_FILENAME,C_FILETYPE,C_FILEPATH,C_FILELINK,D_DT,C_EMPID from TB_FILE ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TB_FILE model=new Mod_TB_FILE();
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
		public Mod_TB_FILE DataRowToModel(DataRow row)
		{
			Mod_TB_FILE model=new Mod_TB_FILE();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_FILENAME"]!=null)
				{
					model.C_FILENAME=row["C_FILENAME"].ToString();
				}
				if(row["C_FILETYPE"]!=null)
				{
					model.C_FILETYPE=row["C_FILETYPE"].ToString();
				}
				if(row["C_FILEPATH"]!=null)
				{
					model.C_FILEPATH=row["C_FILEPATH"].ToString();
				}
				if(row["C_FILELINK"]!=null)
				{
					model.C_FILELINK=row["C_FILELINK"].ToString();
				}
				if(row["D_DT"]!=null && row["D_DT"].ToString()!="")
				{
					model.D_DT=DateTime.Parse(row["D_DT"].ToString());
				}
				if(row["C_EMPID"]!=null)
				{
					model.C_EMPID=row["C_EMPID"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string pk)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat(@"SELECT C_ID,
       C_FILENAME,
       C_FILETYPE,
       C_FILEPATH,
       ('http://60.6.254.51:808' || replace(C_FILEPATH, '~', '')) C_FILEPATH2,
       C_FILELINK,
       D_DT,
       C_EMPID ");
			strSql.Append(" FROM TB_FILE  where 1=1");
			if(!string.IsNullOrEmpty(pk))
			{
				strSql.Append(" and C_FILELINK='"+pk+"' ");
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TB_FILE ");
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
			strSql.Append(")AS Row, T.*  from TB_FILE T ");
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

