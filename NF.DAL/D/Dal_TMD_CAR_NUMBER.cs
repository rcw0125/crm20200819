using NF.DAL;
using NF.MODEL.D;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.DLL.D
{
    /// <summary>
    /// 数据访问类:TMD_CAR_NUMBER
    /// </summary>
    public partial class Dal_TMD_CAR_NUMBER
    {
        public Dal_TMD_CAR_NUMBER()
        { }
        #region  BasicMethod




        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string car)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMD_CAR_NUMBER T WHERE T.C_TYPE='禁止发运'");
            strSql.AppendFormat(" AND NVL(SUBSTR(T.C_NUMBER, 0, INSTR(T.C_NUMBER, '-') - 1), T.C_NUMBER)='{0}'", car);
            return DbHelperOra.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMD_CAR_NUMBER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMD_CAR_NUMBER(");
            strSql.Append("C_NUMBER,N_STATUS,C_EMP_ID,C_TYPE)");
            strSql.Append(" values (");
            strSql.Append(":C_NUMBER,:N_STATUS,:C_EMP_ID,:C_TYPE)");
            OracleParameter[] parameters = {
                   
                    new OracleParameter(":C_NUMBER", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_TYPE", OracleDbType.Varchar2,100)
            };
          
            parameters[0].Value = model.C_NUMBER;
            parameters[1].Value = model.N_STATUS;
            parameters[2].Value = model.C_EMP_ID;
            parameters[3].Value = model.C_TYPE;

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
        public bool Update(Mod_TMD_CAR_NUMBER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMD_CAR_NUMBER set ");
            strSql.Append("C_ID=:C_ID,");
            strSql.Append("C_NUMBER=:C_NUMBER,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_NUMBER", OracleDbType.Varchar2,200),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_NUMBER;
            parameters[2].Value = model.N_STATUS;
            parameters[3].Value = model.C_EMP_ID;
            parameters[4].Value = model.D_MOD_DT;

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
        public bool Delete(string strwhere )
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMD_CAR_NUMBER where 1=1  ");

            strSql.Append(strwhere);
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
        /// 删除一条数据
        /// </summary>
        public bool UpdateByWhere(string strwhere)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update TMD_CAR_NUMBER set N_STATUS=0 where 1=1  ");
            
            strSql.Append(strwhere);
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
        public Mod_TMD_CAR_NUMBER GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NUMBER,N_STATUS,C_EMP_ID,D_MOD_DT from TMD_CAR_NUMBER ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

            Mod_TMD_CAR_NUMBER model = new Mod_TMD_CAR_NUMBER();
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
        public Mod_TMD_CAR_NUMBER DataRowToModel(DataRow row)
        {
            Mod_TMD_CAR_NUMBER model = new Mod_TMD_CAR_NUMBER();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_NUMBER"] != null)
                {
                    model.C_NUMBER = row["C_NUMBER"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string cph,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_NUMBER,N_STATUS,C_EMP_ID,D_MOD_DT,C_TYPE ");
            strSql.Append(" FROM TMD_CAR_NUMBER WHERE 1=1");
            if(!string .IsNullOrEmpty(cph))
            {
                strSql.Append(" AND C_NUMBER LIKE '%"+cph+"%'");
            }
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" AND C_TYPE = '" + type + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from TMD_CAR_NUMBER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
