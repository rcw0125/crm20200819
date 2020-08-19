using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMC_TECH_CONSULT_RESULT
    /// </summary>
    public partial class Dal_TMC_TECH_CONSULT_RESULT
    {
        public Dal_TMC_TECH_CONSULT_RESULT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_TECH_CONSULT_RESULT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_TECH_CONSULT_RESULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_TECH_CONSULT_RESULT(");
            strSql.Append("C_TECH_CONSULT_ID,C_DEPT,C_EMP_ID,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK,N_CUST_EVAL,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_TECH_CONSULT_ID,:C_DEPT,:C_EMP_ID,:D_PLAN_DT,:D_FINISH_DT,:C_REAL_TIME,:C_RESULT,:C_LEAVE_Q,:C_REMARK,:N_CUST_EVAL,:D_CUST_EVAL_DT,:N_XG_EVAL,:C_XG_EVAL_EMP,:D_XG_EVAL_DT)");
            OracleParameter[] parameters = {
                    
                    new OracleParameter(":C_TECH_CONSULT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":D_FINISH_DT", OracleDbType.Date),
                    new OracleParameter(":C_REAL_TIME", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_RESULT", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,300),
                    new OracleParameter(":N_CUST_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":D_CUST_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":N_XG_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":C_XG_EVAL_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XG_EVAL_DT", OracleDbType.Date)};
            
            parameters[0].Value = model.C_TECH_CONSULT_ID;
            parameters[1].Value = model.C_DEPT;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.D_PLAN_DT;
            parameters[4].Value = model.D_FINISH_DT;
            parameters[5].Value = model.C_REAL_TIME;
            parameters[6].Value = model.C_RESULT;
            parameters[7].Value = model.C_LEAVE_Q;
            parameters[8].Value = model.C_REMARK;
            parameters[9].Value = model.N_CUST_EVAL;
            parameters[10].Value = model.D_CUST_EVAL_DT;
            parameters[11].Value = model.N_XG_EVAL;
            parameters[12].Value = model.C_XG_EVAL_EMP;
            parameters[13].Value = model.D_XG_EVAL_DT;

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
        public bool Update(Mod_TMC_TECH_CONSULT_RESULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_TECH_CONSULT_RESULT set ");
            strSql.Append("C_TECH_CONSULT_ID=:C_TECH_CONSULT_ID,");
            strSql.Append("C_DEPT=:C_DEPT,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_PLAN_DT=:D_PLAN_DT,");
            strSql.Append("D_FINISH_DT=:D_FINISH_DT,");
            strSql.Append("C_REAL_TIME=:C_REAL_TIME,");
            strSql.Append("C_RESULT=:C_RESULT,");
            strSql.Append("C_LEAVE_Q=:C_LEAVE_Q,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_CUST_EVAL=:N_CUST_EVAL,");
            strSql.Append("D_CUST_EVAL_DT=:D_CUST_EVAL_DT,");
            strSql.Append("N_XG_EVAL=:N_XG_EVAL,");
            strSql.Append("C_XG_EVAL_EMP=:C_XG_EVAL_EMP,");
            strSql.Append("D_XG_EVAL_DT=:D_XG_EVAL_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_TECH_CONSULT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":D_FINISH_DT", OracleDbType.Date),
                    new OracleParameter(":C_REAL_TIME", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_RESULT", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,300),
                    new OracleParameter(":N_CUST_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":D_CUST_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":N_XG_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":C_XG_EVAL_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XG_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_TECH_CONSULT_ID;
            parameters[1].Value = model.C_DEPT;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.D_PLAN_DT;
            parameters[4].Value = model.D_FINISH_DT;
            parameters[5].Value = model.C_REAL_TIME;
            parameters[6].Value = model.C_RESULT;
            parameters[7].Value = model.C_LEAVE_Q;
            parameters[8].Value = model.C_REMARK;
            parameters[9].Value = model.N_CUST_EVAL;
            parameters[10].Value = model.D_CUST_EVAL_DT;
            parameters[11].Value = model.N_XG_EVAL;
            parameters[12].Value = model.C_XG_EVAL_EMP;
            parameters[13].Value = model.D_XG_EVAL_DT;
            parameters[14].Value = model.C_ID;

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
            strSql.Append("delete from TMC_TECH_CONSULT_RESULT ");
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
            strSql.Append("delete from TMC_TECH_CONSULT_RESULT ");
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
        public Mod_TMC_TECH_CONSULT_RESULT GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TECH_CONSULT_ID,C_DEPT,C_EMP_ID,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK,N_CUST_EVAL,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT from TMC_TECH_CONSULT_RESULT ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMC_TECH_CONSULT_RESULT model = new Mod_TMC_TECH_CONSULT_RESULT();
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
        public Mod_TMC_TECH_CONSULT_RESULT DataRowToModel(DataRow row)
        {
            Mod_TMC_TECH_CONSULT_RESULT model = new Mod_TMC_TECH_CONSULT_RESULT();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_TECH_CONSULT_ID"] != null)
                {
                    model.C_TECH_CONSULT_ID = row["C_TECH_CONSULT_ID"].ToString();
                }
                if (row["C_DEPT"] != null)
                {
                    model.C_DEPT = row["C_DEPT"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_PLAN_DT"] != null && row["D_PLAN_DT"].ToString() != "")
                {
                    model.D_PLAN_DT = DateTime.Parse(row["D_PLAN_DT"].ToString());
                }
                if (row["D_FINISH_DT"] != null && row["D_FINISH_DT"].ToString() != "")
                {
                    model.D_FINISH_DT = DateTime.Parse(row["D_FINISH_DT"].ToString());
                }
                if (row["C_REAL_TIME"] != null)
                {
                    model.C_REAL_TIME = row["C_REAL_TIME"].ToString();
                }
                if (row["C_RESULT"] != null)
                {
                    model.C_RESULT = row["C_RESULT"].ToString();
                }
                if (row["C_LEAVE_Q"] != null)
                {
                    model.C_LEAVE_Q = row["C_LEAVE_Q"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_CUST_EVAL"] != null && row["N_CUST_EVAL"].ToString() != "")
                {
                    model.N_CUST_EVAL = decimal.Parse(row["N_CUST_EVAL"].ToString());
                }
                if (row["D_CUST_EVAL_DT"] != null && row["D_CUST_EVAL_DT"].ToString() != "")
                {
                    model.D_CUST_EVAL_DT = DateTime.Parse(row["D_CUST_EVAL_DT"].ToString());
                }
                if (row["N_XG_EVAL"] != null && row["N_XG_EVAL"].ToString() != "")
                {
                    model.N_XG_EVAL = decimal.Parse(row["N_XG_EVAL"].ToString());
                }
                if (row["C_XG_EVAL_EMP"] != null)
                {
                    model.C_XG_EVAL_EMP = row["C_XG_EVAL_EMP"].ToString();
                }
                if (row["D_XG_EVAL_DT"] != null && row["D_XG_EVAL_DT"].ToString() != "")
                {
                    model.D_XG_EVAL_DT = DateTime.Parse(row["D_XG_EVAL_DT"].ToString());
                }
            }
            return model;
        }

        public Mod_TMC_TECH_CONSULT_RESULT2 DataRowToModel2(DataRow row)
        {
            Mod_TMC_TECH_CONSULT_RESULT2 model = new Mod_TMC_TECH_CONSULT_RESULT2();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_TECH_CONSULT_ID"] != null)
                {
                    model.C_TECH_CONSULT_ID = row["C_TECH_CONSULT_ID"].ToString();
                }
                if (row["C_DEPT"] != null)
                {
                    model.C_DEPT = row["C_DEPT"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_PLAN_DT"] != null && row["D_PLAN_DT"].ToString() != "")
                {
                    model.D_PLAN_DT = DateTime.Parse(row["D_PLAN_DT"].ToString());
                }
                if (row["D_FINISH_DT"] != null && row["D_FINISH_DT"].ToString() != "")
                {
                    model.D_FINISH_DT = DateTime.Parse(row["D_FINISH_DT"].ToString());
                }
                if (row["C_REAL_TIME"] != null)
                {
                    model.C_REAL_TIME = row["C_REAL_TIME"].ToString();
                }
                if (row["C_RESULT"] != null)
                {
                    model.C_RESULT = row["C_RESULT"].ToString();
                }
                if (row["C_LEAVE_Q"] != null)
                {
                    model.C_LEAVE_Q = row["C_LEAVE_Q"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_CUST_EVAL"] != null && row["N_CUST_EVAL"].ToString() != "")
                {
                    model.N_CUST_EVAL = decimal.Parse(row["N_CUST_EVAL"].ToString());
                }
                if (row["D_CUST_EVAL_DT"] != null && row["D_CUST_EVAL_DT"].ToString() != "")
                {
                    model.D_CUST_EVAL_DT = DateTime.Parse(row["D_CUST_EVAL_DT"].ToString());
                }
                if (row["N_XG_EVAL"] != null && row["N_XG_EVAL"].ToString() != "")
                {
                    model.N_XG_EVAL = decimal.Parse(row["N_XG_EVAL"].ToString());
                }
                if (row["C_XG_EVAL_EMP"] != null)
                {
                    model.C_XG_EVAL_EMP = row["C_XG_EVAL_EMP"].ToString();
                }
                if (row["D_XG_EVAL_DT"] != null && row["D_XG_EVAL_DT"].ToString() != "")
                {
                    model.D_XG_EVAL_DT = DateTime.Parse(row["D_XG_EVAL_DT"].ToString());
                }
                if (row["DEPT_NAME"] != null)
                {
                    model.DEPT_NAME = row["DEPT_NAME"].ToString();
                }
                if (row["USER_NAME"] != null)
                {
                    model.USER_NAME = row["USER_NAME"].ToString();
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
            strSql.Append("select C_ID,C_TECH_CONSULT_ID,C_DEPT,C_EMP_ID,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK,N_CUST_EVAL,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT ");
            strSql.Append(" FROM TMC_TECH_CONSULT_RESULT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string deptID, string start, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select count(1)
                              from tmc_tech_consult t
                             inner join tmc_tech_consult_result a
                                on t.c_id = a.c_tech_consult_id");
            strSql.Append(" and a.c_dept in(" + deptID + ")");

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and t.D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string deptID,string start, string end)
        {
            StringBuilder where = new StringBuilder();

            string item = @"t.C_ID,
                           t.C_QUEST_ID,
                          (select a.c_name from tmc_question a where a.c_id=t.c_quest_id) QUEST_NAME,
                           t.C_CUST_NAME,
                           t.C_CUST_CODE,
                           t.C_STL_GRD,
                           t.C_USE_DESC,
                           t.C_REMARK,
                           t.C_EMP_ID,
                           t.C_EMP_NAME,
                           t.D_MOD_DT,
                           (select b.c_name from ts_user b where b.c_id = d.c_emp_id) deptEmp,
                           d.c_dept,
                           (select t.c_name from ts_dept t where t.c_id=d.c_dept) deptName,
                           d.d_plan_dt,
                           d.d_finish_dt";

            string table = @"tmc_tech_consult t
                             inner join tmc_tech_consult_result d
                                on t.c_id = d.c_tech_consult_id";
            string order = "t.D_MOD_DT  desc";

            where.Append(" and d.c_dept in(" + deptID + ")");

            

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and t.D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConsult_ResultList(string C_TECH_CONSULT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select C_ID,
                                   C_TECH_CONSULT_ID,
                                   C_DEPT,
                                   (select a.c_name from ts_dept a where a.c_id = t.c_dept) dept_name,
                                   C_EMP_ID,
                                   (select b.c_name from ts_user b where b.c_id = t.c_emp_id) user_name,
                                   D_PLAN_DT,
                                   D_FINISH_DT,
                                   C_REAL_TIME,
                                   C_RESULT,
                                   C_LEAVE_Q,
                                   C_REMARK,
                                   N_CUST_EVAL,
                                   D_CUST_EVAL_DT,
                                   N_XG_EVAL,
                                   C_XG_EVAL_EMP,
                                   D_XG_EVAL_DT
                              from TMC_TECH_CONSULT_RESULT t
                             where 1=1");

            if (!string.IsNullOrEmpty(C_TECH_CONSULT_ID))
            {
                strSql.Append(" and C_TECH_CONSULT_ID='" + C_TECH_CONSULT_ID + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataRow GetConsult_ResultList(string C_TECH_CONSULT_ID,string DEPTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select C_ID,
                                   C_TECH_CONSULT_ID,
                                   C_DEPT,
                                   (select a.c_name from ts_dept a where a.c_id = t.c_dept) dept_name,
                                   C_EMP_ID,
                                   (select b.c_name from ts_user b where b.c_id = t.c_emp_id) user_name,
                                   D_PLAN_DT,
                                   D_FINISH_DT,
                                   C_REAL_TIME,
                                   C_RESULT,
                                   C_LEAVE_Q,
                                   C_REMARK,
                                   N_CUST_EVAL,
                                   D_CUST_EVAL_DT,
                                   N_XG_EVAL,
                                   C_XG_EVAL_EMP,
                                   D_XG_EVAL_DT
                              from TMC_TECH_CONSULT_RESULT t
                             where 1=1");

            if (!string.IsNullOrEmpty(C_TECH_CONSULT_ID))
            {
                strSql.Append(" and C_TECH_CONSULT_ID='" + C_TECH_CONSULT_ID + "'");
            }
            if (!string.IsNullOrEmpty(DEPTID))
            {
                strSql.Append(" and C_DEPT='"+ DEPTID + "'");
            }
            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
		/// 客户评价
		/// </summary>
		public bool UpdateCust_Eval(string C_ID, int Num, DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_TECH_CONSULT_RESULT set ");
            strSql.Append("N_CUST_EVAL=:N_CUST_EVAL,");
            strSql.Append("D_CUST_EVAL_DT=:D_CUST_EVAL_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {

                    new OracleParameter(":N_CUST_EVAL", OracleDbType.Int32),
                    new OracleParameter(":D_CUST_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = Num;
            parameters[1].Value = time;
            parameters[2].Value = C_ID;

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
		/// 邢钢评价
		/// </summary>
		public bool UpdateXG_Eval(string C_ID, int Num,string emp, DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_TECH_CONSULT_RESULT set ");
            strSql.Append("N_XG_EVAL=:N_XG_EVAL,");
            strSql.Append("C_XG_EVAL_EMP=:C_XG_EVAL_EMP,");
            strSql.Append("D_XG_EVAL_DT=:D_XG_EVAL_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {

                    new OracleParameter(":N_XG_EVAL", OracleDbType.Int32),
                    new OracleParameter(":C_XG_EVAL_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XG_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = Num;
            parameters[1].Value = emp;
            parameters[2].Value = time;
            parameters[3].Value = C_ID;

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

        #endregion  ExtensionMethod
    }
}

