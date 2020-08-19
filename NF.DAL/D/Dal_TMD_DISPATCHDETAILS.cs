using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Collections;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMD_DISPATCHDETAILS
    /// </summary>
    public partial class Dal_TMD_DISPATCHDETAILS
    {
        public Dal_TMD_DISPATCHDETAILS()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMD_DISPATCHDETAILS");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_DISPATCHDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMD_DISPATCHDETAILS(");
            strSql.Append("C_ID,C_DISPATCH_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_SLAB_NO,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_SEND_STOCK,C_QUALIRY_LEV,C_FREE_TERM,C_ELSENEED,N_COM_AMOUNT_WGT,N_WGT,C_EQUATION_FACTOR,N_OUT_STOCK_WGT,C_UNITIS,C_SEND_SITE,C_AOG_SITE,C_ORGO_CUST,C_CGC,N_IS_SEND_CLOSE,C_ORDER_TYPE,C_SEND_AREA,C_AREA,C_AU_UNITIS,C_CUSTFILE_ID,C_CUST_ID,C_REMARK,C_MZDATE,N_MWGT,N_PWGT,N_JWGT,N_MZTIME,N_PZTIME,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CON_NO,C_PLAN_ID,C_PLAN_CODE,C_PK_NCID,C_NO,C_STD_CODE,C_JUDGE_LEV_ZH,C_PRODUCT_ID,C_FREE_TERM2,C_PACK,C_PZDATE)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_DISPATCH_ID,:C_STOVE,:C_BATCH_NO,:C_TICK_NO,:C_SLAB_NO,:C_MAT_CODE,:C_MAT_NAME,:C_SPEC,:C_STL_GRD,:C_SEND_STOCK,:C_QUALIRY_LEV,:C_FREE_TERM,:C_ELSENEED,:N_COM_AMOUNT_WGT,:N_WGT,:C_EQUATION_FACTOR,:N_OUT_STOCK_WGT,:C_UNITIS,:C_SEND_SITE,:C_AOG_SITE,:C_ORGO_CUST,:C_CGC,:N_IS_SEND_CLOSE,:C_ORDER_TYPE,:C_SEND_AREA,:C_AREA,:C_AU_UNITIS,:C_CUSTFILE_ID,:C_CUST_ID,:C_REMARK,:C_MZDATE,:N_MWGT,:N_PWGT,:N_JWGT,:N_MZTIME,:N_PZTIME,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:C_CON_NO,:C_PLAN_ID,:C_PLAN_CODE,:C_PK_NCID,:C_NO,:C_STD_CODE,:C_JUDGE_LEV_ZH,:C_PRODUCT_ID,:C_FREE_TERM2,:C_PACK,:C_PZDATE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DISPATCH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUALIRY_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_ELSENEED", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_COM_AMOUNT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_EQUATION_FACTOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OUT_STOCK_WGT", OracleDbType.Decimal,6),
                    new OracleParameter(":C_UNITIS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_IS_SEND_CLOSE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AU_UNITIS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTFILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_MZDATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_JWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MZTIME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PZTIME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_NCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM2", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PZDATE", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_DISPATCH_ID;
            parameters[2].Value = model.C_STOVE;
            parameters[3].Value = model.C_BATCH_NO;
            parameters[4].Value = model.C_TICK_NO;
            parameters[5].Value = model.C_SLAB_NO;
            parameters[6].Value = model.C_MAT_CODE;
            parameters[7].Value = model.C_MAT_NAME;
            parameters[8].Value = model.C_SPEC;
            parameters[9].Value = model.C_STL_GRD;
            parameters[10].Value = model.C_SEND_STOCK;
            parameters[11].Value = model.C_QUALIRY_LEV;
            parameters[12].Value = model.C_FREE_TERM;
            parameters[13].Value = model.C_ELSENEED;
            parameters[14].Value = model.N_COM_AMOUNT_WGT;
            parameters[15].Value = model.N_WGT;
            parameters[16].Value = model.C_EQUATION_FACTOR;
            parameters[17].Value = model.N_OUT_STOCK_WGT;
            parameters[18].Value = model.C_UNITIS;
            parameters[19].Value = model.C_SEND_SITE;
            parameters[20].Value = model.C_AOG_SITE;
            parameters[21].Value = model.C_ORGO_CUST;
            parameters[22].Value = model.C_CGC;
            parameters[23].Value = model.N_IS_SEND_CLOSE;
            parameters[24].Value = model.C_ORDER_TYPE;
            parameters[25].Value = model.C_SEND_AREA;
            parameters[26].Value = model.C_AREA;
            parameters[27].Value = model.C_AU_UNITIS;
            parameters[28].Value = model.C_CUSTFILE_ID;
            parameters[29].Value = model.C_CUST_ID;
            parameters[30].Value = model.C_REMARK;
            parameters[31].Value = model.C_MZDATE;
            parameters[32].Value = model.N_MWGT;
            parameters[33].Value = model.N_PWGT;
            parameters[34].Value = model.N_JWGT;
            parameters[35].Value = model.N_MZTIME;
            parameters[36].Value = model.N_PZTIME;
            parameters[37].Value = model.C_EMP_ID;
            parameters[38].Value = model.C_EMP_NAME;
            parameters[39].Value = model.D_MOD_DT;
            parameters[40].Value = model.C_CON_NO;
            parameters[41].Value = model.C_PLAN_ID;
            parameters[42].Value = model.C_PLAN_CODE;
            parameters[43].Value = model.C_PK_NCID;
            parameters[44].Value = model.C_NO;
            parameters[45].Value = model.C_STD_CODE;
            parameters[46].Value = model.C_JUDGE_LEV_ZH;
            parameters[47].Value = model.C_PRODUCT_ID;
            parameters[48].Value = model.C_FREE_TERM2;
            parameters[49].Value = model.C_PACK;
            parameters[50].Value = model.C_PZDATE;

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
        public bool Update(Mod_TMD_DISPATCHDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_DISPATCHDETAILS set ");
            strSql.Append("C_DISPATCH_ID=:C_DISPATCH_ID,");
            strSql.Append("C_STOVE=:C_STOVE,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_TICK_NO=:C_TICK_NO,");
            strSql.Append("C_SLAB_NO=:C_SLAB_NO,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SEND_STOCK=:C_SEND_STOCK,");
            strSql.Append("C_QUALIRY_LEV=:C_QUALIRY_LEV,");
            strSql.Append("C_FREE_TERM=:C_FREE_TERM,");
            strSql.Append("C_ELSENEED=:C_ELSENEED,");
            strSql.Append("N_COM_AMOUNT_WGT=:N_COM_AMOUNT_WGT,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_EQUATION_FACTOR=:C_EQUATION_FACTOR,");
            strSql.Append("N_OUT_STOCK_WGT=:N_OUT_STOCK_WGT,");
            strSql.Append("C_UNITIS=:C_UNITIS,");
            strSql.Append("C_SEND_SITE=:C_SEND_SITE,");
            strSql.Append("C_AOG_SITE=:C_AOG_SITE,");
            strSql.Append("C_ORGO_CUST=:C_ORGO_CUST,");
            strSql.Append("C_CGC=:C_CGC,");
            strSql.Append("N_IS_SEND_CLOSE=:N_IS_SEND_CLOSE,");
            strSql.Append("C_ORDER_TYPE=:C_ORDER_TYPE,");
            strSql.Append("C_SEND_AREA=:C_SEND_AREA,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_AU_UNITIS=:C_AU_UNITIS,");
            strSql.Append("C_CUSTFILE_ID=:C_CUSTFILE_ID,");
            strSql.Append("C_CUST_ID=:C_CUST_ID,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_MZDATE=:C_MZDATE,");
            strSql.Append("N_MWGT=:N_MWGT,");
            strSql.Append("N_PWGT=:N_PWGT,");
            strSql.Append("N_JWGT=:N_JWGT,");
            strSql.Append("N_MZTIME=:N_MZTIME,");
            strSql.Append("N_PZTIME=:N_PZTIME,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("C_PLAN_ID=:C_PLAN_ID,");
            strSql.Append("C_PLAN_CODE=:C_PLAN_CODE,");
            strSql.Append("C_PK_NCID=:C_PK_NCID,");
            strSql.Append("C_NO=:C_NO,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_JUDGE_LEV_ZH=:C_JUDGE_LEV_ZH,");
            strSql.Append("C_PRODUCT_ID=:C_PRODUCT_ID,");
            strSql.Append("C_FREE_TERM2=:C_FREE_TERM2,");
            strSql.Append("C_PACK=:C_PACK,");
            strSql.Append("C_PZDATE=:C_PZDATE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_DISPATCH_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STOVE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TICK_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLAB_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUALIRY_LEV", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_ELSENEED", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_COM_AMOUNT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_EQUATION_FACTOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OUT_STOCK_WGT", OracleDbType.Decimal,6),
                    new OracleParameter(":C_UNITIS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_IS_SEND_CLOSE", OracleDbType.Decimal,1),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AU_UNITIS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUSTFILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_MZDATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_MWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_PWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_JWGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MZTIME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_PZTIME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PK_NCID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_JUDGE_LEV_ZH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PRODUCT_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FREE_TERM2", OracleDbType.Varchar2,300),
                    new OracleParameter(":C_PACK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PZDATE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_DISPATCH_ID;
            parameters[1].Value = model.C_STOVE;
            parameters[2].Value = model.C_BATCH_NO;
            parameters[3].Value = model.C_TICK_NO;
            parameters[4].Value = model.C_SLAB_NO;
            parameters[5].Value = model.C_MAT_CODE;
            parameters[6].Value = model.C_MAT_NAME;
            parameters[7].Value = model.C_SPEC;
            parameters[8].Value = model.C_STL_GRD;
            parameters[9].Value = model.C_SEND_STOCK;
            parameters[10].Value = model.C_QUALIRY_LEV;
            parameters[11].Value = model.C_FREE_TERM;
            parameters[12].Value = model.C_ELSENEED;
            parameters[13].Value = model.N_COM_AMOUNT_WGT;
            parameters[14].Value = model.N_WGT;
            parameters[15].Value = model.C_EQUATION_FACTOR;
            parameters[16].Value = model.N_OUT_STOCK_WGT;
            parameters[17].Value = model.C_UNITIS;
            parameters[18].Value = model.C_SEND_SITE;
            parameters[19].Value = model.C_AOG_SITE;
            parameters[20].Value = model.C_ORGO_CUST;
            parameters[21].Value = model.C_CGC;
            parameters[22].Value = model.N_IS_SEND_CLOSE;
            parameters[23].Value = model.C_ORDER_TYPE;
            parameters[24].Value = model.C_SEND_AREA;
            parameters[25].Value = model.C_AREA;
            parameters[26].Value = model.C_AU_UNITIS;
            parameters[27].Value = model.C_CUSTFILE_ID;
            parameters[28].Value = model.C_CUST_ID;
            parameters[29].Value = model.C_REMARK;
            parameters[30].Value = model.C_MZDATE;
            parameters[31].Value = model.N_MWGT;
            parameters[32].Value = model.N_PWGT;
            parameters[33].Value = model.N_JWGT;
            parameters[34].Value = model.N_MZTIME;
            parameters[35].Value = model.N_PZTIME;
            parameters[36].Value = model.C_EMP_ID;
            parameters[37].Value = model.C_EMP_NAME;
            parameters[38].Value = model.D_MOD_DT;
            parameters[39].Value = model.C_CON_NO;
            parameters[40].Value = model.C_PLAN_ID;
            parameters[41].Value = model.C_PLAN_CODE;
            parameters[42].Value = model.C_PK_NCID;
            parameters[43].Value = model.C_NO;
            parameters[44].Value = model.C_STD_CODE;
            parameters[45].Value = model.C_JUDGE_LEV_ZH;
            parameters[46].Value = model.C_PRODUCT_ID;
            parameters[47].Value = model.C_FREE_TERM2;
            parameters[48].Value = model.C_PACK;
            parameters[49].Value = model.C_PZDATE;
            parameters[50].Value = model.C_ID;

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
            strSql.Append("delete from TMD_DISPATCHDETAILS ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
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
            strSql.Append("delete from TMD_DISPATCHDETAILS ");
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
        public Mod_TMD_DISPATCHDETAILS GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_DISPATCH_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_SLAB_NO,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_SEND_STOCK,C_QUALIRY_LEV,C_FREE_TERM,C_ELSENEED,N_COM_AMOUNT_WGT,N_WGT,C_EQUATION_FACTOR,N_OUT_STOCK_WGT,C_UNITIS,C_SEND_SITE,C_AOG_SITE,C_ORGO_CUST,C_CGC,N_IS_SEND_CLOSE,C_ORDER_TYPE,C_SEND_AREA,C_AREA,C_AU_UNITIS,C_CUSTFILE_ID,C_CUST_ID,C_REMARK,C_MZDATE,N_MWGT,N_PWGT,N_JWGT,N_MZTIME,N_PZTIME,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CON_NO,C_PLAN_ID,C_PLAN_CODE,C_PK_NCID,C_NO,C_STD_CODE,C_JUDGE_LEV_ZH,C_PRODUCT_ID,C_FREE_TERM2,C_PACK,C_PZDATE,C_ORDERPK,C_CUSTNO,N_FYZS,N_FYWGT,C_SEND_STOCK_PK,C_SEND_STOCK_CODE,N_PRICE FROM TMD_DISPATCHDETAILS ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMD_DISPATCHDETAILS model = new Mod_TMD_DISPATCHDETAILS();
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
        public Mod_TMD_DISPATCHDETAILS DataRowToModel(DataRow row)
        {
            Mod_TMD_DISPATCHDETAILS model = new Mod_TMD_DISPATCHDETAILS();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_DISPATCH_ID"] != null)
                {
                    model.C_DISPATCH_ID = row["C_DISPATCH_ID"].ToString();
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
                if (row["C_SLAB_NO"] != null)
                {
                    model.C_SLAB_NO = row["C_SLAB_NO"].ToString();
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
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SEND_STOCK"] != null)
                {
                    model.C_SEND_STOCK = row["C_SEND_STOCK"].ToString();
                }
                if (row["C_QUALIRY_LEV"] != null)
                {
                    model.C_QUALIRY_LEV = row["C_QUALIRY_LEV"].ToString();
                }
                if (row["C_FREE_TERM"] != null)
                {
                    model.C_FREE_TERM = row["C_FREE_TERM"].ToString();
                }
                if (row["C_ELSENEED"] != null)
                {
                    model.C_ELSENEED = row["C_ELSENEED"].ToString();
                }
                if (row["N_COM_AMOUNT_WGT"] != null && row["N_COM_AMOUNT_WGT"].ToString() != "")
                {
                    model.N_COM_AMOUNT_WGT = decimal.Parse(row["N_COM_AMOUNT_WGT"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_EQUATION_FACTOR"] != null)
                {
                    model.C_EQUATION_FACTOR = row["C_EQUATION_FACTOR"].ToString();
                }
                if (row["N_OUT_STOCK_WGT"] != null && row["N_OUT_STOCK_WGT"].ToString() != "")
                {
                    model.N_OUT_STOCK_WGT = decimal.Parse(row["N_OUT_STOCK_WGT"].ToString());
                }
                if (row["C_UNITIS"] != null)
                {
                    model.C_UNITIS = row["C_UNITIS"].ToString();
                }
                if (row["C_SEND_SITE"] != null)
                {
                    model.C_SEND_SITE = row["C_SEND_SITE"].ToString();
                }
                if (row["C_AOG_SITE"] != null)
                {
                    model.C_AOG_SITE = row["C_AOG_SITE"].ToString();
                }
                if (row["C_ORGO_CUST"] != null)
                {
                    model.C_ORGO_CUST = row["C_ORGO_CUST"].ToString();
                }
                if (row["C_CGC"] != null)
                {
                    model.C_CGC = row["C_CGC"].ToString();
                }
                if (row["N_IS_SEND_CLOSE"] != null && row["N_IS_SEND_CLOSE"].ToString() != "")
                {
                    model.N_IS_SEND_CLOSE = decimal.Parse(row["N_IS_SEND_CLOSE"].ToString());
                }
                if (row["C_ORDER_TYPE"] != null)
                {
                    model.C_ORDER_TYPE = row["C_ORDER_TYPE"].ToString();
                }
                if (row["C_SEND_AREA"] != null)
                {
                    model.C_SEND_AREA = row["C_SEND_AREA"].ToString();
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["C_AU_UNITIS"] != null)
                {
                    model.C_AU_UNITIS = row["C_AU_UNITIS"].ToString();
                }
                if (row["C_CUSTFILE_ID"] != null)
                {
                    model.C_CUSTFILE_ID = row["C_CUSTFILE_ID"].ToString();
                }
                if (row["C_CUST_ID"] != null)
                {
                    model.C_CUST_ID = row["C_CUST_ID"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_MZDATE"] != null)
                {
                    model.C_MZDATE = row["C_MZDATE"].ToString();
                }
                if (row["N_MWGT"] != null && row["N_MWGT"].ToString() != "")
                {
                    model.N_MWGT = decimal.Parse(row["N_MWGT"].ToString());
                }
                if (row["N_PWGT"] != null && row["N_PWGT"].ToString() != "")
                {
                    model.N_PWGT = decimal.Parse(row["N_PWGT"].ToString());
                }
                if (row["N_JWGT"] != null && row["N_JWGT"].ToString() != "")
                {
                    model.N_JWGT = decimal.Parse(row["N_JWGT"].ToString());
                }
                if (row["N_MZTIME"] != null)
                {
                    model.N_MZTIME = row["N_MZTIME"].ToString();
                }
                if (row["N_PZTIME"] != null)
                {
                    model.N_PZTIME = row["N_PZTIME"].ToString();
                }
                if (row["N_PRICE"] != null && row["N_PRICE"].ToString() != "")
                {
                    model.N_PRICE = decimal.Parse(row["N_PRICE"].ToString());
                }

                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["C_EMP_NAME"] != null)
                {
                    model.C_EMP_NAME = row["C_EMP_NAME"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["C_PLAN_ID"] != null)
                {
                    model.C_PLAN_ID = row["C_PLAN_ID"].ToString();
                }
                if (row["C_PLAN_CODE"] != null)
                {
                    model.C_PLAN_CODE = row["C_PLAN_CODE"].ToString();
                }
                if (row["C_PK_NCID"] != null)
                {
                    model.C_PK_NCID = row["C_PK_NCID"].ToString();
                }
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_JUDGE_LEV_ZH"] != null)
                {
                    model.C_JUDGE_LEV_ZH = row["C_JUDGE_LEV_ZH"].ToString();
                }
                if (row["C_PRODUCT_ID"] != null)
                {
                    model.C_PRODUCT_ID = row["C_PRODUCT_ID"].ToString();
                }
                if (row["C_FREE_TERM2"] != null)
                {
                    model.C_FREE_TERM2 = row["C_FREE_TERM2"].ToString();
                }
                if (row["C_PACK"] != null)
                {
                    model.C_PACK = row["C_PACK"].ToString();
                }
                if (row["C_PZDATE"] != null)
                {
                    model.C_PZDATE = row["C_PZDATE"].ToString();
                }
                if (row["C_ORDERPK"] != null)
                {
                    model.C_ORDERPK = row["C_ORDERPK"].ToString();
                }
                if (row["C_CUSTNO"] != null)
                {
                    model.C_CUSTNO = row["C_CUSTNO"].ToString();
                }
                if (row["N_FYZS"] != null && row["N_FYZS"].ToString() != "")
                {
                    model.N_FYZS = decimal.Parse(row["N_FYZS"].ToString());
                }
                if (row["N_FYWGT"] != null && row["N_FYWGT"].ToString() != "")
                {
                    model.N_FYWGT = decimal.Parse(row["N_FYWGT"].ToString());
                }
                if (row["C_SEND_STOCK_PK"] != null)
                {
                    model.C_SEND_STOCK_PK = row["C_SEND_STOCK_PK"].ToString();
                }
                if (row["C_SEND_STOCK_CODE"] != null)
                {
                    model.C_SEND_STOCK_CODE = row["C_SEND_STOCK_CODE"].ToString();
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
            strSql.Append("select C_ID,C_DISPATCH_ID,C_STOVE,C_BATCH_NO,C_TICK_NO,C_SLAB_NO,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_SEND_STOCK,C_QUALIRY_LEV,C_FREE_TERM,C_ELSENEED,N_COM_AMOUNT_WGT,N_WGT,C_EQUATION_FACTOR,N_OUT_STOCK_WGT,C_UNITIS,C_SEND_SITE,C_AOG_SITE,C_ORGO_CUST,C_CGC,N_IS_SEND_CLOSE,C_ORDER_TYPE,C_SEND_AREA,C_AREA,C_AU_UNITIS,C_CUSTFILE_ID,C_CUST_ID,C_REMARK,C_MZDATE,N_MWGT,N_PWGT,N_JWGT,N_MZTIME,N_PZTIME,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_CON_NO,C_PLAN_ID,C_PLAN_CODE,C_PK_NCID,C_NO,C_STD_CODE,C_JUDGE_LEV_ZH,C_PRODUCT_ID,C_FREE_TERM2,C_PACK,C_PZDATE,C_ORDERPK,C_CUSTNO,N_FYZS,N_FYWGT,C_SEND_STOCK_PK,C_SEND_STOCK_CODE,N_PRICE ");
            strSql.Append(" FROM TMD_DISPATCHDETAILS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where C_DISPATCH_ID='" + strWhere + "'");
            }
            strSql.Append(" order by D_MOD_DT,C_MAT_NAME,C_STL_GRD,C_SPEC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TMD_DISPATCHDETAILS ");
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
            strSql.Append(")AS Row, T.*  from TMD_DISPATCHDETAILS T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region//自定义方法

        /// <summary>
        /// 获取质量等级NC主键
        /// </summary>
        /// <param name="checkname">质量名称</param>
        /// <param name="flag">8线材，6钢坯</param>
        /// <returns></returns>
        public DataSet GetCheck(string checkname, int flag)
        {
            string type = flag == 8 ? "线材" : "钢坯";
            string strSql = "select C_ID from tqb_checkstate where C_REMARK='1001' and C_CHECKSTATE_NAME='" + checkname + "' and C_CHECKSTATE_TYPE='" + type + "'";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 根据订单号获取发运单据
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public DataSet GetOrderFYD(string orderNO)
        {
            string strSql = string.Format(@"SELECT DISTINCT T.C_DISPATCH_ID, B.C_DETAILNAME,A.C_LIC_PLA_NO,A.C_ATSTATION,T.C_ORDER_TYPE,A.D_DISP_DT
  FROM TMD_DISPATCHDETAILS T,TMD_DISPATCH A,TS_DIC B
 WHERE T.C_DISPATCH_ID=A.C_ID  AND A.C_SHIPVIA=B.C_ID AND  T.C_NO = '{0}'", orderNO);
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 根据发运单获取明细
        /// </summary>
        /// <param name="sendCode">发运单据号</param>
        /// <param name="orderType">钢种类型</param>
        /// <returns></returns>
        public DataSet GetOrderFYDList(string sendCode, string orderType)
        {
            StringBuilder strSql = new StringBuilder();

            switch (orderType)
            {
                case "8"://线材
                    strSql.AppendFormat(@"select t.C_BATCH_NO,t.C_STOVE,
                                   (t.C_MAT_DESC || C_STL_GRD || C_SPEC) matname,
                                   count(0) jianshu,
                                   sum(t.N_WGT) N_WGT
                              from trc_roll_prodcut t
                             where t.c_fydh = '{0}' group by t.C_STOVE,t.C_BATCH_NO,t.C_MAT_DESC,t.C_STL_GRD,t.C_SPEC", sendCode);
                    break;
                case "6"://钢坯
                    strSql.AppendFormat(@"select t.C_BATCH_NO,t.C_STOVE,
                               (t.C_MAT_NAME || C_STL_GRD || C_SPEC) matname,
                               count(0) jianshu,
                               sum(t.N_WGT) N_WGT
                          from tsc_slab_main t
                         where t.c_fydh = '{0}' group by t.C_STOVE,t.C_MAT_NAME,t.C_STL_GRD,t.C_SPEC", sendCode);
                    break;

            }

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 发运单钢坯
        /// </summary>
        public DataSet GetDispatchGP(string dispatchCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.C_PK_NCID,
                                           t.c_dispatch_id,
                                           t.C_PLAN_CODE,
                                           t.c_mat_code,
                                           sum(t.N_WGT) N_WGT,
                                           count(0) jianshu,
                                           t.C_QUALIRY_LEV
                                      FROM TMD_DISPATCHDETAILS t
                                     where t.C_DISPATCH_ID = '{0}'
                                     group by t.C_PLAN_CODE, t.c_mat_code,t.c_dispatch_id,t.C_PK_NCID,t.C_QUALIRY_LEV", dispatchCode);

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDispatchList(string dispatchCode, int flag)
        {
            StringBuilder strSql = new StringBuilder();
            if (flag == 8)//线材
            {
                strSql.AppendFormat(@"select t.c_dispatch_id,
                                       t.C_PLAN_CODE,
                                       t.c_mat_code,
                                      t.C_QUALIRY_LEV,
                                       sum(t.N_WGT) N_WGT,
                                       count(0) jianshu
                                  FROM TMD_DISPATCHDETAILS t
                                 where t.C_DISPATCH_ID = '{0}'
                                 group by t.C_PLAN_CODE, t.c_mat_code,t.C_QUALIRY_LEV,t.c_dispatch_id", dispatchCode);
            }
            else//钢坯
            {
                strSql.AppendFormat(@"select t.c_dispatch_id,
                                            t.C_PLAN_CODE,
                                           t.c_mat_code,
                                           sum(t.N_WGT) N_WGT,
                                           count(0) jianshu,
                                           t.C_QUALIRY_LEV
                                      FROM TMD_DISPATCHDETAILS t
                                     where t.C_DISPATCH_ID = '{0}'
                                     group by t.C_PLAN_CODE, t.c_mat_code,t.c_dispatch_id,t.C_QUALIRY_LEV", dispatchCode);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新导入NC生成新主键
        /// </summary>
        /// <param name="C_PLAN_CODE">计划号</param>
        /// <param name="C_PK_NCID">新生成主键NC</param>
        /// <returns></returns>
        public bool UpdateNCID(List<apiPkDto> list, int flag)
        {
            ArrayList sqlArray = new ArrayList();

            if (list.Count > 0)
            {
                if (flag == 8)//线材
                {
                    string strsql = string.Format("update TMD_DISPATCH set C_STATUS=2  where C_ID='{0}'", list[0].sendcode);
                    sqlArray.Add(strsql);
                    for (int i = 0; i < list.Count; i++)
                    {
                        string strsql2 = "update TMD_DISPATCHDETAILS set C_PK_NCID='" + list[i].pk_ncid + "' where c_dispatch_id='" + list[i].sendcode + "'  and C_PLAN_CODE='" + list[i].plancode + "'";
                        sqlArray.Add(strsql2);
                    }
                }
                else//钢坯
                {
                    string strsql = string.Format("update TMD_DISPATCH set C_STATUS=4  where C_ID='{0}'", list[0].sendcode);
                    sqlArray.Add(strsql);
                    for (int i = 0; i < list.Count; i++)
                    {
                        string strsql2 = "update TMD_DISPATCHDETAILS set C_PK_NCID='" + list[i].pk_ncid + "' where c_dispatch_id='" + list[i].sendcode + "' and C_PLAN_CODE='" + list[i].plancode + "'";
                        sqlArray.Add(strsql2);
                    }
                }
            }
            return DbHelperOra.ExecuteSqlTran(sqlArray);

        }

        /// <summary>
        /// 物流钢坯实绩
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool WL_SJ_F(List<ApiDispDto> list)
        {
            ArrayList arraySql = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TMD_DISPATCHDETAILS set  ");
                strSql.Append(" C_MZDATE ='" + list[i].mzdate + "',");
                strSql.Append(" N_MWGT = " + Convert.ToDecimal(list[i].mwgt) + ",");
                strSql.Append(" N_PWGT = " + Convert.ToDecimal(list[i].pwgt) + ",");
                strSql.Append(" N_JWGT = " + Convert.ToDecimal(list[i].jwgt) + ",");
                strSql.Append(" N_MZTIME = '" + list[i].mztime + "',");
                strSql.Append(" N_PZTIME ='" + list[i].pztime + "',");
                strSql.Append(" C_PZDATE ='" + list[i].pzdate + "'");
                strSql.Append(" WHERE c_id = '" + list[i].pkid + "' and C_DISPATCH_ID='" + list[i].sendcode + "'");
                arraySql.Add(strSql.ToString());


            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 物流钢坯实绩
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int WL_SJ(List<ApiDispDto> list)
        {
            int result = 0;

            for (int i = 0; i < list.Count; i++)
            {
                OracleParameter[] iDataParms = {
                new OracleParameter("v_pkid", OracleDbType.Varchar2,100),
                new OracleParameter("v_sendcode", OracleDbType.Varchar2,100),
                new OracleParameter("v_matcode", OracleDbType.Varchar2,100),
                new OracleParameter("v_mzdate", OracleDbType.Varchar2,100),
                new OracleParameter("v_mztime", OracleDbType.Varchar2,100),
                new OracleParameter("v_mwgt", OracleDbType.Decimal),
                new OracleParameter("v_pzdate", OracleDbType.Varchar2,100),
                new OracleParameter("v_pztime", OracleDbType.Varchar2,100),
                new OracleParameter("v_pwgt", OracleDbType.Decimal),
                new OracleParameter("v_jwgt", OracleDbType.Decimal),
                new OracleParameter("v_result", OracleDbType.Varchar2,100)};
                iDataParms[0].Value = list[i].pkid;
                iDataParms[1].Value = list[i].sendcode;
                iDataParms[2].Value = list[i].matcode;
                iDataParms[3].Value = list[i].mzdate;
                iDataParms[4].Value = list[i].mztime;
                iDataParms[5].Value = Convert.ToDecimal(list[i].mwgt);
                iDataParms[6].Value = list[i].pzdate;
                iDataParms[7].Value = list[i].pztime;
                iDataParms[8].Value = Convert.ToDecimal(list[i].pwgt);
                iDataParms[9].Value = Convert.ToDecimal(list[i].jwgt);
                iDataParms[10].Value = "0";

                result = DbHelperOra.RunProcedure("PKG_NC_SJ.P_WL_SJ", iDataParms);
            }
            return result;
        }

        /// <summary>
        /// 线材/钢坯销售出库净重
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <returns></returns>
        public DataSet GetZJBList(string sendcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_DISPATCH_ID,C_SEND_STOCK,N_NUM,C_CKDH,N_JZ,N_WGT,C_BATCH_NO,C_STOVE,C_PLAN_ID,C_STL_GRD,C_STD_CODE,C_SPEC,C_PK_NCID,C_MZDATE,N_MWGT,N_PWGT,N_MZTIME,N_PZTIME,C_PZDATE,C_ZLDJ,N_STATUS");
            strSql.Append(" FROM TMD_DISPATCH_SJZJB WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sendcode))
            {
                strSql.Append(" AND C_DISPATCH_ID='" + sendcode + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 线材/钢坯销售出库净重
        /// </summary>
        /// <param name="sendcode">发运单</param>
        /// <param name="ch">车号</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="bs">批次号/炉号</param>
        /// <param name="printEmp">打印人</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库截至时间</param>
        /// <returns></returns>
        public DataSet GetZJBList(string sendcode, string ch, string stlgrd, string bs, string printEmp, string outStartTime, string outEndTime, string printstatus)
        {
            string strSql = $@"SELECT T.*, A.C_LIC_PLA_NO, B.C_NAME
                                  FROM TMD_DISPATCH_SJZJB T
                                  LEFT JOIN TMD_DISPATCH A
                                    ON A.C_ID = T.C_DISPATCH_ID
                                  LEFT JOIN TS_USER B
                                    ON B.C_ID = A.C_CREATE_ID WHERE 1=1";
            if (!string.IsNullOrEmpty(printstatus))
            {
                strSql += $" AND T.N_PRINT_STATUS ={printstatus}";

            }
            if (!string.IsNullOrEmpty(ch))
            {
                strSql += $"AND A.C_LIC_PLA_NO LIKE '%{ch}%' ";

            }
            if (!string.IsNullOrEmpty(sendcode))
            {
                strSql += $" AND T.C_DISPATCH_ID='{sendcode}'";
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql += $" AND T.C_STL_GRD='{stlgrd}'";
            }
            if (!string.IsNullOrEmpty(bs))
            {
                strSql += $" AND (T.C_BATCH_NO='{bs}' OR T.C_STOVE='{bs}')";
            }
            if (!string.IsNullOrEmpty(printEmp))
            {
                strSql += $" AND T.C_PRINTEMP='{printEmp}'";
            }

            if (!string.IsNullOrEmpty(outStartTime) && !string.IsNullOrEmpty(outEndTime))
            {
                strSql += $" AND T.D_CKSJ>=TO_DATE('" + Convert.ToDateTime(outStartTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ";
                strSql += $" AND T.D_CKSJ<= TO_DATE('" + Convert.ToDateTime(outEndTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ";

            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新销售出库打印状态
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="printemp">打印人</param>
        /// <returns></returns>
        public bool UpdateZJB(string fyd, string printemp,string printtype)
        {
            string strSql = $@"UPDATE TMD_DISPATCH_SJZJB SET N_PRINT_STATUS=1,N_PRINT_NUM=N_PRINT_NUM+1,C_PRINTEMP='{printemp}',D_PRINTTIME=TO_DATE('{ DateTime.Now}', 'yyyy-mm-dd hh24:mi:ss') ,C_PRINTTYPE='{printtype}' WHERE C_DISPATCH_ID='{fyd}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }


        /// <summary>
        /// 出库单补打设置
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="printemp">打印人</param>
        /// <param name="zt">0未打印，1已打印，2补打</param>
        /// <returns></returns>
        public bool UpdatePDSet(string fyd, string printemp,string zt,string remark)
        {
            string strSql = $@"UPDATE TMD_DISPATCH_SJZJB SET N_PRINT_STATUS={zt},C_PDEMP='{printemp}',C_REMARK='{remark}',D_PDTIME=TO_DATE('{ DateTime.Now}', 'yyyy-mm-dd hh24:mi:ss') WHERE C_DISPATCH_ID='{fyd}'";
            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 获取未生成钢坯质证书
        /// </summary>
        /// <returns></returns>
        public DataTable GetGPZZS()
        {
            string strSql = $@"SELECT DISTINCT T.C_DISPATCH_ID
                              FROM TMD_DISPATCH_SJZJB T
                              LEFT JOIN TQC_ZZS_INFO A
                                ON A.C_FYDH = T.C_DISPATCH_ID
                             WHERE T.N_STATUS = 6
                               AND T.N_JZ IS NOT NULL
                               AND A.C_ZSH IS NULL
                               AND T.D_CKSJ > SYSDATE - 30";
            return DbHelperOra.Query(strSql).Tables[0];
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="sendcode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateGPStatus(string sendcode, int status)
        {
            ArrayList sqlArray = new ArrayList();
            sqlArray.Add("update TMD_DISPATCH set C_STATUS=" + status + " where C_ID='" + sendcode + "'");
            sqlArray.Add("update TSC_SLAB_MAIN set C_MOVE_TYPE='S' where C_FYDH='" + sendcode + "'");
            return DbHelperOra.ExecuteSqlTran(sqlArray);
        }

        /// <summary>
        /// 更新钢坯状态
        /// </summary>
        /// <param name="sendcode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateFydStatus(string sendcode, int status)
        {
            ArrayList sqlArray = new ArrayList();
            sqlArray.Add("update TMD_DISPATCH set C_STATUS=" + status + " where C_ID='" + sendcode + "'");
            return DbHelperOra.ExecuteSqlTran(sqlArray);
        }
        #endregion

        #region//质证书打印

        /// <summary>
        /// 根据发运单号获取基本信息
        /// </summary>
        /// <param name="sendCode"></param>
        /// <returns></returns>
        public DataSet GetFydInfo(string sendCode)
        {
            string strSql = string.Format(@"select t.C_EXTEND5,t.C_LIC_PLA_NO from tmd_dispatch t where t.c_id='{0}'", sendCode);
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 根据发运单号获取钢种
        /// </summary>
        /// <param name="sendCode"></param>
        /// <returns></returns>
        public DataSet GetFydStlGrd(string sendCode)
        {
            string strSql = string.Format("select distinct t.c_stl_grd from TMD_DISPATCHDETAILS t where t.c_dispatch_id='{0}'", sendCode);
            return DbHelperOra.Query(strSql);
        }
        /// <summary>
        /// 根据发运单与钢种获取执行标准
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetFydStdCode(string sendCode, string stlGrd)
        {
            string strSql = string.Format("select distinct t.c_std_code  from TMD_DISPATCHDETAILS t where t.c_dispatch_id='{0}' and t.c_stl_grd='{1}'", sendCode, stlGrd);
            return DbHelperOra.Query(strSql);
        }


        /// <summary>
        /// 根据发运单获取明细
        /// </summary>
        /// <param name="sendCode">发运单据号</param>
        /// <param name="orderType">钢种类型</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="stdCode">执行标准</param>
        /// <returns></returns>
        public DataSet GetFYDList(string sendCode, string orderType, string stlGrd, string stdCode)
        {

            string[] arr = { sendCode, stlGrd, stdCode };

            StringBuilder strSql = new StringBuilder();

            switch (orderType)
            {
                case "8"://线材
                    strSql.AppendFormat(@"SELECT T.C_DISPATCH_ID,
                                           T.C_CKDH,
                                           T.C_SEND_STOCK,
                                           T.C_BATCH_NO,
                                           T.C_MAT_NAME,
                                           T.C_STL_GRD,
                                           T.C_SPEC,
                                           T.N_NUM,
                                           T.N_JZ,
                                           T.C_TICK_STR,
                                           T.C_ZLDJ,
                                           T.C_STD_CODE,
                                           T.D_CKSJ
                                      FROM TMD_DISPATCH_SJZJB T
                                     WHERE  T.N_STATUS=8 AND T.C_DISPATCH_ID='{0}' AND T.C_STL_GRD='{1}' AND T.C_STD_CODE='{2}'", arr);

                    break;
                case "6"://钢坯
                    strSql.AppendFormat(@"SELECT T.C_DISPATCH_ID,
                                           T.C_CKDH,
                                           T.C_SEND_STOCK,
                                           T.C_STOVE AS C_BATCH_NO,
                                           T.C_MAT_NAME,
                                           T.C_STL_GRD,
                                           T.C_SPEC,
                                           T.N_NUM,
                                           T.N_JZ,
                                           T.C_TICK_STR,
                                           T.C_ZLDJ,
                                           T.C_STD_CODE,
                                           T.D_CKSJ
                                      FROM TMD_DISPATCH_SJZJB T
                                     WHERE  T.N_STATUS=6 AND T.C_DISPATCH_ID='{0}' AND T.C_STL_GRD='{1}' AND T.C_STD_CODE='{2}'", arr);
                    break;

            }

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据批号获取性能成分
        /// </summary>
        /// <param name="batchNo"></param>
        /// <returns></returns>
        public DataSet GetBatchCFXN(string batchNo, string stlgrd, string stdcode, string stove, string type)
        {
            StringBuilder cmdText = new StringBuilder();
            if (type != "4")
            {
                string[] arr = { batchNo, stlgrd, stdcode };
                cmdText.AppendFormat(@"SELECT MAX(T.C_DESIGN_NO) C_DESIGN_NO
                                      FROM TQC_COMPRE_ITEM_RESULT T
                                     WHERE T.C_BATCH_NO = '{0}'
                                       AND T.C_STL_GRD = '{1}'
                                       AND T.C_STD_CODE = '{2}'", arr);
            }
            else
            {
                string[] arr = { stove, stlgrd, stdcode };
                cmdText.AppendFormat(@"SELECT MAX(T.C_DESIGN_NO) C_DESIGN_NO
                                      FROM TQC_COMPRE_ITEM_RESULT T
                                     WHERE T.C_BATCH_NO is null and  T.C_STOVE = '{0}'
                                       AND T.C_STL_GRD = '{1}'
                                       AND T.C_STD_CODE = '{2}'", arr);
            }
            DataRow dr = DbHelperOra.GetDataRow(cmdText.ToString());
            string c_design_no = string.Empty;
            if (dr != null)
            {
                c_design_no = dr["C_DESIGN_NO"].ToString();
            }
            StringBuilder strSql = new StringBuilder();
            if (type != "4")
            {
                strSql.AppendFormat(@"select *
  from (SELECT *
          FROM (SELECT  T.C_CHARACTER_ID,
                                C.C_NAME,
                                T.C_VALUE                                
                  FROM TQC_COMPRE_ITEM_RESULT T
                  LEFT JOIN TQB_DESIGN B
                    ON T.C_DESIGN_NO = B.C_DESIGN_NO
                  LEFT JOIN TQB_DESIGN_ITEM A
                    ON A.C_DESIGN_ID = B.C_ID
                   AND T.C_CHARACTER_ID = A.C_CHARACTER_ID
                  LEFT JOIN TQB_CHARACTER C
                    ON C.C_ID = T.C_CHARACTER_ID
                 WHERE T.C_TYPE = '成分'
                   AND T.C_VALUE IS NOT NULL
                   AND T.C_BATCH_NO = '{0}'
                group by  T.C_CHARACTER_ID,
                                C.C_NAME,
                                 T.C_VALUE
                 ORDER BY  C_NAME)
        UNION ALL
        SELECT *
          FROM (SELECT T.C_CHARACTER_ID,
                       T.C_ITEM_NAME,
                       T.C_VALUE                       
                  FROM TQC_COMPRE_ITEM_RESULT T
                 WHERE T.C_TYPE = '性能'
                   and t.c_value is not null
                   AND T.C_BATCH_NO = '{0}'
                   AND T.N_STATUS = 1
                 ORDER BY  T.C_ITEM_NAME)) tm
 where tm.c_character_id in
       (select tb.c_character_id
          from tqb_design_item tb
         where substr(tb.c_design_id, 3) = '{1}'
           and tb.c_is_print = '是')", batchNo, c_design_no);
            }
            else
            {
                strSql.AppendFormat(@"SELECT  T.C_CHARACTER_ID,
                                C.C_NAME,
                                MAX(T.C_VALUE) as C_VALUE                                 
                  FROM TQC_COMPRE_ITEM_RESULT T
                  LEFT JOIN TQB_DESIGN B
                    ON T.C_DESIGN_NO = B.C_DESIGN_NO
                  LEFT JOIN TQB_DESIGN_ITEM A
                    ON A.C_DESIGN_ID = B.C_ID
                   AND T.C_CHARACTER_ID = A.C_CHARACTER_ID
                  LEFT JOIN TQB_CHARACTER C
                    ON C.C_ID = T.C_CHARACTER_ID
                 WHERE T.C_TYPE = '成分'
                   AND T.C_VALUE IS NOT NULL
                   AND T.C_BATCH_NO is null and T.C_STOVE= '{0}' and   substr(a.c_design_id, 3) = '{1}' and a.c_is_print='是'
                group by  T.C_CHARACTER_ID,
                                C.C_NAME
                 ORDER BY  C_NAME ", stove, c_design_no);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion

    }
}

