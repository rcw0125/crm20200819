using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections;
using System.Linq;

namespace NF.DAL
{
    /// <summary>
    /// 合同
    /// </summary>
    public partial class Dal_TMO_CON
    {
        public Dal_TMO_CON()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_CON_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_CON");
            strSql.Append(" where C_CON_NO=:C_CON_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_CON_NO;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMO_CON model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMO_CON(");
            strSql.Append("C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_COPERATORID,D_DMAKEDATE,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,N_FLAG,C_SALECORPID,C_BIZTYPE,C_DEPTID,C_EMPLOYEEID,C_EDITEMPLOYEEID,D_EDITDATE,C_APPROVEID,D_APPROVEDATE,C_FLOWID,C_XGID,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_CHANGEDATE,D_NEED_DT,C_NC_STATE,C_CHANGEEMPID,N_CHANGENUM,C_RECEIPTCODE)");
            strSql.Append(" values (");
            strSql.Append(":C_CON_NO,:C_CON_NAME,:C_CONTYPEID,:C_CUSTOMERID,:C_CUSTNAME,:C_COPERATORID,:D_DMAKEDATE,:C_CURRENCYTYPEID,:D_CONSING_DT,:D_CONEFFE_DT,:D_CONINVALID_DT,:C_TRANSMODEID,:C_AREA,:N_STATUS,:N_FLAG,:C_SALECORPID,:C_BIZTYPE,:C_DEPTID,:C_EMPLOYEEID,:C_EDITEMPLOYEEID,:D_EDITDATE,:C_APPROVEID,:D_APPROVEDATE,:C_FLOWID,:C_XGID,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:N_CUST_LEV,:C_CRECEIPTCUSTOMERID,:C_ADDRESS,:C_CRECEIPTAREAID,:C_CRECEIPTCORPID,:C_STATION,:C_REAMRK,:D_CHANGEDATE,:D_NEED_DT,:C_NC_STATE,:C_CHANGEEMPID,:N_CHANGENUM,:C_RECEIPTCODE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DMAKEDATE", OracleDbType.Date),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CONSING_DT", OracleDbType.Date),
                    new OracleParameter(":D_CONEFFE_DT", OracleDbType.Date),
                    new OracleParameter(":D_CONINVALID_DT", OracleDbType.Date),
                    new OracleParameter(":C_TRANSMODEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALECORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EDITEMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_EDITDATE", OracleDbType.Date),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_FLOWID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_CUST_LEV", OracleDbType.Decimal,1),
                    new OracleParameter(":C_CRECEIPTCUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CRECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CRECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REAMRK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_CHANGEDATE", OracleDbType.Date),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":C_NC_STATE", OracleDbType.Varchar2, 100),
                    new OracleParameter(":C_CHANGEEMPID", OracleDbType.Varchar2, 100),
                    new OracleParameter(":N_CHANGENUM", OracleDbType.Decimal, 2),
                    new OracleParameter(":C_RECEIPTCODE", OracleDbType.Varchar2, 100)};
            parameters[0].Value = model.C_CON_NO;
            parameters[1].Value = model.C_CON_NAME;
            parameters[2].Value = model.C_CONTYPEID;
            parameters[3].Value = model.C_CUSTOMERID;
            parameters[4].Value = model.C_CUSTNAME;
            parameters[5].Value = model.C_COPERATORID;
            parameters[6].Value = model.D_DMAKEDATE;
            parameters[7].Value = model.C_CURRENCYTYPEID;
            parameters[8].Value = model.D_CONSING_DT;
            parameters[9].Value = model.D_CONEFFE_DT;
            parameters[10].Value = model.D_CONINVALID_DT;
            parameters[11].Value = model.C_TRANSMODEID;
            parameters[12].Value = model.C_AREA;
            parameters[13].Value = model.N_STATUS;
            parameters[14].Value = model.N_FLAG;
            parameters[15].Value = model.C_SALECORPID;
            parameters[16].Value = model.C_BIZTYPE;
            parameters[17].Value = model.C_DEPTID;
            parameters[18].Value = model.C_EMPLOYEEID;
            parameters[19].Value = model.C_EDITEMPLOYEEID;
            parameters[20].Value = model.D_EDITDATE;
            parameters[21].Value = model.C_APPROVEID;
            parameters[22].Value = model.D_APPROVEDATE;
            parameters[23].Value = model.C_FLOWID;
            parameters[24].Value = model.C_XGID;
            parameters[25].Value = model.C_EMP_ID;
            parameters[26].Value = model.C_EMP_NAME;
            parameters[27].Value = model.D_MOD_DT;
            parameters[28].Value = model.N_CUST_LEV;
            parameters[29].Value = model.C_CRECEIPTCUSTOMERID;
            parameters[30].Value = model.C_ADDRESS;
            parameters[31].Value = model.C_CRECEIPTAREAID;
            parameters[32].Value = model.C_CRECEIPTCORPID;
            parameters[33].Value = model.C_STATION;
            parameters[34].Value = model.C_REAMRK;
            parameters[35].Value = model.D_CHANGEDATE;
            parameters[36].Value = model.D_NEED_DT;
            parameters[37].Value = model.C_NC_STATE;
            parameters[38].Value = model.C_CHANGEEMPID;
            parameters[39].Value = model.N_CHANGENUM;
            parameters[40].Value = model.C_RECEIPTCODE;

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
        public bool UpdateCheckEmp(string conNO, string empID, DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CON set ");
            strSql.Append("C_APPROVEID=:C_APPROVEID,");
            strSql.Append("D_APPROVEDATE=:D_APPROVEDATE");
            strSql.Append(" where C_CON_NO=:C_CON_NO ");
            OracleParameter[] parameters = {
                 new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};

            parameters[0].Value = empID;
            parameters[1].Value = time;
            parameters[2].Value = conNO;

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
        public bool UpdateConStatus(int status, string conNO)
        {


            ArrayList strSql = new ArrayList();
            strSql.Add("update TMO_CON set N_STATUS=" + status + "  where C_CON_NO='" + conNO + "' ");
            strSql.Add("update TMO_CON_ORDER set N_STATUS=" + status + "  where  C_CON_NO='" + conNO + "'");
            return DbHelperOra.ExecuteSqlTran(strSql);
        }

        /// <summary>
        /// 更新发送NC状态
        /// </summary>
        public bool UpdateNC(string C_NC_STATE, string conNO)
        {
            string strSql = $@"update TMO_CON set C_NC_STATE='{C_NC_STATE}' where C_CON_NO='{conNO}'";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateConStatus(int status, string conNO, string flowID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CON set ");
            strSql.Append("C_FLOWID=:C_FLOWID, ");
            strSql.Append("N_STATUS=:N_STATUS ");
            strSql.Append(" where C_CON_NO=:C_CON_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FLOWID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = flowID;
            parameters[1].Value = status;
            parameters[2].Value = conNO;

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
        public bool Update(Mod_TMO_CON model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMO_CON set ");
            strSql.Append("C_CON_NAME=:C_CON_NAME,");
            strSql.Append("C_CONTYPEID=:C_CONTYPEID,");
            strSql.Append("C_CUSTOMERID=:C_CUSTOMERID,");
            strSql.Append("C_CUSTNAME=:C_CUSTNAME,");
            strSql.Append("C_COPERATORID=:C_COPERATORID,");
            strSql.Append("D_DMAKEDATE=:D_DMAKEDATE,");
            strSql.Append("C_CURRENCYTYPEID=:C_CURRENCYTYPEID,");
            strSql.Append("D_CONSING_DT=:D_CONSING_DT,");
            strSql.Append("D_CONEFFE_DT=:D_CONEFFE_DT,");
            strSql.Append("D_CONINVALID_DT=:D_CONINVALID_DT,");
            strSql.Append("C_TRANSMODEID=:C_TRANSMODEID,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("C_SALECORPID=:C_SALECORPID,");
            strSql.Append("C_BIZTYPE=:C_BIZTYPE,");
            strSql.Append("C_DEPTID=:C_DEPTID,");
            strSql.Append("C_EMPLOYEEID=:C_EMPLOYEEID,");
            strSql.Append("C_EDITEMPLOYEEID=:C_EDITEMPLOYEEID,");
            strSql.Append("D_EDITDATE=:D_EDITDATE,");
            strSql.Append("C_APPROVEID=:C_APPROVEID,");
            strSql.Append("D_APPROVEDATE=:D_APPROVEDATE,");
            strSql.Append("C_FLOWID=:C_FLOWID,");
            strSql.Append("C_XGID=:C_XGID,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_CUST_LEV=:N_CUST_LEV,");
            strSql.Append("C_CRECEIPTCUSTOMERID=:C_CRECEIPTCUSTOMERID,");
            strSql.Append("C_ADDRESS=:C_ADDRESS,");
            strSql.Append("C_CRECEIPTAREAID=:C_CRECEIPTAREAID,");
            strSql.Append("C_CRECEIPTCORPID=:C_CRECEIPTCORPID,");
            strSql.Append("C_STATION=:C_STATION,");
            strSql.Append("C_REAMRK=:C_REAMRK,");
            strSql.Append("D_CHANGEDATE=:D_CHANGEDATE,");
            strSql.Append("D_NEED_DT=:D_NEED_DT,");
            strSql.Append("C_NC_STATE=:C_NC_STATE,");
            strSql.Append("C_CHANGEEMPID=:C_CHANGEEMPID,");
            strSql.Append("N_CHANGENUM=:N_CHANGENUM,");
            strSql.Append("C_RECEIPTCODE=:C_RECEIPTCODE");
            strSql.Append(" where C_CON_NO=:C_CON_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CONTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTNAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COPERATORID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DMAKEDATE", OracleDbType.Date),
                    new OracleParameter(":C_CURRENCYTYPEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CONSING_DT", OracleDbType.Date),
                    new OracleParameter(":D_CONEFFE_DT", OracleDbType.Date),
                    new OracleParameter(":D_CONINVALID_DT", OracleDbType.Date),
                    new OracleParameter(":C_TRANSMODEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALECORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BIZTYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPTID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EDITEMPLOYEEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_EDITDATE", OracleDbType.Date),
                    new OracleParameter(":C_APPROVEID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVEDATE", OracleDbType.Date),
                    new OracleParameter(":C_FLOWID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XGID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_CUST_LEV", OracleDbType.Decimal,1),
                    new OracleParameter(":C_CRECEIPTCUSTOMERID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDRESS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CRECEIPTAREAID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CRECEIPTCORPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REAMRK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_CHANGEDATE", OracleDbType.Date),
                    new OracleParameter(":D_NEED_DT", OracleDbType.Date),
                    new OracleParameter(":C_NC_STATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CHANGEEMPID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_CHANGENUM", OracleDbType.Decimal,2),
                    new OracleParameter(":C_RECEIPTCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_CON_NAME;
            parameters[1].Value = model.C_CONTYPEID;
            parameters[2].Value = model.C_CUSTOMERID;
            parameters[3].Value = model.C_CUSTNAME;
            parameters[4].Value = model.C_COPERATORID;
            parameters[5].Value = model.D_DMAKEDATE;
            parameters[6].Value = model.C_CURRENCYTYPEID;
            parameters[7].Value = model.D_CONSING_DT;
            parameters[8].Value = model.D_CONEFFE_DT;
            parameters[9].Value = model.D_CONINVALID_DT;
            parameters[10].Value = model.C_TRANSMODEID;
            parameters[11].Value = model.C_AREA;
            parameters[12].Value = model.N_STATUS;
            parameters[13].Value = model.N_FLAG;
            parameters[14].Value = model.C_SALECORPID;
            parameters[15].Value = model.C_BIZTYPE;
            parameters[16].Value = model.C_DEPTID;
            parameters[17].Value = model.C_EMPLOYEEID;
            parameters[18].Value = model.C_EDITEMPLOYEEID;
            parameters[19].Value = model.D_EDITDATE;
            parameters[20].Value = model.C_APPROVEID;
            parameters[21].Value = model.D_APPROVEDATE;
            parameters[22].Value = model.C_FLOWID;
            parameters[23].Value = model.C_XGID;
            parameters[24].Value = model.C_EMP_ID;
            parameters[25].Value = model.C_EMP_NAME;
            parameters[26].Value = model.D_MOD_DT;
            parameters[27].Value = model.N_CUST_LEV;
            parameters[28].Value = model.C_CRECEIPTCUSTOMERID;
            parameters[29].Value = model.C_ADDRESS;
            parameters[30].Value = model.C_CRECEIPTAREAID;
            parameters[31].Value = model.C_CRECEIPTCORPID;
            parameters[32].Value = model.C_STATION;
            parameters[33].Value = model.C_REAMRK;
            parameters[34].Value = model.D_CHANGEDATE;
            parameters[35].Value = model.D_NEED_DT;
            parameters[36].Value = model.C_NC_STATE;
            parameters[37].Value = model.C_CHANGEEMPID;
            parameters[38].Value = model.N_CHANGENUM;
            parameters[39].Value = model.C_RECEIPTCODE;
            parameters[40].Value = model.C_CON_NO;

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
        public bool Delete(string C_CON_NO)
        {


            ArrayList arraySql = new ArrayList();
            string strSql = $@"delete from TMO_CON where C_CON_NO='{C_CON_NO}' AND N_STATUS=0";
            string strSql2 = $@"delete from TMO_CON_ORDER where C_CON_NO='{C_CON_NO}' AND N_STATUS=0";

            arraySql.Add(strSql);
            arraySql.Add(strSql2);

            return DbHelperOra.ExecuteSqlTran(arraySql);

        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_CON_NOlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMO_CON ");
            strSql.Append(" where C_CON_NO in (" + C_CON_NOlist + ")  ");
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
        public Mod_TMO_CON GetModel(string C_CON_NO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select C_CON_NO,
       C_CON_NAME,
       C_CONTYPEID,
       (select t.c_detailname from ts_dic t where t.c_id = C_CONTYPEID) as C_CONTYPE,
       C_CUSTOMERID,
       C_CUSTNAME,
       C_CUST_NO,
       C_COPERATORID,
       D_DMAKEDATE,
       C_CURRENCYTYPEID,
       (select t.c_detailname from ts_dic t where t.c_id = C_CURRENCYTYPEID) as C_CURRENCYTYPE,
       D_CONSING_DT,
       D_CONEFFE_DT,
       D_CONINVALID_DT,
       C_TRANSMODEID,
       (select t.c_detailname from ts_dic t where t.c_id = C_TRANSMODEID) as C_TRANSMODE,
       C_AREA,
       N_STATUS,
       N_FLAG,
       (select t.c_detailname from ts_dic t where t.c_id = N_FLAG) as CLASSNAME,
       C_SALECORPID,
       (select t.c_detailname from ts_dic t where t.c_id = C_SALECORPID) as C_SALECORP,
       C_BIZTYPE,
       (select t.c_detailname from ts_dic t where t.c_id = C_BIZTYPE) as C_BIZTYPENAME,
       C_DEPTID,
       (select t.C_NAME from ts_dept t where t.C_ID=C_DEPTID ) as C_DEPT,
       C_EMPLOYEEID,
       (select t.C_NAME from TS_SALE_EMP t where t.C_ID = C_EMPLOYEEID) as C_EMPLOYEE,
       C_EDITEMPLOYEEID,
       D_EDITDATE,
       C_APPROVEID,
       D_APPROVEDATE,
       C_FLOWID,
       C_XGID,
       C_EMP_ID,
       C_EMP_NAME,
       D_MOD_DT,
       N_CUST_LEV,
       C_CRECEIPTCUSTOMERID,
       (select a.c_name
          from ts_custfile a
         where a.c_nc_m_id = C_CRECEIPTCUSTOMERID) as C_CRECEIPTCUSTOMER,
       C_ADDRESS,
       C_CRECEIPTAREAID,
       C_CRECEIPTCORPID,
       (select a.c_name
          from ts_custfile a
         where a.c_nc_m_id = C_CRECEIPTCORPID) as C_CRECEIPTCORP,
       C_STATION,
       C_REAMRK,
       D_CHANGEDATE,
       D_NEED_DT,
       C_NC_STATE,
       C_CHANGEEMPID,
       N_CHANGENUM,
       C_RECEIPTCODE,
       C_CON_NO_OLD
  from TMO_CON
");
            strSql.Append(" where C_CON_NO=:C_CON_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100)};
            parameters[0].Value = C_CON_NO;

            Mod_TMO_CON model = new Mod_TMO_CON();
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
        public Mod_TMO_CON DataRowToModel(DataRow row)
        {
            Mod_TMO_CON model = new Mod_TMO_CON();
            if (row != null)
            {

                #region //自定义
                if (row["C_EMPLOYEE"] != null)
                {
                    model.C_EMPLOYEE = row["C_EMPLOYEE"].ToString();
                }
                if (row["C_CONTYPE"] != null)
                {
                    model.C_CONTYPE = row["C_CONTYPE"].ToString();
                }
                if (row["C_CURRENCYTYPE"] != null)
                {
                    model.C_CURRENCYTYPE = row["C_CURRENCYTYPE"].ToString();
                }
                if (row["C_TRANSMODE"] != null)
                {
                    model.C_TRANSMODE = row["C_TRANSMODE"].ToString();
                }
                if (row["C_CRECEIPTCUSTOMER"] != null)
                {
                    model.C_CRECEIPTCUSTOMER = row["C_CRECEIPTCUSTOMER"].ToString();
                }
                if (row["C_CRECEIPTCORP"] != null)
                {
                    model.C_CRECEIPTCORP = row["C_CRECEIPTCORP"].ToString();
                }

                if (row["C_BIZTYPENAME"] != null)//业务类型
                {
                    model.C_BIZTYPENAME = row["C_BIZTYPENAME"].ToString();
                }
                if (row["CLASSNAME"] != null)//合同分类
                {
                    model.CLASSNAME = row["CLASSNAME"].ToString();
                }
                if (row["C_SALECORP"] != null)//销售组织
                {
                    model.C_SALECORP = row["C_SALECORP"].ToString();
                }
                if (row["C_DEPT"] != null)//部门
                {
                    model.C_DEPT = row["C_DEPT"].ToString();
                }

                #endregion

                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["C_CON_NO_OLD"] != null)
                {
                    model.C_CON_NO_OLD = row["C_CON_NO_OLD"].ToString();
                }
                if (row["C_CON_NAME"] != null)
                {
                    model.C_CON_NAME = row["C_CON_NAME"].ToString();
                }
                if (row["C_CONTYPEID"] != null)
                {
                    model.C_CONTYPEID = row["C_CONTYPEID"].ToString();
                }
                if (row["C_CUSTOMERID"] != null)
                {
                    model.C_CUSTOMERID = row["C_CUSTOMERID"].ToString();
                }
                if (row["C_CUSTNAME"] != null)
                {
                    model.C_CUSTNAME = row["C_CUSTNAME"].ToString();
                }
                if (row["C_CUST_NO"] != null)
                {
                    model.C_CUST_NO = row["C_CUST_NO"].ToString();
                }
                if (row["C_COPERATORID"] != null)
                {
                    model.C_COPERATORID = row["C_COPERATORID"].ToString();
                }
                if (row["D_DMAKEDATE"] != null && row["D_DMAKEDATE"].ToString() != "")
                {
                    model.D_DMAKEDATE = DateTime.Parse(row["D_DMAKEDATE"].ToString());
                }
                if (row["C_CURRENCYTYPEID"] != null)
                {
                    model.C_CURRENCYTYPEID = row["C_CURRENCYTYPEID"].ToString();
                }
                if (row["D_CONSING_DT"] != null && row["D_CONSING_DT"].ToString() != "")
                {
                    model.D_CONSING_DT = DateTime.Parse(row["D_CONSING_DT"].ToString());
                }
                if (row["D_CONEFFE_DT"] != null && row["D_CONEFFE_DT"].ToString() != "")
                {
                    model.D_CONEFFE_DT = DateTime.Parse(row["D_CONEFFE_DT"].ToString());
                }
                if (row["D_CONINVALID_DT"] != null && row["D_CONINVALID_DT"].ToString() != "")
                {
                    model.D_CONINVALID_DT = DateTime.Parse(row["D_CONINVALID_DT"].ToString());
                }
                if (row["C_TRANSMODEID"] != null)
                {
                    model.C_TRANSMODEID = row["C_TRANSMODEID"].ToString();
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_FLAG"] != null)
                {
                    model.N_FLAG = row["N_FLAG"].ToString();
                }
                if (row["C_SALECORPID"] != null)
                {
                    model.C_SALECORPID = row["C_SALECORPID"].ToString();
                }
                if (row["C_BIZTYPE"] != null)
                {
                    model.C_BIZTYPE = row["C_BIZTYPE"].ToString();
                }
                if (row["C_DEPTID"] != null)
                {
                    model.C_DEPTID = row["C_DEPTID"].ToString();
                }
                if (row["C_EMPLOYEEID"] != null)
                {
                    model.C_EMPLOYEEID = row["C_EMPLOYEEID"].ToString();
                }
                if (row["C_EDITEMPLOYEEID"] != null)
                {
                    model.C_EDITEMPLOYEEID = row["C_EDITEMPLOYEEID"].ToString();
                }
                if (row["D_EDITDATE"] != null && row["D_EDITDATE"].ToString() != "")
                {
                    model.D_EDITDATE = DateTime.Parse(row["D_EDITDATE"].ToString());
                }
                if (row["C_APPROVEID"] != null)
                {
                    model.C_APPROVEID = row["C_APPROVEID"].ToString();
                }
                if (row["D_APPROVEDATE"] != null && row["D_APPROVEDATE"].ToString() != "")
                {
                    model.D_APPROVEDATE = DateTime.Parse(row["D_APPROVEDATE"].ToString());
                }
                if (row["C_FLOWID"] != null)
                {
                    model.C_FLOWID = row["C_FLOWID"].ToString();
                }
                if (row["C_XGID"] != null)
                {
                    model.C_XGID = row["C_XGID"].ToString();
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
                if (row["N_CUST_LEV"] != null && row["N_CUST_LEV"].ToString() != "")
                {
                    model.N_CUST_LEV = decimal.Parse(row["N_CUST_LEV"].ToString());
                }
                if (row["C_CRECEIPTCUSTOMERID"] != null)
                {
                    model.C_CRECEIPTCUSTOMERID = row["C_CRECEIPTCUSTOMERID"].ToString();
                }
                if (row["C_ADDRESS"] != null)
                {
                    model.C_ADDRESS = row["C_ADDRESS"].ToString();
                }
                if (row["C_CRECEIPTAREAID"] != null)
                {
                    model.C_CRECEIPTAREAID = row["C_CRECEIPTAREAID"].ToString();
                }
                if (row["C_CRECEIPTCORPID"] != null)
                {
                    model.C_CRECEIPTCORPID = row["C_CRECEIPTCORPID"].ToString();
                }
                if (row["C_STATION"] != null)
                {
                    model.C_STATION = row["C_STATION"].ToString();
                }
                if (row["C_REAMRK"] != null)
                {
                    model.C_REAMRK = row["C_REAMRK"].ToString();
                }
                if (row["D_CHANGEDATE"] != null && row["D_CHANGEDATE"].ToString() != "")
                {
                    model.D_CHANGEDATE = DateTime.Parse(row["D_CHANGEDATE"].ToString());
                }
                if (row["D_NEED_DT"] != null && row["D_NEED_DT"].ToString() != "")
                {
                    model.D_NEED_DT = DateTime.Parse(row["D_NEED_DT"].ToString());
                }
                if (row["C_NC_STATE"] != null)
                {
                    model.C_NC_STATE = row["C_NC_STATE"].ToString();
                }
                if (row["C_CHANGEEMPID"] != null)
                {
                    model.C_CHANGEEMPID = row["C_CHANGEEMPID"].ToString();
                }
                if (row["N_CHANGENUM"] != null && row["N_CHANGENUM"].ToString() != "")
                {
                    model.N_CHANGENUM = decimal.Parse(row["N_CHANGENUM"].ToString());
                }
                if (row["C_RECEIPTCODE"] != null)
                {
                    model.C_RECEIPTCODE = row["C_RECEIPTCODE"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetConList(string C_EMP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_COPERATORID,D_DMAKEDATE,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,N_FLAG,C_SALECORPID,C_BIZTYPE,C_DEPTID,C_EMPLOYEEID,C_EDITEMPLOYEEID,D_EDITDATE,C_APPROVEID,D_APPROVEDATE,C_FLOWID,C_XGID,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_CHANGEDATE,D_NEED_DT,C_NC_STATE,C_CHANGEEMPID,N_CHANGENUM,C_RECEIPTCODE,C_CUST_NO  ");
            strSql.Append(" FROM TMO_CON  where 1=1");
            if (!string.IsNullOrEmpty(C_EMP_ID))
            {
                strSql.Append(" and C_EMP_ID='" + C_EMP_ID + "'");
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_COPERATORID,D_DMAKEDATE,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,N_FLAG,C_SALECORPID,C_BIZTYPE,C_DEPTID,C_EMPLOYEEID,C_EDITEMPLOYEEID,D_EDITDATE,C_APPROVEID,D_APPROVEDATE,C_FLOWID,C_XGID,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_CHANGEDATE,D_NEED_DT,C_NC_STATE,C_CHANGEEMPID,N_CHANGENUM,C_RECEIPTCODE,C_CUST_NO  ");
            strSql.Append(" FROM TMO_CON ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        ///  获取记录总数
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public int GetRecordCount2(string con_no, string con_name, string start, string end, string type, string state, string custname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMO_CON where 1=1 ");

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.Append("and C_CUSTNAME like '%" + custname + "%'");
            }
            if (!string.IsNullOrEmpty(con_no))
            {
                strSql.Append("and C_CON_NO = '" + con_no + "'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                strSql.Append("and C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append("and C_AREA = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append("and N_STATUS = '" + state + "'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {

                strSql.Append(" and D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            strSql.Append(" and N_STATUS !=-1");

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
        ///  获取记录总数
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="emp_id">用户ID</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public int GetRecordCount(string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMO_CON where 1=1 ");

            if (!string.IsNullOrEmpty(con_no))
            {
                strSql.Append("and C_CON_NO = '" + con_no + "'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                strSql.Append("and C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(emp_id))
            {
                strSql.Append("and C_EMP_ID = '" + emp_id + "'");
            }

            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append("and C_CONTYPEID = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append("and N_STATUS = " + state + "");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        public DataSet GetListByPage3(string con_no, string con_name, string start, string end, string type, string state, string custname, string custcode)
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@"SELECT *
  FROM (SELECT C_CON_NO,
               C_CON_NAME,
               C_CONTYPEID,
               C_CUSTOMERID,
               C_CUSTNAME,
               C_COPERATORID,
               D_DMAKEDATE,
               C_CURRENCYTYPEID,
               D_CONSING_DT,
               D_CONEFFE_DT,
               D_CONINVALID_DT,
               C_TRANSMODEID,
               C_AREA,
               N_STATUS,
               N_FLAG,
               C_SALECORPID,
               C_BIZTYPE,
               C_DEPTID,
               C_EMPLOYEEID,
               C_EDITEMPLOYEEID,
               D_EDITDATE,
               C_APPROVEID,
               D_APPROVEDATE,
               C_FLOWID,
               C_XGID,
               C_EMP_ID,
               C_EMP_NAME,
               D_MOD_DT,
               N_CUST_LEV,
               C_CRECEIPTCUSTOMERID,
               C_ADDRESS,
               C_CRECEIPTAREAID,
               C_CRECEIPTCORPID,
               C_STATION,
               C_REAMRK,
               D_CHANGEDATE,
               D_NEED_DT,
               C_NC_STATE,
               C_CHANGEEMPID,
               N_CHANGENUM,
               C_RECEIPTCODE,
               C_CON_NO_OLD,
               C_CUST_NO
          FROM TMO_CON) T1
  LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, T.C_CON_NO,T.N_STATUS
               FROM TMO_CON_ORDER T
              GROUP BY T.C_CON_NO,T.N_STATUS) T2
    ON T2.C_CON_NO = T1.C_CON_NO
 where 1 = 1
");

            if (!string.IsNullOrEmpty(custcode))
            {
                where.Append("and T1.C_CUST_NO ='" + custcode + "'");
            }

            if (!string.IsNullOrEmpty(custname))
            {
                where.Append("and T1.C_CUSTNAME like '%" + custname + "%'");
            }
            if (!string.IsNullOrEmpty(con_no))
            {
                where.Append("and T1.C_CON_NO  like '%" + con_no + "%'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                where.Append("and T1.C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(type))
            {
                where.Append("and T1.C_AREA = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                where.Append("and T1.N_STATUS = " + state + "");
            }
            //if (!string.IsNullOrEmpty(state))
            //{
            //    where.Append("and T2.N_STATUS = " + state + "");
            //}
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and T1.D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            where.Append(" and T1.N_STATUS !=-1");

            where.Append(" ORDER BY  T1.D_CONSING_DT desc");

            return DbHelperOra.Query(where.ToString());

        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage2(int pageSize, int startIndex, string con_no, string con_name, string start, string end, string type, string state, string custname)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_COPERATORID,D_DMAKEDATE,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,N_FLAG,C_SALECORPID,C_BIZTYPE,C_DEPTID,C_EMPLOYEEID,C_EDITEMPLOYEEID,D_EDITDATE,C_APPROVEID,D_APPROVEDATE,C_FLOWID,C_XGID,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_CHANGEDATE,D_NEED_DT,C_NC_STATE,C_CHANGEEMPID,N_CHANGENUM,C_RECEIPTCODE,C_CON_NO_OLD,C_CUST_NO  ";
            string table = "TMO_CON";
            string order = " D_CONSING_DT desc";


            if (!string.IsNullOrEmpty(custname))
            {
                where.Append("and C_CUSTNAME like '%" + custname + "%'");
            }
            if (!string.IsNullOrEmpty(con_no))
            {
                where.Append("and C_CON_NO = '" + con_no + "'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                where.Append("and C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(type))
            {
                where.Append("and C_AREA = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                where.Append("and N_STATUS = " + state + "");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            where.Append(" and N_STATUS !=-1");

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int pageSize, int startIndex, string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_COPERATORID,D_DMAKEDATE,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,N_FLAG,C_SALECORPID,C_BIZTYPE,C_DEPTID,C_EMPLOYEEID,C_EDITEMPLOYEEID,D_EDITDATE,C_APPROVEID,D_APPROVEDATE,C_FLOWID,C_XGID,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_CHANGEDATE,D_NEED_DT,C_NC_STATE,C_CHANGEEMPID,N_CHANGENUM,C_RECEIPTCODE,C_CON_NO_OLD,C_CUST_NO ";
            string table = "TMO_CON";
            string order = " D_CONSING_DT desc";



            if (!string.IsNullOrEmpty(con_no))
            {
                where.Append("and C_CON_NO = '" + con_no + "'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                where.Append("and C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(emp_id))
            {
                where.Append("and C_EMP_ID = '" + emp_id + "'");
            }

            if (!string.IsNullOrEmpty(type))
            {
                where.Append("and C_CONTYPEID = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                where.Append("and N_STATUS = '" + state + "'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                where.Append(" and D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        /// <summary>
        /// 获取客户原始合同列表
        /// </summary>
        /// <param name="con_no">合同号</param>
        /// <param name="con_name">合同名称</param>
        /// <param name="start">签署开始时间</param>
        /// <param name="end">签署结束时间</param>
        /// <param name="emp_id">操作人</param>
        /// <param name="type">合同类型</param>
        /// <param name="state">合同状态</param>
        /// <returns></returns>
        public DataSet GetConList(string con_no, string con_name, string start, string end, string emp_id, string type, string state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"WITH T1 AS
 (SELECT INSTR(T.C_CON_NO, '-', 1, 3) LEN, T.* FROM TMO_CON T),
T2 AS
 (SELECT CASE TT.LEN
           WHEN 0 THEN
            TT.C_CON_NO
           ELSE
            SUBSTR(TT.C_CON_NO, 0, TT.LEN - 1)
         END AS OLDCONNO,
         TT.*
    FROM T1 TT)
SELECT *
  FROM T2
  LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, T.C_CON_NO
               FROM TMO_CON_ORDER T
              GROUP BY T.C_CON_NO) T3
    ON T3.C_CON_NO = T2.C_CON_NO
 WHERE (T2.OLDCONNO, T2.D_CONSING_DT) IN
       (SELECT T2.OLDCONNO, MAX(T2.D_CONSING_DT)
          FROM T2
         GROUP BY T2.OLDCONNO) ");

            if (!string.IsNullOrEmpty(con_no))
            {
                strSql.Append("and T2.OLDCONNO like  '%" + con_no + "%'");
            }
            if (!string.IsNullOrEmpty(con_name))
            {
                strSql.Append("and T2.C_CON_NAME like '%" + con_name + "%'");
            }
            if (!string.IsNullOrEmpty(emp_id))
            {
                strSql.Append("and T2.C_EMP_ID = '" + emp_id + "'");
            }

            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append("and T2.C_CONTYPEID = '" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append("and T2.N_STATUS = '" + state + "'");
            }

            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                strSql.Append(" and T2.D_CONSING_DT between to_date('" + start + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }

            strSql.Append(" ORDER BY  T2.D_CONSING_DT DESC ");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取客户原始合同变更记录
        /// </summary>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public DataSet GetConListSub(string conNO)
        {
            string strSql = string.Format(@"SELECT TT.C_CON_NO,
       TT.C_CON_NAME,
       T2.N_WGT,
       TT.N_STATUS,
       TT.D_CONSING_DT,
       TT.D_CONEFFE_DT,
       TT.D_CONINVALID_DT,
       TT.C_CURRENCYTYPEID,
       TT.C_CONTYPEID,
       TT.C_TRANSMODEID,
       TT.C_CON_NO_OLD
             FROM TMO_CON TT
 LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, T.C_CON_NO
               FROM TMO_CON_ORDER T
              GROUP BY T.C_CON_NO) T2
    ON T2.C_CON_NO = TT.C_CON_NO  
            WHERE TT.C_CON_NO LIKE '%{0}%'
            ORDER BY TT.N_CHANGENUM DESC", conNO);
            return DbHelperOra.Query(strSql);
        }

        #endregion  BasicMethod

        #region  自定义方法

        #region//插入合同与多条合同明细

        /// <summary>
        /// 判断是否监控钢种
        /// </summary>
        public bool Exists_MOIN_STLGRD(string stlgrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_MONI_STLGRD");
            strSql.Append(" where C_STL_GRD=:C_STL_GRD ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100)         };
            parameters[0].Value = stlgrd;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 插入合同与多条合同明细
        /// </summary>
        /// <param name="modCon"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertConOrder(Mod_TMO_CON modCon, List<Mod_TMO_ORDER> orderList)
        {
            ArrayList arraySql = new ArrayList();

            #region  //合同
            if (modCon != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMO_CON(");
                strSql.Append("C_CON_NO,C_CON_NAME,C_CONTYPEID,C_CUSTOMERID,C_CUSTNAME,C_CURRENCYTYPEID,D_CONSING_DT,D_CONEFFE_DT,D_CONINVALID_DT,C_TRANSMODEID,C_AREA,N_STATUS,C_DEPTID,C_EMPLOYEEID,C_EMP_ID,C_EMP_NAME,N_CUST_LEV,C_CRECEIPTCUSTOMERID,C_ADDRESS,C_CRECEIPTAREAID,C_CRECEIPTCORPID,C_STATION,C_REAMRK,D_NEED_DT,C_CON_NO_OLD,N_CHANGENUM,C_CUST_NO,C_CON_XH)");
                strSql.Append(" values (");
                strSql.Append("'" + modCon.C_CON_NO + "','" + modCon.C_CON_NAME + "','" + modCon.C_CONTYPEID + "','" + modCon.C_CUSTOMERID + "','" + modCon.C_CUSTNAME + "','" + modCon.C_CURRENCYTYPEID + "',to_date('" + Convert.ToDateTime(modCon.D_CONSING_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),to_date('" + Convert.ToDateTime(modCon.D_CONEFFE_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),to_date('" + Convert.ToDateTime(modCon.D_CONINVALID_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),'" + modCon.C_TRANSMODEID + "','" + modCon.C_AREA + "'," + modCon.N_STATUS + ",'" + modCon.C_DEPTID + "','" + modCon.C_EMPLOYEEID + "','" + modCon.C_EMP_ID + "','" + modCon.C_EMP_NAME + "'," + modCon.N_CUST_LEV + ",'" + modCon.C_CRECEIPTCUSTOMERID + "','" + modCon.C_ADDRESS + "','" + modCon.C_CRECEIPTAREAID + "','" + modCon.C_CRECEIPTCORPID + "','" + modCon.C_STATION + "','" + modCon.C_REAMRK + "',to_date('" + Convert.ToDateTime(modCon.D_NEED_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),'" + modCon.C_CON_NO_OLD + "'," + modCon.N_CHANGENUM + ",'" + modCon.C_CUST_NO + "','" + modCon.C_CON_XH + "')");
                arraySql.Add(strSql.ToString());
            }
            #endregion

            for (int i = 0; i < orderList.Count; i++)
            {
                string C_SFJK = Exists_MOIN_STLGRD(orderList[i].C_STL_GRD) == true ? "Y" : "N";//监控钢种

                #region //合同订单
                string orderID = Guid.NewGuid().ToString("N");//订单主键ID
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into TMO_CON_ORDER(");
                strSql2.Append("C_ID,");//订单主键ID
                strSql2.Append("C_ORDER_NO,");//订单号
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_CON_NAME,");//合同名称
                strSql2.Append("C_AREA,");//合同区域
                strSql2.Append("C_INVBASDOCID,");//存货档案主键
                strSql2.Append("C_INVENTORYID,");//存货管理档案主键
                strSql2.Append("C_PROD_NAME,");//品名
                strSql2.Append("C_PROD_KIND,");//品种
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_FUNITID,");//辅单位
                strSql2.Append("C_UNITID,");//主计量单位
                //strSql2.Append("D_NEED_DT,");//需求日期
                strSql2.Append("D_DELIVERY_DT,");//计划收货日期
                strSql2.Append("D_DT,");//订单日期//签单日期
                strSql2.Append("C_TECH_PROT,");//客户协议号
                strSql2.Append("C_PRO_USE,");//产品用途
                strSql2.Append("C_FREE1,");//自由项1
                strSql2.Append("C_FREE2,");//自由项2
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("C_DESIGN_NO,");//质量设计号
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("N_TAXRATE,");//税率
                strSql2.Append("N_ORIGINALCURPRICE,");//原币无税单价
                strSql2.Append("N_ORIGINALCURTAXPRICE,");//原币含税单价
                strSql2.Append("N_ORIGINALCURTAXMNY,");//原币税额
                strSql2.Append("N_ORIGINALCURMNY,");//原币无税金额
                strSql2.Append("N_ORIGINALCURSUMMNY,");//原币价税合计
                strSql2.Append("N_WGT,");//数量
                strSql2.Append("N_HSL,");//换算率
                strSql2.Append("N_FNUM,");//辅数量
                strSql2.Append("C_RECEIPTAREAID,");//收货地区
                strSql2.Append("C_RECEIVEADDRESS,");//收货地址
                strSql2.Append("C_RECEIPTCORPID,");//收货单位
                strSql2.Append("C_CURRENCYTYPEID,");//货币
                strSql2.Append("N_TYPE,");//线材类型
                strSql2.Append("N_USER_LEV,");//客户等级
                strSql2.Append("C_REMARK,");
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_CUST_NO,");
                strSql2.Append("C_CUST_NAME,");
                strSql2.Append("C_SALE_CHANNEL,");//分销类型
                strSql2.Append("C_LEV,");//钢种等级
                strSql2.Append("C_ORDER_LEV,");//订单等级
                strSql2.Append("N_COST,");//成本
                strSql2.Append("C_VDEF1,");//质量等级
                strSql2.Append("C_TRANSMODE,");//发运方式
                strSql2.Append("C_TRANSMODEID,");//发运方式ID
                strSql2.Append("C_BY4,");//是否不锈钢
                strSql2.Append("C_YWY,");//业务员姓名
                strSql2.Append("C_CUST_SQ,");//客户要求
                strSql2.Append("C_SFPJ,");//订单是否评价
                strSql2.Append("N_STATUS,");//订单状态
                strSql2.Append("C_ORDER_NO_OLD,");//原始合同订单号
                strSql2.Append("C_SFJK");//监控钢种
                strSql2.Append(")");
                strSql2.Append(" values (");
                strSql2.Append("'" + orderID + "',");//订单主键ID
                strSql2.Append("'" + orderList[i].C_ORDER_NO + "',");//订单号
                strSql2.Append("'" + orderList[i].C_CON_NO + "',");//合同号
                strSql2.Append("'" + orderList[i].C_CON_NAME + "',");//合同名称
                strSql2.Append("'" + orderList[i].C_AREA + "',");//合同区域
                strSql2.Append("'" + orderList[i].C_INVBASDOCID + "',");//存货档案主键
                strSql2.Append("'" + orderList[i].C_INVENTORYID + "',");//存货管理档案主键
                strSql2.Append("'" + orderList[i].C_PROD_NAME + "',");//品名
                strSql2.Append("'" + orderList[i].C_PROD_KIND + "',");//品种
                strSql2.Append("'" + orderList[i].C_MAT_CODE + "',");//物料编码
                strSql2.Append("'" + orderList[i].C_MAT_NAME + "',");//物料名称
                strSql2.Append("'" + orderList[i].C_SPEC + "',");//规格
                strSql2.Append("'" + orderList[i].C_STL_GRD + "',");//钢种
                strSql2.Append("'" + orderList[i].C_FUNITID + "',");//辅单位
                strSql2.Append("'" + orderList[i].C_UNITID + "',");//主计量单位
                //strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_NEED_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//需求日期
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DELIVERY_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//计划收货日期
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//订单日期//签单日期
                strSql2.Append("'" + orderList[i].C_TECH_PROT + "',");//客户协议号
                strSql2.Append("'" + orderList[i].C_PRO_USE + "',");//产品用途
                strSql2.Append("'" + orderList[i].C_FREE1 + "',");//自由项1
                strSql2.Append("'" + orderList[i].C_FREE2 + "',");//自由项2
                strSql2.Append("'" + orderList[i].C_STD_CODE + "',");//执行标准
                strSql2.Append("'" + orderList[i].C_DESIGN_NO + "',");//质量设计号
                strSql2.Append("'" + orderList[i].C_PACK + "',");//包装要求
                strSql2.Append("" + orderList[i].N_TAXRATE + ",");//税率
                strSql2.Append("" + orderList[i].N_ORIGINALCURPRICE + ",");//原币无税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXPRICE + ",");//原币含税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXMNY + ",");//原币税额
                strSql2.Append("" + orderList[i].N_ORIGINALCURMNY + ",");//原币无税金额
                strSql2.Append("" + orderList[i].N_ORIGINALCURSUMMNY + ",");//原币价税合计
                strSql2.Append("" + orderList[i].N_WGT + ",");//数量
                strSql2.Append("" + orderList[i].N_HSL + ",");//换算率
                strSql2.Append("" + orderList[i].N_FNUM + ",");//辅数量
                strSql2.Append("'" + orderList[i].C_RECEIPTAREAID + "',");//收货地区
                strSql2.Append("'" + orderList[i].C_RECEIVEADDRESS + "',");//收货地址
                strSql2.Append("'" + orderList[i].C_RECEIPTCORPID + "',");//收货单位
                strSql2.Append("'" + orderList[i].C_CURRENCYTYPEID + "',");//货币
                strSql2.Append("" + orderList[i].N_TYPE + ",");//线材类型
                strSql2.Append("" + orderList[i].N_USER_LEV + ",");//客户等级
                strSql2.Append("'" + orderList[i].C_REMARK + "',");
                strSql2.Append("'" + orderList[i].C_EMP_ID + "',");
                strSql2.Append("'" + orderList[i].C_EMP_NAME + "',");
                strSql2.Append("'" + orderList[i].C_CUST_NO + "',");//客户编码
                strSql2.Append("'" + orderList[i].C_CUST_NAME + "',");//客户名称
                strSql2.Append("'" + orderList[i].C_SALE_CHANNEL + "',");//分销类型
                strSql2.Append("'" + orderList[i].C_LEV + "',");//钢种等级
                strSql2.Append("'" + orderList[i].C_ORDER_LEV + "',");//订单等级
                strSql2.Append("" + orderList[i].N_COST + ",");//成本
                strSql2.Append("'" + orderList[i].C_VDEF1 + "',");//质量等级
                strSql2.Append("'" + orderList[i].C_TRANSMODE + "',");//发运方式
                strSql2.Append("'" + orderList[i].C_TRANSMODEID + "',");//发运方式主键
                strSql2.Append("'" + orderList[i].C_BY4 + "',");//是否不锈钢
                strSql2.Append("'" + orderList[i].C_YWY + "',");//业务员姓名
                strSql2.Append("'" + orderList[i].C_CUST_SQ + "',");//客户要求
                strSql2.Append("'" + orderList[i].C_SFPJ + "',");//订单是否评价
                strSql2.Append("'" + orderList[i].N_STATUS + "',");//状态
                strSql2.Append("'" + orderList[i].C_ORDER_NO_OLD + "',");//原始合同订单号
                strSql2.Append("'" + C_SFJK + "'");//监控钢种

                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
                #endregion
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //插入正常订单
        /// <summary>
        /// 插入订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertFirstOrder(List<Mod_TMO_ORDER> orderList)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < orderList.Count; i++)
            {

                string C_SFJK = Exists_MOIN_STLGRD(orderList[i].C_STL_GRD) == true ? "Y" : "N";//监控钢种


                #region //合同订单
                string orderID = Guid.NewGuid().ToString("N");//订单主键ID
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into TMO_CON_ORDER(");
                strSql2.Append("C_ID,");//订单主键ID
                strSql2.Append("C_ORDER_NO,");//订单号
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_CON_NAME,");//合同名称
                strSql2.Append("C_AREA,");//合同区域
                strSql2.Append("C_INVBASDOCID,");//存货档案主键
                strSql2.Append("C_INVENTORYID,");//存货管理档案主键
                strSql2.Append("C_PROD_NAME,");//品名
                strSql2.Append("C_PROD_KIND,");//品种
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_FUNITID,");//辅单位
                strSql2.Append("C_UNITID,");//主计量单位
                //strSql2.Append("D_NEED_DT,");//需求日期
                strSql2.Append("D_DELIVERY_DT,");//计划收货日期
                strSql2.Append("D_DT,");//订单日期//签单日期
                strSql2.Append("C_TECH_PROT,");//客户协议号
                strSql2.Append("C_PRO_USE,");//产品用途
                strSql2.Append("C_FREE1,");//自由项1
                strSql2.Append("C_FREE2,");//自由项2
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("C_DESIGN_NO,");//质量设计号
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("N_TAXRATE,");//税率
                strSql2.Append("N_ORIGINALCURPRICE,");//原币无税单价
                strSql2.Append("N_ORIGINALCURTAXPRICE,");//原币含税单价
                strSql2.Append("N_ORIGINALCURTAXMNY,");//原币税额
                strSql2.Append("N_ORIGINALCURMNY,");//原币无税金额
                strSql2.Append("N_ORIGINALCURSUMMNY,");//原币价税合计
                strSql2.Append("N_WGT,");//数量
                strSql2.Append("N_HSL,");//换算率
                strSql2.Append("N_FNUM,");//辅数量
                strSql2.Append("C_RECEIPTAREAID,");//收货地区
                strSql2.Append("C_RECEIVEADDRESS,");//收货地址
                strSql2.Append("C_RECEIPTCORPID,");//收货单位
                strSql2.Append("C_CURRENCYTYPEID,");//货币
                strSql2.Append("N_TYPE,");//线材类型
                strSql2.Append("N_USER_LEV,");//客户等级
                strSql2.Append("C_REMARK,");
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_CUST_NO,");
                strSql2.Append("C_CUST_NAME,");
                strSql2.Append("C_SALE_CHANNEL,");//分销类型
                strSql2.Append("C_LEV,");//钢种等级
                strSql2.Append("C_ORDER_LEV,");//订单等级
                strSql2.Append("C_BY4,");//是否不锈钢
                strSql2.Append("N_COST,");//成本
                strSql2.Append("C_VDEF1,");//质量等级
                strSql2.Append("C_TRANSMODE,");//发运方式
                strSql2.Append("C_SFJK,");//监控钢种
                strSql2.Append("N_STATUS");//订单状态
                strSql2.Append(")");
                strSql2.Append(" values (");
                strSql2.Append("'" + orderID + "',");//订单主键ID
                strSql2.Append("'" + orderList[i].C_ORDER_NO + "',");//订单号
                strSql2.Append("'" + orderList[i].C_CON_NO + "',");//合同号
                strSql2.Append("'" + orderList[i].C_CON_NAME + "',");//合同名称
                strSql2.Append("'" + orderList[i].C_AREA + "',");//合同区域
                strSql2.Append("'" + orderList[i].C_INVBASDOCID + "',");//存货档案主键
                strSql2.Append("'" + orderList[i].C_INVENTORYID + "',");//存货管理档案主键
                strSql2.Append("'" + orderList[i].C_PROD_NAME + "',");//品名
                strSql2.Append("'" + orderList[i].C_PROD_KIND + "',");//品种
                strSql2.Append("'" + orderList[i].C_MAT_CODE + "',");//物料编码
                strSql2.Append("'" + orderList[i].C_MAT_NAME + "',");//物料名称
                strSql2.Append("'" + orderList[i].C_SPEC + "',");//规格
                strSql2.Append("'" + orderList[i].C_STL_GRD + "',");//钢种
                strSql2.Append("'" + orderList[i].C_FUNITID + "',");//辅单位
                strSql2.Append("'" + orderList[i].C_UNITID + "',");//主计量单位
                //strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_NEED_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//需求日期
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DELIVERY_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//计划收货日期
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//订单日期//签单日期
                strSql2.Append("'" + orderList[i].C_TECH_PROT + "',");//客户协议号
                strSql2.Append("'" + orderList[i].C_PRO_USE + "',");//产品用途
                strSql2.Append("'" + orderList[i].C_FREE1 + "',");//自由项1
                strSql2.Append("'" + orderList[i].C_FREE2 + "',");//自由项2
                strSql2.Append("'" + orderList[i].C_STD_CODE + "',");//执行标准
                strSql2.Append("'" + orderList[i].C_DESIGN_NO + "',");//质量设计号
                strSql2.Append("'" + orderList[i].C_PACK + "',");//包装要求
                strSql2.Append("" + orderList[i].N_TAXRATE + ",");//税率
                strSql2.Append("" + orderList[i].N_ORIGINALCURPRICE + ",");//原币无税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXPRICE + ",");//原币含税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXMNY + ",");//原币税额
                strSql2.Append("" + orderList[i].N_ORIGINALCURMNY + ",");//原币无税金额
                strSql2.Append("" + orderList[i].N_ORIGINALCURSUMMNY + ",");//原币价税合计
                strSql2.Append("" + orderList[i].N_WGT + ",");//数量
                strSql2.Append("" + orderList[i].N_HSL + ",");//换算率
                strSql2.Append("" + orderList[i].N_FNUM + ",");//辅数量
                strSql2.Append("'" + orderList[i].C_RECEIPTAREAID + "',");//收货地区
                strSql2.Append("'" + orderList[i].C_RECEIVEADDRESS + "',");//收货地址
                strSql2.Append("'" + orderList[i].C_RECEIPTCORPID + "',");//收货单位
                strSql2.Append("'" + orderList[i].C_CURRENCYTYPEID + "',");//货币
                strSql2.Append("" + orderList[i].N_TYPE + ",");//线材类型
                strSql2.Append("" + orderList[i].N_USER_LEV + ",");//客户等级
                strSql2.Append("'" + orderList[i].C_REMARK + "',");
                strSql2.Append("'" + orderList[i].C_EMP_ID + "',");
                strSql2.Append("'" + orderList[i].C_EMP_NAME + "',");
                strSql2.Append("'" + orderList[i].C_CUST_NO + "',");
                strSql2.Append("'" + orderList[i].C_CUST_NAME + "',");
                strSql2.Append("'" + orderList[i].C_SALE_CHANNEL + "',");//分销类型
                strSql2.Append("'" + orderList[i].C_LEV + "',");//钢种等级
                strSql2.Append("'" + orderList[i].C_ORDER_LEV + "',");//订单等级
                strSql2.Append("'" + orderList[i].C_BY4 + "',");//是否不锈钢
                strSql2.Append("" + orderList[i].N_COST + ",");//成本
                strSql2.Append("'" + orderList[i].C_VDEF1 + "',");//质量等级
                strSql2.Append("'" + orderList[i].C_TRANSMODE + "',");//发运方式
                strSql2.Append("'" + C_SFJK + "',");//监控钢种
                strSql2.Append("" + orderList[i].N_STATUS + "");//订单状态
                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
                #endregion
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //插入库存超订单
        /// <summary>
        /// 插入订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertKCFirstOrder(List<Mod_TMO_ORDER> orderList)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < orderList.Count; i++)
            {
                string C_SFJK = Exists_MOIN_STLGRD(orderList[i].C_STL_GRD) == true ? "Y" : "N";//监控钢种


                #region //合同订单
                string orderID = Guid.NewGuid().ToString("N");//订单主键ID
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into TMO_CON_ORDER(");
                strSql2.Append("C_ID,");//订单主键ID
                strSql2.Append("C_ORDER_NO,");//订单号
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_CON_NAME,");//合同名称
                strSql2.Append("C_AREA,");//合同区域
                strSql2.Append("C_INVBASDOCID,");//存货档案主键
                strSql2.Append("C_INVENTORYID,");//存货管理档案主键
                strSql2.Append("C_PROD_NAME,");//品名
                strSql2.Append("C_PROD_KIND,");//品种
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_FUNITID,");//辅单位
                strSql2.Append("C_UNITID,");//主计量单位
                strSql2.Append("D_DELIVERY_DT,");//计划收货日期
                strSql2.Append("D_DT,");//订单日期//签单日期
                strSql2.Append("C_TECH_PROT,");//客户协议号
                strSql2.Append("C_PRO_USE,");//产品用途
                strSql2.Append("C_FREE1,");//自由项1
                strSql2.Append("C_FREE2,");//自由项2
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("C_DESIGN_NO,");//质量设计号
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("N_TAXRATE,");//税率
                strSql2.Append("N_ORIGINALCURPRICE,");//原币无税单价
                strSql2.Append("N_ORIGINALCURTAXPRICE,");//原币含税单价
                strSql2.Append("N_ORIGINALCURTAXMNY,");//原币税额
                strSql2.Append("N_ORIGINALCURMNY,");//原币无税金额
                strSql2.Append("N_ORIGINALCURSUMMNY,");//原币价税合计
                strSql2.Append("N_WGT,");//数量
                strSql2.Append("N_HSL,");//换算率
                strSql2.Append("N_FNUM,");//辅数量
                strSql2.Append("C_RECEIPTAREAID,");//收货地区
                strSql2.Append("C_RECEIVEADDRESS,");//收货地址
                strSql2.Append("C_RECEIPTCORPID,");//收货单位
                strSql2.Append("C_CURRENCYTYPEID,");//货币
                strSql2.Append("N_TYPE,");//线材类型
                strSql2.Append("N_USER_LEV,");//客户等级
                strSql2.Append("C_REMARK,");
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_CUST_NO,");
                strSql2.Append("C_CUST_NAME,");
                strSql2.Append("C_SALE_CHANNEL,");//分销类型
                strSql2.Append("C_LEV,");//钢种等级
                strSql2.Append("C_ORDER_LEV,");//订单等级
                strSql2.Append("C_BY4,");//是否不锈钢
                strSql2.Append("N_COST,");//成本
                strSql2.Append("C_VDEF1,");//质量等级
                strSql2.Append("C_TRANSMODE,");//发运方式
                strSql2.Append("C_SFJK,");//监控钢种
                strSql2.Append("N_EXEC_STATUS,");//执行状态
                strSql2.Append("N_STATUS");//订单状态
                strSql2.Append(")");
                strSql2.Append(" values (");
                strSql2.Append("'" + orderID + "',");//订单主键ID
                strSql2.Append("'" + orderList[i].C_ORDER_NO + "',");//订单号
                strSql2.Append("'" + orderList[i].C_CON_NO + "',");//合同号
                strSql2.Append("'" + orderList[i].C_CON_NAME + "',");//合同名称
                strSql2.Append("'" + orderList[i].C_AREA + "',");//合同区域
                strSql2.Append("'" + orderList[i].C_INVBASDOCID + "',");//存货档案主键
                strSql2.Append("'" + orderList[i].C_INVENTORYID + "',");//存货管理档案主键
                strSql2.Append("'" + orderList[i].C_PROD_NAME + "',");//品名
                strSql2.Append("'" + orderList[i].C_PROD_KIND + "',");//品种
                strSql2.Append("'" + orderList[i].C_MAT_CODE + "',");//物料编码
                strSql2.Append("'" + orderList[i].C_MAT_NAME + "',");//物料名称
                strSql2.Append("'" + orderList[i].C_SPEC + "',");//规格
                strSql2.Append("'" + orderList[i].C_STL_GRD + "',");//钢种
                strSql2.Append("'" + orderList[i].C_FUNITID + "',");//辅单位
                strSql2.Append("'" + orderList[i].C_UNITID + "',");//主计量单位
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DELIVERY_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//计划收货日期
                strSql2.Append("to_date('" + Convert.ToDateTime(orderList[i].D_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//订单日期//签单日期
                strSql2.Append("'" + orderList[i].C_TECH_PROT + "',");//客户协议号
                strSql2.Append("'" + orderList[i].C_PRO_USE + "',");//产品用途
                strSql2.Append("'" + orderList[i].C_FREE1 + "',");//自由项1
                strSql2.Append("'" + orderList[i].C_FREE2 + "',");//自由项2
                strSql2.Append("'" + orderList[i].C_STD_CODE + "',");//执行标准
                strSql2.Append("'" + orderList[i].C_DESIGN_NO + "',");//质量设计号
                strSql2.Append("'" + orderList[i].C_PACK + "',");//包装要求
                strSql2.Append("" + orderList[i].N_TAXRATE + ",");//税率
                strSql2.Append("" + orderList[i].N_ORIGINALCURPRICE + ",");//原币无税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXPRICE + ",");//原币含税单价
                strSql2.Append("" + orderList[i].N_ORIGINALCURTAXMNY + ",");//原币税额
                strSql2.Append("" + orderList[i].N_ORIGINALCURMNY + ",");//原币无税金额
                strSql2.Append("" + orderList[i].N_ORIGINALCURSUMMNY + ",");//原币价税合计
                strSql2.Append("" + orderList[i].N_WGT + ",");//数量
                strSql2.Append("" + orderList[i].N_HSL + ",");//换算率
                strSql2.Append("" + orderList[i].N_FNUM + ",");//辅数量
                strSql2.Append("'" + orderList[i].C_RECEIPTAREAID + "',");//收货地区
                strSql2.Append("'" + orderList[i].C_RECEIVEADDRESS + "',");//收货地址
                strSql2.Append("'" + orderList[i].C_RECEIPTCORPID + "',");//收货单位
                strSql2.Append("'" + orderList[i].C_CURRENCYTYPEID + "',");//货币
                strSql2.Append("" + orderList[i].N_TYPE + ",");//线材类型
                strSql2.Append("" + orderList[i].N_USER_LEV + ",");//客户等级
                strSql2.Append("'" + orderList[i].C_REMARK + "',");
                strSql2.Append("'" + orderList[i].C_EMP_ID + "',");
                strSql2.Append("'" + orderList[i].C_EMP_NAME + "',");
                strSql2.Append("'" + orderList[i].C_CUST_NO + "',");
                strSql2.Append("'" + orderList[i].C_CUST_NAME + "',");
                strSql2.Append("'" + orderList[i].C_SALE_CHANNEL + "',");//分销类型
                strSql2.Append("'" + orderList[i].C_LEV + "',");//钢种等级
                strSql2.Append("'" + orderList[i].C_ORDER_LEV + "',");//订单等级
                strSql2.Append("'" + orderList[i].C_BY4 + "',");//是否不锈钢
                strSql2.Append("" + orderList[i].N_COST + ",");//成本
                strSql2.Append("'" + orderList[i].C_VDEF1 + "',");//质量等级
                strSql2.Append("'" + orderList[i].C_TRANSMODE + "',");//发运方式
                strSql2.Append("'" + C_SFJK + "',");//监控钢种
                strSql2.Append("7,");//7库存货
                strSql2.Append("" + orderList[i].N_STATUS + "");//订单状态
                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
                #endregion
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //插入预测订单/合同订单/排产
        /// <summary>
        /// 需求订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool InsertNeedOrder(List<Mod_TMO_ORDER> orderList)
        {

            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < orderList.Count; i++)
            {
                string C_SFJK = Exists_MOIN_STLGRD(orderList[i].C_STL_GRD) == true ? "Y" : "N";//监控钢种

                #region //合同订单
                string orderID = Guid.NewGuid().ToString("N");//订单主键ID
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into TMO_ORDER(");
                strSql2.Append("C_ID,");//订单主键ID
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_ORDER_NO,");//订单号
                strSql2.Append("C_AREA,");//合同区域
                strSql2.Append("C_INVBASDOCID,");//存货档案主键
                strSql2.Append("C_INVENTORYID,");//存货管理档案主键
                strSql2.Append("C_PROD_NAME,");//品名
                strSql2.Append("C_PROD_KIND,");//品种
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_FUNITID,");//辅单位
                strSql2.Append("C_UNITID,");//主计量单位
                strSql2.Append("C_YWY,");//业务员
                strSql2.Append("C_FREE1,");//自由项1
                strSql2.Append("C_FREE2,");//自由项2
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("C_DESIGN_NO,");//质量设计号
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("N_WGT,");//数量
                strSql2.Append("N_TYPE,");//线材类型
                strSql2.Append("N_FLAG,");//订单类型
                strSql2.Append("N_EXEC_STATUS,");//执行状态
                strSql2.Append("C_REMARK4,");//行备注
                strSql2.Append("C_PCTBEMP,");//提报人
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_LEV,");//钢种等级
                strSql2.Append("C_ORDER_LEV,");//订单等级
                strSql2.Append("C_BY4,");//是否不锈钢
                strSql2.Append("C_SFJK,");//监控钢种
                strSql2.Append("N_STATUS,");//订单状态
                strSql2.Append("C_CUST_NO,");//客户编码
                strSql2.Append("C_CUST_NAME");//客户信息
                strSql2.Append(")");
                strSql2.Append(" values (");
                strSql2.Append("'" + orderID + "',");//订单主键ID
                strSql2.Append("'" + orderList[i].C_CON_NO + "',");//合同号
                strSql2.Append("'" + orderList[i].C_ORDER_NO + "',");//订单号
                strSql2.Append("'" + orderList[i].C_AREA + "',");//合同区域
                strSql2.Append("'" + orderList[i].C_INVBASDOCID + "',");//存货档案主键
                strSql2.Append("'" + orderList[i].C_INVENTORYID + "',");//存货管理档案主键
                strSql2.Append("'" + orderList[i].C_PROD_NAME + "',");//品名
                strSql2.Append("'" + orderList[i].C_PROD_KIND + "',");//品种
                strSql2.Append("'" + orderList[i].C_MAT_CODE + "',");//物料编码
                strSql2.Append("'" + orderList[i].C_MAT_NAME + "',");//物料名称
                strSql2.Append("'" + orderList[i].C_SPEC + "',");//规格
                strSql2.Append("'" + orderList[i].C_STL_GRD + "',");//钢种
                strSql2.Append("'" + orderList[i].C_FUNITID + "',");//辅单位
                strSql2.Append("'" + orderList[i].C_UNITID + "',");//主计量单位
                strSql2.Append("'" + orderList[i].C_YWY + "',");//业务员
                strSql2.Append("'" + orderList[i].C_FREE1 + "',");//自由项1
                strSql2.Append("'" + orderList[i].C_FREE2 + "',");//自由项2
                strSql2.Append("'" + orderList[i].C_STD_CODE + "',");//执行标准
                strSql2.Append("'" + orderList[i].C_DESIGN_NO + "',");//质量设计号
                strSql2.Append("'" + orderList[i].C_PACK + "',");//包装要求
                strSql2.Append("" + orderList[i].N_WGT + ",");//数量
                strSql2.Append("" + orderList[i].N_TYPE + ",");//线材类型
                strSql2.Append("" + orderList[i].N_FLAG + ",");//订单0正常，1预测订单
                strSql2.Append("" + orderList[i].N_EXEC_STATUS + ",");//执行状态：-1 提报订单
                strSql2.Append("'" + orderList[i].C_REMARK4 + "',");//备注
                strSql2.Append("'" + orderList[i].C_PCTBEMP + "',");//提报人
                strSql2.Append("'" + orderList[i].C_EMP_ID + "',");
                strSql2.Append("'" + orderList[i].C_EMP_NAME + "',");
                strSql2.Append("'" + orderList[i].C_LEV + "',");//钢种等级
                strSql2.Append("'" + orderList[i].C_ORDER_LEV + "',");//订单等级
                strSql2.Append("'" + orderList[i].C_BY4 + "',");//是否不锈钢
                strSql2.Append("'" + C_SFJK + "',");//监控钢种
                strSql2.Append("" + orderList[i].N_STATUS + ",");//订单状态
                strSql2.Append("'" + orderList[i].C_CUST_NO + "',");//客户编码
                strSql2.Append("'" + orderList[i].C_CUST_NAME + "'");//客户名称
                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
                #endregion
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }


        /// <summary>
        /// 获取合同订单已下发排产量
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        public string GetOrderPCWGT(string orderNO)
        {
            string strSql = string.Format("SELECT NVL(SUM(T.N_WGT),0) FROM TMO_ORDER T WHERE T.N_EXEC_STATUS IN(-1,0,6)  AND T.C_ORDER_NO IN({0})", orderNO);
            return DbHelperOra.GetSingle(strSql)?.ToString() ?? "0";
        }

        #endregion

        #region //更新合同与合同明细数据
        /// <summary>
        /// 更新合同与合同明细数据
        /// </summary>
        /// <param name="modCon"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public bool UpdateConOrder(Mod_TMO_CON modCon, List<Mod_TMO_ORDER> orderList)
        {
            ArrayList arraySql = new ArrayList();

            #region //合同

            if (modCon != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TMO_CON set ");
                if (!string.IsNullOrEmpty(modCon.C_CON_NEW))
                {
                    strSql.Append("C_CON_NO='" + modCon.C_CON_NEW + "',");//合同号
                }
                strSql.Append("C_CON_NAME='" + modCon.C_CON_NAME + "',");//合同名称
                strSql.Append("C_CONTYPEID='" + modCon.C_CONTYPEID + "',");//合同类型
                strSql.Append("C_COPERATORID='" + modCon.C_COPERATORID + "',");//制单人
                strSql.Append("C_EMPLOYEEID='" + modCon.C_EMPLOYEEID + "',");//业务员
                strSql.Append("C_CURRENCYTYPEID='" + modCon.C_CURRENCYTYPEID + "',");//货币类型
                strSql.Append("D_CONSING_DT=to_date('" + Convert.ToDateTime(modCon.D_CONSING_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//合同签署日期
                strSql.Append("D_CONEFFE_DT=to_date('" + Convert.ToDateTime(modCon.D_CONEFFE_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//计划生效日期
                strSql.Append("D_CONINVALID_DT=to_date('" + Convert.ToDateTime(modCon.D_CONINVALID_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//计划失效日期
                //strSql.Append("D_NEED_DT=to_date('" + Convert.ToDateTime(modCon.D_NEED_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//需求日期
                strSql.Append("C_TRANSMODEID='" + modCon.C_TRANSMODEID + "',");//发运方式
                strSql.Append("C_AREA='" + modCon.C_AREA + "',");//合同区域
                strSql.Append("N_STATUS=" + modCon.N_STATUS + ",");//状态
                strSql.Append("C_ADDRESS='" + modCon.C_ADDRESS + "',");//收货地址
                strSql.Append("C_CRECEIPTAREAID='" + modCon.C_CRECEIPTAREAID + "',");//收货地区
                strSql.Append("C_STATION='" + modCon.C_STATION + "',");//站点
                strSql.Append("C_SALECORPID='" + modCon.C_SALECORPID + "',");//销售组织
                strSql.Append("C_BIZTYPE='" + modCon.C_BIZTYPE + "',");//业务类型
                strSql.Append("C_DEPTID='" + modCon.C_DEPTID + "',");//业务部门
                strSql.Append("C_CRECEIPTCORPID='" + modCon.C_CRECEIPTCORPID + "',");//开票单位
                strSql.Append("C_CRECEIPTCUSTOMERID='" + modCon.C_CRECEIPTCUSTOMERID + "',");//收货单位
                strSql.Append("C_REAMRK='" + modCon.C_REAMRK + "',");//合同备注
                strSql.Append("C_EDITEMPLOYEEID='" + modCon.C_EDITEMPLOYEEID + "',");//修改人
                if (!string.IsNullOrEmpty(modCon.D_EDITDATE.ToString()))
                {
                    strSql.Append("D_EDITDATE=to_date('" + Convert.ToDateTime(modCon.D_EDITDATE) + "', 'yyyy-mm-dd hh24:mi:ss'),");//修改时间
                }
                strSql.Append("N_FLAG='" + modCon.N_FLAG + "'");//合同标识
                strSql.Append(" where C_CON_NO='" + modCon.C_CON_NO + "' ");//合同号主键
                arraySql.Add(strSql.ToString());
            }

            #endregion

            for (int i = 0; i < orderList.Count; i++)
            {
                #region //订单
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update TMO_CON_ORDER set ");
                if (!string.IsNullOrEmpty(modCon.C_CON_NEW))
                {
                    strSql2.Append("C_CON_NO='" + orderList[i].C_CON_NO + "',");//合同号
                }
                strSql2.Append("C_CON_NAME='" + orderList[i].C_CON_NAME + "',");//合同名称
                strSql2.Append("C_AREA='" + orderList[i].C_AREA + "',");//合同区域
                strSql2.Append("N_STATUS=" + orderList[i].N_STATUS + ",");//订单状态
                //strSql2.Append("D_NEED_DT=to_date('" + Convert.ToDateTime(orderList[i].D_NEED_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//需求日期
                strSql2.Append("D_DELIVERY_DT=to_date('" + Convert.ToDateTime(orderList[i].D_DELIVERY_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//交货日期
                strSql2.Append("C_PACK='" + orderList[i].C_PACK + "',");//包装
                strSql2.Append("C_STD_CODE='" + orderList[i].C_STD_CODE + "',");//执行标准
                strSql2.Append("C_FREE1='" + orderList[i].C_FREE1 + "',");//自由项1
                strSql2.Append("C_FREE2='" + orderList[i].C_FREE2 + "',");//自由项2
                strSql2.Append("N_WGT=" + orderList[i].N_WGT + ",");//重量
                strSql2.Append("N_TAXRATE=" + orderList[i].N_TAXRATE + ",");//税率
                if (!string.IsNullOrEmpty(orderList[i].N_FNUM.ToString()))
                {
                    strSql2.Append("N_FNUM=" + orderList[i].N_FNUM + ",");//辅数量
                }
                strSql2.Append("N_ORIGINALCURPRICE=" + orderList[i].N_ORIGINALCURPRICE + ",");//无税单价
                strSql2.Append("N_ORIGINALCURTAXPRICE=" + orderList[i].N_ORIGINALCURTAXPRICE + ",");//含税单价
                strSql2.Append("N_ORIGINALCURTAXMNY=" + orderList[i].N_ORIGINALCURTAXMNY + ",");//税额
                strSql2.Append("N_ORIGINALCURMNY=" + orderList[i].N_ORIGINALCURMNY + ",");//无税金额
                strSql2.Append("N_ORIGINALCURSUMMNY=" + orderList[i].N_ORIGINALCURSUMMNY + ",");//价税合计
                strSql2.Append("C_CUST_NAME='" + modCon.C_CUSTNAME + "',");//客户名称
                strSql2.Append("C_CUST_NO='" + modCon.C_CUST_NO + "',");//客户客户编码
                strSql2.Append("C_RECEIPTAREAID='" + orderList[i].C_RECEIPTAREAID + "',");//收货地区
                strSql2.Append("C_RECEIVEADDRESS='" + orderList[i].C_RECEIVEADDRESS + "',");//收货地址
                strSql2.Append("C_RECEIPTCORPID='" + orderList[i].C_RECEIPTCORPID + "',");//收货单位
                strSql2.Append("C_CURRENCYTYPEID='" + orderList[i].C_CURRENCYTYPEID + "',");//货币主键
                strSql2.Append("C_REMARK='" + orderList[i].C_REMARK + "',");//行备注
                strSql2.Append("C_LEV='" + orderList[i].C_LEV + "',");//钢种等级
                strSql2.Append("C_ORDER_LEV='" + orderList[i].C_ORDER_LEV + "',");//订单级别
                strSql2.Append("C_VDEF1='" + orderList[i].C_VDEF1 + "',");//质量等级
                strSql2.Append("C_TRANSMODE='" + orderList[i].C_TRANSMODE + "',");//发运方式
                strSql2.Append("C_TRANSMODEID='" + orderList[i].C_TRANSMODEID + "',");//发运方式主键
                strSql2.Append("C_YWY='" + orderList[i].C_YWY + "',");//业务员姓名
                strSql2.Append("C_PCLX='" + orderList[i].C_PCLX + "',");//1出口材，0普通材
                strSql2.Append("C_SFJK='" + orderList[i].C_SFJK + "',");//监控钢种
                strSql2.Append("C_STL_GRD_CLASS='" + orderList[i].C_STL_GRD_CLASS + "',");//钢种大类
                strSql2.Append("N_EXEC_STATUS=" + orderList[i].N_EXEC_STATUS + "");//执行状态

                strSql2.Append(" where C_ID='" + orderList[i].C_ID + "'");//订单主键
                arraySql.Add(strSql2.ToString());
                #endregion
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //删除订单&质量

        /// <summary>
        /// 删除订单&质量
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DelConOrder(string orderID)
        {
            ArrayList arraySql = new ArrayList();

            //订单
            string strSql = string.Format("delete from TMO_CON_ORDER where C_ID='{0}' and C_SFPJ='N'", orderID);
            arraySql.Add(strSql);
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }


        /// <summary>
        /// 根据订单号删除
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool DelOrderNo(string orderNo)
        {
            DataRow dr = DbHelperOra.GetDataRow("select C_ID from TMO_CON_ORDER where C_ORDER_NO='" + orderNo + "'");
            if (dr != null)
            {
                return DelConOrder(dr["C_ID"].ToString());
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region //合同变更
        /// <summary>
        /// 合同变更-原始合同终止
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止 </param>
        /// <param name="conNO">合同号</param>
        /// <param name="empID">操作人</param>
        /// <returns></returns>
        public bool AlterationCon(int status, string conNO, string empID)
        {
            string cmd = string.Format(@"SELECT T.C_ORDER_NO
                                      FROM TMO_CON_ORDER T
                                     WHERE T.C_CON_NO = '{0}'
                                       AND T.C_SFPJ = 'Y'
                                       AND T.N_EXEC_STATUS IN (0)", conNO);
            DataTable dt = DbHelperOra.Query(cmd).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                ArrayList strSql = new ArrayList();

                #region //终止原始合同状态
                //合同
                strSql.Add("update TMO_CON set N_STATUS=" + status + ",D_CHANGEDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),C_CHANGEEMPID='" + empID + "'  where C_CON_NO='" + conNO + "'");
                //合同订单
                strSql.Add("update TMO_CON_ORDER t set t.N_STATUS=" + status + " where  t.c_con_no='" + conNO + "'");
                #endregion

                return DbHelperOra.ExecuteSqlTran(strSql);
            }
        }
        #endregion

        #region  //合同提交审批
        /// <summary>
        /// 合同提交审批
        /// </summary>
        /// <param name="modFile">文件</param>
        /// <param name="modNextEmp">步骤操作人</param>
        /// <returns></returns>
        public bool ApproveCon(Mod_TMF_FILEINFO modFile, Mod_TMB_FILE_NEXT_EMP modNextEmp)
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

            #region //更新合同状态与制单人/制单时间
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update TMO_CON set ");
            strSql2.Append("C_FLOWID='" + modFile.C_FLOW_ID + "', ");
            strSql2.Append("N_STATUS=1, ");//1审批中
            strSql2.Append("C_COPERATORID='" + modFile.C_EMP_ID + "',");//制单人
            strSql2.Append("D_DMAKEDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),");//制单时间
            strSql2.Append("C_APPROVEID='" + modNextEmp.C_NEXT_EMP_ID + "' ");//审批人
            strSql2.Append(" where C_CON_NO='" + modFile.C_TASK_ID + "' ");
            arraySql.Add(strSql2.ToString());
            string cmdtext = "UPDATE TMO_CON_ORDER SET N_STATUS=1 WHERE C_CON_NO='" + modFile.C_TASK_ID + "'";
            arraySql.Add(cmdtext);
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

        #region //新增变更合同修改合同制单人/修改人记录
        /// <summary>
        /// 修改变更合同制单人/修改人/录入原始合同号
        /// </summary>
        /// <param name="conNo">变更新合同号</param>
        /// <param name="y_conNO">原始合同号</param>
        /// <param name="empid">操作人</param>
        /// <returns></returns>
        public bool UpdateEditEmp(string conNo, string y_conNO, string empid)
        {
            string strsql = "update TMO_CON set C_CON_NO_OLD='" + y_conNO + "', C_COPERATORID='" + empid + "',D_DMAKEDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'), C_EDITEMPLOYEEID='" + empid + "',D_EDITDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss')  where C_CON_NO='" + conNo + "' ";
            int rows = DbHelperOra.ExecuteSql(strsql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region //合同生效


        string[] mattype = { "6", "8" };

        /// <summary>
        /// 更新合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateStatus(int status, string conNO, string empid)
        {

            ArrayList strSql = new ArrayList();
            strSql.Add("update TMO_CON set N_STATUS=" + status + ",C_EDITEMPLOYEEID='" + empid + "',D_EDITDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss')  where C_CON_NO='" + conNO + "' ");
            strSql.Add("update TMO_CON_ORDER set N_STATUS=" + status + "  where  C_CON_NO='" + conNO + "'");
            return DbHelperOra.ExecuteSqlTran(strSql);

            #region //停用
            //string cmd = string.Format(@"SELECT T.C_ORDER_NO
            //                          FROM TMO_ORDER T
            //                         WHERE T.C_CON_NO = '{0}'
            //                           AND T.C_SFPJ = 'Y'
            //                           AND T.N_EXEC_STATUS IN (0)", conNO);
            //DataTable dt = DbHelperOra.Query(cmd).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    ArrayList strSql = new ArrayList();
            //    strSql.Add("update TMO_CON set N_STATUS=" + status + ",C_EDITEMPLOYEEID='" + empid + "',D_EDITDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss')  where C_CON_NO='" + conNO + "' ");
            //    strSql.Add("update TMO_CON_ORDER set N_STATUS=" + status + "  where  C_CON_NO='" + conNO + "'");
            //    return DbHelperOra.ExecuteSqlTran(strSql);
            //}
            #endregion
        }

        /// <summary>
        /// 冻结合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateFreezeStatus(int status, string conNO, string empid)
        {
            string cmd = string.Format(@"SELECT T.C_ORDER_NO
                                      FROM TMO_ORDER T
                                     WHERE T.C_CON_NO = '{0}'
                                       AND T.C_SFPJ = 'Y'
                                       AND T.N_EXEC_STATUS IN (0)", conNO);
            DataTable dt = DbHelperOra.Query(cmd).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                ArrayList strSql = new ArrayList();
                strSql.Add("update TMO_CON set N_STATUS=" + status + ",C_EDITEMPLOYEEID='" + empid + "',D_EDITDATE=to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss')  where C_CON_NO='" + conNO + "' ");
                strSql.Add("update TMO_CON_ORDER set N_STATUS=" + status + " where  C_CON_NO='" + conNO + "'");
                return DbHelperOra.ExecuteSqlTran(strSql);
            }
        }

        /// <summary>
        /// 解冻合同状态
        /// </summary>
        /// <param name="status">合同状态：-1未提交，0待审，1审核中，2生效，3变更, 4 审核通过,5冻结,6终止</param>
        /// <param name="conNO">合同号</param>
        /// <returns></returns>
        public bool UpdateUnfreezeStatus(string conNO)
        {
            DataRow dr = DbHelperOra.GetDataRow("select N_OLDSTATUS from TMO_CON where C_CON_NO='" + conNO + "'");
            ArrayList strSql = new ArrayList();
            strSql.Add("update TMO_CON set N_STATUS=" + dr["N_OLDSTATUS"] + " where  C_CON_NO='" + conNO + "'");
            strSql.Add("update TMO_CON_ORDER set N_STATUS=" + dr["N_OLDSTATUS"] + " where C_CON_NO='" + conNO + "'");
            return DbHelperOra.ExecuteSqlTran(strSql);
        }
        #endregion

        #region //获取销售合同是否发送NC
        /// <summary>
        /// 获取销售合同发送NC状态
        /// </summary>
        /// <param name="conNo"></param>
        /// <returns></returns>
        public string GetSaleCon(string conNo)
        {
            string strSql = $@"SELECT C_NC_STATE FROM TMO_CON WHERE C_CON_NO='{conNo}'";
            return DbHelperOra.GetSingle(strSql).ToString();
        }

        #endregion

        #region //合同操作日志

        /// <summary>
        /// 合同操作日志
        /// </summary>
        /// <param name="con"></param>
        /// <param name="empID"></param>
        /// <param name="empName"></param>
        /// <returns></returns>
        public bool InsertConOrderLog(string con, string empID, string empName)
        {
            string[] arr = { con, empID, empName };

            string strSql = string.Format("insert into TMO_CON_LOG(C_CON_NO,C_EMP_ID,C_EMP_NAME)values('{0}','{1}','{2}')", arr);

            if (DbHelperOra.ExecuteSql(strSql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region //客户合同终止确认


        /// <summary>
        /// 获取客户合同终止确认数据列表
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet GetCustCon_End_List(string conno, string custNo, string flag, string kssj, string jssj)
        {
            string strSql = $@"SELECT T.C_ID,
                                   T.C_CUSTNO,
                                   T.C_CUSTNAME,
                                   DECODE(T.C_FLAG, '-1', '待审', '0', '已通知', '1', '已确认') C_FLAG2,
                                   T.C_FLAG,
                                   T.C_EMPID,
                                   T.D_EMPDT,
                                   A.C_NAME AS C_SALEEMPID,
                                   T.D_SALEDT,
                                   T.C_REMARK,
                                   T.C_CONNO,
                                   T.C_AREA,
                                   TM.N_WGT,
                                   TM.YLXWGT,
                                   TM.DLXWGT
                              FROM TMO_CON_END T
                              LEFT JOIN TS_USER A
                                ON A.C_ID = T.C_SALEEMPID
                              LEFT JOIN (SELECT SUM(TMO.N_WGT) N_WGT,
                                                SUM(TMO.YLXWGT) YLXWGT,
                                                SUM(TMO.DLXWGT) DLXWGT,
                                                TMO.C_CON_NO
                                           FROM (SELECT T.N_WGT,
                                                        NVL(TRC.YLXWGT, 0) YLXWGT,
                                                        (T.N_WGT - NVL(TRC.YLXWGT, 0)) AS DLXWGT,
                                                        T.C_CON_NO
                                                   FROM TMO_CON_ORDER T
                                                   LEFT JOIN (SELECT SUM(NVL(G.N_JZ, 0)) YLXWGT, K.C_NO
                                                               FROM TMD_DISPATCH_SJZJB G
                                                              INNER JOIN TMD_DISPATCHDETAILS K
                                                                 ON G.C_PK_NCID = K.C_ID
                                                              GROUP BY K.C_NO
                                                             UNION ALL
                                                             select SUM(NVL(L.N_FYWGT, 0)) YLXWGT, L.C_NO
                                                               from tmd_dispatchdetails L
                                                              WHERE L.C_ORDER_TYPE in
                                                                    ('805', '806', '807')
                                                              GROUP BY L.C_NO) TRC
                                                     ON TRC.C_NO = T.C_ORDER_NO) TMO
                                          GROUP BY TMO.C_CON_NO) TM
                                ON TM.C_CON_NO = T.C_CONNO WHERE 1=1";

            if (!string.IsNullOrEmpty(custNo))
            {
                strSql += $" AND T.C_CUSTNO = '{custNo}'";
            }

            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND T.C_CONNO LIKE '%{conno}%'";
            }

            if (!string.IsNullOrEmpty(flag))
            {
                strSql += $" AND T.C_FLAG IN({flag})";
            }
            if (!string.IsNullOrEmpty(kssj) && !string.IsNullOrEmpty(jssj))
            {
                strSql += $" AND T.D_SALEDT>=TO_DATE('{kssj}','yyyy-mm-dd hh24:mi:ss') AND T.D_SALEDT<=TO_DATE('{jssj} 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            }
            strSql += " ORDER BY T.D_SALEDT DESC";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 获取客户合同终止确认数据列表
        /// </summary>
        /// <param name="custNo"></param>
        /// <returns></returns>
        public DataSet GetCustCon_End_List(string C_ID)
        {
            string strSql = $"SELECT * FROM TMO_CON_END  WHERE C_ID='{C_ID}' ";


            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 插入客户合同终止信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool InsertCustCon_End(Mod_TMO_CON_END mod)
        {
            string strSql = $@"INSERT INTO TMO_CON_END(C_CUSTNO,C_CUSTNAME,C_SALEEMPID,C_REMARK,C_CONNO,C_AREA)VALUES('{mod.C_CUSTNO}','{mod.C_CUSTNAME}','{mod.C_SALEEMPID}','{mod.C_REMARK}','{mod.C_CONNO}','{mod.C_AREA}')";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }


        /// <summary>
        /// 批准合同终止通知
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool CheckCustCon_End(string id, string empID)
        {
            string strSql = $@"UPDATE TMO_CON_END SET C_FLAG='0',C_APPROVEID='{ empID}',D_APPROVEDT=TO_DATE('{DateTime.Now}','yyyy-mm-dd hh24:mi:ss') WHERE C_ID='{id}' AND C_FLAG='-1'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;

        }


        /// <summary>
        /// 修改客户合同终止信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool UpdateCustCon_End(string id, string empID)
        {
            DataTable dt = GetCustCon_End_List(id).Tables[0];

            ArrayList arraySql = new ArrayList();
            string strSql = $@"UPDATE TMO_CON_END SET C_FLAG='1',C_EMPID='{ empID}',D_EMPDT=TO_DATE('{DateTime.Now}','yyyy-mm-dd hh24:mi:ss') WHERE C_ID='{id}'";
            arraySql.Add(strSql);
            string strSql2 = $@"UPDATE TMO_CON SET N_STATUS=6,C_EDITEMPLOYEEID='{dt.Rows[0]["C_SALEEMPID"].ToString()}',D_EDITDATE=TO_DATE('{dt.Rows[0]["D_SALEDT"].ToString()}','yyyy-mm-dd hh24:mi:ss')  WHERE C_CON_NO='{dt.Rows[0]["C_CONNO"].ToString()}'";
            arraySql.Add(strSql2);
            string strSql3 = $@"UPDATE TMO_CON_ORDER SET N_STATUS=6  WHERE  C_CON_NO='{dt.Rows[0]["C_CONNO"].ToString()}'";
            arraySql.Add(strSql3);

            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        #endregion

        #endregion
    }
}

