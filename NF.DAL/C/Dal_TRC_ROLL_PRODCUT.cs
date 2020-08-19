using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TRC_ROLL_PRODCUT
    /// </summary>
    public partial class Dal_TRC_ROLL_PRODCUT
    {
        public Dal_TRC_ROLL_PRODCUT()
        { }


        /// <summary>
        /// 执行钢坯/线材库存类型type
        /// </summary>
        public void ExeProc()
        {
            DbHelperOra.RunProcedure("pkg_xc_drkc.p_tb_type", new OracleParameter[] { });
        }


        #region 获取钢坯产量
        /// <summary>
        /// 获取钢坯产量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetProdSlab(string date)
        {
            string strSql = $@"SELECT TT.C_TYPE,
       TT.N_WGT_MONTH,
       TT.N_WGT_DAY,
       TT.N_WGT_CK,
       DECODE(TT.C_TYPE,
              '普碳钢坯',
              'Y',
              '品种钢坯',
              'Y',
              '精品钢坯',
              'Y',
              'N') FLAG
  FROM (SELECT DECODE(A.C_FLAG, 'Y', '监控钢坯') C_TYPE,
               A.N_WGT_MONTH,
               B.N_WGT_DAY,
               C.N_WGT_CK
          FROM (SELECT M.C_FLAG, SUM(T.N_WGT) N_WGT_MONTH
                  FROM TSC_SLAB_MAIN T
                  LEFT JOIN TMB_MONI_STLGRD M
                    ON M.C_STL_GRD = T.C_STL_GRD
                 WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                   AND M.C_FLAG = 'Y'
                   AND C_SLAB_TYPE_R IS NOT NULL
                   AND SUBSTR(T.C_MAT_CODE, 0, 3) <> '614'
                      
                   AND T.D_CCM_DATE >=
                       TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                             'MONTH')
                   AND T.D_CCM_DATE <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)
                
                 GROUP BY M.C_FLAG) A
          LEFT JOIN (SELECT M.C_FLAG, SUM(T.N_WGT) N_WGT_DAY
                      FROM TSC_SLAB_MAIN T
                      LEFT JOIN TMB_MONI_STLGRD M
                        ON M.C_STL_GRD = T.C_STL_GRD
                     WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                       AND M.C_FLAG = 'Y'
                       AND C_SLAB_TYPE_R IS NOT NULL
                       AND SUBSTR(T.C_MAT_CODE, 0, 3) <> '614'
                       AND T.D_CCM_DATE >=
                           TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_CCM_DATE <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY M.C_FLAG) B
            ON A.C_FLAG = B.C_FLAG
          LEFT JOIN (SELECT M.C_FLAG, SUM(T.N_WGT) N_WGT_CK
                      FROM TRD_GPDRKC_INFO T
                      LEFT JOIN TMB_MONI_STLGRD M
                        ON M.C_STL_GRD = T.C_STL_GRD
                     WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                       AND M.C_FLAG = 'Y'
                       AND T.C_SLAB_TYPE IS NOT NULL
                       AND T.D_MOD_DT >=
                           to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_MOD_DT <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY M.C_FLAG) C
            ON A.C_FLAG = C.C_FLAG
        union all
        SELECT A.C_SLAB_TYPE_R AS C_TYPE,
               A.N_WGT_MONTH,
               B.N_WGT_DAY,
               C.N_WGT_CK
          FROM (SELECT T.C_SLAB_TYPE_R, SUM(T.N_WGT) N_WGT_MONTH
                  FROM TSC_SLAB_MAIN T
                 WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                   AND C_SLAB_TYPE_R IS NOT NULL
                   AND SUBSTR(T.C_MAT_CODE, 0, 3) <> '614'
                   AND T.D_CCM_DATE >=
                       TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                             'MONTH')
                   AND T.D_CCM_DATE <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)
                 GROUP BY C_SLAB_TYPE_R) A
          LEFT JOIN (SELECT T.C_SLAB_TYPE_R, SUM(T.N_WGT) N_WGT_DAY
                      FROM TSC_SLAB_MAIN T
                     WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                       AND C_SLAB_TYPE_R IS NOT NULL
                       AND SUBSTR(T.C_MAT_CODE, 0, 3) <> '614'
                       AND T.D_CCM_DATE >=
                           TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_CCM_DATE <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY C_SLAB_TYPE_R) B
            ON A.C_SLAB_TYPE_R = B.C_SLAB_TYPE_R
          LEFT JOIN (SELECT DECODE(T.C_TYPE,
                                  '品种钢',
                                  '品种钢坯',
                                  '普碳钢',
                                  '普碳钢坯',
                                  '精品钢',
                                  '精品钢坯') C_TYPE,
                           SUM(T.N_WGT) N_WGT_CK
                      FROM TRD_GPDRKC_INFO T
                     WHERE T.C_MAT_NAME NOT LIKE '%工模具钢%'
                       AND T.C_SLAB_TYPE IS NOT NULL
                       AND T.D_MOD_DT >=
                           to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_MOD_DT <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY DECODE(T.C_TYPE,
                                     '品种钢',
                                     '品种钢坯',
                                     '普碳钢',
                                     '普碳钢坯',
                                     '精品钢',
                                     '精品钢坯')) C
            ON A.C_SLAB_TYPE_R = C.C_TYPE) TT
 ORDER BY DECODE(TT.C_TYPE,
                 '监控钢坯',
                 '5',
                 '普碳钢坯',
                 1,
                 '品种钢坯',
                 2,
                 '精品钢坯',
                 3,
                 4)";

            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region 获取线材产量
        /// <summary>
        /// 获取线材产量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetProdRoll(string date)
        {
            string strSql = $@"SELECT TT.C_TYPE,
       TT.N_WGT_MONTH,
       TT.N_WGT_DAY,
       TT.N_WGT_CK,
       DECODE(TT.C_TYPE,
              '普碳线材',
              'Y',
              '品种线材',
              'Y',
              '精品线材',
              'Y',
              'N') FLAG
  FROM (SELECT decode(A.C_FLAG, 'Y', '监控线材') C_TYPE,
               A.N_WGT as N_WGT_MONTH,
               B.N_WGT as N_WGT_DAY,
               C.N_WGT AS N_WGT_CK
          FROM (SELECT M.C_FLAG, SUM(T.N_WGT) N_WGT
                  FROM TRC_ROLL_PRODCUT T
                  LEFT JOIN TMB_MONI_STLGRD M
                    ON M.C_STL_GRD = T.C_STL_GRD
                 WHERE T.C_TYPE IS NOT NULL
                   AND M.C_FLAG = 'Y'
                   AND T.C_TYPE NOT IN ('不锈钢')
                      
                   AND T.D_PRODUCE_DATE >=
                       TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                             'MONTH')
                   AND T.D_PRODUCE_DATE <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)
                
                 GROUP BY M.C_FLAG) A
          LEFT JOIN (SELECT M.C_FLAG, SUM(T.N_WGT) N_WGT
                      FROM TRC_ROLL_PRODCUT T
                      LEFT JOIN TMB_MONI_STLGRD M
                        ON M.C_STL_GRD = T.C_STL_GRD
                     WHERE T.C_TYPE IS NOT NULL
                       AND M.C_FLAG = 'Y'
                       AND T.C_TYPE NOT IN ('不锈钢')
                       AND T.D_PRODUCE_DATE >=
                           TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_PRODUCE_DATE <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                    
                     GROUP BY M.C_FLAG) B
            ON B.C_FLAG = A.C_FLAG
          LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, M.C_FLAG
                      FROM TRD_ROLL_XCDRKC_INFO T
                      LEFT JOIN TMB_MONI_STLGRD M
                        ON M.C_STL_GRD = T.C_STL_GRD
                     WHERE T.C_TYPE NOT IN ('不锈钢')
                       AND T.C_TYPE IS NOT NULL
                       AND M.C_FLAG = 'Y'
                       AND T.D_MOD_DT >=
                           to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_MOD_DT <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY M.C_FLAG) C
            ON C.C_FLAG = A.C_FLAG
        union all
        SELECT decode(A.C_TYPE,
                      '普碳钢',
                      '普碳线材',
                      '高速线材',
                      '品种线材',
                      '精品线材') C_TYPE,
               A.N_WGT as N_WGT_MONTH,
               B.N_WGT as N_WGT_DAY,
               C.N_WGT AS N_WGT_CK
          FROM (SELECT T.C_TYPE, SUM(T.N_WGT) N_WGT
                  FROM TRC_ROLL_PRODCUT T
                 WHERE T.C_TYPE IS NOT NULL
                   AND T.C_TYPE NOT IN ('不锈钢')
                      
                   AND T.D_PRODUCE_DATE >=
                       TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                             'MONTH')
                   AND T.D_PRODUCE_DATE <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)
                
                 GROUP BY T.C_TYPE) A
          LEFT JOIN (
                    
                    SELECT SUM(T.N_WGT) N_WGT, T.C_TYPE
                      FROM TRC_ROLL_PRODCUT T
                     WHERE T.C_TYPE NOT IN ('不锈钢')
                       AND T.C_TYPE IS NOT NULL
                          
                       AND T.D_PRODUCE_DATE >=
                           TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_PRODUCE_DATE <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                    
                     GROUP BY T.C_TYPE) B
            ON B.C_TYPE = A.C_TYPE
          LEFT JOIN (SELECT SUM(T.N_WGT) N_WGT, T.C_TYPE
                      FROM TRD_ROLL_XCDRKC_INFO T
                     WHERE T.C_TYPE NOT IN ('不锈钢')
                       AND T.C_TYPE IS NOT NULL
                       AND T.D_MOD_DT >=
                           to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND T.D_MOD_DT <=
                           (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                     GROUP BY T.C_TYPE) C
            ON C.C_TYPE = A.C_TYPE) TT
 ORDER BY DECODE(TT.C_TYPE,
                 '监控线材',
                 5,
                 '普碳线材',
                 2,
                 '品种线材',
                 3,
                 '精品线材',
                 4)";
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region //获取汽运/火运线材销量
        /// <summary>
        /// 获取汽运/火运线材销量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetSaleShip(string date)
        {
            string strSql = $@"SELECT D.C_SHIPVIA AS C_TYPE, D.N_WGT_MONTH, E.N_WGT_DAY, G.N_WGT_CK
  FROM (SELECT SUM(C.N_WGT) N_WGT_MONTH,
                DECODE(C.C_SHIPVIA,
                       '0001NC10000000003ILV',
                       '汽运',
                       '0001NC10000000003ILR',
                       '汽运',
                       '0001NC10000000003ILQ',
                       '火运') C_SHIPVIA
           FROM (SELECT T.N_WGT,
                        (SELECT MAX(A.C_SHIPVIA)
                           FROM TMD_DISPATCH A
                          WHERE A.C_ID = T.C_FYDH) C_SHIPVIA,
                        (SELECT MAX(B.D_CKSJ)
                           FROM TMD_DISPATCH_SJZJB B
                          WHERE B.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                   FROM TRC_ROLL_PRODCUT T
                  WHERE T.C_MOVE_TYPE = 'S'
                    AND T.C_TYPE NOT IN ('不锈钢')) C
          WHERE
         
          C.D_CKSJ >=TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                     'MONTH')
       AND C.D_CKSJ <= (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
          1 / 86400)
         
          GROUP BY DECODE(C.C_SHIPVIA,
                          '0001NC10000000003ILV',
                          '汽运',
                          '0001NC10000000003ILR',
                          '汽运',
                          '0001NC10000000003ILQ',
                          '火运')) D
  LEFT JOIN (SELECT SUM(C.N_WGT) N_WGT_DAY,
                    DECODE(C.C_SHIPVIA,
                           '0001NC10000000003ILV',
                           '汽运',
                           '0001NC10000000003ILR',
                           '汽运',
                           '0001NC10000000003ILQ',
                           '火运') C_SHIPVIA
               FROM (SELECT T.N_WGT,
                            (SELECT MAX(A.C_SHIPVIA)
                               FROM TMD_DISPATCH A
                              WHERE A.C_ID = T.C_FYDH) C_SHIPVIA,
                            (SELECT MAX(B.D_CKSJ)
                               FROM TMD_DISPATCH_SJZJB B
                              WHERE B.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                       FROM TRC_ROLL_PRODCUT T
                      WHERE T.C_MOVE_TYPE = 'S'
                        AND T.C_TYPE NOT IN ('不锈钢')) C
              WHERE C.D_CKSJ >=
                    TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                AND C.D_CKSJ <=
                    (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                    1 / 86400)
             
              GROUP BY DECODE(C.C_SHIPVIA,
                              '0001NC10000000003ILV',
                              '汽运',
                              '0001NC10000000003ILR',
                              '汽运',
                              '0001NC10000000003ILQ',
                              '火运')) E
    ON E.C_SHIPVIA = D.C_SHIPVIA
  LEFT JOIN (SELECT SUM(C.N_WGT) N_WGT_CK,
                    DECODE(C.C_SHIPVIA,
                           '0001NC10000000003ILV',
                           '汽运',
                           '0001NC10000000003ILR',
                           '汽运',
                           '0001NC10000000003ILQ',
                           '火运') C_SHIPVIA
               FROM (SELECT T.N_WGT,
                            (SELECT MAX(A.C_SHIPVIA)
                               FROM TMD_DISPATCH A
                              WHERE A.C_ID = T.C_FYDH) C_SHIPVIA,
                            (SELECT MAX(B.D_CKSJ)
                               FROM TMD_DISPATCH_SJZJB B
                              WHERE B.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                       FROM TRC_ROLL_PRODCUT T
                      WHERE T.C_MOVE_TYPE = 'S'
                        AND T.C_TYPE NOT IN ('不锈钢')) C
              WHERE C.D_CKSJ >=
                    TO_DATE('{date} 00:00:00', 'YYYY-MM-DD HH24:MI:SS') + 1
                AND C.D_CKSJ <=
                    TO_DATE('{date} 07:00:00', 'YYYY-MM-DD HH24:MI:SS') + 1
              GROUP BY DECODE(C.C_SHIPVIA,
                              '0001NC10000000003ILV',
                              '汽运',
                              '0001NC10000000003ILR',
                              '汽运',
                              '0001NC10000000003ILQ',
                              '火运')) G
    ON G.C_SHIPVIA = D.C_SHIPVIA";
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region //获取线材销量
        public DataSet GetSaleRoll(string date)
        {
            string strSql = $@"SELECT TT.C_TYPE,
       TT.N_WGT_MONTH,
       TT.N_WGT_DAY,
       TT.N_WGT_CK,
       DECODE(TT.C_TYPE,
              '普碳线材',
              'Y',
              '品种线材',
              'Y',
              '精品线材',
              'Y',
              'N') FLAG
  FROM (SELECT DECODE(C.C_TYPE, 'Y', '监控线材') C_TYPE,
               C.N_WGT_MONTH,
               D.N_WGT_DAY,
               E.N_WGT_CK
          FROM (SELECT B.C_FLAG as C_TYPE, SUM(B.N_WGT) N_WGT_MONTH
                   FROM (select T.N_WGT,
                                M.C_FLAG,
                                (SELECT MAX(A.D_CKSJ)
                                   FROM TMD_DISPATCH_SJZJB A
                                  WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                           from trc_roll_prodcut t
                           LEFT JOIN TMB_MONI_STLGRD M
                             ON M.C_STL_GRD = T.C_STL_GRD
                          where t.c_move_type = 'S'
                            AND M.C_FLAG = 'Y'
                            and t.C_TYPE NOT IN ('不锈钢')) B
                  WHERE
                 
                  B.D_CKSJ >=TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                     'MONTH')
               AND B.D_CKSJ <=
                  (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                  1 / 86400)
                 
                  GROUP BY B.C_FLAG) C
          LEFT JOIN (SELECT B.C_FLAG as C_TYPE, SUM(B.N_WGT) N_WGT_DAY
                      FROM (select T.N_WGT,
                                   M.C_FLAG,
                                   (SELECT MAX(A.D_CKSJ)
                                      FROM TMD_DISPATCH_SJZJB A
                                     WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                              from trc_roll_prodcut t
                              LEFT JOIN TMB_MONI_STLGRD M
                                ON M.C_STL_GRD = T.C_STL_GRD
                             where t.c_move_type = 'S'
                               AND M.C_FLAG = 'Y'
                               and t.C_TYPE NOT IN ('不锈钢')) B
                     WHERE
                    
                     B.D_CKSJ >=
                     TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                 AND B.D_CKSJ <=
                     (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                     1 / 86400)
                    
                     GROUP BY B.C_FLAG) D
            ON D.C_TYPE = C.C_TYPE
          LEFT JOIN (SELECT B.C_FLAG as C_TYPE, SUM(B.N_WGT) N_WGT_CK
                      FROM (select T.N_WGT,
                                   M.C_FLAG,
                                   (SELECT MAX(A.D_CKSJ)
                                      FROM TMD_DISPATCH_SJZJB A
                                     WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                              from trc_roll_prodcut t
                              LEFT JOIN TMB_MONI_STLGRD M
                                ON M.C_STL_GRD = T.C_STL_GRD
                             where t.c_move_type = 'S'
                               AND M.C_FLAG = 'Y'
                               and t.C_TYPE NOT IN ('不锈钢')) B
                     WHERE B.D_CKSJ >=
                           TO_DATE('{date} 00:00:00',
                                   'YYYY-MM-DD HH24:MI:SS') + 1
                       AND B.D_CKSJ <=
                           TO_DATE('{date} 07:00:00',
                                   'YYYY-MM-DD HH24:MI:SS') + 1
                     GROUP BY B.C_FLAG) E
            ON E.C_TYPE = C.C_TYPE
        UNION ALL
        SELECT DECODE(C.C_TYPE,
                      '普碳钢',
                      '普碳线材',
                      '高速线材',
                      '品种线材',
                      '精品线材') C_TYPE,
               C.N_WGT_MONTH,
               D.N_WGT_DAY,
               E.N_WGT_CK
          FROM (SELECT B.C_TYPE, SUM(B.N_WGT) N_WGT_MONTH
                  FROM (select T.N_WGT,
                               T.C_TYPE,
                               (SELECT MAX(A.D_CKSJ)
                                  FROM TMD_DISPATCH_SJZJB A
                                 WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                          from trc_roll_prodcut t
                         where t.c_move_type = 'S') B
                 WHERE B.C_TYPE NOT IN ('不锈钢')
                   and
                      
                       B.D_CKSJ >=TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                     'MONTH')
                   AND B.D_CKSJ <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)
                
                 GROUP BY B.C_TYPE) C
          LEFT JOIN (SELECT B.C_TYPE, SUM(B.N_WGT) N_WGT_DAY
                      FROM (select T.N_WGT,
                                   T.C_TYPE,
                                   (SELECT MAX(A.D_CKSJ)
                                      FROM TMD_DISPATCH_SJZJB A
                                     WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                              from trc_roll_prodcut t
                             where t.c_move_type = 'S') B
                     WHERE B.C_TYPE NOT IN ('不锈钢')
                       and
                          
                           B.D_CKSJ >=
                           TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                       AND B.D_CKSJ <= (TRUNC(to_date('{date}',
                                                      'YYYY-MM-DD HH24:MI:SS')) + 1 -
                           1 / 86400)
                    
                     GROUP BY B.C_TYPE) D
            ON D.C_TYPE = C.C_TYPE
          LEFT JOIN (SELECT B.C_TYPE, SUM(B.N_WGT) N_WGT_CK
                      FROM (select T.N_WGT,
                                   T.C_TYPE,
                                   (SELECT MAX(A.D_CKSJ)
                                      FROM TMD_DISPATCH_SJZJB A
                                     WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ
                              from trc_roll_prodcut t
                             where t.c_move_type = 'S') B
                     WHERE B.D_CKSJ >=
                           TO_DATE('{date} 00:00:00',
                                   'YYYY-MM-DD HH24:MI:SS') + 1
                       AND B.D_CKSJ <=
                           TO_DATE('{date} 07:00:00',
                                   'YYYY-MM-DD HH24:MI:SS') + 1
                     GROUP BY B.C_TYPE) E
            ON E.C_TYPE = C.C_TYPE) TT
 ORDER BY DECODE(TT.C_TYPE,
                 '监控线材',
                 4,
                 '普碳线材',
                 1,
                 '品种线材',
                 2,
                 '精品线材',
                 3)";
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region //获取钢坯销量
        /// <summary>
        /// 获取钢坯销量
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetSaleSlab(string date)
        {
            string strSql = $@"SELECT DECODE(TT.C_AREA,
              '国际贸易部',
              '外销出口钢坯',
              '纯铁销售部',
              '外销纯铁钢坯',
              '北方普碳区域',
              '外销普碳钢坯') C_TYPE,
       TA.N_WGT_MONTH,
       TB.N_WGT_DAY,
       TC.N_WGT_CK
  FROM (SELECT T.C_DETAILNAME AS C_AREA
          FROM TS_DIC T
         WHERE T.C_TYPECODE = 'ConArea'
           AND T.C_DETAILNAME IN ('国际贸易部', '纯铁销售部', '北方普碳区域')
         ORDER BY T.C_INDEX) TT
  LEFT JOIN (SELECT SUM(T2.N_JWGT) N_WGT_MONTH, T2.C_AREA
               FROM (SELECT TA.N_JWGT, TA.C_AREA, TA.D_CKSJ
                        FROM (SELECT T.N_JWGT,
                                     TB.C_AREA,
                                     (SELECT MAX(A.D_CKSJ)
                                        FROM TMD_DISPATCH_SJZJB A
                                       WHERE A.C_DISPATCH_ID = T.C_DISPATCH_ID) D_CKSJ
                                FROM TMD_DISPATCHDETAILS T
                                LEFT JOIN TMO_CON_ORDER TB
                                  ON TB.C_ORDER_NO = T.C_NO
                               WHERE T.C_ORDER_TYPE = '6') TA
                       WHERE
                      
                       TA.D_CKSJ >=TRUNC(TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS'),
                     'MONTH')
                    AND TA.D_CKSJ <=
                       (TRUNC(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)) T2
              GROUP BY T2.C_AREA) TA
    ON TA.C_AREA = TT.C_AREA

  LEFT JOIN (SELECT SUM(T2.N_JWGT) N_WGT_DAY, T2.C_AREA
               FROM (SELECT TA.N_JWGT, TA.C_AREA, TA.D_CKSJ
                       FROM (SELECT T.N_JWGT,
                                    TB.C_AREA,
                                    (SELECT MAX(A.D_CKSJ)
                                       FROM TMD_DISPATCH_SJZJB A
                                      WHERE A.C_DISPATCH_ID = T.C_DISPATCH_ID) D_CKSJ
                               FROM TMD_DISPATCHDETAILS T
                               LEFT JOIN TMO_CON_ORDER TB
                                 ON TB.C_ORDER_NO = T.C_NO
                              WHERE T.C_ORDER_TYPE = '6') TA
                      WHERE TA.D_CKSJ >=
                            TO_DATE('{date}', 'YYYY-MM-DD HH24:MI:SS')
                        AND TA.D_CKSJ <= (TRUNC(to_date('{date}',
                                                        'YYYY-MM-DD HH24:MI:SS')) + 1 -
                            1 / 86400)) T2
              GROUP BY T2.C_AREA) TB
    ON TB.C_AREA = TT.C_AREA
  LEFT JOIN (SELECT SUM(T2.N_JWGT) N_WGT_CK, T2.C_AREA
               FROM (SELECT TA.N_JWGT, TA.C_AREA, TA.D_CKSJ
                       FROM (SELECT T.N_JWGT,
                                    TB.C_AREA,
                                    (SELECT MAX(A.D_CKSJ)
                                       FROM TMD_DISPATCH_SJZJB A
                                      WHERE A.C_DISPATCH_ID = T.C_DISPATCH_ID) D_CKSJ
                               FROM TMD_DISPATCHDETAILS T
                               LEFT JOIN TMO_CON_ORDER TB
                                 ON TB.C_ORDER_NO = T.C_NO
                              WHERE T.C_ORDER_TYPE = '6') TA
                      WHERE TA.D_CKSJ >=
                            TO_DATE('{date} 00:00:00',
                                    'YYYY-MM-DD HH24:MI:SS')
                        AND TA.D_CKSJ <=
                            TO_DATE('{date} 07:00:00',
                                    'YYYY-MM-DD HH24:MI:SS')) T2
              GROUP BY T2.C_AREA) TC
    ON TC.C_AREA = TT.C_AREA";
            return DbHelperOra.Query(strSql);
        }
        #endregion


        #region //远程质证书



        public DataSet GetZZSList(string fyd, string zsh)
        {
            string strSql = $@"SELECT * FROM TQC_ZZS_INFO T WHERE T.C_FYDH='{fyd}' AND T.C_ZSH='{zsh}'";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 质证打印行数
        /// </summary>
        /// <param name="stlgrd"></param>
        /// <param name="std"></param>
        /// <returns></returns>
        public string GetZZSPrintRowNum(string stlgrd, string std)
        {
            string strSql = $@"SELECT T.N_ROWNUM FROM TQB_ZZS_PRINT_ROWNUM T WHERE T.C_STL_GRD='{stlgrd}' AND T.C_STD_CODE='{std}'";

            object obj = DbHelperOra.GetSingle(strSql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "6";
            }
        }
        public string GetZZSType(string stlgrd, string std)
        {
            string strSql = $@"SELECT T.C_MODLE_TYPE FROM TQB_ZZS_PRINT_MODLE T WHERE T.C_STL_GRD='{stlgrd}' AND T.C_STD_CODE='{std}'";

            object obj = DbHelperOra.GetSingle(strSql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "1";
            }
        }

        /// <summary>
        /// 获取出库发运单
        /// </summary>
        /// <param name="ch">车号</param>
        /// <param name="custName">客户名称</param>
        /// <param name="fyd">发运单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批号</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库结束时间</param>
        /// <param name="ww">委外</param>
        /// <param name="type">8线材，6钢坯</param>
        /// <returns></returns>

        public DataSet GetZZS(string ch, string custName, string fyd, string stlGrd, string spec, string batch, string startDate, string endDate, string ww, string type, string stove, string printstate)
        {
            StringBuilder strSql = new StringBuilder();

            if (type == "6")
            {
                #region //钢坯
                strSql.Append(@"SELECT TT.C_FYDH, --发运单
                                   TT.C_BATCH_NO, --批次
                                   TT.C_STOVE, --炉号
                                   TT.C_SPEC, --规格
                                   TT.C_STL_GRD, --钢种
                                   TT.C_STD_CODE, --执行标准
                                   TT.C_MAT_DESC, --物料名称
                                   TT.C_JUDGE_LEV_ZH, --质量等级
                                   TT.C_ZSH, --证书号
                                   TT.C_PDF_PATCH,
                                   TT.C_QZR, --审核人
                                   TT.D_QZRQ, --审核时间     
                                   TT.D_CKSJ, --出库时间
                                   TT.C_CH, --车号
                                   TT.C_CUST_NAME, --客户名称
                                   TT.C_CGC, --收货单位
                                   TT.ZDR, --制单人
                                   TT.C_PRINT_EMP,
                                   TT.D_PRINT_DT,
                                   TT.N_PRINT_NUM,
                                   TT.N_WGT, --重量
                                   TT.QUA, --件数
                                   '6' AS C_TYPE,
                                   TT.C_ZYX1,
                                   TT.C_ZYX2,
                                   TT.C_JH_STATE,
                                   TT.C_XKZH,
                                   TT.C_TECH_PROT,
                                   TT.C_CON_NO
                              FROM (SELECT T.C_DISPATCH_ID AS C_FYDH, --发运单
                                           T.C_BATCH_NO, --批次
                                           T.C_STOVE, --炉号
                                           T.C_SPEC, --规格
                                           T.C_STL_GRD, --钢种
                                           T.C_STD_CODE, --执行标准
                                           T.C_MAT_NAME AS C_MAT_DESC, --物料名称
                                           T.C_ZLDJ AS C_JUDGE_LEV_ZH, --质量等级              
                                           TA.C_ZSH, --证书号
                                           TA.C_QZR, --审核人
                                           TA.D_QZRQ, --审核时间
                                           TA.C_PRINT_EMP,
                                           TA.D_PRINT_DT,
                                           TA.N_PRINT_NUM,
                                           TA.C_PDF_PATCH,
                                           T.D_CKSJ, --出库时间
                                           T.N_JZ AS N_WGT, --重量
                                           T.N_NUM AS QUA, --发运支数
                                           B.C_LIC_PLA_NO AS C_CH, --车牌号
                                           (SELECT A.C_ORGO_CUST
                                              FROM TMD_DISPATCHDETAILS A
                                             WHERE A.C_ID = T.C_PK_NCID) C_CUST_NAME, --订货单位
                                           (SELECT A.C_CGC
                                              FROM TMD_DISPATCHDETAILS A
                                             WHERE A.C_ID = T.C_PK_NCID) AS C_CGC, --收货单位
                                           (SELECT MAX(A.C_NAME)
                                              FROM TS_USER A
                                             WHERE A.C_ID = B.C_CREATE_ID) ZDR, --制单人
                                           (SELECT MAX(A.C_FREE_TERM)
                                              FROM TMD_DISPATCHDETAILS A
                                             WHERE A.C_ID = T.C_PK_NCID) AS C_ZYX1, --自由项1
                                           (SELECT MAX(A.C_FREE_TERM2)
                                              FROM TMD_DISPATCHDETAILS A
                                             WHERE A.C_ID = T.C_PK_NCID) AS C_ZYX2, --自由项2
                                           (SELECT MAX(A.C_REMARK1)
                                              FROM TB_MATRL_MAIN A
                                             WHERE A.C_ID = T.C_MAT_CODE
                                               AND A.C_REMARK1 IS NOT NULL) AS C_JH_STATE, --交货状态
                                           (SELECT DECODE(MAX(A.C_REMARK3),
                                                          NULL,
                                                          '',
                                                          '许可证号:' || MAX(A.C_REMARK3))
                                              FROM TB_MATRL_MAIN A
                                             WHERE A.C_ID = T.C_MAT_CODE
                                               AND A.C_REMARK3 IS NOT NULL) AS C_XKZH, --许可证号
                                           (SELECT MAX(B.C_TECH_PROT)
                                              FROM TMD_DISPATCHDETAILS A
                                              LEFT JOIN TMO_CON_ORDER B
                                                ON B.C_ORDER_NO = A.C_NO
                                             WHERE A.C_ID = T.C_PK_NCID) C_TECH_PROT, --客户协议
                                           (SELECT MAX(A.C_CON_NO)
                                              FROM TMD_DISPATCHDETAILS A
                                             WHERE A.C_ID = T.C_PK_NCID) C_CON_NO --合同号        
                                      FROM TMD_DISPATCH_SJZJB T
                                      LEFT JOIN TMD_DISPATCH B
                                        ON B.C_ID = T.C_DISPATCH_ID
                                      LEFT JOIN TQC_ZZS_INFO TA
                                        ON TA.C_FYDH = T.C_DISPATCH_ID
                                       AND (TA.C_BATCH_NO = T.C_BATCH_NO OR TA.C_STOVE=T.C_STOVE)
                                     WHERE T.N_STATUS = 6
                                       AND B.C_STATUS = '9') TT
                             WHERE 1 = 1 AND TT.C_JUDGE_LEV_ZH='合格品'");

                if (!string.IsNullOrEmpty(ch))
                {
                    strSql.AppendFormat(" AND TT.C_CH LIKE '%{0}%'", ch);
                }
                if (!string.IsNullOrEmpty(custName))
                {
                    strSql.AppendFormat(" AND TT.C_CUST_NAME LIKE '%{0}%'", custName);
                }
                if (!string.IsNullOrEmpty(fyd))
                {
                    strSql.AppendFormat(" AND TT.C_FYDH LIKE '%{0}%'", fyd);
                }
                if (!string.IsNullOrEmpty(stlGrd))
                {
                    strSql.AppendFormat(" AND UPPER(TT.C_STL_GRD) LIKE '%{0}%'", stlGrd.ToUpper());
                }
                if (!string.IsNullOrEmpty(spec))
                {
                    strSql.AppendFormat(" AND TT.C_SPEC LIKE '%{0}%'", spec);
                }
                if (!string.IsNullOrEmpty(batch))
                {
                    strSql.AppendFormat(" AND TT.C_BATCH_NO LIKE '%{0}%'", batch);
                }
                if (!string.IsNullOrEmpty(stove))
                {
                    strSql.AppendFormat(" AND TT.C_STOVE LIKE '%{0}%'", stove);
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    strSql.AppendFormat(@" AND TT.D_CKSJ>=TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') AND TT.D_CKSJ<=(TRUNC(to_date('{1}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)", startDate, endDate);
                }
                if (!string.IsNullOrEmpty(printstate))
                {
                    if (printstate == "0")
                    {
                        strSql.AppendFormat(" AND TT.D_PRINT_DT IS NULL");
                    }
                    if (printstate == "1")
                    {
                        strSql.AppendFormat(" AND TT.D_PRINT_DT IS NOT  NULL");
                    }
                }

                #endregion
            }
            else
            {
                if (ww == "Y")
                {
                    #region //委外
                    strSql.Append(@"SELECT TT.C_FYDH, --发运单
                                   TT.C_BATCH_NO, --批次
                                   TT.C_STOVE, --炉号
                                   TT.C_SPEC, --规格
                                   TT.C_STL_GRD, --钢种
                                   TT.C_STD_CODE, --执行标准
                                   TT.C_MAT_DESC, --物料名称
                                   TT.C_JUDGE_LEV_ZH, --质量等级
                                   TT.C_ZSH, --证书号
                                   TT.C_PDF_PATCH,
                                   TT.C_QZR, --审核人
                                   TT.D_QZRQ, --审核时间     
                                   TT.D_CKSJ, --出库时间
                                   TT.C_CH, --车号
                                   TT.C_CUST_NAME, --客户名称
                                   TT.C_CGC, --收货单位
                                   TT.ZDR, --制单人
                                   TT.C_PRINT_EMP,
                                   TT.D_PRINT_DT,
                                   TT.N_PRINT_NUM,
                                   TT.N_WGT, --重量
                                   TT.QUA, --件数
                                   '8' AS C_TYPE,
                                   TT.C_ZYX1,
                                   TT.C_ZYX2,
                                   TT.C_JH_STATE,
                                   TT.C_XKZH,
                                   TT.C_TECH_PROT,
                                   TT.C_CON_NO
                              FROM (SELECT T.C_DISPATCH_ID AS C_FYDH, --发运单
                                           T.C_BATCH_NO, --批次
                                           (SELECT MAX(C.C_STOVE)
                                              FROM TRC_ROLL_PRODCUT C
                                             WHERE C.C_FYDH = T.C_DISPATCH_ID
                                               AND T.C_BATCH_NO = C.C_BATCH_NO
                                               AND C.C_STL_GRD = T.C_STL_GRD
                                               AND C.C_STD_CODE = T.C_STD_CODE) C_STOVE, --炉号
                                           T.C_SPEC, --规格
                                           T.C_STL_GRD, --钢种
                                           T.C_STD_CODE, --执行标准
                                           T.C_MAT_NAME AS C_MAT_DESC, --物料名称
                                           T.C_JUDGE_LEV_ZH, --质量等级              
                                           TA.C_ZSH, --证书号
                                           TA.C_QZR, --审核人
                                           TA.D_QZRQ, --审核时间
                                           TA.C_PRINT_EMP,
                                           TA.D_PRINT_DT,
                                           TA.N_PRINT_NUM,
                                           TA.C_PDF_PATCH,
                                           B.D_CREATE_DT AS D_CKSJ, --出库时间
                                           T.N_FYWGT AS N_WGT, --重量
                                           T.N_FYZS AS QUA, --发运支数
                                           B.C_LIC_PLA_NO AS C_CH, --车牌号
                                           T.C_ORGO_CUST AS C_CUST_NAME, --订货单位
                                           T.C_CGC, --收货单位
                                           (SELECT MAX(A.C_NAME)
                                              FROM TS_USER A
                                             WHERE A.C_ID = B.C_CREATE_ID) ZDR, --制单人
                                           T.C_FREE_TERM AS C_ZYX1, --自由项1
                                           T.C_FREE_TERM2 AS C_ZYX2, --自由项2
                                           (SELECT MAX(A.C_REMARK1)
                                              FROM TB_MATRL_MAIN A
                                             WHERE A.C_ID = T.C_MAT_CODE
                                               AND A.C_REMARK1 IS NOT NULL) AS C_JH_STATE, --交货状态
                                           (SELECT DECODE(MAX(A.C_REMARK3),
                                                          NULL,
                                                          '',
                                                          '许可证号:' || MAX(A.C_REMARK3))
                                              FROM TB_MATRL_MAIN A
                                             WHERE A.C_ID = T.C_MAT_CODE
                                               AND A.C_REMARK3 IS NOT NULL) AS C_XKZH, --许可证号
                                           (SELECT MAX(B.C_TECH_PROT)
                                              FROM TMO_CON_ORDER B
                                             WHERE B.C_ORDER_NO = T.C_NO) C_TECH_PROT, --客户协议
                                           T.C_CON_NO --合同号
        
                                      FROM TMD_DISPATCHDETAILS T
                                      LEFT JOIN TMD_DISPATCH B
                                        ON B.C_ID = T.C_DISPATCH_ID
                                      LEFT JOIN TQC_ZZS_INFO TA
                                        ON TA.C_FYDH = T.C_DISPATCH_ID
                                       AND TA.C_BATCH_NO = T.C_BATCH_NO
        
                                     WHERE T.C_ORDER_TYPE IN ('805', '806', '807')
                                       AND B.C_STATUS = '8') TT
                             WHERE 1 = 1 AND TT.C_JUDGE_LEV_ZH <> 'D' ");

                    if (!string.IsNullOrEmpty(ch))
                    {
                        strSql.AppendFormat(" AND TT.C_CH LIKE '%{0}%'", ch);
                    }
                    if (!string.IsNullOrEmpty(custName))
                    {
                        strSql.AppendFormat(" AND TT.C_CUST_NAME LIKE '%{0}%'", custName);
                    }
                    if (!string.IsNullOrEmpty(fyd))
                    {
                        strSql.AppendFormat(" AND TT.C_FYDH LIKE '%{0}%'", fyd);
                    }
                    if (!string.IsNullOrEmpty(stlGrd))
                    {
                        strSql.AppendFormat(" AND  UPPER(TT.C_STL_GRD) LIKE '%{0}%'", stlGrd.ToUpper());
                    }
                    if (!string.IsNullOrEmpty(spec))
                    {
                        strSql.AppendFormat(" AND TT.C_SPEC LIKE '%{0}%'", spec);
                    }
                    if (!string.IsNullOrEmpty(batch))
                    {
                        strSql.AppendFormat(" AND TT.C_BATCH_NO LIKE '%{0}%'", batch);
                    }
                    if (!string.IsNullOrEmpty(stove))
                    {
                        strSql.AppendFormat(" AND TT.C_STOVE LIKE '%{0}%'", stove);
                    }

                    if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                    {
                        strSql.AppendFormat(@" AND TT.D_CKSJ>=TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') AND TT.D_CKSJ<=(TRUNC(to_date('{1}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)", startDate, endDate);
                    }

                    if (!string.IsNullOrEmpty(printstate))
                    {
                        if (printstate == "0")
                        {
                            strSql.AppendFormat(" AND TT.D_PRINT_DT IS NULL");
                        }
                        if (printstate == "1")
                        {
                            strSql.AppendFormat(" AND TT.D_PRINT_DT IS NOT  NULL");
                        }
                    }
                    #endregion
                }
                else
                {
                    #region//线材场内


                    strSql.Append(@"SELECT TT.C_FYDH, --发运单
                                       TT.C_BATCH_NO, --批次
                                       TT.C_STOVE, --炉号
                                       TT.C_SPEC, --规格
                                       TT.C_STL_GRD, --钢种
                                       TT.C_STD_CODE, --执行标准
                                       TT.C_MAT_DESC, --物料名称
                                       TT.C_JUDGE_LEV_ZH, --质量等级
                                       TT.C_ZSH, --证书号
                                       TT.C_PDF_PATCH,
                                       TT.C_QZR, --审核人
                                       TT.D_QZRQ, --审核时间     
                                       TT.D_CKSJ, --出库时间
                                       TT.C_CH, --车号
                                       TT.C_CUST_NAME, --客户名称
                                       TT.C_CGC, --收货单位
                                       TT.ZDR, --制单人
                                       TT.C_PRINT_EMP,
                                       TT.D_PRINT_DT,
                                       TT.N_PRINT_NUM,
                                       TT.N_WGT, --重量
                                       TT.QUA, --件数
                                       '8' AS C_TYPE,
                                       TT.C_ZYX1,
                                       TT.C_ZYX2,
                                       TT.C_JH_STATE,
                                       TT.C_XKZH,
                                       TT.C_TECH_PROT,
                                       TT.C_CON_NO
                                  FROM (SELECT T.C_DISPATCH_ID AS C_FYDH, --发运单
                                               T.C_BATCH_NO, --批次
                                               (SELECT MAX(C.C_STOVE)
                                                  FROM TRC_ROLL_PRODCUT C
                                                 WHERE C.C_FYDH = T.C_DISPATCH_ID
                                                   AND T.C_BATCH_NO = C.C_BATCH_NO
                                                   AND C.C_STL_GRD = T.C_STL_GRD
                                                   AND C.C_STD_CODE = T.C_STD_CODE) C_STOVE, --炉号
                                               T.C_SPEC, --规格
                                               T.C_STL_GRD, --钢种
                                               T.C_STD_CODE, --执行标准
                                               T.C_MAT_NAME AS C_MAT_DESC, --物料名称
                                               T.C_ZLDJ AS C_JUDGE_LEV_ZH, --质量等级              
                                               TA.C_ZSH, --证书号
                                               TA.C_QZR, --审核人
                                               TA.D_QZRQ, --审核时间
                                               TA.C_PRINT_EMP,
                                               TA.D_PRINT_DT,
                                               TA.N_PRINT_NUM,
                                               TA.C_PDF_PATCH,
                                               T.D_CKSJ, --出库时间
                                               T.N_JZ AS N_WGT, --重量
                                               T.N_NUM AS QUA, --发运支数
                                               B.C_LIC_PLA_NO AS C_CH, --车牌号
                                               (SELECT A.C_ORGO_CUST
                                                  FROM TMD_DISPATCHDETAILS A
                                                 WHERE A.C_ID = T.C_PK_NCID) C_CUST_NAME, --订货单位
                                               (SELECT A.C_CGC
                                                  FROM TMD_DISPATCHDETAILS A
                                                 WHERE A.C_ID = T.C_PK_NCID) AS C_CGC, --收货单位
                                               (SELECT MAX(A.C_NAME)
                                                  FROM TS_USER A
                                                 WHERE A.C_ID = B.C_CREATE_ID) ZDR, --制单人     
                                               (SELECT MAX(A.C_FREE_TERM)
                                                  FROM TMD_DISPATCHDETAILS A
                                                 WHERE A.C_ID = T.C_PK_NCID) AS C_ZYX1, --自由项1
                                               (SELECT MAX(A.C_FREE_TERM2)
                                                  FROM TMD_DISPATCHDETAILS A
                                                 WHERE A.C_ID = T.C_PK_NCID) AS C_ZYX2, --自由项2
                                               (SELECT MAX(A.C_REMARK1)
                                                  FROM TB_MATRL_MAIN A
                                                 WHERE A.C_ID = T.C_MAT_CODE
                                                   AND A.C_REMARK1 IS NOT NULL) AS C_JH_STATE, --交货状态
                                               (SELECT DECODE(MAX(A.C_REMARK3),
                                                              NULL,
                                                              '',
                                                              '许可证号:' || MAX(A.C_REMARK3))
                                                  FROM TB_MATRL_MAIN A
                                                 WHERE A.C_ID = T.C_MAT_CODE
                                                   AND A.C_REMARK3 IS NOT NULL) AS C_XKZH, --许可证号
                                               (SELECT MAX(B.C_TECH_PROT)
                                                  FROM TMD_DISPATCHDETAILS A
                                                  LEFT JOIN TMO_CON_ORDER B
                                                    ON B.C_ORDER_NO = A.C_NO
                                                 WHERE A.C_ID = T.C_PK_NCID) C_TECH_PROT, --客户协议
                                               (SELECT MAX(A.C_CON_NO)
                                                  FROM TMD_DISPATCHDETAILS A
                                                 WHERE A.C_ID = T.C_PK_NCID) C_CON_NO --合同号
                                          FROM TMD_DISPATCH_SJZJB T
                                          LEFT JOIN TMD_DISPATCH B
                                            ON B.C_ID = T.C_DISPATCH_ID
                                          LEFT JOIN TQC_ZZS_INFO TA
                                            ON TA.C_FYDH = T.C_DISPATCH_ID
                                           AND TA.C_BATCH_NO = T.C_BATCH_NO
                                         WHERE T.N_STATUS = 8
                                           AND B.C_STATUS = '8') TT
                                 WHERE 1 = 1 AND TT.C_JUDGE_LEV_ZH <> 'D'");
                    if (!string.IsNullOrEmpty(ch))
                    {
                        strSql.AppendFormat(" AND TT.C_CH LIKE '%{0}%'", ch);
                    }
                    if (!string.IsNullOrEmpty(custName))
                    {
                        strSql.AppendFormat(" AND TT.C_CUST_NAME LIKE '%{0}%'", custName);
                    }
                    if (!string.IsNullOrEmpty(fyd))
                    {
                        strSql.AppendFormat(" AND TT.C_FYDH LIKE '%{0}%'", fyd);
                    }
                    if (!string.IsNullOrEmpty(stlGrd))
                    {
                        strSql.AppendFormat(" AND  UPPER(TT.C_STL_GRD) LIKE '%{0}%'", stlGrd.ToUpper());
                    }
                    if (!string.IsNullOrEmpty(spec))
                    {
                        strSql.AppendFormat(" AND TT.C_SPEC LIKE '%{0}%'", spec);
                    }
                    if (!string.IsNullOrEmpty(batch))
                    {
                        strSql.AppendFormat(" AND TT.C_BATCH_NO LIKE '%{0}%'", batch);
                    }
                    if (!string.IsNullOrEmpty(stove))
                    {
                        strSql.AppendFormat(" AND TT.C_STOVE LIKE '%{0}%'", stove);
                    }
                    if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                    {
                        strSql.AppendFormat(@" AND TT.D_CKSJ>=TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') AND TT.D_CKSJ<=(TRUNC(to_date('{1}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)", startDate, endDate);
                    }
                    if (!string.IsNullOrEmpty(stove))
                    {
                        strSql.AppendFormat(" AND TT.C_STOVE LIKE '%{0}%'", stove);
                    }
                    if (!string.IsNullOrEmpty(printstate))
                    {
                        if (printstate == "0")
                        {
                            strSql.AppendFormat(" AND TT.D_PRINT_DT IS NULL");
                        }
                        if (printstate == "1")
                        {
                            strSql.AppendFormat(" AND TT.D_PRINT_DT IS NOT  NULL");
                        }
                    }

                    #endregion
                }
            }



            return DbHelperOra.Query(strSql.ToString());
        }




        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string zyx1, string zyx2)
        {
            string strSql = $@"SELECT MAX((NVL(T.C_ZZS, SUBSTR(T.C_ZYX1, INSTR(T.C_ZYX1, '~') + 1)))) C_STD_JH, --交货标准
                                   MAX((DECODE(T.C_FLAG, 'Y', '技术协议:' || T.C_CUST_TECH_PROT, ''))) C_JSXYH --技术协议
                              FROM TB_STD_CONFIG T
                             WHERE 1 = 1
                                  -- AND T.C_CUST_NO = '130582953'
                               AND T.C_STD_CODE = '{stdCode}'
                               AND T.C_STL_GRD = '{stlGrd}'
                               AND T.C_ZYX1 = '{zyx1}'
                               AND T.C_ZYX2 = '{zyx2}'";


            return TransactionHelper.Query(strSql);
        }

        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string techProt, string zyx1, string zyx2)
        {
            string strSql = $@"SELECT MAX((NVL(T.C_ZZS, SUBSTR(T.C_ZYX1, INSTR(T.C_ZYX1, '~') + 1)))) C_STD_JH, --交货标准
                                   MAX((DECODE(T.C_FLAG, 'Y', '技术协议:' || T.C_CUST_TECH_PROT, ''))) C_JSXYH --技术协议
                              FROM TB_STD_CONFIG T
                             WHERE 1 = 1
                                  -- AND T.C_CUST_NO = '130582953'
                               AND T.C_STD_CODE = '{stdCode}'
                               AND T.C_STL_GRD = '{stlGrd}'
                               AND T.C_ZYX1 = '{zyx1}'
                               AND T.C_ZYX2 = '{zyx2}'";

            if (!string.IsNullOrEmpty(techProt))
            {
                strSql += $@" AND T.C_CUST_TECH_PROT = '{techProt}'";
            }
            return TransactionHelper.Query(strSql);
        }

        public bool ExistsZZS(string fyd, string batch)
        {
            string strSql = $@"select count(1) from tqc_zzs_info t where t.c_fydh='{fyd}' and t.c_batch_no='{batch}'";
            return DbHelperOra.Exists(strSql);
        }

        public bool ExistsZZS(string fyd, string batch, string stove)
        {
            string strSql = $@"SELECT COUNT(1) FROM TQC_ZZS_INFO T WHERE T.C_FYDH='{fyd}' AND (T.C_BATCH_NO='{batch}' OR T.C_STOVE='{stove}') ";
            return DbHelperOra.Exists(strSql);
        }

        #endregion

        #region //添加远程质证书


        public bool InsertZZS(Mod_TQC_ZZS_INFO item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TQC_ZZS_INFO(");
            strSql.Append("C_FYDH,");
            strSql.Append("C_BATCH_NO,");
            strSql.Append("C_STOVE,");
            strSql.Append("C_SPEC,");
            strSql.Append("C_STL_GRD,");
            strSql.Append("C_STD_CODE,");
            strSql.Append("D_CKSJ,");
            strSql.Append("N_JZ,");
            strSql.Append("N_NUM,");
            strSql.Append("C_CH,");
            strSql.Append("C_ZSH,");
            strSql.Append("C_QZR,");
            strSql.Append("C_IMG,");
            strSql.Append("C_CUST_NO,");
            strSql.Append("C_CON_NO,");
            strSql.Append("C_SH_NAME,");//收货单位名称
            strSql.Append("C_MAT_NAME,");//产品名称
            strSql.Append("C_STD_JH,");//交货标准
            strSql.Append("C_ZLDJ,");//质量等级
            strSql.Append("C_JH_STATE,");//交货状态
            strSql.Append("C_JSXYH,");//技术协议号
            strSql.Append("C_XKZH,"); //许可证号
            strSql.Append("C_BY1,"); //类型
            strSql.Append("C_CUST_NAME");//订货单位
            strSql.Append(")VALUES(");
            strSql.AppendFormat("'{0}',", item.C_FYDH);
            strSql.AppendFormat("'{0}',", item.C_BATCH_NO);
            strSql.AppendFormat("'{0}',", item.C_STOVE);
            strSql.AppendFormat("'{0}',", item.C_SPEC);
            strSql.AppendFormat("'{0}',", item.C_STL_GRD);
            strSql.AppendFormat("'{0}',", item.C_STD_CODE);
            strSql.AppendFormat("to_date('{0}','YYYY-MM-DD HH24:MI:SS'),", item.D_CKSJ);
            strSql.AppendFormat("{0},", item.N_JZ);
            strSql.AppendFormat("{0},", item.N_NUM);
            strSql.AppendFormat("'{0}',", item.C_CH);
            strSql.AppendFormat("'{0}',", item.C_ZSH);
            strSql.AppendFormat("'{0}',", item.C_QZR);
            strSql.AppendFormat("'{0}',", item.C_IMG);
            strSql.AppendFormat("'{0}',", item.C_CUST_NO);
            strSql.AppendFormat("'{0}',", item.C_CON_NO);
            strSql.AppendFormat("'{0}',", item.C_SH_NAME);//收货单位名称
            strSql.AppendFormat("'{0}',", item.C_MAT_NAME);//产品名称
            strSql.AppendFormat("'{0}',", item.C_STD_JH);//交货标准
            strSql.AppendFormat("'{0}',", item.C_ZLDJ);//质量等级
            strSql.AppendFormat("'{0}',", item.C_JH_STATE);//交货状态
            strSql.AppendFormat("'{0}',", item.C_JSXYH);//技术协议号
            strSql.AppendFormat("'{0}',", item.C_XKZH); //许可证号
            strSql.AppendFormat("'{0}',", item.C_BY1); //类型
            strSql.AppendFormat("'{0}'", item.C_CUST_NAME);
            strSql.Append(")");

            return DbHelperOra.ExecuteSql(strSql.ToString()) > 0 ? true : false;
        }
        #endregion


        #region //更新远程客户打印次数
        /// <summary>
        /// 更新证书号PDF
        /// </summary>
        /// <param name="fyd"></param>
        /// <param name="zsh"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool UpdateZZSPDF(string fyd, string zsh, string path)
        {
            string strSql = $@"UPDATE TQC_ZZS_INFO SET C_PDF_PATCH='{path}' WHERE C_FYDH='{fyd}'  AND C_ZSH='{zsh}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        public bool UpdateZZSPrint(string fyd, string zsh)
        {
            string strSql = $@"UPDATE TQC_ZZS_INFO SET N_PRINT_NUM=0  WHERE C_FYDH='{fyd}'  AND C_ZSH='{zsh}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        public bool UpdateZZSPrint(string fyd, string zsh, string emp)
        {
            string strSql = $@"UPDATE TQC_ZZS_INFO SET N_PRINT_NUM=N_PRINT_NUM+1,C_PRINT_EMP='{emp}',D_PRINT_DT=TO_DATE('{DateTime.Now.ToString()}','yyyy-MM-dd HH24:mi:ss') WHERE C_FYDH='{fyd}'  AND C_ZSH='{zsh}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }
        #endregion

        #region //获取证书号打印次数

        public int GetPrintNum(string zsh)
        {
            string strSql = $@"SELECT N_PRINT_NUM FROM TQC_ZZS_INFO WHERE C_ZSH='{zsh}'";

            object obj = DbHelperOra.GetSingle(strSql);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region //客户获取自己远程打印信息

        public DataSet GetCustZZS(string fyd, string zsh, string batch, string ch, string conNO, string startDate, string endDate, string custNo, string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT *  FROM TQC_ZZS_INFO WHERE 1=1");


            if (!string.IsNullOrEmpty(custNo))
            {
                strSql.AppendFormat(" AND C_CUST_NO='{0}'", custNo);
            }
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND C_FYDH='{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(zsh))
            {
                strSql.AppendFormat(" AND C_ZSH='{0}'", zsh);
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND C_BATCH_NO='{0}'", batch);
            }
            if (!string.IsNullOrEmpty(ch))
            {
                strSql.AppendFormat(" AND C_CH LIKE '%{0}%'", ch);
            }
            if (!string.IsNullOrEmpty(conNO))
            {
                strSql.AppendFormat(" AND C_CON_NO LIKE '%{0}%'", conNO);
            }
            if (!string.IsNullOrEmpty(type))
            {
                strSql.AppendFormat(" AND C_BY1 = '{0}'", type);
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.AppendFormat(@" AND D_CKSJ>=TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') AND D_CKSJ<=(TRUNC(to_date('{1}', 'YYYY-MM-DD HH24:MI:SS')) + 1 -
                       1 / 86400)", startDate, endDate);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion


        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_PRODCUT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_PRODCUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_PRODCUT(");
            strSql.Append("C_ID,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_EMP_ID,D_MOD_DT,C_STA_ID,C_JUDGE_LEV_BP,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_ZH,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_BZYQ,C_WWBATCH_NO,C_ZYX1,C_ZYX2,C_IS_QR,D_PRODUCE_DATE)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_TRC_ROLL_MAIN_ID,:C_STOVE,:C_BATCH_NO,:C_TICK_NO,:C_STL_GRD,:C_STL_GRD_BEFORE,:N_WGT,:C_STD_CODE,:C_STD_CODE_BEFORE,:C_MOVE_TYPE,:C_SPEC,:C_SHIFT,:C_GROUP,:C_EMP_ID,:D_MOD_DT,:C_STA_ID,:C_JUDGE_LEV_BP,:C_JUDGE_LEV_CF,:C_JUDGE_LEV_XN,:C_JUDGE_LEV_ZH,:C_DP_SHIFT,:C_DP_GROUP,:C_DP_EMP_ID,:D_DP_DT,:C_PLANT_ID,:C_PLANT_DESC,:C_MAT_CODE,:C_MAT_CODE_BEFORE,:C_MAT_DESC,:C_MAT_DESC_BEFORE,:C_IS_DEPOT,:C_PLAN_ID,:C_ORDER_NO,:C_CON_NO,:C_CUST_NO,:C_CUST_NAME,:C_ISFREE,:C_LINEWH_CODE,:C_LINEWH_AREA_CODE,:C_LINEWH_LOC_CODE,:C_FLOOR,:C_CUST_AREA,:C_SALE_AREA,:C_BZYQ,:C_WWBATCH_NO,:C_ZYX1,:C_ZYX2,'Y',:D_PRODUCE_DATE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TRC_ROLL_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,3),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_CF", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_XN", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_SHIFT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_GROUP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_DP_DT", OracleDbType.Date),
                    new OracleParameter(":C_PLANT_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PLANT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_LINEWH_AREA_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_LINEWH_LOC_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_FLOOR", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_CUST_AREA", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SALE_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_WWBATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE",OracleDbType.Date),
            };
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_TRC_ROLL_MAIN_ID;
            parameters[2].Value = model.C_STOVE;
            parameters[3].Value = model.C_BATCH_NO;
            parameters[4].Value = model.C_TICK_NO;
            parameters[5].Value = model.C_STL_GRD;
            parameters[6].Value = model.C_STL_GRD_BEFORE;
            parameters[7].Value = model.N_WGT;
            parameters[8].Value = model.C_STD_CODE;
            parameters[9].Value = model.C_STD_CODE_BEFORE;
            parameters[10].Value = model.C_MOVE_TYPE;
            parameters[11].Value = model.C_SPEC;
            parameters[12].Value = model.C_SHIFT;
            parameters[13].Value = model.C_GROUP;
            parameters[14].Value = model.C_EMP_ID;
            parameters[15].Value = model.D_MOD_DT;
            parameters[16].Value = model.C_STA_ID;
            parameters[17].Value = model.C_JUDGE_LEV_BP;
            parameters[18].Value = model.C_JUDGE_LEV_CF;
            parameters[19].Value = model.C_JUDGE_LEV_XN;
            parameters[20].Value = model.C_JUDGE_LEV_ZH;
            parameters[21].Value = model.C_DP_SHIFT;
            parameters[22].Value = model.C_DP_GROUP;
            parameters[23].Value = model.C_DP_EMP_ID;
            parameters[24].Value = model.D_DP_DT;
            parameters[25].Value = model.C_PLANT_ID;
            parameters[26].Value = model.C_PLANT_DESC;
            parameters[27].Value = model.C_MAT_CODE;
            parameters[28].Value = model.C_MAT_CODE_BEFORE;
            parameters[29].Value = model.C_MAT_DESC;
            parameters[30].Value = model.C_MAT_DESC_BEFORE;
            parameters[31].Value = model.C_IS_DEPOT;
            parameters[32].Value = model.C_PLAN_ID;
            parameters[33].Value = model.C_ORDER_NO;
            parameters[34].Value = model.C_CON_NO;
            parameters[35].Value = model.C_CUST_NO;
            parameters[36].Value = model.C_CUST_NAME;
            parameters[37].Value = model.C_ISFREE;
            parameters[38].Value = model.C_LINEWH_CODE;
            parameters[39].Value = model.C_LINEWH_AREA_CODE;
            parameters[40].Value = model.C_LINEWH_LOC_CODE;
            parameters[41].Value = model.C_FLOOR;
            parameters[42].Value = model.C_CUST_AREA;
            parameters[43].Value = model.C_SALE_AREA;
            parameters[44].Value = model.C_BZYQ;
            parameters[45].Value = model.C_WWBATCH_NO;
            parameters[46].Value = model.C_ZYX1;
            parameters[47].Value = model.C_ZYX2;
            parameters[48].Value = DateTime.Parse(DateTime.Today.ToShortDateString());

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
        public bool Update(Mod_TRC_ROLL_PRODCUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_PRODCUT set ");
            strSql.Append("C_TRC_ROLL_MAIN_ID=:C_TRC_ROLL_MAIN_ID,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_TICK_NO=:C_TICK_NO,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_STL_GRD_BEFORE=:C_STL_GRD_BEFORE,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_STD_CODE_BEFORE=:C_STD_CODE_BEFORE,");
            strSql.Append("C_MOVE_TYPE=:C_MOVE_TYPE,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_SHIFT=:C_SHIFT,");
            strSql.Append("C_GROUP=:C_GROUP,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_JUDGE_LEV_BP=:C_JUDGE_LEV_BP,");
            strSql.Append("C_JUDGE_LEV_CF=:C_JUDGE_LEV_CF,");
            strSql.Append("C_JUDGE_LEV_XN=:C_JUDGE_LEV_XN,");
            strSql.Append("C_JUDGE_LEV_ZH=:C_JUDGE_LEV_ZH,");
            strSql.Append("C_DP_SHIFT=:C_DP_SHIFT,");
            strSql.Append("C_DP_GROUP=:C_DP_GROUP,");
            strSql.Append("C_DP_EMP_ID=:C_DP_EMP_ID,");
            strSql.Append("D_DP_DT=:D_DP_DT,");
            strSql.Append("C_PLANT_ID=:C_PLANT_ID,");
            strSql.Append("C_PLANT_DESC=:C_PLANT_DESC,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_CODE_BEFORE=:C_MAT_CODE_BEFORE,");
            strSql.Append("C_MAT_DESC=:C_MAT_DESC,");
            strSql.Append("C_MAT_DESC_BEFORE=:C_MAT_DESC_BEFORE,");
            strSql.Append("C_IS_DEPOT=:C_IS_DEPOT,");
            strSql.Append("C_PLAN_ID=:C_PLAN_ID,");
            strSql.Append("C_ORDER_NO=:C_ORDER_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_CUST_NO=:C_CUST_NO,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_ISFREE=:C_ISFREE,");
            strSql.Append("C_LINEWH_CODE=:C_LINEWH_CODE,");
            strSql.Append("C_LINEWH_AREA_CODE=:C_LINEWH_AREA_CODE,");
            strSql.Append("C_LINEWH_LOC_CODE=:C_LINEWH_LOC_CODE,");
            strSql.Append("C_FLOOR=:C_FLOOR,");
            strSql.Append("C_CUST_AREA=:C_CUST_AREA,");
            strSql.Append("C_SALE_AREA=:C_SALE_AREA");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_TRC_ROLL_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,3),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_CF", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_XN", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_SHIFT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_GROUP", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DP_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_DP_DT", OracleDbType.Date),
                    new OracleParameter(":C_PLANT_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PLANT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_LINEWH_AREA_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_LINEWH_LOC_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_FLOOR", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_CUST_AREA", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SALE_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_TRC_ROLL_MAIN_ID;
            parameters[1].Value = model.C_STOVE;
            parameters[2].Value = model.C_BATCH_NO;
            parameters[3].Value = model.C_TICK_NO;
            parameters[4].Value = model.C_STL_GRD;
            parameters[5].Value = model.C_STL_GRD_BEFORE;
            parameters[6].Value = model.N_WGT;
            parameters[7].Value = model.C_STD_CODE;
            parameters[8].Value = model.C_STD_CODE_BEFORE;
            parameters[9].Value = model.C_MOVE_TYPE;
            parameters[10].Value = model.C_SPEC;
            parameters[11].Value = model.C_SHIFT;
            parameters[12].Value = model.C_GROUP;
            parameters[13].Value = model.C_EMP_ID;
            parameters[14].Value = model.D_MOD_DT;
            parameters[15].Value = model.C_STA_ID;
            parameters[16].Value = model.C_JUDGE_LEV_BP;
            parameters[17].Value = model.C_JUDGE_LEV_CF;
            parameters[18].Value = model.C_JUDGE_LEV_XN;
            parameters[19].Value = model.C_JUDGE_LEV_ZH;
            parameters[20].Value = model.C_DP_SHIFT;
            parameters[21].Value = model.C_DP_GROUP;
            parameters[22].Value = model.C_DP_EMP_ID;
            parameters[23].Value = model.D_DP_DT;
            parameters[24].Value = model.C_PLANT_ID;
            parameters[25].Value = model.C_PLANT_DESC;
            parameters[26].Value = model.C_MAT_CODE;
            parameters[27].Value = model.C_MAT_CODE_BEFORE;
            parameters[28].Value = model.C_MAT_DESC;
            parameters[29].Value = model.C_MAT_DESC_BEFORE;
            parameters[30].Value = model.C_IS_DEPOT;
            parameters[31].Value = model.C_PLAN_ID;
            parameters[32].Value = model.C_ORDER_NO;
            parameters[33].Value = model.C_CON_NO;
            parameters[34].Value = model.C_CUST_NO;
            parameters[35].Value = model.C_CUST_NAME;
            parameters[36].Value = model.C_ISFREE;
            parameters[37].Value = model.C_LINEWH_CODE;
            parameters[38].Value = model.C_LINEWH_AREA_CODE;
            parameters[39].Value = model.C_LINEWH_LOC_CODE;
            parameters[40].Value = model.C_FLOOR;
            parameters[41].Value = model.C_CUST_AREA;
            parameters[42].Value = model.C_SALE_AREA;
            parameters[43].Value = model.C_ID;

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
            strSql.Append("delete from TRC_ROLL_PRODCUT ");
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
            strSql.Append("delete from TRC_ROLL_PRODCUT ");
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
        public Mod_TRC_ROLL_PRODCUT GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_EMP_ID,D_MOD_DT,C_STA_ID,C_JUDGE_LEV_BP,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_ZH,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA from TRC_ROLL_PRODCUT ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_PRODCUT model = new Mod_TRC_ROLL_PRODCUT();
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
        public Mod_TRC_ROLL_PRODCUT DataRowToModel(DataRow row)
        {
            Mod_TRC_ROLL_PRODCUT model = new Mod_TRC_ROLL_PRODCUT();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_TRC_ROLL_MAIN_ID"] != null)
                {
                    model.C_TRC_ROLL_MAIN_ID = row["C_TRC_ROLL_MAIN_ID"].ToString();
                }
                if (row["C_STOVE"] != null)
                {
                    model.C_STOVE = row["C_STOVE"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_TICK_NO"] != null)
                {
                    model.C_TICK_NO = row["C_TICK_NO"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_STL_GRD_BEFORE"] != null)
                {
                    model.C_STL_GRD_BEFORE = row["C_STL_GRD_BEFORE"].ToString();
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_STD_CODE_BEFORE"] != null)
                {
                    model.C_STD_CODE_BEFORE = row["C_STD_CODE_BEFORE"].ToString();
                }
                if (row["C_MOVE_TYPE"] != null)
                {
                    model.C_MOVE_TYPE = row["C_MOVE_TYPE"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_SHIFT"] != null)
                {
                    model.C_SHIFT = row["C_SHIFT"].ToString();
                }
                if (row["C_GROUP"] != null)
                {
                    model.C_GROUP = row["C_GROUP"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_STA_ID"] != null)
                {
                    model.C_STA_ID = row["C_STA_ID"].ToString();
                }
                if (row["C_JUDGE_LEV_BP"] != null)
                {
                    model.C_JUDGE_LEV_BP = row["C_JUDGE_LEV_BP"].ToString();
                }
                if (row["C_JUDGE_LEV_CF"] != null)
                {
                    model.C_JUDGE_LEV_CF = row["C_JUDGE_LEV_CF"].ToString();
                }
                if (row["C_JUDGE_LEV_XN"] != null)
                {
                    model.C_JUDGE_LEV_XN = row["C_JUDGE_LEV_XN"].ToString();
                }
                if (row["C_JUDGE_LEV_ZH"] != null)
                {
                    model.C_JUDGE_LEV_ZH = row["C_JUDGE_LEV_ZH"].ToString();
                }
                if (row["C_DP_SHIFT"] != null)
                {
                    model.C_DP_SHIFT = row["C_DP_SHIFT"].ToString();
                }
                if (row["C_DP_GROUP"] != null)
                {
                    model.C_DP_GROUP = row["C_DP_GROUP"].ToString();
                }
                if (row["C_DP_EMP_ID"] != null)
                {
                    model.C_DP_EMP_ID = row["C_DP_EMP_ID"].ToString();
                }
                if (row["D_DP_DT"] != null && row["D_DP_DT"].ToString() != "")
                {
                    model.D_DP_DT = DateTime.Parse(row["D_DP_DT"].ToString());
                }
                if (row["C_PLANT_ID"] != null)
                {
                    model.C_PLANT_ID = row["C_PLANT_ID"].ToString();
                }
                if (row["C_PLANT_DESC"] != null)
                {
                    model.C_PLANT_DESC = row["C_PLANT_DESC"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_CODE_BEFORE"] != null)
                {
                    model.C_MAT_CODE_BEFORE = row["C_MAT_CODE_BEFORE"].ToString();
                }
                if (row["C_MAT_DESC"] != null)
                {
                    model.C_MAT_DESC = row["C_MAT_DESC"].ToString();
                }
                if (row["C_MAT_DESC_BEFORE"] != null)
                {
                    model.C_MAT_DESC_BEFORE = row["C_MAT_DESC_BEFORE"].ToString();
                }
                if (row["C_IS_DEPOT"] != null)
                {
                    model.C_IS_DEPOT = row["C_IS_DEPOT"].ToString();
                }
                if (row["C_PLAN_ID"] != null)
                {
                    model.C_PLAN_ID = row["C_PLAN_ID"].ToString();
                }
                if (row["C_ORDER_NO"] != null)
                {
                    model.C_ORDER_NO = row["C_ORDER_NO"].ToString();
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["C_CUST_NO"] != null)
                {
                    model.C_CUST_NO = row["C_CUST_NO"].ToString();
                }
                if (row["C_CUST_NAME"] != null)
                {
                    model.C_CUST_NAME = row["C_CUST_NAME"].ToString();
                }
                if (row["C_ISFREE"] != null)
                {
                    model.C_ISFREE = row["C_ISFREE"].ToString();
                }
                if (row["C_LINEWH_CODE"] != null)
                {
                    model.C_LINEWH_CODE = row["C_LINEWH_CODE"].ToString();
                }
                if (row["C_LINEWH_AREA_CODE"] != null)
                {
                    model.C_LINEWH_AREA_CODE = row["C_LINEWH_AREA_CODE"].ToString();
                }
                if (row["C_LINEWH_LOC_CODE"] != null)
                {
                    model.C_LINEWH_LOC_CODE = row["C_LINEWH_LOC_CODE"].ToString();
                }
                if (row["C_FLOOR"] != null)
                {
                    model.C_FLOOR = row["C_FLOOR"].ToString();
                }
                if (row["C_CUST_AREA"] != null)
                {
                    model.C_CUST_AREA = row["C_CUST_AREA"].ToString();
                }
                if (row["C_SALE_AREA"] != null)
                {
                    model.C_SALE_AREA = row["C_SALE_AREA"].ToString();
                }
                if (row["C_BZYQ"] != null)
                {
                    model.C_BZYQ = row["C_BZYQ"].ToString();
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
            strSql.Append("select C_ID,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_EMP_ID,D_MOD_DT,C_STA_ID,C_JUDGE_LEV_BP,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_ZH,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA ,C_BZYQ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT ");
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
            strSql.Append("select count(1) FROM TRC_ROLL_PRODCUT ");
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
            strSql.Append(")AS Row, T.*  from TRC_ROLL_PRODCUT T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }



        #endregion  BasicMethod



        #region  ExtensionMethod



        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_BATCH_NO,
                                   T.C_LINEWH_CODE,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_BZYQ,
                                   T.C_SALE_AREA,
                                   T.D_PRODUCE_DATE,
                                   COUNT(0) QUA,
                                   SUM(NVL(T.N_WGT, 0)) WGT,
                                   A.C_CUST_NAME
                              FROM TRC_ROLL_PRODCUT T
                              LEFT JOIN TMO_CON_ORDER A
                                ON A.C_ORDER_NO = T.C_ORDER_NO WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y'");
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) = '{0}'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (!string.IsNullOrEmpty(salearea))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA = '{0}'", salearea);
            }
            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND A.C_CUST_NAME like '%{0}%'", custname);
            }

            strSql.AppendFormat(@" GROUP BY T.C_BATCH_NO,
                                      T.C_LINEWH_CODE,
                                      T.C_STL_GRD,
                                      T.C_SPEC,
                                      T.C_MAT_CODE,
                                      T.C_MAT_DESC,
                                      T.C_JUDGE_LEV_ZH,
                                      T.C_ZYX1,
                                      T.C_ZYX2,
                                      T.C_BZYQ,
                                      T.C_SALE_AREA,
                                      T.D_PRODUCE_DATE,
                                      A.C_CUST_NAME
                             ORDER BY T.C_MAT_DESC
                            ");
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
        /// 储运发运单仓库查询
        /// </summary>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="fydID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetCKRollProdcut(string ckcode, string fydID)
        {
            Dal_TMD_DISPATCHDETAILS dal = new Dal_TMD_DISPATCHDETAILS();
            Mod_TMD_DISPATCHDETAILS mod = dal.GetModel(fydID);
            string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_PACK, mod.C_JUDGE_LEV_ZH };

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT 
       T.C_BATCH_NO,
       T.C_LINEWH_CODE,
       T.C_LINEWH_AREA_CODE,
       T.C_LINEWH_LOC_CODE,
       T.C_STL_GRD,
       T.C_SPEC,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.C_JUDGE_LEV_ZH,
       T.C_STD_CODE,
       T.C_ZYX1,
       T.C_ZYX2,
       T.C_BZYQ,
       T.C_SALE_AREA,
       T.D_PRODUCE_DATE,
       sum(T.N_WGT) N_WGT,
       count(0) jianshu,
       T.C_PCINFO,
       T.C_IS_QR
  FROM TRC_ROLL_PRODCUT T 
 WHERE T.C_IS_QR='Y' and T.C_MOVE_TYPE = 'E'  AND T.C_MAT_CODE = '{0}'
                               AND T.C_STD_CODE = '{1}'
                               AND T.C_BZYQ = '{2}'
                               AND T.C_JUDGE_LEV_ZH = '{3}' ", arr);


            strSql.AppendFormat(@" group by 
                                    T.C_BATCH_NO,
                                   T.C_LINEWH_CODE,
                                   T.C_LINEWH_AREA_CODE,
                                   T.C_LINEWH_LOC_CODE,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_STD_CODE,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_BZYQ,
                                   T.C_SALE_AREA,
                                   T.D_PRODUCE_DATE,
                                   T.C_PCINFO,
                                   T.C_IS_QR order by t.c_mat_desc, T.C_STL_GRD,T.C_SPEC,T.D_PRODUCE_DATE");



            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据订单查询线材仓库
        /// </summary>
        /// <param name="orderID">发运单明细主键</param>
        /// <returns></returns>
        public DataSet GetCKRollProdcut(string orderID)
        {
            Dal_TMO_ORDER dal = new Dal_TMO_ORDER();
            Mod_TMO_ORDER mod = dal.GetModel(orderID);

            Dal_TQB_CHECKSTATE daltqb = new Dal_TQB_CHECKSTATE();
            Mod_TQB_CHECKSTATE modtqb = daltqb.GetModel(mod.C_VDEF1);

            string[] arr = { mod.C_MAT_CODE, mod.C_STD_CODE, mod.C_PACK, modtqb.C_CHECKSTATE_NAME };

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT 
       T.C_BATCH_NO,
       T.C_LINEWH_CODE,
       T.C_LINEWH_AREA_CODE,
       T.C_STL_GRD,
       T.C_SPEC,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.C_JUDGE_LEV_ZH,
       T.C_STD_CODE,
       T.C_ZYX1,
       T.C_ZYX2,
       T.C_BZYQ,
       T.C_SALE_AREA,
       T.D_PRODUCE_DATE,
       sum(T.N_WGT) N_WGT,
       count(0) jianshu,
       T.C_PCINFO,
       T.C_IS_QR
  FROM TRC_ROLL_PRODCUT T 
 WHERE T.C_IS_QR='Y' and T.C_MOVE_TYPE = 'E'  AND T.C_MAT_CODE = '{0}'
                               AND T.C_STD_CODE = '{1}'
                               AND T.C_BZYQ = '{2}'
                               AND T.C_JUDGE_LEV_ZH = '{3}' ", arr);


            strSql.AppendFormat(@" group by 
                                    T.C_BATCH_NO,
                                   T.C_LINEWH_CODE,
                                   T.C_LINEWH_AREA_CODE,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_STD_CODE,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_BZYQ,
                                   T.C_SALE_AREA,
                                   T.D_PRODUCE_DATE,
                                   T.C_PCINFO,
                                   T.C_IS_QR order by t.c_mat_desc, T.C_STL_GRD,T.C_SPEC");



            return DbHelperOra.Query(strSql.ToString());
        }


        public string GetAreaList(string area)
        {

            Dal_TS_DIC ts_dic = new Dal_TS_DIC();
            var list = new List<string>();

            string areaList = "";

            var table = ts_dic.GetDicArea(area).Tables[0];
            foreach (DataRow dr in table.Rows)
            {
                string str = "'" + dr["C_DETAILNAME"].ToString() + "'";
                list.Add(str);
            }

            areaList = string.Join(",", list);

            return areaList;

        }

        /// <summary>
        /// 客户库存查询
        /// </summary>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="conno">合同号</param>
        /// <param name="custname">客户名称</param>
        /// <returns></returns>
        public DataSet GetCustRollProc(string stlgrd, string spec, string conno, string custname, string area)
        {
            string strSql = $@"SELECT T.C_MAT_CODE,
                               T.C_MAT_DESC,
                               T.C_BATCH_NO,
                               T.C_STL_GRD,
                               T.C_SPEC,
                               T.C_JUDGE_LEV_ZH,
                               T.C_BZYQ,
                               T.D_PRODUCE_DATE,
                               SUM(T.N_WGT) AS N_WGT,
                               COUNT(0) AS QUA,
                               T.C_CON_NO,
                               T.C_SALE_AREA
                          FROM TRC_ROLL_PRODCUT T
                         WHERE T.C_MOVE_TYPE = 'E'
                           AND T.C_CUST_NAME = '{custname}'";

            if (!string.IsNullOrEmpty(area))
            {
                strSql += $" AND T.C_SALE_AREA='{area}'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND T.C_STL_GRD='{stlgrd}'";
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql += $" AND T.C_SPEC='{spec}'";
            }
            if (!string.IsNullOrEmpty(conno))
            {
                strSql += $" AND T.C_CON_NO LIKE '%{conno}%'";
            }
            strSql += @"GROUP BY T.C_MAT_CODE,
                                  T.C_MAT_DESC,
                                  T.C_BATCH_NO,
                                  T.C_STL_GRD,
                                  T.C_SPEC,
                                  T.C_JUDGE_LEV_ZH,
                                  T.C_BZYQ,
                                  T.D_PRODUCE_DATE,
                                  T.C_SALE_AREA,
                                  T.C_CON_NO";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 获取线材超期库存
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_CQ(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_BATCH_NO,
       T.C_LINEWH_CODE,
       T.C_STL_GRD,
       T.C_SPEC,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       NVL(T.C_JUDGE_LEV_ZH, 'DP') C_JUDGE_LEV_ZH,
       T.C_STD_CODE,
       T.C_ZYX1,
       T.C_ZYX2,
       T.C_BZYQ,
       T.C_SALE_AREA,
       TO_CHAR(T.D_PRODUCE_DATE, 'YYYY-MM-DD') D_PRODUCE_DATE,
       TO_CHAR((CASE WHEN T.C_IS_QR='Y' THEN NVL(T.D_QR_DATE,T.D_PRODUCE_DATE) ELSE T.D_QR_DATE  END), 'YYYY-MM-DD') D_QR_DATE,
       sum(T.N_WGT) N_WGT,
       count(0) jianshu,
       A.C_CUST_NAME,
       T.C_PCINFO,
       T.C_IS_QR,
       T.C_CKDH,
       B.C_FLAG,
       T.C_CON_NO,
       T.C_ORDER_NO,
       V.sf_cq,
       V.N_DAY
  FROM TRC_ROLL_PRODCUT T
  LEFT JOIN TMO_CON_ORDER A
    ON A.C_ORDER_NO = T.C_ORDER_NO
  LEFT JOIN TMB_MONI_STLGRD B
    ON B.C_STL_GRD = T.C_STL_GRD
  LEFT JOIN V_ROLL_CQ_CRM2 V
    ON V.C_ID = T.C_ID
 WHERE T.C_MOVE_TYPE IN('E','QE') AND V.sf_cq='Y' AND T.C_LINEWH_CODE NOT IN('164')");
            if (flag != "全部")
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }
            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (!string.IsNullOrEmpty(minarea))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA ='{0}'", minarea);
            }
            else
            {
                if (salearea != "-1")
                {

                    string area = GetAreaList(salearea);
                    string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";
                    strSql.Append(where);
                }
            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND A.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(sckssj) && !string.IsNullOrEmpty(scjssj))
            {
                strSql.Append(" AND T.D_PRODUCE_DATE>=TO_DATE('" + Convert.ToDateTime(sckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_PRODUCE_DATE<= TO_DATE('" + Convert.ToDateTime(scjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.AppendFormat(@" group by T.C_BATCH_NO,
          T.C_LINEWH_CODE,
          T.C_STL_GRD,
          T.C_SPEC,
          T.C_MAT_CODE,
          T.C_MAT_DESC,
          T.C_JUDGE_LEV_ZH,
          T.C_STD_CODE,
          T.C_ZYX1,
          T.C_ZYX2,
          T.C_BZYQ,
          T.C_SALE_AREA,
          T.D_PRODUCE_DATE,
          T.D_QR_DATE,
          A.C_CUST_NAME,
          T.C_PCINFO,
          T.C_CKDH,
          T.C_IS_QR,
          B.C_FLAG,
          T.C_CON_NO,
          T.C_ORDER_NO,
          V.sf_cq,
          V.N_DAY
 order by t.c_mat_desc, T.C_STL_GRD, T.C_SPEC, T.D_PRODUCE_DATE");



            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 线材改判库存
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_GP(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT * FROM V_ROLL_CK_GP T WHERE 1=1");
            if (flag != "全部")
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }
            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (!string.IsNullOrEmpty(minarea))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA ='{0}'", minarea);
            }
            else
            {
                if (salearea != "-1")
                {

                    string area = GetAreaList(salearea);
                    string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";
                    strSql.Append(where);
                }
            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(sckssj) && !string.IsNullOrEmpty(scjssj))
            {
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')>=TO_DATE('" + Convert.ToDateTime(sckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')<= TO_DATE('" + Convert.ToDateTime(scjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.AppendFormat(@" order by  T.D_PRODUCE_DATE");



            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材仓库查询是否室内
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut_SFSN(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj, string sfsn, string con)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT * FROM V_ROLL_CK_ISOUT T WHERE 1=1");
            if (flag != "全部")
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }
            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (!string.IsNullOrEmpty(minarea))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA ='{0}'", minarea);
            }
            else
            {
                if (salearea != "-1")
                {
                    string area = GetAreaList(salearea);
                    string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";
                    strSql.Append(where);
                }
            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }
            if (!string.IsNullOrEmpty(sfsn))
            {
                strSql.AppendFormat(" AND T.C_ISOUT='{0}'", sfsn);
            }
            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND T.C_CON_NO like '%{0}%'", con);
            }

            if (!string.IsNullOrEmpty(sckssj) && !string.IsNullOrEmpty(scjssj))
            {
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')>=TO_DATE('" + Convert.ToDateTime(sckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')<= TO_DATE('" + Convert.ToDateTime(scjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.AppendFormat(@" order by  T.D_PRODUCE_DATE");



            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材仓库查询
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="minarea">小区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut3(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string minarea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT * FROM V_ROLL_CK T WHERE 1=1");
            if (flag != "全部")
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }
            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (!string.IsNullOrEmpty(minarea))
            {
                strSql.AppendFormat(" AND T.C_SALE_AREA ='{0}'", minarea);
            }
            else
            {
                if (salearea != "-1")
                {

                    string area = GetAreaList(salearea);
                    string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";
                    strSql.Append(where);
                }
            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(sckssj) && !string.IsNullOrEmpty(scjssj))
            {
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')>=TO_DATE('" + Convert.ToDateTime(sckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TO_DATE(T.D_PRODUCE_DATE,'yyyy-mm-dd hh24:mi:ss')<= TO_DATE('" + Convert.ToDateTime(scjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.AppendFormat(@" order by  T.D_PRODUCE_DATE");



            return DbHelperOra.Query(strSql.ToString());
        }




        /// <summary>
        /// 线材资源整批调配
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="sckssj">生产开始时间</param>
        /// <param name="scjssj">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetRollProdcut(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string sckssj, string scjssj, string conno, string gpstate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_BATCH_NO,
                                   T.C_LINEWH_CODE,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.C_MAT_CODE,
                                   T.C_MAT_DESC,
                                   NVL(T.C_JUDGE_LEV_ZH, 'DP') C_JUDGE_LEV_ZH,
                                   T.C_JUDGE_LEV_BP,
                                   T.C_STD_CODE,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_BZYQ,
                                   T.C_SALE_AREA,
                                   TO_CHAR(T.D_PRODUCE_DATE, 'YYYY-MM-DD') D_PRODUCE_DATE,
                                   sum(T.N_WGT) N_WGT,
                                   count(0) jianshu,
                                   T.C_CUST_NAME,
                                   T.C_CON_NO,
                                   T.C_PCINFO,
                                   T.C_IS_QR,
                                   MIN(T.C_CKDH) C_CKDH,
                                   T.C_ORDER_NO,
                                   (SELECT MAX(A.N_WGT)
                                      FROM TMO_ORDER A
                                     WHERE A.C_ORDER_NO = T.C_ORDER_NO) 计划需求量,
                                   (SELECT MAX(NVL(A.N_SLAB_MATCH_WGT, 0) + NVL(A.N_PROD_WGT, 0))
                                      FROM TMO_ORDER A
                                     WHERE A.C_ORDER_NO = T.C_ORDER_NO) 完工数量,
                                   (SELECT MAX(TO_CHAR(A.D_PCTBTS,'yyyy-mm-dd'))
                                      FROM TMO_ORDER A
                                     WHERE A.C_ORDER_NO = T.C_ORDER_NO) 计划日期,
                                   (SELECT MAX(TO_CHAR(A.D_NEED_DT,'yyyy-mm-dd'))
                                      FROM TMO_ORDER A
                                     WHERE A.C_ORDER_NO = T.C_ORDER_NO) 需求日期
                              FROM TRC_ROLL_PRODCUT T
                             WHERE T.C_MOVE_TYPE = 'E'");



            if (!string.IsNullOrEmpty(gpstate))
            {
                strSql.AppendFormat(" AND T.C_QGP_STATE = '{0}'", gpstate);
            }
            if (flag != "全部")
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }
            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }
            if (salearea != "-1")
            {
                string area = GetAreaList(salearea);
                string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";
                strSql.Append(where);
            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(conno))
            {
                strSql.AppendFormat(" AND T.C_CON_NO like '%{0}%'", conno);
            }

            if (!string.IsNullOrEmpty(sckssj) && !string.IsNullOrEmpty(scjssj))
            {
                strSql.Append(" AND T.D_PRODUCE_DATE>=TO_DATE('" + Convert.ToDateTime(sckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND T.D_PRODUCE_DATE<= TO_DATE('" + Convert.ToDateTime(scjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.AppendFormat(@" GROUP BY T.C_BATCH_NO,
                                      T.C_LINEWH_CODE,
                                      T.C_STL_GRD,
                                      T.C_SPEC,
                                      T.C_MAT_CODE,
                                      T.C_MAT_DESC,
                                      T.C_JUDGE_LEV_ZH,
                                      T.C_JUDGE_LEV_BP,
                                      T.C_STD_CODE,
                                      T.C_ZYX1,
                                      T.C_ZYX2,
                                      T.C_BZYQ,
                                      T.C_SALE_AREA,
                                      T.D_PRODUCE_DATE,
                                      T.C_PCINFO,          
                                      T.C_IS_QR,
                                      T.C_ORDER_NO,
                                      T.C_CON_NO,
                                      T.C_CUST_NAME");



            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材列表单卷显示
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="pagesize">显示页数</param>
        /// <param name="pageindex">起始页数</param>
        /// <returns></returns>
        public DataSet GetRollProdcut2(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string con,string top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_ID,
       T.C_BATCH_NO,
       T.C_LINEWH_CODE,
       T.C_STL_GRD,
       T.C_SPEC,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.C_JUDGE_LEV_ZH,
       T.C_STD_CODE,
       T.C_ZYX1,
       T.C_ZYX2,
       T.C_BZYQ,
       T.C_SALE_AREA,
       T.D_PRODUCE_DATE,
       T.N_WGT,
       T.C_CUST_NAME,
       T.C_CON_NO,
       T.C_PCINFO,
       T.C_IS_QR,
       T.C_CKDH,--原区域
       T.C_CKRY--原客户
  FROM TRC_ROLL_PRODCUT T
 WHERE T.C_MOVE_TYPE = 'E' ");

            if (!string.IsNullOrEmpty(flag))
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }

            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like  '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }

            if (salearea != "-1")
            {
                string area = GetAreaList(salearea);
                string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";

                strSql.Append(where);

            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND T.C_CON_NO like '%{0}%'", con);
            }
            if (!string.IsNullOrEmpty(top))
            {
                strSql.AppendFormat(" AND ROWNUM<={0} ", top);
            }


            strSql.Append(" order by t.C_MAT_DESC,T.C_STL_GRD,T.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材列表单卷显示
        /// </summary>
        /// <param name="batchno">批次号</param>
        /// <param name="ckcode">仓库编码</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="matcode">物料编码</param>
        /// <param name="zldj">质量等级</param>
        /// <param name="salearea">销售区域</param>
        /// <param name="custname">客户名称</param>
        /// <param name="pagesize">显示页数</param>
        /// <param name="pageindex">起始页数</param>
        /// <returns></returns>
        public DataSet GetRollProdcut2_top(string batchno, string ckcode, string stlgrd, string spec, string matcode, string zldj, string salearea, string custname, string C_PCINFO, string flag, string con, string top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_ID,
       T.C_BATCH_NO,
       T.C_LINEWH_CODE,
       T.C_STL_GRD,
       T.C_SPEC,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.C_JUDGE_LEV_ZH,
       T.C_STD_CODE,
       T.C_ZYX1,
       T.C_ZYX2,
       T.C_BZYQ,
       T.C_SALE_AREA,
       T.D_PRODUCE_DATE,
       T.N_WGT,
       T.C_CUST_NAME,
       T.C_CON_NO,
       T.C_PCINFO,
       T.C_IS_QR,
       T.C_CKDH,--原区域
       T.C_CKRY--原客户
  FROM TRC_ROLL_PRODCUT T
 WHERE T.C_MOVE_TYPE = 'E' ");

            if (!string.IsNullOrEmpty(flag))
            {
                strSql.AppendFormat(" AND T.C_IS_QR ='{0}'", flag);
            }

            if (!string.IsNullOrEmpty(C_PCINFO))
            {
                strSql.AppendFormat(" AND T.C_PCINFO = '{0}'", C_PCINFO);
            }
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO = '{0}'", batchno);
            }
            if (!string.IsNullOrEmpty(ckcode))
            {
                strSql.AppendFormat(" AND T.C_LINEWH_CODE = '{0}'", ckcode);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) like  '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC like '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(matcode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE = '{0}'", matcode);
            }
            if (!string.IsNullOrEmpty(zldj))
            {
                strSql.AppendFormat(" AND T.C_JUDGE_LEV_ZH = '{0}'", zldj);
            }

            if (salearea != "-1")
            {
                string area = GetAreaList(salearea);
                string where = salearea == "" ? "AND T.C_SALE_AREA is null" : area != "" ? $"AND T.C_SALE_AREA IN({area})" : $"AND T.C_SALE_AREA='{salearea}'";

                strSql.Append(where);

            }

            if (!string.IsNullOrEmpty(custname))
            {
                strSql.AppendFormat(" AND T.C_CUST_NAME like '%{0}%'", custname);
            }

            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND T.C_CON_NO like '%{0}%'", con);
            }

            if (!string.IsNullOrEmpty(top))
            {
                strSql.AppendFormat(" AND ROWNUM<={0} ", top);
            }


            strSql.Append(" order by t.C_MAT_DESC,T.C_STL_GRD,T.C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据批号获取相关数据
        /// </summary>
        /// <param name="batchno"></param>
        /// <returns></returns>
        public DataSet GetRollProdcut(string batchno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT distinct T.C_BATCH_NO,
                T.C_STL_GRD,
                T.C_SPEC,
                T.C_MAT_CODE,
                T.C_MAT_DESC,
                T.C_SALE_AREA,
                A.C_CUST_NAME
  FROM TRC_ROLL_PRODCUT T
  LEFT JOIN TMO_CON_ORDER A
    ON A.C_ORDER_NO = T.C_ORDER_NO
 WHERE T.C_MOVE_TYPE = 'E'
   --AND T.C_JUDGE_LEV_ZH IN ('A', 'CK', 'AA', 'AAA')
   AND T.C_IS_QR = 'Y'");
            if (!string.IsNullOrEmpty(batchno))
            {
                strSql.AppendFormat(" AND T.C_BATCH_NO in({0}) ", batchno);
            }




            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 订单挂单
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="C_ORDER_NO">订单号</param>
        /// <param name="C_CON_NO">合同号</param>
        /// <param name="C_CUST_NO">客户编码</param>
        /// <param name="C_CUST_NAME">客户名称</param>
        /// <param name="C_ISFREE">是否自由状态</param>
        /// <returns></returns>
        public bool UpdateMatch(string id, string C_ORDER_NO, string C_CON_NO, string C_CUST_NO, string C_CUST_NAME, string C_ISFREE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_PRODCUT set ");

            strSql.Append("C_ORDER_NO=:C_ORDER_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_CUST_NO=:C_CUST_NO,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_ISFREE=:C_ISFREE,");

            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,5),

                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = C_ORDER_NO;
            parameters[1].Value = C_CON_NO;
            parameters[2].Value = C_CUST_NO;
            parameters[3].Value = C_CUST_NAME;
            parameters[4].Value = C_ISFREE;

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
        /// 获取线材各区域总量/监控/超期
        /// </summary>
        /// <returns></returns>
        public DataSet GetRollArea(string stlGrd, string spec)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select T.c_detailname AS area,
       T.C_INDEX,
       trc.ZWGT,
       trc.qua,
       nvl(j.JKWGT, 0) JKWGT,
       nvl(j.jkqua, 0) jkqua,
       NVL(CQ.CQWGT, 0) CQWGT,
       NVL(CQ.CQQUA, 0) CQQUA
  from (select '其它区域' as c_detailname, to_number('21') as C_INDEX
          from dual
        union all
        SELECT t.c_detailname, T.C_INDEX
          FROM TS_DIC T
         WHERE T.C_TYPECODE = 'ConArea') T
  left join (SELECT NVL(t.c_sale_area, '其它区域') c_sale_area,
                    sum(t.n_wgt) ZWGT,
                    count(t.c_id) qua
               FROM TRC_ROLL_PRODCUT T
              WHERE T.C_MOVE_TYPE = 'E'");
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(@" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(@" AND T.C_SPEC like '%{0}%'", spec);
            }
            strSql.Append(@" GROUP BY t.c_sale_area) trc
    on trc.c_sale_area = t.c_detailname");
            strSql.Append(@" LEFT JOIN (SELECT t.c_sale_area, sum(t.n_wgt) JKWGT, count(t.c_id) jkqua
               FROM TRC_ROLL_PRODCUT T
               LEFT JOIN TMB_MONI_STLGRD B
                 ON B.C_STL_GRD = T.C_STL_GRD
              WHERE T.C_MOVE_TYPE = 'E'
                and B.C_FLAG = 'Y'");
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(@" AND UPPER(T.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(@" AND T.C_SPEC like'%{0}%'", spec);
            }

            strSql.Append(@"  GROUP BY t.c_sale_area) J
    ON J.c_sale_area = t.c_detailname");
            strSql.Append(@"  LEFT JOIN (SELECT V.c_sale_area, SUM(V.N_WGT) CQWGT, COUNT(V.C_ID) CQQUA
               FROM V_ROLL_CQ_CRM2 V
              WHERE V.sf_cq = 'Y'");
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(@" AND UPPER(V.C_STL_GRD) like '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(@" AND V.C_SPEC like '%{0}%'", spec);
            }
            strSql.Append(@" GROUP BY V.c_sale_area) CQ
    ON CQ.c_sale_area = t.c_detailname
 ORDER BY T.C_INDEX");
            #region //
            //           string strSql = $@"select T.c_detailname AS area,
            //      T.C_INDEX,
            //      trc.ZWGT,
            //      trc.qua,
            //      nvl(j.JKWGT, 0) JKWGT,
            //      nvl(j.jkqua, 0) jkqua,
            //      NVL(CQ.CQWGT, 0) CQWGT,
            //      NVL(CQ.CQQUA, 0) CQQUA
            // from (select '其它区域' as c_detailname, to_number('21') as C_INDEX
            //         from dual
            //       union all
            //       SELECT t.c_detailname, T.C_INDEX
            //         FROM TS_DIC T
            //        WHERE T.C_TYPECODE = 'ConArea') T
            // left join (SELECT NVL(t.c_sale_area, '其它区域') c_sale_area,
            //                   sum(t.n_wgt) ZWGT,
            //                   count(t.c_id) qua
            //              FROM TRC_ROLL_PRODCUT T
            //             WHERE T.C_MOVE_TYPE = 'E'
            //             GROUP BY t.c_sale_area) trc
            //   on trc.c_sale_area = t.c_detailname
            // LEFT JOIN (SELECT t.c_sale_area, sum(t.n_wgt) JKWGT, count(t.c_id) jkqua
            //              FROM TRC_ROLL_PRODCUT T
            //              LEFT JOIN TMB_MONI_STLGRD B
            //                ON B.C_STL_GRD = T.C_STL_GRD
            //             WHERE T.C_MOVE_TYPE = 'E'
            //               and B.C_FLAG = 'Y'
            //             GROUP BY t.c_sale_area) J
            //   ON J.c_sale_area = t.c_detailname

            // LEFT JOIN (SELECT V.c_sale_area, SUM(V.N_WGT) CQWGT, COUNT(V.C_ID) CQQUA
            //              FROM V_ROLL_CQ_CRM2 V
            //             WHERE V.sf_cq = 'Y'
            //             GROUP BY V.c_sale_area) CQ
            //   ON CQ.c_sale_area = t.c_detailname
            //ORDER BY T.C_INDEX";
            #endregion
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 检查合同是否排产或是否有线材库存
        /// </summary>
        /// <param name="conno"></param>
        /// <returns></returns>
        public ModMsg Check_OrderAndRoll(string conno)
        {
            string strSql = $"SELECT T.C_CON_NO FROM TMO_ORDER T WHERE T.C_CON_NO ='{conno}' AND T.N_EXEC_STATUS IN(-1,0) ";
            if (DbHelperOra.ExecuteSql(strSql) > 0)
            {
                var mod = new ModMsg() {
                    Flag = 0,
                    Result =true
                };
                return mod;
            }
            else
            {
                string cmdText = $"SELECT T.C_CON_NO FROM TRC_ROLL_PRODCUT T WHERE T.C_CON_NO='{conno}' AND T.C_MOVE_TYPE='E'";
                if (DbHelperOra.ExecuteSql(cmdText) > 0)
                {
                    var mod = new ModMsg()
                    {
                        Flag = 1,
                        Result = true
                    };
                    return mod;
                }
                else
                {
                    var mod = new ModMsg()
                    {
                        Flag = 1,
                        Result =false
                    };
                    return mod;
                }
            }
        }

        #endregion  ExtensionMethod

        #region PCI
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="ph">批号</param>
        /// <param name="grd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <param name="ck">仓库</param>
        /// <param name="qy">区域</param>
        /// <param name="kw">库位</param>
        /// <param name="sfdp">是否待判</param>
        /// <returns></returns>
        public DataSet GetXCKC(string ph, string grd, string std, string ck, string qy, string kw, string status, string C_QTCKD, string C_ZKD, string sfdp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) N_NUM, COUNT(1) N_SNUM,C_BATCH_NO,C_STL_GRD,SUM(N_WGT) N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2 ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
            if (sfdp.Trim() != "全部")
            {
                strSql.Append(" and nvl2(C_JUDGE_LEV_ZH,0,1)='" + sfdp + "' ");
            }
            if (ph.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + ph + "%' ");
            }
            if (grd.Trim() != "")
            {
                strSql.Append(" and C_STL_GRD like '%" + grd + "%' ");
            }
            if (std.Trim() != "")
            {
                strSql.Append(" and C_STD_CODE like '%" + std + "%' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE ='" + ck + "' ");
            }
            if (qy.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_AREA_CODE ='" + qy + "' ");
            }
            if (kw.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_LOC_CODE ='" + kw + "' ");
            }
            if (C_QTCKD.Trim() != "")
            {
                strSql.Append(" and C_QTCKD_NO LIKE'%" + C_QTCKD + "%' ");
            }
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" and C_ZKD_NO LIKE'%" + C_ZKD + "%' ");
            }
            strSql.Append(" GROUP BY  C_BATCH_NO,C_STL_GRD,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2 ");
            strSql.Append(" ORDER BY C_BATCH_NO");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="ph">批号</param>
        /// <param name="grd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <param name="ck">仓库</param>
        /// <param name="qy">区域</param>
        /// <param name="kw">库位</param>
        /// <param name="sfdp">是否待判</param>
        /// <returns></returns>
        public DataSet GetXCKC1(string ph, string grd, string std, string ck, string qy, string kw, string status, string C_QTCKD, string C_ZKD, string sfdp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) N_NUM, COUNT(1) N_SNUM,C_BATCH_NO,C_STL_GRD,SUM(N_WGT) N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2 ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
            if (sfdp.Trim() != "全部")
            {
                strSql.Append(" and nvl2(C_JUDGE_LEV_ZH,0,1)='" + sfdp + "' ");
            }
            if (ph.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + ph + "%' ");
            }
            if (grd.Trim() != "")
            {
                strSql.Append(" and C_STL_GRD like '%" + grd + "%' ");
            }
            if (std.Trim() != "")
            {
                strSql.Append(" and C_STD_CODE like '%" + std + "%' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE ='" + ck + "' ");
            }
            if (qy.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_AREA_CODE ='" + qy + "' ");
            }
            if (kw.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_LOC_CODE ='" + kw + "' ");
            }
            if (C_QTCKD.Trim() != "")
            {
                strSql.Append(" and C_QTCKD_NO LIKE'%" + C_QTCKD + "%' ");
            }
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" and C_ZKD_NO LIKE'%" + C_ZKD + "%' ");
            }
            strSql.Append(" GROUP BY  C_BATCH_NO,C_STL_GRD,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2 ");
            strSql.Append(" ORDER BY C_BATCH_NO");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ck"></param>
        /// <param name="kw"></param>
        /// <param name="gz"></param>
        /// <param name="bz"></param>
        /// <param name="batchno"></param>
        /// <param name="barcode"></param>
        /// <param name="sfdp"></param>
        /// <param name="zldj"></param>
        /// <returns></returns>
        public DataSet GetXCKList(string ck, string kw, string gz, string bz, string batchno, string barcode, string sfdp, string zldj, string dt1, string dt2, string qy, string kczt, string gg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 1 as N_NUM,C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,DECODE(C_MOVE_TYPE,'E','在库','S','已销售','M','转库','QC','其他出库','QE','其他入库','QS','其他销售') C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,DECODE（C_JUDGE_LEV_ZH,'','DP',C_JUDGE_LEV_ZH)C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_LINEWH_CODE<>'164'");
            if (kczt.Trim() != "全部")
            {
                strSql.Append(" and C_MOVE_TYPE='" + kczt + "' ");
            }
            if (sfdp.Trim() != "全部")
            {
                strSql.Append(" and nvl2(C_JUDGE_LEV_ZH,0,1)='" + sfdp + "' ");
            }
            if (gg.Trim() != "")
            {
                strSql.Append(" and C_SPEC LIKE '%" + gg + "%' ");
            }
            if (zldj.Trim() != "")
            {
                strSql.Append(" and nvl(C_JUDGE_LEV_ZH,'DP') = '" + zldj + "' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE LIKE '%" + ck + "%' ");
            }
            if (qy.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_AREA_CODE LIKE '%" + qy + "%' ");
            }
            if (kw.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_LOC_CODE LIKE'%" + kw + "%' ");
            }
            if (gz.Trim() != "")
            {
                strSql.Append(" and C_STL_GRD LIKE '%" + gz + "%' ");
            }
            if (bz.Trim() != "")
            {
                strSql.Append(" and C_STD_CODE LIKE'%" + bz + "%' ");
            }
            if (batchno.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO LIKE'%" + batchno + "%' ");
            }
            if (barcode.Trim() != "")
            {
                strSql.Append(" and C_BARCODE LIKE'%" + barcode + "%' ");
            }
            if (dt1.Trim() != "")
            {
                strSql.Append(" and D_PRODUCE_DATE>=to_date('" + dt1 + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (dt2.Trim() != "")
            {
                strSql.Append(" and D_PRODUCE_DATE<=to_date('" + dt2 + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" ORDER BY C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_STL_GRD,C_STD_CODE,C_BATCH_NO,C_BARCODE ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

    }
}

