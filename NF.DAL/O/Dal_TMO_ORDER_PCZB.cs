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
    /// 订单排产指标
    /// </summary>
    public partial class Dal_TMO_ORDER_PCZB
    {
        public Dal_TMO_ORDER_PCZB() { }


        #region //校验当前区域下发订单是否满足排产指标
        /// <summary>
        /// 校验当前区域下发订单是否满足排产指标
        /// </summary>
        /// <param name="wgt">订单排产量</param>
        /// <param name="area">区域</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool CheckStl_Grd_ZB(decimal wgt, string area, string orderNo, string xday)
        {
            //TRUNC((TO_CHAR(SYSDATE, 'DD')-1)/10)
            bool result = true;
            string strSql = $@"SELECT T.N_DAY_JK_ZB,T.N_DAY_JP_ZB,T.N_DAY_PZ_ZB,T.C_FLAG,T.C_AREA
                              FROM TMO_ORDER_PCZB T
                             WHERE T.C_AREA = '{area}'
                               AND T.C_FLAG = 'Y'
                               AND T.N_TYPE={xday}
                               AND TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')";
            DataTable dtZB = DbHelperOra.Query(strSql).Tables[0];//获取排产指标
            if (dtZB.Rows.Count > 0)//判定是否指标控制
            {
                string strSql2 = $@"SELECT * FROM V_CON_ORDER_TYPE T WHERE T.C_ORDER_NO='{orderNo}'";
                DataTable dt2 = DbHelperOra.Query(strSql2).Tables[0];//获取当前订单基本信息
                if (dt2.Rows.Count > 0)//获取钢种监控/精品/品种
                {
                    if (dt2.Rows[0]["C_FLAG"].ToString() == "Y")//监控钢种
                    {
                        #region //监控
                        //获取当前区域当月旬监控提报排产总量
                        string strSql3 = $@"SELECT  NVL(SUM(T.N_WGT),0) N_WGT
                                              FROM V_ORDER_PLAN T
                                             WHERE T.C_FLAG = 'Y' AND T.C_AREA='{dt2.Rows[0]["C_AREA"].ToString()}'
                                               AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
                                               AND TRUNC((TO_CHAR(T.D_DT, 'DD') - 1) / 10) ={xday}";

                        decimal pcwgt = Convert.ToDecimal(DbHelperOra.GetSingle(strSql3)) + wgt;

                        if (pcwgt > Convert.ToDecimal(dtZB.Rows[0]["N_DAY_JK_ZB"]))//判定是否超出旬监控指标
                        {
                            result = false;
                        }
                        else
                        {
                            if (wgt < Convert.ToDecimal(dtZB.Rows[0]["N_PC_JK"]))//判定是否满足单项监控指标
                            {
                                result = false;
                            }
                        }
                        #endregion
                    }
                    else
                    {

                        switch (dt2.Rows[0]["C_TYPE"].ToString())
                        {
                            case "普碳钢":
                                #region //普碳钢
                                //获取当前区域当前月当旬品种总排产量
                                string strSql4 = $@"SELECT NVL(SUM(T.N_WGT), 0) N_WGT
                                              FROM V_ORDER_PLAN T
                                             WHERE T.C_TYPE IN ('普碳钢')
                                               AND T.C_AREA = '{dt2.Rows[0]["C_AREA"].ToString()}'
                                               AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
                                               AND TRUNC((TO_CHAR(T.D_DT, 'DD') - 1) / 10) ={xday}";

                                decimal pcwgt_pt = Convert.ToDecimal(DbHelperOra.GetSingle(strSql4)) + wgt;

                                if (pcwgt_pt > Convert.ToDecimal(dtZB.Rows[0]["N_DAY_PZ_ZB"]))//判定是否超出旬品种指标
                                {
                                    result = false;
                                }
                                else
                                {
                                    if (wgt < Convert.ToDecimal(dtZB.Rows[0]["N_PC_PZ"]))//判定是否满足单项品种指标
                                    {
                                        result = false;
                                    }
                                }
                                #endregion
                                break;
                            case "高速线材":
                                #region //高速线材
                                //获取当前区域当前月当旬品种总排产量
                                string strSql6 = $@"SELECT NVL(SUM(T.N_WGT), 0) N_WGT
                                              FROM V_ORDER_PLAN T
                                             WHERE T.C_TYPE IN ('普碳钢')
                                               AND T.C_AREA = '{dt2.Rows[0]["C_AREA"].ToString()}'
                                               AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
                                               AND TRUNC((TO_CHAR(T.D_DT, 'DD') - 1) / 10) ={xday}";

                                decimal pcwgt_pz = Convert.ToDecimal(DbHelperOra.GetSingle(strSql6)) + wgt;

                                if (pcwgt_pz > Convert.ToDecimal(dtZB.Rows[0]["N_DAY_PZ_ZB"]))//判定是否超出旬品种指标
                                {
                                    result = false;
                                }
                                else
                                {
                                    if (wgt < Convert.ToDecimal(dtZB.Rows[0]["N_PC_PZ"]))//判定是否满足单项品种指标
                                    {
                                        result = false;
                                    }
                                }
                                #endregion
                                break;
                            case "精品线材":
                                #region //精品线材
                                //获取当前区域当前月当旬精品总排产量
                                string strSql5 = $@"SELECT NVL(SUM(T.N_WGT), 0) N_WGT
                                              FROM V_ORDER_PLAN T
                                             WHERE T.C_TYPE IN ('精品线材')
                                               AND T.C_AREA = '{dt2.Rows[0]["C_AREA"].ToString()}'
                                               AND TO_CHAR(T.D_DT, 'YYYY-MM') = TO_CHAR(SYSDATE, 'YYYY-MM')
                                               AND TRUNC((TO_CHAR(T.D_DT, 'DD') - 1) / 10) ={xday}";
                                decimal pcwgt_jp = Convert.ToDecimal(DbHelperOra.GetSingle(strSql5)) + wgt;

                                if (pcwgt_jp > Convert.ToDecimal(dtZB.Rows[0]["N_DAY_JP_ZB"]))//判定是否超出旬精品指标
                                {
                                    result = false;
                                }
                                else
                                {
                                    if (wgt < Convert.ToDecimal(dtZB.Rows[0]["N_PC_JP"]))//判定是否满足单项精品指标
                                    {
                                        result = false;
                                    }
                                }
                                #endregion
                                break;
                        }
                    }
                }
            }

            return result;

        }

        #endregion


        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string startDt, string endDt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMO_ORDER_PCZB T");
            strSql.AppendFormat(@" where T.D_PLAN_DT >=
                    TO_DATE({0}', 'YYYY-MM-DD HH24:MI:SS')
                AND T.D_PLAN_DT <=
                    TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS')", startDt, endDt);


            return DbHelperOra.Exists(strSql.ToString());
        }
        #endregion

        #region 获取订单排产指标

        /// <summary>
        /// 获取订单排产指标
        /// </summary>
        /// <param name="startDt">计划开始日期</param>
        /// <param name="endDt">计划截至日期</param>
        /// <returns></returns>
        public DataSet GetList(string startDt)
        {
            string strSql = $@"SELECT T.C_ID, T.C_AREA,
                                                     T.N_MONTH_JK_ZB,
                                                     T.N_MONTH_JP_ZB,
                                                     T.N_MONTH_PZ_ZB,
                                                     T.N_MONTH_PT_ZB,
                              (NVL(T.N_MONTH_JP_ZB, 0) + NVL(T.N_MONTH_PZ_ZB, 0) +
                               NVL(T.N_MONTH_PT_ZB, 0)) SUM_JP_PZ, --合计
                                                     'Y' AS FLAG
                                       FROM TMO_ORDER_PCZB T
                                      WHERE TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') =
                                            TO_CHAR(TO_DATE('{startDt}', 'YYYY-MM-DD'), 'YYYY-MM')";

            DataTable dt = DbHelperOra.Query(strSql).Tables[0];
            if (dt.Rows.Count <= 0)
            {
                strSql = $@"SELECT '' AS C_ID,
                                       T.C_DETAILNAME AS C_AREA,
                                       0 AS N_MONTH_JK_ZB,
                                       0 AS N_MONTH_JP_ZB,
                                       0 AS N_MONTH_PZ_ZB,
                                       0 AS N_MONTH_PT_ZB,
                                       0 AS SUM_JP_PZ,
                                       'N' AS FLAG
                                  FROM TS_DIC T
                                 WHERE T.C_TYPECODE = 'ConArea'
                                   AND T.C_DETAILCODE NOT IN ('6', '7', '10', '11', '27')
                                 ORDER BY T.C_INDEX";

            }

            return DbHelperOra.Query(strSql);
        }
        /// <summary>
        /// 获取订单排产指标
        /// </summary>
        /// <param name="startDt">计划开始日期</param>
        /// <param name="endDt">计划截至日期</param>
        /// <returns></returns>
        public DataSet GetList(string startDt, string endDt, int n_type)
        {
            string strSql = $@"SELECT TF.C_ID,
                               TA.C_AREA,
                               TG.N_MONTH_JK_ZB, --月指标监控
                               TG.N_MONTH_JP_ZB, --月指标精品
                               TG.N_MONTH_PZ_ZB, --月指标品种
                               TG.N_MONTH_PT_ZB, --月指标普碳钢
                               (NVL(TG.N_MONTH_JP_ZB, 0) + NVL(TG.N_MONTH_PZ_ZB, 0) +
                               NVL(TG.N_MONTH_PT_ZB, 0)) SUM_JP_PZ, --合计
                               TF.N_DAY_JK_ZB, --旬指标监控
                               TF.N_DAY_JP_ZB, --旬指标精品
                               TF.N_DAY_PZ_ZB, --旬指标品种
                               TF.N_DAY_PT_ZB, --旬指标普碳钢
                               NVL(TB.N_WGT, 0) N_WGT_JK, --实际需求监控
                               NVL(TD.N_WGT, 0) N_WGT_JP, --实际需求精品
                               NVL(TC.N_WGT, 0) N_WGT_PZ, --实际需求品种
                               NVL(TH.N_WGT, 0) N_WGT_PT, --实际需求普碳钢
                               NVL(TE.N_WGT, 0) N_WGT_CON, --正常订单
                               TO_CHAR((case
                                         WHEN NVL(TE.N_WGT, 0) = 0 THEN
                                          0
                                         ELSE
                                          ROUND(NVL(TE.N_WGT, 0) /
                                                (NVL(TC.N_WGT, 0) + NVL(TD.N_WGT, 0) + NVL(TH.N_WGT, 0)) * 100,
                                                2)
                                       END)) || '%' ZB, --正常订单 /当前区域总库存
                               (NVL(TB.N_WGT, 0) - NVL(TF.N_DAY_JK_ZB, 0)) AS JK_CZ, --监控差值 
                               (NVL(TD.N_WGT, 0) - NVL(TF.N_DAY_JP_ZB, 0)) AS JP_CZ, --精品差值 
                               (NVL(TC.N_WGT, 0) - NVL(TF.N_DAY_PZ_ZB, 0)) AS PZ_CZ, --品种差值   
                               (NVL(TH.N_WGT, 0) - NVL(TF.N_DAY_PT_ZB, 0)) AS PT_CZ, --普碳差值 
                               TF.C_FLAG, --是否控制下发
                               TF.N_PC_JK, --监控下发量
                               TF.N_PC_JP, --精品下发量
                               TF.N_PC_PZ, --品种下发量
                               TF.N_PC_PT, --普碳下发量
                               (CASE
                                 WHEN TF.C_ID IS NULL THEN
                                  'N'
                                 ELSE
                                  'Y'
                               END) C_TYPE2

                          FROM (SELECT T.C_DETAILNAME AS C_AREA
                                  FROM TS_DIC T
                                 WHERE T.C_TYPECODE = 'ConArea'
                                   AND T.C_DETAILCODE NOT IN ('6', '7', '10', '11', '27')
                                 ORDER BY T.C_INDEX) TA --区域
                          LEFT JOIN (SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                       FROM V_ORDER_PLAN T
                                      WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                        AND T.D_DT >= TO_DATE('{startDt}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{endDt} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.C_FLAG = 'Y'
                                      GROUP BY T.C_AREA) TB --监控
                            ON TB.C_AREA = TA.C_AREA
                          LEFT JOIN (SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                       FROM V_ORDER_PLAN T
                                      WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                        AND T.D_DT >= TO_DATE('{startDt}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{endDt} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.C_TYPE IN ('高速线材')
                                      GROUP BY T.C_AREA) TC --品种钢
                            ON TC.C_AREA = TA.C_AREA
                          LEFT JOIN (SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                       FROM V_ORDER_PLAN T
                                      WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                        AND T.D_DT >= TO_DATE('{startDt}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{endDt} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.C_TYPE IN ('普碳钢')
                                      GROUP BY T.C_AREA) TH --普碳钢
                            ON TH.C_AREA = TA.C_AREA
                          LEFT JOIN (
             
                                     SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                       FROM V_ORDER_PLAN T
                                      WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                        AND T.D_DT >= TO_DATE('{startDt}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{endDt} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.C_TYPE IN ('精品线材')
                                      GROUP BY T.C_AREA) TD --精品
                            ON TD.C_AREA = TA.C_AREA
                          LEFT JOIN (SELECT T.C_AREA, SUM(T.N_WGT) N_WGT
                                       FROM V_ORDER_PLAN T
                                      WHERE T.N_EXEC_STATUS IN (-1, 0, 2, 6)
                                        AND T.D_DT >= TO_DATE('{startDt}', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.D_DT <=
                                            TO_DATE('{endDt} 23:59:59', 'YYYY-MM-DD HH24:MI:SS')
                                        AND T.ORDER_FLAG = 0
                                      GROUP BY T.C_AREA) TE --正常订单需求量
                            ON TE.C_AREA = TA.C_AREA
                          LEFT JOIN (SELECT T.C_ID,
                                            T.C_AREA,
                                            T.N_MONTH_JK_ZB,
                                            T.N_MONTH_JP_ZB,
                                            T.N_MONTH_PZ_ZB,
                                            T.N_MONTH_PT_ZB,
                                            T.N_DAY_JK_ZB,
                                            T.N_DAY_JP_ZB,
                                            T.N_DAY_PZ_ZB,
                                            T.N_DAY_PT_ZB,
                                            T.N_TYPE,
                                            T.C_FLAG,
                                            T.N_PC_JK,
                                            T.N_PC_JP,
                                            T.N_PC_PZ,
                                            T.N_PC_PT
             
                                       FROM TMO_ORDER_PCZB T
                                      WHERE T.N_TYPE = {n_type}
                                        AND TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') =
                                            TO_CHAR(TO_DATE('{endDt}', 'YYYY-MM-DD'), 'YYYY-MM')) TF
                            ON TF.C_AREA = TA.C_AREA

                          LEFT JOIN (SELECT DISTINCT T.C_AREA,
                                                     T.N_MONTH_JK_ZB,
                                                     T.N_MONTH_JP_ZB,
                                                     T.N_MONTH_PZ_ZB,
                                                     T.N_MONTH_PT_ZB
                                       FROM TMO_ORDER_PCZB T
                                      WHERE TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') =
                                            TO_CHAR(TO_DATE('{endDt}', 'YYYY-MM-DD'), 'YYYY-MM')) TG
                            ON TG.C_AREA = TA.C_AREA";
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region 获取下旬指标= 月指标 减去 旬指标总和
        /// <summary>
        /// 获取下旬指标
        /// </summary>
        /// <param name="endDt">计划日期</param>
        /// <param name="area">区域</param>
        /// <returns></returns>
        public DataSet GetZB(string endDt, string area)
        {
            string strSql = $@"SELECT T.C_AREA,
                               T.N_MONTH_JK_ZB,
                               T.N_MONTH_JP_ZB,
                               T.N_MONTH_PZ_ZB,
                               T.N_MONTH_PT_ZB,
                               (NVL(T.N_MONTH_JK_ZB,0)-SUM(T.N_DAY_JK_ZB)) AS JKZB,
                                (NVL(T.N_MONTH_JP_ZB,0)-SUM(T.N_DAY_JP_ZB)) AS JPZB,
                                (NVL(T.N_MONTH_PZ_ZB,0)-SUM(T.N_DAY_PZ_ZB)) AS PZZB,
                                (NVL(T.N_MONTH_PT_ZB,0)-SUM(T.N_DAY_PT_ZB)) AS PTZB
                          FROM TMO_ORDER_PCZB T
                         WHERE  T.C_AREA='{area}' AND  TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') =
                                            TO_CHAR(TO_DATE('{endDt}', 'YYYY-MM-DD'), 'YYYY-MM') 
                         GROUP BY T.C_AREA, T.N_MONTH_JK_ZB, T.N_MONTH_JP_ZB, T.N_MONTH_PZ_ZB,T.N_MONTH_PT_ZB";
            return DbHelperOra.Query(strSql);
        }
        #endregion

        #region 添加/更新指标2
        /// <summary>
        /// 添加/更新指标
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update2(List<Mod_TMO_ORDER_PCZB> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    if (mod.C_TYPE2 == "N")
                    {
                        #region //添加
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("INSERT INTO TMO_ORDER_PCZB(");
                        strSql.Append("C_AREA,");
                        strSql.Append("N_MONTH_JK_ZB,");
                        strSql.Append("N_MONTH_JP_ZB,");
                        strSql.Append("N_MONTH_PZ_ZB,");
                        strSql.Append("N_MONTH_PT_ZB,");
                        strSql.Append("D_PLAN_DT,");
                        strSql.Append("C_CREATE_ID");

                        strSql.Append(")VALUES(");
                        strSql.AppendFormat("'{0}',", mod.C_AREA);//区域
                        strSql.AppendFormat("{0},", mod.N_MONTH_JK_ZB);//月监控指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_JP_ZB);//月精品指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_PZ_ZB);//月品种指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_PT_ZB);//月普碳指标
                        strSql.AppendFormat("TO_DATE('{0}', 'yyyy-mm-dd hh24:mi:ss'),", mod.D_PLAN_DT);//计划排产日期
                        strSql.AppendFormat("'{0}'", mod.C_CREATE_ID);//制单人                     
                        strSql.Append(")");
                        arraySql.Add(strSql.ToString());
                        #endregion
                    }
                    else
                    {
                        #region //更新
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.AppendFormat("UPDATE TMO_ORDER_PCZB SET ");
                        strSql2.AppendFormat("N_MONTH_JK_ZB={0},", mod.N_MONTH_JK_ZB);
                        strSql2.AppendFormat("N_MONTH_JP_ZB={0},", mod.N_MONTH_JP_ZB);
                        strSql2.AppendFormat("N_MONTH_PZ_ZB={0},", mod.N_MONTH_PZ_ZB);
                        strSql2.AppendFormat("N_MONTH_PT_ZB={0}", mod.N_MONTH_PT_ZB);

                        strSql2.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
                        arraySql.Add(strSql2.ToString());
                        #endregion
                    }
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion


        #region 添加/更新指标
        /// <summary>
        /// 添加/更新指标
        /// </summary>
        /// <param name="list">参数</param>
        /// <returns></returns>
        public bool Insert_Update(List<Mod_TMO_ORDER_PCZB> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    if (mod.C_TYPE2 == "N")
                    {
                        #region //添加
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("INSERT INTO TMO_ORDER_PCZB(");
                        strSql.Append("C_AREA,");
                        strSql.Append("N_MONTH_JK_ZB,");
                        strSql.Append("N_MONTH_JP_ZB,");
                        strSql.Append("N_MONTH_PZ_ZB,");
                        strSql.Append("N_MONTH_PT_ZB,");
                        strSql.Append("N_DAY_JK_ZB,");
                        strSql.Append("N_DAY_JP_ZB,");
                        strSql.Append("N_DAY_PZ_ZB,");
                        strSql.Append("N_DAY_PT_ZB,");
                        strSql.Append("D_PLAN_DT,");
                        strSql.Append("N_TYPE,");
                        strSql.Append("C_CREATE_ID,");
                        strSql.Append("C_EMP_ID,");
                        strSql.Append("D_EMP_DT,");
                        strSql.Append("N_PC_JK,");
                        strSql.Append("N_PC_JP,");
                        strSql.Append("N_PC_PZ,");
                        strSql.Append("N_PC_PT,");
                        strSql.Append("N_SORT");
                        strSql.Append(")VALUES(");
                        strSql.AppendFormat("'{0}',", mod.C_AREA);//区域
                        strSql.AppendFormat("{0},", mod.N_MONTH_JK_ZB);//月监控指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_JP_ZB);//月精品指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_PZ_ZB);//月品种指标
                        strSql.AppendFormat("{0},", mod.N_MONTH_PT_ZB);//月普碳指标
                        strSql.AppendFormat("{0},", mod.N_DAY_JK_ZB);//旬监控指标
                        strSql.AppendFormat("{0},", mod.N_DAY_JP_ZB);//旬精品指标
                        strSql.AppendFormat("{0},", mod.N_DAY_PZ_ZB);//旬品种指标
                        strSql.AppendFormat("{0},", mod.N_DAY_PT_ZB);//旬普碳指标
                        strSql.AppendFormat("TO_DATE('{0}', 'yyyy-mm-dd hh24:mi:ss'),", mod.D_PLAN_DT);//计划排产日期
                        strSql.AppendFormat("{0},", mod.N_TYPE);//1上旬 ，2中旬，3下旬
                        strSql.AppendFormat("'{0}',", mod.C_CREATE_ID);//制单人
                        strSql.AppendFormat("'{0}',", mod.C_EMP_ID);//最后修改人
                        strSql.AppendFormat("TO_DATE('{0}', 'yyyy-mm-dd hh24:mi:ss'),", mod.D_EMP_DT);//最后修改时间
                        strSql.AppendFormat("{0},", mod.N_PC_JK);//监控下发范围
                        strSql.AppendFormat("{0},", mod.N_PC_JP);//精品下发范围
                        strSql.AppendFormat("{0},", mod.N_PC_PZ);//品种下发范围
                        strSql.AppendFormat("{0},", mod.N_PC_PT);//普碳下发范围
                        strSql.AppendFormat("{0}", mod.N_SORT);//排序
                        strSql.Append(")");
                        arraySql.Add(strSql.ToString());
                        #endregion
                    }
                    else
                    {
                        #region //更新
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.AppendFormat("UPDATE TMO_ORDER_PCZB SET ");
                        strSql2.AppendFormat("N_MONTH_JK_ZB={0},", mod.N_MONTH_JK_ZB);
                        strSql2.AppendFormat("N_MONTH_JP_ZB={0},", mod.N_MONTH_JP_ZB);
                        strSql2.AppendFormat("N_MONTH_PZ_ZB={0},", mod.N_MONTH_PZ_ZB);
                        strSql2.AppendFormat("N_MONTH_PT_ZB={0},", mod.N_MONTH_PT_ZB);
                        strSql2.AppendFormat("N_DAY_JK_ZB={0},", mod.N_DAY_JK_ZB);
                        strSql2.AppendFormat("N_DAY_JP_ZB={0},", mod.N_DAY_JP_ZB);
                        strSql2.AppendFormat("N_DAY_PZ_ZB={0},", mod.N_DAY_PZ_ZB);
                        strSql2.AppendFormat("N_DAY_PT_ZB={0},", mod.N_DAY_PT_ZB);
                        strSql2.AppendFormat("C_EMP_ID='{0}',", mod.C_EMP_ID);
                        strSql2.AppendFormat("D_EMP_DT=TO_DATE('{0}', 'yyyy-mm-dd hh24:mi:ss'),", mod.D_EMP_DT);
                        strSql2.AppendFormat("N_PC_JK={0},", mod.N_PC_JK);
                        strSql2.AppendFormat("N_PC_JP={0},", mod.N_PC_JP);
                        strSql2.AppendFormat("N_PC_PZ={0}", mod.N_PC_PZ);
                        strSql2.AppendFormat("N_PC_PT={0}", mod.N_PC_PT);
                        strSql2.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
                        arraySql.Add(strSql2.ToString());
                        #endregion
                    }
                }
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region 指标控制
        /// <summary>
        /// 指标控制
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateFlag(List<Mod_TMO_ORDER_PCZB> list)
        {
            ArrayList arraySql = new ArrayList();

            if (list.Count > 0)
            {
                foreach (var mod in list)
                {
                    if (mod.C_TYPE2 == "Y")
                    {
                        #region //更新
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.AppendFormat("UPDATE TMO_ORDER_PCZB SET ");
                        strSql2.AppendFormat("C_FLAG='{0}',", mod.C_FLAG);
                        strSql2.AppendFormat("C_EMP_ID='{0}',", mod.C_EMP_ID);
                        strSql2.AppendFormat("D_EMP_DT=TO_DATE('{0}', 'yyyy-mm-dd hh24:mi:ss')", mod.D_EMP_DT);

                        strSql2.AppendFormat(" WHERE C_ID='{0}'", mod.C_ID);
                        arraySql.Add(strSql2.ToString());
                        #endregion
                    }
                }
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion

        #region 删除当月旬指标
        /// <summary>
        /// 删除当月旬指标
        /// </summary>
        /// <param name="endDt">提报日期</param>
        /// <param name="type">旬1上旬，2中旬，3下旬</param>
        /// <returns></returns>
        public bool DelZB(string endDt, int type)
        {
            string strSql = $@"DELETE FROM TMO_ORDER_PCZB T
                                 WHERE T.N_TYPE ={type}
                                   AND TO_CHAR(T.D_PLAN_DT, 'YYYY-MM') =
                                       TO_CHAR(TO_DATE('{endDt}', 'YYYY-MM-DD'), 'YYYY-MM')";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }
        #endregion

        #region 删除当月旬指标2
        /// <summary>
        /// 删除当月旬指标
        /// </summary>
        /// <param name="endDt">提报日期</param>
        /// <param name="type">旬1上旬，2中旬，3下旬</param>
        /// <returns></returns>
        public bool DelZB2(List<Mod_TMO_ORDER_PCZB> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"DELETE FROM TMO_ORDER_PCZB T
                                 WHERE T.C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion




    }
}
