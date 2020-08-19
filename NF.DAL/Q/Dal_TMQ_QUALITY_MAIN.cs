using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMQ_QUALITY_MAIN
    /// </summary>
    public partial class Dal_TMQ_QUALITY_MAIN
    {
        public Dal_TMQ_QUALITY_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMQ_QUALITY_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMQ_QUALITY_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMQ_QUALITY_MAIN(");
            strSql.Append("C_ID,C_QUEST_ID,C_PROD_KIND_ID,C_SHIPVIA,D_SHIP_START_DT,D_SHIP_END_DT,N_PARENT_REMAIN_WGT,N_MIDDLE_REMAIN_WGT,C_AREA,C_CUST_NAME,C_CUST_TYPE,C_CUST_NO,C_TEL,C_NAME,C_STL_GRD_CLASS,C_PROD_USE,N_OBJECT_COUNT_WGT,C_OBJECT_CONTENT,C_TECH_DESC,C_SITE_SURVEY_CONTENT,N_PARENT_QUA,N_QUEST_QUA,N_MIDDLE_QUA,N_ELSE_QUA,C_SITE_SURVEY_EMP,C_DEPT,C_REMARK,C_CUST_MAKING,C_CUST_MAKING_DT,C_XG_MODIFY,C_XG_MODEIFY_DT,C_APPROVER,D_APPROVER_DT,C_FLOW_ID,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT2,C_DEPT3,C_DEPT4)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_QUEST_ID,:C_PROD_KIND_ID,:C_SHIPVIA,:D_SHIP_START_DT,:D_SHIP_END_DT,:N_PARENT_REMAIN_WGT,:N_MIDDLE_REMAIN_WGT,:C_AREA,:C_CUST_NAME,:C_CUST_TYPE,:C_CUST_NO,:C_TEL,:C_NAME,:C_STL_GRD_CLASS,:C_PROD_USE,:N_OBJECT_COUNT_WGT,:C_OBJECT_CONTENT,:C_TECH_DESC,:C_SITE_SURVEY_CONTENT,:N_PARENT_QUA,:N_QUEST_QUA,:N_MIDDLE_QUA,:N_ELSE_QUA,:C_SITE_SURVEY_EMP,:C_DEPT,:C_REMARK,:C_CUST_MAKING,:C_CUST_MAKING_DT,:C_XG_MODIFY,:C_XG_MODEIFY_DT,:C_APPROVER,:D_APPROVER_DT,:C_FLOW_ID,:N_STATUS,:N_FLAG,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:C_DEPT2,:C_DEPT3,:C_DEPT4)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUEST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_SHIP_START_DT", OracleDbType.Date),
                    new OracleParameter(":D_SHIP_END_DT", OracleDbType.Date),
                    new OracleParameter(":N_PARENT_REMAIN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MIDDLE_REMAIN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TEL", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_CLASS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OBJECT_COUNT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_OBJECT_CONTENT", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_TECH_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SITE_SURVEY_CONTENT", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_PARENT_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_QUEST_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_MIDDLE_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_ELSE_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":C_SITE_SURVEY_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUST_MAKING", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_MAKING_DT", OracleDbType.Date),
                    new OracleParameter(":C_XG_MODIFY", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XG_MODEIFY_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVER_DT", OracleDbType.Date),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_DEPT2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT4", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_QUEST_ID;
            parameters[2].Value = model.C_PROD_KIND_ID;
            parameters[3].Value = model.C_SHIPVIA;
            parameters[4].Value = model.D_SHIP_START_DT;
            parameters[5].Value = model.D_SHIP_END_DT;
            parameters[6].Value = model.N_PARENT_REMAIN_WGT;
            parameters[7].Value = model.N_MIDDLE_REMAIN_WGT;
            parameters[8].Value = model.C_AREA;
            parameters[9].Value = model.C_CUST_NAME;
            parameters[10].Value = model.C_CUST_TYPE;
            parameters[11].Value = model.C_CUST_NO;
            parameters[12].Value = model.C_TEL;
            parameters[13].Value = model.C_NAME;
            parameters[14].Value = model.C_STL_GRD_CLASS;
            parameters[15].Value = model.C_PROD_USE;
            parameters[16].Value = model.N_OBJECT_COUNT_WGT;
            parameters[17].Value = model.C_OBJECT_CONTENT;
            parameters[18].Value = model.C_TECH_DESC;
            parameters[19].Value = model.C_SITE_SURVEY_CONTENT;
            parameters[20].Value = model.N_PARENT_QUA;
            parameters[21].Value = model.N_QUEST_QUA;
            parameters[22].Value = model.N_MIDDLE_QUA;
            parameters[23].Value = model.N_ELSE_QUA;
            parameters[24].Value = model.C_SITE_SURVEY_EMP;
            parameters[25].Value = model.C_DEPT;
            parameters[26].Value = model.C_REMARK;
            parameters[27].Value = model.C_CUST_MAKING;
            parameters[28].Value = model.C_CUST_MAKING_DT;
            parameters[29].Value = model.C_XG_MODIFY;
            parameters[30].Value = model.C_XG_MODEIFY_DT;
            parameters[31].Value = model.C_APPROVER;
            parameters[32].Value = model.D_APPROVER_DT;
            parameters[33].Value = model.C_FLOW_ID;
            parameters[34].Value = model.N_STATUS;
            parameters[35].Value = model.N_FLAG;
            parameters[36].Value = model.C_EMP_ID;
            parameters[37].Value = model.C_EMP_NAME;
            parameters[38].Value = model.D_MOD_DT;
            parameters[39].Value = model.C_DEPT2;
            parameters[40].Value = model.C_DEPT3;
            parameters[41].Value = model.C_DEPT4;

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
        public bool Update(Mod_TMQ_QUALITY_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMQ_QUALITY_MAIN set ");
            strSql.Append("C_QUEST_ID=:C_QUEST_ID,");
            strSql.Append("C_PROD_KIND_ID=:C_PROD_KIND_ID,");
            strSql.Append("C_SHIPVIA=:C_SHIPVIA,");
            strSql.Append("D_SHIP_START_DT=:D_SHIP_START_DT,");
            strSql.Append("D_SHIP_END_DT=:D_SHIP_END_DT,");
            strSql.Append("N_PARENT_REMAIN_WGT=:N_PARENT_REMAIN_WGT,");
            strSql.Append("N_MIDDLE_REMAIN_WGT=:N_MIDDLE_REMAIN_WGT,");
            strSql.Append("C_AREA=:C_AREA,");
            strSql.Append("C_CUST_NAME=:C_CUST_NAME,");
            strSql.Append("C_CUST_TYPE=:C_CUST_TYPE,");
            strSql.Append("C_CUST_NO=:C_CUST_NO,");
            strSql.Append("C_TEL=:C_TEL,");
            strSql.Append("C_NAME=:C_NAME,");
            strSql.Append("C_STL_GRD_CLASS=:C_STL_GRD_CLASS,");
            strSql.Append("C_PROD_USE=:C_PROD_USE,");
            strSql.Append("N_OBJECT_COUNT_WGT=:N_OBJECT_COUNT_WGT,");
            strSql.Append("C_OBJECT_CONTENT=:C_OBJECT_CONTENT,");
            strSql.Append("C_TECH_DESC=:C_TECH_DESC,");
            strSql.Append("C_SITE_SURVEY_CONTENT=:C_SITE_SURVEY_CONTENT,");
            strSql.Append("N_PARENT_QUA=:N_PARENT_QUA,");
            strSql.Append("N_QUEST_QUA=:N_QUEST_QUA,");
            strSql.Append("N_MIDDLE_QUA=:N_MIDDLE_QUA,");
            strSql.Append("N_ELSE_QUA=:N_ELSE_QUA,");
            strSql.Append("C_SITE_SURVEY_EMP=:C_SITE_SURVEY_EMP,");
            strSql.Append("C_DEPT=:C_DEPT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_CUST_MAKING=:C_CUST_MAKING,");
            strSql.Append("C_CUST_MAKING_DT=:C_CUST_MAKING_DT,");
            strSql.Append("C_XG_MODIFY=:C_XG_MODIFY,");
            strSql.Append("C_XG_MODEIFY_DT=:C_XG_MODEIFY_DT,");
            strSql.Append("C_APPROVER=:C_APPROVER,");
            strSql.Append("D_APPROVER_DT=:D_APPROVER_DT,");
            strSql.Append("C_FLOW_ID=:C_FLOW_ID,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_DEPT2=:C_DEPT2,");
            strSql.Append("C_DEPT3=:C_DEPT3,");
            strSql.Append("C_DEPT4=:C_DEPT4");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QUEST_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_KIND_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SHIPVIA", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_SHIP_START_DT", OracleDbType.Date),
                    new OracleParameter(":D_SHIP_END_DT", OracleDbType.Date),
                    new OracleParameter(":N_PARENT_REMAIN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_MIDDLE_REMAIN_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_AREA", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_NO", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TEL", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD_CLASS", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_USE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_OBJECT_COUNT_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_OBJECT_CONTENT", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_TECH_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SITE_SURVEY_CONTENT", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_PARENT_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_QUEST_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_MIDDLE_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":N_ELSE_QUA", OracleDbType.Decimal,2),
                    new OracleParameter(":C_SITE_SURVEY_EMP", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_CUST_MAKING", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_MAKING_DT", OracleDbType.Date),
                    new OracleParameter(":C_XG_MODIFY", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_XG_MODEIFY_DT", OracleDbType.Date),
                    new OracleParameter(":C_APPROVER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVER_DT", OracleDbType.Date),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_DEPT2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT3", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DEPT4", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_QUEST_ID;
            parameters[1].Value = model.C_PROD_KIND_ID;
            parameters[2].Value = model.C_SHIPVIA;
            parameters[3].Value = model.D_SHIP_START_DT;
            parameters[4].Value = model.D_SHIP_END_DT;
            parameters[5].Value = model.N_PARENT_REMAIN_WGT;
            parameters[6].Value = model.N_MIDDLE_REMAIN_WGT;
            parameters[7].Value = model.C_AREA;
            parameters[8].Value = model.C_CUST_NAME;
            parameters[9].Value = model.C_CUST_TYPE;
            parameters[10].Value = model.C_CUST_NO;
            parameters[11].Value = model.C_TEL;
            parameters[12].Value = model.C_NAME;
            parameters[13].Value = model.C_STL_GRD_CLASS;
            parameters[14].Value = model.C_PROD_USE;
            parameters[15].Value = model.N_OBJECT_COUNT_WGT;
            parameters[16].Value = model.C_OBJECT_CONTENT;
            parameters[17].Value = model.C_TECH_DESC;
            parameters[18].Value = model.C_SITE_SURVEY_CONTENT;
            parameters[19].Value = model.N_PARENT_QUA;
            parameters[20].Value = model.N_QUEST_QUA;
            parameters[21].Value = model.N_MIDDLE_QUA;
            parameters[22].Value = model.N_ELSE_QUA;
            parameters[23].Value = model.C_SITE_SURVEY_EMP;
            parameters[24].Value = model.C_DEPT;
            parameters[25].Value = model.C_REMARK;
            parameters[26].Value = model.C_CUST_MAKING;
            parameters[27].Value = model.C_CUST_MAKING_DT;
            parameters[28].Value = model.C_XG_MODIFY;
            parameters[29].Value = model.C_XG_MODEIFY_DT;
            parameters[30].Value = model.C_APPROVER;
            parameters[31].Value = model.D_APPROVER_DT;
            parameters[32].Value = model.C_FLOW_ID;
            parameters[33].Value = model.N_STATUS;
            parameters[34].Value = model.N_FLAG;
            parameters[35].Value = model.C_EMP_ID;
            parameters[36].Value = model.C_EMP_NAME;
            parameters[37].Value = model.D_MOD_DT;
            parameters[38].Value = model.C_DEPT2;
            parameters[39].Value = model.C_DEPT3;
            parameters[40].Value = model.C_DEPT4;
            parameters[41].Value = model.C_ID;

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
            strSql.Append("delete from TMQ_QUALITY_MAIN ");
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
            strSql.Append("delete from TMQ_QUALITY_MAIN ");
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
        public Mod_TMQ_QUALITY_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUEST_ID,C_PROD_KIND_ID,C_SHIPVIA,D_SHIP_START_DT,D_SHIP_END_DT,N_PARENT_REMAIN_WGT,N_MIDDLE_REMAIN_WGT,C_AREA,C_CUST_NAME,C_CUST_TYPE,C_CUST_NO,C_TEL,C_NAME,C_STL_GRD_CLASS,C_PROD_USE,N_OBJECT_COUNT_WGT,C_OBJECT_CONTENT,C_TECH_DESC,C_SITE_SURVEY_CONTENT,N_PARENT_QUA,N_QUEST_QUA,N_MIDDLE_QUA,N_ELSE_QUA,C_SITE_SURVEY_EMP,C_DEPT,C_REMARK,C_CUST_MAKING,C_CUST_MAKING_DT,C_XG_MODIFY,C_XG_MODEIFY_DT,C_APPROVER,D_APPROVER_DT,C_FLOW_ID,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT2,C_DEPT3,C_DEPT4 from TMQ_QUALITY_MAIN ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMQ_QUALITY_MAIN model = new Mod_TMQ_QUALITY_MAIN();
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
        public Mod_TMQ_QUALITY_MAIN DataRowToModel(DataRow row)
        {
            Mod_TMQ_QUALITY_MAIN model = new Mod_TMQ_QUALITY_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_QUEST_ID"] != null)
                {
                    model.C_QUEST_ID = row["C_QUEST_ID"].ToString();
                }
                if (row["C_PROD_KIND_ID"] != null)
                {
                    model.C_PROD_KIND_ID = row["C_PROD_KIND_ID"].ToString();
                }
                if (row["C_SHIPVIA"] != null)
                {
                    model.C_SHIPVIA = row["C_SHIPVIA"].ToString();
                }
                if (row["D_SHIP_START_DT"] != null && row["D_SHIP_START_DT"].ToString() != "")
                {
                    model.D_SHIP_START_DT = DateTime.Parse(row["D_SHIP_START_DT"].ToString());
                }
                if (row["D_SHIP_END_DT"] != null && row["D_SHIP_END_DT"].ToString() != "")
                {
                    model.D_SHIP_END_DT = DateTime.Parse(row["D_SHIP_END_DT"].ToString());
                }
                if (row["N_PARENT_REMAIN_WGT"] != null && row["N_PARENT_REMAIN_WGT"].ToString() != "")
                {
                    model.N_PARENT_REMAIN_WGT = decimal.Parse(row["N_PARENT_REMAIN_WGT"].ToString());
                }
                if (row["N_MIDDLE_REMAIN_WGT"] != null && row["N_MIDDLE_REMAIN_WGT"].ToString() != "")
                {
                    model.N_MIDDLE_REMAIN_WGT = decimal.Parse(row["N_MIDDLE_REMAIN_WGT"].ToString());
                }
                if (row["C_AREA"] != null)
                {
                    model.C_AREA = row["C_AREA"].ToString();
                }
                if (row["C_CUST_NAME"] != null)
                {
                    model.C_CUST_NAME = row["C_CUST_NAME"].ToString();
                }
                if (row["C_CUST_TYPE"] != null)
                {
                    model.C_CUST_TYPE = row["C_CUST_TYPE"].ToString();
                }
                if (row["C_CUST_NO"] != null)
                {
                    model.C_CUST_NO = row["C_CUST_NO"].ToString();
                }
                if (row["C_TEL"] != null)
                {
                    model.C_TEL = row["C_TEL"].ToString();
                }
                if (row["C_NAME"] != null)
                {
                    model.C_NAME = row["C_NAME"].ToString();
                }
                if (row["C_STL_GRD_CLASS"] != null)
                {
                    model.C_STL_GRD_CLASS = row["C_STL_GRD_CLASS"].ToString();
                }
                if (row["C_PROD_USE"] != null)
                {
                    model.C_PROD_USE = row["C_PROD_USE"].ToString();
                }
                if (row["N_OBJECT_COUNT_WGT"] != null && row["N_OBJECT_COUNT_WGT"].ToString() != "")
                {
                    model.N_OBJECT_COUNT_WGT = decimal.Parse(row["N_OBJECT_COUNT_WGT"].ToString());
                }
                if (row["C_OBJECT_CONTENT"] != null)
                {
                    model.C_OBJECT_CONTENT = row["C_OBJECT_CONTENT"].ToString();
                }
                if (row["C_TECH_DESC"] != null)
                {
                    model.C_TECH_DESC = row["C_TECH_DESC"].ToString();
                }
                if (row["C_SITE_SURVEY_CONTENT"] != null)
                {
                    model.C_SITE_SURVEY_CONTENT = row["C_SITE_SURVEY_CONTENT"].ToString();
                }
                if (row["N_PARENT_QUA"] != null && row["N_PARENT_QUA"].ToString() != "")
                {
                    model.N_PARENT_QUA = decimal.Parse(row["N_PARENT_QUA"].ToString());
                }
                if (row["N_QUEST_QUA"] != null && row["N_QUEST_QUA"].ToString() != "")
                {
                    model.N_QUEST_QUA = decimal.Parse(row["N_QUEST_QUA"].ToString());
                }
                if (row["N_MIDDLE_QUA"] != null && row["N_MIDDLE_QUA"].ToString() != "")
                {
                    model.N_MIDDLE_QUA = decimal.Parse(row["N_MIDDLE_QUA"].ToString());
                }
                if (row["N_ELSE_QUA"] != null && row["N_ELSE_QUA"].ToString() != "")
                {
                    model.N_ELSE_QUA = decimal.Parse(row["N_ELSE_QUA"].ToString());
                }
                if (row["C_SITE_SURVEY_EMP"] != null)
                {
                    model.C_SITE_SURVEY_EMP = row["C_SITE_SURVEY_EMP"].ToString();
                }
                if (row["C_DEPT"] != null)
                {
                    model.C_DEPT = row["C_DEPT"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_CUST_MAKING"] != null)
                {
                    model.C_CUST_MAKING = row["C_CUST_MAKING"].ToString();
                }
                if (row["C_CUST_MAKING_DT"] != null && row["C_CUST_MAKING_DT"].ToString() != "")
                {
                    model.C_CUST_MAKING_DT = DateTime.Parse(row["C_CUST_MAKING_DT"].ToString());
                }
                if (row["C_XG_MODIFY"] != null)
                {
                    model.C_XG_MODIFY = row["C_XG_MODIFY"].ToString();
                }
                if (row["C_XG_MODEIFY_DT"] != null && row["C_XG_MODEIFY_DT"].ToString() != "")
                {
                    model.C_XG_MODEIFY_DT = DateTime.Parse(row["C_XG_MODEIFY_DT"].ToString());
                }
                if (row["C_APPROVER"] != null)
                {
                    model.C_APPROVER = row["C_APPROVER"].ToString();
                }
                if (row["D_APPROVER_DT"] != null && row["D_APPROVER_DT"].ToString() != "")
                {
                    model.D_APPROVER_DT = DateTime.Parse(row["D_APPROVER_DT"].ToString());
                }
                if (row["C_FLOW_ID"] != null)
                {
                    model.C_FLOW_ID = row["C_FLOW_ID"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_FLAG"] != null && row["N_FLAG"].ToString() != "")
                {
                    model.N_FLAG = decimal.Parse(row["N_FLAG"].ToString());
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
                if (row["C_DEPT2"] != null)
                {
                    model.C_DEPT2 = row["C_DEPT2"].ToString();
                }
                if (row["C_DEPT3"] != null)
                {
                    model.C_DEPT3 = row["C_DEPT3"].ToString();
                }
                if (row["C_DEPT4"] != null)
                {
                    model.C_DEPT4 = row["C_DEPT4"].ToString();
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
            strSql.Append("select C_ID,C_QUEST_ID,C_PROD_KIND_ID,C_SHIPVIA,D_SHIP_START_DT,D_SHIP_END_DT,N_PARENT_REMAIN_WGT,N_MIDDLE_REMAIN_WGT,C_AREA,C_CUST_NAME,C_CUST_TYPE,C_CUST_NO,C_TEL,C_NAME,C_STL_GRD_CLASS,C_PROD_USE,N_OBJECT_COUNT_WGT,C_OBJECT_CONTENT,C_TECH_DESC,C_SITE_SURVEY_CONTENT,N_PARENT_QUA,N_QUEST_QUA,N_MIDDLE_QUA,N_ELSE_QUA,C_SITE_SURVEY_EMP,C_DEPT,C_REMARK,C_CUST_MAKING,C_CUST_MAKING_DT,C_XG_MODIFY,C_XG_MODEIFY_DT,C_APPROVER,D_APPROVER_DT,C_FLOW_ID,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_DEPT2,C_DEPT3,C_DEPT4 ");
            strSql.Append(" FROM TMQ_QUALITY_MAIN ");
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
            strSql.Append("select count(1) FROM TMQ_QUALITY_MAIN ");
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
            strSql.Append(")AS Row, T.*  from TMQ_QUALITY_MAIN T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMQ_QUALITY_MAIN";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态：-1未提交,0待处理,1处理中,2办结</param>
        /// <returns></returns>
        public bool UpdateStatus(string id, string status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMQ_QUALITY_MAIN set ");

            strSql.Append("N_STATUS=:N_STATUS");

            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = status;
            parameters[1].Value = id;

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
       /// 更新审批人/时间
       /// </summary>
       /// <param name="id">id</param>
       /// <param name="empID">审批人</param>
       /// <param name="time">审批时间</param>
       /// <returns></returns>
        public bool UpdateCheckEmp(string id, string empID, string status, DateTime time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMQ_QUALITY_MAIN set ");
            strSql.Append("N_STATUS=:N_STATUS");
            strSql.Append("C_APPROVER=:C_APPROVER,");
            strSql.Append("D_APPROVER_DT=:D_APPROVER_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                 new OracleParameter(":C_APPROVER", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_APPROVER_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = empID;
            parameters[1].Value = time;
            parameters[2].Value = id;

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

