using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TQB_DESIGN
	/// </summary>
	public  class Dal_TQB_REMARKPRINT
    {
		public Dal_TQB_REMARKPRINT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TQB_DESIGN");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TQB_REMARKPRINT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TQB_PRINT_REMARK(");
			strSql.Append("C_ID,C_KEY,C_VALUE,N_STATUS,N_TYPE,C_EMP_ID,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_KEY,:C_VALUE,:N_STATUS,:N_TYPE,:C_EMP_ID,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_KEY", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VALUE", OracleDbType.Varchar2,500),
					new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
					new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_KEY;
			parameters[2].Value = model.C_VALUE;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.N_TYPE;
			parameters[5].Value = model.C_EMP_ID;
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
		public bool Update(Mod_TQB_REMARKPRINT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TQB_PRINT_REMARK set ");
			strSql.Append("C_KEY=:C_KEY,");
			strSql.Append("C_VALUE=:C_VALUE,");			
			strSql.Append("N_TYPE=:N_TYPE,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_KEY", OracleDbType.Varchar2,200),
					new OracleParameter(":C_VALUE", OracleDbType.Varchar2,500),
					new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),				
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_KEY;
			parameters[1].Value = model.C_VALUE;
			parameters[2].Value = model.N_TYPE;
			parameters[3].Value = model.C_EMP_ID;
			parameters[4].Value = model.D_MOD_DT;
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
			strSql.Append("delete from TQB_PRINT_REMARK ");
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
			strSql.Append("update  TQB_PRINT_REMARK set  N_STATUS=0  ");
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
		public Mod_TQB_REMARKPRINT GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_KEY,C_VALUE,N_STATUS,C_EMP_ID,D_MOD_DT,N_TYPE from TQB_PRINT_REMARK ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

            Mod_TQB_REMARKPRINT model =new Mod_TQB_REMARKPRINT();
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
		public Mod_TQB_REMARKPRINT DataRowToModel(DataRow row)
		{
            Mod_TQB_REMARKPRINT model =new Mod_TQB_REMARKPRINT();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_KEY"] !=null)
				{
					model.C_KEY = row["C_KEY"].ToString();
				}
				if(row["C_VALUE"] !=null)
				{
					model.C_VALUE = row["C_VALUE"].ToString();
				}
				if(row["N_STATUS"]!=null && row["N_STATUS"].ToString()!="")
				{
					model.N_STATUS=decimal.Parse(row["N_STATUS"].ToString());
				}
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
                if (row["C_EMP_ID"]!=null)
				{
					model.C_EMP_ID=row["C_EMP_ID"].ToString();
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
			strSql.Append("select C_ID,C_KEY,C_VALUE,N_STATUS,C_EMP_ID,D_MOD_DT,N_TYPE ");
			strSql.Append(" FROM TQB_PRINT_REMARK where N_STATUS=1 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}


        #endregion  BasicMethod

        #region Grd

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetGrdList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STL_GRD ");
            strSql.Append(" FROM tmb_moni_stlgrd where N_STATUS=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteGrdList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from   tmb_moni_stlgrd   ");
            strSql.Append(" where C_ID in (" + C_IDlist + ")  ");
            int rows = DbHelperOra.ExecuteSql(strSql.ToString());
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
        /// 增加一条数据
        /// </summary>
        public bool AddGrd(Mod_TMb_MONI_STLGRD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_MONI_STLGRD(");
            strSql.Append("C_STL_GRD,N_STATUS)");
            strSql.Append(" values (");
            strSql.Append(":C_STL_GRD,:N_STATUS)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),           
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1)};
        
            parameters[0].Value = model.C_STL_GRD;
            parameters[1].Value = model.N_STATUS;
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
        #endregion

    }
}

