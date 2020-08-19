using System;
using System.Data;
using System.Text;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMB_FILE_NEXT_EMP
    /// </summary>
    public partial class Dal_TMB_FILE_NEXT_EMP
    {
        public Dal_TMB_FILE_NEXT_EMP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMB_FILE_NEXT_EMP");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMB_FILE_NEXT_EMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_FILE_NEXT_EMP(");
            strSql.Append("C_FILE_ID,C_FLOW_ID,C_NEXT_EMP_ID,C_STEP_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_FILE_ID,:C_FLOW_ID,:C_NEXT_EMP_ID,:C_STEP_ID)");
            OracleParameter[] parameters = {

                    new OracleParameter(":C_FILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEXT_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100)};

            parameters[0].Value = model.C_FILE_ID;
            parameters[1].Value = model.C_FLOW_ID;
            parameters[2].Value = model.C_NEXT_EMP_ID;
            parameters[3].Value = model.C_STEP_ID;

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
        public bool Update(Mod_TMB_FILE_NEXT_EMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMB_FILE_NEXT_EMP set ");
            strSql.Append("C_FILE_ID=:C_FILE_ID,");
            strSql.Append("C_FLOW_ID=:C_FLOW_ID,");
            strSql.Append("C_NEXT_EMP_ID=:C_NEXT_EMP_ID,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_STEP_ID=:C_STEP_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_FILE_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_FLOW_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NEXT_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_STEP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_FILE_ID;
            parameters[1].Value = model.C_FLOW_ID;
            parameters[2].Value = model.C_NEXT_EMP_ID;
            parameters[3].Value = model.C_REMARK;
            parameters[4].Value = model.C_STEP_ID;
            parameters[5].Value = model.C_ID;

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
            strSql.Append("delete from TMB_FILE_NEXT_EMP ");
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
            strSql.Append("delete from TMB_FILE_NEXT_EMP ");
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
        public Mod_TMB_FILE_NEXT_EMP GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_FILE_ID,C_FLOW_ID,C_NEXT_EMP_ID,C_REMARK,C_STEP_ID from TMB_FILE_NEXT_EMP ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMB_FILE_NEXT_EMP model = new Mod_TMB_FILE_NEXT_EMP();
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
        public Mod_TMB_FILE_NEXT_EMP DataRowToModel(DataRow row)
        {
            Mod_TMB_FILE_NEXT_EMP model = new Mod_TMB_FILE_NEXT_EMP();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_FILE_ID"] != null)
                {
                    model.C_FILE_ID = row["C_FILE_ID"].ToString();
                }
                if (row["C_FLOW_ID"] != null)
                {
                    model.C_FLOW_ID = row["C_FLOW_ID"].ToString();
                }
                if (row["C_NEXT_EMP_ID"] != null)
                {
                    model.C_NEXT_EMP_ID = row["C_NEXT_EMP_ID"].ToString();
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["C_STEP_ID"] != null)
                {
                    model.C_STEP_ID = row["C_STEP_ID"].ToString();
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
            strSql.Append("select C_ID,C_FILE_ID,C_FLOW_ID,C_NEXT_EMP_ID,C_REMARK,C_STEP_ID ");
            strSql.Append(" FROM TMB_FILE_NEXT_EMP ");
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
            strSql.Append("select count(1) FROM TMB_FILE_NEXT_EMP ");
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
            strSql.Append(")AS Row, T.*  from TMB_FILE_NEXT_EMP T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }




        #endregion  BasicMethod

        #region //自定义方法
        /// <summary>
        /// 更新下一步
        /// </summary>
        /// <param name="fileID">文件ID</param>
        /// <param name="stepID">当前步骤</param>
        /// <param name="nextStep">下一步骤</param>
        /// <param name="NextEmp">下一处理人</param>
        /// <param name="empID">当前处理人</param>
        /// <returns></returns>
        public bool UpdateNextSetp(string fileID, string stepID, string nextStep, string nextEmp, string empID)
        {

            ArrayList arraySql = new ArrayList();

            #region //更新文件步骤
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update TMF_FILEINFO set ");

            strSql2.Append("C_STEP_ID='" + nextStep + "'");
            strSql2.Append(" where C_ID='" + fileID + "' ");
            arraySql.Add(strSql2.ToString());
            #endregion

            #region //更新下一步骤操作人
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMB_FILE_NEXT_EMP(");
            strSql.Append("C_FILE_ID,C_NEXT_EMP_ID,C_STEP_ID)");
            strSql.Append(" values (");
            strSql.Append("'" + fileID + "','" + nextEmp + "','" + nextStep + "')");
            arraySql.Add(strSql.ToString());
            #endregion

            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        /// <summary>
        /// 驳回步骤处理
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="stepID"></param>
        /// <param name="nextStep"></param>
        /// <returns></returns>
        public bool BackSetp(string fileID, string stepID, string nextStep, string upStep)
        {
            ArrayList strSql = new ArrayList();
            strSql.Add("delete from TMB_FILE_NEXT_EMP  where C_FILE_ID ='" + fileID + "'");

            //更新当前步骤，上一步骤
            strSql.Add("update TMF_FILEINFO set N_STATUS=1,C_STEP_ID='" + upStep + "' where C_ID='" + fileID + "'");

            return DbHelperOra.ExecuteSqlTran(strSql);
        }
        #endregion
    }
}

