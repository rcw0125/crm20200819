using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMC_TECH_CONSULT
    /// </summary>
    public partial class Dal_TMC_TECH_CONSULT
    {
        public Dal_TMC_TECH_CONSULT()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_TECH_CONSULT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_TECH_CONSULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_TECH_CONSULT(");
            strSql.Append("C_QUEST_ID,C_CUST_NAME,C_CUST_CODE,C_STL_GRD,C_USE_DESC,C_REMARK,C_EMP_ID,C_EMP_NAME,C_DEPT,C_EMP,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK2,N_CUST_EVAL,N_STATE,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT,C_ORDER_NO)");
            strSql.Append(" values (");
            strSql.Append(":C_QUEST_ID,:C_CUST_NAME,:C_CUST_CODE,:C_STL_GRD,:C_USE_DESC,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:C_DEPT,:C_EMP,:D_PLAN_DT,:D_FINISH_DT,:C_REAL_TIME,:C_RESULT,:C_LEAVE_Q,:C_REMARK2,:N_CUST_EVAL,:N_STATE,:D_CUST_EVAL_DT,:N_XG_EVAL,:C_XG_EVAL_EMP,:D_XG_EVAL_DT,:C_ORDER_NO)");
            OracleParameter[] parameters = {
                    
                    new OracleParameter(":C_QUEST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_USE_DESC", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":D_FINISH_DT", OracleDbType.Date),
                    new OracleParameter(":C_REAL_TIME", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_RESULT", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,300),
                    new OracleParameter(":N_CUST_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":N_STATE", OracleDbType.Decimal,1),
                    new OracleParameter(":D_CUST_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":N_XG_EVAL", OracleDbType.Decimal,2),
                    new OracleParameter(":C_XG_EVAL_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XG_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,500) };
            
            parameters[0].Value = model.C_QUEST_ID;
            parameters[1].Value = model.C_CUST_NAME;
            parameters[2].Value = model.C_CUST_CODE;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_USE_DESC;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.C_EMP_NAME;
            parameters[8].Value = model.C_DEPT;
            parameters[9].Value = model.C_EMP;
            parameters[10].Value = model.D_PLAN_DT;
            parameters[11].Value = model.D_FINISH_DT;
            parameters[12].Value = model.C_REAL_TIME;
            parameters[13].Value = model.C_RESULT;
            parameters[14].Value = model.C_LEAVE_Q;
            parameters[15].Value = model.C_REMARK2;
            parameters[16].Value = model.N_CUST_EVAL;
            parameters[17].Value = model.N_STATE;
            parameters[18].Value = model.D_CUST_EVAL_DT;
            parameters[19].Value = model.N_XG_EVAL;
            parameters[20].Value = model.C_XG_EVAL_EMP;
            parameters[21].Value = model.D_XG_EVAL_DT;
            parameters[22].Value = model.C_ORDER_NO;
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
        public bool Update(Mod_TMC_TECH_CONSULT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_TECH_CONSULT set ");
            strSql.Append("C_QUEST_ID=:C_QUEST_ID,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_CUST_CODE=:C_CUST_CODE,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_USE_DESC=:C_USE_DESC,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_DEPT=:C_DEPT,");
            strSql.Append("C_EMP=:C_EMP,");
            strSql.Append("D_PLAN_DT=:D_PLAN_DT,");
            strSql.Append("D_FINISH_DT=:D_FINISH_DT,");
            strSql.Append("C_REAL_TIME=:C_REAL_TIME,");
            strSql.Append("C_RESULT=:C_RESULT,");
            strSql.Append("C_LEAVE_Q=:C_LEAVE_Q,");
            strSql.Append("C_REMARK2=:C_REMARK2,");
            strSql.Append("N_CUST_EVAL=:N_CUST_EVAL,");
            strSql.Append("N_STATE=:N_STATE,");
            strSql.Append("D_CUST_EVAL_DT=:D_CUST_EVAL_DT,");
            strSql.Append("N_XG_EVAL=:N_XG_EVAL,");
            strSql.Append("C_XG_EVAL_EMP=:C_XG_EVAL_EMP,");
            strSql.Append("D_XG_EVAL_DT=:D_XG_EVAL_DT,");
            strSql.Append("C_ORDER_NO=:C_ORDER_NO");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QUEST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_USE_DESC", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":D_FINISH_DT", OracleDbType.Date),
                    new OracleParameter(":C_REAL_TIME", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_RESULT", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_LEAVE_Q", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,300),
                    new OracleParameter(":N_CUST_EVAL", OracleDbType.Decimal,15),
                    new OracleParameter(":N_STATE", OracleDbType.Decimal,1),
                    new OracleParameter(":D_CUST_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":N_XG_EVAL", OracleDbType.Decimal,3),
                    new OracleParameter(":C_XG_EVAL_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XG_EVAL_DT", OracleDbType.Date),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_QUEST_ID;
            parameters[1].Value = model.C_CUST_NAME;
            parameters[2].Value = model.C_CUST_CODE;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_USE_DESC;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.C_EMP_NAME;
            parameters[8].Value = model.D_MOD_DT;
            parameters[9].Value = model.C_DEPT;
            parameters[10].Value = model.C_EMP;
            parameters[11].Value = model.D_PLAN_DT;
            parameters[12].Value = model.D_FINISH_DT;
            parameters[13].Value = model.C_REAL_TIME;
            parameters[14].Value = model.C_RESULT;
            parameters[15].Value = model.C_LEAVE_Q;
            parameters[16].Value = model.C_REMARK2;
            parameters[17].Value = model.N_CUST_EVAL;
            parameters[18].Value = model.N_STATE;
            parameters[19].Value = model.D_CUST_EVAL_DT;
            parameters[20].Value = model.N_XG_EVAL;
            parameters[21].Value = model.C_XG_EVAL_EMP;
            parameters[22].Value = model.D_XG_EVAL_DT;
            parameters[23].Value = model.C_ORDER_NO;
            parameters[24].Value = model.C_ID;

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
            strSql.Append("delete from TMC_TECH_CONSULT ");
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
            strSql.Append("delete from TMC_TECH_CONSULT ");
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
        public Mod_TMC_TECH_CONSULT GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUEST_ID,C_CUST_NAME,C_CUST_CODE,C_STL_GRD,C_USE_DESC,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT,C_EMP,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK2,N_CUST_EVAL,N_STATE,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT,C_ORDER_NO from TMC_TECH_CONSULT ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMC_TECH_CONSULT model = new Mod_TMC_TECH_CONSULT();
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
        public Mod_TMC_TECH_CONSULT DataRowToModel(DataRow row)
        {
            Mod_TMC_TECH_CONSULT model = new Mod_TMC_TECH_CONSULT();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_QUEST_ID"] != null)
                {
                    model.C_QUEST_ID = row["C_QUEST_ID"].ToString();
                }
                if (row["C_CUST_NAME"] != null)
                {
                    model.C_CUST_NAME = row["C_CUST_NAME"].ToString();
                }
                if (row["C_CUST_CODE"] != null)
                {
                    model.C_CUST_CODE = row["C_CUST_CODE"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_USE_DESC"] != null)
                {
                    model.C_USE_DESC = row["C_USE_DESC"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
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
                if (row["C_DEPT"] != null)
                {
                    model.C_DEPT = row["C_DEPT"].ToString();
                }
                if (row["C_EMP"] != null)
                {
                    model.C_EMP = row["C_EMP"].ToString();
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
                if (row["C_REMARK2"] != null)
                {
                    model.C_REMARK2 = row["C_REMARK2"].ToString();
                }
                if (row["N_CUST_EVAL"] != null && row["N_CUST_EVAL"].ToString() != "")
                {
                    model.N_CUST_EVAL = decimal.Parse(row["N_CUST_EVAL"].ToString());
                }
                if (row["N_STATE"] != null && row["N_STATE"].ToString() != "")
                {
                    model.N_STATE = decimal.Parse(row["N_STATE"].ToString());
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
                if (row["C_ORDER_NO"] != null)
                {
                    model.C_ORDER_NO = row["C_ORDER_NO"].ToString();
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
            strSql.Append("select C_ID,C_QUEST_ID,C_CUST_NAME,C_CUST_CODE,C_STL_GRD,C_USE_DESC,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT,C_EMP,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK2,N_CUST_EVAL,N_STATE,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT,C_ORDER_NO ");
            strSql.Append(" FROM TMC_TECH_CONSULT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string classID, string empID, string start, string end, string title,string state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMC_TECH_CONSULT where 1=1 ");

            if (!string.IsNullOrEmpty(empID))
            {
                strSql.Append(" and C_EMP_ID='" + empID + "'");
            }
            if (!string.IsNullOrEmpty(classID))
            {
                strSql.Append(" and C_QUEST_ID='" + classID + "'");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and C_STL_GRD like '%" + title + "%'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append("and N_STATE=" + state + "");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string classID, string empID, string start, string end,string title,string state)
        {
            StringBuilder where = new StringBuilder();


            string item = "C_ID,C_QUEST_ID,(select a.c_name from tmc_question a where a.c_id=TMC_TECH_CONSULT.c_quest_id)QUEST_NAME,C_CUST_NAME,C_CUST_CODE,C_STL_GRD,C_USE_DESC,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT,C_EMP,D_PLAN_DT,D_FINISH_DT,C_REAL_TIME,C_RESULT,C_LEAVE_Q,C_REMARK2,N_CUST_EVAL,N_STATE,decode(N_STATE,0,'未处理',1,'已处理',2,'已评分',3,'办结')as N_STATE2,D_CUST_EVAL_DT,N_XG_EVAL,C_XG_EVAL_EMP,D_XG_EVAL_DT,C_ORDER_NO";

            string table = "TMC_TECH_CONSULT";
            string order = "D_MOD_DT  desc";

            if (!string.IsNullOrEmpty(empID))
            {
                where.Append(" and C_EMP_ID='" + empID + "'");
            }
            if (!string.IsNullOrEmpty(classID))
            {
                where.Append(" and C_QUEST_ID='" + classID + "'");
            }         
            if (!string.IsNullOrEmpty(title))
            {
                where.Append(" and C_STL_GRD like '%" + title + "%'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_MOD_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            if(!string .IsNullOrEmpty(state))
            {
                where.Append("and N_STATE="+state+"");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);
        }



        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_QUEST_ID">技术问题主表ID</param>
        /// <returns></returns>
        public DataSet GetConsultList(string C_QUEST_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUEST_ID,C_CUST_NAME,C_CUST_CODE,C_STL_GRD,C_USE_DESC,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMC_TECH_CONSULT where C_QUEST_ID='" + C_QUEST_ID + "' ");

            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

