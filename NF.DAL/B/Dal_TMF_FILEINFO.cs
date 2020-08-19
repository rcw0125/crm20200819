using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMF_FILEINFO
    /// </summary>
    public partial class Dal_TMF_FILEINFO
    {
        public Dal_TMF_FILEINFO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMF_FILEINFO");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMF_FILEINFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMF_FILEINFO(");
            strSql.Append("C_ID,C_FLOW_ID,C_EMP_ID,C_TITLE,C_CONTENT,C_FILEURL,N_STATUS,D_SB_DT,C_REMARK,N_TYPE,C_TASK_ID,C_STEP_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_FLOW_ID,:C_EMP_ID,:C_TITLE,:C_CONTENT,:C_FILEURL,:N_STATUS,:D_SB_DT,:C_REMARK,:N_TYPE,:C_TASK_ID,:C_STEP_ID)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_FILEURL", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":D_SB_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_TASK_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_FLOW_ID;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.C_TITLE;
            parameters[4].Value = model.C_CONTENT;
            parameters[5].Value = model.C_FILEURL;
            parameters[6].Value = model.N_STATUS;
            parameters[7].Value = model.D_SB_DT;
            parameters[8].Value = model.C_REMARK;
            parameters[9].Value = model.N_TYPE;
            parameters[10].Value = model.C_TASK_ID;
            parameters[11].Value = model.C_STEP_ID;

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
        public bool Update(Mod_TMF_FILEINFO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMF_FILEINFO set ");
            strSql.Append("C_FLOW_ID=:C_FLOW_ID,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_TITLE=:C_TITLE,");
            strSql.Append("C_CONTENT=:C_CONTENT,");
            strSql.Append("C_FILEURL=:C_FILEURL,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("D_SB_DT=:D_SB_DT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_TYPE=:N_TYPE,");
            strSql.Append("C_TASK_ID=:C_TASK_ID,");
            strSql.Append("C_STEP_ID=:C_STEP_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_FILEURL", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":D_SB_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_TASK_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FLOW_ID;
            parameters[1].Value = model.C_EMP_ID;
            parameters[2].Value = model.C_TITLE;
            parameters[3].Value = model.C_CONTENT;
            parameters[4].Value = model.C_FILEURL;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.D_SB_DT;
            parameters[7].Value = model.C_REMARK;
            parameters[8].Value = model.N_TYPE;
            parameters[9].Value = model.C_TASK_ID;
            parameters[10].Value = model.C_STEP_ID;
            parameters[11].Value = model.C_ID;

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
            strSql.Append("delete from TMF_FILEINFO ");
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
            strSql.Append("delete from TMF_FILEINFO ");
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
        public Mod_TMF_FILEINFO GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FLOW_ID,C_EMP_ID,C_TITLE,C_CONTENT,C_FILEURL,N_STATUS,D_SB_DT,C_REMARK,N_TYPE,C_TASK_ID,C_STEP_ID from TMF_FILEINFO ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMF_FILEINFO model = new Mod_TMF_FILEINFO();
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
        public Mod_TMF_FILEINFO DataRowToModel(DataRow row)
        {
            Mod_TMF_FILEINFO model = new Mod_TMF_FILEINFO();
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
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_TITLE"] != null)
                {
                    model.C_TITLE = row["C_TITLE"].ToString();
                }
                if (row["C_CONTENT"] != null)
                {
                    model.C_CONTENT = row["C_CONTENT"].ToString();
                }
                if (row["C_FILEURL"] != null)
                {
                    model.C_FILEURL = row["C_FILEURL"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["D_SB_DT"] != null && row["D_SB_DT"].ToString() != "")
                {
                    model.D_SB_DT = DateTime.Parse(row["D_SB_DT"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
                }
                if (row["C_TASK_ID"] != null)
                {
                    model.C_TASK_ID = row["C_TASK_ID"].ToString();
                }
                if (row["C_STEP_ID"] != null)
                {
                    model.C_STEP_ID = row["C_STEP_ID"].ToString();
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
            strSql.Append("select C_ID,C_FLOW_ID,C_EMP_ID,C_TITLE,C_CONTENT,C_FILEURL,N_STATUS,D_SB_DT,C_REMARK,N_TYPE,C_TASK_ID,C_STEP_ID ");
            strSql.Append(" FROM TMF_FILEINFO ");
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
            strSql.Append("select count(1) FROM TMF_FILEINFO ");
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
            strSql.Append(")AS Row, T.*  from TMF_FILEINFO T ");
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
        /// 最后批准步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateLastStep(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.NEXTSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //更新合同审批记录//更新合同状态
            strSql.Add("update TMO_CON set C_APPROVEID='" + mod.C_EMP_ID + "',D_APPROVEDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),N_STATUS=" + mod.CON_STATUS + " where C_CON_NO='" + mod.CON_NO + "' ");

            //更新订单状态
            strSql.Add("UPDATE TMO_CON_ORDER SET N_STATUS=" + mod.CON_STATUS + "  WHERE C_SFPJ='N' and  C_CON_NO='" + mod.CON_NO + "'");
            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP where C_FILE_ID='" + mod.FILEID + "'");

            return DbHelperOra.ExecuteSqlTran(strSql);

        }

        /// <summary>
        /// 质量异议-最后批准步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateLastStep_QUA(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.NEXTSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //更新质量审批记录//更新质量状态

            string str = $@"update TMQ_QUA_MAIN set C_APPROVEID='{ mod.C_EMP_ID }',N_STATUS={mod.CON_STATUS},C_QUALITY_RESULT='{ mod.JYRESULT }',N_AMOUNT={mod.PFMONEY},D_COMPENSATION_DT=TO_DATE('{mod.PFDATE}','yyyy-mm-dd hh24:mi:ss') where C_ID='{mod.CON_NO }'";
            strSql.Add(str);

            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP where C_FILE_ID='" + mod.FILEID + "'");

            return DbHelperOra.ExecuteSqlTran(strSql);

        }

        /// <summary>
        /// 线材资源-最后批准步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateLastStep_ROLL(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.NEXTSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //更新线材资源审批记录//更新线材资源状态

            string str = $@"update TMC_ROLL_APPLY set C_APPROVEID='{ mod.C_EMP_ID }',C_STATUS='{mod.CON_STATUS}' where C_ID='{mod.CON_NO }'";
            strSql.Add(str);

            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP where C_FILE_ID='" + mod.FILEID + "'");

            return DbHelperOra.ExecuteSqlTran(strSql);

        }

        /// <summary>
        /// 驳回最后步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateBackLastSetp(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.UPSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP  where C_FILE_ID ='" + mod.FILEID + "'");

            //更新合同状态
            strSql.Add("update TMO_CON set N_STATUS=" + mod.CON_STATUS + ",C_APPROVEID='" + mod.C_EMP_ID + "',D_APPROVEDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss') where C_CON_NO='" + mod.CON_NO + "'");

            //更新未评价订单池状态
            strSql.Add("update TMO_CON_ORDER set N_STATUS=" + mod.CON_STATUS + " where C_SFPJ='N' and  C_CON_NO='" + mod.CON_NO + "'");

            return DbHelperOra.ExecuteSqlTran(strSql);

        }

        /// <summary>
        /// 质量异议-驳回最后步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateBackLastSetp_QUA(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.UPSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP  where C_FILE_ID ='" + mod.FILEID + "'");

            //更新合同状态
            strSql.Add("update TMQ_QUA_MAIN set N_STATUS=" + mod.CON_STATUS + ",C_APPROVEID='" + mod.C_EMP_ID + "' where C_ID='" + mod.CON_NO + "'");


            return DbHelperOra.ExecuteSqlTran(strSql);

        }


        /// <summary>
        /// 线材资源-驳回最后步骤操作
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateBackLastSetp_ROLL(Mod_ApproveCon mod)
        {
            ArrayList strSql = new ArrayList();

            //更新文件事务状态为办结
            strSql.Add("UPDATE TMF_FILEINFO SET C_STEP_ID='" + mod.UPSTEPID + "',N_STATUS='" + mod.FILE_STATUS + "' where C_ID='" + mod.FILEID + "'");

            //删除步骤记录
            strSql.Add("delete from TMB_FILE_NEXT_EMP  where C_FILE_ID ='" + mod.FILEID + "'");

            //更新状态
            strSql.Add("update TMC_ROLL_APPLY set C_STATUS='" + mod.CON_STATUS + "',C_APPROVEID='" + mod.C_EMP_ID + "' where C_ID='" + mod.CON_NO + "'");


            return DbHelperOra.ExecuteSqlTran(strSql);

        }


        /// <summary>
        /// 更新步骤
        /// </summary>
        public bool UpdateStep(string step, string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMF_FILEINFO set ");

            strSql.Append("C_STEP_ID=:C_STEP_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = step;
            parameters[1].Value = ID;

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
        /// 更新步骤/状态
        /// </summary>
        public bool UpdateStepStatus(string step, int status, string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMF_FILEINFO set ");
            strSql.Append("C_STEP_ID='" + step + "',");
            strSql.Append("N_STATUS=" + status + "");
            strSql.Append(" where C_ID='" + ID + "'");

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string flowID, int type, string taskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FLOW_ID,C_EMP_ID,C_TITLE,C_CONTENT,C_FILEURL,N_STATUS,D_SB_DT,C_REMARK,N_TYPE,C_TASK_ID,C_STEP_ID ");
            strSql.Append(" FROM TMF_FILEINFO  where 1=1");
            if (!string.IsNullOrEmpty(flowID))
            {
                strSql.Append(" and C_FLOW_ID='" + flowID + "'");
            }

            strSql.Append(" and N_TYPE=" + type + "");


            if (!string.IsNullOrEmpty(taskID))
            {
                strSql.Append(" and C_TASK_ID='" + taskID + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string flowID, int type, string taskID, string empID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FLOW_ID,C_EMP_ID,C_TITLE,C_CONTENT,C_FILEURL,N_STATUS,D_SB_DT,C_REMARK,N_TYPE,C_TASK_ID,C_STEP_ID ");
            strSql.Append(" FROM TMF_FILEINFO  where 1=1");
            if (!string.IsNullOrEmpty(flowID))
            {
                strSql.Append(" and C_FLOW_ID='" + flowID + "'");
            }

            strSql.Append(" and N_TYPE=" + type + "");

            if (!string.IsNullOrEmpty(taskID))
            {
                strSql.Append(" and C_TASK_ID='" + taskID + "'");
            }

            if (!string.IsNullOrEmpty(empID))
            {
                strSql.Append(" and C_EMP_ID='" + empID + "'");
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得未处理事务
        /// </summary>
        public DataSet GetUntrWork(string flowID, string empID, string title, string start, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select distinct t.c_task_id,
                                                t.c_id,
                                                (select a.c_name from ts_user a where a.c_id = t.c_emp_id) c_emp_id,
                                                t.c_title,
                                                t.d_sb_dt,
                                                decode(0, t.n_status, '未结', 1, t.n_status, '办结') n_status,
                                                t.c_step_id,
                                                t.n_type,
                                                t.C_FLOW_ID,
                                                (select c.c_name
                                                   from tmb_flowinfo c
                                                  where c.c_id = t.c_flow_id) c_flow_name
                                  from TMF_FILEINFO t
                                 inner join tmb_file_next_emp b
                                    on t.c_id = b.c_file_id
                                   and t.c_step_id = b.c_step_id
                                 where t.n_status = 0
                                   and b.C_REMARK='N'
                                   and b.c_next_emp_id = '{0}'", empID);

            if (!string.IsNullOrEmpty(flowID))
            {
                strSql.Append(" and t.c_flow_id='" + flowID + "'");
            }

            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and t.c_title like '%" + title + "%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and t.d_sb_dt between to_date('" + Convert.ToDateTime(start).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" order by t.d_sb_dt desc");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得已处理的事务
        /// </summary>
        public DataSet GetFinishWork(string flowID, string empID, string title, string start, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.c_task_id,
                           t.c_id,
                           (select a.c_name from ts_user a where a.c_id = t.c_emp_id) c_emp_id,
                           t.c_title,
                           t.d_sb_dt,
                          decode(0,t.n_status,'未结',1,t.n_status,'办结') n_status,
                           t.c_step_id,
                           t.n_type,
                           t.C_FLOW_ID,
                           (select c.c_name from tmb_flowinfo c where c.c_id = t.c_flow_id) c_flow_name
                      from TMF_FILEINFO t
                     where  t.c_id in (select distinct b.C_FILE_ID from tmb_flowproc b where b.C_STEP_EMP_ID='{0}')", empID);


            if (!string.IsNullOrEmpty(flowID))
            {
                strSql.Append(" and t.c_flow_id='" + flowID + "'");
            }

            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and t.c_title like '%" + title + "%'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and t.d_sb_dt between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1) + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" order by t.d_sb_dt desc ");

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

