using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Security.Cryptography;
using System.Text;

namespace NF.DAL
{
    public class TransactionHelper
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	
        private static string connectionString = "DATA SOURCE=192.168.2.94/ORCLPDB;PASSWORD=Admin2018;PERSIST SECURITY INFO=True;USER ID=xgcap";

        /// <summary>
        /// 事务
        /// </summary>
        public static OracleTransaction trans = null;

        [ThreadStatic]
        private static OracleConnection _conn = null;

        /// <summary>
        /// 连接池
        /// </summary>        
        private static OracleConnection connection
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new OracleConnection(connectionString);
                }

                return _conn;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private TransactionHelper()
        {

        }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public static OracleTransaction BeginTransaction()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            trans = connection.BeginTransaction();
            return trans;
        }

        /// <summary>
        /// 提交事物
        /// </summary>
        public static void Commit()
        {
            trans.Commit();
            trans.Dispose();
        }

        /// <summary>
        /// 回滚事物
        /// </summary>
        public static void RollBack()
        {
            if (connection.State == ConnectionState.Open)
            {
                if (trans.Connection == null)
                {
                    trans.Dispose();
                    return;
                }
                trans.Rollback();
                trans.Dispose();
            }
        }



        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, connection))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OracleException E)
                {
                    connection.Close();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, trans, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (OracleException E)
                {
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            DataSet ds = new DataSet();
            try
            {
                OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (OracleException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }


        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params OracleParameter[] cmdParms)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, connection, trans, SQLString, cmdParms);
            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #region PCI
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, connection))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (OracleException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        #endregion

    }
}
