using System;
using System.Data;
using System.Text;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
namespace NF.DAL
{
	/// <summary>
	/// 数据访问类:TQB_PACK
	/// </summary>
	public partial class Dal_TQB_PACK
    {
		public Dal_TQB_PACK()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string C_ID)
		{
            string strSql = $@"SELECT COUNT(1) FROM TQB_PACK WHERE C_PACK_TYPE_CODE='{C_ID}'";
			return DbHelperOra.Exists(strSql);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Mod_TQB_PACK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TQB_PACK(");
			strSql.Append("C_ID,C_PACK_TYPE_CODE,C_PACK_TYPE_NAME,C_PACK_DESC,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT)");
			strSql.Append(" values (");
			strSql.Append(":C_ID,:C_PACK_TYPE_CODE,:C_PACK_TYPE_NAME,:C_PACK_DESC,:N_STATUS,:C_REMARK,:C_EMP_ID,:D_MOD_DT)");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PACK_TYPE_CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PACK_TYPE_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PACK_DESC", OracleDbType.Varchar2,500),
					new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
			parameters[0].Value = model.C_ID;
			parameters[1].Value = model.C_PACK_TYPE_CODE;
			parameters[2].Value = model.C_PACK_TYPE_NAME;
			parameters[3].Value = model.C_PACK_DESC;
			parameters[4].Value = model.N_STATUS;
			parameters[5].Value = model.C_REMARK;
			parameters[6].Value = model.C_EMP_ID;
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
		public bool Update(Mod_TQB_PACK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TQB_PACK set ");
			strSql.Append("C_PACK_TYPE_CODE=:C_PACK_TYPE_CODE,");
			strSql.Append("C_PACK_TYPE_NAME=:C_PACK_TYPE_NAME,");
			strSql.Append("C_PACK_DESC=:C_PACK_DESC,");
			strSql.Append("N_STATUS=:N_STATUS,");
			strSql.Append("C_REMARK=:C_REMARK,");
			strSql.Append("C_EMP_ID=:C_EMP_ID,");
			strSql.Append("D_MOD_DT=:D_MOD_DT");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_PACK_TYPE_CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PACK_TYPE_NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":C_PACK_DESC", OracleDbType.Varchar2,500),
					new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
					new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
					new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
					new OracleParameter(":D_MOD_DT", OracleDbType.Date),
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.C_PACK_TYPE_CODE;
			parameters[1].Value = model.C_PACK_TYPE_NAME;
			parameters[2].Value = model.C_PACK_DESC;
			parameters[3].Value = model.N_STATUS;
			parameters[4].Value = model.C_REMARK;
			parameters[5].Value = model.C_EMP_ID;
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
			strSql.Append("delete from TQB_PACK ");
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
			strSql.Append("delete from TQB_PACK ");
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
		public Mod_TQB_PACK GetModel(string C_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_PACK_TYPE_CODE,C_PACK_TYPE_NAME,C_PACK_DESC,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TQB_PACK ");
			strSql.Append(" where C_ID=:C_ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":C_ID", OracleDbType.Varchar2,100)			};
			parameters[0].Value = C_ID;

			Mod_TQB_PACK model=new Mod_TQB_PACK();
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
		public Mod_TQB_PACK DataRowToModel(DataRow row)
		{
			Mod_TQB_PACK model=new Mod_TQB_PACK();
			if (row != null)
			{
				if(row["C_ID"]!=null)
				{
					model.C_ID=row["C_ID"].ToString();
				}
				if(row["C_PACK_TYPE_CODE"]!=null)
				{
					model.C_PACK_TYPE_CODE=row["C_PACK_TYPE_CODE"].ToString();
				}
				if(row["C_PACK_TYPE_NAME"]!=null)
				{
					model.C_PACK_TYPE_NAME=row["C_PACK_TYPE_NAME"].ToString();
				}
				if(row["C_PACK_DESC"]!=null)
				{
					model.C_PACK_DESC=row["C_PACK_DESC"].ToString();
				}
				if(row["N_STATUS"]!=null && row["N_STATUS"].ToString()!="")
				{
					model.N_STATUS=decimal.Parse(row["N_STATUS"].ToString());
				}
				if(row["C_REMARK"]!=null)
				{
					model.C_REMARK=row["C_REMARK"].ToString();
				}
				if(row["C_EMP_ID"]!=null)
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
		public DataSet GetPackList(string code,string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PACK_TYPE_CODE,C_PACK_TYPE_NAME,C_PACK_DESC,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TQB_PACK where N_STATUS=1");
            
            if(!string .IsNullOrEmpty(code))
            {
                strSql.Append(" and C_PACK_TYPE_CODE like '%"+code+"%'");
            }
            if(!string .IsNullOrEmpty(name))
            {
                strSql.Append(" and C_PACK_TYPE_NAME like '%"+name+"%'");
            }


            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select C_ID,C_PACK_TYPE_CODE,C_PACK_TYPE_NAME,C_PACK_DESC,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
			strSql.Append(" FROM TQB_PACK ");
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
			strSql.Append("select count(1) FROM TQB_PACK ");
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
			strSql.Append(")AS Row, T.*  from TQB_PACK T ");
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

