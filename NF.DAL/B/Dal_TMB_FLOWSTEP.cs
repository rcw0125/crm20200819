using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMB_FLOWSTEP
    /// </summary>
    public partial class Dal_TMB_FLOWSTEP
    {
        public Dal_TMB_FLOWSTEP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_FLOWSTEP");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_FLOWSTEP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_FLOWSTEP(");
            strSql.Append("C_ID,C_FLOW_ID,C_STEP_ID,N_TYPE,N_SORT,N_STATUS,C_APPROVE_ID,D_AGING_DT,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_FLOW_ID,:C_STEP_ID,:N_TYPE,:N_SORT,:N_STATUS,:C_APPROVE_ID,:D_AGING_DT,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,9),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_AGING_DT", OracleDbType.Char,10),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_FLOW_ID;
            parameters[2].Value = model.C_STEP_ID;
            parameters[3].Value = model.N_TYPE;
            parameters[4].Value = model.N_SORT;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.C_APPROVE_ID;
            parameters[7].Value = model.D_AGING_DT;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TMB_FLOWSTEP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_FLOWSTEP set ");
            strSql.Append("C_FLOW_ID=:C_FLOW_ID,");
            strSql.Append("C_STEP_ID=:C_STEP_ID,");
            strSql.Append("N_TYPE=:N_TYPE,");
            strSql.Append("N_SORT=:N_SORT,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_APPROVE_ID=:C_APPROVE_ID,");
            strSql.Append("D_AGING_DT=:D_AGING_DT,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":N_SORT", OracleDbType.Decimal,9),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_AGING_DT", OracleDbType.Char,10),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FLOW_ID;
            parameters[1].Value = model.C_STEP_ID;
            parameters[2].Value = model.N_TYPE;
            parameters[3].Value = model.N_SORT;
            parameters[4].Value = model.N_STATUS;
            parameters[5].Value = model.C_APPROVE_ID;
            parameters[6].Value = model.D_AGING_DT;
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
            strSql.Append("delete from TMB_FLOWSTEP ");
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
            strSql.Append("delete from TMB_FLOWSTEP ");
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
        public Mod_TMB_FLOWSTEP GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FLOW_ID,C_STEP_ID,N_TYPE,N_SORT,N_STATUS,C_APPROVE_ID,D_AGING_DT,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_FLOWSTEP ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMB_FLOWSTEP model = new Mod_TMB_FLOWSTEP();
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
        public Mod_TMB_FLOWSTEP DataRowToModel(DataRow row)
        {
            Mod_TMB_FLOWSTEP model = new Mod_TMB_FLOWSTEP();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_FLOW_ID"] != null)
                {
                    model.C_FLOW_ID = row["C_FLOW_ID"].ToString();
                }
                if (row["C_STEP_ID"] != null)
                {
                    model.C_STEP_ID = row["C_STEP_ID"].ToString();
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
                if (row["N_SORT"] != null && row["N_SORT"].ToString() != "")
                {
                    model.N_SORT = decimal.Parse(row["N_SORT"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_APPROVE_ID"] != null)
                {
                    model.C_APPROVE_ID = row["C_APPROVE_ID"].ToString();
                }
                if (row["D_AGING_DT"] != null)
                {
                    model.D_AGING_DT = row["D_AGING_DT"].ToString();
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FLOW_ID,C_STEP_ID,N_TYPE,N_SORT,N_STATUS,C_APPROVE_ID,D_AGING_DT,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_FLOWSTEP ");
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
            strSql.Append("select count(1) FROM TMB_FLOWSTEP ");
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
            strSql.Append(")AS Row, T.*  from TMB_FLOWSTEP T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMB_FLOWSTEP";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获取当前步骤上一处理步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <param name="step">步骤</param>
        /// <returns></returns>
        public string GetUpStep(string flow, string step)
        {
            string stepID = "0";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.c_step_id,t.n_sort
                                  from TMB_FLOWSTEP t
                                 where t.n_status = 1
                                   and t.c_flow_id='{0}'
                                   and t.n_sort<
                                       (select t.n_sort
                                          from tmb_flowstep t
                                         where t.c_step_id = '{1}'
                                           and t.c_flow_id = '{0}')   
                                 order by t.n_sort desc", flow, step);
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                stepID = dt.Rows[0]["c_step_id"].ToString();
            }
            return stepID;
        }

        /// <summary>
        /// 获取流程第一步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <returns></returns>
        public string GetFirstStep(string flow)
        {
            string stepID = "0";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_step_id from TMB_FLOWSTEP t where t.c_flow_id='" + flow + "' and t.n_status=1 order by t.n_sort asc");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                stepID = dt.Rows[0]["c_step_id"].ToString();
            }
            return stepID;
        }

        /// <summary>
        /// 获取流程最后步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <returns></returns>
        public string GetLastStep(string flow)
        {
            string stepID = "0";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_step_id from TMB_FLOWSTEP t where t.c_flow_id='" + flow + "' and t.n_status=1 order by t.n_sort desc");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                stepID = dt.Rows[0]["c_step_id"].ToString();
            }
            return stepID;
        }



        /// <summary>
        /// 获取当前步骤下一处理步骤
        /// </summary>
        /// <param name="flow">流程</param>
        /// <param name="step">当前步骤</param>
        /// <returns></returns>
        public string GetNextStep(string flow, string step)
        {
            string stepID = "0";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_STEP_ID
                                  FROM TMB_FLOWSTEP T
                                 WHERE T.N_STATUS = 1
                                   AND T.C_FLOW_ID='{0}'
                                   AND T.N_SORT >
                                       (SELECT T.N_SORT
                                          FROM TMB_FLOWSTEP T
                                         WHERE T.C_STEP_ID = '{1}'
                                           AND T.C_FLOW_ID = '{0}')   
                                 ORDER BY T.N_SORT ASC", flow, step);

            DataSet ds = DbHelperOra.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                stepID = ds.Tables[0].Rows[0]["C_STEP_ID"].ToString();
            }
            return stepID;
        }



        #endregion  ExtensionMethod
    }
}

