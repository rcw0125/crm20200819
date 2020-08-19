using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TQ_MODULE
	/// </summary>
	public partial class Dal_TQ_MODULE
    {
		public Dal_TQ_MODULE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TQ_MODULE");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TQ_MODULE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TQ_MODULE(");
			strSql.Append("C_ID,C_CLASS,C_MODULE,C_CONENT,C_XGEMP,C_DEPT,C_TEL,D_TIME,C_ICT,C_RESULT,D_ICTTIME,C_REAMRK)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_CLASS,:C_MODULE,:C_CONENT,:C_XGEMP,:C_DEPT,:C_TEL,:D_TIME,:C_ICT,:C_RESULT,:D_ICTTIME,:C_REAMRK)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.NVarchar2),
					new OracleParameter(":C_CLASS", OracleDbType.Varchar2),
					new OracleParameter(":C_MODULE", OracleDbType.Varchar2),
					new OracleParameter(":C_CONENT", OracleDbType.Varchar2),
					new OracleParameter(":C_XGEMP", OracleDbType.Varchar2),
					new OracleParameter(":C_DEPT", OracleDbType.Varchar2),
					new OracleParameter(":C_TEL", OracleDbType.Varchar2),
					new OracleParameter(":D_TIME", OracleDbType.Date),
					new OracleParameter(":C_ICT", OracleDbType.Varchar2),
					new OracleParameter(":C_RESULT", OracleDbType.Varchar2),
					new OracleParameter(":D_ICTTIME", OracleDbType.Date),
					new OracleParameter(":C_REAMRK", OracleDbType.Varchar2)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_CLASS;
			parameters[2].Value = model.C_MODULE;
			parameters[3].Value = model.C_CONENT;
			parameters[4].Value = model.C_XGEMP;
			parameters[5].Value = model.C_DEPT;
			parameters[6].Value = model.C_TEL;
			parameters[7].Value = model.D_TIME;
			parameters[8].Value = model.C_ICT;
			parameters[9].Value = model.C_RESULT;
			parameters[10].Value = model.D_ICTTIME;
			parameters[11].Value = model.C_REAMRK;

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
		public bool Update(Mod_TQ_MODULE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TQ_MODULE set ");
			strSql.Append("C_CLASS=:C_CLASS,");
			strSql.Append("C_MODULE=:C_MODULE,");
			strSql.Append("C_CONENT=:C_CONENT,");
			strSql.Append("C_XGEMP=:C_XGEMP,");
			strSql.Append("C_DEPT=:C_DEPT,");
			strSql.Append("C_TEL=:C_TEL,");
			strSql.Append("D_TIME=:D_TIME,");
			strSql.Append("C_ICT=:C_ICT,");
			strSql.Append("C_RESULT=:C_RESULT,");
			strSql.Append("D_ICTTIME=:D_ICTTIME,");
			strSql.Append("C_REAMRK=:C_REAMRK");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CLASS", OracleDbType.Varchar2),
					new OracleParameter(":C_MODULE", OracleDbType.Varchar2),
					new OracleParameter(":C_CONENT", OracleDbType.Varchar2),
					new OracleParameter(":C_XGEMP", OracleDbType.Varchar2),
					new OracleParameter(":C_DEPT", OracleDbType.Varchar2),
					new OracleParameter(":C_TEL", OracleDbType.Varchar2),
					new OracleParameter(":D_TIME", OracleDbType.Date),
					new OracleParameter(":C_ICT", OracleDbType.Varchar2),
					new OracleParameter(":C_RESULT", OracleDbType.Varchar2),
					new OracleParameter(":D_ICTTIME", OracleDbType.Date),
					new OracleParameter(":C_REAMRK", OracleDbType.Varchar2),
					new OracleParameter(":C_ID", OracleDbType.Varchar2)};
			parameters[0].Value = model.C_CLASS;
			parameters[1].Value = model.C_MODULE;
			parameters[2].Value = model.C_CONENT;
			parameters[3].Value = model.C_XGEMP;
			parameters[4].Value = model.C_DEPT;
			parameters[5].Value = model.C_TEL;
			parameters[6].Value = model.D_TIME;
			parameters[7].Value = model.C_ICT;
			parameters[8].Value = model.C_RESULT;
			parameters[9].Value = model.D_ICTTIME;
			parameters[10].Value = model.C_REAMRK;
			parameters[11].Value = model.C_ID;

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
			strSql.Append("delete from TQ_MODULE ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2)			};
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
			strSql.Append("delete from TQ_MODULE ");
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
		public Mod_TQ_MODULE GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_CLASS,C_MODULE,C_CONENT,C_XGEMP,C_DEPT,C_TEL,D_TIME,C_ICT,C_RESULT,D_ICTTIME,C_REAMRK from TQ_MODULE ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2)			};
			parameters[0].Value = C_ID;

			Mod_TQ_MODULE model=new Mod_TQ_MODULE();
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
		public Mod_TQ_MODULE DataRowToModel(DataRow row)
		{
			Mod_TQ_MODULE model=new Mod_TQ_MODULE();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_CLASS"]!=null)
				{
					model.C_CLASS=row["C_CLASS"].ToString();
				}
				if(row["C_MODULE"]!=null)
				{
					model.C_MODULE=row["C_MODULE"].ToString();
				}
				if(row["C_CONENT"]!=null)
				{
					model.C_CONENT=row["C_CONENT"].ToString();
				}
				if(row["C_XGEMP"]!=null)
				{
					model.C_XGEMP=row["C_XGEMP"].ToString();
				}
				if(row["C_DEPT"]!=null)
				{
					model.C_DEPT=row["C_DEPT"].ToString();
				}
				if(row["C_TEL"]!=null)
				{
					model.C_TEL=row["C_TEL"].ToString();
				}
				if(row["D_TIME"]!=null && row["D_TIME"].ToString()!="")
				{
					model.D_TIME=DateTime.Parse(row["D_TIME"].ToString());
				}
				if(row["C_ICT"]!=null)
				{
					model.C_ICT=row["C_ICT"].ToString();
				}
				if(row["C_RESULT"]!=null)
				{
					model.C_RESULT=row["C_RESULT"].ToString();
				}
				if(row["D_ICTTIME"]!=null && row["D_ICTTIME"].ToString()!="")
				{
					model.D_ICTTIME=DateTime.Parse(row["D_ICTTIME"].ToString());
				}
				if(row["C_REAMRK"]!=null)
				{
					model.C_REAMRK=row["C_REAMRK"].ToString();
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
			strSql.Append("select C_ID,C_CLASS,C_MODULE,C_CONENT,C_XGEMP,C_DEPT,C_TEL,D_TIME,C_ICT,C_RESULT,D_ICTTIME,C_REAMRK ");
			strSql.Append(" FROM TQ_MODULE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string start, string end, string type)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TQ_MODULE where 1=1 ");

            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append("and C_CLASS = '" + type + "'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_TIME between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        public DataSet GetListByPage(int pageSize, int startIndex,string start, string end, string type)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_CLASS,C_MODULE,C_CONENT,C_XGEMP,C_DEPT,C_TEL,D_TIME,C_ICT,C_RESULT,D_ICTTIME,C_REAMRK";
            string table = "TQ_MODULE";
            string order = " D_TIME desc";
            
            if (!string.IsNullOrEmpty(type))
            {
                where.Append("and C_CLASS = '" + type + "'");
            }
           
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_TIME between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }


        #endregion  BasicMethod
   
    }
}

