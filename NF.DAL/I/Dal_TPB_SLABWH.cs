using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TPB_SLABWH
    /// </summary>
    public partial class Dal_TPB_SLABWH
    {
        public Dal_TPB_SLABWH()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TPB_SLABWH");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TPB_SLABWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TPB_SLABWH(");
            strSql.Append("C_SLABWH_CODE,C_SLABWH_NAME,D_END_DATE,C_REMARK,C_EMP_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_SLABWH_CODE,:C_SLABWH_NAME,:D_END_DATE,:C_REMARK,:C_EMP_ID)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLABWH_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100)
                    };
            parameters[0].Value = model.C_SLABWH_CODE;
            parameters[1].Value = model.C_SLABWH_NAME;
            parameters[2].Value = model.D_END_DATE;
            parameters[3].Value = model.C_REMARK;
            parameters[4].Value = model.C_EMP_ID;


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
        public bool Update(Mod_TPB_SLABWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TPB_SLABWH set ");
            strSql.Append("C_SLABWH_CODE=:C_SLABWH_CODE,");
            strSql.Append("C_SLABWH_NAME=:C_SLABWH_NAME,");
            strSql.Append("D_START_DATE=:D_START_DATE,");
            strSql.Append("D_END_DATE=:D_END_DATE,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SLABWH_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_SLABWH_CODE;
            parameters[1].Value = model.C_SLABWH_NAME;
            parameters[2].Value = model.D_START_DATE;
            parameters[3].Value = model.D_END_DATE;
            parameters[4].Value = model.N_STATUS;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.D_MOD_DT;
            parameters[8].Value = model.C_ID;

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
            strSql.Append("delete from TPB_SLABWH ");
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
            strSql.Append("delete from TPB_SLABWH ");
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
        public Mod_TPB_SLABWH GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME,D_START_DATE,D_END_DATE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TPB_SLABWH ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TPB_SLABWH model = new Mod_TPB_SLABWH();
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
        public Mod_TPB_SLABWH GetModel_Interface(string C_SLABWH_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME,D_START_DATE,D_END_DATE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TPB_SLABWH ");
            strSql.Append(" where C_SLABWH_CODE=:C_SLABWH_CODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_SLABWH_CODE;

            Mod_TPB_SLABWH model = new Mod_TPB_SLABWH();
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
        public Mod_TPB_SLABWH GetModel_Interface_Trans(string C_SLABWH_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME,D_START_DATE,D_END_DATE,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TPB_SLABWH ");
            strSql.Append(" where C_SLABWH_CODE=:C_SLABWH_CODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_SLABWH_CODE", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_SLABWH_CODE;

            Mod_TPB_SLABWH model = new Mod_TPB_SLABWH();
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
        public Mod_TPB_SLABWH DataRowToModel(DataRow row)
        {
            Mod_TPB_SLABWH model = new Mod_TPB_SLABWH();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_SLABWH_CODE"] != null)
                {
                    model.C_SLABWH_CODE = row["C_SLABWH_CODE"].ToString();
                }
                if (row["C_SLABWH_NAME"] != null)
                {
                    model.C_SLABWH_NAME = row["C_SLABWH_NAME"].ToString();
                }
                if (row["D_START_DATE"] != null && row["D_START_DATE"].ToString() != "")
                {
                    model.D_START_DATE = DateTime.Parse(row["D_START_DATE"].ToString());
                }
                if (row["D_END_DATE"] != null && row["D_END_DATE"].ToString() != "")
                {
                    model.D_END_DATE = DateTime.Parse(row["D_END_DATE"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
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
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TPB_SLABWH ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByStatus(int iStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TPB_SLABWH ");
            if (iStatus.ToString().Trim() != "")
            {
                strSql.Append(" where N_STATUS=" + iStatus);
            }
            strSql.Append(" ORDER BY to_number(C_SLABWH_CODE) ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TPB_SLABWH ");
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

        #endregion  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME");
            strSql.Append(" FROM TPB_SLABWH WHERE N_STATUS=1 ORDER BY C_SLABWH_CODE ");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_SLABWH_CODE">仓库编码</param>
        /// <param name="C_SLABWH_NAME">仓库描述</param>
        /// <returns></returns>
        public DataSet GetList_id(string C_SLABWH_CODE, string C_SLABWH_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_SLABWH_CODE,C_SLABWH_NAME");
            strSql.Append(" FROM TPB_SLABWH where 1=1 ");
            if (C_SLABWH_CODE.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_CODE ='" + C_SLABWH_CODE + "'");
            }
            if (C_SLABWH_NAME.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_NAME ='" + C_SLABWH_NAME + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_SLABWH_CODE">仓库编码</param>
        /// <returns></returns>
        public object GetList_id(string C_SLABWH_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID");
            strSql.Append(" FROM TPB_SLABWH where 1=1 ");
            if (C_SLABWH_CODE.Trim() != "")
            {
                strSql.Append(" and C_SLABWH_CODE ='" + C_SLABWH_CODE + "'");
            }
            return DbHelperOra.GetSingle(strSql.ToString());
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSlabwh()
        {
            string sql = @"SELECT TS.C_ID,TS.C_SLABWH_CODE,TS.C_SLABWH_NAME,TS.* FROM TPB_SLABWH TS
                                    ORDER BY TS.C_SLABWH_CODE";
            return DbHelperOra.Query(sql);
        }
    }
}

