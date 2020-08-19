using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMC_CUSTGIVEMARK
    /// </summary>
    public partial class Dal_TMC_CUSTGIVEMARK
    {
        public Dal_TMC_CUSTGIVEMARK()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_CUSTGIVEMARK");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_CUSTGIVEMARK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_CUSTGIVEMARK(");
            strSql.Append("C_PKHID,C_PKID,N_SCORE,C_REMARK)");
            strSql.Append(" values (");
            strSql.Append(":C_PKHID,:C_PKID,:N_SCORE,:C_REMARK)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_PKHID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PKID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SCORE", OracleDbType.Decimal,2),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500)};

            parameters[0].Value = model.C_PKHID;
            parameters[1].Value = model.C_PKID;
            parameters[2].Value = model.N_SCORE;
            parameters[3].Value = model.C_REMARK;

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
        public bool Update(Mod_TMC_CUSTGIVEMARK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_CUSTGIVEMARK set ");
            strSql.Append("C_PKHID=:C_PKHID,");
            strSql.Append("C_PKID=:C_PKID,");
            strSql.Append("N_SCORE=:N_SCORE,");
            strSql.Append("D_TIME=:D_TIME,");
            strSql.Append("C_REMARK=:C_REMARK");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PKHID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PKID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SCORE", OracleDbType.Decimal,2),
                    new OracleParameter(":D_TIME", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_PKHID;
            parameters[1].Value = model.C_PKID;
            parameters[2].Value = model.N_SCORE;
            parameters[3].Value = model.D_TIME;
            parameters[4].Value = model.C_REMARK;
            parameters[5].Value = model.C_ID;

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
            strSql.Append("delete from TMC_CUSTGIVEMARK ");
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
            strSql.Append("delete from TMC_CUSTGIVEMARK ");
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
        public Mod_TMC_CUSTGIVEMARK GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PKHID,C_PKID,N_SCORE,D_TIME,C_REMARK from TMC_CUSTGIVEMARK ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMC_CUSTGIVEMARK model = new Mod_TMC_CUSTGIVEMARK();
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
        public Mod_TMC_CUSTGIVEMARK DataRowToModel(DataRow row)
        {
            Mod_TMC_CUSTGIVEMARK model = new Mod_TMC_CUSTGIVEMARK();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_PKHID"] != null)
                {
                    model.C_PKHID = row["C_PKHID"].ToString();
                }
                if (row["C_PKID"] != null)
                {
                    model.C_PKID = row["C_PKID"].ToString();
                }
                if (row["N_SCORE"] != null && row["N_SCORE"].ToString() != "")
                {
                    model.N_SCORE = decimal.Parse(row["N_SCORE"].ToString());
                }
                if (row["D_TIME"] != null && row["D_TIME"].ToString() != "")
                {
                    model.D_TIME = DateTime.Parse(row["D_TIME"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
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
            strSql.Append("select C_ID,C_PKHID,C_PKID,N_SCORE,D_TIME,C_REMARK ");
            strSql.Append(" FROM TMC_CUSTGIVEMARK ");
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
            strSql.Append("select count(1) FROM TMC_CUSTGIVEMARK ");
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
            strSql.Append(")AS Row, T.*  from TMC_CUSTGIVEMARK T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }


        public DataSet GetGiveMark(string pkhid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select a.c_flag, a.c_name, a.n_score, t.n_score as defen
  from tmc_custgivemark t
 inner join tmc_givemark_item a
    on t.c_pkid = a.c_id where t.c_pkhid='{0}'", pkhid);
            return DbHelperOra.Query(strSql.ToString());
        }


        #endregion  BasicMethod
    }
}

