using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections.Generic;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TRC_ROLL_MAIN
    /// </summary>
    public partial class Dal_TRC_ROLL_MAIN
    {
        public Dal_TRC_ROLL_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TRC_ROLL_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add_Tran(Mod_TRC_ROLL_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_MAIN(");
            strSql.Append("C_ID,C_STA_ID,C_PLANT,C_STOVE,C_BATCH_NO,C_PLAN_ID,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,N_QUA_RETRUN,N_WGT_RETRUN,N_QUA_JOIN,N_WGT_JOIN,N_QUA_EXIT,N_WGT_EXIT,N_QUA_CPHALF,N_WGT_HALF,N_QUA_CPWHOLE,N_WGT_CPWHOLE,C_FUR_TYPE,N_QUA_ELIM,N_WGT_ELIM,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,C_STL_GRD,C_SPEC,C_SLAB_NUM,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,N_QUA_TOTAL_VIRTUAL,N_WGT_TOTAL_VIRTUAL)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_STA_ID,:C_PLANT,:C_STOVE,:C_BATCH_NO,:C_PLAN_ID,:N_QUA_TOTAL,:N_WGT_TOTAL,:C_STL_GRD_SLAB,:C_SPEC_SLAB,:C_EMP_ID,:C_SHIFT,:C_GROUP,:D_MOD_DT,:N_QUA_REMOVE,:N_WGT_REMOVE,:N_QUA_RETRUN,:N_WGT_RETRUN,:N_QUA_JOIN,:N_WGT_JOIN,:N_QUA_EXIT,:N_WGT_EXIT,:N_QUA_CPHALF,:N_WGT_HALF,:N_QUA_CPWHOLE,:N_WGT_CPWHOLE,:C_FUR_TYPE,:N_QUA_ELIM,:N_WGT_ELIM,:C_MAT_SLAB_CODE,:C_MAT_SLAB_NAME,:C_REMARK,:N_STATUS,:C_STD_CODE,:C_STL_GRD,:C_SPEC,:C_SLAB_NUM,:D_PRODUCE_DATE_B,:C_PRODUCE_EMP_ID,:C_PRODUCE_SHIFT,:C_PRODUCE_GROUP,:D_PRODUCE_DATE_E,:N_QUA_TOTAL_VIRTUAL,:N_WGT_TOTAL_VIRTUAL)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_GRD_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_QUA_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPHALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_HALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":C_FUR_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_SLAB_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_SLAB_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_NUM", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_B", OracleDbType.Date),
                    new OracleParameter(":C_PRODUCE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_E", OracleDbType.Date),
                    new OracleParameter(":N_QUA_TOTAL_VIRTUAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL_VIRTUAL",OracleDbType.Decimal,15)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STA_ID;
            parameters[2].Value = model.C_PLANT;
            parameters[3].Value = model.C_STOVE;
            parameters[4].Value = model.C_BATCH_NO;
            parameters[5].Value = model.C_PLAN_ID;
            parameters[6].Value = model.N_QUA_TOTAL;
            parameters[7].Value = model.N_WGT_TOTAL;
            parameters[8].Value = model.C_STL_GRD_SLAB;
            parameters[9].Value = model.C_SPEC_SLAB;
            parameters[10].Value = model.C_EMP_ID;
            parameters[11].Value = model.C_SHIFT;
            parameters[12].Value = model.C_GROUP;
            parameters[13].Value = model.D_MOD_DT;
            parameters[14].Value = model.N_QUA_REMOVE;
            parameters[15].Value = model.N_WGT_REMOVE;
            parameters[16].Value = model.N_QUA_RETRUN;
            parameters[17].Value = model.N_WGT_RETRUN;
            parameters[18].Value = model.N_QUA_JOIN;
            parameters[19].Value = model.N_WGT_JOIN;
            parameters[20].Value = model.N_QUA_EXIT;
            parameters[21].Value = model.N_WGT_EXIT;
            parameters[22].Value = model.N_QUA_CPHALF;
            parameters[23].Value = model.N_WGT_HALF;
            parameters[24].Value = model.N_QUA_CPWHOLE;
            parameters[25].Value = model.N_WGT_CPWHOLE;
            parameters[26].Value = model.C_FUR_TYPE;
            parameters[27].Value = model.N_QUA_ELIM;
            parameters[28].Value = model.N_WGT_ELIM;
            parameters[29].Value = model.C_MAT_SLAB_CODE;
            parameters[30].Value = model.C_MAT_SLAB_NAME;
            parameters[31].Value = model.C_REMARK;
            parameters[32].Value = model.N_STATUS;
            parameters[33].Value = model.C_STD_CODE;
            parameters[34].Value = model.C_STL_GRD;
            parameters[35].Value = model.C_SPEC;
            parameters[36].Value = model.C_SLAB_NUM;
            parameters[37].Value = model.D_PRODUCE_DATE_B;
            parameters[38].Value = model.C_PRODUCE_EMP_ID;
            parameters[39].Value = model.C_PRODUCE_SHIFT;
            parameters[40].Value = model.C_PRODUCE_GROUP;
            parameters[41].Value = model.D_PRODUCE_DATE_E;
            parameters[42].Value = model.N_QUA_TOTAL_VIRTUAL;
            parameters[43].Value = model.N_WGT_TOTAL_VIRTUAL;

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
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TRC_ROLL_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TRC_ROLL_MAIN(");
            strSql.Append(" C_STA_ID,C_PLANT,C_STOVE,C_BATCH_NO,C_PLAN_ID,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,N_QUA_RETRUN,N_WGT_RETRUN,N_QUA_JOIN,N_WGT_JOIN,N_QUA_EXIT,N_WGT_EXIT,N_QUA_CPHALF,N_WGT_HALF,N_QUA_CPWHOLE,N_WGT_CPWHOLE,C_FUR_TYPE,N_QUA_ELIM,N_WGT_ELIM,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,C_STL_GRD,C_SPEC,C_SLAB_NUM,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,N_QUA_TOTAL_VIRTUAL,N_WGT_TOTAL_VIRTUAL)");
            strSql.Append(" values (");
            strSql.Append(":C_STA_ID,:C_PLANT,:C_STOVE,:C_BATCH_NO,:C_PLAN_ID,:N_QUA_TOTAL,:N_WGT_TOTAL,:C_STL_GRD_SLAB,:C_SPEC_SLAB,:C_EMP_ID,:C_SHIFT,:C_GROUP,:D_MOD_DT,:N_QUA_REMOVE,:N_WGT_REMOVE,:N_QUA_RETRUN,:N_WGT_RETRUN,:N_QUA_JOIN,:N_WGT_JOIN,:N_QUA_EXIT,:N_WGT_EXIT,:N_QUA_CPHALF,:N_WGT_HALF,:N_QUA_CPWHOLE,:N_WGT_CPWHOLE,:C_FUR_TYPE,:N_QUA_ELIM,:N_WGT_ELIM,:C_MAT_SLAB_CODE,:C_MAT_SLAB_NAME,:C_REMARK,:N_STATUS,:C_STD_CODE,:C_STL_GRD,:C_SPEC,:C_SLAB_NUM,:D_PRODUCE_DATE_B,:C_PRODUCE_EMP_ID,:C_PRODUCE_SHIFT,:C_PRODUCE_GROUP,:D_PRODUCE_DATE_E,:N_QUA_TOTAL_VIRTUAL,:N_WGT_TOTAL_VIRTUAL)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_GRD_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_QUA_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPHALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_HALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":C_FUR_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_SLAB_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_SLAB_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_NUM", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_B", OracleDbType.Date),
                    new OracleParameter(":C_PRODUCE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_E", OracleDbType.Date),
                    new OracleParameter(":N_QUA_TOTAL_VIRTUAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL_VIRTUAL",OracleDbType.Decimal,15)};
            parameters[0].Value = model.C_STA_ID;
            parameters[1].Value = model.C_PLANT;
            parameters[2].Value = model.C_STOVE;
            parameters[3].Value = model.C_BATCH_NO;
            parameters[4].Value = model.C_PLAN_ID;
            parameters[5].Value = model.N_QUA_TOTAL;
            parameters[6].Value = model.N_WGT_TOTAL;
            parameters[7].Value = model.C_STL_GRD_SLAB;
            parameters[8].Value = model.C_SPEC_SLAB;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.C_SHIFT;
            parameters[11].Value = model.C_GROUP;
            parameters[12].Value = model.D_MOD_DT;
            parameters[13].Value = model.N_QUA_REMOVE;
            parameters[14].Value = model.N_WGT_REMOVE;
            parameters[15].Value = model.N_QUA_RETRUN;
            parameters[16].Value = model.N_WGT_RETRUN;
            parameters[17].Value = model.N_QUA_JOIN;
            parameters[18].Value = model.N_WGT_JOIN;
            parameters[19].Value = model.N_QUA_EXIT;
            parameters[20].Value = model.N_WGT_EXIT;
            parameters[21].Value = model.N_QUA_CPHALF;
            parameters[22].Value = model.N_WGT_HALF;
            parameters[23].Value = model.N_QUA_CPWHOLE;
            parameters[24].Value = model.N_WGT_CPWHOLE;
            parameters[25].Value = model.C_FUR_TYPE;
            parameters[26].Value = model.N_QUA_ELIM;
            parameters[27].Value = model.N_WGT_ELIM;
            parameters[28].Value = model.C_MAT_SLAB_CODE;
            parameters[29].Value = model.C_MAT_SLAB_NAME;
            parameters[30].Value = model.C_REMARK;
            parameters[31].Value = model.N_STATUS;
            parameters[32].Value = model.C_STD_CODE;
            parameters[33].Value = model.C_STL_GRD;
            parameters[34].Value = model.C_SPEC;
            parameters[35].Value = model.C_SLAB_NUM;
            parameters[36].Value = model.D_PRODUCE_DATE_B;
            parameters[37].Value = model.C_PRODUCE_EMP_ID;
            parameters[38].Value = model.C_PRODUCE_SHIFT;
            parameters[39].Value = model.C_PRODUCE_GROUP;
            parameters[40].Value = model.D_PRODUCE_DATE_E;
            parameters[41].Value = model.N_QUA_TOTAL_VIRTUAL;
            parameters[42].Value = model.N_WGT_TOTAL_VIRTUAL;
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
        public bool Update(Mod_TRC_ROLL_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TRC_ROLL_MAIN set ");
            strSql.Append("C_STA_ID=:C_STA_ID,");
            strSql.Append("C_PLANT=:C_PLANT,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_PLAN_ID=:C_PLAN_ID,");
            strSql.Append("N_QUA_TOTAL=:N_QUA_TOTAL,");
            strSql.Append("N_WGT_TOTAL=:N_WGT_TOTAL,");
            strSql.Append("C_STL_GRD_SLAB=:C_STL_GRD_SLAB,");
            strSql.Append("C_SPEC_SLAB=:C_SPEC_SLAB,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_SHIFT=:C_SHIFT,");
            strSql.Append("C_GROUP=:C_GROUP,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_QUA_REMOVE=:N_QUA_REMOVE,");
            strSql.Append("N_WGT_REMOVE=:N_WGT_REMOVE,");
            strSql.Append("N_QUA_RETRUN=:N_QUA_RETRUN,");
            strSql.Append("N_WGT_RETRUN=:N_WGT_RETRUN,");
            strSql.Append("N_QUA_JOIN=:N_QUA_JOIN,");
            strSql.Append("N_WGT_JOIN=:N_WGT_JOIN,");
            strSql.Append("N_QUA_EXIT=:N_QUA_EXIT,");
            strSql.Append("N_WGT_EXIT=:N_WGT_EXIT,");
            strSql.Append("N_QUA_CPHALF=:N_QUA_CPHALF,");
            strSql.Append("N_WGT_HALF=:N_WGT_HALF,");
            strSql.Append("N_QUA_CPWHOLE=:N_QUA_CPWHOLE,");
            strSql.Append("N_WGT_CPWHOLE=:N_WGT_CPWHOLE,");
            strSql.Append("C_ROLL_STATE=:C_ROLL_STATE,");
            strSql.Append("C_FUR_TYPE=:C_FUR_TYPE,");
            strSql.Append("N_QUA_ELIM=:N_QUA_ELIM,");
            strSql.Append("N_WGT_ELIM=:N_WGT_ELIM,");
            strSql.Append("C_MAT_SLAB_CODE=:C_MAT_SLAB_CODE,");
            strSql.Append("C_MAT_SLAB_NAME=:C_MAT_SLAB_NAME,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_SLAB_NUM=:C_SLAB_NUM,");
            strSql.Append("D_PRODUCE_DATE_B=:D_PRODUCE_DATE_B,");
            strSql.Append("C_PRODUCE_EMP_ID=:C_PRODUCE_EMP_ID,");
            strSql.Append("C_PRODUCE_SHIFT=:C_PRODUCE_SHIFT,");
            strSql.Append("C_PRODUCE_GROUP=:C_PRODUCE_GROUP,");
            strSql.Append("D_PRODUCE_DATE_E=:D_PRODUCE_DATE_E,");
            strSql.Append("N_QUA_TOTAL_VIRTUAL=:N_QUA_TOTAL_VIRTUAL,");
            strSql.Append("N_WGT_TOTAL_VIRTUAL=:N_WGT_TOTAL_VIRTUAL");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STA_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLANT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STL_GRD_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC_SLAB", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_QUA_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_REMOVE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_RETRUN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_JOIN",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_EXIT",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPHALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_HALF",OracleDbType.Decimal,15),
                    new OracleParameter(":N_QUA_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_CPWHOLE",OracleDbType.Decimal,15),
                    new OracleParameter(":C_ROLL_STATE",OracleDbType.Decimal,15),
                    new OracleParameter(":C_FUR_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_QUA_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_ELIM",OracleDbType.Decimal,15),
                    new OracleParameter(":C_MAT_SLAB_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_SLAB_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":N_STATUS",OracleDbType.Decimal,15),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_NUM", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_B", OracleDbType.Date),
                    new OracleParameter(":C_PRODUCE_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_SHIFT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCE_GROUP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PRODUCE_DATE_E", OracleDbType.Date),
                    new OracleParameter(":N_QUA_TOTAL_VIRTUAL",OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT_TOTAL_VIRTUAL",OracleDbType.Decimal,15),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_STA_ID;
            parameters[1].Value = model.C_PLANT;
            parameters[2].Value = model.C_STOVE;
            parameters[3].Value = model.C_BATCH_NO;
            parameters[4].Value = model.C_PLAN_ID;
            parameters[5].Value = model.N_QUA_TOTAL;
            parameters[6].Value = model.N_WGT_TOTAL;
            parameters[7].Value = model.C_STL_GRD_SLAB;
            parameters[8].Value = model.C_SPEC_SLAB;
            parameters[9].Value = model.C_EMP_ID;
            parameters[10].Value = model.C_SHIFT;
            parameters[11].Value = model.C_GROUP;
            parameters[12].Value = model.D_MOD_DT;
            parameters[13].Value = model.N_QUA_REMOVE;
            parameters[14].Value = model.N_WGT_REMOVE;
            parameters[15].Value = model.N_QUA_RETRUN;
            parameters[16].Value = model.N_WGT_RETRUN;
            parameters[17].Value = model.N_QUA_JOIN;
            parameters[18].Value = model.N_WGT_JOIN;
            parameters[19].Value = model.N_QUA_EXIT;
            parameters[20].Value = model.N_WGT_EXIT;
            parameters[21].Value = model.N_QUA_CPHALF;
            parameters[22].Value = model.N_WGT_HALF;
            parameters[23].Value = model.N_QUA_CPWHOLE;
            parameters[24].Value = model.N_WGT_CPWHOLE;
            parameters[25].Value = model.C_ROLL_STATE;
            parameters[26].Value = model.C_FUR_TYPE;
            parameters[27].Value = model.N_QUA_ELIM;
            parameters[28].Value = model.N_WGT_ELIM;
            parameters[29].Value = model.C_MAT_SLAB_CODE;
            parameters[30].Value = model.C_MAT_SLAB_NAME;
            parameters[31].Value = model.C_REMARK;
            parameters[32].Value = model.N_STATUS;
            parameters[33].Value = model.C_STD_CODE;
            parameters[34].Value = model.C_STL_GRD;
            parameters[35].Value = model.C_SPEC;
            parameters[36].Value = model.C_SLAB_NUM;
            parameters[37].Value = model.D_PRODUCE_DATE_B;
            parameters[38].Value = model.C_PRODUCE_EMP_ID;
            parameters[39].Value = model.C_PRODUCE_SHIFT;
            parameters[40].Value = model.C_PRODUCE_GROUP;
            parameters[41].Value = model.D_PRODUCE_DATE_E;
            parameters[42].Value = model.N_QUA_TOTAL_VIRTUAL;
            parameters[43].Value = model.N_WGT_TOTAL_VIRTUAL;
            parameters[44].Value = model.C_ID;

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
            strSql.Append("delete from TRC_ROLL_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string C_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TRC_ROLL_MAIN ");
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
        public Mod_TRC_ROLL_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STA_ID,C_PLANT,C_STOVE,C_BATCH_NO,C_PLAN_ID,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,N_QUA_RETRUN,N_WGT_RETRUN,N_QUA_JOIN,N_WGT_JOIN,N_QUA_EXIT,N_WGT_EXIT,N_QUA_CPHALF,N_WGT_HALF,N_QUA_CPWHOLE,N_WGT_CPWHOLE,C_ROLL_STATE,C_FUR_TYPE,N_QUA_ELIM,N_WGT_ELIM,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,C_STL_GRD,C_SPEC,C_SLAB_NUM,D_PRODUCE_DATE_B,C_PRODUCE_EMP_ID,C_PRODUCE_SHIFT,C_PRODUCE_GROUP,D_PRODUCE_DATE_E,N_QUA_TOTAL_VIRTUAL,N_WGT_TOTAL_VIRTUAL   from TRC_ROLL_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TRC_ROLL_MAIN model = new Mod_TRC_ROLL_MAIN();
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
        public Mod_TRC_ROLL_MAIN DataRowToModel(DataRow row)
        {
            Mod_TRC_ROLL_MAIN model = new Mod_TRC_ROLL_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_STA_ID"] != null)
                {
                    model.C_STA_ID = row["C_STA_ID"].ToString();
                }
                if (row["C_PLANT"] != null)
                {
                    model.C_PLANT = row["C_PLANT"].ToString();
                }
                if (row["C_STOVE"] != null)
                {
                    model.C_STOVE = row["C_STOVE"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_PLAN_ID"] != null)
                {
                    model.C_PLAN_ID = row["C_PLAN_ID"].ToString();
                }
                if (row["N_QUA_TOTAL"] != null && row["N_QUA_TOTAL"].ToString() != "")
                {
                    model.N_QUA_TOTAL = decimal.Parse(row["N_QUA_TOTAL"].ToString());
                }
                if (row["N_WGT_TOTAL"] != null && row["N_WGT_TOTAL"].ToString() != "")
                {
                    model.N_WGT_TOTAL = decimal.Parse(row["N_WGT_TOTAL"].ToString());
                }
                if (row["C_STL_GRD_SLAB"] != null)
                {
                    model.C_STL_GRD_SLAB = row["C_STL_GRD_SLAB"].ToString();
                }
                if (row["C_SPEC_SLAB"] != null)
                {
                    model.C_SPEC_SLAB = row["C_SPEC_SLAB"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_SHIFT"] != null)
                {
                    model.C_SHIFT = row["C_SHIFT"].ToString();
                }
                if (row["C_GROUP"] != null)
                {
                    model.C_GROUP = row["C_GROUP"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["N_QUA_REMOVE"] != null && row["N_QUA_REMOVE"].ToString() != "")
                {
                    model.N_QUA_REMOVE = decimal.Parse(row["N_QUA_REMOVE"].ToString());
                }
                if (row["N_WGT_REMOVE"] != null && row["N_WGT_REMOVE"].ToString() != "")
                {
                    model.N_WGT_REMOVE = decimal.Parse(row["N_WGT_REMOVE"].ToString());
                }
                if (row["N_QUA_RETRUN"] != null && row["N_QUA_RETRUN"].ToString() != "")
                {
                    model.N_QUA_RETRUN = decimal.Parse(row["N_QUA_RETRUN"].ToString());
                }
                if (row["N_WGT_RETRUN"] != null && row["N_WGT_RETRUN"].ToString() != "")
                {
                    model.N_WGT_RETRUN = decimal.Parse(row["N_WGT_RETRUN"].ToString());
                }
                if (row["N_QUA_JOIN"] != null && row["N_QUA_JOIN"].ToString() != "")
                {
                    model.N_QUA_JOIN = decimal.Parse(row["N_QUA_JOIN"].ToString());
                }
                if (row["N_WGT_JOIN"] != null && row["N_WGT_JOIN"].ToString() != "")
                {
                    model.N_WGT_JOIN = decimal.Parse(row["N_WGT_JOIN"].ToString());
                }
                if (row["N_QUA_EXIT"] != null && row["N_QUA_EXIT"].ToString() != "")
                {
                    model.N_QUA_EXIT = decimal.Parse(row["N_QUA_EXIT"].ToString());
                }
                if (row["N_WGT_EXIT"] != null && row["N_WGT_EXIT"].ToString() != "")
                {
                    model.N_WGT_EXIT = decimal.Parse(row["N_WGT_EXIT"].ToString());
                }
                if (row["N_QUA_CPHALF"] != null && row["N_QUA_CPHALF"].ToString() != "")
                {
                    model.N_QUA_CPHALF = decimal.Parse(row["N_QUA_CPHALF"].ToString());
                }
                if (row["N_WGT_HALF"] != null && row["N_WGT_HALF"].ToString() != "")
                {
                    model.N_WGT_HALF = decimal.Parse(row["N_WGT_HALF"].ToString());
                }
                if (row["N_QUA_CPWHOLE"] != null && row["N_QUA_CPWHOLE"].ToString() != "")
                {
                    model.N_QUA_CPWHOLE = decimal.Parse(row["N_QUA_CPWHOLE"].ToString());
                }
                if (row["N_WGT_CPWHOLE"] != null && row["N_WGT_CPWHOLE"].ToString() != "")
                {
                    model.N_WGT_CPWHOLE = decimal.Parse(row["N_WGT_CPWHOLE"].ToString());
                }
                if (row["C_ROLL_STATE"] != null && row["C_ROLL_STATE"].ToString() != "")
                {
                    model.C_ROLL_STATE = decimal.Parse(row["C_ROLL_STATE"].ToString());
                }
                if (row["C_FUR_TYPE"] != null)
                {
                    model.C_FUR_TYPE = row["C_FUR_TYPE"].ToString();
                }
                if (row["N_QUA_ELIM"] != null && row["N_QUA_ELIM"].ToString() != "")
                {
                    model.N_QUA_ELIM = decimal.Parse(row["N_QUA_ELIM"].ToString());
                }
                if (row["N_WGT_ELIM"] != null && row["N_WGT_ELIM"].ToString() != "")
                {
                    model.N_WGT_ELIM = decimal.Parse(row["N_WGT_ELIM"].ToString());
                }
                if (row["C_MAT_SLAB_CODE"] != null)
                {
                    model.C_MAT_SLAB_CODE = row["C_MAT_SLAB_CODE"].ToString();
                }
                if (row["C_MAT_SLAB_NAME"] != null)
                {
                    model.C_MAT_SLAB_NAME = row["C_MAT_SLAB_NAME"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_SLAB_NUM"] != null)
                {
                    model.C_SLAB_NUM = row["C_SLAB_NUM"].ToString();
                }
                if (row["D_PRODUCE_DATE_B"] != null && row["D_PRODUCE_DATE_B"].ToString() != "")
                {
                    model.D_PRODUCE_DATE_B = DateTime.Parse(row["D_PRODUCE_DATE_B"].ToString());
                }
                if (row["C_PRODUCE_EMP_ID"] != null)
                {
                    model.C_PRODUCE_EMP_ID = row["C_PRODUCE_EMP_ID"].ToString();
                }
                if (row["C_PRODUCE_SHIFT"] != null)
                {
                    model.C_PRODUCE_SHIFT = row["C_PRODUCE_SHIFT"].ToString();
                }
                if (row["C_PRODUCE_GROUP"] != null)
                {
                    model.C_PRODUCE_GROUP = row["C_PRODUCE_GROUP"].ToString();
                }
                if (row["D_PRODUCE_DATE_E"] != null && row["D_PRODUCE_DATE_E"].ToString() != "")
                {
                    model.D_PRODUCE_DATE_E = DateTime.Parse(row["D_PRODUCE_DATE_E"].ToString());
                }
                if (row["N_QUA_TOTAL_VIRTUAL"] != null && row["N_QUA_TOTAL_VIRTUAL"].ToString() != "")
                {
                    model.N_QUA_TOTAL_VIRTUAL = decimal.Parse(row["N_QUA_TOTAL_VIRTUAL"].ToString());
                }
                if (row["N_WGT_TOTAL_VIRTUAL"] != null && row["N_WGT_TOTAL_VIRTUAL"].ToString() != "")
                {
                    model.N_WGT_TOTAL_VIRTUAL = decimal.Parse(row["N_WGT_TOTAL_VIRTUAL"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="IsOrderDesc">排序 </param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, bool IsOrderDesc)
        {
            string sql = @"SELECT 
                                    MAX( TRM.C_ID) C_ID,
                                    MAX(TWF.C_TRC_ROLL_MAIN_ID) C_TRC_ROLL_MAIN_ID,
                                    MAX( TRM.C_STA_ID) C_STA_ID,
                                    MAX( TRM.C_STL_GRD_SLAB) C_STL_GRD_SLAB,
                                    MAX( TRM.C_SPEC_SLAB) C_SPEC_SLAB,
                                    MAX( TRM.C_MAT_SLAB_CODE) C_MAT_SLAB_CODE,
                                    MAX(TA.C_STA_CODE)C_STA_CODE,
                                    MAX(TA.C_STA_DESC)C_STA_DESC,
                                    TRM.C_BATCH_NO,
                                    COUNT(TWF.C_ID) N_QUA_JOIN,
                                    COUNT(TWF.C_ID)*2 N_WGT_JOIN,     
                                    MAX(TWF.C_EMP_ID)C_EMP_ID,
                                    MAX(TWF.D_MOD_DT)D_MOD_DT,
                                    MAX(TWF.C_SHIFT)C_SHIFT,
                                    MAX(TWF.C_GROUP)C_GROUP,     
                                    MAX(TRM.C_STD_CODE)C_STD_CODE,
                                    MAX(TRM.C_STL_GRD)C_STL_GRD,
                                    MAX(TRM.C_SPEC)C_SPEC，
                                    MAX(TPR.C_MAT_CODE )C_MAT_CODE,
                                    MAX(TRM.C_REMARK)C_REMARK
                               FROM TRC_ROLL_MAIN TRM
                               JOIN TRC_WARM_FURNACE TWF
                                 ON TWF.C_TRC_ROLL_MAIN_ID = TRM.C_ID
                               LEFT JOIN TS_USER TU
                                 ON TU.C_ID = TWF.C_EMP_ID
                               LEFT JOIN TB_STA TA
                                 ON TA.C_ID = TRM.C_STA_ID
                               LEFT JOIN TRP_PLAN_ROLL TPR 
                                 ON TPR.C_ID=TRM.C_PLAN_ID
                                     ";

            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }

            sql += "    GROUP BY TRM.C_BATCH_NO    ";

            if (IsOrderDesc)
                sql += "  ORDER BY TRM.C_BATCH_NO  ";
            else
                sql += "  ORDER BY TRM.C_BATCH_NO   DESC ";

            return DbHelperOra.Query(sql);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="IsOrderDesc">排序 </param>
        /// <returns></returns>
        public DataSet GetListMain(string strWhere, bool IsOrderDesc)
        {
            string sql = @"SELECT
                                    TRM.C_ID,
                                    TRM.C_STA_ID,
                                    TRM.C_PLANT,
                                    TRM.C_STOVE,
                                    TRM.C_BATCH_NO,
                                    TRM.C_PLAN_ID,
                                    TRM.N_QUA_TOTAL,
                                    TRM.N_WGT_TOTAL,
                                    TRM.C_STL_GRD_SLAB,
                                    TRM.C_SPEC_SLAB,
                                    TU.C_NAME C_EMP_ID,
                                    TRM.C_SHIFT,
                                    TRM.C_GROUP,
                                    TRM.D_MOD_DT,
                                    TRM.N_QUA_REMOVE,
                                    TRM.N_WGT_REMOVE,
                                    TRM.N_QUA_RETRUN,
                                    TRM.N_WGT_RETRUN,
                                    TRM.N_QUA_JOIN,
                                    TRM.N_WGT_JOIN,
                                    TRM.N_QUA_EXIT,
                                    TRM.N_WGT_EXIT,
                                    TRM.N_QUA_CPHALF,
                                    TRM.N_WGT_HALF,
                                    TRM.N_QUA_CPWHOLE,
                                    TRM.N_WGT_CPWHOLE,
                                    TRM.C_ROLL_STATE,
                                    TRM.C_FUR_TYPE,
                                    TRM.N_QUA_ELIM,
                                    TRM.N_WGT_ELIM,
                                    TRM.C_MAT_SLAB_CODE,
                                    TRM.C_MAT_SLAB_NAME,
                                    TRM.C_REMARK,
                                    TRM.N_STATUS,
                                    TRM.C_STD_CODE,
                                    TRM.C_STL_GRD,
                                    TRM.C_SPEC,
                                    TA.C_STA_CODE,
                                    TA.C_STA_DESC,
                                    TPR.C_MAT_CODE,
                                    TRM.N_QUA_TOTAL_VIRTUAL,
                                    TRM.N_WGT_TOTAL_VIRTUAL
                                    FROM TRC_ROLL_MAIN TRM
                                    LEFT JOIN TS_USER TU ON TU.C_ID=TRM.C_EMP_ID
                                    LEFT JOIN TB_STA TA ON TA.C_ID=TRM.C_STA_ID
                                    LEFT JOIN TRP_PLAN_ROLL TPR    ON TPR.C_ID=TRM.C_PLAN_ID
                                    WHERE TRM.N_STATUS = 1 ";

            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }

            if (IsOrderDesc)
                sql += "  ORDER BY TRM.C_BATCH_NO   ";
            else
                sql += "  ORDER BY TRM.C_BATCH_NO  DESC ";

            return DbHelperOra.Query(sql);
        }



        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TRC_ROLL_MAIN ");
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
            strSql.Append(")AS Row, T.*  from TRC_ROLL_MAIN T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取最大批号
        /// </summary>
        public string GetMaxPH(string c_sta_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(t.c_batch_no)+1 as c_batch_no from trc_roll_main t where t.c_sta_id='" + c_sta_id + "' ");

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

        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        ///根据计划id，批号获取数据列表
        /// </summary>
        public DataSet GetListByPidAndBid(string C_PLAN_ID, string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STA_ID,C_PLANT,C_STOVE,C_BATCH_NO,C_PLAN_ID,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,N_QUA_RETRUN,N_WGT_RETRUN,N_QUA_JOIN,N_WGT_JOIN,N_QUA_EXIT,N_WGT_EXIT,N_QUA_CPHALF,N_WGT_HALF,N_QUA_CPWHOLE,N_WGT_CPWHOLE,C_ROLL_STATE,C_FUR_TYPE,N_QUA_ELIM,N_WGT_ELIM,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,C_STL_GRD,C_SPEC");
            strSql.Append(" FROM TRC_ROLL_MAIN WHERE 1=1");

            if (C_PLAN_ID != "")
            {
                strSql.Append(" AND C_PLAN_ID='" + C_PLAN_ID + "' ");
            }
            if (C_BATCH_NO != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "' ");
            }

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        ///根据 批号获取数据列表
        /// </summary>
        public DataSet GetList_Batch(string C_BATCH_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STA_ID,C_PLANT,C_STOVE,C_BATCH_NO,C_PLAN_ID,N_QUA_TOTAL,N_WGT_TOTAL,C_STL_GRD_SLAB,C_SPEC_SLAB,C_EMP_ID,C_SHIFT,C_GROUP,D_MOD_DT,N_QUA_REMOVE,N_WGT_REMOVE,N_QUA_RETRUN,N_WGT_RETRUN,N_QUA_JOIN,N_WGT_JOIN,N_QUA_EXIT,N_WGT_EXIT,N_QUA_CPHALF,N_WGT_HALF,N_QUA_CPWHOLE,N_WGT_CPWHOLE,C_ROLL_STATE,C_FUR_TYPE,N_QUA_ELIM,N_WGT_ELIM,C_MAT_SLAB_CODE,C_MAT_SLAB_NAME,C_REMARK,N_STATUS,C_STD_CODE,C_STL_GRD,C_SPEC");
            strSql.Append(" FROM TRC_ROLL_MAIN WHERE 1=1");

            if (C_BATCH_NO != "")
            {
                strSql.Append(" AND C_BATCH_NO='" + C_BATCH_NO + "' ");
            }

            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取线材实绩信息
        /// </summary>
        /// <param name="begin">组批时间 开始</param>
        /// <param name="end">组批时间 结束</param>
        /// <param name="pland">车间</param>
        /// <param name="batch">批号</param>
        /// <returns></returns>
        public DataSet GetProductList(DateTime begin, DateTime end, string pland, string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.c_sta_id,a.c_sta_desc,T.N_STATUS, t.N_QUA_TOTAL_VIRTUAL, t.n_wgt_total_virtual , t.C_STOVE, t.C_BATCH_NO,  t.C_STL_GRD, t.C_STD_CODE, t.C_SPEC, t.C_SHIFT, t.C_GROUP, t.C_ID , t.D_MOD_DT,t.C_REMARK  ");
            strSql.Append(" from TRC_ROLL_MAIN t JOIN TB_STA a on t.c_sta_id=a.c_id where T.N_STATUS=1 ");
            if (begin != null && end != null)
            {
                strSql.Append("and t.D_MOD_DT between to_date('" + Convert.ToDateTime(begin) + "','yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(end) + "','yyyy-mm-dd hh24:mi:ss') ");
            }
            if (pland != "全部")
            {
                strSql.Append(" and a.c_sta_desc ='" + pland + "' ");
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.Append(" and t.C_BATCH_NO ='" + batch + "' ");
            }
            strSql.Append("  order by t.D_MOD_DT ");

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 生成批号
        /// </summary>
        /// <returns></returns>
        public string CreateBranchNo(string staID)
        {
            string querySql = @"SELECT  T.N_FLAG from TB_STA T
                                               WHERE T.C_ID='" + staID + "'";
            object lineObj = DbHelperOra.GetSingle(querySql);


            string sql = @"SELECT * FROM 
                                    (
                                    SELECT  TRM.C_BATCH_NO FROM TRC_ROLL_MAIN TRM 
                                    WHERE   TRM.C_STA_ID='" + staID + "' ";
            sql += @" ORDER BY TRM.C_BATCH_NO DESC
                                    )
                                    WHERE rownum=1";
            var obj = DbHelperOra.GetSingle(sql);
            string no = "";

            if (obj != null)
                no = obj.ToString();

            int year = DateTime.Now.Year;
            if (!string.IsNullOrWhiteSpace(no))
            {
                no = string.Format("3{2}{0}{1}", year.ToString().Substring(2), ReCombine(no), lineObj.ToString());
            }
            else
            {
                no = string.Format("3{1}{0}00001", year.ToString().Substring(2), lineObj.ToString());
            }
            return no;
        }

        /// <summary>
        /// 生成批号(撤回)
        /// </summary>
        /// <returns></returns>
        public string CreateBranchNo(int type)
        {
            string sql = @"SELECT * FROM 
                                    (
                                    SELECT  TRM.C_BATCH_NO FROM TRC_ROLL_MAIN TRM                         
                                    ORDER BY TRM.C_BATCH_NO DESC
                                    )
                                    WHERE rownum=1";
            var obj = DbHelperOra.GetSingle(sql);
            string no = "";
            if (obj == null)
            {
                int year = DateTime.Now.Year;
                no = string.Format("31{0}00001", year.ToString().Substring(2));
            }
            else
            {
                no = obj.ToString();
            }
            return no;
        }

        /// <summary>
        /// 重组批号
        /// </summary>
        /// <param name="no">最大批号</param>
        /// <returns></returns>
        public string ReCombine(string no)
        {
            string result = "";
            string str = no.Substring(4);
            int count = str.Length;
            int re = 0;
            re = Convert.ToInt32(str) + 1;
            int reCount = re.ToString().Length;
            for (int i = 0; i < count - reCount; i++)
            {
                result += "0";
            }
            result += re;
            return result;
        }

        /// <summary>
        /// 更新钢坯入炉状态
        /// </summary>
        /// <returns></returns>
        public int UpdatePutFurnaceType(string id, int putNum, out DataTable outSlabDt)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"SELECT * FROM 
                                    (SELECT TSM.C_ID C_SLAB_MAIN_ID FROM TRC_ROLL_MAIN TRM
                                    LEFT JOIN TRC_ROLL_MAIN_ITEM TRMI ON TRM.C_ID=TRMI.C_ROLL_MAIN_ID
                                    LEFT JOIN TSC_SLAB_MAIN TSM ON TSM.C_ID=TRMI.C_SLAB_MAIN_ID
                                    WHERE TSM.C_MOVE_TYPE='DZ'
                                    AND TRM.C_ID=:id
                                    )
                                    WHERE ROWNUM<=:putNum ";
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            paras.Add(new OracleParameter() { ParameterName = ":putNum", Value = putNum });

            DataTable slabDt = DbHelperOra.Query(sql, paras.ToArray()).Tables[0];
            outSlabDt = slabDt;

            string sqlExec = @"  Update TSC_SLAB_MAIN TSM  
                                                    SET TSM.C_MOVE_TYPE='R'
                                                    WHERE  TSM.C_ID IN( ";
            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'";
                    else
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "',";
                }
            }
            sqlExec += ")   AND TSM.C_MOVE_TYPE='DZ'   ";
            int resultCount = TransactionHelper.ExecuteSql(sqlExec);
            return resultCount;
        }

        /// <summary>
        /// 更新钢坯出炉状态
        /// </summary>
        /// <param name="id">组坯表主键</param>
        /// <param name="putNum">支数</param>
        /// <param name="outSlabDt">钢坯Dt</param>
        /// <returns></returns>
        public int UpdateOutFurnaceType(string id, int putNum, out DataTable outSlabDt)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"SELECT * FROM 
                                    (SELECT TSM.C_ID C_SLAB_MAIN_ID FROM TRC_ROLL_MAIN TRM
                                    LEFT JOIN TRC_ROLL_MAIN_ITEM TRMI ON TRM.C_ID=TRMI.C_ROLL_MAIN_ID
                                    LEFT JOIN TSC_SLAB_MAIN TSM ON TSM.C_ID=TRMI.C_SLAB_MAIN_ID
                                    WHERE TSM.C_MOVE_TYPE='R'
                                    AND TRM.C_ID=:id
                                    )
                                    WHERE ROWNUM<=:putNum ";
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            paras.Add(new OracleParameter() { ParameterName = ":putNum", Value = putNum });

            DataTable slabDt = DbHelperOra.Query(sql, paras.ToArray()).Tables[0];
            outSlabDt = slabDt;

            string sqlExec = @"  Update TSC_SLAB_MAIN TSM  
                                                    SET TSM.C_MOVE_TYPE='C'
                                                    WHERE  TSM.C_ID IN( ";
            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'";
                    else
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "',";
                }
            }
            sqlExec += ")   AND TSM.C_MOVE_TYPE='R'   ";
            int resultCount = TransactionHelper.ExecuteSql(sqlExec);
            return resultCount;
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="id">组坯主键</param>
        /// <param name="newType">新状态</param>
        /// <param name="type">原状态</param>
        /// <param name="slabStatus">钢坯状态</param>
        /// <returns></returns>
        public int UpdateSlabMoveType(DataTable slabDt, string newType, string type, string slabStatus)
        {
            List<OracleParameter> paras = new List<OracleParameter>();

            string sqlExec = @"  Update TSC_SLAB_MAIN TSM  
                                                    SET TSM.C_MOVE_TYPE=:newType ";
            if (!string.IsNullOrWhiteSpace(slabStatus))
                sqlExec += "   ,TSM.C_SLAB_STATUS='" + slabStatus + "' ";
            sqlExec += "  WHERE  TSM.C_ID IN( ";
            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'";
                    else
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "',";
                }
            }
            sqlExec += ")   AND TSM.C_MOVE_TYPE=:type  ";

            paras.Add(new OracleParameter() { ParameterName = ":newType", Value = newType });
            paras.Add(new OracleParameter() { ParameterName = ":type", Value = type });

            int resultCount = TransactionHelper.ExecuteSql(sqlExec, paras.ToArray());
            return resultCount;
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="id">组坯主键</param>
        /// <param name="newType">新状态</param>
        /// <param name="type">原状态</param>
        /// <param name="slabStatus">钢坯状态</param>
        /// <returns></returns>
        public int UpdateSlabMoveType(DataTable slabDt, string newType, string type, string slabStatus, DataTable unQualifiedDt, string shift, string group, string userID)
        {
            List<OracleParameter> paras = new List<OracleParameter>();

            string sqlExec = @"  Update TSC_SLAB_MAIN TSM  
                                                    SET TSM.C_MOVE_TYPE=:newType ";
            if (!string.IsNullOrWhiteSpace(slabStatus))
                sqlExec += "   ,TSM.C_SLAB_STATUS='" + slabStatus + "' ";

            if (unQualifiedDt != null && unQualifiedDt.Rows.Count > 0)
            {
                sqlExec += "   ,TSM.C_SLABWH_AREA_CODE='" + unQualifiedDt.Rows[0]["C_SLABWH_AREA_CODE"].ToString() + "' ";
            }

            if (!string.IsNullOrWhiteSpace(shift))
                sqlExec += "   ,TSM.C_WE_SHIFT='" + shift + "' ";

            if (!string.IsNullOrWhiteSpace(group))
                sqlExec += "   ,TSM.C_WE_GROUP='" + group + "' ";

            if (!string.IsNullOrWhiteSpace(userID))
                sqlExec += "   ,TSM.C_WE_EMP_ID='" + userID + "' ";

            sqlExec += "  WHERE  TSM.C_ID IN( ";
            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'";
                    else
                        sqlExec += "'" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "',";
                }
            }
            sqlExec += ")   AND TSM.C_MOVE_TYPE=:type  ";

            paras.Add(new OracleParameter() { ParameterName = ":newType", Value = newType });
            paras.Add(new OracleParameter() { ParameterName = ":type", Value = type });

            int resultCount = TransactionHelper.ExecuteSql(sqlExec, paras.ToArray());
            return resultCount;
        }

        /// <summary>
        /// 更新钢坯撤回出炉状态
        /// </summary>
        /// <param name="id">组坯主键</param>
        /// <param name="putNum">出炉支数</param>
        /// <returns></returns>
        public int UpdateBackOutFurnaceType(DataTable slabDt)
        {

            string sqlExec = @"  Update TSC_SLAB_MAIN TSM  
                                                    SET TSM.C_MOVE_TYPE='R'
                                                    WHERE (  ";
            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sqlExec += " TSM.C_ID= '" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'";
                    else
                        sqlExec += "  TSM.C_ID=  '" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'   or  ";
                }
            }
            sqlExec += ")   AND TSM.C_MOVE_TYPE='C'   ";
            int resultCount = TransactionHelper.ExecuteSql(sqlExec);
            return resultCount;
        }

        /// <summary>
        /// 更新入炉信息(入炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">入炉支数</param>
        /// <returns></returns>
        public int UpdatePut(string id, int putNum, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            int wgt = putNum * 2;
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET TRM.N_QUA_JOIN=NVL(TRM.N_QUA_JOIN,0)+:num ,
                                        TRM.N_WGT_JOIN=NVL(TRM.N_WGT_JOIN,0)+:wgt ,
                                        TRM.N_QUA_TOTAL=TRM.N_QUA_TOTAL-:num,
                                        TRM.N_WGT_TOTAL=TRM.N_WGT_TOTAL-:wgt,
                                        TRM.C_REMARK=:remark
                                    WHERE TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// 更新出炉信息(出炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">入炉支数</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public int UpdateOut(string id, int putNum, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            int wgt = putNum * 2;
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET TRM.N_QUA_EXIT =NVL(TRM.N_QUA_EXIT,0)+:num ,
                                    TRM.N_WGT_EXIT =NVL(TRM.N_WGT_EXIT,0)+:wgt,
                                    TRM.N_QUA_JOIN=TRM.N_QUA_JOIN-:num,
                                    TRM.N_WGT_JOIN=TRM.N_WGT_JOIN-:wgt,
                                    TRM.C_REMARK=:remark
                                    WHERE TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// 更新入炉信息(撤回入炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">入炉支数</param>
        /// <param name="putWgt">入炉重量</param>
        /// <param name="putWgt">备注</param>
        /// <returns></returns>
        public int BackPut(string id, int putNum, int putWgt, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            int wgt = putNum * 2;
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET     TRM.N_QUA_TOTAL=NVL(TRM.N_QUA_TOTAL,0)+:num
                                           ,TRM.N_WGT_TOTAL=NVL(TRM.N_WGT_TOTAL,0)+:wgt
                                           ,TRM.N_QUA_JOIN=TRM.N_QUA_JOIN-:num
                                           ,TRM.N_WGT_JOIN=TRM.N_WGT_JOIN-:wgt
                                           ,TRM.C_REMARK=:remark
                                    WHERE   TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = wgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// 更新出炉信息(撤回出炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">入炉支数</param>
        /// <param name="putWgt">入炉重量</param>
        /// <param name="putWgt">备注</param>
        /// <returns></returns>
        public int BackOut(string id, int putNum, int putWgt, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET     TRM.N_QUA_JOIN=NVL(TRM.N_QUA_JOIN,0)+:num
                                           ,TRM.N_WGT_JOIN=NVL(TRM.N_WGT_JOIN,0)+:wgt
                                           ,TRM.N_QUA_EXIT=TRM.N_QUA_EXIT-:num
                                           ,TRM.N_WGT_EXIT=TRM.N_WGT_EXIT-:wgt
                                           ,TRM.C_REMARK=:remark
                                    WHERE   TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// (剔除入炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">支数</param>
        /// <param name="putWgt">重量</param>
        /// <param name="putWgt">备注</param>
        /// <returns></returns>
        public int ElimPut(string id, int putNum, int putWgt, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET     TRM.N_QUA_ELIM=NVL(TRM.N_QUA_ELIM,0)+:num
                                           ,TRM.N_WGT_ELIM=NVL(TRM.N_WGT_ELIM,0)+:wgt
                                           ,TRM.N_QUA_JOIN=TRM.N_QUA_JOIN-:num
                                           ,TRM.N_WGT_JOIN=TRM.N_WGT_JOIN-:wgt
                                           ,TRM.C_REMARK=:remark
                                    WHERE   TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }


        /// <summary>
        /// (剔除出炉)
        /// </summary>
        /// <param name="id">组批表ID</param>
        /// <param name="putNum">支数</param>
        /// <param name="putWgt">重量</param>
        /// <param name="putWgt">备注</param>
        /// <returns></returns>
        public int ElimOut(string id, int putNum, int putWgt, string remark)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"UPDATE TRC_ROLL_MAIN TRM 
                                    SET     TRM.N_QUA_ELIM=NVL(TRM.N_QUA_ELIM,0)+:num
                                           ,TRM.N_WGT_ELIM=NVL(TRM.N_WGT_ELIM,0)+:wgt
                                           ,TRM.N_QUA_EXIT=TRM.N_QUA_EXIT-:num
                                           ,TRM.N_WGT_EXIT=TRM.N_WGT_EXIT-:wgt
                                           ,TRM.C_REMARK=:remark
                                    WHERE   TRM.C_ID=:id";
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = putNum });
            paras.Add(new OracleParameter() { ParameterName = ":wgt", Value = putWgt });
            paras.Add(new OracleParameter() { ParameterName = ":remark", Value = remark });
            paras.Add(new OracleParameter() { ParameterName = ":id", Value = id });
            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// 获取加热炉信息
        /// </summary>
        /// <param name="staID">工位ID</param>
        /// <param name="num">支数</param>
        /// <param name="roll_status">状态</param>
        /// <returns></returns>
        public DataSet GetFurnace(string staID, int num, int rollStatus)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"SELECT *
  FROM (SELECT *
          FROM TRC_WARM_FURNACE TWF
         WHERE TWF.N_ROLL_STATE = :rollStatus
           AND TWF.C_STA_ID = :staID
         ORDER BY TWF.C_BATCH_NO DESC) t
 WHERE ROWNUM <= :num
                                     ";
            paras.Add(new OracleParameter() { ParameterName = ":rollStatus", Value = rollStatus });
            paras.Add(new OracleParameter() { ParameterName = ":staID", Value = staID });
            paras.Add(new OracleParameter() { ParameterName = ":num", Value = num });
            return DbHelperOra.Query(sql, paras.ToArray());
        }

        /// <summary>
        /// 更新加热炉状态
        /// </summary>
        /// <param name="id">钢坯主键</param>
        /// <param name="rollStatus">状态1入炉 2出炉</param>
        /// <returns></returns>
        public int UpdateWarmFurnaceStatus(DataTable slabDt, int rollStatus, string shift, string group)
        {
            List<OracleParameter> paras = new List<OracleParameter>();
            string sql = @"UPDATE TRC_WARM_FURNACE TWF 
                                    SET TWF.N_ROLL_STATE=:rollStatus
                                    ,TWF.C_SHIFT='" + shift + "'   ";
            sql += "  ,TWF.C_GROUP='" + group + "'  ";
            sql += " WHERE   ";

            if (slabDt != null && slabDt.Rows.Count > 0)
            {
                for (int i = 0; i < slabDt.Rows.Count; i++)
                {
                    if (i == slabDt.Rows.Count - 1)
                        sql += " TWF.C_SLAB_MAIN_ID='" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "' ";
                    else
                        sql += " TWF.C_SLAB_MAIN_ID='" + slabDt.Rows[i]["C_SLAB_MAIN_ID"] + "'  or  ";
                }
            }

            paras.Add(new OracleParameter() { ParameterName = ":rollStatus", Value = rollStatus });

            return TransactionHelper.ExecuteSql(sql, paras.ToArray());
        }

        /// <summary>
        /// 获取不合格库位
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnqualifiedSlabwhCode(string slabwhCode)
        {
            string sql = @"SELECT * FROM TPB_SLABWH_AREA T  WHERE T.C_SLABWH_AREA_CODE LIKE  '" + slabwhCode + "%'   AND T.C_SLABWH_AREA_NAME='不合格区'";
            return DbHelperOra.Query(sql).Tables[0];
        }

        /// <summary>
        /// 创建ID
        /// </summary>
        /// <returns></returns>
        public string CreateID()
        {
            try
            {
                string id = string.Empty;
                string year = DateTime.Now.Year.ToString().Substring(2);
                string month = DateTime.Now.Month.ToString();
                id += "WG" + year + month;
                id += FillVacancy(DbHelperOra.GetSingle("  select   SEQ_ROLLID.NEXTVAL No   from  sys.dual  ").ToString());
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string FillVacancy(string serNum)
        {
            if (serNum.Length == 1)
                serNum = "0000" + serNum;
            else if (serNum.Length == 2)
                serNum = "000" + serNum;
            else if (serNum.Length == 3)
                serNum = "00" + serNum;
            else if (serNum.Length == 4)
                serNum = "0" + serNum;
            return serNum;
        }

        /// <summary>
        /// 关闭计划
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public bool ClosePlan(string planID)
        {
            string sql = @"UPDATE TRP_PLAN_ROLL T
                                     SET T.N_STATUS=3
                                     WHERE T.C_ID='" + planID + "'";
            int rows = TransactionHelper.ExecuteSql(sql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion  ExtensionMethod
    }
}

