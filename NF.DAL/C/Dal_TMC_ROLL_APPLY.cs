using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 线材资源申请
    /// </summary>
    public partial class Dal_TMC_ROLL_APPLY
    {
        public Dal_TMC_ROLL_APPLY()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_ROLL_APPLY");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_ROLL_APPLY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_ROLL_APPLY(");
            strSql.Append("C_TITLE,C_CONTENT,C_EMPID,C_EMPNAME,D_MOD,C_STATUS,C_APPROVEID,D_APPROVEDATE)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_TITLE,:C_CONTENT,:C_EMPID,:C_EMPNAME,:D_MOD,:C_STATUS,:C_APPROVEID,:D_APPROVEDATE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD", OracleDbType.Date),
                    new OracleParameter(":C_STATUS", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_TITLE;
            parameters[2].Value = model.C_CONTENT;
            parameters[3].Value = model.C_EMPID;
            parameters[4].Value = model.C_EMPNAME;
            parameters[5].Value = model.D_MOD;
            parameters[6].Value = model.C_STATUS;
            parameters[7].Value = model.C_APPROVEID;
            parameters[8].Value = model.D_APPROVEDATE;

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
        public bool Update(Mod_TMC_ROLL_APPLY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_ROLL_APPLY set ");
            strSql.Append("C_TITLE=:C_TITLE,");
            strSql.Append("C_CONTENT=:C_CONTENT,");
            strSql.Append("C_EMPID=:C_EMPID,");
            strSql.Append("C_EMPNAME=:C_EMPNAME,");
            strSql.Append("D_MOD=:D_MOD,");
            strSql.Append("C_STATUS=:C_STATUS,");
            strSql.Append("C_APPROVEID=:C_APPROVEID,");
            strSql.Append("D_APPROVEDATE=:D_APPROVEDATE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CONTENT", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD", OracleDbType.Date),
                    new OracleParameter(":C_STATUS", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_TITLE;
            parameters[1].Value = model.C_CONTENT;
            parameters[2].Value = model.C_EMPID;
            parameters[3].Value = model.C_EMPNAME;
            parameters[4].Value = model.D_MOD;
            parameters[5].Value = model.C_STATUS;
            parameters[6].Value = model.C_APPROVEID;
            parameters[7].Value = model.D_APPROVEDATE;
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
            ArrayList arraySql = new ArrayList();

            string strSql = $@"DELETE FROM TMC_ROLL_APPLY WHERE C_ID='{C_ID}'";
            string strSql2 = $@"DELETE FROM TMC_ROLL_APPLY_ITEM WHERE C_PKID='{C_ID}'";

            arraySql.Add(strSql);
            arraySql.Add(strSql2);
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMC_ROLL_APPLY ");
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
        public Mod_TMC_ROLL_APPLY GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TITLE,C_CONTENT,C_EMPID,C_EMPNAME,D_MOD,C_STATUS,C_APPROVEID,D_APPROVEDATE from TMC_ROLL_APPLY ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMC_ROLL_APPLY model = new Mod_TMC_ROLL_APPLY();
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
        public Mod_TMC_ROLL_APPLY DataRowToModel(DataRow row)
        {
            Mod_TMC_ROLL_APPLY model = new Mod_TMC_ROLL_APPLY();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_TITLE"] != null)
                {
                    model.C_TITLE = row["C_TITLE"].ToString();
                }
                if (row["C_CONTENT"] != null)
                {
                    model.C_CONTENT = row["C_CONTENT"].ToString();
                }
                if (row["C_EMPID"] != null)
                {
                    model.C_EMPID = row["C_EMPID"].ToString();
                }
                if (row["C_EMPNAME"] != null)
                {
                    model.C_EMPNAME = row["C_EMPNAME"].ToString();
                }
                if (row["D_MOD"] != null && row["D_MOD"].ToString() != "")
                {
                    model.D_MOD = DateTime.Parse(row["D_MOD"].ToString());
                }
                if (row["C_STATUS"] != null)
                {
                    model.C_STATUS = row["C_STATUS"].ToString();
                }
                if (row["C_APPROVEID"] != null)
                {
                    model.C_APPROVEID = row["C_APPROVEID"].ToString();
                }
                if (row["D_APPROVEDATE"] != null && row["D_APPROVEDATE"].ToString() != "")
                {
                    model.D_APPROVEDATE = DateTime.Parse(row["D_APPROVEDATE"].ToString());
                }
            }
            return model;
        }

        #region  //资源送审
        /// <summary>
        /// 质量异议审批
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveQua(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
        {
            ArrayList arraySql = new ArrayList();

            #region //文件
            string ID = Guid.NewGuid().ToString("N");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMF_FILEINFO(");
            strSql.Append("C_ID,");
            strSql.Append("C_FLOW_ID,");
            strSql.Append("C_EMP_ID,");
            strSql.Append("C_TITLE,");
            strSql.Append("C_CONTENT,");
            strSql.Append("N_TYPE,");
            strSql.Append("C_TASK_ID,");
            strSql.Append("C_STEP_ID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + ID + "',");
            strSql.Append("'" + modFile.C_FLOW_ID + "',");
            strSql.Append("'" + modFile.C_EMP_ID + "',");
            strSql.Append("'" + modFile.C_TITLE + "',");
            strSql.Append("'" + modFile.C_CONTENT + "',");
            strSql.Append("" + modFile.N_TYPE + ",");
            strSql.Append("'" + modFile.C_TASK_ID + "',");
            strSql.Append("'" + modFile.C_STEP_ID + "'");
            strSql.Append(")");
            arraySql.Add(strSql.ToString());
            #endregion

            #region //更新质量异议反馈
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update TMC_ROLL_APPLY set ");   
            strSql2.Append("C_STATUS='1', ");//1审批中         
            strSql2.Append("C_APPROVEID='" + modNextEmp.C_NEXT_EMP_ID + "' ");//审批人
            strSql2.Append(" where C_ID='" + modFile.C_TASK_ID + "' ");
            arraySql.Add(strSql2.ToString());
            #endregion

            #region//步骤操作人
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into TMB_FILE_NEXT_EMP(");
            strSql3.Append("C_FILE_ID,");
            strSql3.Append("C_NEXT_EMP_ID,");
            strSql3.Append("C_STEP_ID");
            strSql3.Append(")");
            strSql3.Append(" values (");
            strSql3.Append("'" + ID + "',");
            strSql3.Append("'" + modNextEmp.C_NEXT_EMP_ID + "',");
            strSql3.Append("'" + modNextEmp.C_STEP_ID + "'");
            strSql3.Append(")");
            arraySql.Add(strSql3.ToString());
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion



        public bool Insert(Mod_TMC_ROLL_APPLY mod)
        {
            string strSql = $@"INSERT INTO TMC_ROLL_APPLY(C_ID,C_TITLE,C_EMPID,C_EMPNAME)VALUES('{mod.C_ID}','{mod.C_TITLE}','{mod.C_EMPID}','{mod.C_EMPNAME}')";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TITLE,C_CONTENT,C_EMPID,C_EMPNAME,D_MOD,C_STATUS,C_APPROVEID,D_APPROVEDATE ");
            strSql.Append(" FROM TMC_ROLL_APPLY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string startDate, string endDate, string status, string empID)
        {
            String strSql = $@"SELECT C_ID,
                               C_TITLE,
                               C_CONTENT,
                               C_EMPID,
                               C_EMPNAME,
                               D_MOD,
                               C_STATUS,
                               (decode(C_STATUS,
                                       '-1',
                                       '未提交',
                                       '0',
                                       '待处理',
                                       '1',
                                       '审批中',
                                       '2',
                                       '已完成')) C_STATUS2,
                               C_APPROVEID,
                               D_APPROVEDATE
                          FROM TMC_ROLL_APPLY WHERE 1=1";
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql += $@" AND D_MOD >= TO_DATE('{startDate}', 'yyyy-mm-dd hh24:mi:ss') AND D_MOD <= TO_DATE('{endDate} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            if (!string.IsNullOrEmpty(status))
            {
                strSql += $@" AND C_STATUS='{status}'";
            }
            if (!string.IsNullOrEmpty(empID))
            {
                strSql += $@" AND C_EMPID='{empID}'";
            }
            strSql += $@" ORDER BY D_MOD DESC ";



            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMC_ROLL_APPLY ");
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
            strSql.Append(")AS Row, T.*  from TMC_ROLL_APPLY T ");
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

