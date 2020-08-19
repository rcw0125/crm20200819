using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Collections;
using NF.MODEL;
using NF.DLL;
using System.Linq;
using ZXing;
using System.Drawing;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMD_DISPATCH
    /// </summary>
    public partial class Dal_TMD_DISPATCH
    {
        public Dal_TMD_DISPATCH()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMD_DISPATCH");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_DISPATCH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMD_DISPATCH(");
            strSql.Append("C_ID,C_PLAN_ID,C_GPS_NO,C_NO,C_CON_NO,D_DISP_DT,C_SHIPVIA,C_COMCAR,C_PATH,C_PATH_DESC,C_SEND_DEPT,C_BUSINESS_DEPT,C_BUSINESS_ID,C_IS_WIRESALE,N_IS_EXPORT,C_LIC_PLA_NO,C_ATSTATION,D_APPROVE_DT,D_CREATE_DT,C_APPROVE_ID,C_CREATE_ID,C_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_GUID,C_IS_WIRESALE_ID,C_REMARK,C_REMARK2,D_FAILURE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_PLAN_ID,:C_GPS_NO,:C_NO,:C_CON_NO,:D_DISP_DT,:C_SHIPVIA,:C_COMCAR,:C_PATH,:C_PATH_DESC,:C_SEND_DEPT,:C_BUSINESS_DEPT,:C_BUSINESS_ID,:C_IS_WIRESALE,:N_IS_EXPORT,:C_LIC_PLA_NO,:C_ATSTATION,:D_APPROVE_DT,:D_CREATE_DT,:C_APPROVE_ID,:C_CREATE_ID,:C_STATUS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:C_GUID,:C_IS_WIRESALE_ID,:C_REMARK,:C_REMARK2,:D_FAILURE,:C_EXTEND1,:C_EXTEND2,:C_EXTEND3,:C_EXTEND4,:C_EXTEND5)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GPS_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DISP_DT", OracleDbType.Date),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COMCAR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PATH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PATH_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SEND_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_WIRESALE", OracleDbType.Varchar2,2),
                    new OracleParameter(":N_IS_EXPORT", OracleDbType.Decimal,1),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVE_DT", OracleDbType.Date),
                    new OracleParameter(":D_CREATE_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STATUS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_GUID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_WIRESALE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_FAILURE", OracleDbType.Date),
                    new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND5", OracleDbType.Varchar2,500)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_PLAN_ID;
            parameters[2].Value = model.C_GPS_NO;
            parameters[3].Value = model.C_NO;
            parameters[4].Value = model.C_CON_NO;
            parameters[5].Value = model.D_DISP_DT;
            parameters[6].Value = model.C_SHIPVIA;
            parameters[7].Value = model.C_COMCAR;
            parameters[8].Value = model.C_PATH;
            parameters[9].Value = model.C_PATH_DESC;
            parameters[10].Value = model.C_SEND_DEPT;
            parameters[11].Value = model.C_BUSINESS_DEPT;
            parameters[12].Value = model.C_BUSINESS_ID;
            parameters[13].Value = model.C_IS_WIRESALE;
            parameters[14].Value = model.N_IS_EXPORT;
            parameters[15].Value = model.C_LIC_PLA_NO;
            parameters[16].Value = model.C_ATSTATION;
            parameters[17].Value = model.D_APPROVE_DT;
            parameters[18].Value = model.D_CREATE_DT;
            parameters[19].Value = model.C_APPROVE_ID;
            parameters[20].Value = model.C_CREATE_ID;
            parameters[21].Value = model.C_STATUS;
            parameters[22].Value = model.C_EMP_ID;
            parameters[23].Value = model.C_EMP_NAME;
            parameters[24].Value = model.D_MOD_DT;
            parameters[25].Value = model.C_GUID;
            parameters[26].Value = model.C_IS_WIRESALE_ID;
            parameters[27].Value = model.C_REMARK;
            parameters[28].Value = model.C_REMARK2;
            parameters[29].Value = model.D_FAILURE;
            parameters[30].Value = model.C_EXTEND1;
            parameters[31].Value = model.C_EXTEND2;
            parameters[32].Value = model.C_EXTEND3;
            parameters[33].Value = model.C_EXTEND4;
            parameters[34].Value = model.C_EXTEND5;

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
        public bool Update(Mod_TMD_DISPATCH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_DISPATCH set ");
            strSql.Append("C_PLAN_ID=:C_PLAN_ID,");
            strSql.Append("C_GPS_NO=:C_GPS_NO,");
            strSql.Append("C_NO=:C_NO,");
            strSql.Append("C_CON_NO=:C_CON_NO,");
            strSql.Append("D_DISP_DT=:D_DISP_DT,");
            strSql.Append("C_SHIPVIA=:C_SHIPVIA,");
            strSql.Append("C_COMCAR=:C_COMCAR,");
            strSql.Append("C_PATH=:C_PATH,");
            strSql.Append("C_PATH_DESC=:C_PATH_DESC,");
            strSql.Append("C_SEND_DEPT=:C_SEND_DEPT,");
            strSql.Append("C_BUSINESS_DEPT=:C_BUSINESS_DEPT,");
            strSql.Append("C_BUSINESS_ID=:C_BUSINESS_ID,");
            strSql.Append("C_IS_WIRESALE=:C_IS_WIRESALE,");
            strSql.Append("N_IS_EXPORT=:N_IS_EXPORT,");
            strSql.Append("C_LIC_PLA_NO=:C_LIC_PLA_NO,");
            strSql.Append("C_ATSTATION=:C_ATSTATION,");
            strSql.Append("D_APPROVE_DT=:D_APPROVE_DT,");
            strSql.Append("D_CREATE_DT=:D_CREATE_DT,");
            strSql.Append("C_APPROVE_ID=:C_APPROVE_ID,");
            strSql.Append("C_CREATE_ID=:C_CREATE_ID,");
            strSql.Append("C_STATUS=:C_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_GUID=:C_GUID,");
            strSql.Append("C_IS_WIRESALE_ID=:C_IS_WIRESALE_ID,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_REMARK2=:C_REMARK2,");
            strSql.Append("D_FAILURE=:D_FAILURE,");
            strSql.Append("C_EXTEND1=:C_EXTEND1,");
            strSql.Append("C_EXTEND2=:C_EXTEND2,");
            strSql.Append("C_EXTEND3=:C_EXTEND3,");
            strSql.Append("C_EXTEND4=:C_EXTEND4,");
            strSql.Append("C_EXTEND5=:C_EXTEND5");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_PLAN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_GPS_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CON_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_DISP_DT", OracleDbType.Date),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COMCAR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PATH", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PATH_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SEND_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BUSINESS_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_WIRESALE", OracleDbType.Varchar2,2),
                    new OracleParameter(":N_IS_EXPORT", OracleDbType.Decimal,1),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ATSTATION", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVE_DT", OracleDbType.Date),
                    new OracleParameter(":D_CREATE_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CREATE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STATUS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_GUID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_IS_WIRESALE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_REMARK2", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_FAILURE", OracleDbType.Date),
                    new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND5", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_PLAN_ID;
            parameters[1].Value = model.C_GPS_NO;
            parameters[2].Value = model.C_NO;
            parameters[3].Value = model.C_CON_NO;
            parameters[4].Value = model.D_DISP_DT;
            parameters[5].Value = model.C_SHIPVIA;
            parameters[6].Value = model.C_COMCAR;
            parameters[7].Value = model.C_PATH;
            parameters[8].Value = model.C_PATH_DESC;
            parameters[9].Value = model.C_SEND_DEPT;
            parameters[10].Value = model.C_BUSINESS_DEPT;
            parameters[11].Value = model.C_BUSINESS_ID;
            parameters[12].Value = model.C_IS_WIRESALE;
            parameters[13].Value = model.N_IS_EXPORT;
            parameters[14].Value = model.C_LIC_PLA_NO;
            parameters[15].Value = model.C_ATSTATION;
            parameters[16].Value = model.D_APPROVE_DT;
            parameters[17].Value = model.D_CREATE_DT;
            parameters[18].Value = model.C_APPROVE_ID;
            parameters[19].Value = model.C_CREATE_ID;
            parameters[20].Value = model.C_STATUS;
            parameters[21].Value = model.C_EMP_ID;
            parameters[22].Value = model.C_EMP_NAME;
            parameters[23].Value = model.D_MOD_DT;
            parameters[24].Value = model.C_GUID;
            parameters[25].Value = model.C_IS_WIRESALE_ID;
            parameters[26].Value = model.C_REMARK;
            parameters[27].Value = model.C_REMARK2;
            parameters[28].Value = model.D_FAILURE;
            parameters[29].Value = model.C_EXTEND1;
            parameters[30].Value = model.C_EXTEND2;
            parameters[31].Value = model.C_EXTEND3;
            parameters[32].Value = model.C_EXTEND4;
            parameters[33].Value = model.C_EXTEND5;
            parameters[34].Value = model.C_ID;

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
            strSql.Append("delete from TMD_DISPATCH ");
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
            strSql.Append("delete from TMD_DISPATCH ");
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
        public Mod_TMD_DISPATCH GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_PLAN_ID,C_GPS_NO,C_NO,C_CON_NO,D_DISP_DT,C_SHIPVIA,C_COMCAR,C_PATH,C_PATH_DESC,C_SEND_DEPT,C_BUSINESS_DEPT,C_BUSINESS_ID,C_IS_WIRESALE,N_IS_EXPORT,C_LIC_PLA_NO,C_ATSTATION,D_APPROVE_DT,D_CREATE_DT,C_APPROVE_ID,C_CREATE_ID,C_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_GUID,C_IS_WIRESALE_ID,C_REMARK,C_REMARK2,D_FAILURE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_CUSTNAME,N_QUA,N_WGT from TMD_DISPATCH ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TMD_DISPATCH model = new Mod_TMD_DISPATCH();
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
        public Mod_TMD_DISPATCH DataRowToModel(DataRow row)
        {
            Mod_TMD_DISPATCH model = new Mod_TMD_DISPATCH();
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
                if (row["C_GPS_NO"] != null)
                {
                    model.C_GPS_NO = row["C_GPS_NO"].ToString();
                }
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
                }
                if (row["C_CON_NO"] != null)
                {
                    model.C_CON_NO = row["C_CON_NO"].ToString();
                }
                if (row["D_DISP_DT"] != null && row["D_DISP_DT"].ToString() != "")
                {
                    model.D_DISP_DT = DateTime.Parse(row["D_DISP_DT"].ToString());
                }
                if (row["C_SHIPVIA"] != null)
                {
                    model.C_SHIPVIA = row["C_SHIPVIA"].ToString();
                }
                if (row["C_COMCAR"] != null)
                {
                    model.C_COMCAR = row["C_COMCAR"].ToString();
                }
                if (row["C_PATH"] != null)
                {
                    model.C_PATH = row["C_PATH"].ToString();
                }
                if (row["C_PATH_DESC"] != null)
                {
                    model.C_PATH_DESC = row["C_PATH_DESC"].ToString();
                }
                if (row["C_SEND_DEPT"] != null)
                {
                    model.C_SEND_DEPT = row["C_SEND_DEPT"].ToString();
                }
                if (row["C_BUSINESS_DEPT"] != null)
                {
                    model.C_BUSINESS_DEPT = row["C_BUSINESS_DEPT"].ToString();
                }
                if (row["C_BUSINESS_ID"] != null)
                {
                    model.C_BUSINESS_ID = row["C_BUSINESS_ID"].ToString();
                }
                if (row["C_IS_WIRESALE"] != null)
                {
                    model.C_IS_WIRESALE = row["C_IS_WIRESALE"].ToString();
                }
                if (row["N_IS_EXPORT"] != null && row["N_IS_EXPORT"].ToString() != "")
                {
                    model.N_IS_EXPORT = decimal.Parse(row["N_IS_EXPORT"].ToString());
                }
                if (row["C_LIC_PLA_NO"] != null)
                {
                    model.C_LIC_PLA_NO = row["C_LIC_PLA_NO"].ToString();
                }
                if (row["C_ATSTATION"] != null)
                {
                    model.C_ATSTATION = row["C_ATSTATION"].ToString();
                }
                if (row["D_APPROVE_DT"] != null && row["D_APPROVE_DT"].ToString() != "")
                {
                    model.D_APPROVE_DT = DateTime.Parse(row["D_APPROVE_DT"].ToString());
                }
                if (row["D_CREATE_DT"] != null && row["D_CREATE_DT"].ToString() != "")
                {
                    model.D_CREATE_DT = DateTime.Parse(row["D_CREATE_DT"].ToString());
                }
                if (row["C_APPROVE_ID"] != null)
                {
                    model.C_APPROVE_ID = row["C_APPROVE_ID"].ToString();
                }
                if (row["C_CREATE_ID"] != null)
                {
                    model.C_CREATE_ID = row["C_CREATE_ID"].ToString();
                }
                if (row["C_STATUS"] != null)
                {
                    model.C_STATUS = row["C_STATUS"].ToString();
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
                if (row["C_GUID"] != null)
                {
                    model.C_GUID = row["C_GUID"].ToString();
                }
                if (row["C_IS_WIRESALE_ID"] != null)
                {
                    model.C_IS_WIRESALE_ID = row["C_IS_WIRESALE_ID"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_REMARK2"] != null)
                {
                    model.C_REMARK2 = row["C_REMARK2"].ToString();
                }
                if (row["D_FAILURE"] != null && row["D_FAILURE"].ToString() != "")
                {
                    model.D_FAILURE = DateTime.Parse(row["D_FAILURE"].ToString());
                }
                if (row["C_EXTEND1"] != null)
                {
                    model.C_EXTEND1 = row["C_EXTEND1"].ToString();
                }
                if (row["C_EXTEND2"] != null)
                {
                    model.C_EXTEND2 = row["C_EXTEND2"].ToString();
                }
                if (row["C_EXTEND3"] != null)
                {
                    model.C_EXTEND3 = row["C_EXTEND3"].ToString();
                }
                if (row["C_EXTEND4"] != null)
                {
                    model.C_EXTEND4 = row["C_EXTEND4"].ToString();
                }
                if (row["C_EXTEND5"] != null)
                {
                    model.C_EXTEND5 = row["C_EXTEND5"].ToString();
                }
                if (row["C_CUSTNAME"] != null)
                {
                    model.C_CUSTNAME = row["C_CUSTNAME"].ToString();
                }
                if (row["N_QUA"] != null && row["N_QUA"].ToString() != "")
                {
                    model.N_QUA = decimal.Parse(row["N_QUA"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
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
            strSql.Append("select C_ID,C_PLAN_ID,C_GPS_NO,C_NO,C_CON_NO,D_DISP_DT,C_SHIPVIA,C_COMCAR,C_PATH,C_PATH_DESC,C_SEND_DEPT,C_BUSINESS_DEPT,C_BUSINESS_ID,C_IS_WIRESALE,N_IS_EXPORT,C_LIC_PLA_NO,C_ATSTATION,D_APPROVE_DT,D_CREATE_DT,C_APPROVE_ID,C_CREATE_ID,C_STATUS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_GUID,C_IS_WIRESALE_ID,C_REMARK,C_REMARK2,D_FAILURE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_CUSTNAME,N_QUA,N_WGT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string sfbj)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT T.C_ID,
                                   T.C_PLAN_ID,
                                   T.D_DISP_DT,
                                   A.C_DETAILNAME AS C_SHIPVIA,
                                   B.C_DETAILNAME AS C_COMCAR,
                                   T.C_IS_WIRESALE,
                                   T.C_LIC_PLA_NO,
                                   T.C_EXTEND2,--虚拟车号
                                   T.C_EXTEND3,--司机姓名
                                   T.C_EXTEND4,--司机电话
                                   T.C_ATSTATION,
                                   T.C_EMP_NAME,
                                   T.D_MOD_DT,
                                   C.C_NAME AS C_CREATE_ID,
                                   T.D_CREATE_DT,
                                   T.C_CUSTNAME,
                                   T.C_STATUS,
                                   T.N_QUA,
                                   T.N_WGT,
                                   T.C_GPS_NO,
                                   T.C_CUSTNAME AS C_ORGO_CUST,
                                   (SELECT DISTINCT MAX(D.C_CON_NO)
                                      FROM TMD_DISPATCHDETAILS D
                                     WHERE D.C_DISPATCH_ID = T.C_ID) C_CON_NO
                              FROM TMD_DISPATCH T
                             INNER JOIN TS_DIC A
                                ON A.C_DETAILCODE = T.C_SHIPVIA
                              LEFT JOIN TS_DIC B
                                ON B.C_DETAILCODE = T.C_COMCAR
                             INNER JOIN TS_USER C
                                ON C.C_ID = T.C_CREATE_ID
                             WHERE 1 = 1 ");

            strSql.AppendFormat(" AND T.N_IS_EXPORT={0}", sfbj);

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" AND T.C_ID = '{0}'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" AND (T.C_LIC_PLA_NO LIKE '%{0}%' OR T.C_EXTEND2 LIKE '%{0}%')", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" AND (T.C_CUSTNAME LIKE '%{0}%' OR T.C_CON_NO LIKE '%{0}%')", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" AND C.C_NAME LIKE '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" AND T.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" AND T.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" AND T.D_CREATE_DT BETWEEN TO_DATE('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" ORDER BY T.C_ID ASC");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_WL(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string sfbj, string ischeck)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT T.C_ID,
                                   T.C_PLAN_ID,
                                   T.D_DISP_DT,
                                   A.C_DETAILNAME AS C_SHIPVIA,
                                   B.C_DETAILNAME AS C_COMCAR,
                                   T.C_IS_WIRESALE,
                                   T.C_LIC_PLA_NO,
                                   T.C_EXTEND2, --虚拟车号
                                   T.C_EXTEND3, --司机姓名
                                   T.C_EXTEND4, --司机电话
                                   T.C_ATSTATION,
                                   T.C_EMP_NAME,
                                   T.D_MOD_DT,
                                   C.C_NAME AS C_CREATE_ID,
                                   T.D_CREATE_DT,
                                   T.C_CUSTNAME,
                                   T.C_STATUS,
                                   T.N_QUA,
                                   T.N_WGT,
                                   T.C_GPS_NO,
                                   T.C_CUSTNAME AS C_ORGO_CUST,
                                   (SELECT DISTINCT MAX(D.C_CON_NO)
                                      FROM TMD_DISPATCHDETAILS D
                                     WHERE D.C_DISPATCH_ID = T.C_ID) C_CON_NO,
                                   NVL(D.C_ISCHECK, 'Y') C_ISCHECK
                              FROM TMD_DISPATCH T
                             INNER JOIN TS_DIC A
                                ON A.C_DETAILCODE = T.C_SHIPVIA
                              LEFT JOIN TS_DIC B
                                ON B.C_DETAILCODE = T.C_COMCAR
                             INNER JOIN TS_USER C
                                ON C.C_ID = T.C_CREATE_ID
                              LEFT JOIN TMC_TRAIN_MAIN D
                                ON D.C_ID = T.C_ID
                             WHERE (D.C_ISCHECK='{0}' OR D.C_ISCHECK IS NULL) ", ischeck);

            strSql.AppendFormat(" AND T.N_IS_EXPORT={0}", sfbj);

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" AND T.C_ID = '{0}'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" AND (T.C_LIC_PLA_NO LIKE '%{0}%' OR T.C_EXTEND2 LIKE '%{0}%')", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" AND (T.C_CUSTNAME LIKE '%{0}%' OR T.C_CON_NO LIKE '%{0}%')", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" AND C.C_NAME LIKE '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" AND T.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" AND T.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" AND T.D_CREATE_DT BETWEEN TO_DATE('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" ORDER BY T.C_ID ASC");
            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select count(1)  from tmd_dispatch t  where 1=1");

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" and t.C_ID like '%{0}%'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" and t.C_LIC_PLA_NO like '%{0}%'", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" and t.C_CUSTNAME like '%{0}%'", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" and t.C_EMP_NAME like '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" and t.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" and t.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and t.D_CREATE_DT between to_date('" + startTime + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endTime).AddDays(1).ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        /// 获取记录总数
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <param name="cheHao">车号</param>
        /// <param name="custName">客户</param>
        /// <param name="empName">制单人</param>
        /// <param name="fyFS">发运方式</param>
        /// <param name="YN">是否线材销售</param>
        /// <param name="startTime">制单开始时间</param>
        /// <param name="endTime">制单截至时间</param>
        /// <param name="dz">到站</param>
        /// <returns></returns>
        public int GetRecordCount(string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string dz)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select count(1)
                                  from tmd_dispatch t
                                  left join ts_user a
                                    on a.c_id = t.C_CREATE_ID
                                 where 1 = 1  ");

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" and t.C_ID = '{0}'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" and t.C_LIC_PLA_NO like '%{0}%'", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" and t.C_CUSTNAME like '%{0}%'", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" and a.c_name like '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" and t.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" and t.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(dz))
            {
                strSql.AppendFormat(" and t.C_ATSTATION = '{0}'", dz);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and t.D_CREATE_DT between to_date('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.C_ID,
                       t.C_PLAN_ID,
                       t.D_DISP_DT,
                       a.c_detailname  as C_SHIPVIA,
                       b.c_detailname  as C_COMCAR,
                       t.C_IS_WIRESALE,
                       t.C_LIC_PLA_NO,
                       t.C_ATSTATION,
                       t.C_EMP_NAME,
                       t.D_MOD_DT,
                       c.c_name as C_CREATE_ID,
                       t.D_CREATE_DT,
                       t.C_CUSTNAME,
                       t.C_STATUS,
                       t.N_QUA,
                       t.N_WGT
                  from tmd_dispatch t
                 inner join ts_dic a
                    on a.c_detailcode = t.C_SHIPVIA
                 left join ts_dic b
                    on b.c_detailcode = t.C_COMCAR
                    inner join ts_user c on c.c_id=t.C_CREATE_ID
                 where 1=1");

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" and t.C_ID = '{0}'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" and t.C_LIC_PLA_NO like '%{0}%'", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" and t.C_CUSTNAME like '%{0}%'", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" and c.c_name like '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" and t.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" and t.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and t.D_CREATE_DT between to_date('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" order by t.D_CREATE_DT desc");
            return DataSetHelper.SplitDataSet(DbHelperOra.Query(strSql.ToString()), pageSize, startIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="startIndex">起始页数</param>
        /// <param name="sendCode">发运单号</param>
        /// <param name="cheHao">车号</param>
        /// <param name="custName">客户</param>
        /// <param name="empName">制单人</param>
        /// <param name="fyFS">发运方式</param>
        /// <param name="YN">是否线材销售</param>
        /// <param name="startTime">制单开始时间</param>
        /// <param name="endTime">制单截至时间</param>
        /// <param name="dz">到站</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string sendCode, string cheHao, string custName, string empName, string fyFS, string YN, string startTime, string endTime, string dz)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select t.C_ID,
                       t.C_PLAN_ID,
                       t.D_DISP_DT,
                       a.c_detailname  as C_SHIPVIA,
                       b.c_detailname  as C_COMCAR,
                       t.C_IS_WIRESALE,
                       t.C_LIC_PLA_NO,
                       t.C_ATSTATION,
                       t.C_EMP_NAME,
                       t.D_MOD_DT,
                       c.c_name as C_CREATE_ID,
                       t.D_CREATE_DT,
                       t.C_CUSTNAME,
                       t.C_STATUS,
                       t.N_QUA,
                       t.N_WGT
                  from tmd_dispatch t
                 inner join ts_dic a
                    on a.c_detailcode = t.C_SHIPVIA
                 left join ts_dic b
                    on b.c_detailcode = t.C_COMCAR
                    inner join ts_user c on c.c_id=t.C_CREATE_ID
                 where 1=1");

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.AppendFormat(" and t.C_ID = '{0}'", sendCode);
            }
            if (!string.IsNullOrEmpty(cheHao))
            {
                strSql.AppendFormat(" and t.C_LIC_PLA_NO like '%{0}%'", cheHao);
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" and t.C_CUSTNAME like '%{0}%'", custName);
            }
            if (!string.IsNullOrEmpty(empName))
            {
                strSql.AppendFormat(" and t.C_EMP_NAME like '%{0}%'", empName);
            }
            if (!string.IsNullOrEmpty(fyFS))
            {
                strSql.AppendFormat(" and t.C_SHIPVIA = '{0}'", fyFS);
            }
            if (!string.IsNullOrEmpty(YN))
            {
                strSql.AppendFormat(" and t.C_IS_WIRESALE = '{0}'", YN);
            }
            if (!string.IsNullOrEmpty(dz))
            {
                strSql.AppendFormat(" and t.C_ATSTATION = '{0}'", dz);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and t.D_CREATE_DT between to_date('" + Convert.ToDateTime(startTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') and to_date('" + Convert.ToDateTime(endTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(" order by t.D_CREATE_DT desc");
            return DataSetHelper.SplitDataSet(DbHelperOra.Query(strSql.ToString()), pageSize, startIndex);
        }
        #endregion  BasicMethod

        /// <summary>
        /// 出库单查询
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <param name="chehao">车牌号</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public DataSet GetStockOut(string sendCode, string chehao, string startDate, string endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT T.C_DISPATCH_ID,
                               T.C_CKDH,
                               T.C_SEND_STOCK,
                               (CASE T.N_STATUS
                                 WHEN 8 THEN
                                  T.C_BATCH_NO
                                 WHEN 6 THEN
                                  T.C_STOVE
                               END) BIANHAO,
                               T.C_MAT_NAME,
                               T.C_STL_GRD,
                               T.C_SPEC,
                               T.N_NUM,
                               T.N_JZ,
                               T.C_TICK_STR
                          FROM TMD_DISPATCH_SJZJB T
                         INNER JOIN TMD_DISPATCH A
                            ON A.C_ID = T.C_DISPATCH_ID
                         WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.Append(" AND  A.C_ID='" + sendCode + "'");
            }
            if (!string.IsNullOrEmpty(chehao))
            {
                strSql.Append(" AND  A.C_LIC_PLA_NO='" + chehao + "'");
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" AND A.D_DISP_DT BETWEEN TO_DATE('" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 出库单查询
        /// </summary>
        /// <param name="sendCode">发运单号</param>
        /// <returns></returns>
        public DataSet GetStockOut(string sendCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT T.C_ID,
                           T.C_DISPATCH_ID,
                           T.C_CKDH,
                           T.C_SEND_STOCK,
                           T.C_BATCH_NO,
                           T.C_STOVE,
                           T.C_MAT_CODE,
                           T.C_MAT_NAME,
                           T.C_STL_GRD,
                           T.C_SPEC,
                           T.N_NUM,
                           T.N_JZ,
                           t.N_WGT,
                           T.C_TICK_STR,
                           T.D_CKSJ
                      FROM TMD_DISPATCH_SJZJB T WHERE 1=1 ");

            if (!string.IsNullOrEmpty(sendCode))
            {
                strSql.Append(" AND  T.C_DISPATCH_ID='" + sendCode + "'");
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 修改钢坯销售出库量
        /// </summary>
        /// <param name="list">参数 ID，发运单号，净重</param>
        /// <returns></returns>
        public bool UpdateStockOut(List<Mod_TMD_DISPATCH_SJZJB> list)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string cmdText = $@"UPDATE TMD_DISPATCH_SJZJB SET N_JZ={list[i].N_JZ} WHERE C_ID='{list[i].C_ID}' AND C_DISPATCH_ID='{list[i].C_DISPATCH_ID}'";
                arraySql.Add(cmdText);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }




        /// <summary>
        /// 获取钢坯仓库主键
        /// </summary>
        /// <param name="code">仓库编码</param>
        /// <returns></returns>
        public DataRow GetStock(string code)
        {
            string strSql = string.Format("SELECT T.C_ID,T.C_SLABWH_CODE,T.C_SLABWH_NAME FROM TPB_SLABWH T WHERE T.C_SLABWH_CODE='{0}'", code);
            return DbHelperOra.GetDataRow(strSql);
        }

        /// <summary>
        /// 获取获取线材/钢坯仓库列表
        /// </summary>
        /// <param name="pkid">仓库主键</param>
        /// <returns></returns>
        public DataRow GetStockList(string pkid)
        {

            string cmd = string.Format(@"SELECT TT.C_ID,TT.CKCODE
                                          FROM (SELECT T.C_ID, T.C_SLABWH_CODE AS CKCODE
                                                  FROM TPB_SLABWH T
                                                UNION
                                                SELECT T.C_ID, T.C_LINEWH_CODE AS CKCODE
                                                  FROM TPB_LINEWH T) TT
                                         WHERE TT.C_ID = '{0}'", pkid);

            return DbHelperOra.GetDataRow(cmd);
        }

        /// <summary>
        ///批量添加发运单
        /// </summary>
        /// <param name="modhead">表头</param>
        /// <param name="item">表体</param>
        /// <returns></returns>
        public bool InsertFYD(Mod_TMD_DISPATCH modhead, List<Mod_TMD_DISPATCHDETAILS> item)
        {
            ArrayList arraySql = new ArrayList();

            #region //表头
            if (modhead != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into TMD_DISPATCH(");
                strSql.Append("C_ID,");//发运单单据号
                strSql.Append("C_GPS_NO,");//GPS号
                strSql.Append("D_DISP_DT,");//发运日期
                strSql.Append("C_SHIPVIA,");//发运方式
                strSql.Append("C_COMCAR,");//承运商
                strSql.Append("C_IS_WIRESALE,");//字符是否线材
                strSql.Append("C_IS_WIRESALE_ID,");//是否线材主键
                strSql.Append("C_LIC_PLA_NO,");//车牌号
                strSql.Append("C_ATSTATION,");//到站
                strSql.Append("C_CREATE_ID,");//制单人
                strSql.Append("C_EMP_ID,");//修改人ID
                strSql.Append("C_EMP_NAME,");//修改人
                strSql.Append("C_EXTEND5,");//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                strSql.Append("C_CUSTNAME,");//客户
                strSql.Append("C_CON_NO,");//合同号
                strSql.Append("C_BUSINESS_DEPT,");//业务部门
                strSql.Append("C_BUSINESS_ID,");//业务员
                strSql.Append("N_QUA,");//发运支数
                strSql.Append("N_WGT,");//发运量
                strSql.Append("N_IS_EXPORT,");//是否包到价
                strSql.Append("C_EXTEND2,");//虚拟车号
                strSql.Append("C_EXTEND4,");//客户姓名/电话
                strSql.Append("C_EXTEND3");//司机姓名/电话
                strSql.Append(")values(");
                strSql.Append("'" + modhead.C_ID + "',");
                strSql.Append("'" + modhead.C_GPS_NO + "',");
                strSql.Append("to_date('" + Convert.ToDateTime(modhead.D_DISP_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");
                strSql.Append("'" + modhead.C_SHIPVIA + "',");
                strSql.Append("'" + modhead.C_COMCAR + "',");
                strSql.Append("'" + modhead.C_IS_WIRESALE + "',");
                strSql.Append("'" + modhead.C_IS_WIRESALE_ID + "',");
                strSql.Append("'" + modhead.C_LIC_PLA_NO + "',");
                strSql.Append("'" + modhead.C_ATSTATION + "',");
                strSql.Append("'" + modhead.C_CREATE_ID + "',");
                strSql.Append("'" + modhead.C_EMP_ID + "',");
                strSql.Append("'" + modhead.C_EMP_NAME + "',");
                strSql.Append("'" + modhead.C_EXTEND5 + "',");
                strSql.Append("'" + modhead.C_CUSTNAME + "',");
                strSql.Append("'" + modhead.C_CON_NO + "',");
                strSql.Append("'" + modhead.C_BUSINESS_DEPT + "',");
                strSql.Append("'" + modhead.C_BUSINESS_ID + "',");
                strSql.Append("" + modhead.N_QUA + ",");
                strSql.Append("" + modhead.N_WGT + ",");
                strSql.Append("" + modhead.N_IS_EXPORT + ",");//是否包到价
                strSql.Append("'" + modhead.C_EXTEND2 + "',");//虚拟车号
                strSql.Append("'" + modhead.C_EXTEND4 + "',");//客户姓名/电话
                strSql.Append("'" + modhead.C_EXTEND3 + "'");//司机姓名/电话
                strSql.Append(")");
                arraySql.Add(strSql.ToString());
            }
            #endregion

            #region //表体
            for (int i = 0; i < item.Count; i++)
            {

                string ckcode = "";
                if (!string.IsNullOrEmpty(item[i].C_SEND_STOCK_PK))
                {
                    DataRow drck = GetStockList(item[i].C_SEND_STOCK_PK);
                    if (drck != null)
                    {
                        ckcode = drck["CKCODE"].ToString();
                    }
                }

                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into tmd_dispatchdetails(");
                strSql2.Append("C_DISPATCH_ID,");//发运单单据号
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_QUALIRY_LEV,");//质量等级主键
                strSql2.Append("C_JUDGE_LEV_ZH,");//质量等级编码
                strSql2.Append("C_FREE_TERM,");//自由项
                strSql2.Append("C_FREE_TERM2,");//自由项2
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("C_ELSENEED,");//其他要求
                strSql2.Append("C_REMARK,");//行备注
                strSql2.Append("N_COM_AMOUNT_WGT,");//原订单辅数量
                strSql2.Append("N_WGT,");//原订单数量
                strSql2.Append("C_EQUATION_FACTOR,");//换算率
                strSql2.Append("C_UNITIS,");//主计量单位ID
                strSql2.Append("C_ORGO_CUST,");//订货客户
                strSql2.Append("C_CGC,");//收货单位
                strSql2.Append("C_ORDER_TYPE,");//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                strSql2.Append("C_SEND_AREA,");//到货地区
                strSql2.Append("C_AREA,");//到货地址
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_PLAN_ID,");//日计划主键
                strSql2.Append("C_NO,"); //订单号
                strSql2.Append("C_ORDERPK,"); //订单号PK
                strSql2.Append("C_CUSTNO,"); //客户编码
                strSql2.Append("N_FYZS,"); //发运支数
                strSql2.Append("N_FYWGT,"); //发运量
                strSql2.Append("C_SEND_STOCK,"); //发货仓库名称
                strSql2.Append("C_SEND_STOCK_PK,"); //发运仓库主键
                strSql2.Append("C_PRODUCT_ID,"); //仓库产品ID
                strSql2.Append("C_AU_UNITIS,"); //辅单位
                strSql2.Append("C_SEND_STOCK_CODE,"); //发运仓库编码
                strSql2.Append("C_AOG_SITE,"); //到货地点
                strSql2.Append("N_PRICE"); //到货地点费用
                strSql2.Append(")values(");
                strSql2.Append("'" + item[i].C_DISPATCH_ID + "',");
                strSql2.Append("'" + item[i].C_MAT_CODE + "',");
                strSql2.Append("'" + item[i].C_MAT_NAME + "',");
                strSql2.Append("'" + item[i].C_SPEC + "',");
                strSql2.Append("'" + item[i].C_STL_GRD + "',");
                strSql2.Append("'" + item[i].C_QUALIRY_LEV + "',");
                strSql2.Append("'" + item[i].C_JUDGE_LEV_ZH + "',");
                strSql2.Append("'" + item[i].C_FREE_TERM + "',");
                strSql2.Append("'" + item[i].C_FREE_TERM2 + "',");
                strSql2.Append("'" + item[i].C_PACK + "',");
                strSql2.Append("'" + item[i].C_STD_CODE + "',");
                strSql2.Append("'" + item[i].C_ELSENEED.Trim() + "',");//其它要求
                strSql2.Append("'" + item[i].C_REMARK + "',");//备注
                if (!string.IsNullOrEmpty(item[i].N_COM_AMOUNT_WGT.ToString()))
                {
                    strSql2.Append("" + item[i].N_COM_AMOUNT_WGT + ",");
                }
                else
                {
                    strSql2.Append("0,");
                }
                strSql2.Append("" + item[i].N_WGT + ",");
                strSql2.Append("'" + item[i].C_EQUATION_FACTOR + "',");
                strSql2.Append("'" + item[i].C_UNITIS + "',");
                strSql2.Append("'" + item[i].C_ORGO_CUST + "',");
                strSql2.Append("'" + item[i].C_CGC + "',");
                strSql2.Append("'" + item[i].C_ORDER_TYPE + "',");
                strSql2.Append("'" + item[i].C_SEND_AREA + "',");
                strSql2.Append("'" + item[i].C_AREA + "',");
                strSql2.Append("'" + item[i].C_EMP_ID + "',");
                strSql2.Append("'" + item[i].C_EMP_NAME + "',");
                strSql2.Append("'" + item[i].C_CON_NO + "',");
                strSql2.Append("'" + item[i].C_PLAN_ID + "',");
                strSql2.Append("'" + item[i].C_NO + "',");
                strSql2.Append("'" + item[i].C_ORDERPK + "',");
                strSql2.Append("'" + item[i].C_CUSTNO + "',");
                strSql2.Append("" + item[i].N_FYZS + ",");
                strSql2.Append("" + item[i].N_FYWGT + ",");
                strSql2.Append("'" + item[i].C_SEND_STOCK + "',");
                strSql2.Append("'" + item[i].C_SEND_STOCK_PK + "',");
                strSql2.Append("'" + item[i].C_PRODUCT_ID + "',");
                strSql2.Append("'" + item[i].C_AU_UNITIS + "',");
                strSql2.Append("'" + ckcode + "',");//仓库编码
                strSql2.Append("'" + item[i].C_AOG_SITE + "',");//到货地点
                strSql2.Append("" + item[i].N_PRICE + "");//到货地点费用
                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
            }
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 单条插入发运单表体数据
        /// </summary>
        /// <param name="item">表体参数</param>
        /// <returns></returns>
        public bool InsertFYD_ITEM(List<Mod_TMD_DISPATCHDETAILS> item)
        {
            ArrayList arraySql = new ArrayList();

            #region //表体
            for (int i = 0; i < item.Count; i++)
            {



                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("insert into tmd_dispatchdetails(");
                strSql2.Append("C_DISPATCH_ID,");//发运单单据号
                strSql2.Append("C_MAT_CODE,");//物料编码
                strSql2.Append("C_MAT_NAME,");//物料名称
                strSql2.Append("C_SPEC,");//规格
                strSql2.Append("C_STL_GRD,");//钢种
                strSql2.Append("C_QUALIRY_LEV,");//质量等级主键
                strSql2.Append("C_FREE_TERM,");//自由项
                strSql2.Append("C_FREE_TERM2,");//自由项2
                strSql2.Append("C_PACK,");//包装要求
                strSql2.Append("C_STD_CODE,");//执行标准
                strSql2.Append("N_COM_AMOUNT_WGT,");//原订单辅数量
                strSql2.Append("N_WGT,");//原订单数量
                strSql2.Append("C_EQUATION_FACTOR,");//换算率
                strSql2.Append("C_UNITIS,");//主计量单位ID
                strSql2.Append("C_ORGO_CUST,");//订货客户
                strSql2.Append("C_CGC,");//收货单位
                strSql2.Append("C_ORDER_TYPE,");//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                strSql2.Append("C_SEND_AREA,");//到货地区
                strSql2.Append("C_AREA,");//到货地址
                strSql2.Append("C_EMP_ID,");
                strSql2.Append("C_EMP_NAME,");
                strSql2.Append("C_CON_NO,");//合同号
                strSql2.Append("C_PLAN_ID,");//日计划主键
                strSql2.Append("C_NO,"); //订单号
                strSql2.Append("C_ORDERPK,"); //订单号PK
                strSql2.Append("C_CUSTNO,"); //客户编码
                strSql2.Append("C_AU_UNITIS"); //辅单位
                strSql2.Append(")values(");
                strSql2.Append("'" + item[i].C_DISPATCH_ID + "',");
                strSql2.Append("'" + item[i].C_MAT_CODE + "',");
                strSql2.Append("'" + item[i].C_MAT_NAME + "',");
                strSql2.Append("'" + item[i].C_SPEC + "',");
                strSql2.Append("'" + item[i].C_STL_GRD + "',");
                strSql2.Append("'" + item[i].C_QUALIRY_LEV + "',");
                strSql2.Append("'" + item[i].C_FREE_TERM + "',");
                strSql2.Append("'" + item[i].C_FREE_TERM2 + "',");
                strSql2.Append("'" + item[i].C_PACK + "',");
                strSql2.Append("'" + item[i].C_STD_CODE + "',");
                if (!string.IsNullOrEmpty(item[i].N_COM_AMOUNT_WGT.ToString()))
                {
                    strSql2.Append("" + item[i].N_COM_AMOUNT_WGT + ",");
                }
                else
                {
                    strSql2.Append("0,");
                }
                strSql2.Append("" + item[i].N_WGT + ",");
                strSql2.Append("'" + item[i].C_EQUATION_FACTOR + "',");
                strSql2.Append("'" + item[i].C_UNITIS + "',");
                strSql2.Append("'" + item[i].C_ORGO_CUST + "',");
                strSql2.Append("'" + item[i].C_CGC + "',");
                strSql2.Append("'" + item[i].C_ORDER_TYPE + "',");
                strSql2.Append("'" + item[i].C_SEND_AREA + "',");
                strSql2.Append("'" + item[i].C_AREA + "',");
                strSql2.Append("'" + item[i].C_EMP_ID + "',");
                strSql2.Append("'" + item[i].C_EMP_NAME + "',");
                strSql2.Append("'" + item[i].C_CON_NO + "',");
                strSql2.Append("'" + item[i].C_PLAN_ID + "',");
                strSql2.Append("'" + item[i].C_NO + "',");
                strSql2.Append("'" + item[i].C_ORDERPK + "',");
                strSql2.Append("'" + item[i].C_CUSTNO + "',");
                strSql2.Append("'" + item[i].C_AU_UNITIS + "'");
                strSql2.Append(")");
                arraySql.Add(strSql2.ToString());
            }
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 批量更新发运单
        /// </summary>
        /// <param name="modhead"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateFYD(Mod_TMD_DISPATCH modhead, List<Mod_TMD_DISPATCHDETAILS> item)
        {
            ArrayList arraySql = new ArrayList();

            #region //表头
            if (modhead != null)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE TMD_DISPATCH SET ");
                strSql.AppendFormat("C_GPS_NO='{0}',", modhead.C_GPS_NO);//GPS号
                strSql.Append("D_DISP_DT=to_date('" + Convert.ToDateTime(modhead.D_DISP_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//发运日期
                strSql.AppendFormat("C_SHIPVIA='{0}',", modhead.C_SHIPVIA);//发运方式
                strSql.AppendFormat("C_COMCAR='{0}',", modhead.C_COMCAR);//承运商
                strSql.AppendFormat("C_IS_WIRESALE='{0}',", modhead.C_IS_WIRESALE);//字符是否线材
                strSql.AppendFormat("C_IS_WIRESALE_ID='{0}',", modhead.C_IS_WIRESALE_ID);//是否线材主键
                strSql.AppendFormat("C_LIC_PLA_NO='{0}',", modhead.C_LIC_PLA_NO);//车牌号
                strSql.AppendFormat("C_ATSTATION='{0}',", modhead.C_ATSTATION);//到站
                strSql.AppendFormat("C_EMP_ID='{0}',", modhead.C_EMP_ID);//修改人ID
                strSql.AppendFormat("C_EMP_NAME='{0}',", modhead.C_EMP_NAME);//修改人
                strSql.Append("D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss'),");//修改时间
                strSql.AppendFormat("C_EXTEND5='{0}',", modhead.C_EXTEND5);//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                strSql.AppendFormat("C_EXTEND2='{0}',", modhead.C_EXTEND2);//虚拟车号
                strSql.AppendFormat("C_EXTEND4='{0}',", modhead.C_EXTEND4);//客户姓名/电话
                strSql.AppendFormat("N_QUA={0},", modhead.N_QUA);//发运支数
                strSql.AppendFormat("N_WGT={0}", modhead.N_WGT);//发运量
                strSql.AppendFormat(" where C_ID='{0}'", modhead.C_ID);//发运单单据号
                arraySql.Add(strSql.ToString());
            }
            #endregion

            #region //表体
            for (int i = 0; i < item.Count; i++)
            {

                string ckcode = "";
                if (!string.IsNullOrEmpty(item[i].C_SEND_STOCK_PK))
                {
                    DataRow drck = GetStockList(item[i].C_SEND_STOCK_PK);
                    if (drck != null)
                    {
                        ckcode = drck["CKCODE"].ToString();
                    }
                }

                if (item[i].FLAG == "N")
                {
                    #region//insert
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into tmd_dispatchdetails(");
                    strSql2.Append("C_DISPATCH_ID,");//发运单单据号
                    strSql2.Append("C_MAT_CODE,");//物料编码
                    strSql2.Append("C_MAT_NAME,");//物料名称
                    strSql2.Append("C_SPEC,");//规格
                    strSql2.Append("C_STL_GRD,");//钢种
                    strSql2.Append("C_QUALIRY_LEV,");//质量等级主键
                    strSql2.Append("C_JUDGE_LEV_ZH,");//质量等级主键
                    strSql2.Append("C_FREE_TERM,");//自由项
                    strSql2.Append("C_FREE_TERM2,");//自由项2
                    strSql2.Append("C_PACK,");//包装要求
                    strSql2.Append("C_STD_CODE,");//执行标准
                    strSql2.Append("C_ELSENEED,");//其他要求
                    strSql2.Append("N_COM_AMOUNT_WGT,");//原订单辅数量
                    strSql2.Append("N_WGT,");//原订单数量
                    strSql2.Append("C_EQUATION_FACTOR,");//换算率
                    strSql2.Append("C_UNITIS,");//主计量单位ID
                    strSql2.Append("C_ORGO_CUST,");//订货客户
                    strSql2.Append("C_CGC,");//收货单位
                    strSql2.Append("C_ORDER_TYPE,");//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
                    strSql2.Append("C_SEND_AREA,");//到货地区
                    strSql2.Append("C_AREA,");//到货地址
                    strSql2.Append("C_EMP_ID,");
                    strSql2.Append("C_EMP_NAME,");
                    strSql2.Append("C_CON_NO,");//合同号
                    strSql2.Append("C_PLAN_ID,");//日计划主键
                    strSql2.Append("C_NO,"); //订单号
                    strSql2.Append("C_ORDERPK,"); //订单号PK
                    strSql2.Append("C_CUSTNO,"); //客户编码
                    strSql2.Append("N_FYZS,"); //发运支数
                    strSql2.Append("N_FYWGT,"); //发运量
                    strSql2.Append("C_BATCH_NO,"); //批次号
                    strSql2.Append("C_SEND_STOCK,"); //发运仓库
                    strSql2.Append("C_SEND_STOCK_PK,"); //发仓库ID
                    strSql2.Append("C_PRODUCT_ID,"); //仓库产品ID
                    strSql2.Append("C_AU_UNITIS,"); //辅单位
                    strSql2.Append("C_SEND_STOCK_CODE,"); //仓库编码
                    strSql2.Append("C_AOG_SITE,"); //到货地点
                    strSql2.Append("N_PRICE"); //到货地点费用
                    strSql2.Append(")values(");
                    strSql2.Append("'" + item[i].C_DISPATCH_ID + "',");
                    strSql2.Append("'" + item[i].C_MAT_CODE + "',");
                    strSql2.Append("'" + item[i].C_MAT_NAME + "',");
                    strSql2.Append("'" + item[i].C_SPEC + "',");
                    strSql2.Append("'" + item[i].C_STL_GRD + "',");
                    strSql2.Append("'" + item[i].C_QUALIRY_LEV + "',");
                    strSql2.Append("'" + item[i].C_JUDGE_LEV_ZH + "',");
                    strSql2.Append("'" + item[i].C_FREE_TERM + "',");
                    strSql2.Append("'" + item[i].C_FREE_TERM2 + "',");
                    strSql2.Append("'" + item[i].C_PACK + "',");
                    strSql2.Append("'" + item[i].C_STD_CODE + "',");
                    strSql2.Append("'" + item[i].C_ELSENEED + "',");
                    strSql2.Append("" + item[i].N_COM_AMOUNT_WGT.ToString() == "" ? "0" : item[i].N_COM_AMOUNT_WGT + ",");
                    strSql2.Append("" + item[i].N_WGT + ",");
                    strSql2.Append("'" + item[i].C_EQUATION_FACTOR + "',");
                    strSql2.Append("'" + item[i].C_UNITIS + "',");
                    strSql2.Append("'" + item[i].C_ORGO_CUST + "',");
                    strSql2.Append("'" + item[i].C_CGC + "',");
                    strSql2.Append("'" + item[i].C_ORDER_TYPE + "',");
                    strSql2.Append("'" + item[i].C_SEND_AREA + "',");
                    strSql2.Append("'" + item[i].C_AREA + "',");
                    strSql2.Append("'" + item[i].C_EMP_ID + "',");
                    strSql2.Append("'" + item[i].C_EMP_NAME + "',");
                    strSql2.Append("'" + item[i].C_CON_NO + "',");
                    strSql2.Append("'" + item[i].C_PLAN_ID + "',");
                    strSql2.Append("'" + item[i].C_NO + "',");
                    strSql2.Append("'" + item[i].C_ORDERPK + "',");
                    strSql2.Append("'" + item[i].C_CUSTNO + "',");
                    strSql2.Append("" + item[i].N_FYZS + ",");
                    strSql2.Append("" + item[i].N_FYWGT + ",");
                    strSql2.Append("'" + item[i].C_BATCH_NO + "',");
                    strSql2.Append("'" + item[i].C_SEND_STOCK + "',");
                    strSql2.Append("'" + item[i].C_SEND_STOCK_PK + "',");
                    strSql2.Append("'" + item[i].C_PRODUCT_ID + "',");
                    strSql2.Append("'" + item[i].C_AU_UNITIS + "',");
                    strSql2.Append("'" + ckcode + "',");//仓库编码
                    strSql2.Append("'" + item[i].C_AOG_SITE + "',");//到货地点
                    strSql2.Append("" + item[i].N_PRICE + "");//运费
                    strSql2.Append(")");
                    arraySql.Add(strSql2.ToString());
                    #endregion
                }
                else
                {
                    #region//update
                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("update tmd_dispatchdetails set ");
                    strSql3.AppendFormat("C_QUALIRY_LEV='{0}',", item[i].C_QUALIRY_LEV);//质量等级主键
                    strSql3.AppendFormat("C_JUDGE_LEV_ZH='{0}',", item[i].C_JUDGE_LEV_ZH);//质量等级编码
                    strSql3.AppendFormat("C_STD_CODE='{0}',", item[i].C_STD_CODE);//执行标准
                    strSql3.AppendFormat("C_FREE_TERM='{0}',", item[i].C_FREE_TERM);//自由项1
                    strSql3.AppendFormat("C_FREE_TERM2='{0}',", item[i].C_FREE_TERM2);//自由项2
                    strSql3.AppendFormat("C_PACK='{0}',", item[i].C_PACK);//包装要求
                    strSql3.AppendFormat("C_REMARK='{0}',", item[i].C_REMARK);//行备注
                    strSql3.AppendFormat("C_ELSENEED='{0}',", item[i].C_ELSENEED);//其他要求
                    strSql3.AppendFormat("C_CGC='{0}',", item[i].C_CGC);//收货单位
                    strSql3.AppendFormat("C_SEND_AREA='{0}',", item[i].C_SEND_AREA);//到货地区
                    strSql3.AppendFormat("C_AREA='{0}',", item[i].C_AREA);//到货地址
                    strSql3.AppendFormat("C_EMP_ID='{0}',", item[i].C_EMP_ID);
                    strSql3.AppendFormat("C_EMP_NAME='{0}',", item[i].C_EMP_NAME);
                    strSql3.AppendFormat("N_FYZS={0},", item[i].N_FYZS); //发运支数
                    strSql3.AppendFormat("N_FYWGT={0},", item[i].N_FYWGT); //发运量
                    strSql3.AppendFormat("C_BATCH_NO='{0}',", item[i].C_BATCH_NO); //批次号
                    strSql3.AppendFormat("C_SEND_STOCK='{0}',", item[i].C_SEND_STOCK); //发运仓库
                    strSql3.AppendFormat("C_SEND_STOCK_PK='{0}',", item[i].C_SEND_STOCK_PK); //发仓库ID
                    strSql3.AppendFormat("C_PRODUCT_ID='{0}',", item[i].C_PRODUCT_ID); //仓库产品ID
                    strSql3.AppendFormat("C_SEND_STOCK_CODE='{0}'", ckcode); //仓库编码
                    strSql3.AppendFormat(" where C_ID='{0}'", item[i].C_ID);//主键

                    arraySql.Add(strSql3.ToString());
                    #endregion
                }
            }
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        ///执行线材库销售S,发运单状态8线材实绩已导入NC
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="status">状态</param>
        /// <param name="empid">操作人ID</param>
        /// <param name="empName">操作人姓名</param>
        /// <returns></returns>
        public bool UpdateFydWW(string sendcode, int status, string empid, string empName)
        {
            ArrayList arraySql = new ArrayList();


            TransactionHelper.BeginTransaction();
            try
            {

                string strcmd1 = string.Format(@"update TMD_DISPATCH set C_STATUS='" + status + "',C_EMP_ID='" + empid + "',C_EMP_NAME='" + empName + "',D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + sendcode + "' ");

                TransactionHelper.ExecuteSql(strcmd1);

                DataTable dt = DbHelperOra.Query("SELECT T.C_ID FROM TMD_DISPATCHDETAILS T WHERE T.C_DISPATCH_ID='" + sendcode + "'").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Dal_TMD_DISPATCHDETAILS dal_tmd_dispatchdetails = new Dal_TMD_DISPATCHDETAILS();
                        Mod_TMD_DISPATCHDETAILS moditem = dal_tmd_dispatchdetails.GetModel(dt.Rows[i]["C_ID"].ToString());
                        if (moditem != null)
                        {
                            List<Mod_TRC_ROLL_PRODCUT> list = new List<Mod_TRC_ROLL_PRODCUT>();

                            if (!string.IsNullOrEmpty(moditem.C_PACK))
                            {
                                string sql = $@"
                                        select t.*  from  TRC_ROLL_PRODCUT T
                                        WHERE T.C_BATCH_NO='{moditem.C_BATCH_NO}' AND T.C_STL_GRD='{moditem.C_STL_GRD}' AND T.C_STD_CODE='{moditem.C_STD_CODE}'
                                        AND T.C_SPEC='{moditem.C_SPEC}'
                                        AND T.c_judge_lev_zh = '{moditem.C_JUDGE_LEV_ZH}' 
                                        AND T.C_LINEWH_CODE = '{moditem.C_SEND_STOCK_CODE}'
                                        AND T.C_BZYQ = '{moditem.C_PACK}' 
                                        AND T.c_move_type IN ('E')";
                                list.AddRange(TransactionHelper.Query(sql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>());
                            }
                            else
                            {
                                string sql = $@"
                                        select t.*  from  TRC_ROLL_PRODCUT T
                                        WHERE T.C_BATCH_NO='{moditem.C_BATCH_NO}' AND T.C_STL_GRD='{moditem.C_STL_GRD}' AND T.C_STD_CODE='{moditem.C_STD_CODE}'
                                        AND T.C_SPEC='{moditem.C_SPEC}'
                                        AND T.c_judge_lev_zh = '{moditem.C_JUDGE_LEV_ZH}' 
                                        AND T.C_LINEWH_CODE = '{moditem.C_SEND_STOCK_CODE}'
                                        AND T.C_BZYQ IS NULL 
                                        AND T.c_move_type IN ('E')";
                                list.AddRange(TransactionHelper.Query(sql).Tables[0].DataTableToList2<Mod_TRC_ROLL_PRODCUT>());
                            }



                            // 验证库存是否足够
                            if (list.Count < moditem.N_FYZS)
                            {
                                throw new Exception("库存不够，不能发运");
                            }

                            if (list.Count > moditem.N_FYZS && list.Sum(w => w.N_WGT) <= moditem.N_FYWGT)
                            {
                                throw new Exception("库存量不够，请确认支数与重量");
                            }
                            int fyzs = (Int32)(moditem.N_FYZS ?? 0);
                            if (list.Count == moditem.N_FYZS)
                            {
                                // 如果全部转库，则转库总重量等于库存重量
                                moditem.N_FYWGT = list.Sum(w => w.N_WGT);
                            }
                            else
                            {
                                Dal_TMO_ORDER order = new Dal_TMO_ORDER();
                                // 更新库存量（将支数与转库的重量分摊到每支上重新计算结余的重量）
                                order.UpdateInventory(list, moditem.N_FYWGT ?? 0, fyzs);
                            }

                            var fyItms = list.Take(fyzs);

                            foreach (var item in fyItms)
                            {
                                string strcmd2 = $@"UPDATE TRC_ROLL_PRODCUT T
                                           SET T.C_MOVE_TYPE = 'S',T.C_FYDH='{moditem.C_DISPATCH_ID}' 
                                         WHERE T.C_ID='{item.C_ID}'";

                                TransactionHelper.ExecuteSql(strcmd2);
                            }

                        }
                    }

                }
                TransactionHelper.Commit();
                return true;
            }
            catch (Exception ex)
            {
                TransactionHelper.RollBack();
                throw ex;
            }
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


        /// <summary>
        /// 物流车号录入
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="ch">车牌号</param>
        /// <returns></returns>
        public bool UpdateFyd_CH_WL(Mod_TMD_DISPATCH modhead)
        {



            #region //表头
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TMD_DISPATCH SET ");
            strSql.Append("C_GPS_NO=:C_GPS_NO,");//GPS号
            strSql.Append("C_COMCAR=:C_COMCAR,");//承运商

            strSql.Append("C_LIC_PLA_NO=:C_LIC_PLA_NO,");//车牌号
            strSql.Append("C_EXTEND3=:C_EXTEND3,");//司机姓名
                                                   //strSql.AppendFormat("C_EXTEND4='{0}',", modhead.C_EXTEND4);//司机电话

            strSql.Append("C_EMP_ID=:C_EMP_ID,");//修改人ID
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");//修改人
            strSql.Append("D_MOD_DT=:D_MOD_DT,");//修改时间
            strSql.Append("C_XGEMP=:C_XGEMP,");//维护人员
            strSql.Append("D_XGTIME=:D_XGTIME");//维护时间

            strSql.Append(" WHERE C_ID=:C_ID");//发运单单据号



            OracleParameter[] parameters = {
                    new OracleParameter(":C_GPS_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_COMCAR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LIC_PLA_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_XGEMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_XGTIME", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)
            };
            parameters[0].Value = modhead.C_GPS_NO;
            parameters[1].Value = modhead.C_COMCAR;
            parameters[2].Value = modhead.C_LIC_PLA_NO;
            parameters[3].Value = modhead.C_EXTEND3;
            parameters[4].Value = modhead.C_EMP_ID;
            parameters[5].Value = modhead.C_EMP_NAME;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = modhead.C_XGEMP;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = modhead.C_ID;

            #endregion

            return DbHelperOra.ExecuteSql(strSql.ToString(), parameters) > 0 ? true : false;
        }


        /// <summary>
        /// 更新发运单车牌号
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="ch">车牌号</param>
        /// <returns></returns>
        public bool UpdateFyd_CH(Mod_TMD_DISPATCH modhead)
        {

            ArrayList arraySql = new ArrayList();

            #region //表头
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE TMD_DISPATCH SET ");
            strSql.AppendFormat("C_GPS_NO='{0}',", modhead.C_GPS_NO);//GPS号
            strSql.Append("D_DISP_DT=to_date('" + Convert.ToDateTime(modhead.D_DISP_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//发运日期
            strSql.Append("D_CREATE_DT=to_date('" + Convert.ToDateTime(modhead.D_CREATE_DT) + "', 'yyyy-mm-dd hh24:mi:ss'),");//制单日期
            strSql.AppendFormat("C_SHIPVIA='{0}',", modhead.C_SHIPVIA);//发运方式
            strSql.AppendFormat("C_COMCAR='{0}',", modhead.C_COMCAR);//承运商
            //strSql.AppendFormat("C_IS_WIRESALE='{0}',", modhead.C_IS_WIRESALE);//字符是否线材
            //strSql.AppendFormat("C_IS_WIRESALE_ID='{0}',", modhead.C_IS_WIRESALE_ID);//是否线材主键
            strSql.AppendFormat("C_LIC_PLA_NO='{0}',", modhead.C_LIC_PLA_NO);//车牌号
            strSql.AppendFormat("C_EXTEND2='{0}',", modhead.C_EXTEND2);//虚拟车号
            strSql.AppendFormat("C_EXTEND3='{0}',", modhead.C_EXTEND3);//司机姓名/电话
            strSql.AppendFormat("C_EXTEND4='{0}',", modhead.C_EXTEND4);//客户姓名/电话
            strSql.AppendFormat("C_ATSTATION='{0}',", modhead.C_ATSTATION);//到站
            strSql.AppendFormat("C_EMP_ID='{0}',", modhead.C_EMP_ID);//修改人ID
            strSql.AppendFormat("C_EMP_NAME='{0}',", modhead.C_EMP_NAME);//修改人
            strSql.Append("D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss')");//修改时间
            //strSql.AppendFormat("C_EXTEND5='{0}',", modhead.C_EXTEND5);//订单类型 8线材 6钢坯 831废乱材  841焦化产品 851渣
            //strSql.AppendFormat("C_CUSTNAME='{0}',", modhead.C_CUSTNAME);//客户
            //strSql.AppendFormat("N_QUA={0},", modhead.N_QUA);//发运支数
            //strSql.AppendFormat("N_WGT={0}", modhead.N_WGT);//发运量
            strSql.AppendFormat(" where C_ID='{0}'", modhead.C_ID);//发运单单据号

            arraySql.Add(strSql);
            #endregion

            #region //表体

            string cmdText = $@"update tmd_dispatchdetails set D_MOD_DT=to_date('{modhead.D_CREATE_DT}', 'yyyy-mm-dd hh24:mi:ss') where C_DISPATCH_ID='{modhead.C_ID}'";
            arraySql.Add(cmdText);
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 更新发运单导入条码次数
        /// </summary>
        /// <param name="sendcode">发运单号</param>
        /// <param name="num">当前次数</param>
        /// <returns></returns>
        public bool UpdateFydRF_Num(string sendcode, string num)
        {

            if (!string.IsNullOrEmpty(num))
            {
                num = Convert.ToString(Convert.ToInt32(num) + 1);
            }
            else
            {
                num = "1";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_DISPATCH set C_EXTEND1='" + num + "' where C_ID='" + sendcode + "' ");

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
        /// 更新发运单状态
        /// </summary>
        /// <param name="sendcode">发运单单据号</param>
        /// <param name="status">发运单状态 0自由状态 2已导入NC 3已导入条码 4已导入物流 7 已做实绩，8线材实绩已导入NC，9钢坯实绩已导入NC，10审核</param>
        /// <param name="mod">参数</param>
        /// <param name="flag">1保存，2审批</param>
        /// <returns></returns>
        public bool UpdateFydStatus(string sendcode, int status, string empid, string empName, string flag)
        {
            StringBuilder strSql = new StringBuilder();
            switch (flag)
            {
                case "1":
                    strSql.Append("update TMD_DISPATCH set C_STATUS='" + status + "',C_EMP_ID='" + empid + "',C_EMP_NAME='" + empName + "',D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + sendcode + "' ");
                    break;
                case "2"://审批
                    strSql.Append("update TMD_DISPATCH set C_STATUS='" + status + "',C_EMP_ID='" + empid + "',C_EMP_NAME='" + empName + "',D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss'),C_APPROVE_ID='" + empid + "',D_APPROVE_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + sendcode + "' ");
                    break;
                default:
                    strSql.Append("update TMD_DISPATCH set C_STATUS='" + status + "',C_EMP_ID='" + empid + "',C_EMP_NAME='" + empName + "',D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + sendcode + "' ");
                    break;
            }
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
        /// 批量删除发运单与明细
        /// </summary>
        /// <param name="sendcode"></param>
        /// <returns></returns>
        public bool DelFYD(string sendcode, string empID)
        {
            ArrayList arraySql = new ArrayList();
            string strSql = $@"delete from TMD_DISPATCH where C_ID='{sendcode}'";
            string strSql2 = "delete from tmd_dispatchdetails where C_DISPATCH_ID='" + sendcode + "'";
            string cmdText = $@"update trc_roll_prodcut t set t.c_move_type='E' WHERE T.C_FYDH='{sendcode}' and t.c_move_type='S'";
            string strSql3 = $@"INSERT INTO TMD_DISPATCH_LOG(C_DISPATCH_ID,C_EMP_ID)VALUES('{sendcode}','{empID}')";

            string strSql4 = $"DELETE FROM TMC_TRAIN_MAIN WHERE C_ID='{sendcode}'";//火运计划
            string strSql5 = $"DELETE FROM TMC_TRAIN_ITEM WHERE C_PKID='{sendcode}'";//火运计划

            arraySql.Add(strSql);
            arraySql.Add(strSql2);
            arraySql.Add(strSql3);
            arraySql.Add(cmdText);
            arraySql.Add(strSql4);
            arraySql.Add(strSql5);

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 检测NC是否删除发运单
        /// </summary>
        /// <param name="ncpk"></param>
        /// <returns></returns>
        public bool DelNCFYD(string ncpk)
        {
            bool result = true;
            //NC销售订单
            object obj = DbHelperNC.GetSingle("select count(*) from XGERP50.dm_delivbill_b  where vfree9 = '" + ncpk + "' and pksalecorp = '1001' and dr = 0");
            if (obj != null && Convert.ToInt32(obj) > 0)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 检测条码是否删除发运单
        /// </summary>
        /// <param name="ncpk"></param>
        /// <returns></returns>
        public bool DelRFFYD(string ncpk)
        {
            bool result = false;
            //NC销售订单
            object obj = DbHelperNC.GetSingle("select max(Status) zt from wms_bms_pic_fyd where FYDH='" + ncpk + "' ");
            if (obj == null || obj?.ToString() == "4")
            {
                result = true;
            }
            return result;
        }



        /// <summary>
        /// 检测NC是否关闭发运单
        /// </summary>
        /// <param name="ncpk">发运单号</param>
        /// <returns></returns>
        public bool DelNCFYD_GP(string ncpk)
        {
            bool result = true;
            //NC销售订单

            string strSql = $@"select distinct dm_delivbill_b.bcloseout
   from XGERP50.dm_delivbill_h, XGERP50.dm_delivbill_b
  where dm_delivbill_h.pk_delivbill_h = dm_delivbill_b.pk_delivbill_h
    and dm_delivbill_h.dr = 0
    and dm_delivbill_b.dr = 0
    and dm_delivbill_h.pkdelivorg = '1001NC10000000006EHS'
    and dm_delivbill_h.vdelivbillcode = '{ncpk}'";

            string flag = DbHelperNC.GetSingle(strSql)?.ToString() ?? "N";
            result = flag == "Y" ? true : false;
            return result;
        }


        /// <summary>
        /// 质证书/出库单打印
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="cph">车牌号</param>
        /// <param name="ysfs">发运方式</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库结束时间</param>
        /// <returns></returns>
        public DataSet GetPrintInfo(string fyd, string cph, string ysfs, string startDate, string endDate,
            string batch, int printStatus, string attostor, string cno, string mb)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"
select tl.c_ckdh,
      re.c_attestor,
      re.d_visa_dt,
  aa.c_certificate_no,
       tl.c_dispatch_id,
       tl.c_send_stock,
       tl.c_batch_no,
       tl.c_stove,
       tl.c_mat_name,
       tl.c_stl_grd,
       tl.c_spec,
       tl.n_num,
       tl.n_jz,
       tl.c_std_code,
       tl.c_zldj,
       tl.c_tick_str,
       tl.n_status, --线材8，6钢坯
       tl.d_cksj,
       tl.C_LIC_PLA_NO,
       tl.c_shipvia,
       tl.c_orgo_cust,
       tl.C_EMP_NAME,
       tl.N_PRINT_STATUS,
       decode(tm.c_batch_no, null, '', '是') isOK
  from ( 
select distinct t.c_ckdh,
       t.c_dispatch_id,
       t.c_send_stock,
       t.c_batch_no,");
            if (mb != "4")
            {
                strSql.AppendFormat(@"    (select max(tt.c_stove) from trc_roll_prodcut tt where tt.c_batch_no=t.c_batch_no) as c_stove,");
            }
            else
            {
                strSql.AppendFormat(" t.c_stove,");
            }
            strSql.AppendFormat(@"  t.c_mat_name,
       t.c_stl_grd,
       t.c_spec,
       t.n_num,
       t.n_jz,
       t.c_std_code,
       t.c_zldj,
       t.c_tick_str,
       t.n_status,--线材8，6钢坯
       t.d_cksj,
       a.C_LIC_PLA_NO,
       a.c_shipvia,
       b.c_orgo_cust,
     u.c_name C_EMP_NAME,
      a.N_PRINT_STATUS
  from tmd_dispatch_sjzjb t
 left join tmd_dispatch a
    on a.c_id = t.c_dispatch_id left join tmd_dispatchdetails b  on b.c_dispatch_id = t.c_pk_ncid    left join ts_user u
    on a.C_CREATE_ID=u.c_id where  t.n_jz<>0 and t.n_num<>0 ");
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" and t.c_dispatch_id = '{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(cph))
            {
                strSql.AppendFormat(" and a.C_LIC_PLA_NO like '%{0}%'", cph);
            }
            if (!string.IsNullOrEmpty(ysfs))
            {
                strSql.AppendFormat(" and a.c_shipvia='{0}'", ysfs);
            }

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" and t.c_batch_no like '{0}%'", batch);
            }
            if (printStatus != -1)
            {
                if (printStatus == 0)
                {
                    strSql.AppendFormat(" and (a.N_PRINT_STATUS  is null or a.N_PRINT_STATUS =0) ");
                }
                else
                {
                    strSql.AppendFormat(" and a.N_PRINT_STATUS ={0}", printStatus);
                }
            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.Append(" AND t.d_cksj BETWEEN TO_DATE('" + startDate + "', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + Convert.ToDateTime(endDate).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss')");
            }
            strSql.Append(@" ) tl
  left join (select nvl(tcr.c_result_people, tcr.c_result_all) as dj,
                    tcr.c_batch_no,
                    tcr.c_stl_grd,
                    tcr.c_std_code
               from tqc_compre_roll tcr
              where tcr.c_pcinfo = '厂外时效'
                and tcr.n_status = 1
              group by tcr.c_batch_no,
                       tcr.c_stl_grd,
                       tcr.c_std_code,
                       nvl(tcr.c_result_people, tcr.c_result_all)) tm
    on tl.c_batch_no = tm.c_batch_no
   and tl.c_stl_grd = tm.c_stl_grd
   and tl.c_std_code = tm.c_std_code
   and tl.c_zldj = tm.dj 
   left join (select * from  tmd_zzs_reprint where N_STATUS=1 ) aa
   on (tl.C_SPEC=aa.C_SPEC and tl.C_STL_GRD=aa.C_STL_GRD and tl.C_STD_CODE=aa.C_STD_CODE and tl.C_DISPATCH_ID=aa.C_DISPATCH_ID and tl.C_LIC_PLA_NO=aa.c_lic_pla_no)
   left join   (select * from tmd_ckd_reprint  where (N_STATUS = 1 )) re 
   on (tl.c_dispatch_id=re.c_dispatch_id ) where 1=1");
            if (mb != "4")
            {
                strSql.Append(" and tl.n_status=8 ");
            }
            else
            {
                strSql.Append(" and tl.n_status=6 ");
            }
            if (!string.IsNullOrEmpty(attostor))
            {
                strSql.AppendFormat(" and re.c_attestor like '%{0}%'", attostor);
            }
            if (!string.IsNullOrEmpty(cno))
            {
                strSql.AppendFormat(" and aa.c_certificate_no like '%{0}%'", cno);
            }
            strSql.Append(" order by d_visa_dt asc ");
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        ///委外 质证书/出库单打印
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="cph">车牌号</param>
        /// <param name="ysfs">发运方式</param>
        /// <param name="startDate">出库开始时间</param>
        /// <param name="endDate">出库结束时间</param>
        /// <returns></returns>
        public DataSet GetWWPrintInfo(string fyd, string cph, string ysfs, string batch, string qzr, int printStatus, string start, string end)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
distinct t.c_mat_name,-- 存货名称
       re.c_attestor,
      re.d_visa_dt,
       b.c_lic_pla_no,--车牌号
       t.c_dispatch_id,--发运单号
       t.c_batch_no,--批号
       t.c_stl_grd,--钢种
       t.c_std_code,--执行标准
       t.c_spec,--规格
       t.n_fyzs,--件数
       t.n_wgt,--重量
       a.c_stove,--炉号
       t.c_send_stock_code,--仓库
       c.c_checkstate_name,--质量等级
       t.C_TICK_NO,--钩号
       '' 出库时间,
       e.c_name C_ORGO_CUST,--收货单位
       d.c_name C_EMP_NAME,--制单人
       '' C_CKDH,
       b.N_PRINT_STATUS 
  from tmd_dispatchdetails t
  left join tmd_dispatch b
    on b.c_id = t.c_dispatch_id
  left join trc_roll_prodcut a
    on a.c_batch_no = t.c_batch_no
  left join tqb_checkstate c
    on c.c_id = t.C_QUALIRY_LEV
  left join ts_user d
    on d.c_id = b.C_CREATE_ID
  left join ts_custfile e on e.c_nc_m_id=t.C_CGC
  left join (select *  from TMD_ZZS_REPRINT where N_STATUS = 1 ) re
 on (t.c_dispatch_id=re.c_dispatch_id and t.c_stl_grd=re.c_stl_grd and t.c_spec=re.c_spec and t.c_std_code=re.c_std_code and b.c_lic_pla_no=re.c_lic_pla_no )
 where t.c_batch_no is not null ");
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" and t.c_dispatch_id = '{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(cph))
            {
                strSql.AppendFormat(" and b.C_LIC_PLA_NO like '%{0}%'", cph);
            }
            if (!string.IsNullOrEmpty(ysfs))
            {
                strSql.AppendFormat(" and b.C_SHIPVIA='{0}'", ysfs);
            }
            if (!string.IsNullOrEmpty(start))
            {
                strSql.Append(" AND re.d_visa_dt >=TO_DATE('" + start + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (!string.IsNullOrEmpty(end))
            {
                strSql.Append(" AND re.d_visa_dt <=TO_DATE('" + end + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" and t.c_batch_no like '{0}%'", batch);
            }
            if (printStatus != -1)
            {
                if (printStatus == 0)
                {
                    strSql.AppendFormat(" and ( b.N_PRINT_STATUS is null or b.N_PRINT_STATUS=0 ) ");
                }
                else
                {
                    strSql.AppendFormat(" and b.N_PRINT_STATUS ={0}", printStatus);
                }
            }
            if (!string.IsNullOrEmpty(qzr))
            {
                strSql.AppendFormat(" and re.c_attestor like '%{0}%'", qzr);
            }
            strSql.Append("order by t.c_dispatch_id asc");
            return DbHelperOra.Query(strSql.ToString());
        }


        #region //发运统计

        /// <summary>
        /// 发运统计
        /// </summary>
        /// <param name="fyd">发运单号</param>
        /// <param name="zhidanren">制单人</param>
        /// <param name="cph">车牌号</param>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="matCode">物料编码</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="fyfs">发运方式</param>
        /// <param name="area">区域</param>
        /// <param name="zdStart_DT">制单开始日期</param>
        /// <param name="zdEnd_DT">制单结束日期</param>
        /// <param name="isLineSale">是否线材销售</param>
        /// <param name="dz">到站</param>
        /// <param name="addr">到货地点</param>
        /// <param name="ztFR">是否导入条码</param>
        /// <param name="rfexe">条码执行状态</param>
        /// <param name="gps">gps号</param>
        /// <param name="jckssj">进厂开始时间</param>
        /// <param name="jcjssj">进厂结束时间</param>
        /// <param name="cckssj">出厂开始时间</param>
        /// <param name="ccjssj">出厂结束时间</param>
        /// <param name="cys">承运商</param>
        /// <returns></returns>
        public DataSet GetFYStatistic(string fyd, string zhidanren, string cph, string con, string cust, string matCode, string stlGrd, string spec, string fyfs, string area, string zdStart_DT, string zdEnd_DT, string judge_Lev_Zh, string ckStart_DT, string ckEnd_DT, string isLineSale, string sfbd, string dz, string addr, string ztFR, string rfexe, string gps, string jckssj, string jcjssj, string cckssj, string ccjssj, string cys)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT TMD.C_DISPATCH_ID,
                                   TMD.C_SHIPVIA,
                                   TMD.C_COMCAR,
                                   TMD.C_LIC_PLA_NO,
                                   TMD.N_FYZS,
                                   NVL(TMD_SJ.N_NUM, 0) N_NUM,
                                   TMD.N_FYWGT,
                                   NVL(TMD_SJ.N_JZ, 0) N_JZ,
                                   TMD.C_MAT_CODE,
                                   TMD.C_MAT_NAME,
                                   TMD.C_STL_GRD,
                                   TMD.C_SPEC,
                                   TMD.C_STD_CODE,
                                   TMD.C_FREE_TERM,
                                   TMD.C_FREE_TERM2,
                                   TMD.C_QUALIRY_LEV,
                                   TMD.C_PACK,
                                   TMD.C_CREATE_ID,
                                   TMD.D_CREATE_DT,
                                   TO_CHAR(TMD.D_CREATE_DT, 'YYYY-MM-DD') AS D_CREATE_DT2,
                                   TMD.C_AREA,
                                   TMD.C_CON_NO,
                                   TMD.C_CUST_NAME,
                                   TMD.C_SEND_STOCK_CODE,
                                   TMD_SJ.D_CKSJ,
                                   TO_CHAR(TMD_SJ.D_CKSJ, 'YYYY-MM-DD') AS D_CKSJ2,
                                   TMD.C_STATUS,
                                   TMD.C_JUDGE_LEV_ZH,
                                   TMD.C_ORDER_TYPE,
                                   M.C_FLAG,
                                   TMD.C_IS_WIRESALE,
                                   TMD.C_EXTEND3,
                                   TMD.C_EXTEND4,
                                   TMD.N_IS_EXPORT,
                                   (CASE
                                     WHEN TMD.C_STATUS = 0 THEN
                                      '未导入'
                                     WHEN TMD.C_STATUS = 2 THEN
                                      '未导入'
                                     WHEN TMD.C_STATUS = 10 THEN
                                      '未导入'
                                     ELSE
                                      NVL(TMD.N_RFSTATUS, '未同步')
                                   END) N_RFSTATUS,
                                   TMD.D_RFINTIME,
                                   TMD.D_RFOUTTIME,
                                   TMD.C_ATSTATION,
                                   TMD.C_AOG_SITE,
                                   TMD.C_XGEMP,
                                   TMD.D_XGTIME,
                                   TMD.C_GPS_NO,
                                   TMD.N_PRICE,
                                   TMD.N_ORIGINALCURTAXPRICE,
                                   TMD.SHDW,
                                   TMD.CARTYPE
                              FROM (SELECT T.C_ID,
                                           T.C_DISPATCH_ID,
                                           B.C_DETAILNAME AS C_SHIPVIA,
                                           F.C_DETAILNAME AS C_COMCAR,
                                           A.C_LIC_PLA_NO,
                                           J.C_TYPE AS CARTYPE,
                                           T.N_FYZS,
                                           T.N_FYWGT,
                                           T.C_MAT_CODE,
                                           T.C_MAT_NAME,
                                           T.C_STL_GRD,
                                           T.C_SPEC,
                                           T.C_STD_CODE,
                                           T.C_FREE_TERM,
                                           T.C_FREE_TERM2,
                                           C.C_CHECKSTATE_NAME AS C_QUALIRY_LEV,
                                           T.C_PACK,
                                           D.C_NAME AS C_CREATE_ID,
                                           A.D_CREATE_DT,
                                           E.C_AREA,
                                           E.C_CON_NO,
                                           E.C_CUST_NAME,
                                           T.C_SEND_STOCK_CODE,
                                           A.C_STATUS,
                                           T.C_JUDGE_LEV_ZH,
                                           T.C_ORDER_TYPE,
                                           A.C_IS_WIRESALE,
                                           A.C_EXTEND3, --司机姓名
                                           A.C_EXTEND4, --司机电话
                                           A.N_IS_EXPORT, --是否包到价
                                           DECODE(A.N_RFSTATUS,
                                                  0,
                                                  '未执行',
                                                  1,
                                                  '已进门',
                                                  2,
                                                  '装车完毕',
                                                  3,
                                                  '已出门',
                                                  4,
                                                  '已作废',
                                                  5,
                                                  '正在装车') N_RFSTATUS,
                                           A.D_RFINTIME,
                                           A.D_RFOUTTIME,
                                           A.C_ATSTATION,
                                           T.C_AOG_SITE,
                                           A.C_XGEMP,
                                           A.D_XGTIME,
                                           A.C_GPS_NO,
                                           T.N_PRICE,
                                           E.N_ORIGINALCURTAXPRICE,
                                           K.C_NAME SHDW
                                      FROM TMD_DISPATCHDETAILS T
                                     INNER JOIN TMD_DISPATCH A
                                        ON A.C_ID = T.C_DISPATCH_ID
                                      LEFT JOIN TS_DIC B
                                        ON B.C_ID = A.C_SHIPVIA
                                      LEFT JOIN TQB_CHECKSTATE C
                                        ON C.C_ID = T.C_QUALIRY_LEV
                                      LEFT JOIN TS_USER D
                                        ON D.C_ID = A.C_CREATE_ID
                                      LEFT JOIN TMO_CON_ORDER E
                                        ON E.C_ID = T.C_ORDERPK
                                      LEFT JOIN TS_DIC F
                                        ON F.C_DETAILCODE = A.C_COMCAR
                                      LEFT JOIN TS_CUSTFILE K
                                        ON K.C_NC_M_ID = T.C_CGC
                                      LEFT JOIN TMD_CAR_NUMBER J
                                        ON J.C_NUMBER = SUBSTR(A.C_LIC_PLA_NO, 0, 7)
                                       AND J.C_TYPE <> '禁止发运') TMD
                              left JOIN (select sum(F.N_NUM) N_NUM,
                                                SUM(F.N_JZ) N_JZ,
                                                F.C_PK_NCID,
                                                F.d_cksj
                                           FROM TMD_DISPATCH_SJZJB F
                                          GROUP BY F.C_PK_NCID, F.d_cksj
                                         union all
                                         select sum(G.N_FYZS) N_NUM,
                                                SUM(G.N_FYWGT) N_JZ,
                                                G.C_ID AS C_PK_NCID,
                                                G.D_MOD_DT AS D_CKSJ
                                           FROM tmd_dispatchdetails G
                                          WHERE G.C_ORDER_TYPE in ('805', '806', '807')
                                          GROUP BY G.C_ID, G.D_MOD_DT) TMD_SJ
                                ON TMD_SJ.C_PK_NCID = TMD.C_ID
                              LEFT JOIN TMB_MONI_STLGRD M
                                ON M.C_STL_GRD = TMD.C_STL_GRD
                             WHERE 1 = 1");

            if (!string.IsNullOrEmpty(cys))
            {
                strSql.AppendFormat(" AND TMD.C_COMCAR='{0}'", cys);
            }
            if (!string.IsNullOrEmpty(gps))
            {
                strSql.AppendFormat(" AND TMD.C_GPS_NO='{0}'", gps);
            }
            if (!string.IsNullOrEmpty(rfexe))
            {
                strSql.AppendFormat(" AND TMD.N_RFSTATUS='{0}'", rfexe);
            }

            if (!string.IsNullOrEmpty(ztFR))
            {
                strSql.AppendFormat(" AND TMD.C_STATUS IN ({0})", ztFR);
            }
            if (!string.IsNullOrEmpty(dz))
            {
                strSql.AppendFormat(" AND TMD.C_ATSTATION  LIKE '%{0}%'", dz);
            }
            if (!string.IsNullOrEmpty(addr))
            {
                strSql.AppendFormat(" AND TMD.C_AOG_SITE  LIKE '%{0}%'", addr);
            }

            if (!string.IsNullOrEmpty(sfbd))
            {
                strSql.AppendFormat(" AND TMD.N_IS_EXPORT = '{0}'", sfbd);
            }

            if (!string.IsNullOrEmpty(isLineSale))
            {
                strSql.AppendFormat(" AND TMD.C_IS_WIRESALE = '{0}'", isLineSale);
            }

            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND TMD.C_DISPATCH_ID='{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(zhidanren))
            {
                strSql.AppendFormat(" AND TMD.C_CREATE_ID like '%{0}%'", zhidanren);
            }
            if (!string.IsNullOrEmpty(cph))
            {
                strSql.AppendFormat(" AND TMD.C_LIC_PLA_NO like '%{0}%'", cph);
            }
            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND TMD.C_CON_NO  LIKE '{0}%'", con);
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql.AppendFormat(" AND TMD.C_CUST_NAME like '%{0}%'", cust);
            }
            if (!string.IsNullOrEmpty(matCode))
            {
                strSql.AppendFormat(" AND TMD.C_MAT_CODE = '{0}'", matCode);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" AND UPPER(TMD.C_STL_GRD) ='{0}'", stlGrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND TMD.C_SPEC LIKE '%{0}%'", spec);
            }
            if (!string.IsNullOrEmpty(fyfs))
            {
                strSql.AppendFormat(" AND TMD.C_SHIPVIA = '{0}'", fyfs);
            }
            if (!string.IsNullOrEmpty(area))
            {
                strSql.AppendFormat(" AND TMD.C_AREA = '{0}'", area);
            }
            if (!string.IsNullOrEmpty(judge_Lev_Zh))
            {
                strSql.AppendFormat(" AND TMD.C_JUDGE_LEV_ZH = '{0}'", judge_Lev_Zh);
            }
            if (!string.IsNullOrEmpty(zdStart_DT) && !string.IsNullOrEmpty(zdEnd_DT))
            {
                strSql.Append(" AND TMD.D_CREATE_DT>=TO_DATE('" + Convert.ToDateTime(zdStart_DT).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD.D_CREATE_DT<= TO_DATE('" + Convert.ToDateTime(zdEnd_DT).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            if (!string.IsNullOrEmpty(ckStart_DT) && !string.IsNullOrEmpty(ckEnd_DT))
            {
                strSql.Append(" AND TMD_SJ.D_CKSJ>=TO_DATE('" + Convert.ToDateTime(ckStart_DT).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD_SJ.D_CKSJ<= TO_DATE('" + Convert.ToDateTime(ckEnd_DT).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            if (!string.IsNullOrEmpty(jckssj) && !string.IsNullOrEmpty(jcjssj))
            {
                strSql.Append(" AND TMD.D_RFINTIME>=TO_DATE('" + Convert.ToDateTime(jckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD.D_RFINTIME<= TO_DATE('" + Convert.ToDateTime(jcjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            if (!string.IsNullOrEmpty(cckssj) && !string.IsNullOrEmpty(ccjssj))
            {
                strSql.Append(" AND TMD.D_RFOUTTIME>=TO_DATE('" + Convert.ToDateTime(cckssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD.D_RFOUTTIME<= TO_DATE('" + Convert.ToDateTime(ccjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            strSql.Append(" ORDER BY TMD.C_SHIPVIA");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取发运区域统计
        /// </summary>
        /// <param name="createStartTime"></param>
        /// <param name="createEndTime"></param>
        /// <param name="outStartTime"></param>
        /// <param name="outEndTime"></param>
        /// <returns></returns>
        public DataSet GetFyAreaStatistics(string createStartTime, string createEndTime, string outStartTime, string outEndTime, string custName, string shipWay, string isLineSale)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT NVL(SUM(TMD.N_FYZS), 0) N_FYZS,
       NVL(SUM(TMD_SJ.N_NUM), 0) N_NUM,
       NVL(SUM(TMD.N_FYWGT), 0) N_FYWGT,
       NVL(SUM(TMD_SJ.N_JZ), 0) N_JZ,
       TMD.C_AREA,
       TMD.C_IS_WIRESALE
  FROM (SELECT T.C_ID,
               T.C_DISPATCH_ID,
               B.C_DETAILNAME      AS C_SHIPVIA,
               A.C_LIC_PLA_NO,
               T.N_FYZS,
               T.N_FYWGT,
               T.C_MAT_CODE,
               T.C_MAT_NAME,
               T.C_STL_GRD,
               T.C_SPEC,
               T.C_STD_CODE,
               T.C_FREE_TERM,
               T.C_FREE_TERM2,
               C.C_CHECKSTATE_NAME AS C_QUALIRY_LEV,
               T.C_PACK,
               D.C_NAME            AS C_CREATE_ID,
               A.D_CREATE_DT,
               E.C_AREA,
               E.C_CON_NO,
               E.C_CUST_NAME,
               T.C_SEND_STOCK_CODE,
               A.C_STATUS,
               T.C_JUDGE_LEV_ZH,
               T.C_ORDER_TYPE,
               A.C_IS_WIRESALE
          FROM TMD_DISPATCHDETAILS T
         INNER JOIN TMD_DISPATCH A
            ON A.C_ID = T.C_DISPATCH_ID
          LEFT JOIN TS_DIC B
            ON B.C_ID = A.C_SHIPVIA
          LEFT JOIN TQB_CHECKSTATE C
            ON C.C_ID = T.C_QUALIRY_LEV
          LEFT JOIN TS_USER D
            ON D.C_ID = A.C_CREATE_ID
          LEFT JOIN TMO_CON_ORDER E
            ON E.C_ID = T.C_ORDERPK) TMD
  LEFT JOIN (SELECT SUM(F.N_NUM) N_NUM,
                    SUM(F.N_JZ) N_JZ,
                    F.C_PK_NCID,
                    F.D_CKSJ
               FROM TMD_DISPATCH_SJZJB F
              GROUP BY F.C_PK_NCID, F.D_CKSJ
             UNION ALL
             SELECT SUM(G.N_FYZS) N_NUM,
                    SUM(G.N_FYWGT) N_JZ,
                    G.C_ID AS C_PK_NCID,
                    G.D_MOD_DT AS D_CKSJ
               FROM TMD_DISPATCHDETAILS G
              WHERE G.C_ORDER_TYPE IN ('805', '806', '807')
              GROUP BY G.C_ID, G.D_MOD_DT) TMD_SJ
    ON TMD_SJ.C_PK_NCID = TMD.C_ID
  LEFT JOIN TMB_MONI_STLGRD M
    ON M.C_STL_GRD = TMD.C_STL_GRD
 WHERE TMD.C_STATUS IN ('3', '8', '7', '9') ");

            if (!string.IsNullOrEmpty(isLineSale))
            {
                strSql.AppendFormat(" AND TMD.C_IS_WIRESALE = '{0}'", isLineSale);
            }

            if (!string.IsNullOrEmpty(custName))
            {
                strSql.AppendFormat(" AND TMD.C_CUST_NAME like '%{0}%'", custName);
            }

            if (!string.IsNullOrEmpty(shipWay))
            {
                strSql.AppendFormat(" AND TMD.C_SHIPVIA = '{0}'", shipWay);
            }

            if (!string.IsNullOrEmpty(createStartTime) && !string.IsNullOrEmpty(createEndTime))
            {
                strSql.Append(" AND TMD.D_CREATE_DT>=TO_DATE('" + Convert.ToDateTime(createStartTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD.D_CREATE_DT<= TO_DATE('" + Convert.ToDateTime(createEndTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            if (!string.IsNullOrEmpty(outStartTime) && !string.IsNullOrEmpty(outEndTime))
            {
                strSql.Append(" AND TMD_SJ.D_CKSJ>=TO_DATE('" + Convert.ToDateTime(outStartTime).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND TMD_SJ.D_CKSJ<= TO_DATE('" + Convert.ToDateTime(outEndTime).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            strSql.Append(" GROUP BY TMD.C_AREA, TMD.C_IS_WIRESALE");

            return DbHelperOra.Query(strSql.ToString());

        }
        #endregion


        #region //客户按整批次查询

        /// <summary>
        /// 客户整批次查询
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic_Cust(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_FYDH,
       T.C_BATCH_NO,
       T.C_STL_GRD,
       T.C_SPEC,
       SUM(T.N_WGT) N_WGT,
       COUNT(T.C_ID) N_QUA,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.D_CKSJ,
       TO_CHAR(T.D_CKSJ, 'YYYY-MM-DD')D_CKSJ2,
       T.C_CUST_NAME,
       T.C_CON_NO,
       T.C_LIC_PLA_NO,T.SJXM,T.SJTEL  FROM (SELECT T.C_FYDH,
               T.C_BATCH_NO,
               T.C_ID,
               T.C_STL_GRD,
               T.C_SPEC,
               T.N_WGT,
               T.C_MAT_CODE,
               T.C_MAT_DESC,
               (SELECT MAX(A.D_CKSJ)
                  FROM TMD_DISPATCH_SJZJB A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ,
               (SELECT MAX(A.C_ORGO_CUST)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CUST_NAME,
                   (SELECT MAX(A.C_CON_NO)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CON_NO,
                  (SELECT MAX(A.C_LIC_PLA_NO)
                  FROM TMD_DISPATCH A
                 WHERE A.C_ID = T.C_FYDH) C_LIC_PLA_NO,
              (SELECT MAX(A.C_EXTEND3)
                  FROM TMD_DISPATCH A
                 WHERE A.C_ID = T.C_FYDH) SJXM,
              (SELECT MAX(A.C_EXTEND4)
                  FROM TMD_DISPATCH A
                 WHERE A.C_ID = T.C_FYDH) SJTEL
          FROM TRC_ROLL_PRODCUT T
        
         WHERE T.C_FYDH IN
               (SELECT DISTINCT A.C_DISPATCH_ID
                  FROM TMD_DISPATCHDETAILS A
                  LEFT JOIN TMO_CON_ORDER B
                    ON B.C_ORDER_NO = A.C_NO
                 WHERE 1 = 1");

            if (!string.IsNullOrEmpty(empid))
            {
                strSql.AppendFormat(" AND B.C_CUST_NO= '{0}'", empid);
            }

            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND A.C_CON_NO ='{0}'", con);
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql.AppendFormat(" AND A.C_ORGO_CUST LIKE '%{0}%'", cust);
            }
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND A.C_DISPATCH_ID = '{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND  UPPER(A.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND  A.C_SPEC like '%{0}%'", spec);
            }
            strSql.Append(")");

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND  T.C_BATCH_NO = '{0}'", batch);
            }

            strSql.Append(" ORDER BY T.C_MAT_DESC,T.C_STL_GRD) T WHERE 1=1 ");
            if (!string.IsNullOrEmpty(ckkssj) && !string.IsNullOrEmpty(ckjssj))
            {
                strSql.Append(" AND D_CKSJ>=TO_DATE('" + Convert.ToDateTime(ckkssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND D_CKSJ<= TO_DATE('" + Convert.ToDateTime(ckjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            strSql.Append(@" GROUP BY T.C_FYDH,
          T.C_BATCH_NO,
          T.C_STL_GRD,
          T.C_SPEC,
          T.C_MAT_CODE,
          T.C_MAT_DESC,
          T.D_CKSJ,
          T.C_CUST_NAME,
          T.C_CON_NO,
          T.C_LIC_PLA_NO,
          T.SJXM,
          T.SJTEL
          ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //客户单卷明细查询

        /// <summary>
        /// 客户单卷明细查询
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic_Cust2(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT T.C_FYDH,
       T.C_BATCH_NO,
       T.C_STOVE,
       T.C_ID,
       T.C_STL_GRD,
       T.C_SPEC,
       T.N_WGT,
       T.C_MAT_CODE,
       T.C_MAT_DESC,
       T.D_CKSJ,
       TO_CHAR(T.D_CKSJ, 'YYYY-MM-DD')D_CKSJ2,
       T.C_CUST_NAME,
       T.C_CON_NO,
       T.C_LIC_PLA_NO  FROM (SELECT T.C_FYDH,
               T.C_BATCH_NO,
               T.C_STOVE,
               T.C_ID,
               T.C_STL_GRD,
               T.C_SPEC,
               T.N_WGT,
               T.C_MAT_CODE,
               T.C_MAT_DESC,
               (SELECT MAX(A.D_CKSJ)
                  FROM TMD_DISPATCH_SJZJB A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ,
               (SELECT MAX(A.C_ORGO_CUST)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CUST_NAME,
                   (SELECT MAX(A.C_CON_NO)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) C_CON_NO,
                  (SELECT MAX(A.C_LIC_PLA_NO)
                  FROM TMD_DISPATCH A
                 WHERE A.C_ID = T.C_FYDH) C_LIC_PLA_NO
          FROM TRC_ROLL_PRODCUT T
        
         WHERE T.C_FYDH IN
               (SELECT DISTINCT A.C_DISPATCH_ID
                  FROM TMD_DISPATCHDETAILS A
                  LEFT JOIN TMO_CON_ORDER B
                    ON B.C_ORDER_NO = A.C_NO
                 WHERE 1 = 1");

            if (!string.IsNullOrEmpty(empid))
            {
                strSql.AppendFormat(" AND B.C_CUST_NO= '{0}'", empid);
            }

            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND A.C_CON_NO = '{0}'", con);
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql.AppendFormat(" AND A.C_ORGO_CUST LIKE '%{0}%'", cust);
            }
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND A.C_DISPATCH_ID = '{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND  UPPER(A.C_STL_GRD) like '%{0}%'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND  A.C_SPEC like '%{0}%'", spec);
            }
            strSql.Append(")");

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND  T.C_BATCH_NO = '{0}'", batch);
            }

            strSql.Append(" ORDER BY T.C_MAT_DESC,T.C_STL_GRD) T WHERE 1=1 ");
            if (!string.IsNullOrEmpty(ckkssj) && !string.IsNullOrEmpty(ckjssj))
            {
                strSql.Append(" AND D_CKSJ>=TO_DATE('" + Convert.ToDateTime(ckkssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND D_CKSJ<= TO_DATE('" + Convert.ToDateTime(ckjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //合同发运执行明细表

        /// <summary>
        /// 合同发运执行明细表
        /// </summary>
        /// <param name="con">合同号</param>
        /// <param name="cust">客户</param>
        /// <param name="fyd">发运单</param>
        /// <param name="stlgrd">钢种</param>
        /// <param name="spec">规格</param>
        /// <param name="batch">批次</param>
        /// <param name="ckkssj">出库开始时间</param>
        /// <param name="ckjssj">出库结束时间</param>
        /// <param name="empid">用户ID</param>
        /// <returns></returns>
        public DataSet GetConFYMX_Statistic(string con, string cust, string fyd, string stlgrd, string spec, string batch, string ckkssj, string ckjssj, string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT *
  FROM (SELECT T.C_FYDH,
               T.C_BATCH_NO,
               T.C_STOVE,
               T.C_ID,
               T.C_STL_GRD,
               T.C_SPEC,
               T.N_WGT,
               T.C_MAT_CODE,
               T.C_MAT_DESC,
               (SELECT MAX(A.D_CKSJ)
                  FROM TMD_DISPATCH_SJZJB A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH) D_CKSJ,
               (select MAX(A.C_ORGO_CUST)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH
                   AND A.C_MAT_CODE = T.C_MAT_CODE) C_CUST_NAME,
               (select MAX(A.C_CON_NO)
                  FROM TMD_DISPATCHDETAILS A
                 WHERE A.C_DISPATCH_ID = T.C_FYDH
                   AND A.C_MAT_CODE = T.C_MAT_CODE) C_CON_NO
          FROM TRC_ROLL_PRODCUT T
         WHERE T.C_MOVE_TYPE = 'S') T WHERE 1=1");



            if (!string.IsNullOrEmpty(con))
            {
                strSql.AppendFormat(" AND C_CON_NO ='{0}'", con);
            }
            if (!string.IsNullOrEmpty(cust))
            {
                strSql.AppendFormat(" AND C_CUST_NAME LIKE '%{0}%'", cust);
            }
            if (!string.IsNullOrEmpty(fyd))
            {
                strSql.AppendFormat(" AND C_FYDH = '{0}'", fyd);
            }
            if (!string.IsNullOrEmpty(stlgrd))
            {
                strSql.AppendFormat(" AND  UPPER(C_STL_GRD) = '{0}'", stlgrd.ToUpper());
            }
            if (!string.IsNullOrEmpty(spec))
            {
                strSql.AppendFormat(" AND  C_SPEC like '%{0}%'", spec);
            }

            if (!string.IsNullOrEmpty(batch))
            {
                strSql.AppendFormat(" AND  C_BATCH_NO = '{0}'", batch);
            }

            if (!string.IsNullOrEmpty(ckkssj) && !string.IsNullOrEmpty(ckjssj))
            {
                strSql.Append(" AND D_CKSJ>=TO_DATE('" + Convert.ToDateTime(ckkssj).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
                strSql.Append(" AND D_CKSJ<= TO_DATE('" + Convert.ToDateTime(ckjssj).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");

            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region //插入发运指标
        /// <summary>
        /// 插入发运指标
        /// </summary>
        /// <param name="list">参数：部门，数量，日期</param>
        /// <returns></returns>
        public bool InsertFYZB(List<Mod_TMD_FYZB> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                if (item.C_TYPE == "N")
                {
                    #region//添加
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into TMD_FYZB(");
                    strSql.Append("C_DEPT,");
                    strSql.Append("N_WGT,");
                    strSql.Append("D_DAY,");
                    strSql.Append("C_EMPID,");
                    strSql.Append("N_ZKWGT,");
                    strSql.Append("N_JKWGT,");
                    strSql.Append("N_CQWGT,");
                    strSql.Append("N_DPWGT,");
                    strSql.Append("N_KCZB,");
                    strSql.Append("N_JKZB,");
                    strSql.Append("N_CQZB,");
                    strSql.Append("N_FYJKZB,");
                    strSql.Append("N_FYCQZB,");
                    strSql.Append("N_QYFY,");
                    strSql.Append("N_QYJKFY,");
                    strSql.Append("N_HYFY,");
                    strSql.Append("N_HYJKFY,");
                    strSql.Append("C_FLAG,");
                    strSql.Append("N_SORT,");
                    strSql.Append("N_CQFY");
                    strSql.Append(")values(");
                    strSql.AppendFormat("'{0}',", item.C_DEPT);//部门
                    strSql.AppendFormat("{0},", item.N_WGT);//发运总指标
                    strSql.AppendFormat("to_date('{0}', 'yyyy-mm-dd hh24:mi:ss'),", item.D_DAY);//时间
                    strSql.AppendFormat("'{0}',", item.C_EMPID);//操作人
                    strSql.AppendFormat("{0},", item.N_ZKWGT);//各区域总库存
                    strSql.AppendFormat("{0},", item.N_JKWGT);//各区域监控库存
                    strSql.AppendFormat("{0},", item.N_CQWGT);//各区域超期库存
                    strSql.AppendFormat("{0},", item.N_DPWGT);//各区域待判库存
                    strSql.AppendFormat("{0},", item.N_KCZB);//各区域库存占比
                    strSql.AppendFormat("{0},", item.N_JKZB);//各区域监控占比
                    strSql.AppendFormat("{0},", item.N_CQZB);//各区域超期占比
                    strSql.AppendFormat("{0},", item.N_FYJKZB);//发运监控指标
                    strSql.AppendFormat("{0},", item.N_FYCQZB);//发运超期指标
                    strSql.AppendFormat("{0},", item.N_QYFY);//汽运发运量
                    strSql.AppendFormat("{0},", item.N_QYJKFY);//汽运监控发运量
                    strSql.AppendFormat("{0},", item.N_HYFY);//火运发运量
                    strSql.AppendFormat("{0},", item.N_HYJKFY);//火运监控发运量
                    strSql.AppendFormat("'{0}',", item.C_FLAG);//是否控制发运
                    strSql.AppendFormat("{0},", item.N_SORT);//排序
                    strSql.AppendFormat("{0}", item.N_CQFY);//超期库存发运
                    strSql.Append(")");
                    arraySql.Add(strSql);
                    #endregion
                }
                else
                {
                    #region //修改
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update TMD_FYZB set ");
                    strSql2.AppendFormat("N_KCZB={0},", item.N_KCZB);//库存占比
                    strSql2.AppendFormat("N_JKZB={0},", item.N_JKZB);//监控占比
                    strSql2.AppendFormat("N_CQZB={0},", item.N_CQZB);//超期占比
                    strSql2.AppendFormat("N_WGT={0},", item.N_WGT);//发运总指标
                    strSql2.AppendFormat("N_FYJKZB={0},", item.N_FYJKZB);//发运监控指标
                    strSql2.AppendFormat("N_FYCQZB={0}", item.N_FYCQZB);//发运超期指标
                    strSql2.AppendFormat(" where C_ID='{0}'", item.C_ID);
                    arraySql.Add(strSql2);
                    #endregion
                }
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 发运单-每日发运指标控制
        /// </summary>
        /// <param name="area">区域</param>
        /// <param name="fywgt">当前发运量</param>
        /// <returns></returns>
        public bool GetAreaFyZb(string area, decimal fywgt)
        {
            bool result = true;

            if (!area.Contains("不锈钢公司"))
            {
                decimal fyzbwgt = 0;//当日发运总指标
                decimal outwgt = 0;//已出库量
                decimal ztwgt = 0;//在途量

                #region//每日区域发运指标
                string strSql = $@"select t.n_wgt
              from TMD_FYZB t
             WHERE t.C_FLAG='Y' AND  t.c_dept = '{area}'
               and TO_CHAR(T.D_DAY, 'YYYY-MM-DD') =
                   TO_CHAR(sysdate,'YYYY-MM-DD')";

                fyzbwgt = Convert.ToDecimal(DbHelperOra.GetSingle(strSql)?.ToString() ?? "0");
                #endregion

                #region //当前区域出库量
                string strSql2 = $@"SELECT NVL(SUM(G.N_JZ), 0) YLXNUM
                              FROM TMD_DISPATCH_SJZJB G
                             INNER JOIN TMD_DISPATCHDETAILS K
                                ON G.C_PK_NCID = K.C_ID
                             INNER join tmo_con a
                                on a.c_con_no = k.c_con_no
                             WHERE A.C_AREA = '{area}'
                               and TO_CHAR(K.D_MOD_DT, 'YYYY-MM-DD') =
                                   TO_CHAR(sysdate,'YYYY-MM-DD')";
                outwgt = Convert.ToDecimal(DbHelperOra.GetSingle(strSql2)?.ToString() ?? "0");
                #endregion

                #region //当前区域在途量
                string strSql3 = $@"select nvl(sum(k.n_fywgt), 0) n_fywgt
                              from tmd_dispatchdetails K
                             inner join tmd_dispatch t
                                on t.c_id = k.c_dispatch_id
                             INNER join tmo_con a
                                on a.c_con_no = k.c_con_no
                             WHERE A.C_AREA = '{area}'
                               and TO_CHAR(K.D_MOD_DT, 'YYYY-MM-DD') =
                                   TO_CHAR(sysdate,'YYYY-MM-DD')
                               and t.c_status in ('0', '2', '3', '4', '7', '10')";
                ztwgt = Convert.ToDecimal(DbHelperOra.GetSingle(strSql3)?.ToString() ?? "0");
                #endregion

                decimal sumwgt = outwgt + ztwgt + fywgt;

                if (fyzbwgt == 0)
                {
                    result = true;
                }
                else if (sumwgt > fyzbwgt)
                {
                    result = false;
                }
            }
            return result;

        }

        /// <summary>
        ///获取发运指标数据列表
        /// </summary>
        /// <param name="date">发运日期</param>
        /// <returns></returns>
        public DataSet GetAreaFyZbList(string date)
        {
            string strSql = $@"select t.c_id,t.c_dept, t.n_wgt, t.d_day
                              from TMD_FYZB t
                             inner join ts_dic a
                                on a.c_detailname = t.c_dept
                             WHERE a.c_typecode = 'ConArea'
                               and TO_CHAR(T.D_DAY, 'YYYY-MM-DD') =
                                   TO_CHAR(to_date('{date}', 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD')
                             order by a.c_index asc";
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 更新发运指标
        /// </summary>
        /// <param name="list">参数,flag 1修改指标，2汽运/火运/超期发运录入，3 控制发运</param>
        /// <returns></returns>
        public bool UpdateAreaFyZb(List<Mod_TMD_FYZB> list, int flag)
        {
            ArrayList arraySql = new ArrayList();

            switch (flag)
            {
                case 1://修改总指标
                    foreach (var item in list)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update TMD_FYZB set ");
                        strSql.AppendFormat("N_WGT={0} ", item.N_WGT);//发运总指标
                        strSql.AppendFormat(" where C_ID='{0}'", item.C_ID);
                        arraySql.Add(strSql);
                    }

                    break;
                case 2://汽运/火运/超期发运录入
                    foreach (var item in list)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update TMD_FYZB  set ");
                        strSql.AppendFormat("N_QYFY={0},", item.N_QYFY);//汽运发运量
                        strSql.AppendFormat("N_QYJKFY={0},", item.N_QYJKFY);//汽运监控发运量
                        strSql.AppendFormat("N_HYFY={0},", item.N_HYFY);//火运发运量
                        strSql.AppendFormat("N_HYJKFY={0},", item.N_HYJKFY);//火运监控发运量
                        strSql.AppendFormat("N_CQFY={0}", item.N_CQFY);//超期库存发运
                        strSql.AppendFormat(" where C_ID='{0}'", item.C_ID);
                        arraySql.Add(strSql);
                    }
                    break;
                case 3://控制发运
                    foreach (var item in list)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update TMD_FYZB set ");
                        strSql.AppendFormat("C_FLAG='{0}'", item.C_FLAG);//是否控制发运
                        strSql.AppendFormat(" where C_ID='{0}'", item.C_ID);
                        arraySql.Add(strSql);
                    }
                    break;
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 发运指标日报表查询
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetFyZbDay(string date, string zzb, string jkzb, string cqzb)
        {

            DataTable dt = new DataTable();

            string cmdText = $@"SELECT T.C_ID,T.C_DEPT,
       T.N_ZKWGT,
       T.N_JKWGT,
       T.N_CQWGT,
       T.N_DPWGT,
       T.N_KCZB,
       T.N_JKZB,
       T.N_CQZB,
       T.N_WGT,
       T.N_FYJKZB,
       T.N_FYCQZB,
       T.N_QYFY,
       T.N_QYJKFY,
       T.N_HYFY,
       T.N_HYJKFY,
       T.N_CQFY,
       (NVL(T.N_ZKWGT,0)-NVL(T.N_DPWGT,0)) N_KFY,
       ((T.N_QYFY + T.N_HYFY) - T.N_WGT) N_FY_CZ,
       ((T.N_QYJKFY + T.N_HYJKFY) - T.N_WGT) N_JK_CZ,
       T.C_FLAG,
       'Y' AS C_TYPE
  FROM TMD_FYZB T
 WHERE TO_CHAR(T.D_DAY, 'YYYY-MM-DD') =
       TO_CHAR(TO_DATE('{date}', 'YYYY-MM-DD'), 'YYYY-MM-DD') ORDER BY T.N_SORT ASC";

            dt = DbHelperOra.Query(cmdText).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                string strSql = $@"select '' AS C_ID, T.C_DETAILNAME as C_DEPT, --区域
       T.ZKWGT AS N_ZKWGT, --区域总库存
       T.JKWGT AS N_JKWGT, --区域监控库存
       T.CQWGT AS N_CQWGT, --区域超期库存
       T.DPWGT AS N_DPWGT,--区域待判库存
       (NVL(T.ZKWGT,0)-NVL(T.DPWGT,0)) AS N_KFY,--可发运库存
       (ROUND((T.ZKWGT / T.KCZH), 2)) N_KCZB, --库存占比
       (ROUND((T.JKWGT / T.JKZH), 2)) N_JKZB, --监控占比
       (ROUND((T.CQWGT / T.CQZH), 2)) N_CQZB, --超期占比
       (ROUND({zzb} * (T.ZKWGT / T.KCZH), -1)) N_WGT, --区域总指标
       (ROUND({jkzb} * (T.JKWGT / T.JKZH), -1)) N_FYJKZB, --区域监控指标
       (ROUND({cqzb} * (T.CQWGT / T.CQZH), -1)) N_FYCQZB, --区域超期指标
       0 AS N_QYFY,
       0 AS N_QYJKFY,
       (T.HYCKWGT + T.HYZTWGT) AS N_HYFY, --火运发运量
      (T.HYCKWGT_JK + T.HYZTWGT_JK)  AS N_HYJKFY,
       0 AS N_CQFY,
       0 AS N_FY_CZ,
       0 AS N_JK_CZ,
       'N' AS C_FLAG,
       'N' AS C_TYPE
  from V_ROLL_AREA T";
                dt = DbHelperOra.Query(strSql).Tables[0];
                return dt;
            }
        }


        /// <summary>
        /// 发运指标日报表查询-2次指标预览
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataTable GetFyZbView(string date, string zzb, string jkzb, string cqzb)
        {

            string str = $@"SELECT * FROM TMD_FYZB T
 WHERE TO_CHAR(T.D_DAY, 'YYYY-MM-DD') =
       TO_CHAR(TO_DATE('{date}', 'YYYY-MM-DD'), 'YYYY-MM-DD') ORDER BY T.N_SORT ASC";

            if (DbHelperOra.Query(str).Tables[0].Rows.Count > 0)
            {

                decimal KCZH = 0;//当日库存总量
                decimal JKZH = 0;//当日库存监控总量
                decimal CQZH = 0;//当日库存超期总量

                string strSql = "SELECT  KCZH,JKZH,CQZH FROM  V_ROLL_DAY";
                DataTable dt = DbHelperOra.Query(strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    KCZH = Convert.ToDecimal(dt.Rows[0]["KCZH"].ToString());
                    JKZH = Convert.ToDecimal(dt.Rows[0]["JKZH"].ToString());
                    CQZH = Convert.ToDecimal(dt.Rows[0]["CQZH"].ToString());
                }
                string cmdText = $@"SELECT T.C_ID,
                               T.C_DEPT,--区域
                               T.N_ZKWGT, --区域总库存
                               T.N_JKWGT,--区域监控库存
                               T.N_CQWGT,--区域超期库存
                               T.N_DPWGT,--区域待判库存
                               (NVL(T.N_ZKWGT,0)-NVL(T.N_DPWGT,0)) N_KFY,
                               (ROUND((T.N_ZKWGT / {KCZH}), 2)) N_KCZB, --库存占比
                               (ROUND((T.N_JKWGT / {JKZH}), 2)) N_JKZB, --监控占比
                               (ROUND((T.N_CQWGT / {CQZH}), 2)) N_CQZB, --超期占比
                               (ROUND({zzb} * (T.N_ZKWGT / {KCZH}), -1)) N_WGT, --区域总指标
                               (ROUND({jkzb} * (T.N_JKWGT / {JKZH}), -1)) N_FYJKZB, --区域监控指标
                               (ROUND({cqzb} * (T.N_CQWGT / {CQZH}), -1)) N_FYCQZB, --区域超期指标
                               T.N_QYFY,
                               T.N_QYJKFY,
                               T.N_HYFY,
                               T.N_HYJKFY,
                               T.N_CQFY,
                               ((T.N_QYFY + T.N_HYFY) - T.N_WGT) N_FY_CZ,
                               ((T.N_QYJKFY + T.N_HYJKFY) - T.N_WGT) N_JK_CZ,
                               T.C_FLAG,
                               'Y' AS C_TYPE
                          FROM TMD_FYZB T
                         WHERE TO_CHAR(T.D_DAY, 'YYYY-MM-DD') =
                               TO_CHAR(TO_DATE('{date}', 'YYYY-MM-DD'), 'YYYY-MM-DD') ORDER BY T.N_SORT ASC";
                return DbHelperOra.Query(cmdText).Tables[0];
            }
            else
            {
                string strSql2 = $@"select '' AS C_ID, T.C_DETAILNAME as C_DEPT, --区域
                                   T.ZKWGT AS N_ZKWGT, --区域总库存
                                   T.JKWGT AS N_JKWGT, --区域监控库存
                                   T.CQWGT AS N_CQWGT, --区域超期库存
                                   T.DPWGT AS N_DPWGT,--区域待判库存
                                  (NVL(T.ZKWGT,0)-NVL(T.DPWGT,0)) AS N_KFY,--可发运库存
                                   (ROUND((T.ZKWGT / T.KCZH), 2)) N_KCZB, --库存占比
                                   (ROUND((T.JKWGT / T.JKZH), 2)) N_JKZB, --监控占比
                                   (ROUND((T.CQWGT / T.CQZH), 2)) N_CQZB, --超期占比
                                   (ROUND({zzb} * (T.ZKWGT / T.KCZH), -1)) N_WGT, --区域总指标
                                   (ROUND({jkzb} * (T.JKWGT / T.JKZH), -1)) N_FYJKZB, --区域监控指标
                                   (ROUND({cqzb} * (T.CQWGT / T.CQZH), -1)) N_FYCQZB, --区域超期指标
                                   0 AS N_QYFY,
                                   0 AS N_QYJKFY,
                                   (T.HYCKWGT + T.HYZTWGT) AS N_HYFY, --火运发运量
                                  (T.HYCKWGT_JK + T.HYZTWGT_JK)  AS N_HYJKFY,
                                   0 AS N_CQFY,
                                   0 AS N_FY_CZ,
                                   0 AS N_JK_CZ,
                                   'N' AS C_FLAG,
                                   'N' AS C_TYPE
                              from V_ROLL_AREA T";
                return DbHelperOra.Query(strSql2).Tables[0];
            }


        }


        #endregion

        #region PCI
        /// <summary>
        /// 获取钢坯发运单
        /// </summary>
        /// <param name="C_ID">发运单号</param>
        /// <param name="dt1">时间1</param>
        /// <param name="dt2">时间2</param>
        /// <param name="status">状态</param>
        /// <param name="cph">车牌号</param>
        /// <returns></returns>
        public DataSet GetFYDList(string C_ID, DateTime dt1, DateTime dt2, string status, string cph, string movetype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT b.C_FREE_TERM,b.C_FREE_TERM2,a.C_LIC_PLA_NO,a.d_create_dt,a.c_id,b.C_ID ITEMID, b.C_MAT_CODE, b.C_STL_GRD, b.C_STD_CODE,b.C_SEND_STOCK_CODE, b.C_JUDGE_LEV_ZH,b.C_SPEC, b.N_FYZS  N_NUM,b.N_FYWGT  N_WGT,b.N_JWGT  N_JWGT,c.SJSL,case a.c_Status when '4' then '已导入物流' when '7' then '已做实绩' when '9' then '实绩已回NC' end C_STATUS FROM TMD_DISPATCH a  INNER JOIN TMD_DISPATCHDETAILS  b on a.c_id = b.c_dispatch_id  left join (SELECT COUNT(1) SJSL, C_FYDH,C_FYID, C_MAT_CODE, C_STD_CODE, C_SLABWH_CODE, C_JUDGE_LEV_ZH  FROM TSC_SLAB_MAIN WHERE C_MOVE_TYPE = '" + movetype + "' GROUP BY  C_FYDH,C_FYID, C_MAT_CODE, C_STD_CODE, C_SLABWH_CODE, C_JUDGE_LEV_ZH) c on b.c_dispatch_id = c.c_FYDH and b.C_ID=c.C_FYID and b.C_MAT_CODE = c.C_MAT_CODE and b.C_STD_CODE = c.C_STD_CODE and b.C_SEND_STOCK_CODE = c.C_SLABWH_CODE and b.C_JUDGE_LEV_ZH = c.C_JUDGE_LEV_ZH WHERE a.c_STATUS='" + status + "' and a.C_EXTEND5='6' ");
            strSql.Append(" AND a.d_create_dt >=TO_DATE('" + dt1 + "','YYYY-MM-DD HH24:MI:SS') ");
            strSql.Append(" and a.d_create_dt <=TO_DATE('" + dt2 + "','YYYY-MM-DD HH24:MI:SS') ");
            if (cph.Trim() != "")
            {
                strSql.Append(" AND a.C_LIC_PLA_NO LIKE'%" + cph + "%'");
            }
            if (C_ID.Trim() != "")
            {
                strSql.Append(" AND a.C_ID LIKE'%" + C_ID + "%'");
            }
            strSql.Append(" ORDER BY c_id ");
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion
        /// <summary>
        /// 变更发运单
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="empid">操作人id</param>
        /// <param name="empName">操作人名称</param>
        /// <param name="sendcode">发运单号</param>
        /// <returns></returns>
        public int UPFYD(string status, string empid, string empName, string sendcode)
        {
            string sql = "update TMD_DISPATCH set ";
            if (status != "")
            {
                sql += " C_STATUS='" + status + "',";
            }
            sql += " C_EMP_ID='" + empid + "',C_EMP_NAME='" + empName + "',D_MOD_DT=to_date('" + DateTime.Now.ToString() + "', 'yyyy-mm-dd hh24:mi:ss') where C_ID='" + sendcode + "'";
            return DbHelperOra.ExecuteSql(sql);
        }

        #region //同步条码入厂时间/装车状态/出厂时间

        public bool TBRFFYD(string kssj, string jssj)
        {

            ArrayList arraySql = new ArrayList();

            string cmd = $@"SELECT T.C_ID,T.N_RFSTATUS,T.D_RFINTIME,T.D_RFOUTTIME   FROM TMD_DISPATCH T WHERE 1=1";

            if (!string.IsNullOrEmpty(kssj) && !string.IsNullOrEmpty(jssj))
            {
                cmd += $" AND T.D_CREATE_DT>=TO_DATE('{ Convert.ToDateTime(kssj).ToString("yyyy-MM-dd 00:00:00")}', 'yyyy-mm-dd hh24:mi:ss')";
                cmd += $" AND T.D_CREATE_DT<= TO_DATE('{ Convert.ToDateTime(jssj).ToString("yyyy-MM-dd 23:59:59")}', 'yyyy-mm-dd hh24:mi:ss')";
            }

            DataTable dt = DbHelperOra.Query(cmd).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSql = $"select distinct  FYDH,Status,CZ_InTime,CZ_OtTime from WMS_Bms_Pic_FYD where FYDH='{dt.Rows[i]["C_ID"].ToString()}'";
                DataTable dt2 = DbHelper_SQL.Query(strSql).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    string cmd2 = $@"UPDATE TMD_DISPATCH T SET T.N_RFSTATUS={dt2.Rows[0]["Status"]},T.D_RFINTIME=TO_DATE('{dt2.Rows[0]["CZ_InTime"]}','YYYY-MM-DD HH24:MI:SS'),T.D_RFOUTTIME=TO_DATE('{dt2.Rows[0]["CZ_OtTime"]}','YYYY-MM-DD HH24:MI:SS') WHERE T.C_ID='{dt.Rows[i]["C_ID"].ToString()}' ";
                    arraySql.Add(cmd2);
                }
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        public bool TBRFFYD2(string kssj, string jssj)
        {

            ArrayList arraySql = new ArrayList();

            string cmd = $@"SELECT DISTINCT T.C_DISPATCH_ID,T.D_CKSJ FROM TMD_DISPATCH_SJZJB T WHERE 1=1";

            if (!string.IsNullOrEmpty(kssj) && !string.IsNullOrEmpty(jssj))
            {
                cmd += $" AND T.D_CKSJ>=TO_DATE('{ Convert.ToDateTime(kssj).ToString("yyyy-MM-dd 00:00:00")}', 'yyyy-mm-dd hh24:mi:ss')";
                cmd += $" AND T.D_CKSJ<= TO_DATE('{ Convert.ToDateTime(jssj).ToString("yyyy-MM-dd 23:59:59")}', 'yyyy-mm-dd hh24:mi:ss')";
            }

            DataTable dt = DbHelperOra.Query(cmd).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSql = $"select distinct  FYDH,Status,CZ_InTime,CZ_OtTime from WMS_Bms_Pic_FYD where FYDH='{dt.Rows[i]["C_DISPATCH_ID"].ToString()}'";
                DataTable dt2 = DbHelper_SQL.Query(strSql).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    string cmd2 = $@"UPDATE TMD_DISPATCH T SET T.N_RFSTATUS={dt2.Rows[0]["Status"]},T.D_RFINTIME=TO_DATE('{dt2.Rows[0]["CZ_InTime"]}','YYYY-MM-DD HH24:MI:SS'),T.D_RFOUTTIME=TO_DATE('{dt2.Rows[0]["CZ_OtTime"]}','YYYY-MM-DD HH24:MI:SS') WHERE T.C_ID='{dt.Rows[i]["C_ID"].ToString()}' ";
                    arraySql.Add(cmd2);
                }
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        #endregion


        #region //自动生成火运/汽运日计划
        public bool AddTrainPlan(Mod_TMC_TRAIN_MAIN mod, List<Mod_TMC_TRAIN_ITEM> list)
        {
            ArrayList arraySql = new ArrayList();

            string strSql = $@"INSERT INTO TMC_TRAIN_MAIN(C_ID,C_EMPID,C_EMPNAME,C_STATION,C_PLANNO,C_LINE,C_REMARK,N_TRAIN_NUM,C_SHIPVIA,C_ISCHECK)VALUES('{mod.C_ID}','{mod.C_EMPID}','{mod.C_EMPNAME}','{mod.C_STATION}','{mod.C_PLANNO}','{mod.C_LINE}','{mod.C_REMARK}',{mod.N_TRAIN_NUM},'{mod.C_SHIPVIA}','{mod.C_ISCHECK}')";
            arraySql.Add(strSql);

            foreach (var item in list)
            {
                #region //参数
                string strSql2 = $@"INSERT INTO TMC_TRAIN_ITEM
                              (C_EMPNAME,
                               C_PKID,
                               C_AREA,
                               C_CONNO,
                               C_DH_COMPANY,
                               C_SH_COMPANY,
                               C_CUSTNO,
                               C_CUSTNAME,
                               C_KH_BANK,
                               C_TAXNO,
                               C_ADDRESS,
                               C_TEL,
                               C_ACCOUNT,
                               C_FLAG,
                               C_BILLCODE,
                               C_SPEC,
                               C_STL_GRD,
                               N_WGT,
                               C_REMARK
                               )
                            VALUES(";
                strSql2 += $"'{item.C_EMPNAME}',";
                strSql2 += $"'{mod.C_ID}',";
                strSql2 += $"'{item.C_AREA}',";
                strSql2 += $"'{item.C_CONNO}',";
                strSql2 += $"'{item.C_DH_COMPANY}',";
                strSql2 += $"'{item.C_SH_COMPANY}',";
                strSql2 += $"'{item.C_CUSTNO}',";
                strSql2 += $"'{item.C_CUSTNAME}',";
                strSql2 += $"'{item.C_KH_BANK}',";
                strSql2 += $"'{item.C_TAXNO}',";
                strSql2 += $"'{item.C_ADDRESS}',";
                strSql2 += $"'{item.C_TEL}',";
                strSql2 += $"'{item.C_ACCOUNT}',";
                strSql2 += $"'{item.C_FLAG}',";
                strSql2 += $"'{item.C_BILLCODE}',";
                strSql2 += $"'{item.C_SPEC}',";
                strSql2 += $"'{item.C_STL_GRD}',";
                strSql2 += $"{item.N_WGT},";
                strSql2 += $"'{item.C_REMARK}'";
                strSql2 += ")";

                #endregion
                arraySql.Add(strSql2);
            }

            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        #endregion
    }
}

