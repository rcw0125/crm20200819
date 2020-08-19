using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMB_FLOWPROC
    /// </summary>
    public partial class Dal_TMB_FLOWPROC
    {
        public Dal_TMB_FLOWPROC()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_FLOWPROC");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_FLOWPROC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_FLOWPROC(");
            strSql.Append("C_FILE_ID,C_STEP_ID,C_STEP_EMP_ID,C_STEPNOTE,C_NEXT_EMP_ID,N_PROCRESULT,C_REMARK)");
            strSql.Append(" values (");
            strSql.Append(":C_FILE_ID,:C_STEP_ID,:C_STEP_EMP_ID,:C_STEPNOTE,:C_NEXT_EMP_ID,:N_PROCRESULT,:C_REMARK)");
            OracleParameter[] parameters = {
                     new OracleParameter(":C_FILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEPNOTE", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_NEXT_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PROCRESULT", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200)};

            parameters[0].Value = model.C_FILE_ID;
            parameters[1].Value = model.C_STEP_ID;
            parameters[2].Value = model.C_STEP_EMP_ID;
            parameters[3].Value = model.C_STEPNOTE;
            parameters[4].Value = model.C_NEXT_EMP_ID;
            parameters[5].Value = model.N_PROCRESULT;
            parameters[6].Value = model.C_REMARK;

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
        public bool Update(Mod_TMB_FLOWPROC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_FLOWPROC set ");
            strSql.Append("C_FILE_ID=:C_FILE_ID,");
            strSql.Append("C_STEP_ID=:C_STEP_ID,");
            strSql.Append("C_STEP_EMP_ID=:C_STEP_EMP_ID,");
            strSql.Append("C_STEPNOTE=:C_STEPNOTE,");
            strSql.Append("D_STEP_DT=:D_STEP_DT,");
            strSql.Append("C_NEXT_EMP_ID=:C_NEXT_EMP_ID,");
            strSql.Append("N_PROCRESULT=:N_PROCRESULT,");
            strSql.Append("C_REMARK=:C_REMARK");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEPNOTE", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_STEP_DT", OracleDbType.Date),
                    new OracleParameter(":C_NEXT_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PROCRESULT", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FILE_ID;
            parameters[1].Value = model.C_STEP_ID;
            parameters[2].Value = model.C_STEP_EMP_ID;
            parameters[3].Value = model.C_STEPNOTE;
            parameters[4].Value = model.D_STEP_DT;
            parameters[5].Value = model.C_NEXT_EMP_ID;
            parameters[6].Value = model.N_PROCRESULT;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.C_ID;

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
            strSql.Append("delete from TMB_FLOWPROC ");
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
            strSql.Append("delete from TMB_FLOWPROC ");
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
        public Mod_TMB_FLOWPROC GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FILE_ID,C_STEP_ID,C_STEP_EMP_ID,C_STEPNOTE,D_STEP_DT,C_NEXT_EMP_ID,N_PROCRESULT,C_REMARK from TMB_FLOWPROC ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMB_FLOWPROC model = new Mod_TMB_FLOWPROC();
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
        public Mod_TMB_FLOWPROC DataRowToModel(DataRow row)
        {
            Mod_TMB_FLOWPROC model = new Mod_TMB_FLOWPROC();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_FILE_ID"] != null)
                {
                    model.C_FILE_ID = row["C_FILE_ID"].ToString();
                }
                if (row["C_STEP_ID"] != null)
                {
                    model.C_STEP_ID = row["C_STEP_ID"].ToString();
                }
                if (row["C_STEP_EMP_ID"] != null)
                {
                    model.C_STEP_EMP_ID = row["C_STEP_EMP_ID"].ToString();
                }
                if (row["C_STEPNOTE"] != null)
                {
                    model.C_STEPNOTE = row["C_STEPNOTE"].ToString();
                }
                if (row["D_STEP_DT"] != null && row["D_STEP_DT"].ToString() != "")
                {
                    model.D_STEP_DT = DateTime.Parse(row["D_STEP_DT"].ToString());
                }
                if (row["C_NEXT_EMP_ID"] != null)
                {
                    model.C_NEXT_EMP_ID = row["C_NEXT_EMP_ID"].ToString();
                }
                if (row["N_PROCRESULT"] != null && row["N_PROCRESULT"].ToString() != "")
                {
                    model.N_PROCRESULT = decimal.Parse(row["N_PROCRESULT"].ToString());
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
            strSql.Append("select C_ID,C_FILE_ID,C_STEP_ID,C_STEP_EMP_ID,C_STEPNOTE,D_STEP_DT,C_NEXT_EMP_ID,N_PROCRESULT,C_REMARK ");
            strSql.Append(" FROM TMB_FLOWPROC ");
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
            strSql.Append("select count(1) FROM TMB_FLOWPROC ");
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
            strSql.Append(")AS Row, T.*  from TMB_FLOWPROC T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获取事务审批节点记录
        /// </summary>
        /// <param name="taskID">事务ID</param>
        /// <returns></returns>
        public DataSet GetFlowSteps(string taskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select *
  from (with t as (select t.c_step_id, t.c_next_emp_id, t.c_file_id
                     from tmb_file_next_emp t
                    where t.c_file_id in
                          (select t.C_ID
                             from tmf_fileinfo t
                            where  t.c_task_id = '{0}'))
         select c_step_id,
                
                (select MAX(a.C_NAME)
                   from ts_role a
                  where a.C_ID = t.c_step_id) stepname,
                (select MAX(a.C_NAME)
                   from ts_user a
                  where a.c_id = t.c_next_emp_id) as c_step_emp_name,
                (select MAX(a.C_STEPNOTE)
                   from tmb_flowproc a
                  where a.c_file_id = t.c_file_id
                    and a.c_step_id = t.c_step_id
                    and a.c_step_emp_id = t.c_next_emp_id) as C_STEPNOTE,
                (select MAX(a.d_step_dt)
                   from tmb_flowproc a
                  where a.c_file_id = t.c_file_id
                    and a.c_step_id = t.c_step_id
                    and a.c_step_emp_id = t.c_next_emp_id) as d_step_dt,
                (select MAX(a.N_PROCRESULT)
                   from tmb_flowproc a
                  where a.c_file_id = t.c_file_id
                    and a.c_step_id = t.c_step_id
                    and a.c_step_emp_id = t.c_next_emp_id) as N_PROCRESULT
           from t
         union
         select t.c_step_id,
                (select a.C_NAME
                   from ts_role a
                  where a.C_ID=t.C_STEP_ID ) stepname,
                (select a.C_NAME
                   from ts_user a
                  where a.c_id = t.C_STEP_EMP_ID) as username,
                t.C_STEPNOTE,
                t.d_step_dt,
                t.N_PROCRESULT
           from tmb_flowproc t
          where t.c_file_id in (select t.C_ID
                                  from tmf_fileinfo t
                                 where t.c_task_id = '{0}'))
          order by d_step_dt desc
", taskID);
            return DbHelperOra.Query(strSql.ToString());
        }



        #endregion  ExtensionMethod
    }
}

