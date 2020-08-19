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
    /// 客户档案
    /// </summary>
    public partial class Dal_TS_CUST_SF
    {

        public Dal_TS_CUST_SF()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string custCode)
        {
            string strSql = $@"SELECT COUNT(1) FROM TS_CUSTFILE T WHERE T.C_NO='{custCode}'";

            return DbHelperOra.Exists(strSql.ToString());
        }

        /// <summary>
        /// 检查三方关系是否存在
        /// </summary>
        /// <param name="twoCustCode">二级客户</param>
        /// <param name="threeCustCode">三级客户</param>
        /// <returns></returns>
        public bool Exists(string twoCustCode, string threeCustCode)
        {
            string strSql = $@"SELECT COUNT(1) FROM TS_CUST_SF T WHERE T.C_CUSTCODE='{twoCustCode}' AND T.C_CUSTCODE_PARENT='{threeCustCode}'";

            return DbHelperOra.Exists(strSql.ToString());
        }

        /// <summary>
        /// 获取三方数据列表
        /// </summary>
        /// <param name="twoCustCode"></param>
        /// <param name="threeCustCode"></param>
        /// <returns></returns>
        public DataSet GetList(string twoCustCode, string threeCustCode)
        {
            string strSql = $@"SELECT T.C_ID,
                               (SELECT A.C_NAME FROM TS_CUSTFILE A WHERE A.C_NO = T.C_CUSTCODE) TWONAME,
                               (SELECT A.C_NAME
                                  FROM TS_CUSTFILE A
                                 WHERE A.C_NO = T.C_CUSTCODE_PARENT) THREENAME,
                               T.C_EMPNAME
                          FROM TS_CUST_SF T WHERE 1=1";
            if (!string.IsNullOrEmpty(twoCustCode))
            {
                strSql += $@" AND T.C_CUSTCODE_PARENT='{twoCustCode}'";
            }
            if (!string.IsNullOrEmpty(threeCustCode))
            {
                strSql += $@" AND T.C_CUSTCODE='{threeCustCode}'";
            }

            return DbHelperOra.Query(strSql);
        }

        public bool InsertList(Mod_TS_CUST_SF mod)
        {
            string strSql = $@"INSERT INTO TS_CUST_SF(C_CUSTCODE,C_CUSTCODE_PARENT,C_EMPNAME)VALUES(";
            strSql += $@"'{mod.C_CUSTCODE}',";
            strSql += $@"'{mod.C_CUSTCODE_PARENT}',";
            strSql += $@"'{mod.C_EMPNAME}'";
            strSql += ")";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        public bool DelList(List<Mod_TS_CUST_SF> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"DELETE FROM TS_CUST_SF T WHERE T.C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

    }
}

