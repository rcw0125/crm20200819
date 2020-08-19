using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TQB_CHECKSTATE
    /// </summary>
    public partial class Dal_TQB_CHECKSTATE
    {
        public Dal_TQB_CHECKSTATE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TQB_CHECKSTATE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TQB_CHECKSTATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TQB_CHECKSTATE(");
            strSql.Append("C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_CHECKSTATE_CODE,:C_CHECKSTATE_NAME,:C_CHECKSTATE_TYPE,:N_STATUS,:C_REMARK,:C_EMP_ID,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CHECKSTATE_CODE;
            parameters[2].Value = model.C_CHECKSTATE_NAME;
            parameters[3].Value = model.C_CHECKSTATE_TYPE;
            parameters[4].Value = model.N_STATUS;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.D_MOD_DT;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TQB_CHECKSTATE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TQB_CHECKSTATE set ");
            strSql.Append("C_CHECKSTATE_CODE=:C_CHECKSTATE_CODE,");
            strSql.Append("C_CHECKSTATE_NAME=:C_CHECKSTATE_NAME,");
            strSql.Append("C_CHECKSTATE_TYPE=:C_CHECKSTATE_TYPE,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CHECKSTATE_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHECKSTATE_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CHECKSTATE_CODE;
            parameters[1].Value = model.C_CHECKSTATE_NAME;
            parameters[2].Value = model.C_CHECKSTATE_TYPE;
            parameters[3].Value = model.N_STATUS;
            parameters[4].Value = model.C_REMARK;
            parameters[5].Value = model.C_EMP_ID;
            parameters[6].Value = model.D_MOD_DT;
            parameters[7].Value = model.C_ID;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TQB_CHECKSTATE ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TQB_CHECKSTATE ");
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
        /// 得到一个对象实体
        /// </summary>
        public Mod_TQB_CHECKSTATE GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TQB_CHECKSTATE ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TQB_CHECKSTATE model = new Mod_TQB_CHECKSTATE();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Mod_TQB_CHECKSTATE DataRowToModel(DataRow row)
        {
            Mod_TQB_CHECKSTATE model = new Mod_TQB_CHECKSTATE();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_CHECKSTATE_CODE"] != null)
                {
                    model.C_CHECKSTATE_CODE = row["C_CHECKSTATE_CODE"].ToString();
                }
                if (row["C_CHECKSTATE_NAME"] != null)
                {
                    model.C_CHECKSTATE_NAME = row["C_CHECKSTATE_NAME"].ToString();
                }
                if (row["C_CHECKSTATE_TYPE"] != null)
                {
                    model.C_CHECKSTATE_TYPE = row["C_CHECKSTATE_TYPE"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
            }
            return model;
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetCheckState(string C_CHECKSTATE_TYPE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TQB_CHECKSTATE where N_STATUS=1  and C_REMARK='1001' ");
            if (!string.IsNullOrEmpty(C_CHECKSTATE_TYPE))
            {
                strSql.Append(" and C_CHECKSTATE_TYPE='" + C_CHECKSTATE_TYPE + "'");
            }
            strSql.Append(" order by C_CHECKSTATE_NAME ");

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCheckState(string C_CHECKSTATE_TYPE, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TQB_CHECKSTATE where N_STATUS=1  and C_REMARK='1001' and  C_ID='" + id + "' ");
            if (!string.IsNullOrEmpty(C_CHECKSTATE_TYPE))
            {
                strSql.Append(" and C_CHECKSTATE_TYPE='" + C_CHECKSTATE_TYPE + "'");
            }
            strSql.Append(" order by C_CHECKSTATE_NAME ");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TQB_CHECKSTATE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TQB_CHECKSTATE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.C_ID desc");
            }
            strSql.Append(")AS Row, T.*  from TQB_CHECKSTATE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region PCI
        /// <summary>
        /// 根据名称获取model
        /// </summary>
        /// <param name="C_CHECKSTATE_NAME">判定等级名称</param>
        /// <returns></returns>
        public Mod_TQB_CHECKSTATE GetModelByName(string C_CHECKSTATE_NAME, string C_REMARK)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CHECKSTATE_CODE,C_CHECKSTATE_NAME,C_CHECKSTATE_TYPE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TQB_CHECKSTATE ");
            strSql.Append(" where C_CHECKSTATE_NAME=:C_CHECKSTATE_NAME AND C_REMARK=:C_REMARK ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CHECKSTATE_NAME", OracleDbType.Varchar2,100),
              new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100)};
            parameters[0].Value = C_CHECKSTATE_NAME;
            parameters[1].Value = C_REMARK;
            Mod_TQB_CHECKSTATE model = new Mod_TQB_CHECKSTATE();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}

