using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections.Generic;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TSC_SLAB_MAIN
    /// </summary>
    public partial class Dal_TSC_SLAB_MAIN
    {
        public Dal_TSC_SLAB_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TSC_SLAB_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TSC_SLAB_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TSC_SLAB_MAIN(");
            strSql.Append("C_ID,C_PLAN_ID,C_ORD_NO,C_STOVE,C_STA_ID,C_STA_CODE,C_STA_DESC,C_STL_GRD,C_STL_GRD_PRE,C_MAT_CODE,C_MAT_NAME,C_SPEC,N_LEN,N_QUA,N_WGT,C_STD_CODE,C_SLAB_TYPE,D_CCM_DATE,C_CCM_SHIFT,C_CCM_GROUP,C_CCM_EMP_ID,C_MOVE_TYPE,C_SC_STATE,D_ESC_DATE,D_LSC_DATE,C_QKP_STATE,C_KP_ID,C_CON_NO,C_CUS_NO,C_CUS_NAME,D_WL_DATE,C_WL_SHIFT,C_WL_GROUP,C_WL_EMP_ID,D_WE_DATE,C_WE_SHIFT,C_WE_GROUP,C_WE_EMP_ID,C_STOCK_STATE,C_MAT_TYPE,C_QGP_STATE,C_SLABWH_CODE,C_SLABWH_AREA_CODE,C_SLABWH_LOC_CODE,C_SLABWH_TIER_CODE,C_Q_RESULT,D_Q_DATE,C_Q_NOTE,N_WGT_METER,C_QF_NAME,C_DESIGN_NO,C_ZRBM,C_IS_DEPOT,C_ISXM,C_XMGX,C_ISFREE)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_PLAN_ID,:C_ORD_NO,:C_STOVE,:C_STA_ID,:C_STA_CODE,:C_STA_DESC,:C_STL_GRD,:C_STL_GRD_PRE,:C_MAT_CODE,:C_MAT_NAME,:C_SPEC,:N_LEN,:N_QUA,:N_WGT,:C_STD_CODE,:C_SLAB_TYPE,:D_CCM_DATE,:C_CCM_SHIFT,:C_CCM_GROUP,:C_CCM_EMP_ID,:C_MOVE_TYPE,:C_SC_STATE,:D_ESC_DATE,:D_LSC_DATE,:C_QKP_STATE,:C_KP_ID,:C_CON_NO,:C_CUS_NO,:C_CUS_NAME,:D_WL_DATE,:C_WL_SHIFT,:C_WL_GROUP,:C_WL_EMP_ID,:D_WE_DATE,:C_WE_SHIFT,:C_WE_GROUP,:C_WE_EMP_ID,:C_STOCK_STATE,:C_MAT_TYPE,:C_QGP_STATE,:C_SLABWH_CODE,:C_SLABWH_AREA_CODE,:C_SLABWH_LOC_CODE,:C_SLABWH_TIER_CODE,:C_Q_RESULT,:D_Q_DATE,:C_Q_NOTE,:N_WGT_METER,:C_QF_NAME,:C_DESIGN_NO,:C_ZRBM,:C_IS_DEPOT,:C_ISXM,:C_XMGX,:C_ISFREE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ORD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_STL_GRD_PRE", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,30),
                    new OracleParameter(":N_LEN", OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA", OracleDbType.Decimal,4),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,10),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":D_CCM_DATE", OracleDbType.Date),
                    new OracleParameter(":C_CCM_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_CCM_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_CCM_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SC_STATE", OracleDbType.Varchar2,2),
                    new OracleParameter(":D_ESC_DATE", OracleDbType.Date),
                    new OracleParameter(":D_LSC_DATE", OracleDbType.Date),
                    new OracleParameter(":C_QKP_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_KP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUS_NO", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUS_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_WL_DATE", OracleDbType.Date),
                    new OracleParameter(":C_WL_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WL_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WL_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":D_WE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_WE_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WE_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WE_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":C_STOCK_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_QGP_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_AREA_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_LOC_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_TIER_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_Q_RESULT", OracleDbType.Varchar2,5),
                    new OracleParameter(":D_Q_DATE", OracleDbType.Date),
                    new OracleParameter(":C_Q_NOTE", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_WGT_METER", OracleDbType.Decimal,15),
                    new OracleParameter(":C_QF_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ZRBM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ISXM", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_XMGX", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,5)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_PLAN_ID;
            parameters[2].Value = model.C_ORD_NO;
            parameters[3].Value = model.C_STOVE;
            parameters[4].Value = model.C_STA_ID;
            parameters[5].Value = model.C_STA_CODE;
            parameters[6].Value = model.C_STA_DESC;
            parameters[7].Value = model.C_STL_GRD;
            parameters[8].Value = model.C_STL_GRD_PRE;
            parameters[9].Value = model.C_MAT_CODE;
            parameters[10].Value = model.C_MAT_NAME;
            parameters[11].Value = model.C_SPEC;
            parameters[12].Value = model.N_LEN;
            parameters[13].Value = model.N_QUA;
            parameters[14].Value = model.N_WGT;
            parameters[15].Value = model.C_STD_CODE;
            parameters[16].Value = model.C_SLAB_TYPE;
            parameters[17].Value = model.D_CCM_DATE;
            parameters[18].Value = model.C_CCM_SHIFT;
            parameters[19].Value = model.C_CCM_GROUP;
            parameters[20].Value = model.C_CCM_EMP_ID;
            parameters[21].Value = model.C_MOVE_TYPE;
            parameters[22].Value = model.C_SC_STATE;
            parameters[23].Value = model.D_ESC_DATE;
            parameters[24].Value = model.D_LSC_DATE;
            parameters[25].Value = model.C_QKP_STATE;
            parameters[26].Value = model.C_KP_ID;
            parameters[27].Value = model.C_CON_NO;
            parameters[28].Value = model.C_CUS_NO;
            parameters[29].Value = model.C_CUS_NAME;
            parameters[30].Value = model.D_WL_DATE;
            parameters[31].Value = model.C_WL_SHIFT;
            parameters[32].Value = model.C_WL_GROUP;
            parameters[33].Value = model.C_WL_EMP_ID;
            parameters[34].Value = model.D_WE_DATE;
            parameters[35].Value = model.C_WE_SHIFT;
            parameters[36].Value = model.C_WE_GROUP;
            parameters[37].Value = model.C_WE_EMP_ID;
            parameters[38].Value = model.C_STOCK_STATE;
            parameters[39].Value = model.C_MAT_TYPE;
            parameters[40].Value = model.C_QGP_STATE;
            parameters[41].Value = model.C_SLABWH_CODE;
            parameters[42].Value = model.C_SLABWH_AREA_CODE;
            parameters[43].Value = model.C_SLABWH_LOC_CODE;
            parameters[44].Value = model.C_SLABWH_TIER_CODE;
            parameters[45].Value = model.C_Q_RESULT;
            parameters[46].Value = model.D_Q_DATE;
            parameters[47].Value = model.C_Q_NOTE;
            parameters[48].Value = model.N_WGT_METER;
            parameters[49].Value = model.C_QF_NAME;
            parameters[50].Value = model.C_DESIGN_NO;
            parameters[51].Value = model.C_ZRBM;
            parameters[52].Value = model.C_IS_DEPOT;
            parameters[53].Value = model.C_ISXM;
            parameters[54].Value = model.C_XMGX;
            parameters[55].Value = model.C_ISFREE;

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
        public bool Update(Mod_TSC_SLAB_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TSC_SLAB_MAIN set ");
            strSql.Append("C_PLAN_ID=:C_PLAN_ID,");
            strSql.Append("C_ORD_NO=:C_ORD_NO,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_STA_CODE=:C_STA_CODE,");
            strSql.Append("C_STA_DESC=:C_STA_DESC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_STL_GRD_PRE=:C_STL_GRD_PRE,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("N_LEN=:N_LEN,");
            strSql.Append("N_QUA=:N_QUA,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_SLAB_TYPE=:C_SLAB_TYPE,");
            strSql.Append("D_CCM_DATE=:D_CCM_DATE,");
            strSql.Append("C_CCM_SHIFT=:C_CCM_SHIFT,");
            strSql.Append("C_CCM_GROUP=:C_CCM_GROUP,");
            strSql.Append("C_CCM_EMP_ID=:C_CCM_EMP_ID,");
            strSql.Append("C_MOVE_TYPE=:C_MOVE_TYPE,");
            strSql.Append("C_SC_STATE=:C_SC_STATE,");
            strSql.Append("D_ESC_DATE=:D_ESC_DATE,");
            strSql.Append("D_LSC_DATE=:D_LSC_DATE,");
            strSql.Append("C_QKP_STATE=:C_QKP_STATE,");
            strSql.Append("C_KP_ID=:C_KP_ID,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_CUS_NO=:C_CUS_NO,");
            strSql.Append("C_CUS_NAME=:C_CUS_NAME,");
            strSql.Append("D_WL_DATE=:D_WL_DATE,");
            strSql.Append("C_WL_SHIFT=:C_WL_SHIFT,");
            strSql.Append("C_WL_GROUP=:C_WL_GROUP,");
            strSql.Append("C_WL_EMP_ID=:C_WL_EMP_ID,");
            strSql.Append("D_WE_DATE=:D_WE_DATE,");
            strSql.Append("C_WE_SHIFT=:C_WE_SHIFT,");
            strSql.Append("C_WE_GROUP=:C_WE_GROUP,");
            strSql.Append("C_WE_EMP_ID=:C_WE_EMP_ID,");
            strSql.Append("C_STOCK_STATE=:C_STOCK_STATE,");
            strSql.Append("C_MAT_TYPE=:C_MAT_TYPE,");
            strSql.Append("C_QGP_STATE=:C_QGP_STATE,");
            strSql.Append("C_SLABWH_CODE=:C_SLABWH_CODE,");
            strSql.Append("C_SLABWH_AREA_CODE=:C_SLABWH_AREA_CODE,");
            strSql.Append("C_SLABWH_LOC_CODE=:C_SLABWH_LOC_CODE,");
            strSql.Append("C_SLABWH_TIER_CODE=:C_SLABWH_TIER_CODE,");
            strSql.Append("C_Q_RESULT=:C_Q_RESULT,");
            strSql.Append("D_Q_DATE=:D_Q_DATE,");
            strSql.Append("C_Q_NOTE=:C_Q_NOTE,");
            strSql.Append("N_WGT_METER=:N_WGT_METER,");
            strSql.Append("C_QF_NAME=:C_QF_NAME,");
            strSql.Append("C_DESIGN_NO=:C_DESIGN_NO,");
            strSql.Append("C_ZRBM=:C_ZRBM,");
            strSql.Append("C_IS_DEPOT=:C_IS_DEPOT,");
            strSql.Append("C_ISXM=:C_ISXM,");
            strSql.Append("C_XMGX=:C_XMGX,");
            strSql.Append("C_ISFREE=:C_ISFREE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ORD_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_STL_GRD_PRE", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,30),
                    new OracleParameter(":N_LEN", OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA", OracleDbType.Decimal,4),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,10),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":D_CCM_DATE", OracleDbType.Date),
                    new OracleParameter(":C_CCM_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_CCM_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_CCM_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":C_MOVE_TYPE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SC_STATE", OracleDbType.Varchar2,2),
                    new OracleParameter(":D_ESC_DATE", OracleDbType.Date),
                    new OracleParameter(":D_LSC_DATE", OracleDbType.Date),
                    new OracleParameter(":C_QKP_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_KP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUS_NO", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUS_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_WL_DATE", OracleDbType.Date),
                    new OracleParameter(":C_WL_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WL_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WL_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":D_WE_DATE", OracleDbType.Date),
                    new OracleParameter(":C_WE_SHIFT", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WE_GROUP", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_WE_EMP_ID", OracleDbType.Varchar2,15),
                    new OracleParameter(":C_STOCK_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,10),
                    new OracleParameter(":C_QGP_STATE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_AREA_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_LOC_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_SLABWH_TIER_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_Q_RESULT", OracleDbType.Varchar2,5),
                    new OracleParameter(":D_Q_DATE", OracleDbType.Date),
                    new OracleParameter(":C_Q_NOTE", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_WGT_METER", OracleDbType.Decimal,15),
                    new OracleParameter(":C_QF_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESIGN_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ZRBM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_DEPOT", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_ISXM", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_XMGX", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ISFREE", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_PLAN_ID;
            parameters[1].Value = model.C_ORD_NO;
            parameters[2].Value = model.C_STOVE;
            parameters[3].Value = model.C_STA_ID;
            parameters[4].Value = model.C_STA_CODE;
            parameters[5].Value = model.C_STA_DESC;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_STL_GRD_PRE;
            parameters[8].Value = model.C_MAT_CODE;
            parameters[9].Value = model.C_MAT_NAME;
            parameters[10].Value = model.C_SPEC;
            parameters[11].Value = model.N_LEN;
            parameters[12].Value = model.N_QUA;
            parameters[13].Value = model.N_WGT;
            parameters[14].Value = model.C_STD_CODE;
            parameters[15].Value = model.C_SLAB_TYPE;
            parameters[16].Value = model.D_CCM_DATE;
            parameters[17].Value = model.C_CCM_SHIFT;
            parameters[18].Value = model.C_CCM_GROUP;
            parameters[19].Value = model.C_CCM_EMP_ID;
            parameters[20].Value = model.C_MOVE_TYPE;
            parameters[21].Value = model.C_SC_STATE;
            parameters[22].Value = model.D_ESC_DATE;
            parameters[23].Value = model.D_LSC_DATE;
            parameters[24].Value = model.C_QKP_STATE;
            parameters[25].Value = model.C_KP_ID;
            parameters[26].Value = model.C_CON_NO;
            parameters[27].Value = model.C_CUS_NO;
            parameters[28].Value = model.C_CUS_NAME;
            parameters[29].Value = model.D_WL_DATE;
            parameters[30].Value = model.C_WL_SHIFT;
            parameters[31].Value = model.C_WL_GROUP;
            parameters[32].Value = model.C_WL_EMP_ID;
            parameters[33].Value = model.D_WE_DATE;
            parameters[34].Value = model.C_WE_SHIFT;
            parameters[35].Value = model.C_WE_GROUP;
            parameters[36].Value = model.C_WE_EMP_ID;
            parameters[37].Value = model.C_STOCK_STATE;
            parameters[38].Value = model.C_MAT_TYPE;
            parameters[39].Value = model.C_QGP_STATE;
            parameters[40].Value = model.C_SLABWH_CODE;
            parameters[41].Value = model.C_SLABWH_AREA_CODE;
            parameters[42].Value = model.C_SLABWH_LOC_CODE;
            parameters[43].Value = model.C_SLABWH_TIER_CODE;
            parameters[44].Value = model.C_Q_RESULT;
            parameters[45].Value = model.D_Q_DATE;
            parameters[46].Value = model.C_Q_NOTE;
            parameters[47].Value = model.N_WGT_METER;
            parameters[48].Value = model.C_QF_NAME;
            parameters[49].Value = model.C_DESIGN_NO;
            parameters[50].Value = model.C_ZRBM;
            parameters[51].Value = model.C_IS_DEPOT;
            parameters[52].Value = model.C_ISXM;
            parameters[53].Value = model.C_XMGX;
            parameters[54].Value = model.C_ISFREE;
            parameters[55].Value = model.C_ID;

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
            strSql.Append("delete from TSC_SLAB_MAIN ");
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
            strSql.Append("delete from TSC_SLAB_MAIN ");
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
        public Mod_TSC_SLAB_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PLAN_ID,C_ORD_NO,C_STOVE,C_STA_ID,C_STA_CODE,C_STA_DESC,C_STL_GRD,C_STL_GRD_PRE,C_MAT_CODE,C_MAT_NAME,C_SPEC,N_LEN,N_QUA,N_WGT,C_STD_CODE,C_SLAB_TYPE,D_CCM_DATE,C_CCM_SHIFT,C_CCM_GROUP,C_CCM_EMP_ID,C_MOVE_TYPE,C_SC_STATE,D_ESC_DATE,D_LSC_DATE,C_QKP_STATE,C_KP_ID,C_CON_NO,C_CUS_NO,C_CUS_NAME,D_WL_DATE,C_WL_SHIFT,C_WL_GROUP,C_WL_EMP_ID,D_WE_DATE,C_WE_SHIFT,C_WE_GROUP,C_WE_EMP_ID,C_STOCK_STATE,C_MAT_TYPE,C_QGP_STATE,C_SLABWH_CODE,C_SLABWH_AREA_CODE,C_SLABWH_LOC_CODE,C_SLABWH_TIER_CODE,C_Q_RESULT,D_Q_DATE,C_Q_NOTE,N_WGT_METER,C_QF_NAME,C_DESIGN_NO,C_ZRBM,C_IS_DEPOT,C_ISXM,C_XMGX,C_ISFREE from TSC_SLAB_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TSC_SLAB_MAIN model = new Mod_TSC_SLAB_MAIN();
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
        public Mod_TSC_SLAB_MAIN DataRowToModel(DataRow row)
        {
            Mod_TSC_SLAB_MAIN model = new Mod_TSC_SLAB_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_PLAN_ID"] != null)
                {
                    model.C_PLAN_ID = row["C_PLAN_ID"].ToString();
                }
                if (row["C_ORD_NO"] != null)
                {
                    model.C_ORD_NO = row["C_ORD_NO"].ToString();
                }
                if (row["C_STOVE"] != null)
                {
                    model.C_STOVE = row["C_STOVE"].ToString();
                }
                if (row["C_STA_ID"] != null)
                {
                    model.C_STA_ID = row["C_STA_ID"].ToString();
                }
                if (row["C_STA_CODE"] != null)
                {
                    model.C_STA_CODE = row["C_STA_CODE"].ToString();
                }
                if (row["C_STA_DESC"] != null)
                {
                    model.C_STA_DESC = row["C_STA_DESC"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_STL_GRD_PRE"] != null)
                {
                    model.C_STL_GRD_PRE = row["C_STL_GRD_PRE"].ToString();
                }
                if (row["C_MAT_CODE"] != null)
                {
                    model.C_MAT_CODE = row["C_MAT_CODE"].ToString();
                }
                if (row["C_MAT_NAME"] != null)
                {
                    model.C_MAT_NAME = row["C_MAT_NAME"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["N_LEN"] != null && row["N_LEN"].ToString() != "")
                {
                    model.N_LEN = decimal.Parse(row["N_LEN"].ToString());
                }
                if (row["N_QUA"] != null && row["N_QUA"].ToString() != "")
                {
                    model.N_QUA = decimal.Parse(row["N_QUA"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_SLAB_TYPE"] != null)
                {
                    model.C_SLAB_TYPE = row["C_SLAB_TYPE"].ToString();
                }
                if (row["D_CCM_DATE"] != null && row["D_CCM_DATE"].ToString() != "")
                {
                    model.D_CCM_DATE = DateTime.Parse(row["D_CCM_DATE"].ToString());
                }
                if (row["C_CCM_SHIFT"] != null)
                {
                    model.C_CCM_SHIFT = row["C_CCM_SHIFT"].ToString();
                }
                if (row["C_CCM_GROUP"] != null)
                {
                    model.C_CCM_GROUP = row["C_CCM_GROUP"].ToString();
                }
                if (row["C_CCM_EMP_ID"] != null)
                {
                    model.C_CCM_EMP_ID = row["C_CCM_EMP_ID"].ToString();
                }
                if (row["C_MOVE_TYPE"] != null)
                {
                    model.C_MOVE_TYPE = row["C_MOVE_TYPE"].ToString();
                }
                if (row["C_SC_STATE"] != null)
                {
                    model.C_SC_STATE = row["C_SC_STATE"].ToString();
                }
                if (row["D_ESC_DATE"] != null && row["D_ESC_DATE"].ToString() != "")
                {
                    model.D_ESC_DATE = DateTime.Parse(row["D_ESC_DATE"].ToString());
                }
                if (row["D_LSC_DATE"] != null && row["D_LSC_DATE"].ToString() != "")
                {
                    model.D_LSC_DATE = DateTime.Parse(row["D_LSC_DATE"].ToString());
                }
                if (row["C_QKP_STATE"] != null)
                {
                    model.C_QKP_STATE = row["C_QKP_STATE"].ToString();
                }
                if (row["C_KP_ID"] != null)
                {
                    model.C_KP_ID = row["C_KP_ID"].ToString();
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["C_CUS_NO"] != null)
                {
                    model.C_CUS_NO = row["C_CUS_NO"].ToString();
                }
                if (row["C_CUS_NAME"] != null)
                {
                    model.C_CUS_NAME = row["C_CUS_NAME"].ToString();
                }
                if (row["D_WL_DATE"] != null && row["D_WL_DATE"].ToString() != "")
                {
                    model.D_WL_DATE = DateTime.Parse(row["D_WL_DATE"].ToString());
                }
                if (row["C_WL_SHIFT"] != null)
                {
                    model.C_WL_SHIFT = row["C_WL_SHIFT"].ToString();
                }
                if (row["C_WL_GROUP"] != null)
                {
                    model.C_WL_GROUP = row["C_WL_GROUP"].ToString();
                }
                if (row["C_WL_EMP_ID"] != null)
                {
                    model.C_WL_EMP_ID = row["C_WL_EMP_ID"].ToString();
                }
                if (row["D_WE_DATE"] != null && row["D_WE_DATE"].ToString() != "")
                {
                    model.D_WE_DATE = DateTime.Parse(row["D_WE_DATE"].ToString());
                }
                if (row["C_WE_SHIFT"] != null)
                {
                    model.C_WE_SHIFT = row["C_WE_SHIFT"].ToString();
                }
                if (row["C_WE_GROUP"] != null)
                {
                    model.C_WE_GROUP = row["C_WE_GROUP"].ToString();
                }
                if (row["C_WE_EMP_ID"] != null)
                {
                    model.C_WE_EMP_ID = row["C_WE_EMP_ID"].ToString();
                }
                if (row["C_STOCK_STATE"] != null)
                {
                    model.C_STOCK_STATE = row["C_STOCK_STATE"].ToString();
                }
                if (row["C_MAT_TYPE"] != null)
                {
                    model.C_MAT_TYPE = row["C_MAT_TYPE"].ToString();
                }
                if (row["C_QGP_STATE"] != null)
                {
                    model.C_QGP_STATE = row["C_QGP_STATE"].ToString();
                }
                if (row["C_SLABWH_CODE"] != null)
                {
                    model.C_SLABWH_CODE = row["C_SLABWH_CODE"].ToString();
                }
                if (row["C_SLABWH_AREA_CODE"] != null)
                {
                    model.C_SLABWH_AREA_CODE = row["C_SLABWH_AREA_CODE"].ToString();
                }
                if (row["C_SLABWH_LOC_CODE"] != null)
                {
                    model.C_SLABWH_LOC_CODE = row["C_SLABWH_LOC_CODE"].ToString();
                }
                if (row["C_SLABWH_TIER_CODE"] != null)
                {
                    model.C_SLABWH_TIER_CODE = row["C_SLABWH_TIER_CODE"].ToString();
                }
                if (row["C_Q_RESULT"] != null)
                {
                    model.C_Q_RESULT = row["C_Q_RESULT"].ToString();
                }
                if (row["D_Q_DATE"] != null && row["D_Q_DATE"].ToString() != "")
                {
                    model.D_Q_DATE = DateTime.Parse(row["D_Q_DATE"].ToString());
                }
                if (row["C_Q_NOTE"] != null)
                {
                    model.C_Q_NOTE = row["C_Q_NOTE"].ToString();
                }
                if (row["N_WGT_METER"] != null && row["N_WGT_METER"].ToString() != "")
                {
                    model.N_WGT_METER = decimal.Parse(row["N_WGT_METER"].ToString());
                }
                if (row["C_QF_NAME"] != null)
                {
                    model.C_QF_NAME = row["C_QF_NAME"].ToString();
                }
                if (row["C_DESIGN_NO"] != null)
                {
                    model.C_DESIGN_NO = row["C_DESIGN_NO"].ToString();
                }
                if (row["C_ZRBM"] != null)
                {
                    model.C_ZRBM = row["C_ZRBM"].ToString();
                }
                if (row["C_IS_DEPOT"] != null)
                {
                    model.C_IS_DEPOT = row["C_IS_DEPOT"].ToString();
                }
                if (row["C_ISXM"] != null)
                {
                    model.C_ISXM = row["C_ISXM"].ToString();
                }
                if (row["C_XMGX"] != null)
                {
                    model.C_XMGX = row["C_XMGX"].ToString();
                }
                if (row["C_ISFREE"] != null)
                {
                    model.C_ISFREE = row["C_ISFREE"].ToString();
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
            strSql.Append("select C_ID,C_PLAN_ID,C_ORD_NO,C_STOVE,C_STA_ID,C_STA_CODE,C_STA_DESC,C_STL_GRD,C_STL_GRD_PRE,C_MAT_CODE,C_MAT_NAME,C_SPEC,N_LEN,N_QUA,N_WGT,C_STD_CODE,C_SLAB_TYPE,D_CCM_DATE,C_CCM_SHIFT,C_CCM_GROUP,C_CCM_EMP_ID,C_MOVE_TYPE,C_SC_STATE,D_ESC_DATE,D_LSC_DATE,C_QKP_STATE,C_KP_ID,C_CON_NO,C_CUS_NO,C_CUS_NAME,D_WL_DATE,C_WL_SHIFT,C_WL_GROUP,C_WL_EMP_ID,D_WE_DATE,C_WE_SHIFT,C_WE_GROUP,C_WE_EMP_ID,C_STOCK_STATE,C_MAT_TYPE,C_QGP_STATE,C_SLABWH_CODE,C_SLABWH_AREA_CODE,C_SLABWH_LOC_CODE,C_SLABWH_TIER_CODE,C_Q_RESULT,D_Q_DATE,C_Q_NOTE,N_WGT_METER,C_QF_NAME,C_DESIGN_NO,C_ZRBM,C_IS_DEPOT,C_ISXM,C_XMGX,C_ISFREE ");
            strSql.Append(" FROM TSC_SLAB_MAIN ");
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
            strSql.Append("select count(1) FROM TSC_SLAB_MAIN ");
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
            strSql.Append(")AS Row, T.*  from TSC_SLAB_MAIN T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region //钢坯库存查询
        /// <summary>
        /// 获取钢坯数据列表
        /// </summary>
        /// <param name="matCode">物料编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="startDate">入库开始时间</param>
        /// <param name="endDate">入库截至时间</param>
        /// <returns></returns>
        public DataSet GetSlabList(string matCode, string stlGrd, string spec, string startDate, string endDate,string slabCK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_SLABWH_CODE,
                                   T.C_BATCH_NO,
                                   T.C_STOVE,
                                   T.C_MAT_CODE,
                                   T.C_MAT_NAME,
                                   T.C_STL_GRD,
                                   T.C_SPEC,
                                   T.N_LEN,
                                   SUM(T.N_WGT) SUMWGT,
                                   SUM(T.N_QUA) SUMQUA,
                                   T.C_STD_CODE, --执行标准
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_JUDGE_LEV_ZH,
                                   T.C_SLABWH_LOC_CODE,
                                   TO_CHAR(T.D_WE_DATE,'YYYY-MM-DD')D_WE_DATE --入库时间           
                              FROM TSC_SLAB_MAIN T
                             WHERE T.C_MOVE_TYPE = 'E'
                               AND T.C_IS_QR = 'Y' AND T.C_SLABWH_CODE='{0}'", slabCK);



            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" AND T.C_MAT_CODE='{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" AND UPPER(T.C_STL_GRD) LIKE '%{0}%'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND T.C_SPEC LIKE '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" AND T.D_WE_DATE BETWEEN TO_DATE('" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.AppendFormat(@"GROUP BY T.C_BATCH_NO,
                                          T.C_STOVE,
                                          T.C_MAT_CODE,
                                          T.C_MAT_NAME,
                                          T.C_STL_GRD,
                                          T.C_SPEC,
                                          T.N_LEN,
                                          T.N_WGT,
                                          T.C_STD_CODE,
                                          T.C_ZYX1,
                                          T.C_ZYX2,
                                          T.C_JUDGE_LEV_ZH,
                                          T.C_SLABWH_CODE,
                                          T.C_SLABWH_LOC_CODE,
                                          T.C_STOCK_STATE,
                                          T.D_WE_DATE");

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region pci
        /// <summary>
        /// 获取钢坯库存数据
        /// </summary>
        /// <param name="C_MOVE_TYPE">状态</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_MAT_CODE">物料号</param>
        /// <param name="C_STD_CODE">执行标准</param>
        /// <param name="C_SLABWH_CODE">仓库</param>
        /// <param name="C_BATCH_NO">开坯号</param>
        /// <param name="C_JUDGE_LEV_ZH">质量等级</param>
        /// <returns></returns>
        public DataSet GetList(string C_MOVE_TYPE, string C_STOVE, string C_MAT_CODE, string C_STD_CODE, string C_SLABWH_CODE, string C_BATCH_NO, string C_JUDGE_LEV_ZH,string zyx1,string zyx2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(N_QUA) N_QUA,SUM(N_QUA) N_SNUM,SUM(N_WGT) N_WGT, C_STOVE,C_STL_GRD,C_MAT_CODE,C_MAT_NAME,C_SPEC,N_LEN,C_STD_CODE,C_SLAB_TYPE,C_SLABWH_CODE,C_SLABWH_AREA_CODE,C_SLABWH_LOC_CODE,C_BATCH_NO,C_JUDGE_LEV_ZH,C_ZYX1,C_ZYX2");
            strSql.Append(" FROM TSC_SLAB_MAIN Where C_JUDGE_LEV_ZH is not null");
            if (C_MOVE_TYPE != "")
            {
                strSql.Append(" AND C_MOVE_TYPE='" + C_MOVE_TYPE + "' ");
            }
            if (C_STOVE.Trim() != "")
            {
                strSql.Append(" AND C_STOVE LIKE '%" + C_STOVE + "%' ");
            }
            if (C_BATCH_NO.Trim() != "")
            {
                strSql.Append(" AND C_BATCH_NO LIKE '%" + C_BATCH_NO + "%' ");
            }
            if (C_MAT_CODE.Trim() != "")
            {
                strSql.Append(" AND C_MAT_CODE LIKE '%" + C_MAT_CODE + "%' ");
            }
            if (!string.IsNullOrWhiteSpace(C_STD_CODE))
            {
                strSql.Append(" AND C_STD_CODE LIKE '%" + C_STD_CODE + "%' ");
            }
            if (C_SLABWH_CODE.Trim() != "")
            {
                strSql.Append(" AND C_SLABWH_CODE ='" + C_SLABWH_CODE + "' ");
            }
            if (C_JUDGE_LEV_ZH.Trim() != "")
            {
                strSql.Append(" AND C_JUDGE_LEV_ZH ='" + C_JUDGE_LEV_ZH + "' ");
            }
            if (zyx1.Trim() != "")
            {
                strSql.Append(" AND C_ZYX1 ='" + zyx1 + "' ");
            }
            if (zyx2.Trim() != "")
            {
                strSql.Append(" AND C_ZYX2 ='" + zyx2 + "' ");
            }
            strSql.Append(" GROUP BY  C_STOVE,C_STL_GRD,C_MAT_CODE,C_MAT_NAME,C_SPEC,N_LEN,C_STD_CODE,C_SLAB_TYPE,C_SLABWH_CODE,C_SLABWH_AREA_CODE,C_SLABWH_LOC_CODE,C_BATCH_NO,C_JUDGE_LEV_ZH,C_ZYX1,C_ZYX2");
            strSql.Append(" ORDER BY  C_BATCH_NO desc,C_STOVE desc");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据发运单号获取数据
        /// </summary>
        /// <param name="C_FYDH">发运单号</param>
        /// <param name="C_MOVE_TYPE">状态</param>
        /// <param name="C_STOVE">炉号</param>
        /// <param name="C_BATCH_NO">批号</param>
        /// <param name="C_SLABWH_CODE">仓库</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetListByFYDH(string C_FYDH, string C_MOVE_TYPE, string C_STOVE, string C_BATCH_NO, string C_SLABWH_CODE,string C_STL_GRD,string C_LIC_PLA_NO,string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_STOVE,a.C_STL_GRD,a.C_MAT_CODE,a.C_MAT_NAME,a.C_SPEC, a.N_LEN, SUM(a.N_QUA)N_QUA,SUM(a.N_WGT)N_WGT,a.C_STD_CODE,a.C_MOVE_TYPE,a.C_SLABWH_CODE,a.C_SLABWH_AREA_CODE,a.C_SLABWH_LOC_CODE,a.C_SLABWH_TIER_CODE,a.N_WGT_METER,a.C_QF_NAME,a.C_DESIGN_NO,a.C_ZRBM,a.C_IS_DEPOT,a.C_ISXM,a.C_XMGX,a.N_JZ,a.C_BATCH_NO,a.C_FYDH,a.C_FYID,a.c_Judge_Lev_Zh,b.C_LIC_PLA_NO,case b.c_Status when '4' then '已导入物流' when '7' then '已做实绩' WHEN '9' then '钢坯实绩已导入NC' end c_STATUS ");
            strSql.Append(" FROM TSC_SLAB_MAIN a, TMD_DISPATCH b where a.c_Fydh = b.c_id  AND a.C_FYDH IS NOT NULL AND b.c_Status='"+ status + "' ");
            if (C_MOVE_TYPE != "")
            {
                strSql.Append(" AND a.C_MOVE_TYPE = '" + C_MOVE_TYPE + "' ");
            }
            if (C_LIC_PLA_NO != "")
            {
                strSql.Append(" AND b.C_LIC_PLA_NO LIKE '%" + C_LIC_PLA_NO + "%' ");
            }
            if (C_FYDH != "")
            {
                strSql.Append(" AND a.C_FYDH LIKE '%" + C_FYDH + "%' ");
            }
            if (C_STOVE != "")
            {
                strSql.Append(" AND a.C_STOVE LIKE'%" + C_STOVE + "%' ");
            }
            if (C_BATCH_NO != "")
            {
                strSql.Append(" AND a.C_BATCH_NO LIKE'%" + C_BATCH_NO + "%' ");
            }
            if (C_SLABWH_CODE.Trim() != "")
            {
                strSql.Append(" AND a.C_SLABWH_CODE in('" + C_SLABWH_CODE + "') ");
            }
            if (C_STL_GRD.Trim() != "")
            {
                strSql.Append(" AND a.C_STL_GRD LIKE'%" + C_STL_GRD + "%' ");
            }
            strSql.Append(" GROUP BY a.C_STOVE,a.C_STL_GRD,a.C_MAT_CODE,a.C_MAT_NAME,a.C_SPEC, a.N_LEN ,a.C_STD_CODE,a.C_MOVE_TYPE,a.C_SLABWH_CODE,a.C_SLABWH_AREA_CODE,a.C_SLABWH_LOC_CODE,a.C_SLABWH_TIER_CODE,a.N_WGT_METER,a.C_QF_NAME,a.C_DESIGN_NO,a.C_ZRBM,a.C_IS_DEPOT,a.C_ISXM,a.C_XMGX,a.N_JZ,a.C_BATCH_NO,a.C_FYDH,a.C_FYID,a.c_Judge_Lev_Zh,c_STATUS,b.C_LIC_PLA_NO");
            strSql.Append(" ORDER BY replace(a.C_FYDH,'DM','') desc ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 检测库存是否变更
        /// </summary>
        /// <param name="mat">物料号</param>
        /// <param name="ck">仓库</param>
        /// <param name="ckarea">区域</param>
        /// <param name="ckloc">库位</param>
        /// <param name="stove">炉号</param>
        /// <param name="batch">批号</param>
        /// <param name="zldj">质量等级</param>
        /// <returns></returns>
        public int CKKC(string mat, string ck,string ckarea,string ckloc, string stove, string batch,string zldj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) N_NUM FROM TSC_SLAB_MAIN WHERE C_MOVE_TYPE='E'");
            if (mat.Trim() != "")
            {
                strSql.Append(" and C_MAT_CODE='" + mat + "'");
            }
            if (ck.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_CODE='" + ck + "'");
            }
            if (ckarea.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_AREA_CODE='" + ckarea +  "'");
            }
            if (ckloc.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_LOC_CODE='" + ckloc + "'");
            }
            if (batch.Trim() != "")
            {
                strSql.Append(" and C_BATCH_NO='" + batch + "'");
            }
            if (stove.Trim() != "")
            {
                strSql.Append(" and C_STOVE='" + stove + "'");
            }
            if (stove.Trim() != "")
            {
                strSql.Append(" and C_STOVE='" + stove + "'");
            }
            if (zldj.Trim() != "")
            {
                strSql.Append(" and C_JUDGE_LEV_ZH='" + zldj + "'");
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
        /// 修改钢坯状态
        /// </summary>
        /// <param name="list">List<CommonKC>通用库存处理类</param>
        /// <param name="status">状态</param>
        /// <returns>0失败1成功</returns>
        public int UPSLABSTATUS(List<CommonKC> list, string fydh,string status)
        {
            TransactionHelper.BeginTransaction();
            foreach (CommonKC item in list)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE TSC_SLAB_MAIN   SET C_MOVE_TYPE='" + status + "',C_FYDH='" + fydh + "' ,C_FYID='"+item.id+"' WHERE C_MOVE_TYPE='E'");
                if (item.mat.Trim() != "")
                {
                    strSql.Append(" and C_MAT_CODE='" + item.mat + "'");
                }
                if (item.ck.Trim() != "")
                {
                    strSql.Append(" and C_SLABWH_CODE='" + item.ck + "'");
                }
              
                if (item.batch.Trim() != "")
                {
                    strSql.Append(" and C_BATCH_NO='" + item.batch + "'");
                }
                if (item.stove.Trim() != "")
                {
                    strSql.Append(" and C_STOVE='" + item.stove + "'");
                }
                strSql.Append(" and ROWNUM<='" + item.num + "'");
                if (TransactionHelper.ExecuteSql(strSql.ToString()) != item.num)
                {
                    TransactionHelper.RollBack();
                    return 0;
                }
            }
            TransactionHelper.Commit();
            return 1;
        }
        /// <summary>
        /// 根据发运单号获取已做实绩数量
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public int GetSJCount(string fydh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TSC_SLAB_MAIN WHERE C_MOVE_TYPE='1'");
            if (fydh.Trim() != "")
            {
                strSql.Append(" AND C_FYDH='" + fydh + "' ");
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
        /// 根据发运单号获取该发运单计划总数
        /// </summary>
        /// <param name="fydh">发运单号</param>
        /// <returns></returns>
        public int GetJHCount(string fydh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(N_FYZS) FROM TMD_DISPATCHDETAILS WHERE 1=1");
            if (fydh.Trim() != "")
            {
                strSql.Append(" AND C_DISPATCH_ID='" + fydh + "' ");
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
        #endregion
    }
}

