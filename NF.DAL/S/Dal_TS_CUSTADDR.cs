using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 收货单位
	/// </summary>
	public partial class Dal_TS_CUSTADDR
    {
		public Dal_TS_CUSTADDR()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TS_CUSTADDR");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID",OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TS_CUSTADDR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TS_CUSTADDR(");
			strSql.Append("C_CUST_ID,C_CGC,C_CGADDR,C_CGAREA,C_CGMAN,C_POSTCODE,C_CGMOBILE,C_CGMOBILE2,N_ISDEFAULT)");
			strSql.Append(" values (");
			strSql.Append(":C_CUST_ID,:C_CGC,:C_CGADDR,:C_CGAREA,:C_CGMAN,:C_POSTCODE,:C_CGMOBILE,:C_CGMOBILE2,:N_ISDEFAULT)");
			OracleParameter[] parameters = {
					
					new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CGC", OracleDbType.Varchar2,200),
					new OracleParameter(":C_CGADDR", OracleDbType.Varchar2,200),
					new OracleParameter(":C_CGAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CGMAN", OracleDbType.Varchar2,30),
					new OracleParameter(":C_POSTCODE", OracleDbType.Varchar2,12),
					new OracleParameter(":C_CGMOBILE", OracleDbType.Varchar2,30),
					new OracleParameter(":C_CGMOBILE2", OracleDbType.Varchar2,30),
					new OracleParameter(":N_ISDEFAULT", OracleDbType.Int16,1)};
			
			parameters[0].Value = model.C_CUST_ID;
			parameters[1].Value = model.C_CGC;
			parameters[2].Value = model.C_CGADDR;
			parameters[3].Value = model.C_CGAREA;
			parameters[4].Value = model.C_CGMAN;
			parameters[5].Value = model.C_POSTCODE;
			parameters[6].Value = model.C_CGMOBILE;
			parameters[7].Value = model.C_CGMOBILE2;
			parameters[8].Value = model.N_ISDEFAULT;

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
		public bool Update(Mod_TS_CUSTADDR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TS_CUSTADDR set ");
			strSql.Append("C_CUST_ID=:C_CUST_ID,");
			strSql.Append("C_CGC=:C_CGC,");
			strSql.Append("C_CGADDR=:C_CGADDR,");
			strSql.Append("C_CGAREA=:C_CGAREA,");
			strSql.Append("C_CGMAN=:C_CGMAN,");
			strSql.Append("C_POSTCODE=:C_POSTCODE,");
			strSql.Append("C_CGMOBILE=:C_CGMOBILE,");
			strSql.Append("C_CGMOBILE2=:C_CGMOBILE2,");
			strSql.Append("N_ISDEFAULT=:N_ISDEFAULT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CGC", OracleDbType.Varchar2,200),
					new OracleParameter(":C_CGADDR", OracleDbType.Varchar2,200),
					new OracleParameter(":C_CGAREA", OracleDbType.Varchar2,100),
					new OracleParameter(":C_CGMAN", OracleDbType.Varchar2,30),
					new OracleParameter(":C_POSTCODE", OracleDbType.Varchar2,12),
					new OracleParameter(":C_CGMOBILE", OracleDbType.Varchar2,30),
					new OracleParameter(":C_CGMOBILE2", OracleDbType.Varchar2,30),
					new OracleParameter(":N_ISDEFAULT", OracleDbType.Int16,1),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_CUST_ID;
			parameters[1].Value = model.C_CGC;
			parameters[2].Value = model.C_CGADDR;
			parameters[3].Value = model.C_CGAREA;
			parameters[4].Value = model.C_CGMAN;
			parameters[5].Value = model.C_POSTCODE;
			parameters[6].Value = model.C_CGMOBILE;
			parameters[7].Value = model.C_CGMOBILE2;
			parameters[8].Value = model.N_ISDEFAULT;
			parameters[9].Value = model.C_ID;

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
		public bool UpdateISDEFAULTNotIn(string C_ID, int ISDEFAULT )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_CUSTADDR set ");          
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
			strSql.Append("delete from TS_CUSTADDR ");
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
			strSql.Append("delete from TS_CUSTADDR ");
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
		public Mod_TS_CUSTADDR GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_CUST_ID,C_CGC,C_CGADDR,C_CGAREA,C_CGMAN,C_POSTCODE,C_CGMOBILE,C_CGMOBILE2,N_ISDEFAULT from TS_CUSTADDR ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TS_CUSTADDR model=new Mod_TS_CUSTADDR();
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
		public Mod_TS_CUSTADDR DataRowToModel(DataRow row)
		{
			Mod_TS_CUSTADDR model=new Mod_TS_CUSTADDR();
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
				if(row["C_CGC"]!=null)
				{
					model.C_CGC=row["C_CGC"].ToString();
				}
				if(row["C_CGADDR"]!=null)
				{
					model.C_CGADDR=row["C_CGADDR"].ToString();
				}
				if(row["C_CGAREA"]!=null)
				{
					model.C_CGAREA=row["C_CGAREA"].ToString();
				}
				if(row["C_CGMAN"]!=null)
				{
					model.C_CGMAN=row["C_CGMAN"].ToString();
				}
				if(row["C_POSTCODE"]!=null)
				{
					model.C_POSTCODE=row["C_POSTCODE"].ToString();
				}
				if(row["C_CGMOBILE"]!=null)
				{
					model.C_CGMOBILE=row["C_CGMOBILE"].ToString();
				}
				if(row["C_CGMOBILE2"]!=null)
				{
					model.C_CGMOBILE2=row["C_CGMOBILE2"].ToString();
				}
				if(row["N_ISDEFAULT"]!=null && row["N_ISDEFAULT"].ToString()!="")
				{
					model.N_ISDEFAULT=decimal.Parse(row["N_ISDEFAULT"].ToString());
				}
			}
			return model;
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAddrList(string cust_id,string N_ISDEFAULT)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CGAREA,N_ISDEFAULT ");
            strSql.Append(" FROM TS_CUSTADDR  where  C_CUST_ID='"+cust_id+"'");
            if(!string .IsNullOrEmpty(N_ISDEFAULT))
            {
                strSql.Append(" and N_ISDEFAULT="+N_ISDEFAULT+"");
            }
            
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_CUST_ID,C_CGC,C_CGADDR,C_CGAREA,C_CGMAN,C_POSTCODE,C_CGMOBILE,C_CGMOBILE2,N_ISDEFAULT ");
			strSql.Append(" FROM TS_CUSTADDR ");
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
			strSql.Append("select count(1) FROM TS_CUSTADDR ");
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
			strSql.Append(")AS Row, T.*  from TS_CUSTADDR T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}
        #endregion  BasicMethod

        #region //自定义

        /// <summary>
        /// 获取客户地址NC主键
        /// </summary>
        /// <param name="ncid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataRow GetAddrName(string C_CGADDR)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CGAREA from ts_custaddr where C_CGADDR='" + C_CGADDR + "'");
            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获取客户地址NC主键
        /// </summary>
        /// <param name="ncid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataRow GetAddr(string ncid,string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CGADDR from ts_custaddr where C_CUST_ID='"+ncid+ "' and C_CGAREA='"+name+"' ");
            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获取客户收货地址
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="nc_id">NC客商档案主键</param>
        /// <param name="nc_m_id">NC客商管理档案主键</param>
        /// <param name="no">客商编号</param>
        /// <param name="flag">标识：0或1默认值</param>
        /// <returns></returns>
        public DataSet GetAddr(string id,string nc_id,string nc_m_id,string no,string flag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_CGAREA,a.N_ISDEFAULT from ts_custaddr a inner join ts_custfile b on a.c_cust_id=b.c_nc_id where 1=1");
           
            if (!string .IsNullOrEmpty(id))
            {
                strSql.Append(" and b.c_id = '"+ id + "'");
            }
            if (!string.IsNullOrEmpty(nc_id))
            {
                strSql.Append(" and b.c_nc_id = '" + nc_id + "'");
            }
            if (!string.IsNullOrEmpty(nc_m_id))
            {
                strSql.Append(" and b.c_nc_m_id = '" + nc_m_id + "'");
            }
            if (!string.IsNullOrEmpty(no))
            {
                strSql.Append(" and b.c_no = '" + no + "'");
            }
            if (!string.IsNullOrEmpty(flag))
            {
                strSql.Append(" and a.n_isdefault = " + flag + "");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

    }
}

