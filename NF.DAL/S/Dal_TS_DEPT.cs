using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 部门
    /// </summary>
    public partial class Dal_TS_DEPT
    {
        public Dal_TS_DEPT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TS_DEPT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TS_DEPT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TS_DEPT(");
            strSql.Append("C_ID,C_PARENT_ID,C_CODE,C_NAME,C_DESC,N_STATUS,C_DEPTH,N_DEPTATTR,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_PARENT_ID,:C_CODE,:C_NAME,:C_DESC,:N_STATUS,:C_DEPTH,:N_DEPTATTR,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PARENT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":C_DEPTH", OracleDbType.Int32,3),
                    new OracleParameter(":N_DEPTATTR", OracleDbType.Varchar2,9),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_PARENT_ID;
            parameters[2].Value = model.C_CODE;
            parameters[3].Value = model.C_NAME;
            parameters[4].Value = model.C_DESC;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.C_DEPTH;
            parameters[7].Value = model.N_DEPTATTR;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;

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
        /// 更新状态
        /// </summary>
        public bool UpdateStatus(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_DEPT set ");


            strSql.Append("N_STATUS=0 where C_ID='" + id + "'");

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_DEPT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_DEPT set ");
            strSql.Append("C_PARENT_ID=:C_PARENT_ID,");
            strSql.Append("C_CODE=:C_CODE,");
            strSql.Append("C_NAME=:C_NAME,");
            strSql.Append("C_DESC=:C_DESC,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_DEPTH=:C_DEPTH,");
            strSql.Append("N_DEPTATTR=:N_DEPTATTR,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PARENT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1),
                    new OracleParameter(":C_DEPTH", OracleDbType.Int32,3),
                    new OracleParameter(":N_DEPTATTR", OracleDbType.Varchar2,9),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_PARENT_ID;
            parameters[1].Value = model.C_CODE;
            parameters[2].Value = model.C_NAME;
            parameters[3].Value = model.C_DESC;
            parameters[4].Value = model.N_STATUS;
            parameters[5].Value = model.C_DEPTH;
            parameters[6].Value = model.N_DEPTATTR;
            parameters[7].Value = model.C_EMP_ID;
            parameters[8].Value = model.C_EMP_NAME;
            parameters[9].Value = model.D_MOD_DT;
            parameters[10].Value = model.C_ID;

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
            strSql.Append("delete from TS_DEPT ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
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
            strSql.Append("delete from TS_DEPT ");
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
        public Mod_TS_DEPT GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PARENT_ID,C_CODE,C_NAME,C_DESC,N_STATUS,C_DEPTH,N_DEPTATTR,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TS_DEPT ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TS_DEPT model = new Mod_TS_DEPT();
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
        public Mod_TS_DEPT DataRowToModel(DataRow row)
        {
            Mod_TS_DEPT model = new Mod_TS_DEPT();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_PARENT_ID"] != null)
                {
                    model.C_PARENT_ID = row["C_PARENT_ID"].ToString();
                }
                if (row["C_CODE"] != null)
                {
                    model.C_CODE = row["C_CODE"].ToString();
                }
                if (row["C_NAME"] != null)
                {
                    model.C_NAME = row["C_NAME"].ToString();
                }
                if (row["C_DESC"] != null)
                {
                    model.C_DESC = row["C_DESC"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_DEPTH"] != null && row["C_DEPTH"].ToString() != "")
                {
                    model.C_DEPTH = decimal.Parse(row["C_DEPTH"].ToString());
                }
                if (row["N_DEPTATTR"] != null)
                {
                    model.N_DEPTATTR = row["N_DEPTATTR"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_EMP_NAME"] != null)
                {
                    model.C_EMP_NAME = row["C_EMP_NAME"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 获取部门人员列表
        /// </summary>
        /// <param name="deptID">部门ID</param>
        /// <returns></returns>
        public DataSet GetDeptEMPList(string deptID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"SELECT T.C_ID,T.C_NAME FROM TS_SALE_EMP T WHERE T.C_DEPTID='" + deptID + "'");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
		/// 获取部门列表
		/// </summary>
		public DataSet GetDeptList(string parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   C_ID,C_PARENT_ID,C_CODE,C_NAME,C_DESC,N_STATUS,C_DEPTH,N_DEPTATTR,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TS_DEPT where N_STATUS=1 ");
            if (!string.IsNullOrEmpty(parentID))
            {
                strSql.Append(" and  C_PARENT_ID='" + parentID + "' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDeptCode(string C_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PARENT_ID,C_CODE,C_NAME,C_DESC,N_STATUS,C_DEPTH,N_DEPTATTR,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TS_DEPT where N_STATUS=1");
            if (!string.IsNullOrEmpty(C_CODE))
            {
                strSql.Append(" and C_CODE='" + C_CODE + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C_ID,C_PARENT_ID,C_CODE,C_NAME,C_DESC,N_STATUS,C_DEPTH,N_DEPTATTR,C_EMP_ID,C_EMP_NAME,D_MOD_DT
  FROM TS_DEPT ");
           
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(@" START WITH C_ID IN ('1001NC100000009KN6Q1', '1001NC100000005IOM85')
CONNECT BY PRIOR C_ID = C_PARENT_ID ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TS_DEPT ");
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
            strSql.Append(")AS Row, T.*  from TS_DEPT T ");
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
        /// 获取部门
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public string GetDept(string user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_DEPT_ID ");
            strSql.Append(" FROM TS_USER_DEPT WHERE C_USER_ID='" + user + "'");
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        #endregion

    }
}

