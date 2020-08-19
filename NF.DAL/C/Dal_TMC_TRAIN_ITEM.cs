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
    /// 
    /// </summary>
    public partial class Dal_TMC_TRAIN_ITEM
    {
        public Dal_TMC_TRAIN_ITEM()
        { }

        /// <summary>
        /// 删除火运计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Del(Mod_TMC_TRAIN_ITEM mod)
        {
            string strSql = $"DELETE FROM TMC_TRAIN_ITEM WHERE C_ID='{mod.C_ID}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 删除计划号
        /// </summary>
        /// <param name="C_ID"></param>
        /// <returns></returns>
        public bool DelTrainPlan(string C_ID)
        {
            string strSql = $"DELETE FROM TMC_TRAIN WHERE  C_ID='{C_ID}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }
        /// <summary>
        /// 计划号录入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>

        public bool AddTrainPlan(List<Mod_TMC_TRAIN> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $@"INSERT INTO TMC_TRAIN  (C_EMPNAME,C_FLAG,N_TRAIN_NUM,C_STATION,C_STATION_J,C_PLANNO,C_CUSTNAME,C_CUSTNO,C_AREA,D_MONTH,C_REMARK,C_TYPE)VALUES('{item.C_EMPNAME}','{item.C_FLAG}',{item.N_TRAIN_NUM},'{item.C_STATION}','{item.C_STATION_J}','{item.C_PLANNO}','{item.C_CUSTNAME}','{item.C_CUSTNO}','{item.C_AREA}',to_date('{item.D_MONTH}','yyyy-mm-dd hh24:mi:ss'),'{item.C_REMARK}','{item.C_TYPE}')";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        /// <summary>
        /// 火运发运日计划
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool AddTrain(List<Mod_TMC_TRAIN_ITEM> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var mod in list)
            {
                #region //参数
                string strSql = $@"INSERT INTO TMC_TRAIN_ITEM
                              (C_EMPNAME,
                               C_PKID,
                               C_AREA,
                               C_CONNO,
                               C_DH_COMPANY,
                               C_SH_COMPANY,
                               C_CUSTNO,
                               C_CUSTNAME,
                               C_KH_BANK,
                               C_TAXNO,
                               C_ADDRESS,
                               C_TEL,
                               C_ACCOUNT,
                               C_FLAG,
                               C_BILLCODE,
                               C_SPEC,
                               C_STL_GRD,
                               N_WGT,
                               C_REMARK
                               )
                            VALUES(";
                strSql += $"'{mod.C_EMPNAME}',";
                strSql += $"'{mod.C_PKID}',";
                strSql += $"'{mod.C_AREA}',";
                strSql += $"'{mod.C_CONNO}',";
                strSql += $"'{mod.C_DH_COMPANY}',";
                strSql += $"'{mod.C_SH_COMPANY}',";
                strSql += $"'{mod.C_CUSTNO}',";
                strSql += $"'{mod.C_CUSTNAME}',";
                strSql += $"'{mod.C_KH_BANK}',";
                strSql += $"'{mod.C_TAXNO}',";
                strSql += $"'{mod.C_ADDRESS}',";
                strSql += $"'{mod.C_TEL}',";
                strSql += $"'{mod.C_ACCOUNT}',";
                strSql += $"'{mod.C_FLAG}',";
                strSql += $"'{mod.C_BILLCODE}',";
                strSql += $"'{mod.C_SPEC}',";
                strSql += $"'{mod.C_STL_GRD}',";
                strSql += $"{mod.N_WGT},";
                strSql += $"'{mod.C_REMARK}'";
                strSql += ")";

                #endregion
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }



        /// <summary>
        /// 火运报备计划添加
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool Add(Mod_TMC_TRAIN_ITEM mod)
        {
            string strSql = $@"INSERT INTO TMC_TRAIN_ITEM
                              (C_EMPNAME,
                               C_PKID,
                               C_AREA,
                               C_CONNO,
                               C_DH_COMPANY,
                               C_SH_COMPANY,
                               C_STATION,
                               N_TRAIN_NUM,
                               C_CUSTNO,
                               C_CUSTNAME,
                               C_KH_BANK,
                               C_TAXNO,
                               C_ADDRESS,
                               C_TEL,
                               C_ACCOUNT,
                               C_FLAG,
                               C_BILLCODE,
                               D_MONTH,
                               C_LINE
                               )
                            VALUES(";
            strSql += $"'{mod.C_EMPNAME}',";
            strSql += $"'{mod.C_PKID}',";
            strSql += $"'{mod.C_AREA}',";
            strSql += $"'{mod.C_CONNO}',";
            strSql += $"'{mod.C_DH_COMPANY}',";
            strSql += $"'{mod.C_SH_COMPANY}',";
            strSql += $"'{mod.C_STATION}',";
            strSql += $"{mod.N_TRAIN_NUM},";
            strSql += $"'{mod.C_CUSTNO}',";
            strSql += $"'{mod.C_CUSTNAME}',";
            strSql += $"'{mod.C_KH_BANK}',";
            strSql += $"'{mod.C_TAXNO}',";
            strSql += $"'{mod.C_ADDRESS}',";
            strSql += $"'{mod.C_TEL}',";
            strSql += $"'{mod.C_ACCOUNT}',";
            strSql += $"'{mod.C_FLAG}',";
            strSql += $"'{mod.C_BILLCODE}',";
            strSql += $"to_date('{mod.D_MONTH}','YYYY-MM-DD HH24:MI:SS'),";
            strSql += $"'{mod.C_LINE}'";
            strSql += ")";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 获取计划号
        /// </summary>
        /// <param name="planNo"></param>
        /// <param name="station"></param>
        /// <param name="cust"></param>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <returns></returns>
        public DataSet GetTrainPlan(string planNo, string station, string cust, string startDT, string endDT, string emp,string type)
        {
            string strSql = $@"SELECT T.C_ID,
                               T.C_EMPNAME,
                               T.D_DATE,
                               T.C_FLAG,
                               T.N_TRAIN_NUM,
                               (NVL(T.N_TRAIN_NUM, 0) - NVL((SELECT SUM(A.N_TRAIN_NUM)
                                                              FROM TMC_TRAIN_MAIN A
                                                             WHERE A.C_PLANNO = T.C_PLANNO),
                                                            0)) AS SYNUM,
                               (SELECT SUM(A.N_TRAIN_NUM)
                                  FROM TMC_TRAIN_MAIN A
                                 WHERE A.C_PLANNO = T.C_PLANNO) AS YFNUM,
                               T.C_STATION,
                               T.C_STATION_J,
                               T.C_PLANNO,
                               T.C_CUSTNO,
                               T.C_CUSTNAME,
                               T.C_AREA,
                               T.C_REMARK,
                               T.C_TYPE

                          FROM TMC_TRAIN T
                         WHERE 1 = 1";

            if(type!="全部")
            {
                strSql += $" AND T.C_TYPE='{type}'";
            }
            if (!string.IsNullOrEmpty(emp))
            {
                strSql += $" AND T.C_EMPNAME='{emp}'";
            }
            if (!string.IsNullOrEmpty(planNo))
            {
                strSql += $" AND T.C_PLANNO='{planNo}'";
            }
            if (!string.IsNullOrEmpty(station))
            {
                strSql += $" AND T.C_STATION LIKE '%{station}%'";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql += $" AND (T.C_CUSTNAME LIKE '%{cust}%' or T.C_CUSTNO LIKE '%{cust}%')";
            }
            if (!string.IsNullOrEmpty(startDT) && !string.IsNullOrEmpty(endDT))
            {
                strSql += $@" AND T.D_MONTH BETWEEN TO_DATE('{startDT}', 'yyyy-mm-dd hh24:mi:ss') AND to_date('{endDT} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            return DbHelperOra.Query(strSql);
        }


        /// <summary>
        /// 获取火运报备计划-发运日计划申请
        /// </summary>
        /// <param name="conno"></param>
        /// <returns></returns>
        public DataSet GetTrain(string conno, string stlgrd, string spec, string custname, string startdt, string enddt, string area)
        {
            string strSql = $@"SELECT T.C_AREA,
                               T.C_CON_NO,
                               T.C_ORDER_NO,
                               B.C_NO AS C_CUSTNO,
                               B.C_NAME AS C_CUSTNAME,
                               B.C_EXTEND1 AS C_KH_BANK,
                               B.C_TAXPAYERNO AS C_TAXNO,
                               B.C_EXTEND2 AS C_ACCOUNT,
                               B.C_EXTEND4 AS C_TEL,
                               B.C_EXTEND3 AS C_ADDRESS,
                               T.C_SPEC,
                               T.C_STL_GRD,
                               T.D_DT,
                               T.C_MAT_CODE,
                               T.C_STD_CODE,
                               T.N_WGT, --原订单量
                               TMC.N_WGT AS PLANWGT, --计划量
                               TRC.N_WGT KCWGT,
                               (SELECT A.C_NAME
                                  FROM TS_CUSTFILE A
                                 WHERE A.C_NC_M_ID = T.C_RECEIPTCORPID) AS C_DH_COMPANY
                          FROM TMO_CON_ORDER T
                          LEFT JOIN TS_CUSTFILE B
                            ON B.C_NO = T.C_CUST_NO
                          LEFT JOIN (SELECT SUM(C.N_WGT) N_WGT, C.C_BILLCODE
                                       FROM TMC_TRAIN_ITEM C
                                      WHERE C.C_FLAG = '1'
                                      GROUP BY C.C_BILLCODE) TMC
                            ON TMC.C_BILLCODE = T.C_ORDER_NO
                          LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT,
                                            T.C_MAT_CODE,
                                            T.C_STD_CODE,
                                            T.C_SALE_AREA,
                                            T.C_CON_NO,
                                            T.C_CUST_NAME
                                       FROM TRC_ROLL_PRODCUT T
                                      WHERE T.C_MOVE_TYPE = 'E' AND T.C_IS_QR = 'Y'
                                      GROUP BY T.C_MAT_CODE,
                                               T.C_STD_CODE,
                                               T.C_SALE_AREA,
                                               T.C_CON_NO,
                                               T.C_CUST_NAME) TRC
                            ON TRC.C_MAT_CODE = T.C_MAT_CODE
                           AND TRC.C_STD_CODE = T.C_STD_CODE
                           AND TRC.C_SALE_AREA = T.C_AREA
                           AND SUBSTR(TRC.C_CON_NO, 0, 15) = SUBSTR(T.C_CON_NO, 0, 15)
                           AND TRC.C_CUST_NAME = T.C_CUST_NAME
                         WHERE T.N_STATUS = 2
                           AND NVL(TRC.N_WGT, 0) > 0";

            if (!string.IsNullOrEmpty(area))
            {
                strSql += $" AND T.C_AREA='{area}'";
            }
            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND T.C_CON_NO LIKE '%{conno}%'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND T.C_STL_GRD LIKE '%{stlgrd}%'";
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql += $" AND T.C_SPEC LIKE '%{spec}%'";
            }
            if (!string.IsNullOrEmpty(custname))
            {
                strSql += $" AND T.C_CUST_NAME LIKE '%{custname}%'";
            }

            if (!string.IsNullOrEmpty(startdt) && !string.IsNullOrEmpty(enddt))
            {
                strSql += $@" AND T.D_DT >= TO_DATE('{startdt}', 'yyyy-mm-dd hh24:mi:ss') AND T.D_DT<= to_date('{enddt} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            return DbHelperOra.Query(strSql);
        }

        public DataSet GetList(string empID, string cust, string custno, string startDT, string endDT, string conno, string flag)
        {
            string strSql = $"SELECT * FROM TMC_TRAIN_ITEM T WHERE C_FLAG IN({flag})";

            if (!string.IsNullOrEmpty(empID))
            {
                strSql += $" AND T.C_PKID='{empID}'";
            }
            if (!string.IsNullOrEmpty(custno))
            {
                strSql += $" AND T.C_CUSTNO='{custno}'";
            }
            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND T.C_CONNO LIKE '%{conno}%'";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql += $" AND (T.C_DH_COMPANY LIKE '%{cust}%' OR T.C_SH_COMPANY LIKE '%{cust}%')";
            }
            if (!string.IsNullOrEmpty(startDT) && !string.IsNullOrEmpty(endDT))
            {
                strSql += $@" AND D_DATE BETWEEN TO_DATE('{startDT}', 'yyyy-mm-dd hh24:mi:ss') AND to_date('{endDT} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }
            return DbHelperOra.Query(strSql);
        }


        public DataSet GetList(string empID, string cust, string custno, string startDT, string endDT, string conno, string plancode, string stlgrd,string area)
        {
            string strSql = $"SELECT T.C_ID,T.C_EMPID,T.C_EMPNAME,T.D_DT,T.C_STATION,T.C_PLANNO,T.C_LINE,T.N_TRAIN_NUM,T.C_REMARK,A.* FROM TMC_TRAIN_MAIN T LEFT JOIN TMC_TRAIN_ITEM A ON A.C_PKID=T.C_ID WHERE 1=1";
            if (!string.IsNullOrEmpty(area))
            {
                strSql += $" AND A.C_AREA='{area}'";
            }
            if (!string.IsNullOrEmpty(empID))
            {
                strSql += $" AND T.C_EMPID='{empID}'";
            }
            if (!string.IsNullOrEmpty(custno))
            {
                strSql += $" AND A.C_CUSTNO='{custno}'";
            }
            if (!string.IsNullOrEmpty(plancode))
            {
                strSql += $" AND T.C_PLANNO='{plancode}'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND A.C_STL_GRD LIKE '%{stlgrd}%'";
            }

            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND A.C_CONNO LIKE '%{conno}%'";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql += $" AND (A.C_DH_COMPANY LIKE '%{cust}%' OR A.C_SH_COMPANY LIKE '%{cust}%')";
            }
            if (!string.IsNullOrEmpty(startDT) && !string.IsNullOrEmpty(endDT))
            {
                strSql += $@" AND T.D_DT BETWEEN TO_DATE('{startDT}', 'yyyy-mm-dd hh24:mi:ss') AND to_date('{endDT} 23:59:59', 'yyyy-mm-dd hh24:mi:ss')";
            }

            strSql += " ORDER BY T.D_DT ASC";
            return DbHelperOra.Query(strSql);
        }

        public void AddExportLog(string empName)
        {
            string strSql = $"INSERT INTO TMC_TRAIN_EXPORT_LOG(C_EMPNAME)VALUES('{empName}')";
            DbHelperOra.ExecuteSql(strSql);
        }
    }
}

