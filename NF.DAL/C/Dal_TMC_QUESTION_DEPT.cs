using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TMC_QUESTION_DEPT
	/// </summary>
	public partial class Dal_TMC_QUESTION_DEPT
    {
		public Dal_TMC_QUESTION_DEPT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TMC_QUESTION_DEPT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TMC_QUESTION_DEPT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TMC_QUESTION_DEPT(");
			strSql.Append("C_ID,C_QUESTION_ID,C_DEPT_ID,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_QUESTION_ID,:C_DEPT_ID,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_QUESTION_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_DEPT_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_QUESTION_ID;
			parameters[2].Value = model.C_DEPT_ID;
			parameters[3].Value = model.C_REMARK;
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
		public bool Update(Mod_TMC_QUESTION_DEPT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TMC_QUESTION_DEPT set ");
			strSql.Append("C_QUESTION_ID=:C_QUESTION_ID,");
			strSql.Append("C_DEPT_ID=:C_DEPT_ID,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_QUESTION_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_DEPT_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_QUESTION_ID;
			parameters[1].Value = model.C_DEPT_ID;
			parameters[2].Value = model.C_REMARK;
			parameters[3].Value = model.C_EMP_ID;
			parameters[4].Value = model.C_EMP_NAME;
			parameters[5].Value = model.D_MOD_DT;
			parameters[6].Value = model.C_ID;

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
			strSql.Append("delete from TMC_QUESTION_DEPT ");
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
			strSql.Append("delete from TMC_QUESTION_DEPT ");
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
		public Mod_TMC_QUESTION_DEPT GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_QUESTION_ID,C_DEPT_ID,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMC_QUESTION_DEPT ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TMC_QUESTION_DEPT model=new Mod_TMC_QUESTION_DEPT();
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
		public Mod_TMC_QUESTION_DEPT DataRowToModel(DataRow row)
		{
			Mod_TMC_QUESTION_DEPT model=new Mod_TMC_QUESTION_DEPT();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_QUESTION_ID"]!=null)
				{
					model.C_QUESTION_ID=row["C_QUESTION_ID"].ToString();
				}
				if(row["C_DEPT_ID"]!=null)
				{
					model.C_DEPT_ID=row["C_DEPT_ID"].ToString();
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
			strSql.Append("select C_ID,C_QUESTION_ID,C_DEPT_ID,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
			strSql.Append(" FROM TMC_QUESTION_DEPT ");
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
			strSql.Append("select count(1) FROM TMC_QUESTION_DEPT ");
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
			strSql.Append(")AS Row, T.*  from TMC_QUESTION_DEPT T ");
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
			parameters[0].Value = "TMC_QUESTION_DEPT";
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
       /// 获取技术处理部门
       /// </summary>
       /// <param name="C_QUESTION_ID">问题ID</param>
       /// <param name="C_DEPT_ID">部门ID</param>
       /// <returns></returns>
        public DataSet GetQuestion_Dept(string C_QUESTION_ID,string C_DEPT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUESTION_ID,C_DEPT_ID,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMC_QUESTION_DEPT where 1=1");
            if (!string .IsNullOrEmpty(C_QUESTION_ID))
            {
                strSql.Append(" and C_QUESTION_ID='"+ C_QUESTION_ID + "'");
            }
            if (!string.IsNullOrEmpty(C_DEPT_ID))
            {
                strSql.Append(" and C_DEPT_ID='" + C_DEPT_ID + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

       /// <summary>
       /// 根据问题主表ID删除字表数据
       /// </summary>
       /// <param name="C_QUESTION_ID">主表ID</param>
       /// <returns></returns>
		public bool DeleteQuestion_Dept(string C_QUESTION_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMC_QUESTION_DEPT ");
            strSql.Append(" where C_QUESTION_ID=:C_QUESTION_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QUESTION_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = C_QUESTION_ID;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion  ExtensionMethod
    }
}

