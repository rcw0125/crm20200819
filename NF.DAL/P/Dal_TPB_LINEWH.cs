using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TPB_LINEWH
    /// </summary>
    public partial class Dal_TPB_LINEWH
    {
        public Dal_TPB_LINEWH()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TPB_LINEWH");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TPB_LINEWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TPB_LINEWH(");
            strSql.Append("C_LINEWH_CODE,C_LINEWH_NAME,N_STATUS,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,C_NC_CODE,C_RF_CODE,C_NC_PK)");
            strSql.Append(" values (");
            strSql.Append(":C_LINEWH_CODE,:C_LINEWH_NAME,:N_STATUS,:C_EMP_ID,:D_MOD_DT,:C_REMARK,:D_START_DATE,:D_END_DATE,:C_NC_CODE,:C_RF_CODE,:C_NC_PK)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":C_NC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RF_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_PK", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_LINEWH_CODE;
            parameters[1].Value = model.C_LINEWH_NAME;
            parameters[2].Value = model.N_STATUS;
            parameters[3].Value = model.C_EMP_ID;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.D_START_DATE;
            parameters[7].Value = model.D_END_DATE;
            parameters[8].Value = model.C_NC_CODE;
            parameters[9].Value =  model.C_RF_CODE;
            parameters[10].Value = model.C_NC_PK;

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
        public bool Update(Mod_TPB_LINEWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TPB_LINEWH set ");
            strSql.Append("C_LINEWH_CODE=:C_LINEWH_CODE,");
            strSql.Append("C_LINEWH_NAME=:C_LINEWH_NAME,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("D_START_DATE=:D_START_DATE,");
            strSql.Append("D_END_DATE=:D_END_DATE,");
            strSql.Append("C_NC_CODE=:C_NC_CODE,");
            strSql.Append("C_RF_CODE=:C_RF_CODE,");
            strSql.Append("C_NC_PK=:C_NC_PK");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_LINEWH_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":C_NC_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_RF_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NC_PK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_LINEWH_CODE;
            parameters[1].Value = model.C_LINEWH_NAME;
            parameters[2].Value = model.N_STATUS;
            parameters[3].Value = model.C_EMP_ID;
            parameters[4].Value = model.D_MOD_DT;
            parameters[5].Value = model.C_REMARK;
            parameters[6].Value = model.D_START_DATE;
            parameters[7].Value = model.D_END_DATE;
            parameters[8].Value = model.C_NC_CODE;
            parameters[9].Value = model.C_RF_CODE;
            parameters[10].Value = model.C_NC_PK;
            parameters[11].Value = model.C_ID;

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
            strSql.Append("delete from TPB_LINEWH ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
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
            strSql.Append("delete from TPB_LINEWH ");
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
        public Mod_TPB_LINEWH GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,N_STATUS,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,C_NC_CODE,C_RF_CODE,C_NC_PK from TPB_LINEWH ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TPB_LINEWH model = new Mod_TPB_LINEWH();
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
        public Mod_TPB_LINEWH GetModel_Interface_Trans(string C_LINEWH_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,N_STATUS,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,C_NC_CODE,C_RF_CODE,C_NC_PK from TPB_LINEWH ");
            strSql.Append(" where C_LINEWH_CODE=:C_LINEWH_CODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_LINEWH_CODE;

            Mod_TPB_LINEWH model = new Mod_TPB_LINEWH();
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
        public Mod_TPB_LINEWH DataRowToModel(DataRow row)
        {
            Mod_TPB_LINEWH model = new Mod_TPB_LINEWH();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_LINEWH_CODE"] != null)
                {
                    model.C_LINEWH_CODE = row["C_LINEWH_CODE"].ToString();
                }
                if (row["C_LINEWH_NAME"] != null)
                {
                    model.C_LINEWH_NAME = row["C_LINEWH_NAME"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_EMP_ID"] != null)
                {
                    model.C_EMP_ID = row["C_EMP_ID"].ToString();
                }
                if (row["D_MOD_DT"] != null && row["D_MOD_DT"].ToString() != "")
                {
                    model.D_MOD_DT = DateTime.Parse(row["D_MOD_DT"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["D_START_DATE"] != null && row["D_START_DATE"].ToString() != "")
                {
                    model.D_START_DATE = DateTime.Parse(row["D_START_DATE"].ToString());
                }
                if (row["D_END_DATE"] != null && row["D_END_DATE"].ToString() != "")
                {
                    model.D_END_DATE = DateTime.Parse(row["D_END_DATE"].ToString());
                }
                if (row["C_NC_CODE"] != null)
                {
                    model.C_NC_CODE = row["C_NC_CODE"].ToString();
                }
                if (row["C_RF_CODE"] != null)
                {
                    model.C_RF_CODE = row["C_RF_CODE"].ToString();
                }
                if (row["C_NC_PK"] != null)
                {
                    model.C_NC_PK = row["C_NC_PK"].ToString();
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
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,N_STATUS,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,C_NC_CODE,C_RF_CODE,C_NC_PK ");
            strSql.Append(" FROM TPB_LINEWH ");
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
            strSql.Append("select count(1) FROM TPB_LINEWH ");
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
            strSql.Append(")AS Row, T.*  from TPB_LINEWH T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  BasicMethod
        /// <summary>
        /// 根据仓库编码判断数据是否存在
        /// </summary>
        public bool ExistsByCode(string C_LINEWH_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TPB_LINEWH");
            strSql.Append(" where C_ID=:C_LINEWH_CODE AND N_STATUS=1 ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_LINEWH_CODE;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListByStatus(int iStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,D_START_DATE,D_END_DATE,DECODE(N_STATUS,1,'启用','停用') N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TPB_LINEWH ");
            if (iStatus.ToString().Trim() != "")
            {
                strSql.Append(" where N_STATUS=" + iStatus);
            }
            strSql.Append(" order by to_number(C_LINEWH_CODE)");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_ID(string C_LINEWH_CODE, string C_LINEWH_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,D_START_DATE,D_END_DATE ");
            strSql.Append(" FROM TPB_LINEWH where 1=1 ");
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE ='" + C_LINEWH_CODE + "'");
            }
            if (C_LINEWH_NAME.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_NAME ='" + C_LINEWH_NAME + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }


        #endregion  BasicMethod
        /// <summary>
        /// 根据仓库代码获得model
        /// </summary>
        /// <param name="C_LINEWH_CODE">仓库代码</param>
        /// <returns></returns>
        public Mod_TPB_LINEWH GetModelByCode(string C_LINEWH_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_LINEWH_CODE,C_LINEWH_NAME,N_STATUS,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,C_NC_CODE,C_RF_CODE,C_NC_PK from TPB_LINEWH ");
            strSql.Append(" where C_LINEWH_CODE=:C_LINEWH_CODE ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_LINEWH_CODE", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_LINEWH_CODE;

            Mod_TPB_LINEWH model = new Mod_TPB_LINEWH();
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
        /// 获得数据列表-主键获取
        /// </summary>
        /// <param name="C_SLABWH_CODE">仓库编码</param>
        /// <returns></returns>
        public object GetList_id(string C_LINEWH_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID");
            strSql.Append(" FROM TPB_LINEWH where 1=1 ");
            if (C_LINEWH_CODE.Trim() != "")
            {
                strSql.Append(" and C_LINEWH_CODE ='" + C_LINEWH_CODE + "'");
            }
            return DbHelperOra.GetSingle(strSql.ToString());
        }

    }
}

