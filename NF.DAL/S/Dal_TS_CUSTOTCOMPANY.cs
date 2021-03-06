﻿using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 开票单位
	/// </summary>
	public partial class Dal_TS_CUSTOTCOMPANY
    {
		public Dal_TS_CUSTOTCOMPANY()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TS_CUSTOTCOMPANY");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID",OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TS_CUSTOTCOMPANY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TS_CUSTOTCOMPANY(");
			strSql.Append("C_ID,C_CUST_ID,C_OTCOMPANY,C_OPENBANK,C_ACCOUNTBANK,N_ISDEFAULT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_CUST_ID,:C_OTCOMPANY,:C_OPENBANK,:C_ACCOUNTBANK,:N_ISDEFAULT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_OTCOMPANY", OracleDbType.Varchar2,200),
					new OracleParameter(":C_OPENBANK", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ACCOUNTBANK", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ISDEFAULT", OracleDbType.Int16,1)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_CUST_ID;
			parameters[2].Value = model.C_OTCOMPANY;
			parameters[3].Value = model.C_OPENBANK;
			parameters[4].Value = model.C_ACCOUNTBANK;
			parameters[5].Value = model.N_ISDEFAULT;

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
		public bool Update(Mod_TS_CUSTOTCOMPANY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TS_CUSTOTCOMPANY set ");
			strSql.Append("C_CUST_ID=:C_CUST_ID,");
			strSql.Append("C_OTCOMPANY=:C_OTCOMPANY,");
			strSql.Append("C_OPENBANK=:C_OPENBANK,");
			strSql.Append("C_ACCOUNTBANK=:C_ACCOUNTBANK,");
			strSql.Append("N_ISDEFAULT=:N_ISDEFAULT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_OTCOMPANY", OracleDbType.Varchar2,200),
					new OracleParameter(":C_OPENBANK", OracleDbType.Varchar2,100),
					new OracleParameter(":C_ACCOUNTBANK", OracleDbType.Varchar2,100),
					new OracleParameter(":N_ISDEFAULT", OracleDbType.Int16,1),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_CUST_ID;
			parameters[1].Value = model.C_OTCOMPANY;
			parameters[2].Value = model.C_OPENBANK;
			parameters[3].Value = model.C_ACCOUNTBANK;
			parameters[4].Value = model.N_ISDEFAULT;
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
        /// 更新一条数据
        /// </summary>
        public bool UpdateISDEFAULTNotIn(string C_ID, int ISDEFAULT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_CUSTOTCOMPANY set ");
            strSql.Append("N_ISDEFAULT=:N_ISDEFAULT");
            strSql.Append(" where C_ID not in(:C_ID)");
            OracleParameter[] parameters = {

                    new OracleParameter(":N_ISDEFAULT", OracleDbType.Int16,1),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = ISDEFAULT;
            parameters[1].Value = C_ID;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TS_CUSTOTCOMPANY ");
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
			strSql.Append("delete from TS_CUSTOTCOMPANY ");
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
		public Mod_TS_CUSTOTCOMPANY GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_CUST_ID,C_OTCOMPANY,C_OPENBANK,C_ACCOUNTBANK,N_ISDEFAULT from TS_CUSTOTCOMPANY ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TS_CUSTOTCOMPANY model=new Mod_TS_CUSTOTCOMPANY();
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
		public Mod_TS_CUSTOTCOMPANY DataRowToModel(DataRow row)
		{
			Mod_TS_CUSTOTCOMPANY model=new Mod_TS_CUSTOTCOMPANY();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_CUST_ID"]!=null)
				{
					model.C_CUST_ID=row["C_CUST_ID"].ToString();
				}
				if(row["C_OTCOMPANY"]!=null)
				{
					model.C_OTCOMPANY=row["C_OTCOMPANY"].ToString();
				}
				if(row["C_OPENBANK"]!=null)
				{
					model.C_OPENBANK=row["C_OPENBANK"].ToString();
				}
				if(row["C_ACCOUNTBANK"]!=null)
				{
					model.C_ACCOUNTBANK=row["C_ACCOUNTBANK"].ToString();
				}
				if(row["N_ISDEFAULT"]!=null && row["N_ISDEFAULT"].ToString()!="")
				{
					model.N_ISDEFAULT=decimal.Parse(row["N_ISDEFAULT"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 获取开票单位
        /// </summary>
        /// <param name="C_CUST_ID"></param>
        /// <param name="N_ISDEFAULT"></param>
        /// <returns></returns>
        public DataSet GetOT(string C_CUST_ID,string N_ISDEFAULT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CUST_ID,C_OTCOMPANY,C_OPENBANK,C_ACCOUNTBANK,N_ISDEFAULT ");
            strSql.Append(" FROM TS_CUSTOTCOMPANY where  C_CUST_ID='" + C_CUST_ID + "'");
            if (!string.IsNullOrEmpty(N_ISDEFAULT))
            {
                strSql.Append(" and  N_ISDEFAULT=" + N_ISDEFAULT + "");
            }

            return DbHelperOra.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string C_CUST_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_CUST_ID,C_OTCOMPANY,C_OPENBANK,C_ACCOUNTBANK,N_ISDEFAULT ");
			strSql.Append(" FROM TS_CUSTOTCOMPANY where N_ISDEFAULT=1 and  C_CUST_ID='"+ C_CUST_ID + "'");
			

			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TS_CUSTOTCOMPANY ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj =DbHelperOra.GetSingle(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from TS_CUSTOTCOMPANY T ");
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

