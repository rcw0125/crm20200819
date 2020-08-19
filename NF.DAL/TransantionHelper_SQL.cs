using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace NF.DAL
{
    public partial class TransactionHelper_SQL
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.	
        //private static string connectionString = Decrypt(ConfigurationManager.ConnectionStrings["xgcap"].ConnectionString);
        public static string connectionString = "server=192.168.2.166;database=Acctrue_WMS;uid=sa;pwd=aaa123!";
        /// <summary>
        /// 事务
        /// </summary>
        public static SqlTransaction trans = null;

        /// <summary>
        /// 连接池
        /// </summary>
        /// 
        //private static SqlConnection connection = new SqlConnection(connectionString);

        [ThreadStatic]
        private static SqlConnection _conn = null;

        /// <summary>
        /// 连接池
        /// </summary>        
        private static SqlConnection connection
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new SqlConnection(connectionString);
                }

                return _conn;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        private TransactionHelper_SQL()
        {

        }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public static SqlTransaction BeginTransaction()
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
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    cmd.Transaction = trans;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException E)
                {
                    connection.Close();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
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
                catch (SqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, trans, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (SqlException E)
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
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
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
                foreach (SqlParameter parm in cmdParms)
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
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (SqlException ex)
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
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, trans, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
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

    }
}
