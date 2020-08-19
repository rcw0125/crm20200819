using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NF.MODEL;
using NF.DAL;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 火运车皮计划执行情况
    /// </summary>
    public partial class Dal_TMD_HY_PLAN
    {
        public Dal_TMD_HY_PLAN() { }


        public bool Del(Mod_TMD_HY_PLAN mod)
        {
            string strSql = $@"DELETE FROM TMD_HY_PLAN T WHERE T.C_ID='{mod.C_ID}'";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }


        #region//获取火运计划

        public DataSet GetListFrist(string date)
        {
            string strSql = $@"SELECT * FROM TMD_HY_PLAN T
                                      WHERE T.D_DT >= TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{date} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')";
            return DbHelperOra.Query(strSql);
        }

        public DataSet GetList(string date)
        {
            string strSql = $@"SELECT TT.C_DETAILNAME,
                               TB.C_ID,
                               TB.C_TITLE,
                               TB.N_PLAN_NUM,
                               TB.N_END_NUM,
                               TB.N_START_NUM,
                               TB.N_ZT_NUM,
                               TB.C_REMARK,
                               TB.C_EMP_NAME,
                               TB.D_DT,
                               (CASE
                                 WHEN TB.C_ID IS NULL THEN
                                  'N'
                                 ELSE
                                  'Y'
                               END) C_TYPE
                          FROM (SELECT T.C_DETAILNAME
                                  FROM TS_DIC T
                                 WHERE T.C_TYPECODE = 'HYPlan'
                                 ORDER BY T.C_INDEX) TT
                          LEFT JOIN (
             
                                     SELECT T.C_ID,
                                             T.C_TITLE,
                                             T.N_PLAN_NUM,
                                             T.N_END_NUM,
                                             T.N_START_NUM,
                                             T.N_ZT_NUM,
                                             T.C_REMARK,
                                             T.C_EMP_NAME,
                                             T.D_DT
                                       FROM TMD_HY_PLAN T
                                      WHERE T.D_DT >= TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{date} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')) TB
                            ON TB.C_TITLE = TT.C_DETAILNAME";
            return DbHelperOra.Query(strSql);
        }

        #endregion

        #region 添加/更新

        /// <summary>
        /// 添加/更新
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(Mod_TMD_HY_PLAN mod)
        {
            StringBuilder strSql = new StringBuilder();

            if (mod.C_TYPE == "N")
            {
                #region //添加
                strSql.Append("INSERT INTO TMD_HY_PLAN(");
                strSql.Append("C_REMARK,");
                strSql.Append("C_EMP_NAME,");
                strSql.Append("D_DT");
                strSql.Append(")VALUES(");
                strSql.AppendFormat("'{0}',", mod.C_REMARK);//备注
                strSql.AppendFormat("'{0}',", mod.C_EMP_NAME);
                strSql.AppendFormat("to_date('{0}','yyyy-mm-dd hh24:mi:ss')", mod.D_DT);
                strSql.Append(")");

                #endregion
            }
            else
            {
                #region //更新

                strSql.AppendFormat("UPDATE TMD_HY_PLAN SET ");
                strSql.AppendFormat("C_REMARK='{0}',", mod.C_REMARK);
                strSql.AppendFormat("C_EMP_NAME='{0}'", mod.C_EMP_NAME);
                strSql.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);

                #endregion
            }

            return DbHelperOra.ExecuteSql(strSql.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 添加/更新
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(List<Mod_TMD_HY_PLAN> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    if (mod.C_TYPE == "N")
                    {
                        #region //添加
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("INSERT INTO TMD_HY_PLAN(");
                        strSql.Append("C_TITLE,");
                        strSql.Append("N_PLAN_NUM,");
                        strSql.Append("N_END_NUM,");
                        strSql.Append("N_ZT_NUM,");
                        strSql.Append("N_START_NUM,");
                        strSql.Append("C_REMARK,");
                        strSql.Append("C_EMP_NAME");

                        strSql.Append(")VALUES(");
                        strSql.AppendFormat("'{0}',", mod.C_TITLE);//名称
                        strSql.AppendFormat("{0},", mod.N_PLAN_NUM);//计划数
                        strSql.AppendFormat("{0},", mod.N_END_NUM);//已完成
                        strSql.AppendFormat("{0},", mod.N_ZT_NUM);//正装
                        strSql.AppendFormat("{0},", mod.N_START_NUM);//待装
                        strSql.AppendFormat("'{0}',", mod.C_REMARK);//备注
                        strSql.AppendFormat("'{0}'", mod.C_EMP_NAME);

                        strSql.Append(")");
                        arraySql.Add(strSql.ToString());
                        #endregion
                    }
                    else
                    {
                        #region //更新
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.AppendFormat("UPDATE TMD_HY_PLAN SET ");
                        strSql2.AppendFormat("N_PLAN_NUM={0},", mod.N_PLAN_NUM);
                        strSql2.AppendFormat("N_END_NUM={0},", mod.N_END_NUM);
                        strSql2.AppendFormat("N_ZT_NUM={0},", mod.N_ZT_NUM);
                        strSql2.AppendFormat("N_START_NUM={0},", mod.N_START_NUM);
                        strSql2.AppendFormat("C_REMARK='{0}',", mod.C_REMARK);
                        strSql2.AppendFormat("C_EMP_NAME='{0}'", mod.C_EMP_NAME);
                        strSql2.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
                        arraySql.Add(strSql2.ToString());
                        #endregion
                    }
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //批量删除火运计划
        public bool DelList(List<Mod_TMD_HY_PLAN> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    string strSql = $@"DELETE FROM TMD_HY_PLAN T WHERE T.C_ID='{mod.C_ID}'";
                    arraySql.Add(strSql);
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region//厂内车皮信息
        public DataTable GetListInfo(string date)
        {
            string cmdText = $@"SELECT T.C_ID, T.N_KC_NUM, T.N_ZC_NUM, T.N_YB_NUM, T.D_DT,'Y' C_TYPE
               FROM TMD_HY_INFO T
              WHERE T.D_DT >= TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                AND T.D_DT <=
                    TO_DATE('{date} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')";

            DataTable dt = DbHelperOra.Query(cmdText).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {

                string strSql = $@"SELECT TB.C_ID,
                               TB.N_KC_NUM,
                               TB.N_ZC_NUM,
                               TB.N_YB_NUM,
                               TB.D_DT,
                               (CASE
                                 WHEN TB.C_ID IS NULL THEN
                                  'N'
                                 ELSE
                                  'Y'
                               END) C_TYPE
                          FROM (SELECT '' C_ID FROM dual) T
                          LEFT JOIN (SELECT T.C_ID, T.N_KC_NUM, T.N_ZC_NUM, T.N_YB_NUM, T.D_DT
                                       FROM TMD_HY_INFO T
                                      WHERE T.D_DT >= TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{date} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')) TB
                            ON TB.C_ID = T.C_ID";
                return DbHelperOra.Query(strSql).Tables[0];


            }
        }

        #endregion

        #region 添加/更新/厂内车皮
        /// <summary>
        /// 添加/更新厂内车皮
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update_Info(List<Mod_TMD_HY_INFO> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    if (mod.C_TYPE == "N")
                    {
                        #region //添加
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("INSERT INTO TMD_HY_INFO(");

                        strSql.Append("N_KC_NUM,");
                        strSql.Append("N_ZC_NUM,");
                        strSql.Append("N_YB_NUM,");
                        strSql.Append("C_EMP_NAME");

                        strSql.Append(")VALUES(");

                        strSql.AppendFormat("{0},", mod.N_KC_NUM);//空车
                        strSql.AppendFormat("{0},", mod.N_ZC_NUM);//重车
                        strSql.AppendFormat("{0},", mod.N_YB_NUM);//到达预报
                        strSql.AppendFormat("'{0}'", mod.C_EMP_NAME);

                        strSql.Append(")");
                        arraySql.Add(strSql.ToString());
                        #endregion
                    }
                    else
                    {
                        #region //更新
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.AppendFormat("UPDATE TMD_HY_INFO SET ");
                        strSql2.AppendFormat("N_KC_NUM={0},", mod.N_KC_NUM);
                        strSql2.AppendFormat("N_ZC_NUM={0},", mod.N_ZC_NUM);
                        strSql2.AppendFormat("N_YB_NUM={0},", mod.N_YB_NUM);
                        strSql2.AppendFormat("C_EMP_NAME='{0}'", mod.C_EMP_NAME);
                        strSql2.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
                        arraySql.Add(strSql2.ToString());
                        #endregion
                    }
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region //批量删除厂内车皮
        public bool DelList_Info(List<Mod_TMD_HY_INFO> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    string strSql = $@"DELETE FROM TMD_HY_INFO T WHERE T.C_ID='{mod.C_ID}'";
                    arraySql.Add(strSql);
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion


        #region //销售出库

        public DataSet GetSaleOutList(string date)
        {
            string str = $@"---销售出库汇总
SELECT TT.MAXAREA,
       TT.AREA,
       T2.N_ZKWGT, --当日库存
       T3.N_YJWGT, --当日预警库存
       TA.ZZB,
       TA.N_KFY AS KFYL,
       TA.JKZB,
       TA.N_QYFY,
       TB.N_FYWGT,
       TC.QYCK,
       TD.HYCK,
       TE.SLABWGT,
       TF.JKWGT,
       TG.CRCK,
       TH.YJCK --预警出库
  FROM (SELECT decode(T.C_DETAILNAME,
                      '北方销售一部',
                      '北方',
                      '北方销售二部',
                      '北方',
                      '普碳钢销售部',
                      '北方',
                      '硬线销售部',
                      '北方',
                      '南方销售一部',
                      '南方',
                      '南方销售二部',
                      '南方',
                      '南方销售三部',
                      '南方',
                      '南方销售四部',
                      '南方',
                      '精特钢销售一部',
                      '精特',
                      '精特钢销售二部',
                      '精特',
                      '弹簧钢销售部',
                      '精特',
                      '纯铁销售部',
                      '精特') MAXAREA,
               T.C_DETAILNAME AS AREA
          FROM TS_DIC T
         WHERE T.C_TYPECODE = 'ConArea'
           AND T.C_DETAILCODE NOT IN ('6', '7', '10', '11','23')
         ORDER BY T.C_INDEX) TT

  LEFT JOIN (
             --当日库存
             SELECT SUM(T.N_WGT) N_ZKWGT, T.C_SALE_AREA AS AREA
               FROM TRD_ROLL_XCDRKC_INFO T
              WHERE T.D_MOD_DT >=
                    TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS') - 1
                AND T.D_MOD_DT <=
                    (TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS') - 1) + 1 -
                    1 / 86400)
              GROUP BY T.C_SALE_AREA) T2
    ON T2.AREA = TT.AREA

  LEFT JOIN (
             --当日预警库存
             SELECT SUM(T.N_WGT) N_YJWGT, T.C_SALE_AREA AS AREA
               FROM TRD_ROLL_XCDRKC_INFO T
               LEFT JOIN TMB_MONI_STLGRD M
                 ON M.C_STL_GRD = T.C_STL_GRD
               LEFT JOIN V_ROLL_XC2 V --钢种分类
                 ON V.C_MAT_CODE = T.C_MAT_CODE
              WHERE T.D_MOD_DT >=
                    TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS') - 1
                AND T.D_MOD_DT <=
                    (TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS') - 1) + 1 -
                    1 / 86400)
                AND (CASE
                      WHEN M.C_FLAG = 'Y' THEN --监控钢种开始算超期库存
                       CASE
                         WHEN CEIL(TO_DATE(TO_CHAR(SYSDATE, 'YYYY-MM-DD'),
                                           'YYYY-MM-DD') -
                                   TO_DATE(TO_CHAR((NVL(T.D_QR_DATE,
                                                        T.D_PRODUCE_DATE)),
                                                   'YYYY-MM-DD'),
                                           'YYYY-MM-DD')) >
                              (SELECT A.N_YJ_DAYS
                                 FROM TB_OVERDUE_CONFIGURE A
                                WHERE A.C_TYPE = '线材'
                                  AND A.C_STL_TYPE = '监控钢种') THEN
                          'Y'
                         ELSE
                          'N'
                       END
                    
                      ELSE --其他按钢种分类算超期库存
                       CASE
                         WHEN CEIL(TO_DATE(TO_CHAR(SYSDATE, 'YYYY-MM-DD'),
                                           'YYYY-MM-DD') -
                                   TO_DATE(TO_CHAR((NVL(T.D_QR_DATE,
                                                        T.D_PRODUCE_DATE)),
                                                   'YYYY-MM-DD'),
                                           'YYYY-MM-DD')) >
                              (SELECT A.N_YJ_DAYS
                                 FROM TB_OVERDUE_CONFIGURE A
                                WHERE A.C_TYPE = '线材'
                                  AND A.C_STL_TYPE = V.C_TYPE) THEN
                          'Y'
                         ELSE
                          'N'
                       END
                    
                    END) = 'Y'
              GROUP BY T.C_SALE_AREA) T3
    ON T3.AREA = TT.AREA

  LEFT JOIN (
             --当日库存， 总指标，监控指标，区域汽运需求
             SELECT T.N_ZKWGT,
                     T.N_WGT    AS ZZB,
                     (NVL(T.N_ZKWGT,0)-NVL(T.N_DPWGT,0)) N_KFY,--可发运量
                     T.N_FYJKZB AS JKZB,
                     T.N_QYFY,
                     T.C_DEPT   AS AREA
               FROM TMD_FYZB T
              WHERE T.D_DAY >= TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                AND T.D_DAY <=
                    (TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                    1 / 86400)) TA
    ON TA.AREA = TT.AREA
  LEFT JOIN (
             --汽运制单量
             SELECT SUM(T.N_FYWGT) N_FYWGT, T.C_AREA
               FROM (SELECT T.N_FYWGT AS N_FYWGT,
                             (SELECT MAX(A.C_AREA)
                                FROM TMO_CON_ORDER A
                               WHERE A.C_ORDER_NO = T.C_NO) C_AREA
                        FROM TMD_DISPATCHDETAILS T
                        LEFT JOIN TMD_DISPATCH B
                          ON B.C_ID = T.C_DISPATCH_ID
                       WHERE B.D_CREATE_DT >=
                             TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                         AND B.D_CREATE_DT <=
                             (TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                             1 / 86400)
                         AND B.C_SHIPVIA IN
                             ('0001NC10000000003ILR', '0001NC10000000003ILV')
                         AND B.C_STATUS IN ('3', '8')) T
              GROUP BY T.C_AREA) TB
    ON TB.C_AREA = TT.AREA
  LEFT JOIN (
             --汽运出库
             SELECT SUM(TT.N_JZ) QYCK, TT.AREA
               FROM (SELECT T.N_JZ,
                             (SELECT MAX(B.C_AREA)
                                FROM TMD_DISPATCHDETAILS A
                                LEFT JOIN TMO_CON_ORDER B
                                  ON B.C_ORDER_NO = A.C_NO
                               WHERE A.C_ID = T.C_PK_NCID) AREA
                        FROM TMD_DISPATCH_SJZJB T
                        LEFT JOIN TMD_DISPATCH A
                          ON A.C_ID = T.C_DISPATCH_ID
                       WHERE A.C_SHIPVIA IN
                             ('0001NC10000000003ILR', '0001NC10000000003ILV')
                         AND T.D_CKSJ >=
                             TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                         AND T.D_CKSJ <=
                             (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                             1 / 86400)) TT
              GROUP BY TT.AREA) TC
    ON TC.AREA = TT.AREA
  LEFT JOIN (
             --火运出库
             SELECT SUM(TT.N_JZ) HYCK, TT.AREA
               FROM (SELECT T.N_JZ,
                             (SELECT MAX(B.C_AREA)
                                FROM TMD_DISPATCHDETAILS A
                                LEFT JOIN TMO_CON_ORDER B
                                  ON B.C_ORDER_NO = A.C_NO
                               WHERE A.C_ID = T.C_PK_NCID) AREA
                        FROM TMD_DISPATCH_SJZJB T
                        LEFT JOIN TMD_DISPATCH A
                          ON A.C_ID = T.C_DISPATCH_ID
                       WHERE A.C_SHIPVIA IN ('0001NC10000000003ILQ')
                         AND T.D_CKSJ >=
                             TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                         AND T.D_CKSJ <=
                             (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                             1 / 86400)) TT
              GROUP BY TT.AREA) TD
    ON TD.AREA = TT.AREA
  LEFT JOIN (
             ---外销钢坯
             
             SELECT SUM(TT.N_JZ) SLABWGT, TT.AREA
               FROM (SELECT T.N_JZ,
                             (SELECT MAX(B.C_AREA)
                                FROM TMD_DISPATCHDETAILS A
                                LEFT JOIN TMO_CON_ORDER B
                                  ON B.C_ORDER_NO = A.C_NO
                               WHERE A.C_ID = T.C_PK_NCID) AREA
                      
                        FROM TMD_DISPATCH_SJZJB T
                       WHERE T.N_STATUS = 6
                         AND T.D_CKSJ >=
                             TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                         AND T.D_CKSJ <=
                             (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                             1 / 86400)) TT
              GROUP BY TT.AREA) TE
    ON TE.AREA = TT.AREA
  LEFT JOIN (
             --监控出库
             SELECT SUM(TT.N_JZ) JKWGT, TT.AREA
               FROM (SELECT T.N_JZ,
                             (SELECT MAX(B.C_AREA)
                                FROM TMD_DISPATCHDETAILS A
                                LEFT JOIN TMO_CON_ORDER B
                                  ON B.C_ORDER_NO = A.C_NO
                               WHERE A.C_ID = T.C_PK_NCID) AREA
                        FROM TMD_DISPATCH_SJZJB T
                        LEFT JOIN TMB_MONI_STLGRD M
                          ON M.C_STL_GRD = T.C_STL_GRD
                       WHERE M.C_FLAG = 'Y'
                         AND T.D_CKSJ >=
                             TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                         AND T.D_CKSJ <=
                             (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                             1 / 86400)) TT
              GROUP BY TT.AREA) TF
    ON TF.AREA = TT.AREA
  LEFT JOIN (
             --次日出库
             SELECT SUM(TT.N_JZ) CRCK, TT.AREA
               FROM (SELECT T.N_JZ,
                             (SELECT MAX(B.C_AREA)
                                FROM TMD_DISPATCHDETAILS A
                                LEFT JOIN TMO_CON_ORDER B
                                  ON B.C_ORDER_NO = A.C_NO
                               WHERE A.C_ID = T.C_PK_NCID) AREA
                        FROM TMD_DISPATCH_SJZJB T
                       where T.D_CKSJ >=
                             TO_DATE('{date} 00:00:00',
                                     'YYYY-MM-DD HH24:MI:SS') + 1
                         AND T.D_CKSJ <=
                             TO_DATE('{date} 08:00:00',
                                     'YYYY-MM-DD HH24:MI:SS') + 1) TT
              GROUP BY TT.AREA) TG
    ON TG.AREA = TT.AREA

  LEFT JOIN (
             --预警出库
             SELECT SUM(TT.N_JZ) YJCK, TT.AREA
               FROM (SELECT TMD.N_JZ,
                             TMD.AREA,
                             TMD.D_QR_DATE,
                             TMD.C_FLAG,
                             TMD.C_TYPE
                        FROM (SELECT T.N_JZ,
                                     (SELECT MAX(B.C_AREA)
                                        FROM TMD_DISPATCHDETAILS A
                                        LEFT JOIN TMO_CON_ORDER B
                                          ON B.C_ORDER_NO = A.C_NO
                                       WHERE A.C_ID = T.C_PK_NCID) AREA,
                                     (SELECT MAX(A.D_QR_DATE)
                                        FROM TRC_ROLL_PRODCUT A
                                       WHERE A.C_FYDH = T.C_DISPATCH_ID
                                         AND A.C_BATCH_NO = T.C_BATCH_NO
                                         AND A.C_MOVE_TYPE = 'S') D_QR_DATE,
                                     M.C_FLAG,
                                     v.C_TYPE
                                FROM TMD_DISPATCH_SJZJB T
                                LEFT JOIN TMB_MONI_STLGRD M
                                  ON M.C_STL_GRD = T.C_STL_GRD
                                LEFT JOIN V_ROLL_XC2 V --钢种分类
                                  ON V.C_MAT_CODE = T.C_MAT_CODE
                               where T.D_CKSJ >=
                                     TO_DATE('{date} 00:00:00',
                                             'YYYY-MM-DD HH24:MI:SS') + 1
                                 AND T.D_CKSJ <=
                                     TO_DATE('{date} 08:00:00',
                                             'YYYY-MM-DD HH24:MI:SS') + 1) TMD
                       WHERE (CASE
                               WHEN TMD.C_FLAG = 'Y' THEN --监控钢种开始算超期库存
                                CASE
                                  WHEN CEIL(TO_DATE(TO_CHAR(SYSDATE, 'YYYY-MM-DD'),
                                                    'YYYY-MM-DD') -
                                            TO_DATE(TO_CHAR(TMD.D_QR_DATE,
                                                            'YYYY-MM-DD'),
                                                    'YYYY-MM-DD')) >
                                       (SELECT A.N_YJ_DAYS
                                          FROM TB_OVERDUE_CONFIGURE A
                                         WHERE A.C_TYPE = '线材'
                                           AND A.C_STL_TYPE = '监控钢种') THEN
                                   'Y'
                                  ELSE
                                   'N'
                                END
                             
                               ELSE --其他按钢种分类算超期库存
                                CASE
                                  WHEN CEIL(TO_DATE(TO_CHAR(SYSDATE, 'YYYY-MM-DD'),
                                                    'YYYY-MM-DD') -
                                            TO_DATE(TO_CHAR(TMD.D_QR_DATE,
                                                            'YYYY-MM-DD'),
                                                    'YYYY-MM-DD')) >
                                       (SELECT A.N_YJ_DAYS
                                          FROM TB_OVERDUE_CONFIGURE A
                                         WHERE A.C_TYPE = '线材'
                                           AND A.C_STL_TYPE = TMD.C_TYPE) THEN
                                   'Y'
                                  ELSE
                                   'N'
                                END
                             
                             END) = 'Y') TT
              GROUP BY TT.AREA) TH
    ON TH.AREA = TT.AREA";
            return DbHelperOra.Query(str);
        }

        #endregion

    }
}
