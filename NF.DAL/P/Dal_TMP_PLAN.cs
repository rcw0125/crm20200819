using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMP_PLAN
    /// </summary>
    public partial class Dal_TMP_PLAN
    {
        public Dal_TMP_PLAN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMP_PLAN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMP_PLAN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMP_PLAN(");
            strSql.Append("C_ID,C_NO,C_CON_NO,D_PLANSEND_DT,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_QUALIRY_LEV,N_WGT,N_SENDNUM_WGT,C_ATSTATION,C_AREA,C_ADDR,C_SHIPVIA,C_CGC,C_ORGO_CUST,C_SEND_STOCK_DEPT,N_STATUS,D_ORRE_AOG_DT,C_SEND_STOCK,C_AOG_STOCK_DEPT,C_AOG_STOCK,C_SEND_COM,C_SALE_COM,C_AOG_COM,C_SEND_AREA,C_SEND_ADDR,C_SEND_SITE,C_AOG_SITE,N_OUT_STOCK_WGT,N_SIGN_WGT,N_BACK_WGT,N_DAMAGE_WGT,D_FOR_PLAN_DT,C_FOR_PALN_ID,D_APPROVE_DT,C_APPROVE_ID,C_ORDER_TYPE,N_SORO_BACK,C_REMARK,C_BUSINESS_DEPT,C_BUSINESS_TYPE,C_SALESMAN,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_NO,:C_CON_NO,:D_PLANSEND_DT,:C_MAT_CODE,:C_MAT_NAME,:C_SPEC,:C_STL_GRD,:C_QUALIRY_LEV,:N_WGT,:N_SENDNUM_WGT,:C_ATSTATION,:C_AREA,:C_ADDR,:C_SHIPVIA,:C_CGC,:C_ORGO_CUST,:C_SEND_STOCK_DEPT,:N_STATUS,:D_ORRE_AOG_DT,:C_SEND_STOCK,:C_AOG_STOCK_DEPT,:C_AOG_STOCK,:C_SEND_COM,:C_SALE_COM,:C_AOG_COM,:C_SEND_AREA,:C_SEND_ADDR,:C_SEND_SITE,:C_AOG_SITE,:N_OUT_STOCK_WGT,:N_SIGN_WGT,:N_BACK_WGT,:N_DAMAGE_WGT,:D_FOR_PLAN_DT,:C_FOR_PALN_ID,:D_APPROVE_DT,:C_APPROVE_ID,:C_ORDER_TYPE,:N_SORO_BACK,:C_REMARK,:C_BUSINESS_DEPT,:C_BUSINESS_TYPE,:C_SALESMAN,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLANSEND_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUALIRY_LEV", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SENDNUM_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":D_ORRE_AOG_DT", OracleDbType.Date),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OUT_STOCK_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SIGN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_BACK_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_DAMAGE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":D_FOR_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":C_FOR_PALN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVE_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORO_BACK", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_BUSINESS_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALESMAN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_NO;
            parameters[2].Value = model.C_CON_NO;
            parameters[3].Value = model.D_PLANSEND_DT;
            parameters[4].Value = model.C_MAT_CODE;
            parameters[5].Value = model.C_MAT_NAME;
            parameters[6].Value = model.C_SPEC;
            parameters[7].Value = model.C_STL_GRD;
            parameters[8].Value = model.C_QUALIRY_LEV;
            parameters[9].Value = model.N_WGT;
            parameters[10].Value = model.N_SENDNUM_WGT;
            parameters[11].Value = model.C_ATSTATION;
            parameters[12].Value = model.C_AREA;
            parameters[13].Value = model.C_ADDR;
            parameters[14].Value = model.C_SHIPVIA;
            parameters[15].Value = model.C_CGC;
            parameters[16].Value = model.C_ORGO_CUST;
            parameters[17].Value = model.C_SEND_STOCK_DEPT;
            parameters[18].Value = model.N_STATUS;
            parameters[19].Value = model.D_ORRE_AOG_DT;
            parameters[20].Value = model.C_SEND_STOCK;
            parameters[21].Value = model.C_AOG_STOCK_DEPT;
            parameters[22].Value = model.C_AOG_STOCK;
            parameters[23].Value = model.C_SEND_COM;
            parameters[24].Value = model.C_SALE_COM;
            parameters[25].Value = model.C_AOG_COM;
            parameters[26].Value = model.C_SEND_AREA;
            parameters[27].Value = model.C_SEND_ADDR;
            parameters[28].Value = model.C_SEND_SITE;
            parameters[29].Value = model.C_AOG_SITE;
            parameters[30].Value = model.N_OUT_STOCK_WGT;
            parameters[31].Value = model.N_SIGN_WGT;
            parameters[32].Value = model.N_BACK_WGT;
            parameters[33].Value = model.N_DAMAGE_WGT;
            parameters[34].Value = model.D_FOR_PLAN_DT;
            parameters[35].Value = model.C_FOR_PALN_ID;
            parameters[36].Value = model.D_APPROVE_DT;
            parameters[37].Value = model.C_APPROVE_ID;
            parameters[38].Value = model.C_ORDER_TYPE;
            parameters[39].Value = model.N_SORO_BACK;
            parameters[40].Value = model.C_REMARK;
            parameters[41].Value = model.C_BUSINESS_DEPT;
            parameters[42].Value = model.C_BUSINESS_TYPE;
            parameters[43].Value = model.C_SALESMAN;
            parameters[44].Value = model.C_EMP_ID;
            parameters[45].Value = model.C_EMP_NAME;
            parameters[46].Value = model.D_MOD_DT;

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
        public bool Update(Mod_TMP_PLAN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMP_PLAN set ");
            strSql.Append("C_NO=:C_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("D_PLANSEND_DT=:D_PLANSEND_DT,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_QUALIRY_LEV=:C_QUALIRY_LEV,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("N_SENDNUM_WGT=:N_SENDNUM_WGT,");
            strSql.Append("C_ATSTATION=:C_ATSTATION,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_ADDR=:C_ADDR,");
            strSql.Append("C_SHIPVIA=:C_SHIPVIA,");
            strSql.Append("C_CGC=:C_CGC,");
            strSql.Append("C_ORGO_CUST=:C_ORGO_CUST,");
            strSql.Append("C_SEND_STOCK_DEPT=:C_SEND_STOCK_DEPT,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("D_ORRE_AOG_DT=:D_ORRE_AOG_DT,");
            strSql.Append("C_SEND_STOCK=:C_SEND_STOCK,");
            strSql.Append("C_AOG_STOCK_DEPT=:C_AOG_STOCK_DEPT,");
            strSql.Append("C_AOG_STOCK=:C_AOG_STOCK,");
            strSql.Append("C_SEND_COM=:C_SEND_COM,");
            strSql.Append("C_SALE_COM=:C_SALE_COM,");
            strSql.Append("C_AOG_COM=:C_AOG_COM,");
            strSql.Append("C_SEND_AREA=:C_SEND_AREA,");
            strSql.Append("C_SEND_ADDR=:C_SEND_ADDR,");
            strSql.Append("C_SEND_SITE=:C_SEND_SITE,");
            strSql.Append("C_AOG_SITE=:C_AOG_SITE,");
            strSql.Append("N_OUT_STOCK_WGT=:N_OUT_STOCK_WGT,");
            strSql.Append("N_SIGN_WGT=:N_SIGN_WGT,");
            strSql.Append("N_BACK_WGT=:N_BACK_WGT,");
            strSql.Append("N_DAMAGE_WGT=:N_DAMAGE_WGT,");
            strSql.Append("D_FOR_PLAN_DT=:D_FOR_PLAN_DT,");
            strSql.Append("C_FOR_PALN_ID=:C_FOR_PALN_ID,");
            strSql.Append("D_APPROVE_DT=:D_APPROVE_DT,");
            strSql.Append("C_APPROVE_ID=:C_APPROVE_ID,");
            strSql.Append("C_ORDER_TYPE=:C_ORDER_TYPE,");
            strSql.Append("N_SORO_BACK=:N_SORO_BACK,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_BUSINESS_DEPT=:C_BUSINESS_DEPT,");
            strSql.Append("C_BUSINESS_TYPE=:C_BUSINESS_TYPE,");
            strSql.Append("C_SALESMAN=:C_SALESMAN,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLANSEND_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUALIRY_LEV", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SENDNUM_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":D_ORRE_AOG_DT", OracleDbType.Date),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OUT_STOCK_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_SIGN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_BACK_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_DAMAGE_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":D_FOR_PLAN_DT", OracleDbType.Date),
                    new OracleParameter(":C_FOR_PALN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVE_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SORO_BACK", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_BUSINESS_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALESMAN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.D_PLANSEND_DT;
            parameters[3].Value = model.C_MAT_CODE;
            parameters[4].Value = model.C_MAT_NAME;
            parameters[5].Value = model.C_SPEC;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.C_QUALIRY_LEV;
            parameters[8].Value = model.N_WGT;
            parameters[9].Value = model.N_SENDNUM_WGT;
            parameters[10].Value = model.C_ATSTATION;
            parameters[11].Value = model.C_AREA;
            parameters[12].Value = model.C_ADDR;
            parameters[13].Value = model.C_SHIPVIA;
            parameters[14].Value = model.C_CGC;
            parameters[15].Value = model.C_ORGO_CUST;
            parameters[16].Value = model.C_SEND_STOCK_DEPT;
            parameters[17].Value = model.N_STATUS;
            parameters[18].Value = model.D_ORRE_AOG_DT;
            parameters[19].Value = model.C_SEND_STOCK;
            parameters[20].Value = model.C_AOG_STOCK_DEPT;
            parameters[21].Value = model.C_AOG_STOCK;
            parameters[22].Value = model.C_SEND_COM;
            parameters[23].Value = model.C_SALE_COM;
            parameters[24].Value = model.C_AOG_COM;
            parameters[25].Value = model.C_SEND_AREA;
            parameters[26].Value = model.C_SEND_ADDR;
            parameters[27].Value = model.C_SEND_SITE;
            parameters[28].Value = model.C_AOG_SITE;
            parameters[29].Value = model.N_OUT_STOCK_WGT;
            parameters[30].Value = model.N_SIGN_WGT;
            parameters[31].Value = model.N_BACK_WGT;
            parameters[32].Value = model.N_DAMAGE_WGT;
            parameters[33].Value = model.D_FOR_PLAN_DT;
            parameters[34].Value = model.C_FOR_PALN_ID;
            parameters[35].Value = model.D_APPROVE_DT;
            parameters[36].Value = model.C_APPROVE_ID;
            parameters[37].Value = model.C_ORDER_TYPE;
            parameters[38].Value = model.N_SORO_BACK;
            parameters[39].Value = model.C_REMARK;
            parameters[40].Value = model.C_BUSINESS_DEPT;
            parameters[41].Value = model.C_BUSINESS_TYPE;
            parameters[42].Value = model.C_SALESMAN;
            parameters[43].Value = model.C_EMP_ID;
            parameters[44].Value = model.C_EMP_NAME;
            parameters[45].Value = model.D_MOD_DT;
            parameters[46].Value = model.C_ID;

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
            strSql.Append("delete from TMP_PLAN ");
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
            strSql.Append("delete from TMP_PLAN ");
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
        public Mod_TMP_PLAN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NO,C_CON_NO,D_PLANSEND_DT,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_QUALIRY_LEV,N_WGT,N_SENDNUM_WGT,C_ATSTATION,C_AREA,C_ADDR,C_SHIPVIA,C_CGC,C_ORGO_CUST,C_SEND_STOCK_DEPT,N_STATUS,D_ORRE_AOG_DT,C_SEND_STOCK,C_AOG_STOCK_DEPT,C_AOG_STOCK,C_SEND_COM,C_SALE_COM,C_AOG_COM,C_SEND_AREA,C_SEND_ADDR,C_SEND_SITE,C_AOG_SITE,N_OUT_STOCK_WGT,N_SIGN_WGT,N_BACK_WGT,N_DAMAGE_WGT,D_FOR_PLAN_DT,C_FOR_PALN_ID,D_APPROVE_DT,C_APPROVE_ID,C_ORDER_TYPE,N_SORO_BACK,C_REMARK,C_BUSINESS_DEPT,C_BUSINESS_TYPE,C_SALESMAN,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMP_PLAN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMP_PLAN model = new Mod_TMP_PLAN();
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
        public Mod_TMP_PLAN DataRowToModel(DataRow row)
        {
            Mod_TMP_PLAN model = new Mod_TMP_PLAN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["D_PLANSEND_DT"] != null && row["D_PLANSEND_DT"].ToString() != "")
                {
                    model.D_PLANSEND_DT = DateTime.Parse(row["D_PLANSEND_DT"].ToString());
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
                if (row["C_QUALIRY_LEV"] != null)
                {
                    model.C_QUALIRY_LEV = row["C_QUALIRY_LEV"].ToString();
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["N_SENDNUM_WGT"] != null && row["N_SENDNUM_WGT"].ToString() != "")
                {
                    model.N_SENDNUM_WGT = decimal.Parse(row["N_SENDNUM_WGT"].ToString());
                }
                if (row["C_ATSTATION"] != null)
                {
                    model.C_ATSTATION = row["C_ATSTATION"].ToString();
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["C_ADDR"] != null)
                {
                    model.C_ADDR = row["C_ADDR"].ToString();
                }
                if (row["C_SHIPVIA"] != null)
                {
                    model.C_SHIPVIA = row["C_SHIPVIA"].ToString();
                }
                if (row["C_CGC"] != null)
                {
                    model.C_CGC = row["C_CGC"].ToString();
                }
                if (row["C_ORGO_CUST"] != null)
                {
                    model.C_ORGO_CUST = row["C_ORGO_CUST"].ToString();
                }
                if (row["C_SEND_STOCK_DEPT"] != null)
                {
                    model.C_SEND_STOCK_DEPT = row["C_SEND_STOCK_DEPT"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["D_ORRE_AOG_DT"] != null && row["D_ORRE_AOG_DT"].ToString() != "")
                {
                    model.D_ORRE_AOG_DT = DateTime.Parse(row["D_ORRE_AOG_DT"].ToString());
                }
                if (row["C_SEND_STOCK"] != null)
                {
                    model.C_SEND_STOCK = row["C_SEND_STOCK"].ToString();
                }
                if (row["C_AOG_STOCK_DEPT"] != null)
                {
                    model.C_AOG_STOCK_DEPT = row["C_AOG_STOCK_DEPT"].ToString();
                }
                if (row["C_AOG_STOCK"] != null)
                {
                    model.C_AOG_STOCK = row["C_AOG_STOCK"].ToString();
                }
                if (row["C_SEND_COM"] != null)
                {
                    model.C_SEND_COM = row["C_SEND_COM"].ToString();
                }
                if (row["C_SALE_COM"] != null)
                {
                    model.C_SALE_COM = row["C_SALE_COM"].ToString();
                }
                if (row["C_AOG_COM"] != null)
                {
                    model.C_AOG_COM = row["C_AOG_COM"].ToString();
                }
                if (row["C_SEND_AREA"] != null)
                {
                    model.C_SEND_AREA = row["C_SEND_AREA"].ToString();
                }
                if (row["C_SEND_ADDR"] != null)
                {
                    model.C_SEND_ADDR = row["C_SEND_ADDR"].ToString();
                }
                if (row["C_SEND_SITE"] != null)
                {
                    model.C_SEND_SITE = row["C_SEND_SITE"].ToString();
                }
                if (row["C_AOG_SITE"] != null)
                {
                    model.C_AOG_SITE = row["C_AOG_SITE"].ToString();
                }
                if (row["N_OUT_STOCK_WGT"] != null && row["N_OUT_STOCK_WGT"].ToString() != "")
                {
                    model.N_OUT_STOCK_WGT = decimal.Parse(row["N_OUT_STOCK_WGT"].ToString());
                }
                if (row["N_SIGN_WGT"] != null && row["N_SIGN_WGT"].ToString() != "")
                {
                    model.N_SIGN_WGT = decimal.Parse(row["N_SIGN_WGT"].ToString());
                }
                if (row["N_BACK_WGT"] != null && row["N_BACK_WGT"].ToString() != "")
                {
                    model.N_BACK_WGT = decimal.Parse(row["N_BACK_WGT"].ToString());
                }
                if (row["N_DAMAGE_WGT"] != null && row["N_DAMAGE_WGT"].ToString() != "")
                {
                    model.N_DAMAGE_WGT = decimal.Parse(row["N_DAMAGE_WGT"].ToString());
                }
                if (row["D_FOR_PLAN_DT"] != null && row["D_FOR_PLAN_DT"].ToString() != "")
                {
                    model.D_FOR_PLAN_DT = DateTime.Parse(row["D_FOR_PLAN_DT"].ToString());
                }
                if (row["C_FOR_PALN_ID"] != null)
                {
                    model.C_FOR_PALN_ID = row["C_FOR_PALN_ID"].ToString();
                }
                if (row["D_APPROVE_DT"] != null && row["D_APPROVE_DT"].ToString() != "")
                {
                    model.D_APPROVE_DT = DateTime.Parse(row["D_APPROVE_DT"].ToString());
                }
                if (row["C_APPROVE_ID"] != null)
                {
                    model.C_APPROVE_ID = row["C_APPROVE_ID"].ToString();
                }
                if (row["C_ORDER_TYPE"] != null)
                {
                    model.C_ORDER_TYPE = row["C_ORDER_TYPE"].ToString();
                }
                if (row["N_SORO_BACK"] != null && row["N_SORO_BACK"].ToString() != "")
                {
                    model.N_SORO_BACK = decimal.Parse(row["N_SORO_BACK"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_BUSINESS_DEPT"] != null)
                {
                    model.C_BUSINESS_DEPT = row["C_BUSINESS_DEPT"].ToString();
                }
                if (row["C_BUSINESS_TYPE"] != null)
                {
                    model.C_BUSINESS_TYPE = row["C_BUSINESS_TYPE"].ToString();
                }
                if (row["C_SALESMAN"] != null)
                {
                    model.C_SALESMAN = row["C_SALESMAN"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NO,C_CON_NO,D_PLANSEND_DT,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_QUALIRY_LEV,N_WGT,N_SENDNUM_WGT,C_ATSTATION,C_AREA,C_ADDR,C_SHIPVIA,C_CGC,C_ORGO_CUST,C_SEND_STOCK_DEPT,N_STATUS,D_ORRE_AOG_DT,C_SEND_STOCK,C_AOG_STOCK_DEPT,C_AOG_STOCK,C_SEND_COM,C_SALE_COM,C_AOG_COM,C_SEND_AREA,C_SEND_ADDR,C_SEND_SITE,C_AOG_SITE,N_OUT_STOCK_WGT,N_SIGN_WGT,N_BACK_WGT,N_DAMAGE_WGT,D_FOR_PLAN_DT,C_FOR_PALN_ID,D_APPROVE_DT,C_APPROVE_ID,C_ORDER_TYPE,N_SORO_BACK,C_REMARK,C_BUSINESS_DEPT,C_BUSINESS_TYPE,C_SALESMAN,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMP_PLAN ");
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
            strSql.Append("select count(1) FROM TMP_PLAN ");
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
            strSql.Append(")AS Row, T.*  from TMP_PLAN T ");
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetPlanList(string C_CON_NO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NO,C_CON_NO,D_PLANSEND_DT,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,C_QUALIRY_LEV,N_WGT,N_SENDNUM_WGT,C_ATSTATION,C_AREA,C_ADDR,C_SHIPVIA,C_CGC,C_ORGO_CUST,C_SEND_STOCK_DEPT,N_STATUS,D_ORRE_AOG_DT,C_SEND_STOCK,C_AOG_STOCK_DEPT,C_AOG_STOCK,C_SEND_COM,C_SALE_COM,C_AOG_COM,C_SEND_AREA,C_SEND_ADDR,C_SEND_SITE,C_AOG_SITE,N_OUT_STOCK_WGT,N_SIGN_WGT,N_BACK_WGT,N_DAMAGE_WGT,D_FOR_PLAN_DT,C_FOR_PALN_ID,D_APPROVE_DT,C_APPROVE_ID,C_ORDER_TYPE,N_SORO_BACK,C_REMARK,C_BUSINESS_DEPT,C_BUSINESS_TYPE,C_SALESMAN,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMP_PLAN  where C_CON_NO='" + C_CON_NO + "'");


            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新日计划
        /// </summary>
        /// <returns></returns>
        public bool UpdatePlan(Mod_TMO_CONDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMP_PLAN set ");
            strSql.Append("C_NO=:C_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("D_PLANSEND_DT=:D_PLANSEND_DT,");
            strSql.Append("C_MAT_CODE=:C_MAT_CODE,");
            strSql.Append("C_MAT_NAME=:C_MAT_NAME,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_ATSTATION=:C_ATSTATION,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_ADDR=:C_ADDR,");
            strSql.Append("C_CGC=:C_CGC,");
            strSql.Append("C_ORGO_CUST=:C_ORGO_CUST,");
            strSql.Append("C_SEND_STOCK_DEPT=:C_SEND_STOCK_DEPT,");
            strSql.Append("D_ORRE_AOG_DT=:D_ORRE_AOG_DT,");
            strSql.Append("C_SEND_STOCK=:C_SEND_STOCK,");
            strSql.Append("C_AOG_STOCK_DEPT=:C_AOG_STOCK_DEPT,");
            strSql.Append("C_SEND_COM=:C_SEND_COM,");
            strSql.Append("C_SALE_COM=:C_SALE_COM,");
            strSql.Append("C_AOG_COM=:C_AOG_COM,");
            strSql.Append("C_SEND_AREA=:C_SEND_AREA,");
            strSql.Append("C_SEND_ADDR=:C_SEND_ADDR,");
            strSql.Append("C_SEND_SITE=:C_SEND_SITE,");
            strSql.Append("C_AOG_SITE=:C_AOG_SITE,");
            strSql.Append("C_ORDER_TYPE=:C_ORDER_TYPE,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_NO=:C_NO ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLANSEND_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_ORRE_AOG_DT", OracleDbType.Date),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.D_DELIVERY_DT;
            parameters[3].Value = model.C_MAT_CODE;
            parameters[4].Value = model.C_MAT_NAME;
            parameters[5].Value = model.C_SPEC;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.N_WGT;
            parameters[8].Value = model.C_ATSTATION;
            parameters[9].Value = model.C_AREA;
            parameters[10].Value = model.C_ADDRESS;
            parameters[11].Value = model.C_RECEIPTCORPID;
            parameters[12].Value = model.C_CUST_NO;
            parameters[13].Value = "1001NC10000000000669";//发货库存组织
            parameters[14].Value = model.D_DELIVERY_DT;
            parameters[15].Value = "";//发货仓库
            parameters[16].Value = "1001NC10000000000669";//到货库存组织
            parameters[17].Value = "1001";//发货单位
            parameters[18].Value = "1001";//销售公司
            parameters[19].Value = model.C_RECEIPTCORPID;//到货公司
            parameters[20].Value = model.C_CRECEIPTAREAID;//发货地区
            parameters[21].Value = model.C_ADDRESS;//发货地址
            parameters[22].Value = model.C_ADDRESS;//发货地点
            parameters[23].Value = model.C_ADDRESS;//到货地点
            parameters[24].Value = model.N_TYPE;//订单类型
            parameters[25].Value = model.C_REMARK;
            parameters[26].Value = model.C_EMP_ID;
            parameters[27].Value = model.C_EMP_NAME;
            parameters[28].Value = model.D_MOD_DT;



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
        /// 添加日计划
        /// </summary>
        public bool AddPlan(Mod_TMO_CONDETAILS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMP_PLAN(");
            strSql.Append("C_NO,C_CON_NO,D_PLANSEND_DT,C_MAT_CODE,C_MAT_NAME,C_SPEC,C_STL_GRD,N_WGT,C_ATSTATION,C_AREA,C_ADDR,C_CGC,C_ORGO_CUST,C_SEND_STOCK_DEPT,D_ORRE_AOG_DT,C_SEND_STOCK,C_AOG_STOCK_DEPT,C_SEND_COM,C_SALE_COM,C_AOG_COM,C_SEND_AREA,C_SEND_ADDR,C_SEND_SITE,C_AOG_SITE,C_ORDER_TYPE,C_REMARK,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_NO,:C_CON_NO,:D_PLANSEND_DT,:C_MAT_CODE,:C_MAT_NAME,:C_SPEC,:C_STL_GRD,:N_WGT,:C_ATSTATION,:C_AREA,:C_ADDR,:C_CGC,:C_ORGO_CUST,:C_SEND_STOCK_DEPT,:D_ORRE_AOG_DT,:C_SEND_STOCK,:C_AOG_STOCK_DEPT,:C_SEND_COM,:C_SALE_COM,:C_AOG_COM,:C_SEND_AREA,:C_SEND_ADDR,:C_SEND_SITE,:C_AOG_SITE,:C_ORDER_TYPE,:C_REMARK,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_PLANSEND_DT", OracleDbType.Date),
                    new OracleParameter(":C_MAT_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CGC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORGO_CUST", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_ORRE_AOG_DT", OracleDbType.Date),
                    new OracleParameter(":C_SEND_STOCK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_STOCK_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SALE_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_COM", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_ADDR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SEND_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AOG_SITE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ORDER_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_NO;
            parameters[1].Value = model.C_CON_NO;
            parameters[2].Value = model.D_DELIVERY_DT;
            parameters[3].Value = model.C_MAT_CODE;
            parameters[4].Value = model.C_MAT_NAME;
            parameters[5].Value = model.C_SPEC;
            parameters[6].Value = model.C_STL_GRD;
            parameters[7].Value = model.N_WGT;
            parameters[8].Value = model.C_ATSTATION;
            parameters[9].Value = model.C_AREA;
            parameters[10].Value = model.C_ADDRESS;
            parameters[11].Value = model.C_RECEIPTCORPID;
            parameters[12].Value = model.C_CUST_NO;
            parameters[13].Value = "1001NC10000000000669";//发货库存组织
            parameters[14].Value = model.D_DELIVERY_DT;
            parameters[15].Value = "";//发货仓库
            parameters[16].Value = "1001NC10000000000669";//到货库存组织
            parameters[17].Value = "1001";//发货单位
            parameters[18].Value = "1001";//销售公司
            parameters[19].Value = model.C_RECEIPTCORPID;//到货公司
            parameters[20].Value = model.C_CRECEIPTAREAID;//发货地区
            parameters[21].Value = model.C_ADDRESS;//发货地址
            parameters[22].Value = model.C_ADDRESS;//发货地点
            parameters[23].Value = model.C_ADDRESS;//到货地点
            parameters[24].Value = model.N_TYPE;//订单类型
            parameters[25].Value = model.C_REMARK;
            parameters[26].Value = model.C_EMP_ID;
            parameters[27].Value = model.C_EMP_NAME;
            parameters[28].Value = model.D_MOD_DT;

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
        #endregion  ExtensionMethod
    }
}

