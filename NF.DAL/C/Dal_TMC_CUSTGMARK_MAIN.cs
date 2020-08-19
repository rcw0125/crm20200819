using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMC_CUSTGMARK_MAIN
    /// </summary>
    public partial class Dal_TMC_CUSTGMARK_MAIN
    {
        public Dal_TMC_CUSTGMARK_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMC_CUSTGMARK_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMC_CUSTGMARK_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_CUSTGMARK_MAIN(");
            strSql.Append("C_ID,C_TITLE,C_XGID,C_STLGRD,D_TIME,C_CUSTNO,C_CUSTNAME,C_EMPID,C_EMPNAME,N_STATUS,C_REMARK,C_ORDER_NO)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_TITLE,:C_XGID,:C_STLGRD,:D_TIME,:C_CUSTNO,:C_CUSTNAME,:C_EMPID,:C_EMPNAME,:N_STATUS,:C_REMARK,:C_ORDER_NO)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_STLGRD", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_TIME", OracleDbType.Date),
                    new OracleParameter(":C_CUSTNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTNAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,4),
            new OracleParameter(":C_REMARK", OracleDbType.Varchar2, 500),
             new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2, 500)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_TITLE;
            parameters[2].Value = model.C_XGID;
            parameters[3].Value = model.C_STLGRD;
            parameters[4].Value = model.D_TIME;
            parameters[5].Value = model.C_CUSTNO;
            parameters[6].Value = model.C_CUSTNAME;
            parameters[7].Value = model.C_EMPID;
            parameters[8].Value = model.C_EMPNAME;
            parameters[9].Value = model.N_STATUS;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.C_ORDER_NO;
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
        public bool Update(Mod_TMC_CUSTGMARK_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMC_CUSTGMARK_MAIN set ");
            strSql.Append("C_TITLE=:C_TITLE,");
            strSql.Append("C_XGID=:C_XGID,");
            strSql.Append("C_STLGRD=:C_STLGRD,");
            strSql.Append("D_TIME=:D_TIME,");
            strSql.Append("C_CUSTNO=:C_CUSTNO,");
            strSql.Append("C_CUSTNAME=:C_CUSTNAME,");
            strSql.Append("C_EMPID=:C_EMPID,");
            strSql.Append("C_EMPNAME=:C_EMPNAME,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_ORDER_NO=:C_ORDER_NO");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_TITLE", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_STLGRD", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_TIME", OracleDbType.Date),
                    new OracleParameter(":C_CUSTNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTNAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,4),
                        new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                        new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2, 500),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_TITLE;
            parameters[1].Value = model.C_XGID;
            parameters[2].Value = model.C_STLGRD;
            parameters[3].Value = model.D_TIME;
            parameters[4].Value = model.C_CUSTNO;
            parameters[5].Value = model.C_CUSTNAME;
            parameters[6].Value = model.C_EMPID;
            parameters[7].Value = model.C_EMPNAME;
            parameters[8].Value = model.N_STATUS;
            parameters[9].Value = model.C_REMARK;
            parameters[10].Value = model.C_ORDER_NO;
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
            strSql.Append("delete from TMC_CUSTGMARK_MAIN ");
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
            strSql.Append("delete from TMC_CUSTGMARK_MAIN ");
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
        public Mod_TMC_CUSTGMARK_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TITLE,C_XGID,C_STLGRD,D_TIME,C_CUSTNO,C_CUSTNAME,C_EMPID,C_EMPNAME,N_STATUS,C_REMARK,C_ORDER_NO from TMC_CUSTGMARK_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMC_CUSTGMARK_MAIN model = new Mod_TMC_CUSTGMARK_MAIN();
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
        public Mod_TMC_CUSTGMARK_MAIN DataRowToModel(DataRow row)
        {
            Mod_TMC_CUSTGMARK_MAIN model = new Mod_TMC_CUSTGMARK_MAIN();
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
                if (row["C_XGID"] != null)
                {
                    model.C_XGID = row["C_XGID"].ToString();
                }
                if (row["C_STLGRD"] != null)
                {
                    model.C_STLGRD = row["C_STLGRD"].ToString();
                }
                if (row["D_TIME"] != null && row["D_TIME"].ToString() != "")
                {
                    model.D_TIME = DateTime.Parse(row["D_TIME"].ToString());
                }
                if (row["C_CUSTNO"] != null)
                {
                    model.C_CUSTNO = row["C_CUSTNO"].ToString();
                }
                if (row["C_CUSTNAME"] != null)
                {
                    model.C_CUSTNAME = row["C_CUSTNAME"].ToString();
                }
                if (row["C_EMPID"] != null)
                {
                    model.C_EMPID = row["C_EMPID"].ToString();
                }
                if (row["C_EMPNAME"] != null)
                {
                    model.C_EMPNAME = row["C_EMPNAME"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
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
            strSql.Append("select C_ID,C_TITLE,C_XGID,C_STLGRD,D_TIME,C_CUSTNO,C_CUSTNAME,C_EMPID,C_EMPNAME,N_STATUS,C_REMARK,C_ORDER_NO ");
            strSql.Append(" FROM TMC_CUSTGMARK_MAIN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 检测当前月是否评分
        /// </summary>
        /// <param name="empID">操作人ID</param>
        /// <returns></returns>
        public bool CheckMonth(string empID)
        {
            string cmdText = "select * from TMC_CUSTGMARK_MAIN where to_char(D_TIME,'yyyy')=to_char(sysdate,'yyyy') and to_char(D_TIME,'mm')=to_char(sysdate,'mm')  and C_EMPID='" + empID + "'";
            int row = DbHelperOra.Query(cmdText).Tables[0].Rows.Count;
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertData(Mod_TMC_CUSTGMARK_MAIN mod, DataTable dt)
        {

            ArrayList sqlList = new ArrayList();
            string pkid = Guid.NewGuid().ToString();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMC_CUSTGMARK_MAIN(");
            strSql.Append("C_ID,C_TITLE,C_STLGRD,C_CUSTNO,C_CUSTNAME,C_EMPID,C_EMPNAME,C_REMARK,C_ORDER_NO)");
            strSql.Append(" values (");
            strSql.Append("'" + pkid + "','" + mod.C_TITLE + "','" + mod.C_STLGRD + "','" + mod.C_CUSTNO + "','" + mod.C_CUSTNAME + "','" + mod.C_EMPID + "','" + mod.C_EMPNAME + "','" + mod.C_REMARK + "','" + mod.C_ORDER_NO + "')");
            sqlList.Add(strSql.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into TMC_CUSTGIVEMARK(");
                strSql2.Append("C_PKHID,C_PKID,N_SCORE)");
                strSql2.Append(" values (");
                strSql2.Append("'" + pkid + "','" + dt.Rows[i]["C_ID"].ToString() + "'," + dt.Rows[i]["N_SCORE"].ToString() + ")");
                sqlList.Add(strSql2.ToString());
            }

            return DbHelperOra.ExecuteSqlTran(sqlList);

        }




        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string title, string start, string end, string empID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMC_CUSTGMARK_MAIN where 1=1");

            if (!string.IsNullOrEmpty(empID))
            {
                strSql.Append(" and C_EMPID = '" + empID + "'");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strSql.Append(" and C_TITLE like '%" + title + "%'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_TIME between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string title, string start, string end, string empID)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_TITLE,C_XGID,C_STLGRD,D_TIME,C_CUSTNO,C_CUSTNAME,C_EMPID,C_EMPNAME,N_STATUS,C_REMARK,C_ORDER_NO";
            string table = "TMC_CUSTGMARK_MAIN";
            string order = "D_TIME  desc";



            if (!string.IsNullOrEmpty(empID))
            {
                where.Append(" and C_EMPID = '" + empID + "'");
            }
            if (!string.IsNullOrEmpty(title))
            {
                where.Append(" and C_TITLE like '%" + title + "%'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_TIME between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }


        #endregion  BasicMethod

    }
}

