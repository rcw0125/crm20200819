using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using System.Collections.Generic;
using System.Collections;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TS_DIC
    /// </summary>
    public partial class Dal_TS_DIC
    {
        public Dal_TS_DIC()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TS_DIC");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID",OracleDbType.Varchar2,100)           };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TS_DIC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TS_DIC(");
            strSql.Append("C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_TYPECODE,:C_TYPENAME,:C_DETAILCODE,:C_DETAILNAME,:C_INDEX,:N_STATUS,:N_ISGPS,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TYPECODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_TYPENAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_DETAILCODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_DETAILNAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_INDEX", OracleDbType.Int32,3),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":N_ISGPS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_TYPECODE;
            parameters[2].Value = model.C_TYPENAME;
            parameters[3].Value = model.C_DETAILCODE;
            parameters[4].Value = model.C_DETAILNAME;
            parameters[5].Value = model.C_INDEX;
            parameters[6].Value = model.N_STATUS;
            parameters[7].Value = model.N_ISGPS;
            parameters[8].Value = model.C_EMP_ID;
            parameters[9].Value = model.C_EMP_NAME;
            parameters[10].Value = model.D_MOD_DT;

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
        /// 获取区域是否按客户发运
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public string GetAreaFlag(string area)
        {
            string strSql = $@"select t.c_extend2 from ts_dic t where t.c_typecode='ConArea' and t.c_detailname='{area}'";
            object obj = DbHelperOra.GetSingle(strSql);
            if (obj == null)
            {
                return "N";
            }
            else
            {
                return obj.ToString();
            }
        }


        /// <summary>
        /// 获取发运标识状态Y/N
        /// </summary>
        /// <param name="code">标识代码</param>
        /// <param name="name">标识名称</param>
        /// <returns></returns>
        public string GetDicFlag(string code,string name)
        {
            string strSql = $@"select t.c_extend2 from ts_dic t where t.c_typecode='{code}' and t.c_detailname='{name}'";
            object obj = DbHelperOra.GetSingle(strSql);
            if (obj == null)
            {
                return "N";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 区域GPS配置
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateAreaGPS(List<Mod_TS_DIC> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"UPDATE TS_DIC SET N_ISGPS={item.N_ISGPS} WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }
        /// <summary>
        /// 区域按客户发运
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateAreaCust(List<Mod_TS_DIC> list)
        {
            ArrayList arraySql = new ArrayList();

            foreach (var item in list)
            {
                string strSql = $@"UPDATE TS_DIC SET C_EXTEND2='{item.C_EXTEND2}' WHERE C_ID='{item.C_ID}'";
                arraySql.Add(strSql);
            }
            return DbHelperOra.ExecuteSqlTran(arraySql);
        }

        /// <summary>
        /// 更新是否GPS
        /// </summary>
        public bool UpdateN_ISGPS(int isGPS, String idList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_DIC set ");
            strSql.Append("N_ISGPS=" + isGPS + "");
            strSql.Append(" where C_ID in(" + idList + ") ");

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Mod_TS_DIC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TS_DIC set ");
            strSql.Append("C_TYPECODE=:C_TYPECODE,");
            strSql.Append("C_TYPENAME=:C_TYPENAME,");
            strSql.Append("C_DETAILCODE=:C_DETAILCODE,");
            strSql.Append("C_DETAILNAME=:C_DETAILNAME,");
            strSql.Append("C_INDEX=:C_INDEX,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_ISGPS=:N_ISGPS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_TYPECODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_TYPENAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_DETAILCODE", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_DETAILNAME", OracleDbType.Varchar2,80),
                    new OracleParameter(":C_INDEX", OracleDbType.Int32,3),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":N_ISGPS", OracleDbType.Int16,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_TYPECODE;
            parameters[1].Value = model.C_TYPENAME;
            parameters[2].Value = model.C_DETAILCODE;
            parameters[3].Value = model.C_DETAILNAME;
            parameters[4].Value = model.C_INDEX;
            parameters[5].Value = model.N_STATUS;
            parameters[6].Value = model.N_ISGPS;
            parameters[7].Value = model.C_EMP_ID;
            parameters[8].Value = model.C_EMP_NAME;
            parameters[9].Value = model.D_MOD_DT;
            parameters[10].Value = model.C_ID;

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
            strSql.Append("delete from TS_DIC ");
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
            strSql.Append("delete from TS_DIC ");
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
        public Mod_TS_DIC GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TS_DIC ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TS_DIC model = new Mod_TS_DIC();
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
        public Mod_TS_DIC DataRowToModel(DataRow row)
        {
            Mod_TS_DIC model = new Mod_TS_DIC();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_TYPECODE"] != null)
                {
                    model.C_TYPECODE = row["C_TYPECODE"].ToString();
                }
                if (row["C_TYPENAME"] != null)
                {
                    model.C_TYPENAME = row["C_TYPENAME"].ToString();
                }
                if (row["C_DETAILCODE"] != null)
                {
                    model.C_DETAILCODE = row["C_DETAILCODE"].ToString();
                }
                if (row["C_DETAILNAME"] != null)
                {
                    model.C_DETAILNAME = row["C_DETAILNAME"].ToString();
                }
                if (row["C_INDEX"] != null && row["C_INDEX"].ToString() != "")
                {
                    model.C_INDEX = decimal.Parse(row["C_INDEX"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_ISGPS"] != null && row["N_ISGPS"].ToString() != "")
                {
                    model.N_ISGPS = decimal.Parse(row["N_ISGPS"].ToString());
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
        public DataSet GetDis(string C_TYPECODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5 ");
            strSql.Append(" FROM TS_DIC where N_STATUS=1 ");
            if (!string.IsNullOrEmpty(C_TYPECODE))
            {
                strSql.Append(" and C_TYPECODE='" + C_TYPECODE + "'");
            }
            strSql.Append(" order by C_INDEX asc");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Mod_TS_DIC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5 ");
            strSql.Append(" FROM TS_DIC where N_STATUS=1 ");
            if (!string.IsNullOrEmpty(model.C_TYPECODE))
            {
                strSql.Append(" and C_TYPECODE='" + model.C_TYPECODE + "'");
            }
            if (!string.IsNullOrEmpty(model.C_DETAILCODE))
            {
                strSql.Append(" and C_DETAILCODE='" + model.C_DETAILCODE + "'");
            }
            strSql.Append(" order by C_INDEX asc");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDicArea(string C_PARENT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5 ");
            strSql.Append(" FROM TS_DIC where N_STATUS=1 AND C_TYPECODE='ConArea' ");
            if (!string.IsNullOrEmpty(C_PARENT_ID))
            {
                strSql.AppendFormat(" AND C_EXTEND1='{0}'", C_PARENT_ID);
            }

            strSql.Append(" order by C_INDEX asc");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_TYPECODE,C_TYPENAME,C_DETAILCODE,C_DETAILNAME,C_INDEX,N_STATUS,N_ISGPS,C_EMP_ID,C_EMP_NAME,D_MOD_DT,C_EXTEND1,C_EXTEND2,C_EXTEND3,C_EXTEND4,C_EXTEND5 ");
            strSql.Append(" FROM TS_DIC ");
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
            strSql.Append("select count(1) FROM TS_DIC ");
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
            strSql.Append(")AS Row, T.*  from TS_DIC T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }



        #endregion  BasicMethod

    }
}

