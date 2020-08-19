using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections.Generic;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 区域计划量
    /// </summary>
    public partial class Dal_TMB_AREAPLAN
    {
        public Dal_TMB_AREAPLAN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_AREAPLAN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)           };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string areaID, string start, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_AREAPLAN");
            strSql.Append(" where C_AERA_ID=:C_AERA_ID and to_date('" + Convert.ToDateTime(start) + "', 'yyyy-mm-dd hh24:mi:ss')>=D_START and to_date('" + Convert.ToDateTime(end) + "', 'yyyy-mm-dd hh24:mi:ss') <= D_END ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_AERA_ID",OracleDbType.Varchar2,100)           };
            parameters[0].Value = areaID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加多条数据
        /// </summary>
        public bool AddList(List<Mod_TMB_AREAPLAN> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"insert into TMB_AREAPLAN(C_ID,C_AERA_ID,N_WGT_PT,N_WGT_GS,N_WGT_JP,N_WGT_JK,D_START,D_END,C_EMP_ID,C_EMP_NAME,N_SORT)values('{Guid.NewGuid().ToString("N")}','{item.C_AERA_ID}',{item.N_WGT_PT},{item.N_WGT_GS},{item.N_WGT_JP},{item.N_WGT_JK},to_date('{item.D_START} ', 'yyyy-mm-dd hh24:mi:ss'),to_date('{item.D_END} ', 'yyyy-mm-dd hh24:mi:ss'),'{item.C_EMP_ID}','{item.C_EMP_NAME}',{item.N_SORT})";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_AREAPLAN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_AREAPLAN(");
            strSql.Append("C_ID,C_AERA_ID,N_WGT,D_START,D_END,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_AERA_ID,:N_WGT,:D_START,:D_END,:C_REMARK,:N_STATUS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AERA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,9),
                    new OracleParameter(":D_START", OracleDbType.Date),
                    new OracleParameter(":D_END", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_AERA_ID;
            parameters[2].Value = model.N_WGT;
            parameters[3].Value = model.D_START;
            parameters[4].Value = model.D_END;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.N_STATUS;
            parameters[7].Value = model.C_EMP_ID;
            parameters[8].Value = model.C_EMP_NAME;
            parameters[9].Value = model.D_MOD_DT;

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
        public bool Update(Mod_TMB_AREAPLAN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_AREAPLAN set ");
            strSql.Append("C_AERA_ID=:C_AERA_ID,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("D_START=:D_START,");
            strSql.Append("D_END=:D_END,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_AERA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,9),
                    new OracleParameter(":D_START", OracleDbType.Date),
                    new OracleParameter(":D_END", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_AERA_ID;
            parameters[1].Value = model.N_WGT;
            parameters[2].Value = model.D_START;
            parameters[3].Value = model.D_END;
            parameters[4].Value = model.C_REMARK;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.C_EMP_NAME;
            parameters[8].Value = model.D_MOD_DT;
            parameters[9].Value = model.C_ID;

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
        /// 更新多条数据
        /// </summary>
        public bool UpdateList(List<Mod_TMB_AREAPLAN> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"UPDATE TMB_AREAPLAN SET N_WGT_PT={item.N_WGT_PT},N_WGT_GS={item.N_WGT_GS},N_WGT_JP={item.N_WGT_JP},N_WGT_JK={item.N_WGT_JK} WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMB_AREAPLAN ");
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
            strSql.Append("delete from TMB_AREAPLAN ");
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
        public Mod_TMB_AREAPLAN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_AERA_ID,N_WGT,D_START,D_END,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMB_AREAPLAN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMB_AREAPLAN model = new Mod_TMB_AREAPLAN();
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
        public Mod_TMB_AREAPLAN DataRowToModel(DataRow row)
        {
            Mod_TMB_AREAPLAN model = new Mod_TMB_AREAPLAN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_AERA_ID"] != null)
                {
                    model.C_AERA_ID = row["C_AERA_ID"].ToString();
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["D_START"] != null && row["D_START"].ToString() != "")
                {
                    model.D_START = DateTime.Parse(row["D_START"].ToString());
                }
                if (row["D_END"] != null && row["D_END"].ToString() != "")
                {
                    model.D_END = DateTime.Parse(row["D_END"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
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
        /// 获取当前时间区域计划量/实际订单量
        /// </summary>
        /// <returns></returns>
        public DataSet GetPlanWGT()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"with tt as
 (select t.C_AERA_ID, t.n_wgt, t.d_start, t.d_end
    from TMB_AREAPLAN t
   where t.n_status = 1
     and sysdate >= t.d_start
     and sysdate <= t.d_end)
select C_AERA_ID || ':' || to_char(n_wgt) || '/' ||
       to_char((select nvl(sum(c.n_wgt), 0)
                 from TMO_CON_ORDER c
                where c.n_status = 2
                  and c.c_area = tt.C_AERA_ID
                  and c.d_dt >= tt.d_start
                  and c.d_dt <= tt.d_end)) as wgt
  from tt
");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取区域计划量具体钢种接单量
        /// </summary>
        /// <param name="saleArea">销售区域</param>
        /// <param name="maxclass">大类</param>
        /// <param name="sfkj">监控钢种</param>
        /// <param name="stlgrdcalss">钢类</param>
        /// <returns></returns>
        public DataSet GetPlanStlGRD(string saleArea, string maxclass, string sfkj, string stlgrdcalss)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT   D.C_STL_GRD,D.C_STL_GRD_CLASS,D.C_SFJK,D.C_PROD_NAME, SUM(D.N_WGT) AS WGT FROM 
                                             (SELECT B.C_DETAILNAME, T.N_WGT, T.D_START, T.D_END
                                                FROM TMB_AREAPLAN T
                                               INNER JOIN TS_DIC B
                                                  ON B.C_DETAILCODE = T.C_AERA_ID
                                               WHERE T.N_STATUS = 1
                                                 AND SYSDATE >= T.D_START
                                                 AND SYSDATE <= T.D_END) TMB
                                             INNER JOIN TMO_CON_ORDER D
                                                ON TMB.C_DETAILNAME = D.C_AREA
                                             WHERE D.N_STATUS = 2
                                               AND D.C_AREA = '{0}'
                                               AND D.D_DT >= TMB.D_START
                                               AND D.D_DT <= TMB.D_END", saleArea);
            if (!string.IsNullOrEmpty(maxclass))
            {
                strSql.AppendFormat(" AND D.C_STL_GRD_CLASS='{0}'", maxclass);
            }
            if (!string.IsNullOrEmpty(sfkj))
            {
                strSql.AppendFormat(" AND D.C_SFJK='{0}'", sfkj);
            }
            if (!string.IsNullOrEmpty(stlgrdcalss))
            {
                strSql.AppendFormat(" AND D.C_PROD_NAME='{0}'", stlgrdcalss);
            }
            strSql.Append(@" GROUP BY D.C_STL_GRD,D.C_STL_GRD_CLASS,D.C_SFJK,D.C_PROD_NAME
                                             ORDER BY D.C_STL_GRD_CLASS,D.C_PROD_NAME ");

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_AERA_ID,N_WGT,D_START,D_END,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMB_AREAPLAN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string areaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMB_AREAPLAN where N_STATUS=1 ");
            if (!string.IsNullOrEmpty(areaID))
            {
                strSql.Append("and C_AERA_ID='" + areaID + "'");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string areaID)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_AERA_ID,N_WGT,D_START,D_END,C_REMARK,N_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT";
            string table = "TMB_AREAPLAN ";
            string order = "D_MOD_DT  desc";

            where.Append(" and N_STATUS=1");

            if (!string.IsNullOrEmpty(areaID))
            {
                where.Append("and C_AERA_ID='" + areaID + "'");
            }


            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }




        #endregion  BasicMethod

        /// <summary>
        /// 获取签单指标
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetAreaPlan(string startDate,string endDate)
        {
            DataTable dt = new DataTable();

            string strSql = $@"SELECT T.C_ID,T.C_AERA_ID AS AREA,T.D_START,T.D_END,T.C_EMP_ID,T.C_EMP_NAME,T.D_MOD_DT,T.N_WGT_JK,T.N_SORT,T.N_WGT_PT,T.N_WGT_GS,T.N_WGT_JP 
                              FROM TMB_AREAPLAN T
                             WHERE TO_DATE('{startDate}', 'YYYY-MM-DD') >= t.d_start
                               AND TO_DATE('{endDate}', 'YYYY-MM-DD') <= t.d_end
                             ORDER BY T.N_SORT";

            dt = DbHelperOra.Query(strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                string cmdText = $@"SELECT '' AS C_ID,
                                   T.C_DETAILNAME AS AREA,
                                   '' AS N_WGT_PT,
                                   '' AS N_WGT_GS,
                                   '' AS N_WGT_JP,
                                   '' AS N_WGT_JK,
                                   '' AS D_START,
                                   '' AS D_END
                              FROM TS_DIC T
                             WHERE T.C_TYPECODE = 'ConArea'
                               AND T.C_DETAILCODE NOT IN ('6', '7', '10', '11','23','28')
                             ORDER BY T.C_INDEX";
                return DbHelperOra.Query(cmdText).Tables[0];
            }

        }


        #region 签单指标分析

        public DataSet Get_QD_FX(string empID)
        {
            string strSql = $@"SELECT TS.C_DETAILNAME,
       JP.N_WGT AS JP_WGT,
       GS.N_WGT AS GS_WGT,
       PT.N_WGT AS PT_WGT,
       JK.N_WGT AS JK_WGT， ZB.N_WGT AS ZB_WGT,
       ZB.N_WGT_JK AS ZB_WGT_JK,
       (NVL(JP.N_WGT, 0) + NVL(GS.N_WGT, 0) + NVL(PT.N_WGT, 0)) SUMWGT,
       ((NVL(JP.N_WGT, 0) + NVL(GS.N_WGT, 0) + NVL(PT.N_WGT, 0)) -
       NVL(ZB.N_WGT, 0)) CZ_WGT,
       (NVL(JK.N_WGT, 0) - NVL(ZB.N_WGT_JK, 0)) CZ_WGT_JK
  FROM (SELECT T.C_DETAILNAME
          FROM TS_DIC T
         WHERE T.C_TYPECODE = 'ConArea'
           AND T.C_DETAILCODE NOT IN ('6', '7', '10', '11')
         ORDER BY T.C_INDEX) TS
  LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, T.C_AREA
               FROM V_CON_ORDER_TYPE T
              WHERE T.C_CON_NO IN
                    (select distinct a.c_task_id
                       from TMB_FLOWPROC t
                      inner join tmf_fileinfo a
                         on a.c_id = t.c_file_id
                      WHERE T.C_STEP_EMP_ID = '{empID}')
                AND T.N_STATUS IN (0, 1, 2, 4)
                AND T.C_TYPE = '精品线材'
                AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
              GROUP BY T.C_AREA) JP --精品线材
    ON JP.C_AREA = TS.C_DETAILNAME
  left join (SELECT SUM(T.N_WGT) N_WGT, T.C_AREA
               FROM V_CON_ORDER_TYPE T
              WHERE T.C_CON_NO IN
                    (select distinct a.c_task_id
                       from TMB_FLOWPROC t
                      inner join tmf_fileinfo a
                         on a.c_id = t.c_file_id
                      WHERE T.C_STEP_EMP_ID = '{empID}')
                AND T.N_STATUS IN (0, 1, 2, 4)
                AND T.C_TYPE = '高速线材'
                AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
              GROUP BY T.C_AREA) GS --高速线材--普碳钢
    ON GS.C_AREA = TS.C_DETAILNAME
  left join (SELECT SUM(T.N_WGT) N_WGT, T.C_AREA
               FROM V_CON_ORDER_TYPE T
              WHERE T.C_CON_NO IN
                    (select distinct a.c_task_id
                       from TMB_FLOWPROC t
                      inner join tmf_fileinfo a
                         on a.c_id = t.c_file_id
                      WHERE T.C_STEP_EMP_ID = '{empID}')
                AND T.N_STATUS IN (0, 1, 2, 4)
                AND T.C_TYPE = '普碳钢'
                AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
              GROUP BY T.C_AREA) PT --普碳钢
    ON PT.C_AREA = TS.C_DETAILNAME
  left join (SELECT SUM(T.N_WGT) N_WGT, T.C_AREA
               FROM V_CON_ORDER_TYPE T
              WHERE T.C_CON_NO IN
                    (select distinct a.c_task_id
                       from TMB_FLOWPROC t
                      inner join tmf_fileinfo a
                         on a.c_id = t.c_file_id
                      WHERE T.C_STEP_EMP_ID = '{empID}')
                AND T.N_STATUS IN (0, 1, 2, 4)
                AND T.C_FLAG = 'Y'
                AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
              GROUP BY T.C_AREA) JK --监控钢种
    ON JK.C_AREA = TS.C_DETAILNAME

  LEFT JOIN (SELECT T.C_AERA_ID, T.N_WGT, T.N_WGT_JK
               FROM TMB_AREAPLAN T
              WHERE TO_CHAR(T.D_START, 'YYYY-MM') =
                    TO_CHAR(SYSDATE, 'YYYY-MM')) ZB --签单指标
    ON ZB.C_AERA_ID = TS.C_DETAILNAME";
            return DbHelperOra.Query(strSql);
        }
        #endregion
    }
}

