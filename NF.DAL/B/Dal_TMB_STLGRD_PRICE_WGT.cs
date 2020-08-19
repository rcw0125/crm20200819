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
    /// 地理区域
    /// </summary>
    public partial class Dal_TMB_STLGRD_PRICE_WGT
    {
        public Dal_TMB_STLGRD_PRICE_WGT()
        { }

        /// <summary>
        /// 销售组织
        /// </summary>
        /// <returns></returns>
        public DataSet GetSaleOrg()
        {
            string strSql = $"SELECT DISTINCT T.C_SALESORG FROM TMB_STLGRD_PRICE_WGT T";
            return DbHelperOra.Query(strSql);
        }


        /// <summary>
        /// 获取每月低毛利限量指标
        /// </summary>
        /// <param name="matname"></param>
        /// <param name="saleorg"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetMonth(string matname, string saleorg, string date, string spec)
        {
            string strSql = $@"SELECT *
                              FROM TMB_STLGRD_PRICE_WGT T
                             WHERE TO_CHAR(T.D_MONTH, 'YYYY-MM') = '{date}' ";
            if (!string.IsNullOrEmpty(matname))
            {
                strSql += $" AND T.C_MAT_GROUP_NAME  LIKE '%{matname}%'";
            }
            if (!string.IsNullOrEmpty(saleorg))
            {
                strSql += $" AND T.C_SALESORG = '{saleorg}'";
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql += $" AND {spec} >= T.C_SPEC_MIN  AND {spec} <= T.C_SPEC_MAX";
            }
            return DbHelperOra.Query(strSql);
        }
        /// <summary>
        /// 修改低毛利限量指标
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wgt"></param>
        /// <param name="empid"></param>
        /// <param name="empname"></param>
        /// <returns></returns>
        public bool UpdateMonthWgt(string id, string wgt, string empid, string empname)
        {
            string strsql = $"UPDATE TMB_STLGRD_PRICE_WGT SET N_WGT={wgt},C_EMPID='{empid}',C_EMPNAME='{empname}' WHERE C_ID='{id}'";
            return DbHelperOra.ExecuteSql(strsql) > 0 ? true : false;

        }


        /// <summary>
        /// 获取NC调价单
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetNCStlGrd(string date)
        {
            string strSql = $"SELECT * FROM TMB_STLGRD_PRICE T WHERE T.C_DAY='{date}'";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 生成当月低毛利限制指标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertMonthStlGrd(List<Mod_TMB_STLGRD_PRICE_WGT> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $@"INSERT INTO TMB_STLGRD_PRICE_WGT
                                      (D_MONTH,
                                       C_MAT_GROUP_CODE,
                                       C_MAT_GROUP_NAME,
                                       C_PROD_KIND,
                                       C_SPEC_MIN,
                                       C_SPEC_MAX,
                                       C_PRICE,
                                       C_MAOLI,
                                       C_COST,
                                       C_SALESORG,
                                       N_WGT,
                                       C_EMPID,
                                       C_EMPNAME)
                                    VALUES
                                      (TO_DATE('{item.D_MONTH}','yyyy-mm-dd hh24:mi:ss'),
                                       '{item.C_MAT_GROUP_CODE}',
                                       '{item.C_MAT_GROUP_NAME}',
                                       '{item.C_PROD_KIND}',
                                       '{item.C_SPEC_MIN}',
                                       '{item.C_SPEC_MAX}',
                                       '{item.C_PRICE}',
                                       '{item.C_MAOLI}',
                                       '{item.C_COST}',
                                       '{item.C_SALESORG}',
                                       {item.N_WGT},
                                       '{item.C_EMPID}',
                                       '{item.C_EMPNAME}')";
                arraySql.Add(strSql);
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 修改低毛利限量指标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateMonthWgt(List<Mod_TMB_STLGRD_PRICE_WGT> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                string strSql = $@"UPDATE TMB_STLGRD_PRICE_WGT SET N_WGT={item.N_WGT},C_EMPID='{item.C_EMPID}',C_EMPNAME='{item.C_EMPNAME}',D_DT=to_date('{DateTime.Now}','yyyy-mm-dd hh24:mi:ss') WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 检测每条订单是否低毛利
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <param name="date">合同生效起始日期</param>
        /// <returns></returns>
        public bool CheckMAOLI(string orderID, string matCode, string date)
        {

            Dal_TMO_ORDER dal = new Dal_TMO_ORDER();
            Mod_TMO_ORDER mod = dal.GetModel(orderID);

            ArrayList arraySql = new ArrayList();

            bool result = true;

            string strSql = $@"SELECT T.C_MAT_GROUP_CODE,T.C_SPEC, T.N_THK,NVL(A.C_FLAG,'N')C_FLAG
                                      FROM TB_MATRL_MAIN T LEFT JOIN TMB_MONI_STLGRD A ON A.C_STL_GRD = T.C_STL_GRD
                                     WHERE T.C_MAT_CODE = '{matCode}'";
            DataRow dr = DbHelperOra.GetDataRow(strSql);
            if (dr != null)
            {
                string flag = dr["C_FLAG"].ToString() == "N" ? "01" : "02";//判定是否监控钢种标识
                string matgroupcode = dr["C_MAT_GROUP_CODE"].ToString();//钢种物料组编码

                decimal num = 0;//监控钢种260，其他50
                decimal maoli = Convert.ToDecimal(mod.N_PROFIT);//毛利
                string spec = dr["N_THK"].ToString();//规格

                //监控钢种260，其他50
                string strSql2 = $"SELECT T.C_INDEX FROM TS_DIC T WHERE T.C_TYPECODE='MAOLI' AND  T.C_DETAILCODE='{flag}'";
                DataRow dr2 = DbHelperOra.GetDataRow(strSql2);
                if (dr2 != null)
                {
                    num = Convert.ToDecimal(dr2["C_INDEX"]);
                }

                if (maoli < num)//订单毛利低于配置毛利进行检测
                {
                    result = GetCheckMAOLI(date, matgroupcode, spec, matCode);
                }
            }

            return result;
        }

        /// <summary>
        /// 更新订单毛利/成本
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="maoli"></param>
        /// <param name="cost"></param>
        public void UpdateOrderMAOLI(string conno)
        {
            OracleParameter[] iDataParms = {
                new OracleParameter("v_conno", OracleDbType.Varchar2,100) };
            iDataParms[0].Value = conno;

            DbHelperOra.RunProcedure("PKG_NC_SJ.P_ORDER_MAOLI", iDataParms);
        }

        /// <summary>
        /// 判定合同签单量是否超出低毛利限量指标
        /// </summary>
        /// <param name="date">合同生效起始日期</param>
        /// <param name="matgroupcode">物料组编码</param>
        /// <param name="spec">规格</param>
        /// <param name="matCode">物料编码</param>
        /// <returns></returns>
        public bool GetCheckMAOLI(string date, string matgroupcode, string spec, string matCode)
        {
            bool result = true;

            decimal sumwgt = 0;//合同有效签单量
            decimal maoliwgt = 0;//低毛利限量指标

            string strsql5 = $@"SELECT T.N_WGT
                                              FROM TMB_STLGRD_PRICE_WGT T
                                             WHERE to_char(to_date(T.D_MONTH, 'yyyy-mm-dd hh24:mi:ss'), 'YYYY-MM')= TO_CHAR(to_date('{date}', 'yyyy-mm-dd hh24:mi:ss'), 'YYYY-MM')
                                               AND T.C_MAT_GROUP_CODE = '{matgroupcode}'
                                               AND {spec} >= T.C_SPEC_MIN
                                               AND {spec} <= T.C_SPEC_MAX";
            DataRow dr5 = DbHelperOra.GetDataRow(strsql5);
            if (dr5 != null)
            {
                maoliwgt = Convert.ToDecimal(dr5["N_WGT"]);
            }

            if (maoliwgt <= 0)
            {
                result = true;
            }
            else
            {
                #region //判定签单量是否超出低毛利限量指标

                string strSql4 = $@"SELECT NVL(SUM(T.N_WGT),0) N_WGT
                                                  FROM TMO_CON_ORDER T
                                                  LEFT JOIN TMO_CON A
                                                    ON A.C_CON_NO = T.C_CON_NO
                                                 WHERE TO_CHAR(TO_DATE(A.D_CONEFFE_DT, 'yyyy-mm-dd hh24:mi:ss'), 'YYYY-MM') = TO_CHAR(to_date('{date}', 'yyyy-mm-dd hh24:mi:ss'), 'YYYY-MM')
                                                   AND T.N_STATUS IN (1, 2)
                                                   AND T.C_MAT_CODE = '{matCode}'";
                DataRow dr4 = DbHelperOra.GetDataRow(strSql4);
                if (dr4 != null)
                {
                    sumwgt = Convert.ToDecimal(dr4["N_WGT"]);
                }

                if (sumwgt > maoliwgt)
                {
                    result = false;
                }
                #endregion
            }
            return result;
        }

        /// <summary>
        /// 低毛利订单录入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertMAOLI(List<Mod_TMO_LOWMAOLI_ORDER> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"INSERT INTO TMO_LOWMAOLI_ORDER
                                  (C_CUSTNAME,
                                   C_CONNO,
                                   C_ORDERNO,
                                   C_STLGRD,
                                   C_SPEC,
                                   C_MAOLI,
                                   N_WGT,
                                   C_EMPID,
                                   C_EMPNAME,
                                   D_CONSING_DT,
                                   D_CONEFFE_DT,
                                   C_SALEORG,
                                   N_PRICE,
                                   N_COSTPRICE)
                                VALUES
                                  ('{item.C_CUSTNAME}',
                                   '{item.C_CONNO}',
                                   '{item.C_ORDERNO}',
                                   '{item.C_STLGRD}',
                                   '{item.C_SPEC}',
                                   '{item.C_MAOLI}',
                                   {item.N_WGT},
                                   '{item.C_EMPID}',
                                   '{item.C_EMPNAME}',
                                   TO_DATE('{item.D_CONSING_DT}','yyyy-mm-dd hh24:mi:ss'),
                                   TO_DATE('{item.D_CONEFFE_DT}','yyyy-mm-dd hh24:mi:ss'),
                                   '{item.C_SALEORG}',
                                   {item.N_PRICE},
                                   {item.N_COSTPRICE})";
                arraySql.Add(strSql);
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        /// <summary>
        /// 获取低毛利订单
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="stlgrd"></param>
        /// <param name="saleorg"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetOrderMAOLI(string cust, string stlgrd, string saleorg, string date)
        {
            string strSql = "SELECT * FROM TMO_LOWMAOLI_ORDER WHERE 1=1";

            if (!string.IsNullOrEmpty(date))
            {
                strSql += $" AND TO_CHAR(TO_DATE(D_CONEFFE_DT,'yyyy-mm-dd hh24:mi:ss'),'YYYY-MM')=TO_CHAR(TO_DATE('{date}','yyyy-mm-dd hh24:mi:ss'),'YYYY-MM')";
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql += $" AND C_CUSTNAME LIKE '%{cust}%'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND UPPER(C_STLGRD) LIKE '%{stlgrd.ToUpper()}%'";
            }
            if (!string.IsNullOrEmpty(saleorg))
            {
                strSql += $" AND C_SALEORG= '{saleorg}'";
            }
            return DbHelperOra.Query(strSql);
        }



    }
}

