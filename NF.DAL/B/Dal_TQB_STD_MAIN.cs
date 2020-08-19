using System;
using System.Data;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using NF.MODEL;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TQB_STD_MAIN
    /// </summary>
    public partial class Dal_TQB_STD_MAIN
    {
        public Dal_TQB_STD_MAIN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TQB_STD_MAIN");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TQB_STD_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TQB_STD_MAIN(");
            strSql.Append("C_ID,C_STD_TYPE,C_STD_CODE,C_STD_DESC,C_STL_GRD,C_PROD_NAME,C_PROD_KIND,C_USES,n_EDIT_NUM,C_EDITION,C_IS_LF,C_IS_RH,C_IS_HL,C_IS_XM,C_IRON_REQUIRE,C_STOCK_REQUIRE,C_DELIVERY_STATE,C_PHYSICS_TIME,N_IS_CHECK,N_STATUS,C_REMARK,C_EMP_ID)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_STD_TYPE,:C_STD_CODE,:C_STD_DESC,:C_STL_GRD,:C_PROD_NAME,:C_PROD_KIND,:C_USES,:n_EDIT_NUM,:C_EDITION,:C_IS_LF,:C_IS_RH,:C_IS_HL,:C_IS_XM,:C_IRON_REQUIRE,:C_STOCK_REQUIRE,:C_DELIVERY_STATE,:C_PHYSICS_TIME,:N_IS_CHECK,:N_STATUS,:C_REMARK,:C_EMP_ID)");
            OracleParameter[] parameters = {
                new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_USES", OracleDbType.Varchar2,100),
                    new OracleParameter(":n_EDIT_NUM", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_EDITION", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_IS_LF", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_RH", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_HL", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_XM", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IRON_REQUIRE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STOCK_REQUIRE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DELIVERY_STATE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PHYSICS_TIME", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_IS_CHECK", OracleDbType.Int16,1),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_STD_TYPE;
            parameters[2].Value = model.C_STD_CODE;
            parameters[3].Value = model.C_STD_DESC;
            parameters[4].Value = model.C_STL_GRD;
            parameters[5].Value = model.C_PROD_NAME;
            parameters[6].Value = model.C_PROD_KIND;
            parameters[7].Value = model.C_USES;
            parameters[8].Value = model.N_EDIT_NUM;
            parameters[9].Value = model.C_EDITION;
            parameters[10].Value = model.C_IS_LF;
            parameters[11].Value = model.C_IS_RH;
            parameters[12].Value = model.C_IS_HL;
            parameters[13].Value = model.C_IS_XM;
            parameters[14].Value = model.C_IRON_REQUIRE;
            parameters[15].Value = model.C_STOCK_REQUIRE;
            parameters[16].Value = model.C_DELIVERY_STATE;
            parameters[17].Value = model.C_PHYSICS_TIME;
            parameters[18].Value = model.N_IS_CHECK;
            parameters[19].Value = model.N_STATUS;
            parameters[20].Value = model.C_REMARK;
            parameters[21].Value = model.C_EMP_ID;

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
        public bool Update(Mod_TQB_STD_MAIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TQB_STD_MAIN set ");
            strSql.Append("C_STD_TYPE=:C_STD_TYPE,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("C_STD_DESC=:C_STD_DESC,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_PROD_NAME=:C_PROD_NAME,");
            strSql.Append("C_PROD_KIND=:C_PROD_KIND,");
            strSql.Append("C_USES=:C_USES,");
            strSql.Append("n_EDIT_NUM=:n_EDIT_NUM,");
            strSql.Append("C_EDITION=:C_EDITION,");
            strSql.Append("C_IS_LF=:C_IS_LF,");
            strSql.Append("C_IS_RH=:C_IS_RH,");
            strSql.Append("C_IS_HL=:C_IS_HL,");
            strSql.Append("C_IS_XM=:C_IS_XM,");
            strSql.Append("C_IRON_REQUIRE=:C_IRON_REQUIRE,");
            strSql.Append("C_STOCK_REQUIRE=:C_STOCK_REQUIRE,");
            strSql.Append("C_DELIVERY_STATE=:C_DELIVERY_STATE,");
            strSql.Append("C_PHYSICS_TIME=:C_PHYSICS_TIME,");
            strSql.Append("N_IS_CHECK=:N_IS_CHECK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_STD_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STD_DESC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_PROD_NAME", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PROD_KIND", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_USES", OracleDbType.Varchar2,100),
                    new OracleParameter(":n_EDIT_NUM", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_EDITION", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_IS_LF", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_RH", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_HL", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IS_XM", OracleDbType.Varchar2,5),
                    new OracleParameter(":C_IRON_REQUIRE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STOCK_REQUIRE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_DELIVERY_STATE", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_PHYSICS_TIME", OracleDbType.Varchar2,20),
                    new OracleParameter(":N_IS_CHECK", OracleDbType.Int16,1),
                    new OracleParameter(":N_STATUS", OracleDbType.Int16,1),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,20),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_STD_TYPE;
            parameters[1].Value = model.C_STD_CODE;
            parameters[2].Value = model.C_STD_DESC;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_PROD_NAME;
            parameters[5].Value = model.C_PROD_KIND;
            parameters[6].Value = model.C_USES;
            parameters[7].Value = model.N_EDIT_NUM;
            parameters[8].Value = model.C_EDITION;
            parameters[9].Value = model.C_IS_LF;
            parameters[10].Value = model.C_IS_RH;
            parameters[11].Value = model.C_IS_HL;
            parameters[12].Value = model.C_IS_XM;
            parameters[13].Value = model.C_IRON_REQUIRE;
            parameters[14].Value = model.C_STOCK_REQUIRE;
            parameters[15].Value = model.C_DELIVERY_STATE;
            parameters[16].Value = model.C_PHYSICS_TIME;
            parameters[17].Value = model.N_IS_CHECK;
            parameters[18].Value = model.N_STATUS;
            parameters[19].Value = model.C_REMARK;
            parameters[20].Value = model.C_EMP_ID;
            parameters[21].Value = model.D_MOD_DT;
            parameters[22].Value = model.C_ID;

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
            strSql.Append("delete from TQB_STD_MAIN ");
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
            strSql.Append("delete from TQB_STD_MAIN ");
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
        public Mod_TQB_STD_MAIN GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_STD_TYPE,C_STD_CODE,C_STD_DESC,C_STL_GRD,C_PROD_NAME,C_PROD_KIND,C_USES,n_EDIT_NUM,C_EDITION,C_IS_LF,C_IS_RH,C_IS_HL,C_IS_XM,C_IRON_REQUIRE,C_STOCK_REQUIRE,C_DELIVERY_STATE,C_PHYSICS_TIME,N_IS_CHECK,N_STATUS,C_REMARK,C_EMP_ID,D_MOD_DT from TQB_STD_MAIN ");
            strSql.Append(" where C_ID=:C_ID  and N_IS_CHECK=1 and N_STATUS=1");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TQB_STD_MAIN model = new Mod_TQB_STD_MAIN();
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
        public Mod_TQB_STD_MAIN DataRowToModel(DataRow row)
        {
            Mod_TQB_STD_MAIN model = new Mod_TQB_STD_MAIN();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_STD_TYPE"] != null)
                {
                    model.C_STD_TYPE = row["C_STD_TYPE"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["C_STD_DESC"] != null)
                {
                    model.C_STD_DESC = row["C_STD_DESC"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_PROD_NAME"] != null)
                {
                    model.C_PROD_NAME = row["C_PROD_NAME"].ToString();
                }
                if (row["C_PROD_KIND"] != null)
                {
                    model.C_PROD_KIND = row["C_PROD_KIND"].ToString();
                }
                if (row["C_USES"] != null)
                {
                    model.C_USES = row["C_USES"].ToString();
                }
                if (row["N_EDIT_NUM"] != null && row["N_EDIT_NUM"].ToString() != "")
                {
                    model.N_EDIT_NUM = decimal.Parse(row["N_EDIT_NUM"].ToString());
                }
                if (row["C_EDITION"] != null)
                {
                    model.C_EDITION = row["C_EDITION"].ToString();
                }
                if (row["C_IS_LF"] != null)
                {
                    model.C_IS_LF = row["C_IS_LF"].ToString();
                }
                if (row["C_IS_RH"] != null)
                {
                    model.C_IS_RH = row["C_IS_RH"].ToString();
                }
                if (row["C_IS_HL"] != null)
                {
                    model.C_IS_HL = row["C_IS_HL"].ToString();
                }
                if (row["C_IS_XM"] != null)
                {
                    model.C_IS_XM = row["C_IS_XM"].ToString();
                }
                if (row["C_IRON_REQUIRE"] != null)
                {
                    model.C_IRON_REQUIRE = row["C_IRON_REQUIRE"].ToString();
                }
                if (row["C_STOCK_REQUIRE"] != null)
                {
                    model.C_STOCK_REQUIRE = row["C_STOCK_REQUIRE"].ToString();
                }
                if (row["C_DELIVERY_STATE"] != null)
                {
                    model.C_DELIVERY_STATE = row["C_DELIVERY_STATE"].ToString();
                }
                if (row["C_PHYSICS_TIME"] != null)
                {
                    model.C_PHYSICS_TIME = row["C_PHYSICS_TIME"].ToString();
                }
                if (row["N_IS_CHECK"] != null && row["N_IS_CHECK"].ToString() != "")
                {
                    model.N_IS_CHECK = decimal.Parse(row["N_IS_CHECK"].ToString());
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
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
        /// 获取标准列表
        /// </summary>              
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
		public DataSet GetList_Type(string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct t.c_stl_grd from tqb_std_main t where 1=1  ");
            if (C_STL_GRD != "")
            {
                strSql.Append(" and t.c_stl_grd='" + C_STL_GRD + "' ");
            }
            strSql.Append(" order by t.c_stl_grd");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取钢种执行标准
        /// </summary>              
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetList_STD(string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.C_ID, t.C_STD_CODE from tqb_std_main t where 1=1  ");
            if (C_STL_GRD != "")
            {
                strSql.Append(" and t.c_stl_grd='" + C_STL_GRD + "' ");
            }
            strSql.Append(" order by t.C_STD_CODE");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取标准列表
        /// </summary>              
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetList_Std(string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  t.C_STD_CODE from tqb_std_main t where 1=1  ");
            if (C_STL_GRD != "")
            {
                strSql.Append(" and t.c_stl_grd='" + C_STL_GRD + "' ");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string C_STD_TYPE, string C_STD_CODE, string C_STL_GRD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_ID,b.c_type_name,a.C_STD_TYPE,a.C_STD_CODE,a.C_STD_DESC,a.C_STL_GRD,a.C_PROD_NAME,a.C_PROD_KIND,a.C_USES,a.n_EDIT_NUM,a.C_EDITION,a.C_IS_LF,a.C_IS_RH,a.C_IS_HL,a.C_IS_XM,a.C_IRON_REQUIRE,a.C_STOCK_REQUIRE,a.C_DELIVERY_STATE,a.C_PHYSICS_TIME,a.N_IS_CHECK,a.N_STATUS,a.C_REMARK,a.C_EMP_ID,a.D_MOD_DT");
            strSql.Append(" FROM TQB_STD_MAIN a inner join tqb_std_type b on a.c_std_type=b.c_id where 1=1");
            if (C_STD_TYPE != "全部")
            {
                strSql.Append(" and C_STD_TYPE= '" + C_STD_TYPE + "'");
            }
            if (C_STD_CODE != "")
            {
                strSql.Append(" and C_STD_CODE= '" + C_STD_CODE + "'");
            }
            if (C_STL_GRD != "")
            {
                strSql.Append(" and C_STL_GRD= '" + C_STL_GRD + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TQB_STD_MAIN ");
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
            strSql.Append(")AS Row, T.*  from TQB_STD_MAIN T ");
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
        /// 获取可代轧钢种标准列表
        /// </summary>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetListByGZ(string C_STL_GRD, string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_STD_CODE,a.C_STL_GRD,'' as N_SFXM");
            strSql.Append(" FROM TQB_STD_MAIN a where  N_STATUS=1 and N_IS_CHECK=1 ");
            strSql.Append("and a.C_ID not in(select a.C_ID from TQB_STD_MAIN a,TPB_REPLACE_GRD b where (a.N_STATUS=1 and a.N_IS_CHECK=1 and b.N_STATUS=1) and (b.c_stl_grd='" + C_STL_GRD + "' and b.c_std_code='" + C_STD_CODE + "') and ( a.c_stl_grd = b.c_replace_grd and a.c_std_code = b.c_replace_std_code ) or (a.c_stl_grd='" + C_STL_GRD + "' and a.c_std_code='" + C_STD_CODE + "' ))");
            strSql.Append("ORDER BY a.C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 获取标准列表
        /// </summary>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <returns></returns>
        public DataSet GetList(string C_STL_GRD,string C_STD_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_ID,a.C_PROD_KIND,a.C_PROD_NAME,a.C_STD_CODE,a.C_STL_GRD ");
            strSql.Append(" FROM TQB_STD_MAIN a where  N_STATUS=1 and N_IS_CHECK=1 ");

            if (C_STD_CODE != "")
            {
                strSql.Append(" and a.C_STD_CODE like '%" + C_STD_CODE + "%'");
            }
            if (C_STL_GRD != "")
            {
                strSql.Append(" and a.C_STL_GRD like '%" + C_STL_GRD + "%'");
            }
            strSql.Append("ORDER BY a.C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取标准列表
        /// </summary>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <returns></returns>
        public DataSet GetGLList(string C_STL_GRD, string C_PROD_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_ID,a.C_PROD_KIND,a.C_PROD_NAME,a.C_STD_CODE,a.C_STL_GRD ");
            strSql.Append(" FROM TQB_STD_MAIN a where  a.N_STATUS=1 and a.N_IS_CHECK=1 ");
            strSql.Append(" AND nvl(a.C_PROD_NAME,'') LIKE '%" + C_PROD_NAME + "%' ");
            strSql.Append(" AND nvl(a.C_STL_GRD,'') LIKE '%" + C_STL_GRD + "%' ");
            strSql.Append("ORDER BY a.C_PROD_NAME");
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得所有钢类
        /// </summary>
        public DataSet GetPMList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT C_PROD_NAME FROM TQB_STD_MAIN T WHERE T.N_IS_CHECK=1 AND T.N_STATUS=1");
           
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得所有钢种
        /// </summary>
        public DataSet GetGZList(string grd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT C_STL_GRD");
            strSql.Append(" FROM TQB_STD_MAIN WHERE N_STATUS=1 ");
            strSql.Append(" AND C_STL_GRD like '%" + grd + "%' ");
            strSql.Append("ORDER BY C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取标准列表(可代轧钢种维护)
        /// </summary>
        /// <param name="C_STD_CODE">标准代码</param>
        /// <param name="C_STL_GRD">钢种</param>
        /// <param name="C_ID">主键</param>
        /// <returns></returns>
        public DataSet GetListKDZ(string C_STD_CODE, string C_STL_GRD, string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.C_ID,a.C_PROD_KIND,a.C_PROD_NAME,a.C_STD_CODE,a.C_STL_GRD ");
            strSql.Append(" FROM TQB_STD_MAIN a where  N_STATUS=1 and N_IS_CHECK=1 ");
            if (C_ID != "")
            {
                strSql.Append("AND A.C_ID <> '" + C_ID + "'");
                strSql.Append("AND A.C_ID NOT IN (SELECT NVL(T.C_STD_MAIN_KDZ_ID, 0) FROM TPB_REPLACE_GRD T WHERE T.C_STD_MAIN_ID = '" + C_ID + "')");
            }

            if (C_STD_CODE != "")
            {
                strSql.Append(" and a.C_STD_CODE like '%" + C_STD_CODE + "%'");
            }
            if (C_STL_GRD != "")
            {
                strSql.Append(" and a.C_STL_GRD like '%" + C_STL_GRD + "%'");
            }
            strSql.Append("ORDER BY a.C_STL_GRD");
            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

