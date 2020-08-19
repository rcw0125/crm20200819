using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL.R;
using NF.DAL;

namespace NF.DAL.R
{
    /// <summary>
    /// 数据访问类:TRC_ROLL_PRODCUT
    /// </summary>
    public partial class Dal_TRC_ROLL_PRODCUT
    {
        public Dal_TRC_ROLL_PRODCUT()
        { }
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PH, string GH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_PRODCUT ");
            strSql.Append(" where C_BATCH_NO='" + PH + "' and  C_TICK_NO ='" + GH + "'");
            return DbHelperOra.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_PRODCUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_PRODCUT(");
            strSql.Append(" C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID,C_REASON_NAME,C_IS_PD)");
            strSql.Append(" values (");
            strSql.Append(":C_EMP_ID,:D_MOD_DT,:C_TRC_ROLL_MAIN_ID,:C_STOVE,:C_BATCH_NO,:C_TICK_NO,:C_STL_GRD,:C_STL_GRD_BEFORE,:N_WGT,:C_STD_CODE,:C_STD_CODE_BEFORE,:C_MOVE_TYPE,:C_SPEC,:C_SHIFT,:C_GROUP,:C_STA_ID,:C_JUDGE_LEV_BP,:C_DP_SHIFT,:C_DP_GROUP,:C_DP_EMP_ID,:D_DP_DT,:C_PLANT_ID,:C_PLANT_DESC,:C_MAT_CODE,:C_MAT_CODE_BEFORE,:C_MAT_DESC,:C_MAT_DESC_BEFORE,:C_IS_DEPOT,:C_PLAN_ID,:C_ORDER_NO,:C_CON_NO,:C_CUST_NO,:C_CUST_NAME,:C_ISFREE,:C_LINEWH_CODE,:C_LINEWH_AREA_CODE,:C_LINEWH_LOC_CODE,:C_FLOOR,:C_CUST_AREA,:C_SALE_AREA,:C_JUDGE_LEV_CF,:C_JUDGE_LEV_XN,:C_JUDGE_LEV_XN_RE,:C_JUDGE_LEV_ZH_PEOPLE,:D_JUDGE_DATE,:C_IS_QR,:C_QR_USER,:D_QR_DATE,:C_DESIGN_NO,:C_JUDGE_LEV_ZH,:C_IS_TB,:C_SCUTCHEON,:C_GP_TYPE,:C_BARCODE,:C_RKDH,:C_FYDH,:C_CKDH,:C_MOVE_DESC,:C_CKRY,:D_CKRQ,:C_RKRY,:D_RKRQ,:C_BZYQ,:D_WEIGHT_DT,:D_PRODUCE_DATE,:C_ZYX1,:C_ZYX2,:C_MASTER_ID,:C_GP_BEFORE_ID,:C_GP_AFTER_ID,C_REASON_NAME,C_IS_PD)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_TRC_ROLL_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DP_DT", OracleDbType.Date),
                    new OracleParameter(":C_PLANT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_AREA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_LOC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_CF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN_RE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH_PEOPLE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_JUDGE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_IS_QR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QR_USER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_QR_DATE", OracleDbType.Date),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_TB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SCUTCHEON", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BARCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CKRQ", OracleDbType.Date),
                    new OracleParameter(":C_RKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_RKRQ", OracleDbType.Date),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_WEIGHT_DT", OracleDbType.Date),
                    new OracleParameter(":D_PRODUCE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MASTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_BEFORE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_AFTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REASON_NAME", OracleDbType.Varchar2,100),
                     new OracleParameter(":C_IS_PD", OracleDbType.Varchar2,10)
            };
            parameters[0].Value = model.C_EMP_ID;
            parameters[1].Value = model.D_MOD_DT;
            parameters[2].Value = model.C_TRC_ROLL_MAIN_ID;
            parameters[3].Value = model.C_STOVE;
            parameters[4].Value = model.C_BATCH_NO;
            parameters[5].Value = model.C_TICK_NO;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_STL_GRD_BEFORE;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.C_STD_CODE;
            parameters[10].Value = model.C_STD_CODE_BEFORE;
            parameters[11].Value = model.C_MOVE_TYPE;
            parameters[12].Value = model.C_SPEC;
            parameters[13].Value = model.C_SHIFT;
            parameters[14].Value = model.C_GROUP;
            parameters[15].Value = model.C_STA_ID;
            parameters[16].Value = model.C_JUDGE_LEV_BP;
            parameters[17].Value = model.C_DP_SHIFT;
            parameters[18].Value = model.C_DP_GROUP;
            parameters[19].Value = model.C_DP_EMP_ID;
            parameters[20].Value = model.D_DP_DT;
            parameters[21].Value = model.C_PLANT_ID;
            parameters[22].Value = model.C_PLANT_DESC;
            parameters[23].Value = model.C_MAT_CODE;
            parameters[24].Value = model.C_MAT_CODE_BEFORE;
            parameters[25].Value = model.C_MAT_DESC;
            parameters[26].Value = model.C_MAT_DESC_BEFORE;
            parameters[27].Value = model.C_IS_DEPOT;
            parameters[28].Value = model.C_PLAN_ID;
            parameters[29].Value = model.C_ORDER_NO;
            parameters[30].Value = model.C_CON_NO;
            parameters[31].Value = model.C_CUST_NO;
            parameters[32].Value = model.C_CUST_NAME;
            parameters[33].Value = model.C_ISFREE;
            parameters[34].Value = model.C_LINEWH_CODE;
            parameters[35].Value = model.C_LINEWH_AREA_CODE;
            parameters[36].Value = model.C_LINEWH_LOC_CODE;
            parameters[37].Value = model.C_FLOOR;
            parameters[38].Value = model.C_CUST_AREA;
            parameters[39].Value = model.C_SALE_AREA;
            parameters[40].Value = model.C_JUDGE_LEV_CF;
            parameters[41].Value = model.C_JUDGE_LEV_XN;
            parameters[42].Value = model.C_JUDGE_LEV_XN_RE;
            parameters[43].Value = model.C_JUDGE_LEV_ZH_PEOPLE;
            parameters[44].Value = model.D_JUDGE_DATE;
            parameters[45].Value = model.C_IS_QR;
            parameters[46].Value = model.C_QR_USER;
            parameters[47].Value = model.D_QR_DATE;
            parameters[48].Value = model.C_DESIGN_NO;
            parameters[49].Value = model.C_JUDGE_LEV_ZH;
            parameters[50].Value = model.C_IS_TB;
            parameters[51].Value = model.C_SCUTCHEON;
            parameters[52].Value = model.C_GP_TYPE;
            parameters[53].Value = model.C_BARCODE;
            parameters[54].Value = model.C_RKDH;
            parameters[55].Value = model.C_FYDH;
            parameters[56].Value = model.C_CKDH;
            parameters[57].Value = model.C_MOVE_DESC;
            parameters[58].Value = model.C_CKRY;
            parameters[59].Value = model.D_CKRQ;
            parameters[60].Value = model.C_RKRY;
            parameters[61].Value = model.D_RKRQ;
            parameters[62].Value = model.C_BZYQ;
            parameters[63].Value = model.D_WEIGHT_DT;
            parameters[64].Value = model.D_PRODUCE_DATE;
            parameters[65].Value = model.C_ZYX1;
            parameters[66].Value = model.C_ZYX2;
            parameters[67].Value = model.C_MASTER_ID;
            parameters[68].Value = model.C_GP_BEFORE_ID;
            parameters[69].Value = model.C_GP_AFTER_ID;
            parameters[70].Value = model.C_REASON_NAME;
            parameters[71].Value = model.C_IS_PD;
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
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
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
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_JUDGE_LEV_BP=:C_JUDGE_LEV_BP,");
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
            strSql.Append("C_SALE_AREA=:C_SALE_AREA,");
            strSql.Append("C_JUDGE_LEV_CF=:C_JUDGE_LEV_CF,");
            strSql.Append("C_JUDGE_LEV_XN=:C_JUDGE_LEV_XN,");
            strSql.Append("C_JUDGE_LEV_XN_RE=:C_JUDGE_LEV_XN_RE,");
            strSql.Append("C_JUDGE_LEV_ZH_PEOPLE=:C_JUDGE_LEV_ZH_PEOPLE,");
            strSql.Append("D_JUDGE_DATE=:D_JUDGE_DATE,");
            strSql.Append("C_IS_QR=:C_IS_QR,");
            strSql.Append("C_QR_USER=:C_QR_USER,");
            strSql.Append("D_QR_DATE=:D_QR_DATE,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("C_JUDGE_LEV_ZH=:C_JUDGE_LEV_ZH,");
            strSql.Append("C_IS_TB=:C_IS_TB,");
            strSql.Append("C_SCUTCHEON=:C_SCUTCHEON,");
            strSql.Append("C_GP_TYPE=:C_GP_TYPE,");
            strSql.Append("C_BARCODE=:C_BARCODE,");
            strSql.Append("C_RKDH=:C_RKDH,");
            strSql.Append("C_FYDH=:C_FYDH,");
            strSql.Append("C_CKDH=:C_CKDH,");
            strSql.Append("C_MOVE_DESC=:C_MOVE_DESC,");
            strSql.Append("C_CKRY=:C_CKRY,");
            strSql.Append("D_CKRQ=:D_CKRQ,");
            strSql.Append("C_RKRY=:C_RKRY,");
            strSql.Append("D_RKRQ=:D_RKRQ,");
            strSql.Append("C_BZYQ=:C_BZYQ,");
            strSql.Append("D_WEIGHT_DT=:D_WEIGHT_DT,");
            strSql.Append("D_PRODUCE_DATE=:D_PRODUCE_DATE,");
            strSql.Append("C_ZYX1=:C_ZYX1,");
            strSql.Append("C_ZYX2=:C_ZYX2,");
            strSql.Append("C_MASTER_ID=:C_MASTER_ID,");
            strSql.Append("C_GP_BEFORE_ID=:C_GP_BEFORE_ID,");
            strSql.Append("C_GP_AFTER_ID=:C_GP_AFTER_ID,");
            strSql.Append("C_REASON_NAME=:C_REASON_NAME,");
            strSql.Append("C_IS_PD=:C_IS_PD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_TRC_ROLL_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DP_DT", OracleDbType.Date),
                    new OracleParameter(":C_PLANT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_AREA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_LOC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_CF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN_RE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH_PEOPLE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_JUDGE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_IS_QR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QR_USER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_QR_DATE", OracleDbType.Date),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_TB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SCUTCHEON", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BARCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CKRQ", OracleDbType.Date),
                    new OracleParameter(":C_RKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_RKRQ", OracleDbType.Date),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_WEIGHT_DT", OracleDbType.Date),
                    new OracleParameter(":D_PRODUCE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MASTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_BEFORE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_AFTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REASON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_PD", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_EMP_ID;
            parameters[1].Value = model.D_MOD_DT;
            parameters[2].Value = model.C_TRC_ROLL_MAIN_ID;
            parameters[3].Value = model.C_STOVE;
            parameters[4].Value = model.C_BATCH_NO;
            parameters[5].Value = model.C_TICK_NO;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_STL_GRD_BEFORE;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.C_STD_CODE;
            parameters[10].Value = model.C_STD_CODE_BEFORE;
            parameters[11].Value = model.C_MOVE_TYPE;
            parameters[12].Value = model.C_SPEC;
            parameters[13].Value = model.C_SHIFT;
            parameters[14].Value = model.C_GROUP;
            parameters[15].Value = model.C_STA_ID;
            parameters[16].Value = model.C_JUDGE_LEV_BP;
            parameters[17].Value = model.C_DP_SHIFT;
            parameters[18].Value = model.C_DP_GROUP;
            parameters[19].Value = model.C_DP_EMP_ID;
            parameters[20].Value = model.D_DP_DT;
            parameters[21].Value = model.C_PLANT_ID;
            parameters[22].Value = model.C_PLANT_DESC;
            parameters[23].Value = model.C_MAT_CODE;
            parameters[24].Value = model.C_MAT_CODE_BEFORE;
            parameters[25].Value = model.C_MAT_DESC;
            parameters[26].Value = model.C_MAT_DESC_BEFORE;
            parameters[27].Value = model.C_IS_DEPOT;
            parameters[28].Value = model.C_PLAN_ID;
            parameters[29].Value = model.C_ORDER_NO;
            parameters[30].Value = model.C_CON_NO;
            parameters[31].Value = model.C_CUST_NO;
            parameters[32].Value = model.C_CUST_NAME;
            parameters[33].Value = model.C_ISFREE;
            parameters[34].Value = model.C_LINEWH_CODE;
            parameters[35].Value = model.C_LINEWH_AREA_CODE;
            parameters[36].Value = model.C_LINEWH_LOC_CODE;
            parameters[37].Value = model.C_FLOOR;
            parameters[38].Value = model.C_CUST_AREA;
            parameters[39].Value = model.C_SALE_AREA;
            parameters[40].Value = model.C_JUDGE_LEV_CF;
            parameters[41].Value = model.C_JUDGE_LEV_XN;
            parameters[42].Value = model.C_JUDGE_LEV_XN_RE;
            parameters[43].Value = model.C_JUDGE_LEV_ZH_PEOPLE;
            parameters[44].Value = model.D_JUDGE_DATE;
            parameters[45].Value = model.C_IS_QR;
            parameters[46].Value = model.C_QR_USER;
            parameters[47].Value = model.D_QR_DATE;
            parameters[48].Value = model.C_DESIGN_NO;
            parameters[49].Value = model.C_JUDGE_LEV_ZH;
            parameters[50].Value = model.C_IS_TB;
            parameters[51].Value = model.C_SCUTCHEON;
            parameters[52].Value = model.C_GP_TYPE;
            parameters[53].Value = model.C_BARCODE;
            parameters[54].Value = model.C_RKDH;
            parameters[55].Value = model.C_FYDH;
            parameters[56].Value = model.C_CKDH;
            parameters[57].Value = model.C_MOVE_DESC;
            parameters[58].Value = model.C_CKRY;
            parameters[59].Value = model.D_CKRQ;
            parameters[60].Value = model.C_RKRY;
            parameters[61].Value = model.D_RKRQ;
            parameters[62].Value = model.C_BZYQ;
            parameters[63].Value = model.D_WEIGHT_DT;
            parameters[64].Value = model.D_PRODUCE_DATE;
            parameters[65].Value = model.C_ZYX1;
            parameters[66].Value = model.C_ZYX2;
            parameters[67].Value = model.C_MASTER_ID;
            parameters[68].Value = model.C_GP_BEFORE_ID;
            parameters[69].Value = model.C_GP_AFTER_ID;
            parameters[70].Value = model.C_REASON_NAME;
            parameters[71].Value = model.C_IS_PD;
            parameters[72].Value = model.C_ID;

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
		public bool Update_Trans(Mod_TRC_ROLL_PRODCUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_PRODCUT set ");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
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
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_JUDGE_LEV_BP=:C_JUDGE_LEV_BP,");
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
            strSql.Append("C_SALE_AREA=:C_SALE_AREA,");
            strSql.Append("C_JUDGE_LEV_CF=:C_JUDGE_LEV_CF,");
            strSql.Append("C_JUDGE_LEV_XN=:C_JUDGE_LEV_XN,");
            strSql.Append("C_JUDGE_LEV_XN_RE=:C_JUDGE_LEV_XN_RE,");
            strSql.Append("C_JUDGE_LEV_ZH_PEOPLE=:C_JUDGE_LEV_ZH_PEOPLE,");
            strSql.Append("D_JUDGE_DATE=:D_JUDGE_DATE,");
            strSql.Append("C_IS_QR=:C_IS_QR,");
            strSql.Append("C_QR_USER=:C_QR_USER,");
            strSql.Append("D_QR_DATE=:D_QR_DATE,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("C_JUDGE_LEV_ZH=:C_JUDGE_LEV_ZH,");
            strSql.Append("C_IS_TB=:C_IS_TB,");
            strSql.Append("C_SCUTCHEON=:C_SCUTCHEON,");
            strSql.Append("C_GP_TYPE=:C_GP_TYPE,");
            strSql.Append("C_BARCODE=:C_BARCODE,");
            strSql.Append("C_RKDH=:C_RKDH,");
            strSql.Append("C_FYDH=:C_FYDH,");
            strSql.Append("C_CKDH=:C_CKDH,");
            strSql.Append("C_MOVE_DESC=:C_MOVE_DESC,");
            strSql.Append("C_CKRY=:C_CKRY,");
            strSql.Append("D_CKRQ=:D_CKRQ,");
            strSql.Append("C_RKRY=:C_RKRY,");
            strSql.Append("D_RKRQ=:D_RKRQ,");
            strSql.Append("C_BZYQ=:C_BZYQ,");
            strSql.Append("D_WEIGHT_DT=:D_WEIGHT_DT,");
            strSql.Append("D_PRODUCE_DATE=:D_PRODUCE_DATE,");
            strSql.Append("C_ZYX1=:C_ZYX1,");
            strSql.Append("C_ZYX2=:C_ZYX2,");
            strSql.Append("C_MASTER_ID=:C_MASTER_ID,");
            strSql.Append("C_GP_BEFORE_ID=:C_GP_BEFORE_ID,");
            strSql.Append("C_GP_AFTER_ID=:C_GP_AFTER_ID,");
            strSql.Append("C_REASON_NAME=:C_REASON_NAME,");
            strSql.Append("C_IS_PD=:C_IS_PD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_TRC_ROLL_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_BP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DP_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DP_DT", OracleDbType.Date),
                    new OracleParameter(":C_PLANT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_DESC_BEFORE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_AREA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_LOC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_CF", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_XN_RE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH_PEOPLE", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_JUDGE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_IS_QR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QR_USER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_QR_DATE", OracleDbType.Date),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_TB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SCUTCHEON", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BARCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MOVE_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_CKRQ", OracleDbType.Date),
                    new OracleParameter(":C_RKRY", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_RKRQ", OracleDbType.Date),
                    new OracleParameter(":C_BZYQ", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_WEIGHT_DT", OracleDbType.Date),
                    new OracleParameter(":D_PRODUCE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MASTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_BEFORE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GP_AFTER_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REASON_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_PD", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_EMP_ID;
            parameters[1].Value = model.D_MOD_DT;
            parameters[2].Value = model.C_TRC_ROLL_MAIN_ID;
            parameters[3].Value = model.C_STOVE;
            parameters[4].Value = model.C_BATCH_NO;
            parameters[5].Value = model.C_TICK_NO;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_STL_GRD_BEFORE;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.C_STD_CODE;
            parameters[10].Value = model.C_STD_CODE_BEFORE;
            parameters[11].Value = model.C_MOVE_TYPE;
            parameters[12].Value = model.C_SPEC;
            parameters[13].Value = model.C_SHIFT;
            parameters[14].Value = model.C_GROUP;
            parameters[15].Value = model.C_STA_ID;
            parameters[16].Value = model.C_JUDGE_LEV_BP;
            parameters[17].Value = model.C_DP_SHIFT;
            parameters[18].Value = model.C_DP_GROUP;
            parameters[19].Value = model.C_DP_EMP_ID;
            parameters[20].Value = model.D_DP_DT;
            parameters[21].Value = model.C_PLANT_ID;
            parameters[22].Value = model.C_PLANT_DESC;
            parameters[23].Value = model.C_MAT_CODE;
            parameters[24].Value = model.C_MAT_CODE_BEFORE;
            parameters[25].Value = model.C_MAT_DESC;
            parameters[26].Value = model.C_MAT_DESC_BEFORE;
            parameters[27].Value = model.C_IS_DEPOT;
            parameters[28].Value = model.C_PLAN_ID;
            parameters[29].Value = model.C_ORDER_NO;
            parameters[30].Value = model.C_CON_NO;
            parameters[31].Value = model.C_CUST_NO;
            parameters[32].Value = model.C_CUST_NAME;
            parameters[33].Value = model.C_ISFREE;
            parameters[34].Value = model.C_LINEWH_CODE;
            parameters[35].Value = model.C_LINEWH_AREA_CODE;
            parameters[36].Value = model.C_LINEWH_LOC_CODE;
            parameters[37].Value = model.C_FLOOR;
            parameters[38].Value = model.C_CUST_AREA;
            parameters[39].Value = model.C_SALE_AREA;
            parameters[40].Value = model.C_JUDGE_LEV_CF;
            parameters[41].Value = model.C_JUDGE_LEV_XN;
            parameters[42].Value = model.C_JUDGE_LEV_XN_RE;
            parameters[43].Value = model.C_JUDGE_LEV_ZH_PEOPLE;
            parameters[44].Value = model.D_JUDGE_DATE;
            parameters[45].Value = model.C_IS_QR;
            parameters[46].Value = model.C_QR_USER;
            parameters[47].Value = model.D_QR_DATE;
            parameters[48].Value = model.C_DESIGN_NO;
            parameters[49].Value = model.C_JUDGE_LEV_ZH;
            parameters[50].Value = model.C_IS_TB;
            parameters[51].Value = model.C_SCUTCHEON;
            parameters[52].Value = model.C_GP_TYPE;
            parameters[53].Value = model.C_BARCODE;
            parameters[54].Value = model.C_RKDH;
            parameters[55].Value = model.C_FYDH;
            parameters[56].Value = model.C_CKDH;
            parameters[57].Value = model.C_MOVE_DESC;
            parameters[58].Value = model.C_CKRY;
            parameters[59].Value = model.D_CKRQ;
            parameters[60].Value = model.C_RKRY;
            parameters[61].Value = model.D_RKRQ;
            parameters[62].Value = model.C_BZYQ;
            parameters[63].Value = model.D_WEIGHT_DT;
            parameters[64].Value = model.D_PRODUCE_DATE;
            parameters[65].Value = model.C_ZYX1;
            parameters[66].Value = model.C_ZYX2;
            parameters[67].Value = model.C_MASTER_ID;
            parameters[68].Value = model.C_GP_BEFORE_ID;
            parameters[69].Value = model.C_GP_AFTER_ID;
            parameters[70].Value = model.C_REASON_NAME;
            parameters[71].Value = model.C_IS_PD;
            parameters[72].Value = model.C_ID;

            int rows = TransactionHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update_Batch_No(string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_PRODCUT set ");
            strSql.Append(" C_IS_TB= 'N' ");
            strSql.Append(" where C_BATCH_NO= '" + C_BATCH_NO + "'");
            int rows = TransactionHelper.ExecuteSql(strSql.ToString());
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
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID,C_REASON_NAME,C_IS_PD  from TRC_ROLL_PRODCUT  ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
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
        public Mod_TRC_ROLL_PRODCUT GetModel_Iterface_Trans(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID,C_REASON_NAME,C_IS_PD  from TRC_ROLL_PRODCUT  ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_PRODCUT model = new Mod_TRC_ROLL_PRODCUT();
            DataSet ds = TransactionHelper.Query(strSql.ToString(), parameters);
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
        public Mod_TRC_ROLL_PRODCUT GetModel(string PH, string GH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID,C_REASON_NAME,C_IS_PD  from TRC_ROLL_PRODCUT ");

            strSql.Append(" where C_BATCH_NO=:PH ");
            strSql.Append(" AND C_TICK_NO=:GH ");
            OracleParameter[] parameters = {
                    new OracleParameter(":PH", OracleDbType.Varchar2,100) ,
                     new OracleParameter(":GH", OracleDbType.Varchar2,100)};
            parameters[0].Value = PH;
            parameters[1].Value = GH;

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
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
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
                if (row["C_STA_ID"] != null)
                {
                    model.C_STA_ID = row["C_STA_ID"].ToString();
                }
                if (row["C_JUDGE_LEV_BP"] != null)
                {
                    model.C_JUDGE_LEV_BP = row["C_JUDGE_LEV_BP"].ToString();
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
                if (row["C_JUDGE_LEV_CF"] != null)
                {
                    model.C_JUDGE_LEV_CF = row["C_JUDGE_LEV_CF"].ToString();
                }
                if (row["C_JUDGE_LEV_XN"] != null)
                {
                    model.C_JUDGE_LEV_XN = row["C_JUDGE_LEV_XN"].ToString();
                }
                if (row["C_JUDGE_LEV_XN_RE"] != null)
                {
                    model.C_JUDGE_LEV_XN_RE = row["C_JUDGE_LEV_XN_RE"].ToString();
                }
                if (row["C_JUDGE_LEV_ZH_PEOPLE"] != null)
                {
                    model.C_JUDGE_LEV_ZH_PEOPLE = row["C_JUDGE_LEV_ZH_PEOPLE"].ToString();
                }
                if (row["D_JUDGE_DATE"] != null && row["D_JUDGE_DATE"].ToString() != "")
                {
                    model.D_JUDGE_DATE = DateTime.Parse(row["D_JUDGE_DATE"].ToString());
                }
                if (row["C_IS_QR"] != null)
                {
                    model.C_IS_QR = row["C_IS_QR"].ToString();
                }
                if (row["C_QR_USER"] != null)
                {
                    model.C_QR_USER = row["C_QR_USER"].ToString();
                }
                if (row["D_QR_DATE"] != null && row["D_QR_DATE"].ToString() != "")
                {
                    model.D_QR_DATE = DateTime.Parse(row["D_QR_DATE"].ToString());
                }
                if (row["C_DESIGN_NO"] != null)
                {
                    model.C_DESIGN_NO = row["C_DESIGN_NO"].ToString();
                }
                if (row["C_JUDGE_LEV_ZH"] != null)
                {
                    model.C_JUDGE_LEV_ZH = row["C_JUDGE_LEV_ZH"].ToString();
                }
                if (row["C_IS_TB"] != null)
                {
                    model.C_IS_TB = row["C_IS_TB"].ToString();
                }
                if (row["C_SCUTCHEON"] != null)
                {
                    model.C_SCUTCHEON = row["C_SCUTCHEON"].ToString();
                }
                if (row["C_GP_TYPE"] != null)
                {
                    model.C_GP_TYPE = row["C_GP_TYPE"].ToString();
                }
                if (row["C_BARCODE"] != null)
                {
                    model.C_BARCODE = row["C_BARCODE"].ToString();
                }
                if (row["C_RKDH"] != null)
                {
                    model.C_RKDH = row["C_RKDH"].ToString();
                }
                if (row["C_FYDH"] != null)
                {
                    model.C_FYDH = row["C_FYDH"].ToString();
                }
                if (row["C_CKDH"] != null)
                {
                    model.C_CKDH = row["C_CKDH"].ToString();
                }
                if (row["C_MOVE_DESC"] != null)
                {
                    model.C_MOVE_DESC = row["C_MOVE_DESC"].ToString();
                }
                if (row["C_CKRY"] != null)
                {
                    model.C_CKRY = row["C_CKRY"].ToString();
                }
                if (row["D_CKRQ"] != null && row["D_CKRQ"].ToString() != "")
                {
                    model.D_CKRQ = DateTime.Parse(row["D_CKRQ"].ToString());
                }
                if (row["C_RKRY"] != null)
                {
                    model.C_RKRY = row["C_RKRY"].ToString();
                }
                if (row["D_RKRQ"] != null && row["D_RKRQ"].ToString() != "")
                {
                    model.D_RKRQ = DateTime.Parse(row["D_RKRQ"].ToString());
                }
                if (row["C_BZYQ"] != null)
                {
                    model.C_BZYQ = row["C_BZYQ"].ToString();
                }
                if (row["D_WEIGHT_DT"] != null && row["D_WEIGHT_DT"].ToString() != "")
                {
                    model.D_WEIGHT_DT = DateTime.Parse(row["D_WEIGHT_DT"].ToString());
                }
                if (row["D_PRODUCE_DATE"] != null && row["D_PRODUCE_DATE"].ToString() != "")
                {
                    model.D_PRODUCE_DATE = DateTime.Parse(row["D_PRODUCE_DATE"].ToString());
                }
                if (row["C_ZYX1"] != null)
                {
                    model.C_ZYX1 = row["C_ZYX1"].ToString();
                }
                if (row["C_ZYX2"] != null)
                {
                    model.C_ZYX2 = row["C_ZYX2"].ToString();
                }
                if (row["C_MASTER_ID"] != null)
                {
                    model.C_MASTER_ID = row["C_MASTER_ID"].ToString();
                }
                if (row["C_GP_BEFORE_ID"] != null)
                {
                    model.C_GP_BEFORE_ID = row["C_GP_BEFORE_ID"].ToString();
                }
                if (row["C_GP_AFTER_ID"] != null)
                {
                    model.C_GP_AFTER_ID = row["C_GP_AFTER_ID"].ToString();
                }
                if (row["C_REASON_NAME"] != null)
                {
                    model.C_REASON_NAME = row["C_REASON_NAME"].ToString();
                }
                if (row["C_IS_PD"] != null)
                {
                    model.C_IS_PD = row["C_IS_PD"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表-转库
        /// </summary>
        /// <param name="strWhere">批号</param>
        /// <returns></returns>
        public DataSet GetList_ZK(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='Z' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + strWhere + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-未入库
        /// </summary>
        /// <param name="strWhere">批号</param>
        /// <returns></returns>
        public DataSet GetList_WRK(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='N' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + strWhere + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-已入库
        /// </summary>
        /// <param name="strWhere">批号</param>
        /// <returns></returns>
        public DataSet GetList_RK(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2 ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='E' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + strWhere + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-已入库
        /// </summary>
        /// <param name="strWhere">批号</param>
        /// <param name="C_LINEWH_LOC_CODE">库位</param>
        /// <param name="C_LINEWH_AREA_CODE">区域</param>
        /// <param name="C_LINEWH_CODE">仓库</param>
        /// <returns></returns>
        public DataSet GetList_RK_KW(string strWhere, string C_LINEWH_LOC_CODE, string C_LINEWH_AREA_CODE, string C_LINEWH_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where  C_MOVE_TYPE ='E' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + strWhere + "%' ");
            }
            if (C_LINEWH_LOC_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_LOC_CODE ='" + C_LINEWH_LOC_CODE + "' ");
            }
            if (C_LINEWH_AREA_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_AREA_CODE ='" + C_LINEWH_AREA_CODE + "' ");
            }
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE ='" + C_LINEWH_CODE + "' ");
            }

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-零星材已入库
        /// </summary>
        /// <param name="C_LINEWH_AREA_CODE">区域</param>
        /// <param name="begin">起始库位</param>
        /// <param name="end">截止库位</param>
        /// <returns></returns>
        public DataSet GetList_LXC(string C_LINEWH_AREA_CODE, string begin, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE = 'E'  ");
            if (C_LINEWH_AREA_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_AREA_CODE = '" + C_LINEWH_AREA_CODE + "' ");
            }
            if (begin.Trim() != "" && end.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_LOC_CODE between  '" + begin + "' and '" + end + "'  ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-已入库-13库到21库
        /// </summary>        
        /// <returns></returns>
        public DataSet GetList_RK_KW_13_21()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE = 'E' and C_LINEWH_LOC_CODE between  6030112 and 6030121  ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">批号</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='E' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + strWhere + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_BATCH_NO">批号</param>
        /// <returns></returns>
        public DataSet GetList_Batch(string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select t.C_ID,t.C_BATCH_NO,T.C_STD_CODE,T.C_STL_GRD,T.C_TICK_NO,T.C_SPEC  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT t where  1=1 ");
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" and T.C_BATCH_NO = '" + C_BATCH_NO + "' ");
            }
            strSql.Append(" ORDER BY to_number(T.C_TICK_NO) ASC ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 条件获得数据列表
        /// </summary>
        /// <param name="begin">时间 开始</param>
        /// <param name="end">时间 结束</param>
        /// <param name="pland">车间</param>
        /// <param name="batch">批号</param>
        /// <param name="stl">钢种</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetList_Query1(DateTime begin, DateTime end, string pland, string batch, string stl, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.c_sta_desc,c.c_linewh_name, t.c_std_code,t.C_JUDGE_LEV_BP,t.C_DP_SHIFT,b.c_name,t.C_DP_GROUP,max(D_DP_DT) DT,t. C_MAT_CODE,t.C_MAT_DESC,t.C_LINEWH_CODE,t.C_BATCH_NO,t.C_JUDGE_LEV_ZH,t.C_STL_GRD,t.C_SPEC,t.C_STOVE,t.C_ZYX1,t.C_ZYX2,t.C_BZYQ,SUM(N_WGT) N_WGT,COUNT(1) N_NUM    ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT t left join tb_sta a on t.c_sta_id=a.c_id left join ts_user b on t.c_dp_emp_id=b.c_account left join tpb_linewh c on t.c_linewh_code=c.c_linewh_code WHERE 1=1  ");
            if (begin != null && end != null)
            {
                strSql.Append("and t.D_DP_DT between to_date('" + Convert.ToDateTime(begin) + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end) + "','yyyy-mm-dd hh24:mi:ss') ");
            }
            if (pland != "全部")
            {
                strSql.Append(" and a.c_sta_desc ='" + pland + "' ");
            }
            if (batch.Trim() != "")
            {
                strSql.Append(" and t.C_BATCH_NO like '%" + batch + "%' ");
            }
            if (!string.IsNullOrEmpty(stl))
            {
                strSql.Append(" and t.C_STL_GRD like '%" + stl + "%' ");
            }
            if (!string.IsNullOrEmpty(std))
            {
                strSql.Append(" and t.c_std_code like '%" + std + "%' ");
            }
            strSql.Append(" GROUP BY  a.c_sta_desc,c.c_linewh_name,t.c_std_code,b.c_name,t.C_MAT_CODE,t.C_MAT_DESC,t.C_LINEWH_CODE,t.C_BATCH_NO,t.C_JUDGE_LEV_ZH,t.C_STL_GRD,t.C_SPEC,t.C_STOVE,t.C_ZYX1,t.C_ZYX2,t.C_BZYQ,t. C_JUDGE_LEV_BP,t.C_DP_SHIFT,t.C_DP_EMP_ID,t.C_DP_GROUP ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_ID">主键</param>
        /// <returns></returns>
        public DataSet GetList_ID(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2 ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT ");
            if (C_ID.Trim() != "")
            {
                strSql.Append(" where C_ID='" + C_ID + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_PLANT_DESC">工厂描述</param>
        /// <param name="c_batch_no">批号</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="C_SHIFT">班次</param>
        /// <param name="C_GROUP">班组</param>
        /// <returns></returns>
        public DataSet GetList_Tick_No(string C_PLANT_DESC, string c_batch_no, string C_STOVE, string C_STL_GRD, string C_STD_CODE, string C_SPEC, string C_SHIFT, string C_GROUP)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c_id, c_tick_no  ");
            strSql.Append("from TRC_ROLL_PRODCUT  where C_JUDGE_LEV_BP IS NULL and c_batch_no = '" + c_batch_no + "'  ");
            if (!string.IsNullOrEmpty(C_PLANT_DESC))
            {
                strSql.Append(" and C_PLANT_DESC = '" + C_PLANT_DESC + "' ");
            }
            if (!string.IsNullOrEmpty(C_STOVE))
            {
                strSql.Append(" and C_STOVE = '" + C_STOVE + "' ");
            }
            if (!string.IsNullOrEmpty(C_STL_GRD))
            {
                strSql.Append(" and C_STL_GRD = '" + C_STL_GRD + "' ");
            }
            if (!string.IsNullOrEmpty(C_STD_CODE))
            {
                strSql.Append(" and C_STD_CODE = '" + C_STD_CODE + "' ");
            }
            if (!string.IsNullOrEmpty(C_SPEC))
            {
                strSql.Append(" and C_SPEC = '" + C_SPEC + "' ");
            }
            if (!string.IsNullOrEmpty(C_SHIFT))
            {
                strSql.Append(" and C_SHIFT = '" + C_SHIFT + "' ");
            }
            if (!string.IsNullOrEmpty(C_GROUP))
            {
                strSql.Append(" and C_GROUP = '" + C_GROUP + "' ");
            }
            strSql.Append(" order by c_tick_no");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_PLANT_DESC">工厂描述</param>
        /// <param name="c_batch_no">批号</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <param name="C_SPEC">规格</param>
        /// <param name="C_SHIFT">班次</param>
        /// <param name="C_GROUP">班组</param>
        /// <returns></returns>
        public DataSet GetList_Tick_No_All(string C_PLANT_DESC, string c_batch_no, string C_STOVE, string C_STL_GRD, string C_STD_CODE, string C_SPEC, string C_SHIFT, string C_GROUP)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_id, t.c_tick_no  ");
            strSql.Append("from TRC_ROLL_PRODCUT t where 1=1");
            if (C_PLANT_DESC.Trim() != "" && c_batch_no.Trim() != "" && C_STOVE.Trim() != "" && C_STL_GRD.Trim() != "" && C_STD_CODE.Trim() != "" && C_SPEC.Trim() != "" && C_SHIFT.Trim() != "" && C_GROUP.Trim() != "")
            {
                strSql.Append("and t.C_PLANT_DESC = '" + C_PLANT_DESC + "' and t.c_batch_no = '" + c_batch_no + "' and t.C_STOVE = '" + C_STOVE + "'  and t.C_STL_GRD = '" + C_STL_GRD + "' and t.C_STD_CODE = '" + C_STD_CODE + "' and t.C_SPEC = '" + C_SPEC + "' and t.C_SHIFT = '" + C_SHIFT + "' and t.C_GROUP = '" + C_GROUP + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 条件获得数据列表
        /// </summary>
        /// <param name="begin">生产时间 开始</param>
        /// <param name="end">生产时间 结束</param>
        /// <param name="pland">车间</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public DataSet GetList_Query(DateTime begin, DateTime end, string pland, string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.c_sta_desc,t.c_sta_id,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP,count(1) COU,max(t.D_MOD_DT) DT  ");
            strSql.Append(" from TRC_ROLL_PRODCUT t join tb_sta a on t.c_sta_id=a.c_id  where C_JUDGE_LEV_BP IS NULL ");
            if (begin != null && end != null)
            {
                strSql.Append("and t.D_DP_DT between to_date('" + Convert.ToDateTime(begin) + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end) + "','yyyy-mm-dd hh24:mi:ss') ");
            }
            if (pland != "全部")
            {
                strSql.Append(" and t.c_sta_id ='" + pland + "' ");
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.Append(" and t.C_BATCH_NO ='" + batch + "' ");
            }
            strSql.Append(" group by a.c_sta_desc,t.c_sta_id,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取线材实绩信息
        /// </summary>
        /// <param name="begin">生产时间 开始</param>
        /// <param name="end">生产时间 结束</param>
        /// <param name="pland">车间</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public DataSet GetProductList(DateTime begin, DateTime end, string pland, string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.C_STA_ID,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP,count(1) COU,max(t.D_DP_DT) DT");
            strSql.Append(" from TRC_ROLL_PRODCUT t where 1=1 ");
            if (begin != null && end != null)
            {
                strSql.Append("and D_DP_DT between to_date('" + Convert.ToDateTime(begin) + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end) + "','yyyy-mm-dd hh24:mi:ss') ");
            }
            if (pland != "全部")
            {
                strSql.Append(" and C_PLANT_DESC ='" + pland + "' ");
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.Append(" and C_BATCH_NO ='" + batch + "' ");
            }
            strSql.Append("group by t.C_STA_ID,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP");
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

        /// <summary>
        /// 查询线材综合判定数据
        /// </summary>
        /// <param name="batchNo">批号</param>
        /// <param name="stove">炉号</param>
        /// <param name="strTime1">生产开始时间</param>
        /// <param name="strTime2">生产结束时间</param>
        /// <returns></returns>
        public DataSet GetList(string batchNo, string stove, string strTime1, string strTime2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.C_STOVE AS 炉号, T.C_BATCH_NO AS 批号, T.C_STL_GRD AS 钢种, T.C_SPEC AS 规格, T.C_STD_CODE AS 执行标准, T.C_MAT_CODE AS 物料编码, T.C_MAT_NAME AS 物料名称, T.N_QUA AS 件数, T.N_WGT AS 重量, T.C_RESULT_FACE AS 表判结果, T.C_REASON_NAME AS 不合格原因, T.C_RESULT_ELE AS 成分结果, T.C_RESULT_PHY AS 性能初检结果, T.C_RESULT_PHYSEC AS 性能复检结果, T.C_RESULT_PHYFINAL AS 性能评审结果, T.C_RESULT_ALL AS 综合判定结果, T.C_RESULT_PEOPLE AS 人工判定结果, T.D_RESALL_DT AS 判定时间, T.C_QR_STATE AS 是否确认, T.C_EMP_ID AS 确认人, T.D_MOD_DT AS 确认时间, T.D_DP_DT AS 生产时间, T.C_DESIGN_NO AS 质量设计号  FROM TQC_COMPRE_ROLL T WHERE N_STATUS=1 ");

            if (batchNo.Trim() != "")
            {
                strSql.Append(" and T.C_BATCH_NO like '" + batchNo + "%' ");
            }

            if (stove.Trim() != "")
            {
                strSql.Append(" and T.C_STOVE like '" + stove + "%' ");
            }

            if (strTime1.Trim() != "" && strTime2.Trim() != "")
            {
                strSql.Append(" and T.D_DP_DT between to_date('" + strTime1 + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + strTime2 + "','yyyy-mm-dd hh24:mi:ss') ");
            }

            strSql.Append(" order by T.D_DP_DT desc");

            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_BATCH_NO">批号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public DataSet GetList_GP(DateTime begin, DateTime end, string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='E' ");
            if (begin != null && end != null)
            {
                strSql.Append("and D_DP_DT between to_date('" + Convert.ToDateTime(begin) + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end) + "','yyyy-mm-dd hh24:mi:ss') ");
            }
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + C_BATCH_NO + "%' ");
            }

            strSql.Append(" order by C_BATCH_NO,to_number(nvl(c_tick_no,'0')) ");

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="C_BATCH_NO">批号</param>
        /// <returns></returns>
        public DataSet GetList_KJ(DateTime begin, DateTime end, string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='E'");
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO like '%" + C_BATCH_NO + "%' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取线材实绩库存数
        /// </summary>
        /// <param name="C_LINEWH_LOC_CODE">库位编码</param>
        /// <returns></returns>
        public int Get_KC_COUNt(string C_LINEWH_LOC_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1)  FROM TRC_ROLL_PRODCUT t where t.C_MOVE_TYPE = 'E'   and C_LINEWH_LOC_CODE = '" + C_LINEWH_LOC_CODE + "' ");

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
        /// 根据idstr获取数据列表
        /// </summary>
        /// <param name="idstr"></param>
        /// <returns></returns>
        public DataSet GetListbyIDORDERBY(string idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_BATCH_NO,C_JUDGE_LEV_ZH,C_STL_GRD,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ,SUM(N_WGT) N_WGT,COUNT(1) N_NUM FROM TRC_ROLL_PRODCUT WHERE C_MOVE_TYPE ='E' ");
            if (idstr.Trim() != "")
            {
                strSql.Append(" and C_ID in(" + idstr + ")");
            }
            strSql.Append(" GROUP BY C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_BATCH_NO,C_JUDGE_LEV_ZH,C_STL_GRD,C_SPEC,C_STOVE,C_ZYX1,C_ZYX2,C_BZYQ ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="ph">批号</param>
        /// <param name="grd">钢种</param>
        /// <param name="std">执行标准</param>
        /// <param name="ck">仓库</param>
        /// <param name="qy">区域</param>
        /// <param name="kw">库位</param>
        /// <returns></returns>
        public DataSet GetXCKList(string ph, string grd, string std, string ck, string qy, string kw, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2  ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
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
                strSql.Append(" and C_STD_CODE_BEFORE like '%" + std + "%' ");
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

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mod_TRC_ROLL_PRODCUT GetModelByBARCODE(string C_BARCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID  from TRC_ROLL_PRODCUT  ");
            strSql.Append(" where C_BARCODE=:C_BARCODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_BARCODE", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_BARCODE;

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
		/// 更新一条数据
		/// </summary>
		public bool Update_Trans(string strResult, string strUserID, NF.MODEL.Mod_TQC_COMPRE_ROLL model, string C_GP_AFTER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT T SET T.C_JUDGE_LEV_ZH = '" + strResult + "', T.C_IS_QR = 'Y', T.C_QR_USER = '" + strUserID + "', T.D_QR_DATE = sysdate,t.C_GP_AFTER_ID='" + C_GP_AFTER_ID + "',T.C_IS_TB='Y',T.C_IS_PD='Y'  WHERE T.C_DESIGN_NO = '" + model.C_DESIGN_NO + "' AND T.C_STL_GRD = '" + model.C_STL_GRD + "' AND nvl(T.C_SPEC,'0') = nvl('" + model.C_SPEC + "','0') AND T.C_STD_CODE = '" + model.C_STD_CODE + "' AND T.C_MAT_CODE = '" + model.C_MAT_CODE + "' AND T.c_judge_lev_bp = '" + model.C_RESULT_FACE + "' AND NVL(T.C_REASON_NAME,'0') = NVL('" + model.C_REASON_NAME + "','0')   AND T.C_BATCH_NO = '" + model.C_BATCH_NO + "' ");


            int rows = TransactionHelper.ExecuteSql(strSql.ToString());
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
        public bool Update(string strUserID, NF.MODEL.Mod_TQC_COMPRE_ROLL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT T SET T.C_JUDGE_LEV_ZH = '', T.C_IS_QR = 'N', T.C_QR_USER = '', T.D_QR_DATE = null WHERE T.C_DESIGN_NO = '" + model.C_DESIGN_NO + "' AND T.C_STL_GRD = '" + model.C_STL_GRD + "' AND nvl(T.C_SPEC,'0') = nvl('" + model.C_SPEC + "','0') AND T.C_STD_CODE = '" + model.C_STD_CODE + "' AND T.C_MAT_CODE = '" + model.C_MAT_CODE + "' AND T.c_judge_lev_bp = '" + model.C_RESULT_FACE + "' AND NVL(T.C_REASON_NAME,'0') = NVL('" + model.C_REASON_NAME + "','0')   AND T.C_BATCH_NO = '" + model.C_BATCH_NO + "' AND T.C_STOVE = '" + model.C_STOVE + "' ");


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
        /// 获得数据列表-已入库
        /// </summary> 
        /// <param name="C_LINEWH_LOC_CODE">库位</param> 
        /// <returns></returns>
        public DataSet GetList_KW_Group(string C_LINEWH_LOC_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_linewh_loc_code , sum(t.n_wgt)wgt,a.c_sta_desc,T.C_MAT_CODE,T.C_MAT_DESC,t.C_STA_ID,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP,count(1) COU,max(t.D_DP_DT) DT   ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT T left JOIN  Tb_Sta a on t.c_sta_id=a.c_id where  t.C_MOVE_TYPE ='E'");

            if (C_LINEWH_LOC_CODE.Trim() != "")
            {
                strSql.Append(" and t.c_linewh_loc_code ='" + C_LINEWH_LOC_CODE + "' ");
            }
            strSql.Append(" group by t.c_linewh_loc_code ,t.C_STA_ID,t.c_batch_no,t.C_STOVE,t.C_STL_GRD,t.C_STD_CODE,t.C_SPEC,t.C_SHIFT,t.C_GROUP,T.C_MAT_CODE,T.C_MAT_DESC, a.c_sta_desc ");
            strSql.Append(" order by t.c_linewh_loc_code");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_BATCH_NO">批号</param>
        /// <returns></returns>
        public DataSet Get_All_ByBatch_Trans(string C_BATCH_NO, string C_MASTER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.C_JUDGE_LEV_ZH,SUM(T.N_WGT)AS N_WGT,COUNT(1)AS QUA,max(t.C_ORDER_NO)as C_ORDER_NO,max(t.C_LINEWH_CODE)as C_LINEWH_CODE,T.C_STD_CODE, T.C_MAT_CODE, T.C_ZYX1, T.C_ZYX2,C_GP_AFTER_ID FROM TRC_ROLL_PRODCUT T WHERE T.C_BATCH_NO='" + C_BATCH_NO + "' AND T.C_IS_QR='Y' and C_MASTER_ID='" + C_MASTER_ID + "' GROUP BY T.C_JUDGE_LEV_ZH, T.C_STD_CODE, T.C_MAT_CODE, T.C_ZYX1, T.C_ZYX2,C_GP_AFTER_ID ");

            return TransactionHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="C_BATCH_NO">批号</param>
        /// <returns></returns>
        public DataSet Get_List_ByGroup(string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.C_STD_CODE, T.C_MAT_CODE,T.C_STL_GRD,T.C_SPEC, T.C_ZYX1, T.C_ZYX2,sum(t.n_wgt)as N_WGT,COUNT(1)AS QUA  FROM TRC_ROLL_PRODCUT T WHERE T.C_BATCH_NO = '" + C_BATCH_NO + "' GROUP BY T.C_STD_CODE, T.C_MAT_CODE, T.C_ZYX1, T.C_ZYX2,T.C_STL_GRD,T.C_SPEC ");

            return TransactionHelper.Query(strSql.ToString());
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update_Trans(string C_MASTER_ID, string C_GP_BEFORE_ID, string C_STD_CODE, string C_MAT_CODE, string C_ZYX1, string C_ZYX2, string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TRC_ROLL_PRODCUT T SET T.C_MASTER_ID = '" + C_MASTER_ID + "',t.C_GP_BEFORE_ID='" + C_GP_BEFORE_ID + "'  WHERE T.C_STD_CODE = '" + C_STD_CODE + "' AND T.C_MAT_CODE = '" + C_MAT_CODE + "'  AND T.C_ZYX1 = '" + C_ZYX1 + "' AND T.C_ZYX2 = '" + C_ZYX2 + "' AND T.C_BATCH_NO = '" + C_BATCH_NO + "' ");


            int rows = TransactionHelper.ExecuteSql(strSql.ToString());
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
        /// 获得数据列表
        /// </summary>
        /// <param name="C_BATCH_NO">批号</param>
        /// <returns></returns>
        public DataSet Get_Details(string C_BATCH_NO, string C_STD_CODE, string C_MAT_CODE, string C_ZYX1, string C_ZYX2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  C_ID,C_EMP_ID,D_MOD_DT,C_TRC_ROLL_MAIN_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_STL_GRD,C_STL_GRD_BEFORE,N_WGT,C_STD_CODE,C_STD_CODE_BEFORE,C_MOVE_TYPE,C_SPEC,C_SHIFT,C_GROUP,C_STA_ID,C_JUDGE_LEV_BP,C_DP_SHIFT,C_DP_GROUP,C_DP_EMP_ID,D_DP_DT,C_PLANT_ID,C_PLANT_DESC,C_MAT_CODE,C_MAT_CODE_BEFORE,C_MAT_DESC,C_MAT_DESC_BEFORE,C_IS_DEPOT,C_PLAN_ID,C_ORDER_NO,C_CON_NO,C_CUST_NO,C_CUST_NAME,C_ISFREE,C_LINEWH_CODE,C_LINEWH_AREA_CODE,C_LINEWH_LOC_CODE,C_FLOOR,C_CUST_AREA,C_SALE_AREA,C_JUDGE_LEV_CF,C_JUDGE_LEV_XN,C_JUDGE_LEV_XN_RE,C_JUDGE_LEV_ZH_PEOPLE,D_JUDGE_DATE,C_IS_QR,C_QR_USER,D_QR_DATE,C_DESIGN_NO,C_JUDGE_LEV_ZH,C_IS_TB,C_SCUTCHEON,C_GP_TYPE,C_BARCODE,C_RKDH,C_FYDH,C_CKDH,C_MOVE_DESC,C_CKRY,D_CKRQ,C_RKRY,D_RKRQ,C_BZYQ,D_WEIGHT_DT,D_PRODUCE_DATE,C_ZYX1,C_ZYX2,C_MASTER_ID,C_GP_BEFORE_ID,C_GP_AFTER_ID  from TRC_ROLL_PRODCUT t ");
            strSql.Append(" WHERE T.C_BATCH_NO = '" + C_BATCH_NO + "' and t.C_STD_CODE = '" + C_STD_CODE + "' and T.C_MAT_CODE = '" + C_MAT_CODE + "' and T.C_ZYX1 = '" + C_ZYX1 + "' and T.C_ZYX2 = '" + C_ZYX2 + "' ");

            return TransactionHelper.Query(strSql.ToString());
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
        /// <returns></returns>
        public DataSet GetXCKC(string ph, string grd, string std, string ck, string qy, string kw, string status, string C_QTCKD, string C_ZKD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) N_NUM, COUNT(1) N_SNUM,C_BATCH_NO,C_STL_GRD,SUM(N_WGT) N_WGT,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,nvl(C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP)AS C_JUDGE_LEV_ZH,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            strSql.Append(" FROM TRC_ROLL_PRODCUT where C_MOVE_TYPE ='" + status + "' ");
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
                strSql.Append(" and C_QTCKD_NO ='" + C_QTCKD + "' ");
            }
            if (C_ZKD.Trim() != "")
            {
                strSql.Append(" and C_ZKD_NO ='" + C_ZKD + "' ");
            }
            strSql.Append(" GROUP BY  C_BATCH_NO,C_STL_GRD,C_STD_CODE,C_MOVE_TYPE,C_SPEC,C_MAT_CODE,C_MAT_DESC,C_LINEWH_CODE,C_JUDGE_LEV_ZH,C_JUDGE_LEV_BP,C_BZYQ,C_ZYX1,C_ZYX2,C_ZKD_NO,C_QTCKD_NO ");
            strSql.Append(" ORDER BY  C_BATCH_NO,C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取PCI库存差异数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetTMM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_BATCH_NO,C_BARCODE,C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_MAT_CODE,C_MAT_DESC,C_JUDGE_LEV_ZH,C_REASON_NAME,C_STL_GRD,C_SPEC,C_TICK_NO,N_WGT,C_STD_CODE,C_MOVE_DESC,C_RKRY,C_ZYX1,C_ZYX2,C_BZYQ,C_GROUP,C_PLANT_ID,C_STOVE,C_MOVE_TYPE,C_DESIGN_NO,C_IS_QR,C_IS_TB,C_IS_PD,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA FROM TRC_ROLL_PRODCUT MINUS SELECT C_BATCH_NO, C_BARCODE,C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_MAT_CODE,C_MAT_DESC,C_JUDGE_LEV_ZH,C_REASON_NAME,C_STL_GRD,C_SPEC,C_TICK_NO,  N_WGT,C_STD_CODE,C_MOVE_DESC,C_RKRY,C_ZYX1,C_ZYX2,C_BZYQ,C_GROUP,C_PLANT_ID,C_STOVE,C_MOVE_TYPE,C_DESIGN_NO,C_IS_QR,C_IS_TB,C_IS_PD,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA  FROM TRC_ROLL_PRODUCT_TM ");

            strSql.Append(" ORDER BY  C_BATCH_NO,C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取条码库存差异数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetPCIM()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT C_BATCH_NO,C_BARCODE,C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_MAT_CODE,C_MAT_DESC,C_JUDGE_LEV_ZH,C_REASON_NAME,C_STL_GRD,C_SPEC,C_TICK_NO,N_WGT,C_STD_CODE,C_MOVE_DESC,C_RKRY,C_ZYX1,C_ZYX2,C_BZYQ,C_GROUP,C_PLANT_ID,C_STOVE,C_MOVE_TYPE,C_DESIGN_NO,C_IS_QR,C_IS_TB,C_IS_PD,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA FROM TRC_ROLL_PRODUCT_TM  MINUS SELECT C_BATCH_NO,C_BARCODE,C_LINEWH_CODE,C_LINEWH_LOC_CODE,C_MAT_CODE,C_MAT_DESC,C_JUDGE_LEV_ZH,C_REASON_NAME,C_STL_GRD,C_SPEC,C_TICK_NO,  N_WGT,C_STD_CODE,C_MOVE_DESC,C_RKRY,C_ZYX1,C_ZYX2,C_BZYQ,C_GROUP,C_PLANT_ID,C_STOVE,C_MOVE_TYPE,C_DESIGN_NO,C_IS_QR,C_IS_TB,C_IS_PD,C_JUDGE_LEV_BP,C_LINEWH_AREA_CODE,C_SALE_AREA  FROM TRC_ROLL_PRODCUT ");

            strSql.Append(" ORDER BY  C_BATCH_NO,C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }
    }

}
#endregion  ExtensionMethod
