using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMQ_QUALITY_FILE
	/// </summary>
	public partial class Dal_TMQ_QUALITY_FILE
    {
		public Dal_TMQ_QUALITY_FILE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMQ_QUALITY_FILE");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMQ_QUALITY_FILE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMQ_QUALITY_FILE(");
			strSql.Append("C_QUALITY_ID,C_TITLE,C_PATH,C_REMARK)");
			strSql.Append(" values (");
			strSql.Append(":C_QUALITY_ID,:C_TITLE,:C_PATH,:C_REMARK)");
			OracleParameter[] parameters = {
					

					new OracleParameter(":C_QUALITY_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TITLE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PATH", OracleDbType.Varchar2,200),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200)};
			

			parameters[0].Value = model.C_QUALITY_ID;
			parameters[1].Value = model.C_TITLE;
			parameters[2].Value = model.C_PATH;
			parameters[3].Value = model.C_REMARK;

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
		public bool Update(Mod_TMQ_QUALITY_FILE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMQ_QUALITY_FILE set ");
			strSql.Append("C_QUALITY_ID=:C_QUALITY_ID,");
			strSql.Append("C_TITLE=:C_TITLE,");
			strSql.Append("C_PATH=:C_PATH,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("D_DT=:D_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_QUALITY_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_TITLE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PATH", OracleDbType.Varchar2,200),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":D_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_QUALITY_ID;
			parameters[1].Value = model.C_TITLE;
			parameters[2].Value = model.C_PATH;
			parameters[3].Value = model.C_REMARK;
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
			strSql.Append("delete from TMQ_QUALITY_FILE ");
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
			strSql.Append("delete from TMQ_QUALITY_FILE ");
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
		public Mod_TMQ_QUALITY_FILE GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_QUALITY_ID,C_TITLE,C_PATH,C_REMARK,D_DT from TMQ_QUALITY_FILE ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMQ_QUALITY_FILE model=new Mod_TMQ_QUALITY_FILE();
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
		public Mod_TMQ_QUALITY_FILE DataRowToModel(DataRow row)
		{
			Mod_TMQ_QUALITY_FILE model=new Mod_TMQ_QUALITY_FILE();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_QUALITY_ID"]!=null)
				{
					model.C_QUALITY_ID=row["C_QUALITY_ID"].ToString();
				}
				if(row["C_TITLE"]!=null)
				{
					model.C_TITLE=row["C_TITLE"].ToString();
				}
				if(row["C_PATH"]!=null)
				{
					model.C_PATH=row["C_PATH"].ToString();
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
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
			strSql.Append("select C_ID,C_QUALITY_ID,C_TITLE,C_PATH,C_REMARK,D_DT ");
			strSql.Append(" FROM TMQ_QUALITY_FILE ");
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
			strSql.Append("select count(1) FROM TMQ_QUALITY_FILE ");
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
			strSql.Append(")AS Row, T.*  from TMQ_QUALITY_FILE T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMQ_QUALITY_FILE";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

       /// <summary>
       /// 获取质量附件
       /// </summary>
       /// <param name="C_QUALITY_ID">质量ID</param>
       /// <returns></returns>
        public DataSet GetQualityFileList(string C_QUALITY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUALITY_ID,C_TITLE,C_PATH,C_REMARK,D_DT ");
            strSql.Append(" FROM TMQ_QUALITY_FILE  where C_QUALITY_ID='"+ C_QUALITY_ID + "'");
           
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

