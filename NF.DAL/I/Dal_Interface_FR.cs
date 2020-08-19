using NF.MODEL;
using NF.DAL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ZXing;
using System.Drawing;

namespace NF.DAL.I
{
    public partial class Dal_Interface_FR
    {
        Dal_TB_STA dal_TB_STA = new Dal_TB_STA();
        Dal_TS_DIC dal_ts_dic = new Dal_TS_DIC();
        Dal_TB_MATRL_MAIN dal_matra = new Dal_TB_MATRL_MAIN();
        Dal_TB_STD_CONFIG dalTbStdConfig = new Dal_TB_STD_CONFIG();
        Dal_Interface_NC_XC dal_Interface_NC_XC = new Dal_Interface_NC_XC();
        Dal_Interface_NC_Roll_ZK4I dal_Interface_NC_Roll_ZK4I = new Dal_Interface_NC_Roll_ZK4I();
        Dal_Interface_NC_Roll_ZK4A dal_Interface_NC_Roll_ZK4A = new Dal_Interface_NC_Roll_ZK4A();
        Dal_Interface_NC_Roll_QT4A dal_Interface_NC_Roll_QT4A = new Dal_Interface_NC_Roll_QT4A();
        Dal_Interface_NC_Roll_QT4I dal_Interface_NC_Roll_QT4I = new Dal_Interface_NC_Roll_QT4I();
        public Dal_Interface_FR()
        { }
        /// <summary>
        /// 根据批号、钩号判断本地库存是否存在当前卷信息
        /// </summary>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <returns>是否存在</returns>
        public bool Exists(string PH, string GH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_PRODCUT ");
            strSql.Append(" where C_BATCH_NO='" + PH + "' and  C_TICK_NO ='" + GH + "'");
            return DbHelperOra.Exists(strSql.ToString());
        }

        #region 同步条码库存信息

        /// <summary>
        /// 获取条码库存信息
        /// </summary>
        /// <param name="Barcode">钢卷唯一码</param>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="WGDH">完工单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>条码库存信息</returns>
        public DataSet GetKCList(string Barcode, string CK, string HW, string WGDH, string PH, string GH, string GZ)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T1.BARCODE, T1.WGDH, T1.CK, T1.HW, T1.PCH, T1.WLH, T1.WLMC, T1.SX, T1.PH, T1.GG, T1.BB AS RKBB, T1.GH, T1.ZL, T1.BZ, T1.RQ, T1.RKTYPE, T1.RKRY, T1.WEIGHTRQ, T1.PRODUCEDATA, T1.VFREE1, T1.VFREE2, T1.VFREE3,T1.ERRSEASON,T1.PCInfo, T2.BB AS SCBB, T2.SCX, T2.ZXBZ, T2.VFREE0 ");

