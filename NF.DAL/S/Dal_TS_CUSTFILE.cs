using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 客户档案
    /// </summary>
    public partial class Dal_TS_CUSTFILE
    {
        public Dal_TS_CUSTFILE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TS_CUSTFILE");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TS_CUSTFILE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TS_CUSTFILE(");
            strSql.Append("C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_NC_ID,:C_NC_M_ID,:N_ISFLAG,:C_NO,:C_NAME,:C_SHORNAME,:C_AREATYPE,:C_LEGALREPRES,:C_AGENT,:C_OPERATOR,:C_FAX,:C_TAXPAYERNO,:N_LEVEL,:N_STATUS,:N_TYPE,:C_EXTEND1,:C_EXTEND2,:C_EXTEND3,:C_EXTEND4,:C_EXTEND5,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT,:N_ISGPS,:C_AREAMMAX)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_M_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ISFLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SHORNAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_AREATYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LEGALREPRES", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AGENT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OPERATOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FAX", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_TAXPAYERNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_LEVEL", OracleDbType.Decimal,2),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND5", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_ISGPS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_AREAMMAX", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_NC_ID;
            parameters[2].Value = model.C_NC_M_ID;
            parameters[3].Value = model.N_ISFLAG;
            parameters[4].Value = model.C_NO;
            parameters[5].Value = model.C_NAME;
            parameters[6].Value = model.C_SHORNAME;
            parameters[7].Value = model.C_AREATYPE;
            parameters[8].Value = model.C_LEGALREPRES;
            parameters[9].Value = model.C_AGENT;
            parameters[10].Value = model.C_OPERATOR;
            parameters[11].Value = model.C_FAX;
            parameters[12].Value = model.C_TAXPAYERNO;
            parameters[13].Value = model.N_LEVEL;
            parameters[14].Value = model.N_STATUS;
            parameters[15].Value = model.N_TYPE;
            parameters[16].Value = model.C_EXTEND1;
            parameters[17].Value = model.C_EXTEND2;
            parameters[18].Value = model.C_EXTEND3;
            parameters[19].Value = model.C_EXTEND4;
            parameters[20].Value = model.C_EXTEND5;
            parameters[21].Value = model.C_EMP_ID;
            parameters[22].Value = model.C_EMP_NAME;
            parameters[23].Value = model.D_MOD_DT;
            parameters[24].Value = model.N_ISGPS;
            parameters[25].Value = model.C_AREAMMAX;

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
        public bool Update(Mod_TS_CUSTFILE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_CUSTFILE set ");
            strSql.Append("C_NC_ID=:C_NC_ID,");
            strSql.Append("C_NC_M_ID=:C_NC_M_ID,");
            strSql.Append("N_ISFLAG=:N_ISFLAG,");
            strSql.Append("C_NO=:C_NO,");
            strSql.Append("C_NAME=:C_NAME,");
            strSql.Append("C_SHORNAME=:C_SHORNAME,");
            strSql.Append("C_AREATYPE=:C_AREATYPE,");
            strSql.Append("C_LEGALREPRES=:C_LEGALREPRES,");
            strSql.Append("C_AGENT=:C_AGENT,");
            strSql.Append("C_OPERATOR=:C_OPERATOR,");
            strSql.Append("C_FAX=:C_FAX,");
            strSql.Append("C_TAXPAYERNO=:C_TAXPAYERNO,");
            strSql.Append("N_LEVEL=:N_LEVEL,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_TYPE=:N_TYPE,");
            strSql.Append("C_EXTEND1=:C_EXTEND1,");
            strSql.Append("C_EXTEND2=:C_EXTEND2,");
            strSql.Append("C_EXTEND3=:C_EXTEND3,");
            strSql.Append("C_EXTEND4=:C_EXTEND4,");
            strSql.Append("C_EXTEND5=:C_EXTEND5,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("N_ISGPS=:N_ISGPS,");
            strSql.Append("C_AREAMMAX=:C_AREAMMAX");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NC_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_M_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_ISFLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_SHORNAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_AREATYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LEGALREPRES", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_AGENT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_OPERATOR", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FAX", OracleDbType.Varchar2,30),
                    new OracleParameter(":C_TAXPAYERNO", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_LEVEL", OracleDbType.Decimal,2),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,2),
                    new OracleParameter(":N_TYPE", OracleDbType.Decimal,2),
                    new OracleParameter(":C_EXTEND1", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND2", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND3", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND4", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EXTEND5", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":N_ISGPS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_AREAMMAX", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_NC_ID;
            parameters[1].Value = model.C_NC_M_ID;
            parameters[2].Value = model.N_ISFLAG;
            parameters[3].Value = model.C_NO;
            parameters[4].Value = model.C_NAME;
            parameters[5].Value = model.C_SHORNAME;
            parameters[6].Value = model.C_AREATYPE;
            parameters[7].Value = model.C_LEGALREPRES;
            parameters[8].Value = model.C_AGENT;
            parameters[9].Value = model.C_OPERATOR;
            parameters[10].Value = model.C_FAX;
            parameters[11].Value = model.C_TAXPAYERNO;
            parameters[12].Value = model.N_LEVEL;
            parameters[13].Value = model.N_STATUS;
            parameters[14].Value = model.N_TYPE;
            parameters[15].Value = model.C_EXTEND1;
            parameters[16].Value = model.C_EXTEND2;
            parameters[17].Value = model.C_EXTEND3;
            parameters[18].Value = model.C_EXTEND4;
            parameters[19].Value = model.C_EXTEND5;
            parameters[20].Value = model.C_EMP_ID;
            parameters[21].Value = model.C_EMP_NAME;
            parameters[22].Value = model.D_MOD_DT;
            parameters[23].Value = model.N_ISGPS;
            parameters[24].Value = model.C_AREAMMAX;
            parameters[25].Value = model.C_ID;

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

        public bool UpdateInfo(Mod_TS_CUSTFILE mod)
        {
            string strSql = $@"UPDATE TS_CUSTFILE SET C_EXTEND1='{mod.C_EXTEND1}',C_TAXPAYERNO='{mod.C_TAXPAYERNO}',C_EXTEND2='{mod.C_EXTEND2}',C_EXTEND3='{mod.C_EXTEND3}',C_EXTEND4='{mod.C_EXTEND4}' WHERE C_NO='{mod.C_NO}'";

            return DbHelperOra.ExecuteSql(strSql) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TS_CUSTFILE ");
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
            strSql.Append("delete from TS_CUSTFILE ");
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
        public Mod_TS_CUSTFILE GetCustInfo(string cust)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX from TS_CUSTFILE ");
            strSql.AppendFormat(" where C_NO='{0}' OR C_NAME='{0}'", cust);
           

            Mod_TS_CUSTFILE model = new Mod_TS_CUSTFILE();
            DataSet ds = DbHelperOra.Query(strSql.ToString());
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
        public Mod_TS_CUSTFILE GetModelCode(string custNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX from TS_CUSTFILE ");
            strSql.Append(" where C_NO=:custNo ");
            OracleParameter[] parameters = {
                    new OracleParameter(":custNo", OracleDbType.Varchar2,100) };
            parameters[0].Value = custNo;

            Mod_TS_CUSTFILE model = new Mod_TS_CUSTFILE();
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
        public Mod_TS_CUSTFILE GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX from TS_CUSTFILE ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TS_CUSTFILE model = new Mod_TS_CUSTFILE();
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
        /// 获取客户基本信息
        /// </summary>
        /// <param name="C_NC_M_ID">NC客商管理档案主键</param>
        /// <returns></returns>
        public Mod_TS_CUSTFILE GetCustModel(string C_NC_M_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX from TS_CUSTFILE ");
            strSql.Append(" where C_NC_M_ID=:C_NC_M_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_NC_M_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_NC_M_ID;

            Mod_TS_CUSTFILE model = new Mod_TS_CUSTFILE();
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
        public Mod_TS_CUSTFILE DataRowToModel(DataRow row)
        {
            Mod_TS_CUSTFILE model = new Mod_TS_CUSTFILE();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_NC_ID"] != null)
                {
                    model.C_NC_ID = row["C_NC_ID"].ToString();
                }
                if (row["C_NC_M_ID"] != null)
                {
                    model.C_NC_M_ID = row["C_NC_M_ID"].ToString();
                }
                if (row["N_ISFLAG"] != null && row["N_ISFLAG"].ToString() != "")
                {
                    model.N_ISFLAG = decimal.Parse(row["N_ISFLAG"].ToString());
                }
                if (row["C_NO"] != null)
                {
                    model.C_NO = row["C_NO"].ToString();
                }
                if (row["C_NAME"] != null)
                {
                    model.C_NAME = row["C_NAME"].ToString();
                }
                if (row["C_SHORNAME"] != null)
                {
                    model.C_SHORNAME = row["C_SHORNAME"].ToString();
                }
                if (row["C_AREATYPE"] != null)
                {
                    model.C_AREATYPE = row["C_AREATYPE"].ToString();
                }
                if (row["C_LEGALREPRES"] != null)
                {
                    model.C_LEGALREPRES = row["C_LEGALREPRES"].ToString();
                }
                if (row["C_AGENT"] != null)
                {
                    model.C_AGENT = row["C_AGENT"].ToString();
                }
                if (row["C_OPERATOR"] != null)
                {
                    model.C_OPERATOR = row["C_OPERATOR"].ToString();
                }
                if (row["C_FAX"] != null)
                {
                    model.C_FAX = row["C_FAX"].ToString();
                }
                if (row["C_TAXPAYERNO"] != null)
                {
                    model.C_TAXPAYERNO = row["C_TAXPAYERNO"].ToString();
                }
                if (row["N_LEVEL"] != null && row["N_LEVEL"].ToString() != "")
                {
                    model.N_LEVEL = decimal.Parse(row["N_LEVEL"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_TYPE"] != null && row["N_TYPE"].ToString() != "")
                {
                    model.N_TYPE = decimal.Parse(row["N_TYPE"].ToString());
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
                if (row["N_ISGPS"] != null && row["N_ISGPS"].ToString() != "")
                {
                    model.N_ISGPS = decimal.Parse(row["N_ISGPS"].ToString());
                }
                if (row["C_AREAMMAX"] != null)
                {
                    model.C_AREAMMAX = row["C_AREAMMAX"].ToString();
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
            strSql.Append("select C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX");
            strSql.Append(" FROM TS_CUSTFILE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string C_NO, string C_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TS_CUSTFILE where 1=1");
            if (!string.IsNullOrEmpty(C_NO))
            {
                strSql.Append("and C_NO='" + C_NO + "'");
            }
            if (!string.IsNullOrEmpty(C_NAME))
            {
                strSql.Append("and C_NAME like '%" + C_NAME + "%'");
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
        public DataSet GetListByPage(int pageSize, int startIndex, string C_NO, string C_NAME)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_NC_ID,C_NC_M_ID,N_ISFLAG,C_NO,C_NAME,C_SHORNAME,C_AREATYPE,C_LEGALREPRES,C_AGENT,C_OPERATOR,C_FAX,C_TAXPAYERNO,N_LEVEL,N_STATUS,N_TYPE,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5,C_EMP_ID,C_EMP_NAME,D_MOD_DT,N_ISGPS,C_AREAMMAX";
            string table = "TS_CUSTFILE";
            string order = " C_NO desc";



            if (!string.IsNullOrEmpty(C_NO))
            {
                where.Append("and C_NO='" + C_NO + "'");
            }
            if (!string.IsNullOrEmpty(C_NAME))
            {
                where.Append("and C_NAME like '%" + C_NAME + "%'");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        #endregion  BasicMethod


        /// <summary>
        /// 客户余额查询
        /// </summary>
        /// <param name="custID">客户档案主键</param>
        /// <returns></returns>
        public DataSet GetCusetMoney(string custID)
        {
            Mod_TS_CUSTFILE mod = GetModel(custID);
            string strSql = string.Format("select PK_CUMANDOC,KHYE,TS from xgerp50.so_querykhye  where PK_CUMANDOC='{0}' ORDER BY TS DESC", mod.C_NC_M_ID);
            return DbHelperNC.Query(strSql);
        }

    }
}

