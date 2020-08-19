using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TS_USER_ROLE
    /// </summary>
    public partial class Dal_TS_USER_ROLE
    {
        public Dal_TS_USER_ROLE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TS_USER_ROLE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TS_USER_ROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TS_USER_ROLE(");
            strSql.Append("C_ID,C_USER_ID,C_ROLE_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_USER_ID,:C_ROLE_ID)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_USER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROLE_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_USER_ID;
            parameters[2].Value = model.C_ROLE_ID;

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
        public bool Update(Mod_TS_USER_ROLE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_USER_ROLE set ");
            strSql.Append("C_USER_ID=:C_USER_ID,");
            strSql.Append("C_ROLE_ID=:C_ROLE_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_USER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ROLE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_USER_ID;
            parameters[1].Value = model.C_ROLE_ID;
            parameters[2].Value = model.C_ID;

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
            strSql.Append("delete from TS_USER_ROLE ");
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
            strSql.Append("delete from TS_USER_ROLE ");
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
        public Mod_TS_USER_ROLE GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_USER_ID,C_ROLE_ID from TS_USER_ROLE ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TS_USER_ROLE model = new Mod_TS_USER_ROLE();
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
        public Mod_TS_USER_ROLE DataRowToModel(DataRow row)
        {
            Mod_TS_USER_ROLE model = new Mod_TS_USER_ROLE();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_USER_ID"] != null)
                {
                    model.C_USER_ID = row["C_USER_ID"].ToString();
                }
                if (row["C_ROLE_ID"] != null)
                {
                    model.C_ROLE_ID = row["C_ROLE_ID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 根据角色获取审批人
        /// </summary>
        public DataSet GetCheckEmp(string C_ROLE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.c_user_id,
                                   t.c_role_id,
                                   a.c_name,
                                   a.c_account
                              from TS_USER_ROLE t inner
                              join ts_user a on t.c_user_id = a.c_id
                             where 1 = 1");
            if (!string.IsNullOrEmpty(C_ROLE_ID))
            {
                strSql.Append(" and t.c_role_id='" + C_ROLE_ID + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_USER_ID,C_ROLE_ID ");
            strSql.Append(" FROM TS_USER_ROLE ");
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
            strSql.Append("select count(1) FROM TS_USER_ROLE ");
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
            strSql.Append(")AS Row, T.*  from TS_USER_ROLE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  自定义方法


        /// <summary>
        /// 获取审批人
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="code">编码</param>
        /// <param name="userName">姓名</param>
        /// <returns></returns>
        public DataSet GetCheckEmp(string roleID, string code, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.c_user_id,
                                   t.c_role_id,
                                   a.c_name,
                                   a.c_account
                              from TS_USER_ROLE t inner
                              join ts_user a on t.c_user_id = a.c_id
                             where 1 = 1");
            strSql.Append(" and t.c_role_id='" + roleID + "'");

            if (!string.IsNullOrEmpty(code))
            {
                strSql.Append(" and a.c_account='" + code + "'");
            }
            if (!string.IsNullOrEmpty(userName))
            {
                strSql.Append(" and a.c_name like '%" + userName + "%'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion
    }
}