            strSql.Append(" FROM WMS_BMS_INV_INFO T1 JOIN WMS_BMS_REC_WGD T2 ON T1.WGDH = T2.WGDH  ");
            if (Barcode.Trim() != "")
            {
                strSql.Append(" and  T1.Barcode='" + Barcode + "' ");
            }
            if (CK.Trim() != "")
            {
                strSql.Append(" and  T1.CK='" + CK + "' ");
            }
            if (HW.Trim() != "")
            {
                strSql.Append(" and  T1.HW='" + HW + "' ");
            }
            if (WGDH.Trim() != "")
            {
                strSql.Append(" and  T1.WGDH='" + WGDH + "' ");
            }
            if (PH.Trim() != "")
            {
                strSql.Append(" and  T1.PCH='" + PH + "' ");
            }
            if (GH.Trim() != "")
            {
                strSql.Append(" and  T1.GH='" + GH + "' ");
            }
            if (GZ.Trim() != "")
            {
                strSql.Append(" and  T1.PH='" + GZ + "' ");
            }
            strSql.Append(" ORDER BY T1.RQ,T1.Barcode ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取质量设计号
        /// </summary>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public string Get_Design_No(string C_STD_CODE, string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TB.C_DESIGN_NO FROM TQB_STD_MAIN TA INNER JOIN TQB_DESIGN TB ON TA.C_ID=TB.C_STD_MAIN_ID WHERE TA.C_STD_CODE='" + C_STD_CODE + "' AND TA.C_STL_GRD='" + C_STL_GRD + "' ");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 获取工位id
        /// </summary>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public string GetSTA(string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ID  FROM TB_STA WHERE C_STA_CODE LIKE '%" + batch + "%'");

            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        ///同步条码库存信息
        /// </summary>
        /// <param name="Barcode">钢卷唯一码</param>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="WGDH">完工单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>同步结果</returns>
        public string TbKCList(string Barcode, string CK, string HW, string WGDH, string PH, string GH, string GZ)
        {
            string strResult = "";//同步结果
            int iUpdate = 0;//更新成功记录数
            int iUpdateE = 0;//更新失败记录数
            int iInsert = 0;//插入成功记录数
            int iInsertE = 0;//插入失败记录数
            DataTable dt = GetKCList(Barcode, CK, HW, WGDH, PH, GH, GZ).Tables[0];
            string strDesignNo = "";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strFree1 = dt.Rows[i]["VFREE1"].ToString();
                        string strFree2 = dt.Rows[i]["VFREE2"].ToString();
                        //strFree1 = strFree1.Replace(" ", "");
                        //strFree2 = strFree2.Replace(" ", "");
                        //strFree1 = strFree1.Replace("（", "");
                        //strFree2 = strFree2.Replace("（", "");
                        //strFree1 = strFree1.Replace("）", "");
                        //strFree2 = strFree2.Replace("）", "");
                        string spec = dt.Rows[i]["GG"].ToString().Replace("mm", "");
                        string strStdCode = dalTbStdConfig.Get_Std_Code(strFree1, strFree2);//获取质量等级
                        string strarea = dt.Rows[i]["HW"].ToString();
                        string batch = dt.Rows[i]["PCH"].ToString().Substring(1, 1);
                        string staid = GetSTA(batch);
                        if (strarea.Length > 4)
                        {
                            strarea = strarea.Substring(0, 5);
                        }
                        if (strStdCode != "")
                        {
                            strDesignNo = Get_Design_No(strStdCode, dt.Rows[i]["PH"].ToString());
                        }
                        //查询订单
                        string InsertSql = "INSERT INTO TRC_ROLL_PRODCUT (C_ID,C_BARCODE, C_TRC_ROLL_MAIN_ID, C_LINEWH_CODE, C_LINEWH_LOC_CODE, C_BATCH_NO, C_MAT_CODE, C_MAT_DESC, C_JUDGE_LEV_ZH,C_REASON_NAME, C_STL_GRD, C_SPEC, C_DP_GROUP, C_TICK_NO, N_WGT, C_STD_CODE, D_RKRQ, C_MOVE_DESC, C_RKRY, D_WEIGHT_DT, D_MOD_DT, C_ZYX1, C_ZYX2, C_BZYQ, C_GROUP, C_PLANT_ID,  C_STOVE ,C_STA_ID,C_MOVE_TYPE,C_ORDER_NO,C_DESIGN_NO,D_DP_DT,C_IS_QR,C_IS_TB,C_IS_PD,D_PRODUCE_DATE,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["WGDH"].ToString() + "','" + dt.Rows[i]["CK"].ToString() + "','" + dt.Rows[i]["HW"].ToString() + "','" + dt.Rows[i]["PCH"].ToString() + "','" + dt.Rows[i]["WLH"].ToString() + "','" + dt.Rows[i]["WLMC"].ToString() + "','" + dt.Rows[i]["SX"].ToString() + "','" + dt.Rows[i]["ERRSEASON"].ToString() + "','" + dt.Rows[i]["PH"].ToString() + "','" + spec + "','" + dt.Rows[i]["RKBB"].ToString() + "','" + dt.Rows[i]["GH"].ToString() + "','" + dt.Rows[i]["ZL"].ToString() + "','" + strStdCode + "',to_date( '" + dt.Rows[i]["RQ"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dt.Rows[i]["RKTYPE"].ToString() + "',SUBSTR( '" + dt.Rows[i]["RKRY"].ToString() + "',0,5), TO_DATE('" + dt.Rows[i]["WEIGHTRQ"].ToString() + "', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE(REPLACE('" + dt.Rows[i]["PRODUCEDATA"].ToString() + "', '.', '-'), 'YYYY-MM-DD HH24:MI:SS'),'" + strFree1 + "','" + strFree2 + "','" + dt.Rows[i]["VFREE3"].ToString() + "','" + dt.Rows[i]["SCBB"].ToString() + "','" + dt.Rows[i]["SCX"].ToString() + "','" + dt.Rows[i]["VFREE0"].ToString() + "','" + staid + "','E','','" + strDesignNo + "',TO_DATE('" + dt.Rows[i]["WEIGHTRQ"].ToString() + "', 'YYYY-MM-DD HH24:MI:SS'),'Y','Y','Y', TO_DATE(REPLACE('" + dt.Rows[i]["PRODUCEDATA"].ToString() + "', '.', '-'), 'YYYY-MM-DD HH24:MI:SS'), '" + dt.Rows[i]["SX"].ToString() + "','" + strarea + "','" + dt.Rows[i]["PCInfo"].ToString() + "')";
                        int a = DbHelperOra.ExecuteSql(InsertSql);
                        iInsert = iInsert + 1;
                    }
                    strResult = "数据已同步：\r\n更新成功：" + iUpdate.ToString() + "\r\n更新失败：" + iUpdateE.ToString() + "\r\n新增成功：" + iInsert.ToString() + "\r\n新增失败：" + iInsertE.ToString();
                }
                else
                {
                    strResult = "没有查到需要同步的库存信息！";

                }
                return strResult;
            }
            catch (Exception ex)
            {

                string name = "Dal_Interface_FR.TbKCList";
                string LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码库存信息','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                return "代码错误！";
            }
        }
        public int DelTM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE TRC_ROLL_PRODUCT_TM");

            object obj = DbHelperOra.ExecuteSql(strSql.ToString());

            return Convert.ToInt32(obj);
        }
        /// <summary>
        ///同步条码库存信息
        /// </summary>
        /// <param name="Barcode">钢卷唯一码</param>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="WGDH">完工单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>同步结果</returns>
        public string TbPCIList()
        {
            string strResult = "";//同步结果
            int iUpdate = 0;//更新成功记录数
            int iUpdateE = 0;//更新失败记录数
            int iInsert = 0;//插入成功记录数
            int iInsertE = 0;//插入失败记录数
            DataTable dt = GetKCList("", "", "", "", "", "", "").Tables[0];
            string strDesignNo = "";
            try
            {
                DelTM();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strFree1 = dt.Rows[i]["VFREE1"].ToString();
                        string strFree2 = dt.Rows[i]["VFREE2"].ToString();
                        //strFree1 = strFree1.Replace(" ", "");
                        //strFree2 = strFree2.Replace(" ", "");
                        //strFree1 = strFree1.Replace("（", "");
                        //strFree2 = strFree2.Replace("（", "");
                        //strFree1 = strFree1.Replace("）", "");
                        //strFree2 = strFree2.Replace("）", "");
                        string spec = dt.Rows[i]["GG"].ToString().Replace("mm", "");
                        string strStdCode = dalTbStdConfig.Get_Std_Code(strFree1, strFree2);//获取质量等级
                        string strarea = dt.Rows[i]["HW"].ToString();
                        string batch = dt.Rows[i]["PCH"].ToString().Substring(1, 1);
                        string staid = GetSTA(batch);
                        if (strarea.Length > 4)
                        {
                            strarea = strarea.Substring(0, 4);
                        }
                        if (strStdCode != "")
                        {
                            strDesignNo = Get_Design_No(strStdCode, dt.Rows[i]["PH"].ToString());
                        }
                        //查询订单
                        string InsertSql = "INSERT INTO TRC_ROLL_PRODUCT_TM (C_ID,C_BARCODE, C_TRC_ROLL_MAIN_ID, C_LINEWH_CODE, C_LINEWH_LOC_CODE, C_BATCH_NO, C_MAT_CODE, C_MAT_DESC, C_JUDGE_LEV_ZH,C_REASON_NAME, C_STL_GRD, C_SPEC, C_DP_GROUP, C_TICK_NO, N_WGT, C_STD_CODE, D_RKRQ, C_MOVE_DESC, C_RKRY, D_WEIGHT_DT, D_MOD_DT, C_ZYX1, C_ZYX2, C_BZYQ, C_GROUP, C_PLANT_ID,  C_STOVE ,C_STA_ID,C_MOVE_TYPE,C_ORDER_NO,C_DESIGN_NO,D_DP_DT,C_IS_QR,C_IS_TB,C_IS_PD,D_PRODUCE_DATE,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA) VALUES ('" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["BARCODE"].ToString() + "','" + dt.Rows[i]["WGDH"].ToString() + "','" + dt.Rows[i]["CK"].ToString() + "','" + dt.Rows[i]["HW"].ToString() + "','" + dt.Rows[i]["PCH"].ToString() + "','" + dt.Rows[i]["WLH"].ToString() + "','" + dt.Rows[i]["WLMC"].ToString() + "','" + dt.Rows[i]["SX"].ToString() + "','" + dt.Rows[i]["ERRSEASON"].ToString() + "','" + dt.Rows[i]["PH"].ToString() + "','" + spec + "','" + dt.Rows[i]["RKBB"].ToString() + "','" + dt.Rows[i]["GH"].ToString() + "','" + dt.Rows[i]["ZL"].ToString() + "','" + strStdCode + "',to_date( '" + dt.Rows[i]["RQ"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dt.Rows[i]["RKTYPE"].ToString() + "',SUBSTR( '" + dt.Rows[i]["RKRY"].ToString() + "',0,5), TO_DATE('" + dt.Rows[i]["WEIGHTRQ"].ToString() + "', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE(REPLACE('" + dt.Rows[i]["PRODUCEDATA"].ToString() + "', '.', '-'), 'YYYY-MM-DD HH24:MI:SS'),'" + strFree1 + "','" + strFree2 + "','" + dt.Rows[i]["VFREE3"].ToString() + "','" + dt.Rows[i]["SCBB"].ToString() + "','" + dt.Rows[i]["SCX"].ToString() + "','" + dt.Rows[i]["VFREE0"].ToString() + "','" + staid + "','E','','" + strDesignNo + "',TO_DATE('" + dt.Rows[i]["WEIGHTRQ"].ToString() + "', 'YYYY-MM-DD HH24:MI:SS'),'Y','Y','Y', TO_DATE(REPLACE('" + dt.Rows[i]["PRODUCEDATA"].ToString() + "', '.', '-'), 'YYYY-MM-DD HH24:MI:SS'), '" + dt.Rows[i]["SX"].ToString() + "','" + strarea + "','" + dt.Rows[i]["PCInfo"].ToString() + "')";
                        int a = DbHelperOra.ExecuteSql(InsertSql);
                        iInsert = iInsert + 1;
                    }
                    strResult = "数据已同步：\r\n更新成功：" + iUpdate.ToString() + "\r\n更新失败：" + iUpdateE.ToString() + "\r\n新增成功：" + iInsert.ToString() + "\r\n新增失败：" + iInsertE.ToString();
                }
                else
                {
                    strResult = "没有查到需要同步的库存信息！";

                }
                return strResult;
            }
            catch (Exception ex)
            {

                string name = "Dal_Interface_FR.TbKCList";
                string LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码库存信息','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                return "代码错误！";
            }
        }
        #endregion

        #region 同步条码出库信息

        /// 获取条码库存信息
        /// </summary>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="FYDH">发运单号</param>
        /// <param name="RKDH">入库单号</param>
        /// <param name="CKDH">出库单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>条码库存信息</returns>
        public DataSet GetList(string CK, string HW, string FYDH, string RKDH, string CKDH, string PH, string GH, string GZ)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" Barcode,RKDH,FYDH,CKDH,CK,HW,PCH,WLH,WLMC,SX,ZLDJ,PH,GG,BB,GH,ZL,BZ,RQ,Flag,CKRY,CXH,KHBM,WeightRQ,CKCXH,ProduceData,Filed1,PCInfo,Filed2,ErrSeason,vfree0,vfree1,vfree2,vfree3,vfree4,ysmz  ");
            strSql.Append(" FROM WMS_Bms_Inv_OutInfo where 1=1 ");
            if (CK.Trim() != "")
            {
                strSql.Append(" and  CK='" + CK + "' ");
            }
            if (HW.Trim() != "")
            {
                strSql.Append(" and  HW='" + HW + "' ");
            }
            if (FYDH.Trim() != "")
            {
                strSql.Append(" and  FYDH='" + FYDH + "' ");
            }
            if (RKDH.Trim() != "")
            {
                strSql.Append(" and  RKDH='" + RKDH + "' ");
            }
            if (CKDH.Trim() != "")
            {
                strSql.Append(" and  CKDH='" + CKDH + "' ");
            }
            if (PH.Trim() != "")
            {
                strSql.Append(" and  PCH='" + PH + "' ");
            }

            if (GH.Trim() != "")
            {
                strSql.Append(" and  GH='" + GH + "' ");
            }

            if (GZ.Trim() != "")
            {
                strSql.Append(" and  PH='" + GZ + "' ");
            }
            strSql.Append(" order by  Barcode ");
            return DbHelper_SQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取条码库存信息
        /// </summary>
        /// <param name="CK">仓库</param>
        /// <param name="HW">货位</param>
        /// <param name="FYDH">发运单号</param>
        /// <param name="RKDH">入库单号</param>
        /// <param name="CKDH">出库单号</param>
        /// <param name="PH">批号</param>
        /// <param name="GH">钩号</param>
        /// <param name="GZ">钢种</param>
        /// <returns>条码库存信息</returns>
        public string TbRFCK(string CK, string HW, string FYDH, string RKDH, string CKDH, string PH, string GH, string GZ)
        {
            string strResult = "";//同步结果
            int iUpdate = 0;//更新成功记录数
            int iUpdateE = 0;//更新失败记录数
            int iInsert = 0;//插入成功记录数
            int iInsertE = 0;//插入失败记录数
            //同步出库信息
            DataTable dt2 = GetList(CK, HW, FYDH, RKDH, CKDH, PH, GH, GZ).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    // Mod_TRC_ROLL_PRODCUT mod = bll_pci_kc.GetModel(dt2.Rows[i]["PCH"].ToString(), dt2.Rows[i]["GH"].ToString());//判断是否存在
                    if (Exists(dt2.Rows[i]["PCH"].ToString(), dt2.Rows[i]["GH"].ToString()))//当前库已经存在该卷
                    {

                        try
                        {
                            string updateSql = " UPDATE TRC_ROLL_PRODCUT T SET ";
                            //updateSql = updateSql + " C_BATCH_NO = '" + dt2.Rows[i]["PCH"].ToString() + "'";
                            //updateSql = updateSql + " C_TICK_NO =  '" + dt2.Rows[i]["GH"].ToString() + "'";
                            updateSql = updateSql + " C_STL_GRD =  '" + dt2.Rows[i]["PH"].ToString() + "'";
                            updateSql = updateSql + " ,N_WGT = Convert.ToDecimal( '" + dt2.Rows[i]["ZL"].ToString() + "')";
                            updateSql = updateSql + " ,C_MOVE_TYPE = 'S'";
                            updateSql = updateSql + " ,C_SPEC =  '" + dt2.Rows[i]["GG"].ToString() + "'";
                            updateSql = updateSql + " ,C_DP_SHIFT =  '" + dt2.Rows[i]["BB"].ToString() + "'";
                            updateSql = updateSql + " ,D_DP_DT = Convert.ToDateTime( '" + dt2.Rows[i]["WeightRQ"].ToString() + "')";
                            updateSql = updateSql + " ,C_MAT_CODE =  '" + dt2.Rows[i]["WLH"].ToString() + "'";
                            updateSql = updateSql + " ,C_MAT_DESC =  '" + dt2.Rows[i]["WLMC"].ToString() + "'";
                            updateSql = updateSql + " ,C_LINEWH_CODE =  '" + dt2.Rows[i]["CK"].ToString() + "'";
                            updateSql = updateSql + " ,C_LINEWH_LOC_CODE =  '" + dt2.Rows[i]["HW"].ToString() + "'";
                            updateSql = updateSql + " ,C_SALE_AREA =  '" + dt2.Rows[i]["PCInfo"].ToString() + "'";
                            updateSql = updateSql + " ,C_JUDGE_LEV_ZH =  '" + dt2.Rows[i]["SX"].ToString() + "'";
                            updateSql = updateSql + " ,C_BARCODE =  '" + dt2.Rows[i]["Barcode"].ToString() + "'";
                            // mod.C_RKDH = dt1.Rows[i]["RKDH"].ToString();
                            updateSql = updateSql + " ,C_FYDH =  '" + dt2.Rows[i]["FYDH"].ToString() + "'";
                            updateSql = updateSql + " ,C_CKDH =  '" + dt2.Rows[i]["CKDH"].ToString() + "'";
                            updateSql = updateSql + " ,C_MOVE_DESC =  '" + dt2.Rows[i]["Flag"].ToString() + "'";

                            updateSql = updateSql + " ,C_CKRY = SUBSTR( '" + dt2.Rows[i]["CKRY"].ToString().Trim() + "',0,5)";
                            updateSql = updateSql + " ,D_CKRQ = Convert.ToDateTime( '" + dt2.Rows[i]["RQ"].ToString() + "')";
                            updateSql = updateSql + " ,_BZYQ =  '" + dt2.Rows[i]["vfree3"].ToString() + "'";
                            updateSql = updateSql + " D_MOD_DT = Convert.ToDateTime( '" + dt2.Rows[i]["ProduceData"].ToString().Replace(".", "- ") + "')";
                            updateSql = updateSql + "  WHERE  C_BATCH_NO = '" + dt2.Rows[i]["PCH"].ToString() + "' AND C_TICK_NO =  '" + dt2.Rows[i]["GH"].ToString() + "' ";
                            int res = DbHelperOra.ExecuteSql(updateSql);
                            iUpdate = iUpdate + 1;

                        }
                        catch (Exception ex)
                        {
                            string name = "Dal_Interface_FR.TbRFCK:PH=" + dt2.Rows[i]["PCH"].ToString() + ",  GH=" + dt2.Rows[i]["GH"].ToString() + "";
                            string LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码库存信息','" + ex.ToString() + "','" + name + "')";
                            iUpdateE = iUpdateE + 1;

                        }
                    }
                    else//插入
                    {
                        try
                        {
                            string DD = "";
                            string insertSql = " INSERT INTO TRC_ROLL_PRODCUT ( C_ID ,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_MOVE_TYPE,C_SPEC,C_DP_SHIFT,D_DP_DT,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_SALE_AREA,C_JUDGE_LEV_ZH,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_BZYQ,D_MOD_DT) VALUES ('" + dt2.Rows[i]["Barcode"].ToString() + "','" + dt2.Rows[i]["PCH"].ToString() + "','" + dt2.Rows[i]["GH"].ToString() + "','" + dt2.Rows[i]["PH"].ToString() + "'," + Convert.ToDecimal(dt2.Rows[i]["ZL"].ToString()) + ",'S','" + dt2.Rows[i]["GG"].ToString() + "','" + dt2.Rows[i]["BB"].ToString() + "',TO_DATE('" + dt2.Rows[i]["WeightRQ"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dt2.Rows[i]["WLH"].ToString() + "','" + dt2.Rows[i]["WLMC"].ToString() + "','" + dt2.Rows[i]["CK"].ToString() + "','" + dt2.Rows[i]["HW"].ToString() + "','" + dt2.Rows[i]["PCInfo"].ToString() + "','" + dt2.Rows[i]["SX"].ToString() + "','" + dt2.Rows[i]["Barcode"].ToString() + "','" + dt2.Rows[i]["RKDH"].ToString() + "','" + dt2.Rows[i]["FYDH"].ToString() + "','" + dt2.Rows[i]["CKDH"].ToString() + "','" + dt2.Rows[i]["Flag"].ToString() + "',SUBSTR('" + dt2.Rows[i]["CKRY"].ToString() + "',0,5),TO_DATE('" + dt2.Rows[i]["RQ"].ToString() + "','yyyy-mm-dd hh24:mi:ss'),'" + dt2.Rows[i]["vfree3"].ToString() + "',to_date('" + dt2.Rows[i]["ProduceData"].ToString().Replace(".", "-") + "','yyyy-mm-dd hh24:mi:ss'))";
                            int res = DbHelperOra.ExecuteSql(insertSql);
                            iInsert = iInsert + 1;
                        }
                        catch (Exception ex)
                        {
                            string name = "Dal_Interface_FR.TbRFCK:PH=" + dt2.Rows[i]["PCH"].ToString() + ",  GH=" + dt2.Rows[i]["GH"].ToString() + "";
                            string LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码库存信息','" + ex.ToString() + "','" + name + "')";
                            iInsertE = iInsertE + 1;

                        }
                    }

                    strResult = "数据已同步：\r\n更新成功：" + iUpdate.ToString() + "\r\n更新失败：" + iUpdateE.ToString() + "\r\n新增成功：" + iInsert.ToString() + "\r\n新增失败：" + iInsertE.ToString();
                }
            }
            else
            {
                strResult = "没有查到需要同步的库存信息！";
            }
            return strResult;
        }
        #endregion

        #region 向条码系统发送完工单信息
        /// <summary>
        /// 向条码系统发送完工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelItem"></param>
        /// <returns></returns>
        public int SENDWGD(Mod_TRC_ROLL_WGD model)
        {
            string fzdw = dal_matra.GetModel(model.C_MAT_CODE).C_FJLDWMC;//辅计量单位
            string sql = @"INSERT ReZJB_WGD (
                                     wgdh,
                    				 pch,
                    				 ph,
                    				 gg,
                    				 bb,
                    				 wlh,
                    				 wlmc,
                    				 fzdw,
                    				 zxbz,
                    				 SCX,
                    				 pcinfo,
                    				 zyx1,
                    				 zyx2,
                    				 zyx3,
                    				 gpmainmeasrate,
                    				 ZJBstatus,
                    				 CAPPK,
                    				 Filed1,
                    				 pcsx,
                    				 zpdjbz,
                                     producedate,
                    				 vfree0,
                    				 pclx,
                                     insertts
                    				 )
                                     values
                                     (   ";
            sql += "'" + model.C_MAIN_ID + "',";
            sql += "'" + model.C_BATCH_NO + "',";
            sql += "'" + model.C_STL_GRD + "',";
            sql += "'" + model.C_SPEC + "',";
            sql += "'" + model.C_PRODUCE_GROUP_NAME + "',";
            sql += "'" + model.C_MAT_CODE + "',";
            sql += "'" + model.C_MAT_DESC + "',";
            sql += "'" + fzdw + "',";
            sql += "'" + model.C_STD_CODE + "',";

            sql += "'" + dal_TB_STA.GetModel(model.C_STA_ID).C_SSBMID + "',";
            sql += "'" + model.C_AREA + "',";
            sql += "'" + model.C_FREE_TERM + "',";
            sql += "'" + model.C_FREE_TERM2 + "',";
            sql += "'" + model.C_PACK + "',";
            sql += "'" + model.N_WGT_PRODUCE + "',";
            sql += "0 ,";
            sql += "'" + model.C_ID + "',";
            sql += "'" + model.C_SX + "',";
            sql += "'" + model.C_MRSX + "',";
            sql += "'" + model.C_ZPDJBZ + "',";
            sql += "'" + model.D_PRODUCE_DATE + "',";
            sql += "'" + model.C_STOVE + "',";
            sql += "'" + model.C_PCLX + "',";
            sql += "'" + DateTime.Now + "'";
            sql += "   )  ";

            return DbHelper_SQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 向条码系统发送完工单信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelItem"></param>
        /// <returns></returns>
        public int SENDWGDITEM(List<Mod_TRC_ROLL_WGD_ITEM> modelItems, Mod_TRC_ROLL_WGD model)
        {
            int count = 0;
            foreach (var item in modelItems)
            {
                string sql = @"INSERT ReZJB_WGD_Item
                                    (wgdh,
                                     pch,
                                     ph,
                                     gg,
                                     wlh,
                                     wlmc,
                                     pcinfo,
                                     zyx1,
                                     zyx2,
                                     zyx3,
                                     ZJBstatus,
                                     CAPPK,
                                     zpbxbz,
                                     sx,
                                     zxbz,
                                     insertts
                                     )
                                     values
                                     (   ";

                sql += "'" + item.C_MAIN_ID + "',";
                sql += "'" + item.C_BATCH_NO + "',";
                sql += "'" + item.C_STL_GRD + "',";
                sql += "'" + item.C_SPEC + "',";
                sql += "'" + item.C_MAT_CODE + "',";
                sql += "'" + item.C_MAT_DESC + "',";
                sql += "'" + model.C_AREA + "',";
                sql += "'" + item.C_ZYX1 + "',";
                sql += "'" + item.C_ZYX2 + "',";
                sql += "'" + item.C_BZYQ + "',";
                sql += "0 ,";
                sql += "'" + item.C_ID + "',";
                sql += "'" + item.N_STATUS + "',";
                sql += "'" + model.C_SX + "',";
                sql += "'" + item.C_STD_CODE + "',";
                sql += "'" + DateTime.Now + "'";
                sql += "   )  ";
                DbHelper_SQL.ExecuteSql(sql);
                count++;
            }
            return count;
        }
        #endregion

        #region 实绩日志表
        /// <summary>
        /// 根据单号获取线材实绩日志
        /// </summary>
        /// <param name="DH">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataSet GetYWDXQ(string DH, string status, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_DH,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_MAT_CODE,C_MAT_DESC,C_BARCODE,C_EMP_ID,D_CZ_DATE");
            strSql.Append(" FROM TRC_ROLLCZ_LOG WHERE N_TYPE='" + status + "'");
            if (DH.Trim() != "")
            {
                strSql.Append(" AND C_DH='" + DH + "' ");
            }
            if (id.Trim() != "")
            {
                strSql.Append(" AND C_REMARK='" + id + "' ");
            }
            strSql.Append(" ORDER BY  C_DH,C_STOVE,C_BATCH_NO,C_TICK_NO ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion
        #region 发运单

        /// <summary>
        ///根据发运单号获取条码中间表数据
        /// </summary>
        /// <param name="C_FYDH">发运单号</param>
        /// <returns></returns>
        public DataSet GetTMFYD(string C_FYDH, DateTime dt1, DateTime dt2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pk_SeZJB_FYD_finished,fydh,case ZJBstatus when '0' then '未同步' when '1' then '同步成功'when '2' then '同步异常' when '3' then '作废'end ZJBstatus ,by1,insertts,updatets ");
            strSql.Append(" FROM SeZJB_FYD_finished WHERE 1=1");
            if (C_FYDH.Trim() != "")
            {
                strSql.Append(" AND fydh LIKE '%" + C_FYDH + "%' ");
            }
            strSql.Append(" AND insertts >='" + dt1 + "' ");
            strSql.Append(" and insertts <='" + dt2 + "' ");
            strSql.Append(" ORDER BY  fydh desc,pk_SeZJB_FYD_finished ");
            return TransactionHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 查询条码返回中间表未接收成功的发运单号
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet QueryFYD()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT fydh,pk_SeZJB_FYD_finished,insertts,by1 FROM SeZJB_FYD_finished  WHERE  ZJBSTATUS IN(0,2) and  pk_SeZJB_FYD_finished in(SELECT MAX(pk_SeZJB_FYD_finished) FROM SeZJB_FYD_finished GROUP BY fydh )");
            //strSql.Append("SELECT fydh,pk_SeZJB_FYD_finished,insertts,by1 FROM SeZJB_FYD_finished  WHERE fydh='DMC1908080014'  and  pk_SeZJB_FYD_finished in(SELECT MAX(pk_SeZJB_FYD_finished) FROM SeZJB_FYD_finished GROUP BY fydh )");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根发运单号判断PCI是否存在此发运单
        /// </summary>
        /// <param name="FYD">发运单</param>
        /// <returns>是否存在</returns>
        public bool ExistsByFYD(string FYD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMD_DISPATCH ");
            strSql.Append(" where C_ID='" + FYD + "'");
            return DbHelperOra.Exists(strSql.ToString());
        }
        /// <summary>
        /// 根发运单号判断PCI是否存在此发运单
        /// </summary>
        /// <param name="FYD">发运单</param>
        /// <returns>是否存在</returns>
        public string ExistsFYDstatus(string FYD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select status from WMS_Bms_Pic_FYD ");
            strSql.Append(" where fydh='" + FYD + "'");
            strSql.Append(" AND status not in(2,4)");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 更新条码发运单实绩中间表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int UPFYDBZ(string fydh, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_FYD_finished SET");
            strSql.Append(" by1='已撤回！',updatets='" + DateTime.Now + "'");
            strSql.Append("  where   fydh='" + fydh + "'  and pk_SeZJB_FYD_finished='" + id + "' ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新发运单表
        /// </summary>
        /// <param name="dhstr">移位单号</param>
        /// <returns></returns>
        public int UPFYDSTATUS(string dhstr, string status, string by1, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_FYD_finished SET");
            strSql.Append(" ZJBstatus='" + status + "',by1='" + by1 + "',updatets='" + DateTime.Now + "'");
            strSql.Append("  where fydh='" + dhstr + "' AND pk_SeZJB_FYD_finished='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新发运单状态
        /// </summary>
        /// <param name="dhstr">发运单号</param>
        /// <returns></returns>
        public int UPFYDSTATUS(string dhstr, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TMD_DISPATCH SET");
            strSql.Append(" C_STATUS='" + status + "'");
            strSql.Append(" WHERE C_ID ='" + dhstr + "'");

            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据发运单号更新线材实绩
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public int UPRPByFYDH(string fydh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='E',C_ZKD_NO='',C_FYDH='',C_QTCKD_NO='',C_FRFLAG=''");
            strSql.Append("  where C_FYDH='" + fydh + "' ");
            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        ///更新发运单日志
        /// </summary>
        /// <param name="dhstr">发运单号</param>
        /// <returns></returns>
        public int UPFYDZJB(string dhstr, string C_BATCH_NO, string C_MAT_CODE, string C_LINEWH_CODE, string C_JUDGE_LEV_ZH, string C_BZYQ, string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TMD_DISPATCH_SJZJB ");
            strSql.Append(" SET N_NUM='0',N_JZ='0'  WHERE C_DISPATCH_ID='" + dhstr + "'");
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "'");
            }
            if (C_MAT_CODE.Trim() != "")
            {
                strSql.Append(" AND C_MAT_CODE='" + C_MAT_CODE + "'");
            }
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" AND C_SEND_STOCK='" + C_LINEWH_CODE + "'");
            }
            if (C_JUDGE_LEV_ZH.Trim() != "")
            {
                strSql.Append(" AND C_ZLDJ='" + C_JUDGE_LEV_ZH + "'");
            }
            if (C_BZYQ.Trim() != "")
            {
                strSql.Append(" AND C_BZYQ='" + C_BZYQ + "'");
            }
            if (C_STD_CODE.Trim() != "")
            {
                strSql.Append(" AND C_STD_CODE='" + C_STD_CODE + "'");
            }
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除发运单日志2
        /// </summary>
        /// <param name="dhstr">发运单号</param>
        /// <returns></returns>
        public int DelFYDZJB(string dhstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE TMD_DISPATCH_SJZJB ");
            strSql.Append(" WHERE C_DISPATCH_ID='" + dhstr + "'");
            strSql.Append(" AND N_NUM=0");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除发运单日志
        /// </summary>
        /// <param name="dhstr">发运单号</param>
        /// <returns></returns>
        public int DelFYDZJB(string dhstr, string C_BATCH_NO, string C_MAT_CODE, string C_LINEWH_CODE, string C_JUDGE_LEV_ZH, string C_BZYQ, string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE TMD_DISPATCH_SJZJB ");
            strSql.Append(" WHERE C_DISPATCH_ID='" + dhstr + "'");
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "'");
            }
            if (C_MAT_CODE.Trim() != "")
            {
                strSql.Append(" AND C_MAT_CODE='" + C_MAT_CODE + "'");
            }
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" AND C_SEND_STOCK='" + C_LINEWH_CODE + "'");
            }
            if (C_JUDGE_LEV_ZH.Trim() != "")
            {
                strSql.Append(" AND C_ZLDJ='" + C_JUDGE_LEV_ZH + "'");
            }
            if (C_BZYQ.Trim() != "")
            {
                strSql.Append(" AND C_BZYQ='" + C_BZYQ + "'");
            }
            if (C_STD_CODE.Trim() != "")
            {
                strSql.Append(" AND C_STD_CODE='" + C_STD_CODE + "'");
            }
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除发运单日志
        /// </summary>
        /// <param name="dhstr">发运单号</param>
        /// <returns></returns>
        public int UPFYD(string dhstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLLCZ_LOG SET C_REMARK='已撤回！'");
            strSql.Append(" WHERE C_DH='" + dhstr + "'");
            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 通过单号查询条码发运详情
        /// </summary>
        /// <param name="dh">单号</param>
        /// <returns></returns>
        public DataSet QueryFYDByCK(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Barcode,fydh,CKRY FROM  WMS_Bms_Inv_OutInfo  WHERE FYDH = '" + dh + "'");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号查询线材库存详情
        /// </summary>
        /// <param name="C_BARCODE"></param>
        /// <returns></returns>
        public DataSet GetXCKC(string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_BATCH_NO,C_STOVE,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO,C_SALE_AREA ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where 1=1 ");
            if (C_BARCODE.Trim() != "")
            {
                strSql.Append(" and C_BARCODE ='" + C_BARCODE + "' ");
            }
            strSql.Append(" ORDER BY  C_BATCH_NO,C_STOVE,C_TICK_NO");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号查询线材库存详情
        /// </summary>
        /// <param name="C_BARCODE"></param>
        /// <returns></returns>
        public DataSet GetXCKCTran(string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_CON_NO,C_CUST_NAME,C_BATCH_NO,C_STOVE,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO,C_SALE_AREA ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where 1=1 ");
            if (C_BARCODE.Trim() != "")
            {
                strSql.Append(" and C_BARCODE ='" + C_BARCODE + "' ");
            }
            strSql.Append(" ORDER BY  C_BATCH_NO,C_STOVE,C_TICK_NO");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号获取状态
        /// </summary>
        /// <param name="dh">牌号</param>
        /// <returns></returns>
        public string GetMOVETYPE(string Barcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_MOVE_TYPE FROM TRC_ROLL_PRODCUT ");
            strSql.Append("  where C_BARCODE='" + Barcode + "' ");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["C_MOVE_TYPE"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据发运单item修改线材实绩
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static StringBuilder UPFYD(DataRow item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE = 'S', C_FYDH='" + item["fydh"] + "',C_ZKD_NO='',C_QTCKD_NO='' ");
            strSql.Append("  where C_BARCODE='" + item["Barcode"] + "' ");
            return strSql;
        }
        /// <summary>
        /// 通过单号查询条码发运实绩详情
        /// </summary>
        /// <param name="dh">单号</param>
        /// <returns></returns>
        public DataSet GetFYSJList(string dh, string C_MAT_CODE, string C_LINEWH_CODE, string C_JUDGE_LEV_ZH, string C_BZYQ, string C_BATCH_NO, string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT N_WGT,C_BARCODE, C_BATCH_NO,C_MAT_CODE,C_MAT_DESC,C_SPEC,C_STL_GRD,C_STD_CODE,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_BZYQ,C_TICK_NO from TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE='S' AND nvl(C_FRFLAG, 0) = 0");
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "'");
            }
            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_FYDH='" + dh + "'");
            }
            if (C_MAT_CODE.Trim() != "")
            {
                strSql.Append(" AND C_MAT_CODE='" + C_MAT_CODE + "'");
            }
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" AND C_LINEWH_CODE='" + C_LINEWH_CODE + "'");
            }
            if (C_JUDGE_LEV_ZH.Trim() != "")
            {
                strSql.Append(" AND C_JUDGE_LEV_ZH='" + C_JUDGE_LEV_ZH + "'");
            }
            if (C_BZYQ.Trim() != "")
            {
                strSql.Append(" AND C_BZYQ='" + C_BZYQ + "'");
            }
            if (C_STD_CODE.Trim() != "")
            {
                strSql.Append(" AND C_STD_CODE='" + C_STD_CODE + "'");
            }
            strSql.Append(" ORDER BY C_BATCH_NO,to_number(C_TICK_NO)");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 通过单号查询条码发运实绩详情
        /// </summary>
        /// <param name="dh">单号</param>ss
        /// <returns></returns>
        public DataSet GetFYSJList(string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) N_NUM,SUM(N_WGT) N_WGT, C_BATCH_NO,C_MAT_CODE,C_MAT_DESC,C_SPEC,C_STL_GRD,C_STD_CODE,C_LINEWH_CODE,nvl(C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP)C_JUDGE_LEV_ZH,C_BZYQ from TRC_ROLL_PRODCUT WHERE  C_BARCODE IN(" + C_BARCODE + ") ");

            strSql.Append(" GROUP  BY C_BATCH_NO,C_MAT_CODE,C_MAT_DESC,C_SPEC,C_STL_GRD,C_STD_CODE,C_LINEWH_CODE,nvl(C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP),C_BZYQ");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据发运单号，批号，仓库，质量等级，包装要求查询钩号
        /// </summary>
        /// <param name="dh">发运单号</param>
        /// <param name="C_BATCH_NO">批号</param>
        /// <param name="C_LINEWH_CODE">仓库</param>
        /// <param name="C_JUDGE_LEV_ZH">质量等级</param>
        /// <param name="C_BZYQ">包装要求</param>
        /// <returns></returns>
        public DataSet GetTICKList(string dh, string C_BATCH_NO, string C_LINEWH_CODE, string C_JUDGE_LEV_ZH, string C_BZYQ)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_TICK_NO from TRC_ROLL_PRODCUT WHERE 1=1");
            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_FYDH='" + dh + "'");
            }
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "'");
            }
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" AND C_LINEWH_CODE='" + C_LINEWH_CODE + "'");
            }
            if (C_JUDGE_LEV_ZH.Trim() != "")
            {
                strSql.Append(" AND nvl(C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP)='" + C_JUDGE_LEV_ZH + "'");
            }
            if (C_BZYQ.Trim() != "")
            {
                strSql.Append(" AND C_BZYQ='" + C_BZYQ + "'");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取最新的转库单号
        /// </summary>
        /// <param name="fydh">发运单</param>
        /// <returns></returns>
        public string GetCKDNO(string fydh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(C_CKDH) ");
            strSql.Append(" FROM TMD_DISPATCH_SJZJB WHERE 1=1 ");
            if (fydh.Trim() != "")
            {
                strSql.Append(" AND C_CKDH LIKE 'XC" + fydh + "%' ");
            }
            object obj = TransactionHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 同步发运单
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public string TBFYD(string path)
        {
            string LogSql = "";//异常记录字符串
            string name = "Dal_Interface_FR.TBFYD";//方法名字地址用于记录日志
            try
            {
                DataTable dt = QueryFYD().Tables[0];//查询条码未上传的发运单
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string fydh = item["fydh"].ToString();//获取发运单号
                        string id = item["pk_SeZJB_FYD_finished"].ToString();//获取发运单id
                        string message = "";//异常信息
                        string by = item["by1"].ToString();//条码异常描述
                        string dmarea = $@"select b.c_Area,t.c_Orgo_Cust,b.c_Con_No from Tmd_Dispatchdetails t inner join TMO_CON_ORDER b on t.C_NO = b.C_ORDER_NO  WHERE t.c_dispatch_id ='{fydh}' ";//获取发运单销售区域
                        DataTable areadt = DbHelperOra.Query(dmarea).Tables[0];
                        string dmcust = "";
                        string dmcon = "";
                        if (areadt.Rows.Count > 0)
                        {
                            dmarea = areadt.Rows[0]["c_Area"].ToString();
                            dmcust = areadt.Rows[0]["c_Orgo_Cust"].ToString();
                            dmcon = areadt.Rows[0]["c_Con_No"].ToString();
                        }
                        else
                        {
                            dmarea = "";
                            dmcust = "";
                            dmcon = "";
                            UPFYDSTATUS(fydh, "3", "发运单不存在或发运单销售区域为空", id);
                            continue;
                        }
                        if (by.Contains("PCI系统不存在发运单号") == true)
                        {
                            UPFYDSTATUS(fydh, "3", "发运单已删除", id);
                            continue;
                        }
                        if (by.Contains("异常信息:0") == true)
                        {
                            UPFYDSTATUS(fydh, "3", "条码空点完成", id);
                            continue;
                        }
                        if (by.Contains("异常信息:null") == true)
                        {
                            UPFYDSTATUS(fydh, "3", "条码空点完成", id);
                            continue;
                        }
                        if (ExistsFYDstatus(fydh) != "")//检验发运单是否全部装车
                        {
                            UPFYDSTATUS(fydh, "3", "此发运单未全部装车", id);
                            continue;
                        }
                        if (ExistsByFYD(fydh) == false)//检验发运单是否存在
                        {
                            UPFYDSTATUS(fydh, "3", "PCI系统不存在发运单号" + item["fydh"].ToString(), id);
                        }
                        else
                        {
                            DELROLL(fydh, id);//删除此发运单日志
                            ///发运单号多次发送覆盖
                            UPFYDSTATUS(fydh, "3");
                            UPRPByFYDH(fydh);
                            //传送条码
                            DataTable fydt = QueryFYDByCK(fydh).Tables[0];//获取条码实绩
                            if (fydt.Rows.Count > 0)
                            {
                                TransactionHelper.BeginTransaction();//开启ora事务
                                foreach (DataRow xqitem in fydt.Rows)
                                {
                                    DataTable ydt = GetXCKC(xqitem["Barcode"].ToString()).Tables[0];//获取原线材数据
                                    if (ydt.Rows.Count != 1)
                                    {
                                        //更新条码发运单状态
                                        UPFYDSTATUS(fydh, "2", "牌号" + xqitem["Barcode"].ToString() + "PCI系统不存在！", id);
                                        TransactionHelper.RollBack();
                                        message = "1";
                                        break;
                                    }

                                    string movetype = GetMOVETYPE(xqitem["Barcode"].ToString());///获取线材库存状态
                                    if (movetype != "E")
                                    {
                                        TransactionHelper.RollBack();
                                        UPFYDSTATUS(fydh, "2", "牌号" + xqitem["Barcode"].ToString() + "信息库存状态为" + movetype, id);
                                        message = "1";
                                        break;
                                    }
                                    StringBuilder strSql = UPFYD(xqitem);//执行实际线材销售S
                                    if (TransactionHelper.ExecuteSql(strSql.ToString()) == 0)
                                    {
                                        TransactionHelper.RollBack();
                                        UPFYDSTATUS(fydh, "2", "牌号" + xqitem["Barcode"].ToString() + "变更线材实绩状态错误！", id);
                                        message = "1";
                                        break;
                                    }
                                    DataRow data = ydt.Rows[0];
                                    DataTable trandt = GetXCKCTran(xqitem["Barcode"].ToString()).Tables[0];
                                    //获取现合同号
                                    string consql = $@"select b.c_Area,t.c_Orgo_Cust,b.c_Con_No from Tmd_Dispatchdetails t inner join TMO_CON_ORDER b on t.C_NO = b.C_ORDER_NO  WHERE t.c_dispatch_id ='{fydh}' AND t.C_MAT_CODE='" + data["C_MAT_CODE"] + "' AND t.C_STD_CODE='" + data["C_STD_CODE"] + "' AND  t.C_JUDGE_LEV_ZH='" + data["C_JUDGE_LEV_ZH"] + "' AND  t.C_PACK ='" + data["C_BZYQ"] + "' ";//获取发运单销售区域
                                    DataTable condt = DbHelperOra.Query(consql).Tables[0];
                                    if (condt.Rows.Count > 0)
                                    {
                                        dmcon = condt.Rows[0]["c_Con_No"].ToString();
                                    }
                                    else
                                    {
                                        dmcon = "";
                                        UPFYDSTATUS(fydh, "3", "发运单不存在或发运单销售区域为空", id);
                                        continue;
                                    }
                                    DataRow trandata = trandt.Rows[0];
                                    string zhjl = "";
                                    string sjarea = trandata["C_SALE_AREA"].ToString() == "" ? "空" : trandata["C_SALE_AREA"].ToString();
                                    string sjcust = trandata["C_CUST_NAME"].ToString() == "" ? "空" : trandata["C_CUST_NAME"].ToString();
                                    string sjcon = trandata["C_CON_NO"].ToString() == "" ? "空" : trandata["C_CON_NO"].ToString();
                                    if (dal_ts_dic.GetAreaFlag(dmarea) == "N" && dal_ts_dic.GetAreaFlag(sjarea) == "N")
                                    {
                                        zhjl = xqitem["Barcode"] + "区域为" + sjarea;
                                        #region 置换销售区域
                                        if (sjarea != dmarea)
                                        {
                                            zhjl = "置换销售区域-";
                                            //查询数量最少批次单卷信息
                                            string batchsql = "SELECT C_BATCH_NO,COUNT(1) NUM ,D_PRODUCE_DATE FROM TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE='E'  AND C_MAT_CODE='" + data["C_MAT_CODE"] + "' AND C_STD_CODE='" + data["C_STD_CODE"] + "' AND  C_JUDGE_LEV_ZH='" + data["C_JUDGE_LEV_ZH"] + "' AND  C_BZYQ ='" + data["C_BZYQ"] + "' AND  C_SALE_AREA ='" + dmarea + "' GROUP BY C_BATCH_NO,D_PRODUCE_DATE ORDER BY NUM,D_PRODUCE_DATE,C_BATCH_NO";
                                            DataTable mindt = TransactionHelper.Query(batchsql).Tables[0];
                                            if (mindt.Rows.Count > 0)
                                            {
                                                batchsql = mindt.Rows[0]["C_BATCH_NO"].ToString();
                                                string zhysql = "UPDATE  TRC_ROLL_PRODCUT SET C_SALE_AREA='" + dmarea + "' WHERE  C_BARCODE = '" + xqitem["Barcode"].ToString() + "'";
                                                zhjl += "开始置换-";
                                                if (TransactionHelper.ExecuteSql(zhysql.ToString()) == 0)
                                                {
                                                    TransactionHelper.RollBack();
                                                    message = "1";
                                                    UPFYDSTATUS(fydh, "2", "变更原牌号销售区域错误！", id);
                                                    break;
                                                }
                                                zhjl += "实绩牌号" + xqitem["Barcode"].ToString() + "原区域" + sjarea + "现区域" + dmarea;
                                                string xbh = "SELECT MIN(C_BARCODE) C_BARCODE FROM TRC_ROLL_PRODCUT WHERE  C_BATCH_NO = '" + batchsql + "'AND C_MOVE_TYPE IN ('E', 'M')  AND C_SALE_AREA = '" + dmarea + "'  AND C_JUDGE_LEV_ZH='" + data["C_JUDGE_LEV_ZH"] + "'";
                                                DataTable phdt = TransactionHelper.Query(xbh).Tables[0];
                                                //查询牌号销售区域
                                                //查询是否置换客户信息
                                                if (phdt.Rows.Count > 0)
                                                {
                                                    xbh = phdt.Rows[0]["C_BARCODE"].ToString();
                                                    string zhsql = "UPDATE  TRC_ROLL_PRODCUT SET C_SALE_AREA='" + sjarea + "' WHERE  C_BARCODE ='" + xbh + "'";
                                                    if (TransactionHelper.ExecuteSql(zhsql.ToString()) == 0)
                                                    {
                                                        TransactionHelper.RollBack();
                                                        message = "1";
                                                        UPFYDSTATUS(fydh, "2", "变更销售区域错误！", id);
                                                        break;
                                                    }
                                                    zhjl += "被换牌号" + xbh + "原区域" + dmarea + "现区域" + sjarea;
                                                }
                                                else
                                                {
                                                    zhjl = dmarea + "未查询到可置换批次牌号！";
                                                }
                                            }
                                            else
                                            {
                                                zhjl = dmarea + "未查询到可置换批次！";
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        zhjl = xqitem["Barcode"] + "区域为" + sjarea + "客户为" + sjcust + "合同为" + sjcon;
                                        #region 置换销售区域和客户
                                        string dmcon1 = "";
                                        string sjcon1 = "";
                                        if (dmcon.Length > 14)
                                        {
                                            dmcon1 = dmcon.Substring(0, 15);
                                        }
                                        else
                                        {
                                            dmcon1 = dmcon;
                                        }
                                        if (sjcon1.Length > 14)
                                        {
                                            sjcon1 = sjcon.Substring(0, 15);
                                        }
                                        else
                                        {
                                            sjcon1 = sjcon;
                                        }
                                        if (sjarea != dmarea || sjcust != dmcust || dmcon1 != sjcon1)
                                        {
                                            zhjl = "置换销售区域与客户-";
                                            //查询数量最少批次单卷信息
                                            string batchsql = "SELECT C_BATCH_NO,COUNT(1) NUM ,D_PRODUCE_DATE FROM TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE='E'  AND C_MAT_CODE='" + data["C_MAT_CODE"] + "' AND C_STD_CODE='" + data["C_STD_CODE"] + "' AND  C_JUDGE_LEV_ZH='" + data["C_JUDGE_LEV_ZH"] + "' AND  C_BZYQ ='" + data["C_BZYQ"] + "' AND  C_SALE_AREA ='" + dmarea + "' AND  C_CUST_NAME ='" + dmcust + "' AND SUBSTR(C_CON_NO,0,15) = SUBSTR('" + dmcon + "',0,15)  GROUP BY C_BATCH_NO,D_PRODUCE_DATE ORDER BY NUM,D_PRODUCE_DATE,C_BATCH_NO";
                                            if (dal_ts_dic.GetAreaFlag(dmarea) == "N")
                                            {
                                                batchsql = "SELECT C_BATCH_NO,COUNT(1) NUM ,D_PRODUCE_DATE FROM TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE='E'  AND C_MAT_CODE='" + data["C_MAT_CODE"] + "' AND C_STD_CODE='" + data["C_STD_CODE"] + "' AND  C_JUDGE_LEV_ZH='" + data["C_JUDGE_LEV_ZH"] + "' AND  C_BZYQ ='" + data["C_BZYQ"] + "' AND  C_SALE_AREA ='" + dmarea + "'  GROUP BY C_BATCH_NO,D_PRODUCE_DATE ORDER BY NUM,D_PRODUCE_DATE,C_BATCH_NO";
                                            }
                                            //获取最少零星材批次号
                                            DataTable mindt = TransactionHelper.Query(batchsql).Tables[0];
                                            if (mindt.Rows.Count > 0)
                                            {
                                                //最小零星材批次号
                                                batchsql = mindt.Rows[0]["C_BATCH_NO"].ToString();

                                                //更新实际条码发走批次号
                                                string zhysql = "UPDATE  TRC_ROLL_PRODCUT SET C_SALE_AREA='" + dmarea + "',C_CUST_NAME='" + dmcust + "',C_CON_NO='" + dmcon + "' WHERE  C_BARCODE = '" + xqitem["Barcode"].ToString() + "'";

                                                zhjl += "开始置换-";
                                                if (TransactionHelper.ExecuteSql(zhysql.ToString()) == 0)
                                                {
                                                    TransactionHelper.RollBack();
                                                    message = "1";
                                                    UPFYDSTATUS(fydh, "2", "变更原牌号销售区域错误！", id);
                                                    break;
                                                }
                                                zhjl += "-实绩牌号" + xqitem["Barcode"].ToString() + ",原区域" + sjarea + ",现区域" + dmarea + ",原客户" + sjcust + ",现客户" + dmcust + ",原合同" + sjcon + ",现合同" + dmcon;

                                                string xbh = $@"SELECT MIN(C_BARCODE) C_BARCODE FROM TRC_ROLL_PRODCUT WHERE  C_BATCH_NO = '{batchsql}' AND C_MOVE_TYPE IN ('E', 'M')  AND C_SALE_AREA = '{dmarea}' AND C_CUST_NAME ='{dmcust}' AND SUBSTR(C_CON_NO,0,15) = SUBSTR('{dmcon}',0,15) AND C_JUDGE_LEV_ZH='{data["C_JUDGE_LEV_ZH"].ToString()}'";
                                                if (dal_ts_dic.GetAreaFlag(dmarea) == "N")
                                                {
                                                    xbh = $@"SELECT MIN(C_BARCODE) C_BARCODE FROM TRC_ROLL_PRODCUT WHERE  C_BATCH_NO = '{batchsql}' AND C_MOVE_TYPE IN ('E', 'M')  AND C_SALE_AREA = '{dmarea}' AND C_JUDGE_LEV_ZH='{data["C_JUDGE_LEV_ZH"].ToString()}'";

                                                }
                                                DataTable phdt = TransactionHelper.Query(xbh).Tables[0];
                                                if (phdt.Rows.Count > 0)
                                                {
                                                    xbh = phdt.Rows[0]["C_BARCODE"].ToString();
                                                    string zhsql = "UPDATE  TRC_ROLL_PRODCUT SET C_SALE_AREA='" + sjarea + "',C_CUST_NAME='" + sjcust + "',C_CON_NO='" + sjcon + "' WHERE  C_BARCODE ='" + xbh + "'";
                                                    if (TransactionHelper.ExecuteSql(zhsql.ToString()) == 0)
                                                    {
                                                        TransactionHelper.RollBack();
                                                        message = "1";
                                                        UPFYDSTATUS(fydh, "2", "变更销售区域错误！", id);
                                                        break;
                                                    }
                                                    zhjl += "-被换牌号" + xbh + ",原区域" + dmarea + ",现区域" + sjarea + ",原客户" + dmcust + ",现客户" + sjcust + ",原合同" + dmcon + ",现合同" + sjcon;
                                                }
                                                else
                                                {
                                                    zhjl = dmarea + "未查询到可置换批次牌号！";
                                                }
                                            }
                                            else
                                            {
                                                zhjl = dmarea + "未查询到可置换批次！";
                                            }
                                        }
                                        #endregion
                                    }
                                    //添加线材操作日志

                                    string sql = "insert into TRC_ROLLCZ_LOG(C_DH,C_REMARK,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,D_CZ_DATE,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_EMP_ID,C_BZYQ,C_ZHJL) values('" + fydh + "','" + id + "','" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','','','','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "', to_date('" + DateTime.Now + "', 'yyyy-mm-dd hh24:mi:ss'),'" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + xqitem["Barcode"] + "','2','" + xqitem["CKRY"] + "','" + data["C_BZYQ"] + "','" + zhjl + "')";
                                    if (TransactionHelper.ExecuteSql(sql.ToString()) != 1)///添加操作记录
                                    {
                                        TransactionHelper.RollBack();
                                        UPFYDSTATUS(fydh, "2", "PCI添加操作日志时错误！", id);
                                        message = "1";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                TransactionHelper.BeginTransaction();
                            }
                            if (message == "1")
                            {
                                continue;
                            }
                            ///添加转库单中间表
                            string rjhsql = "SELECT C_PLAN_ID,C_ID,C_MAT_CODE,C_STD_CODE,C_SEND_STOCK_CODE,c_Judge_Lev_Zh,C_PACK,N_FYZS,N_FYWGT FROM TMD_DISPATCHDETAILS WHERE C_DISPATCH_ID='" + item["fydh"].ToString() + "'";
                            DataTable plandt = TransactionHelper.Query(rjhsql).Tables[0];
                            if (plandt.Rows.Count < 1)
                            {
                                TransactionHelper.RollBack();
                                UPFYDSTATUS(fydh, "2", "发运单子表查询错误！", id);
                            }
                            string sfcz = "";
                            foreach (DataRow planrow in plandt.Rows)
                            {
                                int plannum = Convert.ToInt32(planrow["N_FYZS"]);
                                decimal planwgt = Convert.ToDecimal(planrow["N_FYWGT"]);
                                #region 获取出库单
                                string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));//转库单号
                                string maxckd = GetCKDNO(no);//查询当天最大转库单
                                if (maxckd == "")
                                {
                                    no = no + "0001";
                                }
                                else
                                {
                                    no = (Convert.ToInt64(maxckd.Substring(2, maxckd.Length - 2)) + 1).ToString();
                                }
                                no = "XC" + no;
                                #endregion
                                #region 获取线材实绩
                                DataTable dt1 = GetFYSJList(fydh, planrow["C_MAT_CODE"].ToString(), planrow["C_SEND_STOCK_CODE"].ToString(), planrow["c_Judge_Lev_Zh"].ToString(), planrow["C_PACK"].ToString(), "", planrow["C_STD_CODE"].ToString()).Tables[0];
                                if (dt1.Rows.Count == 0)
                                {
                                    sfcz = "1";
                                    UPFYDZJB(fydh, "", planrow["C_MAT_CODE"].ToString(), planrow["C_SEND_STOCK_CODE"].ToString(), planrow["c_Judge_Lev_Zh"].ToString(), planrow["C_PACK"].ToString(), planrow["C_STD_CODE"].ToString());
                                    continue;
                                }
                                else
                                {
                                    DelFYDZJB(fydh);
                                    DelFYDZJB(fydh, "", planrow["C_MAT_CODE"].ToString(), planrow["C_SEND_STOCK_CODE"].ToString(), planrow["c_Judge_Lev_Zh"].ToString(), planrow["C_PACK"].ToString(), planrow["C_STD_CODE"].ToString());
                                }
                                sfcz = "1";
                                string barcodestr = "";
                                foreach (DataRow xqitem in dt1.Rows)
                                {
                                    barcodestr += "'" + xqitem["C_BARCODE"] + "',";
                                }
                                barcodestr = barcodestr.Substring(0, barcodestr.Length - 1);
                                DataTable sjdt = GetFYSJList(barcodestr).Tables[0];//查询材实绩
                                foreach (DataRow item1 in sjdt.Rows)
                                {
                                    string gh = "";
                                    DataTable dt2 = GetFYSJList(fydh, planrow["C_MAT_CODE"].ToString(), planrow["C_SEND_STOCK_CODE"].ToString(), planrow["c_Judge_Lev_Zh"].ToString(), planrow["C_PACK"].ToString(), item1["C_BATCH_NO"].ToString(), planrow["C_STD_CODE"].ToString()).Tables[0];
                                    foreach (DataRow ghitem in dt2.Rows)
                                    {
                                        gh += ghitem["C_TICK_NO"] + ",";
                                    }
                                    gh = gh.Substring(0, gh.Length - 1);
                                    #region 添加中间表
                                    string sql = "";
                                    sql += "insert into TMD_DISPATCH_SJZJB(C_DISPATCH_ID,N_NUM,N_STATUS,C_CKDH,N_JZ,C_SEND_STOCK,C_BATCH_NO,C_PLAN_ID,C_STL_GRD,C_STD_CODE,C_SPEC,C_PK_NCID,C_ZLDJ,C_BZYQ,D_CKSJ,C_MAT_CODE,C_MAT_NAME,C_TICK_STR) values('" + item["fydh"].ToString() + "','" + item1["N_NUM"] + "','8','" + no + "','" + item1["N_WGT"] + "','" + item1["C_LINEWH_CODE"] + "','" + item1["C_BATCH_NO"] + "','" + planrow["C_PLAN_ID"].ToString() + "','" + item1["C_STL_GRD"] + "','" + item1["C_STD_CODE"] + "','" + item1["C_SPEC"] + "','" + planrow["C_ID"].ToString() + "','" + item1["C_JUDGE_LEV_ZH"].ToString() + "','" + item1["C_BZYQ"] + "',to_date('" + item["insertts"].ToString() + "', 'yyyy-mm-dd hh24:mi:ss'),'" + item1["C_MAT_CODE"].ToString() + "','" + item1["C_MAT_DESC"].ToString() + "','" + gh + "')";
                                    if (TransactionHelper.ExecuteSql(sql) == 0)
                                    {
                                        TransactionHelper.RollBack();
                                        UPFYDSTATUS(fydh, "2", "添加发运单中间表错误！", id);
                                    }

                                    #region //自动生成客户远程质证书
                                    try
                                    {
                                        string[] dj = { "A", "AA", "AAA", "CK", "A1", "B1", "B2", "C1", "C2" };
                                        if (dj.Contains(item1["C_JUDGE_LEV_ZH"].ToString()))
                                        {
                                            //删除重复发运单批号
                                            bool res = DelZSH(item["fydh"].ToString(), item1["C_BATCH_NO"].ToString());
                                            //检查是否重复批次
                                            if (!ExistsZZS(item["fydh"].ToString(), item1["C_BATCH_NO"].ToString()))
                                            {
                                                //获取发运单信息
                                                DataTable dtRoll = GetZZS(item["fydh"].ToString(), item1["C_BATCH_NO"].ToString()).Tables[0];
                                                if (dtRoll.Rows.Count > 0)
                                                {
                                                    DataTable dtCustStd = GetCustStd_JH(dtRoll.Rows[0]["C_STD_CODE"].ToString(), dtRoll.Rows[0]["C_STL_GRD"].ToString(), dtRoll.Rows[0]["C_ZYX1"].ToString(), dtRoll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                                    DataTable dtJSXYH = GetCustStd_JH(dtRoll.Rows[0]["C_STD_CODE"].ToString(), dtRoll.Rows[0]["C_STL_GRD"].ToString(), dtRoll.Rows[0]["C_TECH_PROT"].ToString(), dtRoll.Rows[0]["C_ZYX1"].ToString(), dtRoll.Rows[0]["C_ZYX2"].ToString()).Tables[0];

                                                    string zsh = GetZSH();
                                                    string imgpath = $@"D:/QRCode/{zsh}.jpg";//生成二维码图片命名

                                                    #region //生成二维码

                                                    string msg = $@"http://60.6.254.51:808/Common/qualCert.aspx?fyd={item["fydh"].ToString()}&zsh={zsh}";

                                                    Bitmap bt = GenByZXingNet(msg);//调用生成二维码方法
                                                    string upPath = $@"D:/QRCode/{zsh}.jpg";

                                                    bt.Save(upPath);//保存二维码图片

                                                    #endregion

                                                    #region //INSERT



                                                    string cmdText = $@"SELECT C_NO FROM  TS_CUSTFILE WHERE C_NAME='{dtRoll.Rows[0]["C_CGC"].ToString()}'";

                                                    object custNo = DbHelperOra.GetSingle(cmdText);



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
                                                    strSql.AppendFormat("'{0}',", item["fydh"].ToString());
                                                    strSql.AppendFormat("'{0}',", item1["C_BATCH_NO"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_STOVE"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_SPEC"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_STL_GRD"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_STD_CODE"].ToString());
                                                    strSql.AppendFormat("to_date('{0}','YYYY-MM-DD HH24:MI:SS'),", dtRoll.Rows[0]["D_CKSJ"].ToString());
                                                    strSql.AppendFormat("{0},", dtRoll.Rows[0]["N_WGT"].ToString());
                                                    strSql.AppendFormat("{0},", dtRoll.Rows[0]["QUA"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_CH"].ToString());
                                                    strSql.AppendFormat("'{0}',", zsh);
                                                    strSql.AppendFormat("'{0}',", "01");
                                                    strSql.AppendFormat("'{0}',", imgpath);
                                                    strSql.AppendFormat("'{0}',", custNo != null ? custNo.ToString() : "");//客户编码
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_CON_NO"].ToString());
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_CGC"].ToString());//收货单位名称
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_MAT_DESC"].ToString());//产品名称
                                                    strSql.AppendFormat("'{0}',", dtCustStd.Rows[0]["C_STD_JH"].ToString());//交货标准
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_JUDGE_LEV_ZH"].ToString());//质量等级
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_JH_STATE"].ToString());//交货状态
                                                    strSql.AppendFormat("'{0}',", dtJSXYH.Rows[0]["C_JSXYH"].ToString());//技术协议号
                                                    strSql.AppendFormat("'{0}',", dtRoll.Rows[0]["C_XKZH"].ToString()); //许可证号
                                                    strSql.AppendFormat("'{0}',", "8"); //类型
                                                    strSql.AppendFormat("'{0}'", dtRoll.Rows[0]["C_CUST_NAME"].ToString());
                                                    strSql.Append(")");

                                                    TransactionHelper.ExecuteSql(strSql.ToString());

                                                    #endregion

                                                    if (string.IsNullOrEmpty(dtCustStd.Rows[0]["C_STD_JH"].ToString()))
                                                    {
                                                        string logstr = item1["C_BATCH_NO"].ToString() + item["fydh"].ToString() + dtRoll.Rows[0]["C_STL_GRD"].ToString();
                                                        LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('交货标准为空','" + logstr + "','" + name + "')";
                                                        DbHelperOra.ExecuteSql(LogSql);
                                                    }

                                                }
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('生成质证书','" + ex.ToString() + "','" + name + "')";
                                        DbHelperOra.ExecuteSql(LogSql);
                                    }
                                    #endregion

                                    #endregion
                                }
                                #region 变更线材实绩
                                if (BJByBARCODE(barcodestr) == 0)
                                {
                                    TransactionHelper.RollBack();
                                    UPFYDSTATUS(fydh, "2", "根据发运单子表变更线材实绩错误！", id);
                                    break;
                                }

                                #endregion
                                #endregion
                            }
                            if (sfcz == "")
                            {
                                continue;
                            }
                            //上传条码
                            message = dal_Interface_NC_XC.SendXml_DM(path, item["fydh"].ToString());
                            if (message != "1")
                            {
                                TransactionHelper.RollBack();
                                UPFYDSTATUS(fydh, "2", message, id);
                                continue;
                            }
                            TransactionHelper.Commit();
                            UPFYDSTATUS(fydh, "1", "", id);
                            UPFYDSTATUS(fydh, "8");
                        }
                    }
                    return "1";
                }
                else
                {
                    TransactionHelper.RollBack();
                    return "未查询到条码未上传的发运单！";
                }
            }
            catch (Exception ex)
            {
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码发运单信息','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                TransactionHelper.RollBack();
                return "代码异常！";
            }
        }

        #region //远程质证书
        /// <summary>
        /// 远程质证书号
        /// </summary>
        /// <returns></returns>
        public string GetZSH()
        {
            #region 获取发运单
            string maxfyd = string.Empty;

            string no = DateTime.Now.Year.ToString().Substring(2, 2) + (Convert.ToInt32(DateTime.Now.Month) > 9 ? DateTime.Now.Month.ToString() : ("0" + DateTime.Now.Month.ToString())) + (Convert.ToInt32(DateTime.Now.Day) > 9 ? DateTime.Now.Day.ToString() : ("0" + DateTime.Now.Day.ToString()));

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(C_ZSH)  FROM TQC_ZZS_INFO WHERE  C_ZSH LIKE '" + no + "%'");

            object obj = TransactionHelper.GetSingle(strSql.ToString());
            if (obj != null)
            {
                maxfyd = obj.ToString();
            }
            if (!string.IsNullOrEmpty(maxfyd))
            {
                no = (Convert.ToInt64(maxfyd) + 1).ToString();
            }
            else
            {
                no = no + "0001";
            }
            #endregion
            return no;
        }




        public bool DelZSH(string fyd, string batch)
        {
            string strSql = $@"DELETE FROM TQC_ZZS_INFO T WHERE T.C_FYDH='{fyd}' AND T.C_BATCH_NO='{batch}'";

            return TransactionHelper.ExecuteSql(strSql) > 0 ? true : false;

        }

        public bool ExistsZZS(string fyd, string batch)
        {
            string strSql = $@"select count(1) from tqc_zzs_info t where t.c_fydh='{fyd}' and t.c_batch_no='{batch}'";

            return Convert.ToInt32(TransactionHelper.GetSingle(strSql)) > 0 ? true : false;

        }


        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string zyx1, string zyx2)
        {
            string strSql = $@"SELECT MAX((NVL(T.C_ZZS, SUBSTR(T.C_ZYX1, INSTR(T.C_ZYX1, '~') + 1)))) C_STD_JH --交货标准
                              FROM TB_STD_CONFIG T
                             WHERE 1 = 1
                               AND T.C_STD_CODE = '{stdCode}'
                               AND T.C_STL_GRD = '{stlGrd}'
                               AND T.C_ZYX1 = '{zyx1}'
                               AND T.C_ZYX2 = '{zyx2}'";


            return TransactionHelper.Query(strSql);
        }

        public DataSet GetCustStd_JH(string stdCode, string stlGrd, string techProt, string zyx1, string zyx2)
        {
            string strSql = $@"SELECT
                                   MAX((DECODE(T.C_FLAG, 'Y', '技术协议:' || T.C_CUST_TECH_PROT, ''))) C_JSXYH --技术协议
                              FROM TB_STD_CONFIG T
                             WHERE 1 = 1
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


        public DataSet GetZZS(string fyd, string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TT.C_FYDH, --发运单
       TT.C_BATCH_NO, --批次
       TT.C_STOVE, --炉号
       TT.C_SPEC, --规格
       TT.C_STL_GRD, --钢种
       TT.C_STD_CODE, --执行标准
       TT.C_MAT_DESC, --物料名称
       TT.C_JUDGE_LEV_ZH, --质量等级     
       TT.C_JH_STATE, --交货状态     
       TT.C_XKZH, --许可证号
       TT.D_CKSJ, --出库时间
       TT.C_CH, --车号
       TT.C_CUST_NO, --客户编码
       TT.C_TECH_PROT,
       TT.C_CUST_NAME, --客户名称
       TT.C_CGC, --收货单位
       TT.C_CON_NO, --合同号
       TT.ZDR, --制单人
       TT.C_ZYX1,
       TT.C_ZYX2,
       SUM(TT.N_WGT) N_WGT, --重量
       COUNT(0) QUA --件数
  FROM (SELECT T.C_FYDH, --发运单
               T.C_BATCH_NO, --批次
               T.C_STOVE, --炉号
               T.C_SPEC, --规格
               T.C_STL_GRD, --钢种
               T.C_STD_CODE, --执行标准
               T.C_MAT_DESC, --物料名称
               T.C_JUDGE_LEV_ZH, --质量等级
               T.C_ZYX1,
               T.C_ZYX2,
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
               (SELECT MAX(A.D_CKSJ)
                  FROM TMD_DISPATCH_SJZJB A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ, --出库时间
               T.N_WGT, --重量
               (SELECT MAX(A.C_LIC_PLA_NO)
                  FROM TMD_DISPATCH A
                 WHERE A.C_ID = T.C_FYDH) C_CH, --车牌号
               (SELECT MAX(B.C_CUST_NO)
                  FROM TMD_DISPATCHDETAILS A
                  LEFT JOIN TMO_CON B
                    ON B.C_CON_NO = A.C_CON_NO
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CUST_NO, --客户编码
               (SELECT MAX(B.C_TECH_PROT)
                  FROM TMD_DISPATCHDETAILS A
                  LEFT JOIN TMO_CON_ORDER B
                    ON B.C_ORDER_NO = A.C_NO
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_TECH_PROT, --客户协议
               (SELECT MAX(A.C_CON_NO)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CON_NO, --合同号
               (SELECT MAX(A.C_ORGO_CUST)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CUST_NAME, --订货单位
               (SELECT MAX(B.C_NAME)
                  FROM TMD_DISPATCHDETAILS A
                  LEFT JOIN TS_CUSTFILE B
                    ON B.C_NC_M_ID = A.C_CGC
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CGC, --收货单位
               (SELECT MAX(B.C_NAME)
                  FROM TMD_DISPATCH A
                  LEFT JOIN TS_USER B
                    ON B.C_ID = A.C_CREATE_ID
                 WHERE A.C_ID = T.C_FYDH) ZDR --制单人
        
          FROM TRC_ROLL_PRODCUT T
        
         WHERE T.C_MOVE_TYPE = 'S') TT
 WHERE 1 = 1");
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND TT.C_FYDH = '{0}'", fyd);
            }

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND TT.C_BATCH_NO = '{0}'", batch);
            }


            strSql.Append(@" GROUP BY TT.C_FYDH,
          TT.C_BATCH_NO,
          TT.C_STOVE,
          TT.C_SPEC,
          TT.C_STL_GRD,
          TT.C_STD_CODE,
          TT.C_MAT_DESC,
          TT.C_JUDGE_LEV_ZH,
          TT.C_JH_STATE,
          TT.C_XKZH,
          TT.D_CKSJ,
          TT.C_CH,
          TT.C_CUST_NO,
          TT.C_TECH_PROT,
          TT.C_CUST_NAME,
          TT.C_CGC,
          TT.C_CON_NO,
          TT.ZDR,
          TT.C_ZYX1,
          TT.C_ZYX2");
            return TransactionHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private Bitmap GenByZXingNet(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(
            EncodeHintType.ERROR_CORRECTION,
            ZXing.QrCode.Internal.ErrorCorrectionLevel.H

            );
            const int codeSizeInPixels = 250; //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框
            ZXing.Common.BitMatrix bm = writer.Encode(msg);
            Bitmap img = writer.Write(bm);
            return img;
        }

        #endregion


        public string csfydtb(string path, string fyd)
        {
            string message = dal_Interface_NC_XC.SendXml_DM(path, fyd);
            return message;
        }
        /// <summary>
        /// 根据发运单号更新线材实绩
        /// </summary>
        /// <param name="C_BARCODE">牌号</param>
        /// <returns></returns>
        public int BJByBARCODE(string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_FRFLAG='1' ");
            strSql.Append("  where C_BARCODE in(" + C_BARCODE + ") ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }

        #endregion
        #region 转库单
        /// <summary>
        /// 更新转库单中间表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPPCIZKD(string dh, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_ZKD SET");
            strSql.Append(" N_STATUS='" + status + "'");
            strSql.Append("  where  C_ZKD_NO='" + dh + "'  ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新其他出库中间表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPPCIQTCKD(string dh, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_QTCKD SET");
            strSql.Append(" N_STATUS='" + status + "'");
            strSql.Append("  where  C_QTCKD_NO='" + dh + "'  ");
            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新转库单详情
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPPCIZKDTrans(string dh, string id)
        {
            string sql = "SELECT COUNT(1) N_NUM, SUM(N_WGT) N_WGT,  C_MAT_CODE,  C_STD_CODE, C_BATCH_NO, c_judge_lev_zh,c_judge_lev_bp, C_BZYQ FROM TRC_ROLLCZ_LOG WHERE C_DH = '" + dh + "' and C_REMARK='" + id + "'";
            sql += "Group BY C_MAT_CODE,C_STD_CODE,C_BATCH_NO,c_judge_lev_zh,C_BZYQ,c_judge_lev_bp";
            DataTable dt = TransactionHelper.Query(sql).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE TRC_ROLL_ZKD SET");
                strSql.Append(" N_SJNUM='" + item["N_NUM"] + "',N_SJWGT='" + item["N_WGT"] + "' ");
                strSql.Append("  where  C_ZKD_NO='" + dh + "' AND  C_MAT_CODE='" + item["C_MAT_CODE"] + "' AND  C_STD_CODE='" + item["C_STD_CODE"] + "' AND  C_BATCH_NO='" + item["C_BATCH_NO"] + "'   AND  C_BZYQ='" + item["C_BZYQ"] + "'  ");
                if (item["c_judge_lev_zh"].ToString() != "")
                {
                    string zkdzldj = "select c_judge_lev_zh from TRC_ROLL_ZKD  where  C_ZKD_NO='" + dh + "' AND  C_BATCH_NO='" + item["C_BATCH_NO"] + "' ";
                    DataTable zkddt = DbHelperOra.Query(zkdzldj).Tables[0];
                    if (zkddt.Rows.Count > 0)
                    {
                        string zldj = zkddt.Rows[0]["c_judge_lev_zh"].ToString();
                        if (zldj == "")
                        {
                            string zldjsql = "UPDATE   TRC_ROLL_ZKD set c_judge_lev_zh='" + item["c_judge_lev_zh"] + "' WHERE C_ZKD_NO='" + dh + "' AND  C_MAT_CODE='" + item["C_MAT_CODE"] + "' AND  C_STD_CODE='" + item["C_STD_CODE"] + "' AND  C_BATCH_NO='" + item["C_BATCH_NO"] + "'   AND  C_BZYQ='" + item["C_BZYQ"] + "'  AND c_judge_lev_bp='" + item["c_judge_lev_bp"] + "'";
                            if (TransactionHelper.ExecuteSql(zldjsql) != 1)
                            {
                                return 0;
                            }
                        }
                    }
                    strSql.Append("  AND  c_judge_lev_zh='" + item["c_judge_lev_zh"] + "' AND  c_judge_lev_bp='" + item["c_judge_lev_bp"] + "'");
                }
                else
                {
                    strSql.Append("  AND  c_judge_lev_bp='" + item["c_judge_lev_bp"] + "'");
                }
                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                {
                    return 0;
                }
            }
            return 1;
        }
        /// <summary>
        /// 更新其他出库中间表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPPCIQTCKDtrans(string dh, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_QTCKD SET");
            strSql.Append(" N_STATUS='" + status + "'");
            strSql.Append("  where  C_QTCKD_NO='" + dh + "'  ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新其他出库中间表详情
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int UPPCIQTCKDITEM(string dh, string type)
        {
            string sql = "SELECT COUNT(1) N_NUM,SUM(N_WGT) N_WGT,C_MAT_CODE,C_STD_CODE,C_BATCH_NO,c_judge_lev_zh,C_BZYQ FROM TRC_ROLL_PRODCUT WHERE C_QTCKD_NO='" + dh + "' ";

            if (type == "材料出库")
            {
                sql += " AND C_MOVE_TYPE='S'";
            }
            else
            {
                sql += " AND C_MOVE_TYPE='QE'";
            }
            sql += "Group BY C_MAT_CODE,C_STD_CODE,C_BATCH_NO,c_judge_lev_zh,C_BZYQ";
            DataTable dt = TransactionHelper.Query(sql).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE TRC_ROLL_QTCKD_ITEM SET");
                strSql.Append(" N_SJNUM='" + item["N_NUM"] + "',N_SJWGT='" + item["N_WGT"] + "'");
                strSql.Append("  where  C_QTCKD_NO='" + dh + "' AND  C_MAT_CODE='" + item["C_MAT_CODE"] + "' AND  C_STD_CODE='" + item["C_STD_CODE"] + "' AND  C_BATCH_NO='" + item["C_BATCH_NO"] + "' AND  c_judge_lev_zh='" + item["c_judge_lev_zh"] + "'  AND  C_BZYQ='" + item["C_BZYQ"] + "' ");
                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                {
                    return 0;
                }
            }

            return 1;
        }
        /// <summary>
        /// 更新条码转库单实绩表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int UPYWDBZ(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_Shift_Record SET");
            strSql.Append(" by1='已撤回！',updatets='" + DateTime.Now + "'");
            strSql.Append("  where  pk_SeZJB_Shift_Record='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新条码转库单实绩表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int UPZKDBZ(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_ZKD_finished SET");
            strSql.Append(" by1='已撤回！',updatets='" + DateTime.Now + "'");
            strSql.Append("  where  pk_SeZJB_ZKD_finishes='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除转库单中间表
        /// </summary>
        /// <param name="dhstr">单号</param>
        /// <returns></returns>
        public int UPRPBYZKD(string dhstr, string id)
        {
            #region 获取线材操作记录表
            string sql = "SELECT C_BARCODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE FROM TRC_ROLLCZ_LOG WHERE C_DH='" + dhstr + "' AND C_REMARK='" + id + "'";
            DataTable dt = DbHelperOra.Query(sql).Tables[0];
            #endregion
            if (dt.Rows.Count < 1)
            {
                return 0;
            }
            string barcode = "";
            string ck = dt.Rows[0]["C_YLINEWH_CODE"].ToString();
            string qy = dt.Rows[0]["C_YLINEWH_AREA_CODE"].ToString();
            string kw = dt.Rows[0]["C_YLINEWH_LOC_CODE"].ToString();
            foreach (DataRow item in dt.Rows)
            {
                barcode += "'" + item["C_BARCODE"] + "',";
            }
            barcode = barcode.Substring(0, barcode.Length - 1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Trc_Roll_Prodcut SET C_MOVE_TYPE='M',C_LINEWH_CODE='" + ck + "',C_LINEWH_AREA_CODE='" + qy + "',C_LINEWH_LOC_CODE='" + kw + "',C_ZKD_NO='" + dhstr + "'");
            strSql.Append(" WHERE C_BARCODE in(" + barcode + ")");
            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除转库单中间表
        /// </summary>
        /// <param name="dhstr">单号</param>
        /// <returns></returns>
        public int UPRPBYYWD(string dhstr, string id)
        {
            #region 获取线材操作记录表
            string sql = "SELECT C_BARCODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE FROM TRC_ROLLCZ_LOG WHERE C_DH='" + dhstr + "' AND C_REMARK='" + id + "'";
            DataTable dt = TransactionHelper.Query(sql).Tables[0];
            #endregion
            if (dt.Rows.Count < 1)
            {
                return 0;
            }
            string barcode = "";
            string ck = dt.Rows[0]["C_YLINEWH_CODE"].ToString();
            string qy = dt.Rows[0]["C_YLINEWH_AREA_CODE"].ToString();
            string kw = dt.Rows[0]["C_YLINEWH_LOC_CODE"].ToString();
            foreach (DataRow item in dt.Rows)
            {
                barcode += "'" + item["C_BARCODE"] + "',";
            }
            barcode = barcode.Substring(0, barcode.Length - 1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Trc_Roll_Prodcut SET C_MOVE_TYPE='E',C_LINEWH_CODE='" + ck + "',C_LINEWH_AREA_CODE='" + qy + "',C_LINEWH_LOC_CODE='" + kw + "'");
            strSql.Append(" WHERE C_BARCODE in(" + barcode + ")");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        #region 发送转库单
        /// <summary>
        /// 更新线材实绩
        /// </summary>
        /// <param name="dhstr">转库单号</param>
        /// <returns></returns>
        public int UPZKSTATUS(string zkd, CommonKC list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_ZKD_NO='" + zkd + "',C_MOVE_TYPE='M'");
            strSql.Append("  where C_MOVE_TYPE='E' ");
            if (list.mat != "")
            {
                strSql.Append(" and C_MAT_CODE='" + list.mat + "' ");
            }
            if (list.zldj != "")
            {
                strSql.Append(" AND C_JUDGE_LEV_ZH='" + list.zldj + "' ");
            }
            if (list.bpdj != "")
            {
                strSql.Append(" AND C_JUDGE_LEV_BP='" + list.bpdj + "' ");
            }
            if (list.ck != "")
            {
                strSql.Append(" AND C_LINEWH_CODE='" + list.ck + "'  ");
            }
            if (list.batch != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + list.batch + "'  ");
            }
            if (list.bzyq != "")
            {
                strSql.Append(" AND C_BZYQ='" + list.bzyq + "' ");
            }
            strSql.Append(" AND ROWNUM<='" + list.num + "'");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 分组获取库存信息
        /// </summary>
        /// <param name="C_QTCKD"></param>
        /// <param name="status"></param>
        /// <param name="C_ZKD"></param>
        /// <returns></returns>
        public DataSet GetXCKC(string C_QTCKD, string status, string C_ZKD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) N_NUM,C_STOVE,C_BATCH_NO,C_STL_GRD,SUM(N_WGT) N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
            if (C_QTCKD.Trim() != "")
            {
                strSql.Append(" and C_QTCKD_NO ='" + C_QTCKD + "' ");
            }
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" and C_ZKD_NO ='" + C_ZKD + "' ");
            }
            strSql.Append(" GROUP BY  C_BATCH_NO,C_STOVE,C_STL_GRD,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 分组获取库存信息
        /// </summary>
        /// <param name="C_QTCKD"></param>
        /// <param name="status"></param>
        /// <param name="C_ZKD"></param>
        /// <returns></returns>
        public DataSet GetXCKC1(string C_QTCKD, string status, string C_ZKD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) N_NUM,C_STOVE,C_BATCH_NO,C_STL_GRD,SUM(N_WGT) N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
            if (C_QTCKD.Trim() != "")
            {
                strSql.Append(" and C_QTCKD_NO ='" + C_QTCKD + "' ");
            }
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" and C_ZKD_NO ='" + C_ZKD + "' ");
            }
            strSql.Append(" GROUP BY  C_BATCH_NO,C_STOVE,C_STL_GRD,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 通过转库单号获得转库单数据
        /// </summary>
        /// <param name="dh">单号</param>
        /// <returns></returns>
        public DataSet GetZKDListBydh(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_ID,C_MBLINEWH_ID,C_STL_GRD,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS ");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE N_STATUS=1");
            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO ='" + dh + "' ");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 检测库存是否变更
        /// </summary>
        /// <param name="mat">物料号</param>
        /// <param name="ck">仓库</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public int CKKC(string mat, string ck, string batch, string zldj, string bzyq, string bpdj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) N_NUM FROM TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE='E'");
            if (mat.Trim() != "")
            {
                strSql.Append(" and C_MAT_CODE='" + mat + "'");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE='" + ck + "'");
            }
            if (batch.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO='" + batch + "'");
            }
            if (zldj.Trim() != "")
            {
                strSql.Append(" and C_JUDGE_LEV_ZH='" + zldj + "'");
            }
            if (bpdj.Trim() != "")
            {
                strSql.Append(" and C_JUDGE_LEV_BP='" + bpdj + "'");
            }
            if (bzyq.Trim() != "")
            {
                strSql.Append(" and C_BZYQ='" + bzyq + "'");
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
        /// 获取最新的转库单号
        /// </summary>
        /// <param name="zkdstr">转库单</param>
        /// <returns></returns>
        public string GetZKDNO(string zkdstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(C_ZKD_NO) ");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE 1=1 ");
            if (zkdstr.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO LIKE 'ZK" + zkdstr + "%' ");
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 向条码发送转库单
        /// </summary>
        /// <param name="idstr">id字符串</param>
        /// <param name="ckcode">仓库代码</param>
        /// <returns></returns>
        public string SENDZKD1(List<CommonKC> list, string mbck, string zkd, string userId, string usercode)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.SENDZKD";
            DataTable dt = null;
            TransactionHelper.BeginTransaction();//开启ora事务
            TransactionHelper_SQL.BeginTransaction();//开启sql事务
            try
            {
                ///变更线材实绩
                foreach (CommonKC commonkc in list)
                {
                    if (UPZKSTATUS(zkd, commonkc) != commonkc.num)//更新线材实绩表
                    {
                        TransactionHelper.RollBack();
                        TransactionHelper_SQL.RollBack();
                        return "更新线材实绩表状态错误！";
                    }
                }
                ///添加转库单中间表
                DataTable qtckdt = GetXCKC1("", "M", zkd).Tables[0];
                if (qtckdt.Rows.Count == 0)
                {
                    TransactionHelper.RollBack();
                    TransactionHelper_SQL.RollBack();
                    return "查询出库详情错误！";
                }
                foreach (DataRow item in qtckdt.Rows)
                {
                    string mbsql = "Select C_ID From TPB_LINEWH WHERE C_LINEWH_CODE='" + mbck + "'";
                    DataTable mbcktb = DbHelperOra.Query(mbsql).Tables[0];
                    if (mbcktb.Rows.Count == 0)
                    {
                        TransactionHelper.RollBack();
                        TransactionHelper_SQL.RollBack();
                        return "目标仓库(" + mbck + ")信息查询失败！";
                    }
                    mbsql = mbcktb.Rows[0]["C_ID"].ToString();
                    string ycksql = "Select C_ID From TPB_LINEWH WHERE C_LINEWH_CODE='" + item["C_LINEWH_CODE"] + "'";
                    DataTable ycktb = DbHelperOra.Query(ycksql).Tables[0];
                    if (ycktb.Rows.Count == 0)
                    {
                        TransactionHelper.RollBack();
                        TransactionHelper_SQL.RollBack();
                        return "源仓库(" + item["C_LINEWH_CODE"] + ")信息查询失败！";
                    }
                    ycksql = ycktb.Rows[0]["C_ID"].ToString();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("INSERT INTO TRC_ROLL_ZKD(C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_ID,C_MBLINEWH_ID,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_STD_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_BZYQ,N_STATUS,C_ZYX1,C_ZYX2,C_EMP_ID,C_CREATE_CODE,D_CREATE_DATE) VALUES('" + zkd + "','" + item["C_MAT_CODE"] + "','" + item["C_MAT_DESC"] + "','" + ycksql + "','" + mbsql + "','" + item["C_LINEWH_CODE"] + "','" + mbck + "','" + item["C_STL_GRD"] + "','" + item["C_STD_CODE"] + "','" + item["C_JUDGE_LEV_BP"] + "','" + item["C_JUDGE_LEV_ZH"] + "','" + item["N_NUM"] + "','" + item["N_WGT"] + "','件【线材】','吨','" + item["C_BATCH_NO"] + "','" + item["C_SPEC"] + "','" + item["C_STOVE"] + "','" + item["C_BZYQ"] + "',1,'" + item["C_ZYX1"] + "','" + item["C_ZYX2"] + "','" + userId + "' ,'" + usercode + "',to_date('" + DateTime.Now + "', 'yyyy-mm-dd hh24:mi:ss'))");

                    if (TransactionHelper.ExecuteSql(strSql.ToString()) == 0)
                    {
                        TransactionHelper.RollBack();
                        TransactionHelper_SQL.RollBack();
                        return "添加转库单中间表错误！";
                    }
                }
                dt = GetZKDListBydh(zkd).Tables[0];//要传输的转库单数据
                if (dt.Rows.Count != list.Count)
                {
                    TransactionHelper.RollBack();
                    TransactionHelper_SQL.RollBack();
                    return "查询要传输的转库单数据错误！";
                }
                foreach (DataRow zkditem in dt.Rows)
                {
                    string zldj = zkditem["C_JUDGE_LEV_ZH"].ToString();
                    if (zldj == "")
                    {
                        zldj = zkditem["C_JUDGE_LEV_BP"].ToString();
                    }
                    //条码
                    string sql = "";
                    sql += "insert into ReZJB_ZKD(zkdh,sck,tck,wlh,wlmc,pch,sx,jhsl,jhzl,zjldw,fjldw,ph,gg,vfree0,vfree1,vfree2,vfree3,ZJBstatus,insertts,CAPPK) values('" + zkditem["C_ZKD_NO"] + "','" + zkditem["C_LINEWH_ID"] + "','" + zkditem["C_MBLINEWH_ID"] + "','" + zkditem["C_MAT_CODE"] + "','" + zkditem["C_MAT_DESC"] + "','" + zkditem["C_BATCH_NO"] + "','" + zldj + "','" + zkditem["N_NUM"] + "','" + zkditem["N_WGT"] + "','件【线材】','吨','" + zkditem["C_STL_GRD"] + "','" + zkditem["C_SPEC"] + "','" + zkditem["C_STOVE"] + "','" + zkditem["C_ZYX1"] + "','" + zkditem["C_ZYX2"] + "','" + zkditem["C_BZYQ"] + "','0','" + DateTime.Now + "','" + zkditem["C_ID"] + "')";
                    if (TransactionHelper_SQL.ExecuteSql(sql) == 0)
                    {

                        TransactionHelper.RollBack();
                        TransactionHelper_SQL.RollBack();
                        return "发送条码中间表错误！";
                    }
                }

                TransactionHelper.Commit();//提交ora事务
                TransactionHelper_SQL.Commit();//提交sql事务
                return "1";
            }
            catch (Exception ex)
            {
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('向条码发送转库单','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                TransactionHelper.RollBack();
                TransactionHelper_SQL.RollBack();
                return "代码错误";
            }
        }
        #endregion
        #region 同步转库单
        /// <summary>
        /// 根据转库单号获取条码转库单数据
        /// </summary>
        /// <param name="C_ZKD">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMZKZJB(string C_ZKD, DateTime dt1, DateTime dt2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select zkdh,case ZJBstatus when '0' then '未同步' when '1' then '同步成功'when '2' then '同步异常'end ZJBstatus ,by1,insertts,updatets,pk_SeZJB_ZKD_finishes ");
            strSql.Append(" FROM SeZJB_ZKD_finished WHERE 1=1");
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" AND zkdh LIKE'%" + C_ZKD + "%' ");
            }
            strSql.Append(" AND insertts >='" + dt1 + "' AND insertts <='" + dt2 + "' ");
            strSql.Append(" ORDER BY  zkdh desc");
            return TransactionHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 查询条码中间表未同步成功的转库单
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetZKDHByTM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ZKDH,pk_SeZJB_ZKD_finishes,by1 FROM SeZJB_ZKD_finished  WHERE ZJBstatus in('0','2')");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据转库单号判断PCI是否存在本转库单
        /// </summary>
        /// <param name="ZKDH">转库单号</param>
        /// <returns>是否存在</returns>
        public bool ExistsByZKD(string ZKDH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_ZKD ");
            strSql.Append(" where C_ZKD_NO='" + ZKDH + "'");
            return DbHelperOra.Exists(strSql.ToString());
        }
        /// <summary>
        /// 更新条码中间表状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">备注</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int UPZKSTATUS(string status, string message, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_ZKD_finished SET");
            strSql.Append(" ZJBstatus='" + status + "',by1='" + message + "',updatets='" + DateTime.Now + "'");
            strSql.Append("  where pk_SeZJB_ZKD_finishes='" + id + "' ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据转库单查询转库单计划数量
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public DataSet QueryTMJHZKZS(string zkdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.N_NUM FROM TRC_ROLL_ZKD a WHERE  a.C_ZKD_NO = '" + zkdh + "' ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据转库单查询应转库存
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public DataSet QueryTMSJZKZS(string zkdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.ZKDH, a.Barcode FROM WMS_Bms_Tra_ZKD_Detail a WHERE  a.ZKDH = '" + zkdh + "' ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据转库单查询条码库存
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public DataSet QueryTMZKKWByKC(string zkdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.ZKDH, a.Barcode, b.CK, b.HW,b.RKRY,b.RQ FROM WMS_Bms_Tra_ZKD_Detail a, WMS_Bms_Inv_Info b WHERE a.Barcode = b.Barcode and a.ZKDH = '" + zkdh + "' ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号获取转库单号
        /// </summary>
        /// <param name="Barcode">牌号</param>
        /// <returns></returns>
        public string GetZKDDH(string Barcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_ZKD_NO FROM TRC_ROLL_PRODCUT ");
            strSql.Append("  where C_BARCODE='" + Barcode + "'");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["C_ZKD_NO"].ToString();
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 生产修改转库单语句
        /// </summary>
        /// <param name="kcxqitem"></param>
        /// <returns></returns>
        private static StringBuilder UPZKD(DataRow kcxqitem)
        {
            string qy = kcxqitem["HW"].ToString().Substring(0, 5);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_ZKD_NO='',C_FYDH='',C_QTCKD_NO='', C_MOVE_TYPE = 'E',C_LINEWH_CODE='" + kcxqitem["CK"] + "',C_LINEWH_AREA_CODE='" + qy + "' ,C_LINEWH_LOC_CODE='" + kcxqitem["HW"] + "' ");
            strSql.Append("  where C_BARCODE='" + kcxqitem["Barcode"] + "' ");
            return strSql;
        }
        /// <summary>
        /// 根据转库单号获取未匹配线材
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public DataSet GetWPPDH(string zkdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_BARCODE FROM TRC_ROLL_PRODCUT ");
            strSql.Append("  where C_ZKD_NO='" + zkdh + "' AND C_MOVE_TYPE='M'");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据单号，牌号更新线材实绩
        /// </summary>
        /// <param name="dh">转库单号</param>
        /// <param name="C_BARCODE">牌号</param>
        /// <returns></returns>
        public int UPRPByZKD(string dh, string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='M', C_ZKD_NO='" + dh + "',C_QTCKD_NO=''");
            strSql.Append("  where C_BARCODE='" + C_BARCODE + "' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据单号，牌号更新线材实绩
        /// </summary>
        /// <param name="dh">其他出库单单号</param>
        /// <param name="C_BARCODE">牌号</param>
        /// <returns></returns>
        public int UPRPByQTCKD(string dh, string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='QC', C_QTCKD_NO='" + dh + "',C_ZKD_NO='',C_FYDH=''");
            strSql.Append("  where C_BARCODE='" + C_BARCODE + "' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号更新线材实绩
        /// </summary>
        /// <param name="C_QTCKD_NO">牌号</param>
        /// <returns></returns>
        public int UPRPBySJSL(string C_QTCKD_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='E' ,C_ZKD_NO='',C_QTCKD_NO=''");
            strSql.Append("  where C_QTCKD_NO='" + C_QTCKD_NO + "'  AND C_MOVE_TYPE='QC' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据牌号更新线材实绩
        /// </summary>
        /// <param name="C_BARCODE">牌号</param>
        /// <returns></returns>
        public int UPRPByNULL(string C_BARCODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='E' ,C_ZKD_NO='',C_QTCKD_NO=''");
            strSql.Append("  where C_BARCODE='" + C_BARCODE + "' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="ck">仓库</param>
        /// <param name="mbck">目标仓库</param>
        /// <param name="grd">钢种</param>
        /// <param name="ph">批号</param>
        /// <param name="sfdp">是否待判</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataSet GetZKDList(string dh, string ck, string mbck, string grd, string ph, string sfdp, string status, string rq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_ZKD_NO,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_MBLINEWH_CODE,C_STL_GRD,C_STD_CODE,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,C_EMP_ID,D_MOD_DT,C_JUDGE_LEV_BP,DECODE(N_STATUS,0,'已撤回',1,'未回实绩',2,'已回实绩','异常') N_STATUS,D_CREATE_DATE,C_CREATE_CODE");
            strSql.Append(" FROM TRC_ROLL_ZKD WHERE  C_LINEWH_CODE Not LIKE '68%' ");
            if (status != "全部")
            {
                strSql.Append(" AND N_STATUS='" + status + "'");
            }
            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_ZKD_NO LIKE '%" + dh + "%' ");
            }
            if (sfdp.Trim() != "全部")
            {
                strSql.Append(" and nvl2(C_JUDGE_LEV_ZH,0,1)='" + sfdp + "' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" AND C_LINEWH_CODE LIKE'%" + ck + "%' ");
            }
            if (mbck.Trim() != "")
            {
                strSql.Append(" AND C_MBLINEWH_CODE LIKE'%" + mbck + "%' ");
            }
            if (grd.Trim() != "")
            {
                strSql.Append(" AND C_STL_GRD LIKE'%" + grd + "%' ");
            }
            if (ph.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO LIKE'%" + ph + "%' ");
            }
            if (rq.Trim() != "")
            {
                strSql.Append(" AND to_date(to_char(D_MOD_DT,'yyyy-mm-dd'),'yyyy-MM-dd') =to_date('" + rq + "','yyyy-MM-dd')  ");
            }
            strSql.Append(" ORDER BY  replace(C_ZKD_NO,'ZK','')  desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dh">单号</param>
        /// <param name="ck">仓库</param>
        /// <param name="mbck">目标仓库</param>
        /// <param name="grd">钢种</param>
        /// <param name="ph">批号</param>
        /// <param name="sfdp">是否待判</param>
        /// <param name="status">状态</param>
        /// <param name="zdrq">制单日期</param>
        /// <returns></returns>
        public DataSet GetQTCKDList(string dh, string ck, string mbck, string grd, string ph, string sfdp, string status, string zdrq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  T.C_QTCKD_NO,T.C_LIC_PLA_NO,T.C_ADDRESS,T.C_CREATE_ID,T.D_CREATE_DT,DECODE(T.N_STATUS,0,'已撤回',1,'未回实绩',2,'已回实绩','异常') N_STATUS,T.C_TYPE,T.C_CYS,T.C_SHDW,T.D_FYSJ,T.C_MBWH_ID,T.C_MBWH_NAME,B.C_BATCH_NO,B.C_JUDGE_LEV_ZH,B.C_JUDGE_LEV_BP,B.C_MAT_CODE,B.C_MAT_DESC,B.C_STL_GRD,B.C_SPEC,B.N_NUM,B.N_WGT, B.C_BZYQ, B.C_LINEWH_CODE,B.C_STD_CODE,T.C_CREATE_CODE FROM TRC_ROLL_QTCKD T INNER JOIN TRC_ROLL_QTCKD_ITEM B ON T.C_QTCKD_NO = B.C_QTCKD_NO WHERE 1=1 ");
            if (status != "全部")
            {
                strSql.Append(" AND t.N_STATUS='" + status + "'");
            }
            if (dh.Trim() != "")
            {
                strSql.Append(" AND  t.c_qtckd_no LIKE '%" + dh + "%' ");
            }
            if (sfdp.Trim() != "全部")
            {
                strSql.Append(" and nvl2(b.C_JUDGE_LEV_ZH,0,1)='" + sfdp + "' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" AND b.C_LINEWH_CODE LIKE'%" + ck + "%' ");
            }
            if (mbck.Trim() != "")
            {
                strSql.Append(" AND t.c_mbwh_id LIKE'%" + mbck + "%' ");
            }
            if (grd.Trim() != "")
            {
                strSql.Append(" AND b.C_STL_GRD LIKE'%" + grd + "%' ");
            }
            if (ph.Trim() != "")
            {
                strSql.Append(" AND b.C_BATCH_NO LIKE'%" + ph + "%' ");
            }
            if (zdrq.Trim() != "")
            {
                strSql.Append(" AND to_date(to_char(T.D_CREATE_DT,'yyyy-mm-dd'),'yyyy-MM-dd') =to_date('" + zdrq + "','yyyy-MM-dd')  ");
            }
            strSql.Append(" ORDER BY replace(t.c_qtckd_no,'QC','') desc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取其他出库类型
        /// </summary>
        /// <param name="dh">单号</param>
        /// <returns></returns>
        public string GetQTCKTYPE(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  C_TYPE FROM TRC_ROLL_QTCKD WHERE C_QTCKD_NO='" + dh + "' ");
            var obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }

        }
        /// <summary>
        /// 同步条码转库单信息
        /// </summary>
        /// <param name="path">地址</param>
        /// <returns></returns>
        public string TBZKD1(string path)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.TBZKD";
            try
            {
                DataTable dt = GetZKDHByTM().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string id = item["pk_SeZJB_ZKD_finishes"].ToString();
                        string zkd = item["ZKDH"].ToString();
                        if (item["by1"].ToString().Contains("已撤回"))
                        {
                            continue;
                        }
                        if (ExistsByZKD(zkd) == false)
                        {
                            UPZKSTATUS("3", "当前单号PCI系统不存在！", id);
                            continue;
                        }
                        else
                        {
                            DELROLL(zkd, id);
                            TransactionHelper.BeginTransaction();
                            // 发运单号多次发送覆盖
                            if (CKZKD(zkd) > 1)
                            {
                                string lastid = GetLastZKDID(zkd, id);//获取上一条id
                                if (lastid != "")
                                {
                                    if (UPRPBYZKD(zkd, lastid) == 0)//撤回线材实绩
                                    {
                                        TransactionHelper.RollBack();
                                        UPZKSTATUS("2", "撤回线材实绩错误", id);
                                        return "撤回线材实绩错误";
                                    }
                                    UPZKDBZ(lastid);
                                }
                            }


                            //传送条码
                            DataTable ckdt = QueryTMZKKWByKC(zkd).Tables[0];///查询条码出库表
                            List<string> zkdhlist = new List<string>();
                            List<string> qtckdhlist = new List<string>();
                            List<string> nulldhlist = new List<string>();
                            string msg = "";
                            DataTable szdt = QueryTMSJZKZS(zkd).Tables[0];//实绩转库数量
                            if (szdt.Rows.Count != ckdt.Rows.Count)
                            {
                                TransactionHelper.RollBack();

                                UPPCIZKD(zkd, "3");
                                UPZKSTATUS("2", "异常:错误编码255，单号" + zkd + "同步数量不一致，实绩转库数量" + szdt.Rows.Count + "同步数量" + ckdt.Rows.Count + "！", id);
                                continue;
                            }
                            if (ckdt.Rows.Count > 0)
                            {
                                foreach (DataRow xqitem in ckdt.Rows)
                                {
                                    if (xqitem["Barcode"].ToString() == "3319058832020")
                                    {

                                    }
                                    string barcode = xqitem["Barcode"].ToString();
                                    string zkdh = GetZKDDH(barcode);
                                    if (zkdh == "0")
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "打牌序号" + barcode + "PCI系统不存在！", id);
                                        break;
                                    }
                                    if (zkd == zkdh)
                                    {
                                        StringBuilder strSql = UPZKD(xqitem);
                                        if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                        {
                                            msg = "1";
                                            TransactionHelper.RollBack();
                                            UPPCIZKD(zkd, "3");
                                            UPZKSTATUS("2", "异常:错误编码，201打牌序号" + barcode + "更新线材实绩状态错误", id);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (zkdh != "")
                                        {
                                            zkdhlist.Add(zkdh);
                                            StringBuilder strSql = UPZKD(xqitem);
                                            if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                            {
                                                msg = "1";
                                                TransactionHelper.RollBack();
                                                UPPCIZKD(zkd, "3");
                                                UPZKSTATUS("2", "异常:错误编码202，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            string ckdh = GetQTCKDByPH(barcode);
                                            if (ckdh == "0")
                                            {
                                                msg = "1";
                                                TransactionHelper.RollBack();
                                                UPPCIZKD(zkd, "3");
                                                UPZKSTATUS("2", "打牌序号" + barcode + "PCI系统不存在！", id);
                                                break;
                                            }
                                            if (ckdh != "")
                                            {
                                                qtckdhlist.Add(ckdh);
                                                StringBuilder strSql = UPZKD(xqitem);
                                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                                {
                                                    msg = "1";
                                                    TransactionHelper.RollBack();
                                                    UPPCIZKD(zkd, "3");
                                                    UPZKSTATUS("2", "异常:错误编码204，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                nulldhlist.Add("");
                                                StringBuilder strSql = UPZKD(xqitem);
                                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                                {
                                                    msg = "1";
                                                    TransactionHelper.RollBack();
                                                    UPPCIZKD(zkd, "3");
                                                    UPZKSTATUS("2", "异常:错误编码205，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                    DataTable ydt = GetXCKC(barcode).Tables[0];//获取原线材状态
                                    DataRow data = ydt.Rows[0];
                                    string qy = xqitem["HW"].ToString().Substring(0, 5);
                                    string sql = "insert into TRC_ROLLCZ_LOG(C_DH,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,D_CZ_DATE,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_REMARK,C_EMP_ID,C_BZYQ,C_JUDGE_LEV_BP) values('" + zkd + "','" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','" + xqitem["CK"] + "','" + qy + "','" + xqitem["HW"] + "','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "', to_date('" + xqitem["RQ"] + "', 'yyyy-mm-dd hh24:mi:ss'),'" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + barcode + "','1','" + id + "','" + xqitem["RKRY"] + "','" + data["C_BZYQ"] + "','" + data["C_JUDGE_LEV_BP"] + "')";
                                    if (TransactionHelper.ExecuteSql(sql.ToString()) != 1)///添加操作记录
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "PCI添加操作记录时错误", id);
                                        break;
                                    }
                                }
                                if (msg == "1")//验证是否有异常
                                {
                                    continue;
                                }
                                foreach (var wppitem in zkdhlist)
                                {
                                    DataTable wppdt = GetWPPDH(zkd).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码206，单号" + zkd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByZKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码207，打牌序号" + wppdt.Rows[0]["C_BARCODE"] + "更新线材实绩状态错误", id);
                                        break;
                                    }
                                }
                                if (msg == "1")//验证是否有异常
                                {
                                    continue;
                                }
                                foreach (var wppitem in qtckdhlist)
                                {
                                    DataTable wppdt = GetWPPDH(zkd).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码208，单号" + zkd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByQTCKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码209，打牌序号" + wppdt.Rows[0]["C_BARCODE"] + "更新线材实绩状态错误（其他出库单）", id);
                                        break;
                                    }
                                }
                                if (msg == "1")//验证是否有异常
                                {
                                    continue;
                                }
                                foreach (var wppitem in nulldhlist)
                                {
                                    DataTable wppdt = GetWPPDH(item["zkdh"].ToString()).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码210，单号" + zkd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByNULL(wppdt.Rows[0]["C_BARCODE"].ToString()) == 0)
                                    {
                                        msg = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIZKD(zkd, "3");
                                        UPZKSTATUS("2", "异常:错误编码211，打牌序号" + wppdt.Rows[0]["C_BARCODE"].ToString() + "变更线材实绩错误！（库存线材）", id);
                                        break;
                                    }
                                }
                                if (msg == "1")//验证是否有异常
                                {
                                    continue;
                                }
                                string upsql = "update Trc_Roll_Prodcut set C_MOVE_TYPE='E' ,C_ZKD_NO='' WHERE C_MOVE_TYPE='M' and C_ZKD_NO='" + zkd + "'";
                                TransactionHelper.ExecuteSql(upsql);
                            }
                            else
                            {
                                UPPCIZKD(zkd, "3");
                                UPZKSTATUS("2", "条码仓库不存在库存信息！", id);
                                continue;
                            }

                            if (UPPCIZKDTrans(zkd, id) == 0)
                            {
                                TransactionHelper.RollBack();
                                UPZKSTATUS("2", "变更PCI转库单中间表错误！", id);
                                continue;
                            }

                            //传送NC
                            string message = dal_Interface_NC_Roll_ZK4I.SendXml_GP(path, zkd);
                            if (message != "1")//发送其他出库单实绩到NC(4I)
                            {
                                if (message.Contains("存在") == false)
                                {
                                    TransactionHelper.RollBack();
                                    UPPCIZKD(zkd, "3");
                                    UPZKSTATUS("2", "4I" + message, id);
                                    continue;
                                }
                            }
                            message = dal_Interface_NC_Roll_ZK4A.SendXml_GP(path, zkd);
                            if (message != "1")//发送其他出库单实绩到NC(4A)
                            {
                                TransactionHelper.RollBack();
                                UPPCIZKD(zkd, "3");
                                UPZKSTATUS("2", "4A" + message, id);
                                continue;
                            }
                            if (UPPCIZKD(zkd, "2") == 0)
                            {
                                TransactionHelper.RollBack();
                                UPZKSTATUS("2", "变更PCI转库单中间表错误！", id);
                                continue;
                            }
                            TransactionHelper.Commit();
                            UPZKSTATUS("1", "", id);
                        }
                    }
                    return "1";
                }
                else
                {
                    return "条码不存在未上传的转库单信息！";
                }
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码转库单信息','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                return "代码异常！";
            }
        }
        #endregion
        #region 撤回其他出库单




        /// <summary>
        /// 删除转库单表
        /// </summary>
        /// <param name="zkd">转库单</param>
        /// <returns>返回int类型 大于0发送成功,等于0发送失败</returns>
        public int DELZKD(string zkd)
        {
            string sql = "";
            sql += "Delete TRC_ROLL_ZKD WHERE C_ZKD_NO ='" + zkd + "'";
            return DbHelperOra.ExecuteSql(sql);
        }

        /// <summary>
        /// 变更线材实绩表
        /// </summary>
        /// <param name="zkd">转库单</param>
        /// <returns></returns>
        public int UPZKDSTATUSBY(string zkd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET ");
            strSql.Append("C_MOVE_TYPE='E',C_ZKD_NO='',C_QTCKD_NO=''");
            strSql.Append("  where C_ZKD_NO ='" + zkd + "' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        ///根据条码其他出库单撤销数据
        /// </summary>
        /// <param name="zkd">转库单</param>
        /// <returns></returns>
        public int CXZKDByDH(string zkd)
        {
            if (CKZKD(zkd) > 0)
            {
                return 0;
            }
            TransactionHelper.BeginTransaction();
            if (UPZKDSTATUSBY(zkd) == 0)
            {
                TransactionHelper.RollBack();
                return 0;
            }
            if (UPPCIZKD(zkd, "0") == 0)
            {
                TransactionHelper.RollBack();
                return 0;
            }
            TransactionHelper.Commit();
            return 1;
        }
        #endregion
        #endregion
        #region 其他出库单
        /// <summary>
        /// 获取其他出库单数据
        /// </summary>
        /// <param name="C_QTCKD">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMZJB(string C_QTCKD, DateTime dt1, DateTime dt2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ckdh,case ZJBstatus when '0' then '未同步' when '1' then '同步成功'when '2' then '同步异常'end ZJBstatus ,by1,insertts,updatets,pk_SeZJB_QTCKD_finished ");
            strSql.Append(" FROM SeZJB_QTCKD_finished WHERE 1=1");
            if (C_QTCKD.Trim() != "")
            {
                strSql.Append(" AND ckdh LIKE'%" + C_QTCKD + "%' ");
            }
            strSql.Append(" AND insertts >='" + dt1 + "'  AND insertts <='" + dt2 + "' ");
            strSql.Append(" ORDER BY  ckdh desc,pk_SeZJB_QTCKD_finished ");
            return TransactionHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 查未同步条码其他出库单中间表数据
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet QueryQTCKD()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ckdh,pk_SeZJB_QTCKD_finished,by1 FROM SeZJB_QTCKD_finished  WHERE ZJBstatus in('0','2') ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        #region 撤回其他出库单
        /// <summary>
        /// 根其他出库单号判断PCI是否存在此其他出库单
        /// </summary>
        /// <param name="QTCKD">此其他出库单</param>
        /// <returns>是否存在</returns>
        public bool ExistsByQTCKD(string QTCKD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_QTCKD ");
            strSql.Append(" where C_QTCKD_NO='" + QTCKD + "'");
            return DbHelperOra.Exists(strSql.ToString());
        }
        /// <summary>
        /// 删除线材操作日志表
        /// </summary>
        /// <param name="dh">dh</param>
        /// <returns>返回int类型 大于0发送成功,等于0发送失败</returns>
        public int DELROLL(string dh, string id)
        {
            string sql = "";
            sql += "Delete TRC_ROLLCZ_LOG WHERE C_DH= '" + dh + "'  AND C_REMARK='" + id + "'";
            return DbHelperOra.ExecuteSql(sql);
        }


        /// <summary>
        /// 删除其他出库单子表
        /// </summary>
        /// <param name="qtckdstr">其他出库单字符串</param>
        /// <returns>返回int类型 大于0发送成功,等于0发送失败</returns>
        public int DELQTCKDITEM(string qtckdstr)
        {
            string sql = "";
            sql += "Delete TRC_ROLL_QTCKD_ITEM WHERE C_QTCKD_NO ='" + qtckdstr + "' ";
            return DbHelperOra.ExecuteSql(sql);
        }
        /// <summary>
        /// 删除其他出库单子表
        /// </summary>
        /// <param name="qtckdstr">其他出库单字符串</param>
        /// <returns>返回int类型 大于0发送成功,等于0发送失败</returns>
        public int DELQTCKD(string qtckdstr)
        {
            string sql = "";
            sql += "Delete TRC_ROLL_QTCKD WHERE C_QTCKD_NO= '" + qtckdstr + "' ";
            return DbHelperOra.ExecuteSql(sql);
        }

        /// <summary>
        /// 变更线材实绩表
        /// </summary>
        /// <param name="qtckdstr">其他出库单符串</param>
        /// <returns></returns>
        public int UPQTCKDSTATUSBY(string qtckdstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET ");
            strSql.Append("C_MOVE_TYPE='E',C_QTCKD_NO=''");
            strSql.Append("  where C_QTCKD_NO ='" + qtckdstr + "' ");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        ///根据条码其他出库单撤销数据
        /// </summary>
        /// <param name="qtckd">其他出库单</param>
        /// <returns></returns>
        public string CXQTCKDByDH(string qtckd)
        {
            try
            {
                if (CKQTCKD(qtckd) > 0)
                {
                    return "条码已回实绩";
                }
                TransactionHelper.BeginTransaction();
                if (UPQTCKDSTATUSBY(qtckd) == 0)
                {
                    TransactionHelper.RollBack();
                    return "更新线材实绩错误";
                }
                if (UPPCIQTCKDtrans(qtckd, "0") == 0)
                {
                    TransactionHelper.RollBack();
                    return "更新线材其他出库单中间表错误";
                }
                TransactionHelper.Commit();
                return "1";
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                return "代码异常";
            }

        }
        #endregion

        #region 发送其他出库单
        /// <summary>
        /// 获取最新的其他出库单号
        /// </summary>
        /// <param name="qtckdstr">出库单号</param>
        /// <returns></returns>
        public string GetQTCKNO(string qtckdstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(C_QTCKD_NO) ");
            strSql.Append(" FROM TRC_ROLL_QTCKD WHERE 1=1 ");
            if (qtckdstr.Trim() != "")
            {
                strSql.Append(" AND C_QTCKD_NO LIKE 'QC" + qtckdstr + "%' ");
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 根据物料号，仓库批号，质量等级，包装要求，数量变更线材实绩表
        /// </summary>
        /// <param name="qtckd"></param>
        /// <param name="matcode"></param>
        /// <param name="ck"></param>
        /// <param name="batch"></param>
        /// <param name="zldj"></param>
        /// <param name="bzyq"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int UPQTCKSTATUS(string qtckd, string matcode, string ck, string batch, string zldj, string bzyq, int num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_QTCKD_NO='" + qtckd + "',C_MOVE_TYPE='QC'");
            strSql.Append("  where C_MOVE_TYPE='E' AND C_MAT_CODE='" + matcode + "' AND nvl(C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP)='" + zldj + "' AND C_LINEWH_CODE='" + ck + "' AND C_BATCH_NO='" + batch + "'    AND C_BZYQ='" + bzyq + "' AND ROWNUM<='" + num + "'");
            return TransactionHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 通过其他出库单号获得其他出库单数据
        /// </summary>
        /// <param name="dhstr">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetListByQTCKdhstr(string dhstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.C_QTCKD_NO,a.C_LIC_PLA_NO,a.C_ADDRESS,a.C_CREATE_ID,a.D_CREATE_DT,a.C_TYPE,a.C_SHDW,a.D_FYSJ,a.C_ID,a.C_CYS,a.C_NCDJ,b.C_LINEWH_CODE FROM TRC_ROLL_QTCKD a LEFT JOIN TRC_ROLL_QTCKD_ITEM b ON a.c_qtckd_no=b.c_qtckd_no  WHERE a.N_STATUS = 1 ");
            if (dhstr.Trim() != "")
            {
                strSql.Append(" AND a.C_QTCKD_NO ='" + dhstr + "' ");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 向条码发送其他出库单
        /// </summary>
        /// <param name="dt">要发送的集合</param>
        /// <returns>返回int类型 大于0为转入成功,等于0发送失败</returns>
        public int ADDQTCKD(DataRow item)
        {
            string sql = "";
            sql += "insert into ReZJB_QTCKD (CKDH,CK,CPH,AimAdress,ZDR,ZDRQ,CKLX,SHDW,FYSJ,ZJBStatus,insertts,CAPPK,NCDJ,CYS) values('" + item["C_QTCKD_NO"] + "','" + item["C_LINEWH_CODE"] + "','" + item["C_LIC_PLA_NO"] + "','" + item["C_ADDRESS"] + "','" + item["C_CREATE_ID"] + "','" + item["D_CREATE_DT"] + "','" + item["C_TYPE"] + "','" + item["C_SHDW"] + "','" + item["D_FYSJ"] + "','0','" + DateTime.Now + "','" + item["C_ID"] + "','" + item["C_NCDJ"] + "','" + item["C_CYS"] + "')";

            return TransactionHelper_SQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 向条码发送其他出库单详情
        /// </summary>
        /// <param name="dt">要发送的集合</param>
        /// <returns>返回int类型 大于0为转入成功,等于0发送失败</returns>
        public int ADDQTCKDXQ(DataTable dt)
        {
            int scount = 0;
            foreach (DataRow item in dt.Rows)
            {
                string sql = "";
                sql += "insert into ReZJB_QTCKD_Item(CKDH,PCH,SX,WLH,WLMC,PH,GG,JHSL,JHZL,SLDW,ZLDW,vfree0,vfree3,ZJBStatus,insertts,CAPPK,vfree1,vfree2) values('" + item["C_QTCKD_NO"] + "','" + item["C_BATCH_NO"] + "','" + item["C_JUDGE_LEV_ZH"] + "','" + item["C_MAT_CODE"] + "','" + item["C_MAT_DESC"] + "','" + item["C_STL_GRD"] + "','" + item["C_SPEC"] + "','" + item["N_NUM"] + "','" + item["N_WGT"] + "','件【线材】','吨','" + item["C_STOVE"] + "','" + item["C_BZYQ"] + "','0','" + DateTime.Now + "','" + item["C_ID"] + "','" + item["C_ZYX1"] + "','" + item["C_ZYX2"] + "')";
                if (TransactionHelper_SQL.ExecuteSql(sql) > 0)
                {
                    scount++;
                }
                else
                {
                    return 0;
                }
            }
            return scount;
        }
        /// <summary>
        /// 通过出库单号获得出库单详情数据
        /// </summary>
        /// <param name="dh">出库单号</param>
        /// <returns></returns>
        public DataSet GetListByQTCKdhXQ(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QTCKD_NO,C_MAT_CODE,C_MAT_DESC,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS ");
            strSql.Append(" FROM TRC_ROLL_QTCKD_ITEM WHERE N_STATUS=1");

            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_QTCKD_NO ='" + dh + "' ");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 向条码发送其他出库信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="qtckd"></param>
        /// <param name="cph"></param>
        /// <param name="address"></param>
        /// <param name="zdrid"></param>
        /// <param name="zdrcode"></param>
        /// <param name="cklx"></param>
        /// <param name="shdw"></param>
        /// <param name="fysj"></param>
        /// <param name="cys"></param>
        /// <param name="mbckid"></param>
        /// <param name="mbckmc"></param>
        /// <param name="ck"></param>
        /// <returns></returns>
        public string SENDQTCKD1(List<CommonKC> list, string qtckd, string cph, string address, string zdrid, string zdrcode, string cklx, string shdw, DateTime fysj, string cys, string mbckid)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.SENDQTCKD";
            DataTable dt = null;
            try
            {
                string mbckmcsql = "select C_LINEWH_NAME FROM TPB_LINEWH";
                var obj = DbHelperOra.GetSingle(mbckmcsql);
                if (obj == null)
                {
                    return "目标仓库不存在！";
                }
                else
                {
                    mbckmcsql = obj.ToString();
                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO TRC_ROLL_QTCKD(C_QTCKD_NO,C_ADDRESS,C_LIC_PLA_NO,C_CREATE_ID,D_CREATE_DT,N_STATUS,C_TYPE,C_SHDW,D_FYSJ,C_NCDJ,C_CYS,C_MBWH_ID,C_MBWH_NAME,C_CREATE_CODE,C_LINEWH_CODE) VALUES('" + qtckd + "','" + address + "','" + cph + "','" + zdrid + "',to_date('" + DateTime.Now + "','yyyy-mm-dd hh24:mi:ss'),1,'" + cklx + "','" + shdw + "',to_date('" + fysj + "','yyyy-mm-dd hh24:mi:ss'),'" + qtckd + "','" + cys + "','" + mbckid + "','" + mbckmcsql + "','" + zdrcode + "','" + list[0].ck + "') ");
                TransactionHelper.BeginTransaction();//开启事务ora
                TransactionHelper_SQL.BeginTransaction();//开启事务sql
                if (TransactionHelper.ExecuteSql(strSql.ToString()) == 0)//生成其他出库单
                {
                    TransactionHelper.RollBack();
                    return "生成其他出库单错误！";
                }
                foreach (CommonKC item in list)
                {
                    if (UPQTCKSTATUS(qtckd, item.mat, item.ck, item.batch, item.zldj, item.bzyq, item.num) != item.num)
                    {
                        TransactionHelper.RollBack();
                        return "变更库存状态错误！";
                    }
                }
                DataTable qtckdt = GetXCKC(qtckd, "QC", "").Tables[0];
                if (qtckdt.Rows.Count != list.Count)
                {
                    TransactionHelper.RollBack();
                    return "查询出库详情错误！";
                }
                foreach (DataRow qtrow in qtckdt.Rows)
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.Append("INSERT INTO TRC_ROLL_QTCKD_ITEM(C_QTCKD_NO,C_BATCH_NO,C_JUDGE_LEV_ZH,C_MAT_CODE,C_MAT_DESC,C_STL_GRD,C_SPEC,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_STOVE,C_BZYQ,N_STATUS,C_LINEWH_CODE,C_ZYX1,C_ZYX2,C_STD_CODE) VALUES('" + qtrow["C_QTCKD_NO"] + "','" + qtrow["C_BATCH_NO"] + "','" + qtrow["C_JUDGE_LEV_ZH"] + "','" + qtrow["C_MAT_CODE"] + "','" + qtrow["C_MAT_DESC"] + "','" + qtrow["C_STL_GRD"] + "','" + qtrow["C_SPEC"] + "','" + qtrow["N_NUM"] + "','" + qtrow["N_WGT"] + "','件【线材】','吨','" + qtrow["C_STOVE"] + "','" + qtrow["C_BZYQ"] + "',1,'" + qtrow["C_LINEWH_CODE"] + "','" + qtrow["C_ZYX1"] + "','" + qtrow["C_ZYX2"] + "','" + qtrow["C_STD_CODE"] + "') ");
                    if (TransactionHelper.ExecuteSql(strSql1.ToString()) == 0)//生成其他出库单详情
                    {
                        TransactionHelper.RollBack();
                        return "生成其他出库单详情错误！";
                    }
                }

                dt = GetListByQTCKdhstr(qtckd).Tables[0];//要传输的其他出库单数据
                if (dt.Rows.Count == 0)
                {
                    TransactionHelper.RollBack();
                    return "查询要传输的转库单数据错误！";
                }

                if (ADDQTCKD(dt.Rows[0]) != 1)//发送出库单
                {
                    TransactionHelper.RollBack();
                    TransactionHelper_SQL.RollBack();
                    return "上传条码其他出库单中间表错误！";
                }
                dt = GetListByQTCKdhXQ(qtckd).Tables[0]; //要传输的其他出库单详情数据
                if (dt.Rows.Count != list.Count)
                {
                    TransactionHelper.RollBack();
                    TransactionHelper_SQL.RollBack();
                    return "查询要传输的转库单详情数据错误！";
                }
                if (ADDQTCKDXQ(dt) != dt.Rows.Count)//发送出库单
                {
                    TransactionHelper.RollBack();
                    TransactionHelper_SQL.RollBack();
                    return "上传条码其他出库单详情中间表错误！";
                }
                TransactionHelper.Commit();
                TransactionHelper_SQL.Commit();
                return "1";
            }
            catch (Exception ex)
            {
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('向条码发送其他出库单','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                TransactionHelper.RollBack();
                TransactionHelper_SQL.RollBack();
                return "代码错误";
            }
        }
        #endregion
        #region 其他出库单同步
        /// <summary>
        /// 根据牌号获取其他出库单号
        /// </summary>
        /// <param name="Barcode">牌号</param>
        /// <returns></returns>
        public string GetQTCKDByPH(string Barcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_QTCKD_NO FROM TRC_ROLL_PRODCUT ");
            strSql.Append("  where C_BARCODE='" + Barcode + "' ");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["C_QTCKD_NO"].ToString();
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// 根据其他出库单查询条码出库详情
        /// </summary>
        /// <param name="qtckd">其他出库单</param>
        /// <returns></returns>
        public DataSet QueryQTCKDByCK(string qtckd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.FYDH CKDH, b.Barcode, b.CK, b.HW,b.CKRY FROM WMS_Bms_Inv_OutInfo b WHERE   b.FYDH = '" + qtckd + "'");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据单号变更条码其他出库单中间表数据
        /// </summary>
        /// <param name="status">要变更的状态</param>
        /// <param name="message">备注</param>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public int UPQTCKZJBSTATUS(string status, string message, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_QTCKD_finished SET");
            strSql.Append(" ZJBstatus='" + status + "',by1='" + message + "',updatets='" + DateTime.Now + "'");
            strSql.Append("  where pk_SeZJB_QTCKD_finished='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 生成修改其他出库单sql
        /// </summary>
        /// <param name="dh"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        private static StringBuilder UPQTCKD(string dh, string barcode, string mbck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET C_ZKD_NO='',C_QTCKD_NO='" + dh + "',C_LINEWH_CODE='" + mbck + "',C_LINEWH_AREA_CODE='',C_LINEWH_LOC_CODE=''");
            strSql.Append(",C_MOVE_TYPE = 'QE' ");
            strSql.Append("  where C_BARCODE='" + barcode + "' ");
            return strSql;
        }
        /// <summary>
        /// 生成修改其他出库单材料出库sql
        /// </summary>
        /// <param name="dh"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        private static StringBuilder UPQTCKDCL(string dh, string barcode, string mbck)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET C_ZKD_NO='',C_QTCKD_NO='" + dh + "',C_LINEWH_CODE='" + mbck + "',C_LINEWH_AREA_CODE='',C_LINEWH_LOC_CODE=''");
            strSql.Append(",C_MOVE_TYPE = 'S' ");
            strSql.Append("  where C_BARCODE='" + barcode + "' ");
            return strSql;
        }

        /// <summary>
        /// 根据其他出库单号获取未匹配线材
        /// </summary>
        /// <param name="qtcdh">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetWPPQTCKDH(string qtcdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_BARCODE FROM TRC_ROLL_PRODCUT ");
            strSql.Append("  where C_QTCKD_NO='" + qtcdh + "' AND C_MOVE_TYPE='QC' ");
            return TransactionHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 更新发运单表
        /// </summary>
        /// <param name="dhstr">移位单号</param>
        /// <returns></returns>
        public int UPQTCKDSJZJB(string dhstr, string status, string by1, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_QTCKD_finished SET");
            strSql.Append(" ZJBstatus='" + status + "',by1='" + by1 + "',updatets='" + DateTime.Now + "'");
            strSql.Append("  where fydh='" + dhstr + "' AND pk_SeZJB_QTCKD_finished='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新条码其他出库单实绩中间表
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int UPQTCKDBZ(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_QTCKD_finished SET");
            strSql.Append(" by1='已撤回！',updatets='" + DateTime.Now + "'");
            strSql.Append("  where   pk_SeZJB_QTCKD_finished='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据其他出库单更新线材实绩
        /// </summary>
        /// <param name="qtckd">其他出库单</param>
        /// <returns></returns>
        public int UPRPByQTCKDH(string qtckd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
            strSql.Append(" C_MOVE_TYPE='QC'");
            strSql.Append("  where C_QTCKD_NO='" + qtckd + "' ");
            return DbHelperOra.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 同步条码其他出库单信息調試
        /// </summary>
        /// <returns></returns>
        public string QTCKDTBTS(string xmlFileName)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.TBYWD";
            try
            {
                //    {

                //        string ckd = "QC1902130009";
                //        {
                //            TransactionHelper.BeginTransaction();
                //            //传送条码
                //            DataTable ckdt = QueryQTCKDByCK(ckd).Tables[0];///查询条码出库表
                //            List<string> zkdhlist = new List<string>();
                //            List<string> qtckdhlist = new List<string>();
                //            List<string> nulldhlist = new List<string>();
                //            string message = "";
                //            if (ckdt.Rows.Count > 0)
                //            {
                //                foreach (DataRow xqitem in ckdt.Rows)
                //                {
                //                    string barcode = xqitem["Barcode"].ToString();
                //                    string ckdh = GetQTCKDByPH(barcode);
                //                    if (ckdh == "0")
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }

                //                    if (ckd == ckdh)
                //                    {
                //                        StringBuilder strSql = UPQTCKD(ckd, barcode);
                //                        if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                //                        {
                //                            message = "1";
                //                            TransactionHelper.RollBack();
                //                            UPPCIQTCKD(ckd, "3");
                //                            break;
                //                        }
                //                    }
                //                    else
                //                    {
                //                        if (ckdh != "")
                //                        {
                //                            qtckdhlist.Add(ckdh);
                //                            StringBuilder strSql = UPQTCKD(ckd, barcode);
                //                            if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                //                            {
                //                                message = "1";
                //                                TransactionHelper.RollBack();
                //                                UPPCIQTCKD(ckd, "3");
                //                                break;
                //                            }
                //                        }
                //                        else
                //                        {
                //                            string zkdh = GetZKDDH(xqitem["Barcode"].ToString());
                //                            if (zkdh == "0")
                //                            {
                //                                nulldhlist.Add("");
                //                                StringBuilder strSql = UPQTCKD(ckd, barcode);
                //                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                //                                {
                //                                    message = "1";
                //                                    TransactionHelper.RollBack();
                //                                    UPPCIQTCKD(ckd, "3");
                //                                    break;
                //                                }
                //                            }
                //                            if (zkdh != "")
                //                            {
                //                                zkdhlist.Add(zkdh);
                //                                StringBuilder strSql = UPQTCKD(ckd, barcode);
                //                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                //                                {
                //                                    message = "1";
                //                                    TransactionHelper.RollBack();
                //                                    UPPCIQTCKD(ckd, "3");
                //                                    break;
                //                                }
                //                            }
                //                            else
                //                            {
                //                                nulldhlist.Add("");
                //                                StringBuilder strSql = UPQTCKD(ckd, barcode);
                //                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                //                                {
                //                                    message = "1";
                //                                    TransactionHelper.RollBack();
                //                                    UPPCIQTCKD(ckd, "3");
                //                                    break;
                //                                }
                //                            }
                //                        }

                //                    }
                //                    DataTable ydt = GetXCKC(barcode).Tables[0];//获取原线材状态
                //                    DataRow data = ydt.Rows[0];
                //                    string qy = xqitem["HW"].ToString().Substring(0, 5);
                //                    string sql = "insert into TRC_ROLLCZ_LOG(C_DH,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,D_CZ_DATE,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_REMARK,C_EMP_ID) values('" + ckd + "','" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','" + xqitem["CK"] + "','" + qy + "','" + xqitem["HW"] + "','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "', to_date('" + DateTime.Now + "', 'yyyy-mm-dd hh24:mi:ss'),'" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + barcode + "','3','6','" + xqitem["CKRY"] + "')";
                //                    if (TransactionHelper.ExecuteSql(sql.ToString()) != 1)///添加操作记录
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }
                //                }

                //                foreach (var wppitem in zkdhlist)
                //                {
                //                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                //                    if (wppdt.Rows.Count == 0)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }
                //                    if (UPRPByZKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        UPQTCKZJBSTATUS(ckd, "2", "异常:错误编码107，打牌序号" + wppdt.Rows[0]["C_BARCODE"] + "更新线材实绩状态错误");
                //                        break;
                //                    }
                //                }
                //                if (message == "1")
                //                {

                //                }
                //                foreach (var wppitem in qtckdhlist)
                //                {
                //                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                //                    if (wppdt.Rows.Count == 0)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }
                //                    if (UPRPByQTCKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }
                //                }
                //                if (message == "1")
                //                {

                //                }
                //                foreach (var wppitem in nulldhlist)
                //                {
                //                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                //                    if (wppdt.Rows.Count == 0)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }
                //                    if (UPRPByNULL(wppdt.Rows[0]["C_BARCODE"].ToString()) == 0)
                //                    {
                //                        message = "1";
                //                        TransactionHelper.RollBack();
                //                        UPPCIQTCKD(ckd, "3");
                //                        break;
                //                    }

                //                }
                //                if (message == "1")
                //                {

                //                }
                //            }
                //            else
                //            {
                //                TransactionHelper.RollBack();
                //                UPPCIQTCKD(ckd, "3");
                //            }
                //            //传送NC
                //            if (UPPCIQTCKDtrans(ckd, "2") != 1)//变更其他出库单pci中间表
                //            {
                //                TransactionHelper.RollBack();
                //            }
                //            if (UPPCIQTCKDITEM(ckd) != 1)
                //            {
                //                TransactionHelper.RollBack();
                //            }
                //            TransactionHelper.Commit();
                //        }
                //    }
                return "1";
            }
            catch (Exception ex)
            {

                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码其他出库单信息','" + ex.ToString() + "','" + name + "')";
                TransactionHelper.RollBack();
                DbHelperOra.ExecuteSql(LogSql);
                return "代码异常！";
            }
        }
        /// <summary>
        /// 同步条码其他出库单信息
        /// </summary>
        /// <returns></returns>
        public string QTCKDTB(string xmlFileName)
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.TBYWD";
            try
            {
                DataTable dt = QueryQTCKD().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string ckd = item["CKDH"].ToString();
                        string id = item["pk_SeZJB_QTCKD_finished"].ToString();
                        string mbcksql = "select t.c_Mbwh_Id from TRC_ROLL_QTCKD t WHERE C_QTCKD_NO='" + ckd + "'";
                        var obj = DbHelperOra.GetSingle(mbcksql);
                        mbcksql = obj.ToString();//获取目标仓库
                        if (item["by1"].ToString().Contains("已撤回"))
                        {
                            continue;
                        }
                        if (ExistsByQTCKD(ckd) == false)
                        {
                            UPQTCKZJBSTATUS("2", "异常:错误编码001，单号" + ckd + "PCI系统不存在！", id);
                            continue;
                        }
                        else
                        {
                            DELROLL(ckd, id);
                            TransactionHelper.BeginTransaction();
                            // 发运单号多次发送覆盖
                            if (CKQTCKD(ckd) > 1)
                            {
                                string lastid = GetLastQTCKDID(ckd, id);
                                if (lastid != "")
                                {
                                    UPRPByQTCKDH(ckd);
                                    UPQTCKDBZ(lastid);
                                }
                            }

                            //传送NC
                            string type = GetQTCKTYPE(ckd);//查询该其他出库单出库类型
                            //传送条码
                            DataTable ckdt = QueryQTCKDByCK(ckd).Tables[0];///查询条码出库表
                            List<string> zkdhlist = new List<string>();
                            List<string> qtckdhlist = new List<string>();
                            List<string> nulldhlist = new List<string>();
                            string message = "";
                            if (ckdt.Rows.Count > 0)
                            {
                                foreach (DataRow xqitem in ckdt.Rows)
                                {
                                    string barcode = xqitem["Barcode"].ToString();
                                    string ckdh = GetQTCKDByPH(barcode);
                                    if (ckdh == "0")
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "打牌序号" + barcode + "PCI系统不存在！", id);
                                        break;
                                    }

                                    if (ckd == ckdh)
                                    {
                                        StringBuilder strSql = UPQTCKD(ckd, barcode, mbcksql);
                                        if (type == "材料出库")
                                        {
                                            strSql = UPQTCKDCL(ckd, barcode, mbcksql);
                                        }
                                        if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                        {
                                            message = "1";
                                            TransactionHelper.RollBack();
                                            UPPCIQTCKD(ckd, "3");
                                            UPQTCKZJBSTATUS("2", "异常:错误编码101,打牌序号" + barcode + "更新线材实绩状态错误", id);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (ckdh != "")
                                        {
                                            qtckdhlist.Add(ckdh);
                                            StringBuilder strSql = UPQTCKD(ckd, barcode, mbcksql);
                                            if (type == "材料出库")
                                            {
                                                strSql = UPQTCKDCL(ckd, barcode, mbcksql);
                                            }
                                            if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                            {
                                                message = "1";
                                                TransactionHelper.RollBack();
                                                UPPCIQTCKD(ckd, "3");
                                                UPQTCKZJBSTATUS("2", "异常:错误编码102，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            string zkdh = GetZKDDH(xqitem["Barcode"].ToString());
                                            if (zkdh == "0")
                                            {
                                                message = "1";
                                                TransactionHelper.RollBack();
                                                UPPCIQTCKD(ckd, "3");
                                                UPQTCKZJBSTATUS("2", "打牌序号" + barcode + "PCI系统不存在！", id);
                                                break;
                                            }
                                            if (zkdh != "")
                                            {
                                                zkdhlist.Add(zkdh);
                                                StringBuilder strSql = UPQTCKD(ckd, barcode, mbcksql);
                                                if (type == "材料出库")
                                                {
                                                    strSql = UPQTCKDCL(ckd, barcode, mbcksql);
                                                }
                                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                                {
                                                    message = "1";
                                                    TransactionHelper.RollBack();
                                                    UPPCIQTCKD(ckd, "3");
                                                    UPQTCKZJBSTATUS("2", "异常:错误编码104，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                nulldhlist.Add("");
                                                StringBuilder strSql = UPQTCKD(ckd, barcode, mbcksql);
                                                if (type == "材料出库")
                                                {
                                                    strSql = UPQTCKDCL(ckd, barcode, mbcksql);
                                                }
                                                if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
                                                {
                                                    message = "1";
                                                    TransactionHelper.RollBack();
                                                    UPPCIQTCKD(ckd, "3");
                                                    UPQTCKZJBSTATUS("2", "异常:错误编码105，打牌序号" + barcode + "更新线材实绩状态错误", id);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    DataTable ydt = GetXCKC(barcode).Tables[0];//获取原线材状态
                                    DataRow data = ydt.Rows[0];
                                    string sql = "insert into TRC_ROLLCZ_LOG(C_DH,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,D_CZ_DATE,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_REMARK,C_EMP_ID,C_BZYQ) values('" + ckd + "','" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','" + mbcksql + "','','','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "', to_date('" + DateTime.Now + "', 'yyyy-mm-dd hh24:mi:ss'),'" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + barcode + "','3','" + id + "','" + xqitem["CKRY"] + "','" + data["C_BZYQ"] + "')";
                                    if (TransactionHelper.ExecuteSql(sql.ToString()) != 1)///添加操作记录
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "PCI添加操作记录时错误", id);
                                        break;
                                    }
                                }
                                if (message == "1")
                                {
                                    continue;
                                }
                                foreach (var wppitem in zkdhlist)
                                {
                                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "异常:错误编码106，单号" + ckd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByZKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS(ckd, "2", "异常:错误编码107，打牌序号" + wppdt.Rows[0]["C_BARCODE"] + "更新线材实绩状态错误");
                                        break;
                                    }
                                }
                                if (message == "1")
                                {
                                    continue;
                                }
                                foreach (var wppitem in qtckdhlist)
                                {
                                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "异常:错误编码108，单号" + ckd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByQTCKD(wppitem, wppdt.Rows[0]["C_BARCODE"].ToString()) != 1)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "异常:错误编码109，打牌序号" + wppdt.Rows[0]["C_BARCODE"] + "更新线材实绩状态错误（其他出库单）", id);
                                        break;
                                    }
                                }
                                if (message == "1")
                                {
                                    continue;
                                }
                                foreach (var wppitem in nulldhlist)
                                {
                                    DataTable wppdt = GetWPPQTCKDH(ckd).Tables[0];
                                    if (wppdt.Rows.Count == 0)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "异常:错误编码110，单号" + ckd + "未查询到数据！PCI转库单已撤回！", id);
                                        break;
                                    }
                                    if (UPRPByNULL(wppdt.Rows[0]["C_BARCODE"].ToString()) == 0)
                                    {
                                        message = "1";
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "异常:错误编码111，打牌序号" + wppdt.Rows[0]["C_BARCODE"].ToString() + "变更线材实绩错误！（库存线材）", id);
                                        break;
                                    }
                                }
                                if (message == "1")
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                TransactionHelper.RollBack();
                                UPPCIQTCKD(ckd, "3");
                                UPQTCKZJBSTATUS("3", "条码空点完成！", id);
                                continue;
                            }
                            if (UPPCIQTCKDtrans(ckd, "2") != 1)//变更其他出库单pci中间表
                            {
                                TransactionHelper.RollBack();
                                UPQTCKZJBSTATUS("2", "变更其他出库单pci中间表错误", id);
                                continue;
                            }
                            if (UPPCIQTCKDITEM(ckd, type) != 1)
                            {
                                TransactionHelper.RollBack();
                                UPQTCKZJBSTATUS("2", "变更其他出库单详情pci中间表错误", id);
                                continue;
                            }
                            UPRPBySJSL(ckd);
                            //传送NC

                            if (type != "材料出库")
                            {
                                string msg = dal_Interface_NC_Roll_QT4I.SendXml_GP(xmlFileName, ckd);
                                if (msg != "1")//发送其他出库单实绩到NC(4I)
                                {
                                    if (msg.Contains("存在") == false)
                                    {
                                        TransactionHelper.RollBack();
                                        UPPCIQTCKD(ckd, "3");
                                        UPQTCKZJBSTATUS("2", "4I" + msg, id);
                                        continue;
                                    }
                                }
                                msg = dal_Interface_NC_Roll_QT4A.SendXml_GP(xmlFileName, ckd);
                                if (msg != "1")//发送其他出库单实绩到NC(4A)
                                {
                                    TransactionHelper.RollBack();
                                    UPPCIQTCKD(ckd, "3");
                                    UPQTCKZJBSTATUS("2", "4A" + msg, id);
                                    continue;
                                }
                            }
                            TransactionHelper.Commit();
                            UPQTCKZJBSTATUS("1", "", id);
                        }
                    }
                    return "1";
                }
                else
                {
                    return "条码不存在未上传的其他出库单信息！";
                }
            }
            catch (Exception ex)
            {

                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码其他出库单信息','" + ex.ToString() + "','" + name + "')";
                TransactionHelper.RollBack();
                DbHelperOra.ExecuteSql(LogSql);
                return "代码异常！";
            }
        }
        /// <summary>
        /// 通过出库单号获得出库单详情数据
        /// </summary>
        /// <param name="dh">出库单号</param>
        /// <returns></returns>
        public DataSet GetQTCKXQByDH(string dh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QTCKD_NO,C_MAT_CODE,C_MAT_DESC,C_STL_GRD,C_JUDGE_LEV_ZH,N_NUM,N_WGT,C_Z_DW,C_F_DW,C_BATCH_NO,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,C_ZYX4,N_STATUS ");
            strSql.Append(" FROM TRC_ROLL_QTCKD_ITEM WHERE N_STATUS=1");

            if (dh.Trim() != "")
            {
                strSql.Append(" AND C_QTCKD_NO ='" + dh + "' ");
            }
            return TransactionHelper.Query(strSql.ToString());
        }
        #endregion
        #endregion
        #region 移位单
        /// <summary>
        /// 获取移位单数据
        /// </summary>
        /// <param name="C_YWDH">其他出库单号</param>
        /// <returns></returns>
        public DataSet GetTMYWD(string C_YWDH, DateTime dt1, DateTime dt2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pk_SeZJB_Shift_Record,ywdh,barcode,case ZJBstatus when '0' then '未同步' when '1' then '同步成功'when '2' then '同步异常'end ZJBstatus ,by1,insertts,updatets ");
            strSql.Append(" FROM SeZJB_Shift_Record WHERE 1=1");
            if (C_YWDH.Trim() != "")
            {
                strSql.Append(" AND ywdh LIKE'%" + C_YWDH + "%' ");
            }
            strSql.Append(" AND insertts >='" + dt1 + "' AND insertts<='" + dt2 + "'");
            strSql.Append(" ORDER BY  ywdh desc");
            return TransactionHelper_SQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过条码移位单中间表查询所有未同步的移位单号
        /// </summary>
        /// <returns></returns>
        public DataSet GetYWD()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT barcode,ywdh,pk_SeZJB_Shift_Record FROM SeZJB_Shift_Record WHERE ZJBstatus!=1");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 通过库存表查询条码移库库位
        /// </summary>
        /// <param name="dh"></param>
        /// <returns></returns>
        public DataSet QueryTMYKKWByKC(string dh, string barcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.YWDH, a.Barcode, b.CK, b.HW,c.CZRQ,c.CZRY FROM WMS_Bms_Shi_YWD_item a, WMS_Bms_Inv_Info b ,WMS_Bms_Shi_YWD c  WHERE a.Barcode = b.Barcode and a.ywdh=c.ywdh and a.ywdh='" + dh + "' AND a.barcode='" + barcode + "'");

            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 更新移位单表
        /// </summary>
        /// <param name="dhstr">移位单号</param>
        /// <returns></returns>
        public int UPYWDSTATUS(string status, string by1, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SeZJB_Shift_Record SET");
            strSql.Append(" ZJBstatus='" + status + "',by1='" + by1 + "',updatets='" + DateTime.Now + "'");
            strSql.Append("  where pk_SeZJB_Shift_Record='" + id + "'  ");
            return DbHelper_SQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 同步条码移位单信息
        /// </summary>
        /// <returns></returns>
        public string TBYWD()
        {
            string LogSql = "";
            string name = "Dal_Interface_FR.TBYWD";

            try
            {
                DataTable dhdt = GetYWD().Tables[0];
                if (dhdt.Rows.Count == 0)
                {
                    return "没有要同步的单号!";
                }
                foreach (DataRow dhrow in dhdt.Rows)
                {
                    string id = dhrow["pk_SeZJB_Shift_Record"].ToString();
                    string ywd = dhrow["ywdh"].ToString();
                    string barcode = dhrow["barcode"].ToString();
                    //string id = "7155";
                    //string ywd = "YW201902266111701511001";
                    //string barcode = "3419015890505";
                    DataTable dt = QueryTMYKKWByKC(ywd, barcode).Tables[0];//获取移位详情
                    string message = "";
                    if (dt.Rows.Count == 0)
                    {
                        message = "该移位单未查询到移位实绩！";
                        continue;
                    }
                    TransactionHelper.BeginTransaction();//开启
                    foreach (DataRow item in dt.Rows)
                    {

                        DataTable ydt = GetXCKC(item["Barcode"].ToString()).Tables[0];//获取原线材状态
                        if (ydt.Rows.Count != 1)
                        {
                            TransactionHelper.RollBack();
                            message = "牌号" + item["Barcode"].ToString() + "PCI系统不存在！";
                            UPYWDSTATUS("2", message, id);
                            break;
                        }
                        DataRow data = ydt.Rows[0];
                        if (data["C_MOVE_TYPE"].ToString() != "E")
                        {
                            message = "牌号" + item["Barcode"].ToString() + "PCI系统状态为" + data["C_MOVE_TYPE"].ToString() + "！";
                            TransactionHelper.RollBack();
                            UPYWDSTATUS("2", message, id);
                            break;
                        }
                        string qy = item["HW"].ToString().Substring(0, 5);
                        string sql = "insert into TRC_ROLLCZ_LOG(C_DH,C_REMARK,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,D_CZ_DATE,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_EMP_ID) values('" + ywd + "','" + id + "','" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','" + item["CK"] + "','" + qy + "','" + item["HW"] + "','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "', to_date('" + item["CZRQ"] + "', 'yyyy-mm-dd hh24:mi:ss'),'" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + item["Barcode"] + "','2','" + item["CZRY"] + "')";
                        if (TransactionHelper.ExecuteSql(sql.ToString()) != 1)///添加操作记录
                        {
                            message = "PCI添加操作日志时错误！";
                            TransactionHelper.RollBack();
                            UPYWDSTATUS("2", message, id);
                            break;
                        }
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("UPDATE TRC_ROLL_PRODCUT SET");
                        strSql.Append(" C_MOVE_TYPE = 'E',C_LINEWH_CODE='" + item["CK"] + "',C_LINEWH_AREA_CODE='" + qy + "',C_LINEWH_LOC_CODE='" + item["HW"] + "' ");
                        strSql.Append("  where C_BARCODE='" + item["Barcode"] + "' ");
                        if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)//变更线材实绩
                        {
                            message = "更新实绩时错误！";
                            TransactionHelper.RollBack();
                            UPYWDSTATUS("2", message, id);
                            break;
                        }
                    }
                    if (message == "")
                    {
                        UPYWDSTATUS("1", "", id);
                        TransactionHelper.Commit();
                    }
                }
                return "1";
            }
            catch (Exception ex)
            {
                LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG, C_NAME) VALUES('同步条码移位单信息','" + ex.ToString() + "','" + name + "')";
                DbHelperOra.ExecuteSql(LogSql);
                TransactionHelper.RollBack();
                return ex.ToString();
            }
        }
        #endregion
        #region 检查中间表
        /// <summary>
        /// 通过转库单号查询条码中间实绩中间表上一个数据id
        /// </summary>
        /// <param name="fyd">发运单</param>
        /// <returns></returns>
        public string GetLastFYDID(string fyd, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(pk_SeZJB_FYD_finished) FROM SeZJB_FYD_finished  WHERE fydh='" + fyd + "' AND pk_SeZJB_FYD_finished<'" + id + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 通过其他出库单查询条码中间实绩中间表上一个数据id
        /// </summary>
        /// <param name="qtckd">转库单号</param>
        /// <returns></returns>
        public string GetLastQTCKDID(string qtckd, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(pk_SeZJB_QTCKD_finished) FROM SeZJB_QTCKD_finished  WHERE ckdh='" + qtckd + "' AND pk_SeZJB_QTCKD_finished<'" + id + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 通过移位单号，id查询条码中间实绩中间表上一个数据id
        /// </summary>
        /// <param name="ywdh">移位单号</param>
        /// <returns></returns>
        public string GetLastYWDID(string ywdh, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(pk_SeZJB_Shift_Record) FROM SeZJB_Shift_Record  WHERE ywdh='" + ywdh + "' AND pk_SeZJB_Shift_Record<'" + id + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 通过转库单号查询条码中间实绩中间表上一个数据id
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public string GetLastZKDID(string zkdh, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(pk_SeZJB_ZKD_finishes) FROM SeZJB_ZKD_finished  WHERE zkdh='" + zkdh + "' AND pk_SeZJB_ZKD_finishes<'" + id + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 通过转库单号查询条码中间实绩中间表数量
        /// </summary>
        /// <param name="zkdh">转库单号</param>
        /// <returns></returns>
        public int CKZKD(string zkdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM SeZJB_ZKD_finished  WHERE zkdh='" + zkdh + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
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
        /// 根据移位单号查询条码实绩中间表数量
        /// </summary>
        /// <returns>DataSet</returns>
        public int CKYWD(string ywdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM SeZJB_Shift_Record  WHERE ywdh='" + ywdh + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
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
        /// 根据其他出库单号查询条码实绩中间表数量
        /// </summary>
        /// <param name="ckdh">其他出库单</param>
        /// <returns></returns>
        public int CKQTCKD(string ckdh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Count(1) FROM SeZJB_QTCKD_finished ");
            strSql.Append("  where ckdh='" + ckdh + "' AND zjbstatus!=3 ");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj); ;
            }
        }
        /// <summary>
        /// 通过发运单号查询条码实绩中间表数量
        /// </summary>
        /// <returns>DataSet</returns>
        public int CKFYD(string fydh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM SeZJB_FYD_finished  WHERE fydh='" + fydh + "'");
            var obj = DbHelper_SQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion
        #region 查询条码中间表id

        #endregion
        /// <summary>
        /// 添加操作记录
        /// </summary>
        /// <param name="msg"></param>
        public void AddLog(string msg)
        {
            string LogSql = "INSERT INTO TI_RF_LOG(C_TYPE, C_LOG) VALUES('自动同步','" + msg + "')";
            DbHelperOra.ExecuteSql(LogSql);
        }
        /// <summary>
        /// 获取条码发运单备注
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public DataSet GetTMFYDBZ(string fydh, string ck, string ph, string gg)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   fydh, ck, khbm, yslb, cph, wlh, wlmc, sx, zldj, jhsl, jhzl, zjldw, fjldw, varrivestation, zdr, zdrq, PH, GG, PCInfo, zyx1, zyx2, zyx3, zyx4, zyx5, pk_ZJB_FYD, ZJBstatus, CAPPK, ywbm, ywry, insertts, updatets, beizhu FROM      ReZJB_FYD ");
            strSql.Append("  WHERE ZJBSTATUS=2");
            if (fydh.Trim() != "")
            {
                strSql.Append(" AND fydh LIKE'%" + fydh + "%' ");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" AND ck LIKE'%" + ck + "%' ");
            }
            if (ph.Trim() != "")
            {
                strSql.Append(" AND ph LIKE'%" + ph + "%' ");
            }
            if (gg.Trim() != "")
            {
                strSql.Append(" AND gg LIKE'%" + gg + "%' ");
            }
            strSql.Append(" ORDER BY  fydh desc ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据批号获取条码库存
        /// </summary>
        /// <param name="pch">批号</param>
        /// <returns></returns>
        public DataSet GetRFKCbyPH(string pch, string gh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Barcode, WGDH, CK, HW, PCH, WLH, WLMC, SX, ZLDJ, PH, GG, BB, GH, ZL, BZ, RQ, RKType, RKRY,WeightRQ, CKCXH, ProduceData, PCInfo, Filed1, ErrSeason, Filed2, vfree0, vfree1, vfree2, vfree3, vfree4 FROM  WMS_Bms_Inv_Info ");
            strSql.Append("  WHERE 1=1");
            if (pch.Trim() != "")
            {
                strSql.Append(" AND PCH ='" + pch + "' ");
            }
            if (gh.Trim() != "")
            {
                strSql.Append(" AND gh ='" + gh + "' ");
            }
            strSql.Append(" ORDER BY  PCH,GH ");
            return DbHelper_SQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据批号获取条码库存
        /// </summary>
        /// <param name="barcode">单卷号</param>
        /// <param name="ck">仓库</param>
        /// <param name="hw">货位</param>
        /// <param name="zl">重量</param>
        /// <param name="czry">czry</param>
        /// <returns></returns>
        public int UPRoll(string barcode, string ck, string hw, string zl, string czry)
        {
            string qy = hw.Substring(0, 5);
            string sql = "select * from trc_roll_prodcut where C_BARCODE='" + barcode + "'";
            DataTable dt = DbHelperOra.Query(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            DataRow data = dt.Rows[0];
            string addsql = "insert into TRC_ROLLCZ_LOG(C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_ZH,C_MAT_CODE,C_MAT_DESC,C_BARCODE,N_TYPE,C_EMP_ID) values('" + data["C_STOVE"] + "','" + data["C_BATCH_NO"] + "','" + data["C_TICK_NO"] + "','" + data["C_STL_GRD"] + "','" + data["N_WGT"] + "','" + data["C_STD_CODE"] + "','" + data["C_SPEC"] + "','" + ck + "','" + qy + "','" + hw + "','" + data["C_LINEWH_CODE"] + "','" + data["C_LINEWH_AREA_CODE"] + "','" + data["C_LINEWH_LOC_CODE"] + "','" + data["C_JUDGE_LEV_ZH"] + "','" + data["C_MAT_CODE"] + "','" + data["C_MAT_DESC"] + "','" + barcode + "','4','" + czry + "')";
            TransactionHelper.BeginTransaction();
            if (TransactionHelper.ExecuteSql(addsql.ToString()) != 1)///添加操作记录
            {
                TransactionHelper.RollBack();
                return 2;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update trc_roll_prodcut set  C_FYDH='',C_FRFLAG='',C_MOVE_TYPE='E',C_LINEWH_CODE='" + ck + "',C_LINEWH_AREA_CODE='" + qy + "',C_LINEWH_LOC_CODE='" + hw + "',N_WGT='" + zl + "'  where C_BARCODE='" + barcode + "'");
            if (TransactionHelper.ExecuteSql(strSql.ToString()) != 1)
            {
                TransactionHelper.RollBack();
                return 3;
            }
            TransactionHelper.Commit();
            return 1;
        }
        /// <summary>
        /// 根据批号获取线材实绩日志
        /// </summary>
        /// <param name="pch">批号</param>
        /// <param name="dt1">操作开始时间</param>
        /// <param name="dt2">操作结束时间</param>
        /// <param name="gh">钩号</param>
        /// <returns></returns>
        public DataSet GetLog(string pch, string dt1, string dt2, string gh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select D_MOD_DT,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,N_WGT,C_STD_CODE,C_SPEC,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_YLINEWH_CODE,C_YLINEWH_AREA_CODE,C_YLINEWH_LOC_CODE,C_JUDGE_LEV_BP,C_JUDGE_LEV_ZH,C_MAT_CODE,C_MAT_DESC,C_BARCODE,C_EMP_ID,D_CZ_DATE");
            strSql.Append(" FROM TRC_ROLLCZ_LOG WHERE N_TYPE=4");
            if (pch.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + pch + "' ");
            }
            if (gh.Trim() != "")
            {
                strSql.Append(" AND C_TICK_NO='" + gh + "' ");
            }
            if (dt1.Trim() != "")
            {
                strSql.Append(" AND D_MOD_DT>to_date('" + dt1 + "','yyyy-mm-dd') ");
            }
            if (dt2.Trim() != "")
            {
                strSql.Append(" AND D_MOD_DT<to_date('" + dt2 + "','yyyy-mm-dd') ");
            }
            strSql.Append(" ORDER BY D_MOD_DT desc,C_BATCH_NO ");
            return DbHelperOra.Query(strSql.ToString());
        }
    }
}
