using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TB_BCBZ
    /// </summary>
    public partial class Dal_TB_BCBZ
    {
        public Dal_TB_BCBZ()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_BCBZ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TB_BCBZ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_BCBZ(");
            strSql.Append("D_START,D_END,C_BC,C_BZ,C_EMP_ID,D_MOD_DT,C_PRO_ID)");
            strSql.Append(" values (");
            strSql.Append(":D_START,:D_END,:C_BC,:C_BZ,:C_EMP_ID,:D_MOD_DT,:C_PRO_ID)");
            OracleParameter[] parameters = {
                    new OracleParameter(":D_START", OracleDbType.Date),
                    new OracleParameter(":D_END", OracleDbType.Date),
                    new OracleParameter(":C_BC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
               new OracleParameter(":C_PRO_ID",OracleDbType.Varchar2,100)};
            parameters[0].Value = model.D_START;
            parameters[1].Value = model.D_END;
            parameters[2].Value = model.C_BC;
            parameters[3].Value = model.C_BZ;
            parameters[4].Value = model.C_EMP_ID;
            parameters[5].Value = model.D_MOD_DT;
            parameters[6].Value = model.C_PRO_ID;
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
        public bool Update(Mod_TB_BCBZ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_BCBZ set ");
            strSql.Append("D_START=:D_START,");
            strSql.Append("D_END=:D_END,");
            strSql.Append("C_BC=:C_BC,");
            strSql.Append("C_BZ=:C_BZ,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":D_START", OracleDbType.Date),
                    new OracleParameter(":D_END", OracleDbType.Date),
                    new OracleParameter(":C_BC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.D_START;
            parameters[1].Value = model.D_END;
            parameters[2].Value = model.C_BC;
            parameters[3].Value = model.C_BZ;
            parameters[4].Value = model.C_EMP_ID;
            parameters[5].Value = model.D_MOD_DT;
            parameters[6].Value = model.C_ID;

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
            strSql.Append("delete from TB_BCBZ ");
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
            strSql.Append("delete from TB_BCBZ ");
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
        public Mod_TB_BCBZ GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,D_START,D_END,C_BC,C_BZ,C_EMP_ID,D_MOD_DT from TB_BCBZ ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TB_BCBZ model = new Mod_TB_BCBZ();
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
        public Mod_TB_BCBZ DataRowToModel(DataRow row)
        {
            Mod_TB_BCBZ model = new Mod_TB_BCBZ();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["D_START"] != null && row["D_START"].ToString() != "")
                {
                    model.D_START = DateTime.Parse(row["D_START"].ToString());
                }
                if (row["D_END"] != null && row["D_END"].ToString() != "")
                {
                    model.D_END = DateTime.Parse(row["D_END"].ToString());
                }
                if (row["C_BC"] != null)
                {
                    model.C_BC = row["C_BC"].ToString();
                }
                if (row["C_BZ"] != null)
                {
                    model.C_BZ = row["C_BZ"].ToString();
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
            strSql.Append("select C_ID,D_START,C_PRO_ID,D_END,C_BC,C_BZ,C_EMP_ID,D_MOD_DT ");
            strSql.Append(" FROM TB_BCBZ ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY D_START");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TB_BCBZ ");
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
            strSql.Append(")AS Row, T.*  from TB_BCBZ T ");
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
        /// <summary>
        /// 根据开始时间删除数据
        /// </summary>
        public bool Delete(DateTime dateTime, string pro)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_BCBZ WHERE D_START>=to_date('" + dateTime + "','yyyy-MM-dd HH24:mi:ss')");
            strSql.Append(" AND C_PRO_ID ='" + pro + "'");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string pro, DateTime st, DateTime et)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.C_ID,A.D_START,A.C_PRO_ID,A.D_END,B.C_BC_NAME,C.C_BZ_NAME,A.C_EMP_ID,A.D_MOD_DT ");
            strSql.Append(" FROM TB_BCBZ A,TB_BC B,TB_BZ C");
            strSql.Append(" WHERE A.C_BC=B.C_ID AND A.C_BZ=C.C_ID AND A.C_PRO_ID='" + pro + "' AND A.D_START>=to_date('" + st + "','yyyy-MM-dd HH24:mi:ss') AND A.D_END<=to_date('" + et + "','yyyy-MM-dd HH24:mi:ss')");
            strSql.Append(" ORDER BY D_START");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据类别,时间获取当前班次班组
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataSet GetList(string type, DateTime dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_ID,a.D_START,a.C_PRO_ID,a.D_END,a.C_BC,a.C_BZ,a.C_EMP_ID,a.D_MOD_DT ,b.C_BC_NAME,c.C_BZ_NAME");
            strSql.Append(" FROM TB_BCBZ a,TB_BC b,TB_BZ c");
            strSql.Append(" WHERE a.C_PRO_ID='" + type + "' AND a.C_BC=b.C_ID AND a.C_BZ=c.C_ID AND a.D_START<=to_date('" + dt + "','yyyy-MM-dd HH24:mi:ss') AND a.D_END>=to_date('" + dt + "','yyyy-MM-dd HH24:mi:ss')");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据工序，班次获得NC班次
        /// </summary>
        /// <param name="stacode">工位代码</param>
        /// <param name="bc">班次</param>
        /// <returns></returns>
        public DataSet GetNCBCList(string stacode, string bc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT BD_WT.BCNAME, BD_WT.PK_WTID FROM  XGERP50.BD_WT@CAP_ERP, XGERP50.BD_RLH@CAP_ERP, XGERP50.PD_WK@CAP_ERP WHERE BD_WT.PK_BCLBID = BD_RLH.PK_BCLBID AND BD_RLH.PK_RLHID = PD_WK.RLHID ");
            if (stacode.Trim()!="")
            {
                strSql.Append(" AND PD_WK.GZZXBM = '" + stacode + "'");
            }
            if (bc.Trim() != "")
            {
                strSql.Append(" AND BD_WT.BCNAME ='" + bc + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据工位，班组获得NC班组
        /// </summary>
        /// <param name="gzzxid">工作中心ID</param>
        /// <param name="bz">班组</param>
        /// <returns></returns>
        public DataSet GetNCBZList(string gzzxid, string bz)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT PK_PGAID,
       CASE
         WHEN INSTR(BZMC, '甲') > 0 THEN
          '甲'
         WHEN INSTR(BZMC, '乙') > 0 THEN
          '乙'
         WHEN INSTR(BZMC, '丙') > 0 THEN
          '丙'
         ELSE
          '丁'
       END BZMC
  FROM XGERP50.PD_PGA@CAP_ERP WHERE 1=1");
            if (gzzxid.Trim()!="")
            {
                strSql.Append(" AND   GZZXID = '" + gzzxid + "'");
            }
            if (bz.Trim() != "")
            {
                strSql.Append(" AND  BZMC LIKE '%" + bz + "%'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
