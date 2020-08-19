using System;
using System.Data;
using System.Text;
using NF.MODEL;
using Oracle.ManagedDataAccess.Client;
namespace NF.DAL
{
    /// <summary>
    /// 数据访问类:TMQ_QUALITY_STL_GRD
    /// </summary>
    public partial class Dal_TMQ_QUALITY_STL_GRD
    {
        public Dal_TMQ_QUALITY_STL_GRD()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string C_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMQ_QUALITY_STL_GRD");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Mod_TMQ_QUALITY_STL_GRD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMQ_QUALITY_STL_GRD(");
            strSql.Append("C_ID,C_QUALITY_ID,C_MAT_TYPE,C_MAT_TYPE_N,C_STL_GRD,C_SPEC,C_BATCH_NO,C_STD_CODE,N_SHIP_WGT,N_OBJEC_WGT,N_WGT,C_REMARK,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT)");
            strSql.Append(" values (");
            strSql.Append(":C_ID,:C_QUALITY_ID,:C_MAT_TYPE,:C_MAT_TYPE_N,:C_STL_GRD,:C_SPEC,:C_BATCH_NO,:C_STD_CODE,:N_SHIP_WGT,:N_OBJEC_WGT,:N_WGT,:C_REMARK,:N_STATUS,:N_FLAG,:C_EMP_ID,:C_EMP_NAME,:D_MOD_DT)");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_QUALITY_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_TYPE_N", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SHIP_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_OBJEC_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date)};
            parameters[0].Value = model.C_ID;
            parameters[1].Value = model.C_QUALITY_ID;
            parameters[2].Value = model.C_MAT_TYPE;
            parameters[3].Value = model.C_MAT_TYPE_N;
            parameters[4].Value = model.C_STL_GRD;
            parameters[5].Value = model.C_SPEC;
            parameters[6].Value = model.C_BATCH_NO;
            parameters[7].Value = model.C_STD_CODE;
            parameters[8].Value = model.N_SHIP_WGT;
            parameters[9].Value = model.N_OBJEC_WGT;
            parameters[10].Value = model.N_WGT;
            parameters[11].Value = model.C_REMARK;
            parameters[12].Value = model.N_STATUS;
            parameters[13].Value = model.N_FLAG;
            parameters[14].Value = model.C_EMP_ID;
            parameters[15].Value = model.C_EMP_NAME;
            parameters[16].Value = model.D_MOD_DT;

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
        public bool Update(Mod_TMQ_QUALITY_STL_GRD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMQ_QUALITY_STL_GRD set ");
            strSql.Append("C_QUALITY_ID=:C_QUALITY_ID,");
            strSql.Append("C_MAT_TYPE=:C_MAT_TYPE,");
            strSql.Append("C_MAT_TYPE_N=:C_MAT_TYPE_N,");
            strSql.Append("C_STL_GRD=:C_STL_GRD,");
            strSql.Append("C_SPEC=:C_SPEC,");
            strSql.Append("C_BATCH_NO=:C_BATCH_NO,");
            strSql.Append("C_STD_CODE=:C_STD_CODE,");
            strSql.Append("N_SHIP_WGT=:N_SHIP_WGT,");
            strSql.Append("N_OBJEC_WGT=:N_OBJEC_WGT,");
            strSql.Append("N_WGT=:N_WGT,");
            strSql.Append("C_REMARK=:C_REMARK,");
            strSql.Append("N_STATUS=:N_STATUS,");
            strSql.Append("N_FLAG=:N_FLAG,");
            strSql.Append("C_EMP_ID=:C_EMP_ID,");
            strSql.Append("C_EMP_NAME=:C_EMP_NAME,");
            strSql.Append("D_MOD_DT=:D_MOD_DT");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_QUALITY_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_TYPE", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_MAT_TYPE_N", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_STL_GRD", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_SPEC", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_BATCH_NO", OracleDbType.Varchar2,20),
                    new OracleParameter(":C_STD_CODE", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_SHIP_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_OBJEC_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":N_WGT", OracleDbType.Decimal,15),
                    new OracleParameter(":C_REMARK", OracleDbType.Varchar2,100),
                    new OracleParameter(":N_STATUS", OracleDbType.Decimal,1),
                    new OracleParameter(":N_FLAG", OracleDbType.Decimal,1),
                    new OracleParameter(":C_EMP_ID", OracleDbType.Varchar2,100),
                    new OracleParameter(":C_EMP_NAME", OracleDbType.Varchar2,100),
                    new OracleParameter(":D_MOD_DT", OracleDbType.Date),
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)};
            parameters[0].Value = model.C_QUALITY_ID;
            parameters[1].Value = model.C_MAT_TYPE;
            parameters[2].Value = model.C_MAT_TYPE_N;
            parameters[3].Value = model.C_STL_GRD;
            parameters[4].Value = model.C_SPEC;
            parameters[5].Value = model.C_BATCH_NO;
            parameters[6].Value = model.C_STD_CODE;
            parameters[7].Value = model.N_SHIP_WGT;
            parameters[8].Value = model.N_OBJEC_WGT;
            parameters[9].Value = model.N_WGT;
            parameters[10].Value = model.C_REMARK;
            parameters[11].Value = model.N_STATUS;
            parameters[12].Value = model.N_FLAG;
            parameters[13].Value = model.C_EMP_ID;
            parameters[14].Value = model.C_EMP_NAME;
            parameters[15].Value = model.D_MOD_DT;
            parameters[16].Value = model.C_ID;

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
            strSql.Append("delete from TMQ_QUALITY_STL_GRD ");
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
            strSql.Append("delete from TMQ_QUALITY_STL_GRD ");
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
        public Mod_TMQ_QUALITY_STL_GRD GetModel(string C_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUALITY_ID,C_MAT_TYPE,C_MAT_TYPE_N,C_STL_GRD,C_SPEC,C_BATCH_NO,C_STD_CODE,N_SHIP_WGT,N_OBJEC_WGT,N_WGT,C_REMARK,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT from TMQ_QUALITY_STL_GRD ");
            strSql.Append(" where C_ID=:C_ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":C_ID", OracleDbType.Varchar2,100)          };
            parameters[0].Value = C_ID;

            Mod_TMQ_QUALITY_STL_GRD model = new Mod_TMQ_QUALITY_STL_GRD();
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
        public Mod_TMQ_QUALITY_STL_GRD DataRowToModel(DataRow row)
        {
            Mod_TMQ_QUALITY_STL_GRD model = new Mod_TMQ_QUALITY_STL_GRD();
            if (row != null)
            {
                if (row["C_ID"] != null)
                {
                    model.C_ID = row["C_ID"].ToString();
                }
                if (row["C_QUALITY_ID"] != null)
                {
                    model.C_QUALITY_ID = row["C_QUALITY_ID"].ToString();
                }
                if (row["C_MAT_TYPE"] != null)
                {
                    model.C_MAT_TYPE = row["C_MAT_TYPE"].ToString();
                }
                if (row["C_MAT_TYPE_N"] != null)
                {
                    model.C_MAT_TYPE_N = row["C_MAT_TYPE_N"].ToString();
                }
                if (row["C_STL_GRD"] != null)
                {
                    model.C_STL_GRD = row["C_STL_GRD"].ToString();
                }
                if (row["C_SPEC"] != null)
                {
                    model.C_SPEC = row["C_SPEC"].ToString();
                }
                if (row["C_BATCH_NO"] != null)
                {
                    model.C_BATCH_NO = row["C_BATCH_NO"].ToString();
                }
                if (row["C_STD_CODE"] != null)
                {
                    model.C_STD_CODE = row["C_STD_CODE"].ToString();
                }
                if (row["N_SHIP_WGT"] != null && row["N_SHIP_WGT"].ToString() != "")
                {
                    model.N_SHIP_WGT = decimal.Parse(row["N_SHIP_WGT"].ToString());
                }
                if (row["N_OBJEC_WGT"] != null && row["N_OBJEC_WGT"].ToString() != "")
                {
                    model.N_OBJEC_WGT = decimal.Parse(row["N_OBJEC_WGT"].ToString());
                }
                if (row["N_WGT"] != null && row["N_WGT"].ToString() != "")
                {
                    model.N_WGT = decimal.Parse(row["N_WGT"].ToString());
                }
                if (row["C_REMARK"] != null)
                {
                    model.C_REMARK = row["C_REMARK"].ToString();
                }
                if (row["N_STATUS"] != null && row["N_STATUS"].ToString() != "")
                {
                    model.N_STATUS = decimal.Parse(row["N_STATUS"].ToString());
                }
                if (row["N_FLAG"] != null && row["N_FLAG"].ToString() != "")
                {
                    model.N_FLAG = decimal.Parse(row["N_FLAG"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUALITY_ID,C_MAT_TYPE,C_MAT_TYPE_N,C_STL_GRD,C_SPEC,C_BATCH_NO,C_STD_CODE,N_SHIP_WGT,N_OBJEC_WGT,N_WGT,C_REMARK,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMQ_QUALITY_STL_GRD ");
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
            strSql.Append("select count(1) FROM TMQ_QUALITY_STL_GRD ");
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
            strSql.Append(")AS Row, T.*  from TMQ_QUALITY_STL_GRD T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "TMQ_QUALITY_STL_GRD";
			parameters[1].Value = "C_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获取客户质量钢种列表
        /// </summary>
        /// <param name="C_QUALITY_ID">质量主表ID</param>
        /// <returns></returns>
        public DataSet GetQUALITY_STL_GRD(string C_QUALITY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_ID,C_QUALITY_ID,C_MAT_TYPE,C_MAT_TYPE_N,C_STL_GRD,C_SPEC,C_BATCH_NO,C_STD_CODE,N_SHIP_WGT,N_OBJEC_WGT,N_WGT,C_REMARK,N_STATUS,N_FLAG,C_EMP_ID,C_EMP_NAME,D_MOD_DT ");
            strSql.Append(" FROM TMQ_QUALITY_STL_GRD  where C_QUALITY_ID='" + C_QUALITY_ID + "'");

            return DbHelperOra.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

