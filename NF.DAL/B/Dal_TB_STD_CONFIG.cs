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
    ///标准匹配表
    /// </summary>
    public partial class Dal_TB_STD_CONFIG
    {
        public Dal_TB_STD_CONFIG()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string stlGrd, string custNo, string custXY)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_STD_CONFIG");
            strSql.AppendFormat(" where C_STL_GRD='{0}'", stlGrd);
            strSql.AppendFormat(" AND C_CUST_NO='{0}'", custNo);
            strSql.AppendFormat(" AND C_CUST_TECH_PROT='{0}'", custXY);

            return DbHelperOra.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_STD_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_STD_CONFIG(");
            strSql.Append("C_ID,C_STD_ID,C_CUST_TECH_PROT,C_ZYX1,C_ZYX2,C_STL_GRD,C_STD_CODE,C_STEEL_SIGN,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_STD_ID,:C_CUST_TECH_PROT,:C_ZYX1,:C_ZYX2,:C_STL_GRD,:C_STD_CODE,:C_STEEL_SIGN,:C_EMP_ID,:D_MOD_DT,:C_REMARK,:D_START_DATE,:D_END_DATE,:N_STATUS)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEEL_SIGN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STD_ID;
            parameters[2].Value = model.C_CUST_TECH_PROT;
            parameters[3].Value = model.C_ZYX1;
            parameters[4].Value = model.C_ZYX2;
            parameters[5].Value = model.C_STL_GRD;
            parameters[6].Value = model.C_STD_CODE;
            parameters[7].Value = model.C_STEEL_SIGN;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.D_MOD_DT;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.D_START_DATE;
            parameters[12].Value = model.D_END_DATE;
            parameters[13].Value = model.N_STATUS;

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
        public bool Update(Mod_TB_STD_CONFIG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_STD_CONFIG set ");
            strSql.Append("C_ID=:C_ID,");
            strSql.Append("C_STD_ID=:C_STD_ID,");
            strSql.Append("C_CUST_TECH_PROT=:C_CUST_TECH_PROT,");
            strSql.Append("C_ZYX1=:C_ZYX1,");
            strSql.Append("C_ZYX2=:C_ZYX2,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_STEEL_SIGN=:C_STEEL_SIGN,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("D_START_DATE=:D_START_DATE,");
            strSql.Append("D_END_DATE=:D_END_DATE,");
            strSql.Append("N_STATUS=:N_STATUS");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CUST_TECH_PROT", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX1", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ZYX2", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STEEL_SIGN", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,200),
                    new OracleParameter(":D_START_DATE", OracleDbType.Date),
                    new OracleParameter(":D_END_DATE", OracleDbType.Date),
                    new OracleParameter(":N_STATUS", OracleDbType.Int32,1)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STD_ID;
            parameters[2].Value = model.C_CUST_TECH_PROT;
            parameters[3].Value = model.C_ZYX1;
            parameters[4].Value = model.C_ZYX2;
            parameters[5].Value = model.C_STL_GRD;
            parameters[6].Value = model.C_STD_CODE;
            parameters[7].Value = model.C_STEEL_SIGN;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.D_MOD_DT;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.D_START_DATE;
            parameters[12].Value = model.D_END_DATE;
            parameters[13].Value = model.N_STATUS;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_STD_CONFIG ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

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
        public Mod_TB_STD_CONFIG GetModel(string C_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STD_ID,C_CUST_TECH_PROT,C_ZYX1,C_ZYX2,C_STL_GRD,C_STD_CODE,C_STEEL_SIGN,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS from TB_STD_CONFIG ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)         };
            parameters[0].Value = C_ID;

            Mod_TB_STD_CONFIG model = new Mod_TB_STD_CONFIG();
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
        public Mod_TB_STD_CONFIG DataRowToModel(DataRow row)
        {
            Mod_TB_STD_CONFIG model = new Mod_TB_STD_CONFIG();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_STD_ID"] != null)
                {
                    model.C_STD_ID = row["C_STD_ID"].ToString();
                }
                if (row["C_CUST_TECH_PROT"] != null)
                {
                    model.C_CUST_TECH_PROT = row["C_CUST_TECH_PROT"].ToString();
                }
                if (row["C_ZYX1"] != null)
                {
                    model.C_ZYX1 = row["C_ZYX1"].ToString();
                }
                if (row["C_ZYX2"] != null)
                {
                    model.C_ZYX2 = row["C_ZYX2"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_STEEL_SIGN"] != null)
                {
                    model.C_STEEL_SIGN = row["C_STEEL_SIGN"].ToString();
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
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获取技术协议
        /// </summary>
        /// <param name="c_stl_grd">钢种</param>
        /// <param name="c_cust_no">客户编码</param>
        /// <returns></returns>
		public DataSet GetCUST_TECH_PROT(string c_stl_grd, string c_cust_no)
        {
            string[] arr = { c_stl_grd, c_cust_no };

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"WITH TT AS
                                 (SELECT T.C_ID,
                                         T.C_STD_CODE AS C_CUST_TECH_PROT,
                                         T.C_ZYX1,
                                         T.C_ZYX2,
                                         T.C_STL_GRD,
                                         T.C_STD_CODE
                                    FROM TB_STD_CONFIG T
                                  INNER JOIN TQB_STD_MAIN B
                                      ON T.C_STD_CODE=B.C_STD_CODE AND T.C_STL_GRD=B.C_STL_GRD
                                   WHERE T.C_STL_GRD = '{0}'
                                     AND T.C_CUST_NO IS NULL
                                     AND B.N_STATUS=1
                                     AND B.N_IS_CHECK=1
                                     AND T.N_STATUS=1
                                  UNION ALL
                                  SELECT T.C_ID,
                                         T.C_CUST_TECH_PROT,
                                         T.C_ZYX1,
                                         T.C_ZYX2,
                                         T.C_STL_GRD,
                                         T.C_STD_CODE
                                    FROM TB_STD_CONFIG T
                                   INNER JOIN TQB_STD_MAIN B
                                     ON T.C_STD_CODE=B.C_STD_CODE AND T.C_STL_GRD=B.C_STL_GRD                                
                                   WHERE T.C_STL_GRD = '{0}'
                                     AND T.C_CUST_NO = '{1}'
                                     AND B.N_STATUS=1
                                     AND B.N_IS_CHECK=1
                                     AND T.N_STATUS=1)
                                SELECT C_ID,
                                       C_CUST_TECH_PROT,
                                       C_ZYX1,
                                       C_ZYX2,
                                       C_STL_GRD,
                                       C_STD_CODE
                                  FROM TT", arr);
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取技术协议
        /// </summary>
        /// <param name="c_stl_grd">钢种</param>
        /// <param name="c_spec">规格</param>
        /// <param name="c_cust_no">客户编码</param>
        /// <returns></returns>
        public DataSet GetCUST_TECH_PROT(string c_stl_grd)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"SELECT DISTINCT
                                         T.C_STD_CODE
                                    FROM TB_STD_CONFIG T
                                   INNER JOIN TQB_STD_MAIN B
                                      ON T.C_STD_CODE=B.C_STD_CODE AND T.C_STL_GRD=B.C_STL_GRD
                                   WHERE T.C_STL_GRD = '{0}'
                                     AND T.N_STATUS=1
                                     AND B.N_IS_CHECK=1
                                     AND B.N_STATUS=1", c_stl_grd);

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="stdCode">执行标准</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataRow GetFREE(string stdCode, string stlGrd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT 
                                   T.C_ID,
                                   T.C_CUST_TECH_PROT,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_STL_GRD,
                                   T.C_STD_CODE,
                                   B.C_USES,
                                   B.C_IS_BXG,
                                   A.C_ID,
                                   A.C_DESIGN_NO,
                                   B.C_PROD_NAME,
                                   B.C_PROD_KIND 
                              FROM TB_STD_CONFIG T
                              INNER JOIN TQB_STD_MAIN B 
                                ON T.C_STD_CODE=B.C_STD_CODE AND T.C_STL_GRD=B.C_STL_GRD
                              INNER JOIN TQB_DESIGN A
                                ON B.C_ID = A.C_STD_MAIN_ID 
                              WHERE T.N_STATUS=1  AND B.N_IS_CHECK=1 AND B.N_STATUS=1 AND A.N_STATUS=1 AND  T.C_STD_CODE='{0}' AND T.C_STL_GRD='{1}'", stdCode, stlGrd);

            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获取自由项
        /// </summary>
        /// <param name="C_CUST_TECH_PROT">客户协议</param>
        /// <param name="stdCode">执行标准</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataRow GetFREE2(string C_CUST_TECH_PROT, string stlGrd)
        {
            string[] arr = { C_CUST_TECH_PROT, stlGrd };
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT 
                                   T.C_ID,
                                   T.C_CUST_TECH_PROT,
                                   T.C_ZYX1,
                                   T.C_ZYX2,
                                   T.C_STL_GRD,
                                   T.C_STD_CODE,
                                   B.C_USES,
                                   B.C_IS_BXG,
                                   A.C_ID,
                                   A.C_DESIGN_NO,
                                   B.C_PROD_NAME,
                                   B.C_PROD_KIND 
                              FROM TB_STD_CONFIG T
                              INNER JOIN TQB_STD_MAIN B 
                                ON T.C_STD_CODE=B.C_STD_CODE AND T.C_STL_GRD=B.C_STL_GRD
                              INNER JOIN TQB_DESIGN A
                                ON B.C_ID = A.C_STD_MAIN_ID 
                              WHERE T.N_STATUS=1  AND B.N_IS_CHECK=1 AND B.N_STATUS=1 AND A.N_STATUS=1 AND T.C_CUST_TECH_PROT='{0}'  AND T.C_STL_GRD='{1}'", arr);

            return DbHelperOra.GetDataRow(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STD_ID,C_CUST_TECH_PROT,C_ZYX1,C_ZYX2,C_STL_GRD,C_STD_CODE,C_STEEL_SIGN,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS ");
            strSql.Append(" FROM TB_STD_CONFIG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string custNo, string custName, string stlGrd, string techProt, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM TB_STD_CONFIG WHERE N_STATUS=1 ");

            if (!string.IsNullOrEmpty(custNo))
            {
                strSql.Append(" and C_CUST_NO like '%" + custNo + "%'");
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append(" and C_CUST_NAME like '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like  '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(techProt))
            {
                strSql.Append(" and UPPER(C_CUST_TECH_PROT) like  '%" + techProt.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(std))
            {
                strSql.Append(" and UPPER(C_STD_CODE) like  '%" + std.ToUpper() + "%'");
            }

            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="custNo">客户编码</param>
        /// <param name="custName">客户名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="techProt">客户协议</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public int GetRecordCount(string custNo, string custName, string stlGrd, string techProt, string std)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TB_STD_CONFIG where N_STATUS=1");

            if (!string.IsNullOrEmpty(custNo))
            {
                strSql.Append(" and C_CUST_NO like '%" + custNo + "%'");
            }
            if (!string.IsNullOrEmpty(custName))
            {
                strSql.Append(" and C_CUST_NAME like '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.Append(" and UPPER(C_STL_GRD) like  '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(techProt))
            {
                strSql.Append(" and UPPER(C_CUST_TECH_PROT) like  '%" + techProt.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(std))
            {
                strSql.Append(" and UPPER(C_STD_CODE) like  '%" + std.ToUpper() + "%'");
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
        /// 获取分页数据
        /// </summary>
        /// <param name="pageSize">显示页数</param>
        /// <param name="startIndex">起始页数</param>
        /// <param name="custNo">客户编码</param>
        /// <param name="custName">客户名称</param>
        /// <param name="stlGrd">钢种</param>
        /// <param name="techProt">客户协议</param>
        /// <param name="std">执行标准</param>
        /// <returns></returns>
        public DataSet GetListByPage(int pageSize, int startIndex, string custNo, string custName, string stlGrd, string techProt, string std)
        {
            StringBuilder where = new StringBuilder();

            string item = "C_ID,C_STD_ID,C_CUST_TECH_PROT,C_ZYX1,C_ZYX2,C_STL_GRD,C_STD_CODE,C_STEEL_SIGN,C_EMP_ID,D_MOD_DT,C_REMARK,D_START_DATE,D_END_DATE,N_STATUS,C_CUST_NO,C_CUST_NAME,C_ZZS";
            string table = "TB_STD_CONFIG";
            string order = "C_STL_GRD  desc";

            where.Append(" and N_STATUS=1");

            if (!string.IsNullOrEmpty(custNo))
            {
                where.Append(" and C_CUST_NO like '%" + custNo + "%'");
            }
            if (!string.IsNullOrEmpty(custName))
            {
                where.Append(" and C_CUST_NAME like '%" + custName + "%'");
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                where.Append(" and UPPER(C_STL_GRD) like '%" + stlGrd.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(techProt))
            {
                where.Append(" and UPPER(C_CUST_TECH_PROT) like  '%" + techProt.ToUpper() + "%'");
            }
            if (!string.IsNullOrEmpty(std))
            {
                where.Append(" and UPPER(C_STD_CODE) like  '%" + std.ToUpper() + "%'");
            }

            string sql = ByPage.GenerateByPageSql(pageSize, startIndex, item, table, order, where.ToString());
            return DbHelperOra.Query(sql);

        }

        #endregion  BasicMethod


        #region //停用

        public bool UpdateFlag(List<Mod_TB_STD_CONFIG> list)
        {
            ArrayList arraySql = new ArrayList();
            foreach (var item in list)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TB_STD_CONFIG set ");
                strSql.AppendFormat("C_FLAG='{0}'", item.C_FLAG);
                strSql.AppendFormat(" where C_ID='{0}'", item.C_ID);
                arraySql.Add(strSql.ToString());
            }


            return DbHelperOra.ExecuteSqlTran(arraySql);

        }

        public bool UpdateStatus(List<string> listID, int status)
        {
            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < listID.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update TB_STD_CONFIG set ");
                strSql.Append("N_STATUS=" + status + "");
                strSql.Append(" where C_ID='" + listID[i].ToString() + "'");
                arraySql.Add(strSql.ToString());
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }
        /// <summary>
        /// 删除客户协议
        /// </summary>
        /// <param name="listID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool DelList(List<string> listID)
        {

            ArrayList arraySql = new ArrayList();
            for (int i = 0; i < listID.Count; i++)
            {
                Mod_TB_STD_CONFIG mod = GetModel(listID[i].ToString());
                if (mod != null)
                {

                }
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from tb_std_config  where C_ID='" + listID[i].ToString() + "'");
                arraySql.Add(strSql.ToString());
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);

        }
        #endregion

        #region //PCI
        /// <summary>
        /// 获取执行标准代码
        /// </summary>
        /// <param name="strFree1">自由项1</param>
        /// <param name="strFree2">自由项2</param>
        /// <returns></returns>
        public string Get_Std_Code(string strFree1, string strFree2)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(T.C_STD_CODE) FROM TB_STD_CONFIG T WHERE T.C_ZYX1='" + strFree1 + "' AND T.C_ZYX2='" + strFree2 + "' ");

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
        #endregion



    }
}

