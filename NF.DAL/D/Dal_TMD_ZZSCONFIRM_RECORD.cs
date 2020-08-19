using NF.DAL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.MODEL.D
{
    public class Dal_TMD_ZZSCONFIRM_RECORD
    {     
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_ZZSCONFIRM_RECORD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMD_ZZSCONFIRM_RECORD(");
            strSql.Append("C_ID,C_CKD,C_FYD,C_BATCH,D_MOD_DT,C_EMP_NAME,C_EMP_ID,N_TYPE,C_STATE)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_CKD,:C_FYD,:C_BATCH,:D_MOD_DT,:C_EMP_NAME,:C_EMP_ID,:N_TYPE,:C_STATE)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                  new OracleParameter(":N_TYPE", OracleDbType.Decimal,1),
             new OracleParameter(":C_STATE", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CKD;
            parameters[2].Value = model.C_FYD;
            parameters[3].Value = model.C_BATCH;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_EMP_NAME;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.N_TYPE;
            parameters[8].Value = model.C_STATE;
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
        public bool Update(Mod_TMD_ZZSCONFIRM_RECORD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_ZZSCONFIRM_RECORD set ");
            strSql.Append("C_ID=:C_ID,");
            strSql.Append("C_CKD=:C_CKD,");
            strSql.Append("C_FYD=:C_FYD,");
            strSql.Append("C_BATCH=:C_BATCH,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("C_EMP_ID=:C_EMP_ID");
            strSql.Append(" where C_ID=:C_ID and C_CKD=:C_CKD and C_FYD=:C_FYD and C_BATCH=:C_BATCH and D_MOD_DT=:D_MOD_DT and C_EMP_NAME=:C_EMP_NAME and C_EMP_ID=:C_EMP_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_CKD;
            parameters[2].Value = model.C_FYD;
            parameters[3].Value = model.C_BATCH;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_EMP_NAME;
            parameters[6].Value = model.C_EMP_ID;

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
        /// 得到一个对象实体
        /// </summary>
        public Mod_TMD_ZZSCONFIRM_RECORD GetModel(string C_ID, string C_CKD, string C_FYD, string C_BATCH, DateTime D_MOD_DT, string C_EMP_NAME, string C_EMP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_CKD,C_FYD,C_BATCH,D_MOD_DT,C_EMP_NAME,C_EMP_ID from TMD_ZZSCONFIRM_RECORD ");
            strSql.Append(" where C_ID=:C_ID and C_CKD=:C_CKD and C_FYD=:C_FYD and C_BATCH=:C_BATCH and D_MOD_DT=:D_MOD_DT and C_EMP_NAME=:C_EMP_NAME and C_EMP_ID=:C_EMP_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FYD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;
            parameters[1].Value = C_CKD;
            parameters[2].Value = C_FYD;
            parameters[3].Value = C_BATCH;
            parameters[4].Value = D_MOD_DT;
            parameters[5].Value = C_EMP_NAME;
            parameters[6].Value = C_EMP_ID;

            Mod_TMD_ZZSCONFIRM_RECORD model = new Mod_TMD_ZZSCONFIRM_RECORD();
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
        public Mod_TMD_ZZSCONFIRM_RECORD DataRowToModel(DataRow row)
        {
            Mod_TMD_ZZSCONFIRM_RECORD model = new Mod_TMD_ZZSCONFIRM_RECORD();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_CKD"] != null)
                {
                    model.C_CKD = row["C_CKD"].ToString();
                }
                if (row["C_FYD"] != null)
                {
                    model.C_FYD = row["C_FYD"].ToString();
                }
                if (row["C_BATCH"] != null)
                {
                    model.C_BATCH = row["C_BATCH"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_EMP_NAME"] != null)
                {
                    model.C_EMP_NAME = row["C_EMP_NAME"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
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
            strSql.Append("select C_ID,C_CKD,C_FYD,C_BATCH,D_MOD_DT,C_EMP_NAME,C_EMP_ID,decode(N_TYPE,1,'质证书打印','委外质证书打印')  N_TYPE,C_STATE ");
            strSql.Append(" FROM TMD_ZZSCONFIRM_RECORD where 1=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("  " + strWhere);
            }
            strSql.Append(" order by D_MOD_DT asc ");
            return DbHelperOra.Query(strSql.ToString());
        }
        public bool AddList(List<Mod_TMD_ZZSCONFIRM_RECORD> ls)
        {
            try
            {
                TransactionHelper.BeginTransaction();
                foreach (var item in ls)
                {
                    if (!Add(item))
                    {
                        TransactionHelper.RollBack();
                        return false;
                    }
                }
                TransactionHelper.Commit();
                return true;
            }
            catch (Exception)
            {
                TransactionHelper.RollBack();
                return false;
            }           
        }


        #endregion  BasicMethod
    }
}
