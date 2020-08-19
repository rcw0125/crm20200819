using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
using NF.DAL;

namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TSC_SLAB_MAIN_LOG
    /// </summary>
    public partial class Dal_TSC_SLAB_MAIN_LOG
    {
        public Dal_TSC_SLAB_MAIN_LOG()
        { }
        #region //钢坯现存量
        /// <summary>
        /// 获取钢坯数据状态
        /// </summary>
        /// <param name="gzlx">钢种类型</param>
        /// <param name="wlh">物料号</param>
        /// <param name="gz">钢种</param>
        /// <param name="zxbz">执行标准</param>
        /// <param name="lh">炉号</param> 
        /// <param name="ck">仓库</param>
        /// <param name="zt">状态</param>
        /// <param name="hlzt">缓冷状态</param>
        /// <param name="xmzt">修磨状态</param>
        /// <param name="pdzt">判断状态</param>
        /// <returns></returns>
        public DataSet GetSJ(string gzlx, string wlh, string gz, string zxbz, string lh, string ck, string zt, string hlzt, string xmzt, string pdzt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from V_SLAB_KC t WHERE 1=1");
            if (gzlx != "全部")
            {
                strSql.Append(" AND C_SLAB_TYPE LIKE '%" + gzlx + "%'");
            }
            if (!string.IsNullOrEmpty(wlh))
            {
                strSql.Append(" AND C_MAT_CODE LIKE '%" + wlh + "%'");
            }
            if (!string.IsNullOrEmpty(gz))
            {
                strSql.Append(" AND upper(C_STL_GRD) LIKE upper('%" + gz + "%')");
            }
            if (!string.IsNullOrEmpty(zxbz))
            {
                strSql.Append(" AND C_STD_CODE LIKE '%" + zxbz + "%'");
            }
            if (!string.IsNullOrEmpty(lh))
            {
                strSql.Append(" AND C_STOVE LIKE '%" + lh + "%' or C_BATCH_NO LIKE '%" + lh + "%' ");
            }
            if (ck != "全部")
            {
                strSql.Append(" AND C_SLABWH_CODE = '" + ck + "'");
            }
            if (zt != "全部")
            {
                strSql.Append(" AND C_MOVE_TYPE = '" + zt + "'");
            }
            if (xmzt != "全部")
            {
                strSql.Append(" AND C_ISXM = '" + xmzt + "'");
            }
            if (hlzt != "全部")
            {
                strSql.Append(" AND C_HL_TYPE = '" + hlzt + "'");
            }
            if (pdzt != "全部")
            {
                strSql.Append(" AND C_STOCK_STATE = '" + pdzt + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion


        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TSC_SLAB_MAIN_LOG");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TSC_SLAB_MAIN_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TSC_SLAB_MAIN_LOG(");
            strSql.Append("C_MAIN_ID,C_CKDH,N_STATUS,D_DATE,C_BC,C_BZ,C_EMP_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_MAIN_ID,:C_CKDH,:N_STATUS,:D_DATE,:C_BC,:C_BZ,:C_EMP_ID)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":D_DATE", OracleDbType.Date),
                    new OracleParameter(":C_BC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_MAIN_ID;
            parameters[1].Value = model.C_CKDH;
            parameters[2].Value = model.N_STATUS;
            parameters[3].Value = model.D_DATE;
            parameters[4].Value = model.C_BC;
            parameters[5].Value = model.C_BZ;
            parameters[6].Value = model.C_EMP_ID;
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
        public bool Update(Mod_TSC_SLAB_MAIN_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TSC_SLAB_MAIN_LOG set ");
            strSql.Append("C_MAIN_ID=:C_MAIN_ID,");
            strSql.Append("C_CKDH=:C_CKDH,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("D_DATE=:D_DATE,");
            strSql.Append("C_BC=:C_BC,");
            strSql.Append("C_BZ=:C_BZ,");
            strSql.Append("C_EMP_ID=:C_EMP_ID");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_MAIN_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_CKDH", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":D_DATE", OracleDbType.Date),
                    new OracleParameter(":C_BC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BZ", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_MAIN_ID;
            parameters[1].Value = model.C_CKDH;
            parameters[2].Value = model.N_STATUS;
            parameters[3].Value = model.D_DATE;
            parameters[4].Value = model.C_BC;
            parameters[5].Value = model.C_BZ;
            parameters[6].Value = model.C_EMP_ID;
            parameters[7].Value = model.C_ID;

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
            strSql.Append("delete from TSC_SLAB_MAIN_LOG ");
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
            strSql.Append("delete from TSC_SLAB_MAIN_LOG ");
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
        public Mod_TSC_SLAB_MAIN_LOG GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAIN_ID,C_CKDH,N_STATUS,D_DATE,C_BC,C_BZ,C_EMP_ID from TSC_SLAB_MAIN_LOG ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)            };
            parameters[0].Value = C_ID;

            Mod_TSC_SLAB_MAIN_LOG model = new Mod_TSC_SLAB_MAIN_LOG();
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
        public Mod_TSC_SLAB_MAIN_LOG DataRowToModel(DataRow row)
        {
            Mod_TSC_SLAB_MAIN_LOG model = new Mod_TSC_SLAB_MAIN_LOG();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_MAIN_ID"] != null)
                {
                    model.C_MAIN_ID = row["C_MAIN_ID"].ToString();
                }
                if (row["C_CKDH"] != null)
                {
                    model.C_CKDH = row["C_CKDH"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["D_DATE"] != null && row["D_DATE"].ToString() != "")
                {
                    model.D_DATE = DateTime.Parse(row["D_DATE"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_MAIN_ID,C_CKDH,N_STATUS,D_DATE,C_BC,C_BZ,C_EMP_ID ");
            strSql.Append(" FROM TSC_SLAB_MAIN_LOG ");
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
            strSql.Append("select count(1) FROM TSC_SLAB_MAIN_LOG ");
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
            strSql.Append(")AS Row, T.*  from TSC_SLAB_MAIN_LOG T ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetLogList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.c_Stl_Grd,b.c_Stove,b.c_Spec,b.c_Std_Code,b.c_slabwh_code,b.c_Slabwh_Area_Code,b.c_Slabwh_Loc_Code,a.C_ID,a.N_STATUS,a.D_DATE,a.C_BC,a.C_BZ,a.C_EMP_ID ");
            strSql.Append(" FROM TSC_SLAB_MAIN_LOG a,TSC_SLAB_MAIN b WHERE a.c_Main_Id=b.c_id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
