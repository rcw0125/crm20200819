using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMC_CUST_BOOK
    /// </summary>
    public partial class Dal_TMC_CUST_BOOK
    {
        public Dal_TMC_CUST_BOOK()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_CUST_BOOK");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_CUST_BOOK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_CUST_BOOK(");
            strSql.Append("C_ID,D_ZF_DT,C_CUST_NAME,C_AREA,C_CUST_MANAGE,C_CUST_EMP,C_CUST_EMP_TEL,C_MEETING_CUST,C_MEETING_XG,C_MAIN_CONTENT,C_NEED_S_Q,C_LEAVE_Q,C_STL_GRD,C_PRO_USE,C_SITE,C_REMARK,N_TYPE,C_EMPID)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:D_ZF_DT,:C_CUST_NAME,:C_AREA,:C_CUST_MANAGE,:C_CUST_EMP,:C_CUST_EMP_TEL,:C_MEETING_CUST,:C_MEETING_XG,:C_MAIN_CONTENT,:C_NEED_S_Q,:C_LEAVE_Q,:C_STL_GRD,:C_PRO_USE,:C_SITE,:C_REMARK,:N_TYPE,:C_EMPID)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_ZF_DT", OracleDbType.Date),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_MANAGE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_EMP", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUST_EMP_TEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MEETING_CUST", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_MEETING_XG", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_MAIN_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_NEED_S_Q", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SITE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.D_ZF_DT;
            parameters[2].Value = model.C_CUST_NAME;
            parameters[3].Value = model.C_AREA;
            parameters[4].Value = model.C_CUST_MANAGE;
            parameters[5].Value = model.C_CUST_EMP;
            parameters[6].Value = model.C_CUST_EMP_TEL;
            parameters[7].Value = model.C_MEETING_CUST;
            parameters[8].Value = model.C_MEETING_XG;
            parameters[9].Value = model.C_MAIN_CONTENT;
            parameters[10].Value = model.C_NEED_S_Q;
            parameters[11].Value = model.C_LEAVE_Q;
            parameters[12].Value = model.C_STL_GRD;
            parameters[13].Value = model.C_PRO_USE;
            parameters[14].Value = model.C_SITE;
            parameters[15].Value = model.C_REMARK;
            parameters[16].Value = model.N_TYPE;
            parameters[17].Value = model.C_EMPID;

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
        public bool Update(Mod_TMC_CUST_BOOK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_CUST_BOOK set ");
            strSql.Append("D_ZF_DT=:D_ZF_DT,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_CUST_MANAGE=:C_CUST_MANAGE,");
            strSql.Append("C_CUST_EMP=:C_CUST_EMP,");
            strSql.Append("C_CUST_EMP_TEL=:C_CUST_EMP_TEL,");
            strSql.Append("C_MEETING_CUST=:C_MEETING_CUST,");
            strSql.Append("C_MEETING_XG=:C_MEETING_XG,");
            strSql.Append("C_MAIN_CONTENT=:C_MAIN_CONTENT,");
            strSql.Append("C_NEED_S_Q=:C_NEED_S_Q,");
            strSql.Append("C_LEAVE_Q=:C_LEAVE_Q,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_PRO_USE=:C_PRO_USE,");
            strSql.Append("C_SITE=:C_SITE,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_TYPE=:N_TYPE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":D_ZF_DT", OracleDbType.Date),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_MANAGE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_EMP", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUST_EMP_TEL", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MEETING_CUST", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_MEETING_XG", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_MAIN_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_NEED_S_Q", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PRO_USE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SITE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.D_ZF_DT;
            parameters[1].Value = model.C_CUST_NAME;
            parameters[2].Value = model.C_AREA;
            parameters[3].Value = model.C_CUST_MANAGE;
            parameters[4].Value = model.C_CUST_EMP;
            parameters[5].Value = model.C_CUST_EMP_TEL;
            parameters[6].Value = model.C_MEETING_CUST;
            parameters[7].Value = model.C_MEETING_XG;
            parameters[8].Value = model.C_MAIN_CONTENT;
            parameters[9].Value = model.C_NEED_S_Q;
            parameters[10].Value = model.C_LEAVE_Q;
            parameters[11].Value = model.C_STL_GRD;
            parameters[12].Value = model.C_PRO_USE;
            parameters[13].Value = model.C_SITE;
            parameters[14].Value = model.C_REMARK;
            parameters[15].Value = model.N_TYPE;
            parameters[16].Value = model.C_ID;

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
            strSql.Append("delete from TMC_CUST_BOOK ");
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
            strSql.Append("delete from TMC_CUST_BOOK ");
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
        public Mod_TMC_CUST_BOOK GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,D_ZF_DT,C_CUST_NAME,C_AREA,C_CUST_MANAGE,C_CUST_EMP,C_CUST_EMP_TEL,C_MEETING_CUST,C_MEETING_XG,C_MAIN_CONTENT,C_NEED_S_Q,C_LEAVE_Q,C_STL_GRD,C_PRO_USE,C_SITE,C_REMARK,N_TYPE from TMC_CUST_BOOK ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMC_CUST_BOOK model = new Mod_TMC_CUST_BOOK();
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
        public Mod_TMC_CUST_BOOK DataRowToModel(DataRow row)
        {
            Mod_TMC_CUST_BOOK model = new Mod_TMC_CUST_BOOK();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["D_ZF_DT"] != null && row["D_ZF_DT"].ToString() != "")
                {
                    model.D_ZF_DT = DateTime.Parse(row["D_ZF_DT"].ToString());
                }
                if (row["C_CUST_NAME"] != null)
                {
                    model.C_CUST_NAME = row["C_CUST_NAME"].ToString();
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["C_CUST_MANAGE"] != null)
                {
                    model.C_CUST_MANAGE = row["C_CUST_MANAGE"].ToString();
                }
                if (row["C_CUST_EMP"] != null)
                {
                    model.C_CUST_EMP = row["C_CUST_EMP"].ToString();
                }
                if (row["C_CUST_EMP_TEL"] != null)
                {
                    model.C_CUST_EMP_TEL = row["C_CUST_EMP_TEL"].ToString();
                }
                if (row["C_MEETING_CUST"] != null)
                {
                    model.C_MEETING_CUST = row["C_MEETING_CUST"].ToString();
                }
                if (row["C_MEETING_XG"] != null)
                {
                    model.C_MEETING_XG = row["C_MEETING_XG"].ToString();
                }
                if (row["C_MAIN_CONTENT"] != null)
                {
                    model.C_MAIN_CONTENT = row["C_MAIN_CONTENT"].ToString();
                }
                if (row["C_NEED_S_Q"] != null)
                {
                    model.C_NEED_S_Q = row["C_NEED_S_Q"].ToString();
                }
                if (row["C_LEAVE_Q"] != null)
                {
                    model.C_LEAVE_Q = row["C_LEAVE_Q"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_PRO_USE"] != null)
                {
                    model.C_PRO_USE = row["C_PRO_USE"].ToString();
                }
                if (row["C_SITE"] != null)
                {
                    model.C_SITE = row["C_SITE"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,D_ZF_DT,C_CUST_NAME,C_AREA,C_CUST_MANAGE,C_CUST_EMP,C_CUST_EMP_TEL,C_MEETING_CUST,C_MEETING_XG,C_MAIN_CONTENT,C_NEED_S_Q,C_LEAVE_Q,C_STL_GRD,C_PRO_USE,C_SITE,C_REMARK,N_TYPE ");
            strSql.Append(" FROM TMC_CUST_BOOK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string custName, string stlGrd, string start_dt, string end_dt, string empID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,D_ZF_DT,C_CUST_NAME,C_AREA,C_CUST_MANAGE,C_CUST_EMP,C_CUST_EMP_TEL,C_MEETING_CUST,C_MEETING_XG,C_MAIN_CONTENT,C_NEED_S_Q,C_LEAVE_Q,C_STL_GRD,C_PRO_USE,C_SITE,C_REMARK,N_TYPE,C_EMPID ");
            strSql.Append(" FROM TMC_CUST_BOOK where 1=1 ");

            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat("AND C_CUST_NAME LIKE '%{0}%'", custName);
            }
           
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat("AND C_STL_GRD LIKE '%{0}%'", stlGrd);
            }

            if (!string.IsNullOrEmpty(start_dt) && !string.IsNullOrEmpty(end_dt))
            {
                strSql.Append(" AND D_ZF_DT BETWEEN TO_DATE('" + Convert.ToDateTime(start_dt).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end_dt).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            if (!string.IsNullOrEmpty(empID))
            {
                strSql.AppendFormat("and C_EMPID='{0}'", empID);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string cust_name, string area, string type, string start_dt, string end_dt,string empID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,D_ZF_DT,C_CUST_NAME,C_AREA,C_CUST_MANAGE,C_CUST_EMP,C_CUST_EMP_TEL,C_MEETING_CUST,C_MEETING_XG,C_MAIN_CONTENT,C_NEED_S_Q,C_LEAVE_Q,C_STL_GRD,C_PRO_USE,C_SITE,C_REMARK,N_TYPE,C_EMPID ");
            strSql.Append(" FROM TMC_CUST_BOOK where 1=1 ");

            if (!string.IsNullOrEmpty(cust_name))
            {
                strSql.AppendFormat("and C_CUST_NAME='{0}'",cust_name);
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql.AppendFormat("and C_AREA='{0}'", area);
            }
            if (!string.IsNullOrEmpty(type))
            {
                strSql.AppendFormat("and N_TYPE={0}", type);
            }

            if (!string.IsNullOrEmpty(start_dt) && !string.IsNullOrEmpty(end_dt))
            {
                strSql.Append(" and D_ZF_DT between to_date('" + Convert.ToDateTime(start_dt).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end_dt).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            if (!string.IsNullOrEmpty(empID))
            {
                strSql.AppendFormat("and C_EMPID='{0}'", empID);
            }

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMC_CUST_BOOK ");
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
            strSql.Append(")AS Row, T.*  from TMC_CUST_BOOK T ");
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

