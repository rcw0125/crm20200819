using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using NF.MODEL;

namespace NF.DAL
{
    public class Dal_TMB_PROC
    {
        public Dal_TMB_PROC() { }

        /// <summary>
        /// 获取产品类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetProcType()
        {
            string strsql = "SELECT C_ID,C_NAME  FROM TMB_PROC_TYPE WHERE N_STATUS=0 ORDER BY N_SORT";
            return DbHelperOra.Query(strsql);
        }

        /// <summary>
        /// 添加产品类型
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool AddProcType(string name)
        {
            string strSql = string.Format("INSERT INTO TMB_PROC_TYPE(C_NAME)VALUES('{0}')", name);
            int rows = DbHelperOra.ExecuteSql(strSql);
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
        ///更新产品类型
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="status">0正常，1停用</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool UpdateProcType(string name, string status, string id)
        {
            string[] where = { name, status, id };
            string strSql = string.Format("update TMB_PROC_TYPE set C_NAME='{0}',N_STATUS={1} where C_ID='{2}'", where);
            int rows = DbHelperOra.ExecuteSql(strSql);
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
        /// 获取产品列表
        /// </summary>
        /// <param name="procType">产品类型</param>
        /// <param name="stlGrd">钢种</param>
        /// <returns></returns>
        public DataSet GetProcList(string procType, string stlGrd, string pageIndex, string pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STLGRD,C_SPEC,C_STDCODE,C_DESC,C_REMARK,C_PROCTYPE,C_IMGURL,D_DATE from TMB_PROC where N_STATUS=0 ");
            if (!string.IsNullOrEmpty(procType))
            {
                strSql.AppendFormat(" and C_PROCTYPE='{0}'", procType);
            }
            if (!string.IsNullOrEmpty(stlGrd))
            {
                strSql.AppendFormat(" and C_STLGRD like '%{0}%'", stlGrd);
            }
            if (!string.IsNullOrEmpty(pageIndex) && !string.IsNullOrEmpty(pageSize))
            {
                return DataSetHelper.SplitDataSet(DbHelperOra.Query(strSql.ToString()), Convert.ToInt32(pageSize), Convert.ToInt32(pageIndex));
            }
            else
            {
                return DbHelperOra.Query(strSql.ToString());
            }

        }

        /// <summary>
        /// 获取产品列表
        /// </summary>

        /// <returns></returns>
        public DataSet GetProcList(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STLGRD,C_SPEC,C_STDCODE,C_DESC,C_REMARK,C_PROCTYPE,C_IMGURL,D_DATE from TMB_PROC where N_STATUS=0 and C_ID='" + id + "'");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="mod">产品属性</param>
        /// <returns></returns>
        public bool AddProc(Mod_TMB_PROC mod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TMB_PROC(C_STLGRD,C_SPEC,C_STDCODE,C_DESC,C_REMARK,C_PROCTYPE,C_IMGURL)");
            strSql.Append("VALUES(:C_STLGRD,:C_SPEC,:C_STDCODE,:C_DESC,:C_REMARK,:C_PROCTYPE,:C_IMGURL)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STLGRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_STDCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_PROCTYPE", OracleDbType.NVarchar2,1000),
                    new OracleParameter(":C_IMGURL", OracleDbType.Varchar2,200)
                   };
            parameters[0].Value = mod.C_STLGRD;
            parameters[1].Value = mod.C_SPEC;
            parameters[2].Value = mod.C_STDCODE;
            parameters[3].Value = mod.C_DESC;
            parameters[4].Value = mod.C_REMARK;
            parameters[5].Value = mod.C_PROCTYPE;
            parameters[6].Value = mod.C_IMGURL;
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

        public bool UpdateProc(Mod_TMB_PROC mod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  TMB_PROC SET C_STLGRD=:C_STLGRD,C_SPEC=:C_SPEC,C_STDCODE=:C_STDCODE,C_DESC=:C_DESC,C_REMARK=:C_REMARK,C_PROCTYPE=:C_PROCTYPE,C_IMGURL=:C_IMGURL  WHERE C_ID=:C_ID");

            OracleParameter[] parameters = {
                    new OracleParameter(":C_STLGRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_STDCODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_DESC", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,500),
                    new OracleParameter(":C_PROCTYPE", OracleDbType.NVarchar2,1000),
                    new OracleParameter(":C_IMGURL", OracleDbType.Varchar2,200),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)
                   };
            parameters[0].Value = mod.C_STLGRD;
            parameters[1].Value = mod.C_SPEC;
            parameters[2].Value = mod.C_STDCODE;
            parameters[3].Value = mod.C_DESC;
            parameters[4].Value = mod.C_REMARK;
            parameters[5].Value = mod.C_PROCTYPE;
            parameters[6].Value = mod.C_IMGURL;
            parameters[7].Value = mod.C_ID;
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
        public bool DelProc(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM   TMB_PROC WHERE C_ID='" + id + "')");
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
    }
}
